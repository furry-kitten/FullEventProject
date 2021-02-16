using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models.Rules
{
    public class TimerRule : Accepted<DateTime>
    {
        public TimerRule() : base() { }
        public TimerRule(string name, string decription) : base(name, decription) { }
        public TimerRule(string name, string decription, DateTime criticalEventDate, TimerRuleType type) : base(name, decription)
        {
            SetDateTime(criticalEventDate, type);
        }
        public TimerRule(BaseRule baseRule, DateTime criticalEventDate, TimerRuleType type) : base(baseRule.Name, baseRule.Decription)
        {
            SetDateTime(criticalEventDate, type);
        }

        public DateTime CriticalEventDate
        {
            get => MainParametr;
            set { MainParametr = value; OnPropertyChanged(); }
        }
        public override bool Accept(DateTime item) => predicate(item);
        public void SetRuleType(TimerRuleType type) => SetType(type);

        private void SetDateTime(DateTime criticalEventDate, TimerRuleType type)
        {
            this.MainParametr = criticalEventDate;
            SetType(type);
        }
        private void SetType(TimerRuleType type)
        {
            switch (type)
            {
                case TimerRuleType.CanSubscribe:
                    predicate -= MustBePaid;
                    predicate += CanSubscribe;
                    break;
                case TimerRuleType.MustBePaid:
                    predicate -= CanSubscribe;
                    predicate += MustBePaid;
                    break;
            }
        }
        private bool MustBePaid(DateTime dateTime) => dateTime > MainParametr;
        private bool CanSubscribe(DateTime dateTime) => dateTime < MainParametr;

        private Predicate<DateTime> predicate;

        public enum TimerRuleType
        {
            MustBePaid,
            CanSubscribe
        }
    }
}
