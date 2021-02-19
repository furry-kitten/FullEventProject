using FO.Models.Rules.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models.Rules
{
    internal class TimerRule : Accepted<DateTime>
    {
        private string toString;
        private string currentMessage;
        private TimerRuleType ruleType;

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
        public TimerRuleType RuleType
        {
            get => ruleType;
            set => SetType(value);
        }

        public override bool Accept(DateTime item) => predicate(item);
        public bool MustBePaid() => MustBePaid(DateTime.Now);
        public void SetRuleType(TimerRuleType type) => SetType(type);
        public string GetRuleText() => toString;
        public override string ToString()
        {
            var now = DateTime.Now;

            if (Accept(now) && ruleType == TimerRuleType.CanSubscribe)
                return toString;
            else if (ruleType == TimerRuleType.MustBePaid)
            {
                if (Accept(now))
                    return currentMessage;
                else
                    return toString;
            }

            return currentMessage;
        }

        private void SetDateTime(DateTime criticalEventDate, TimerRuleType type)
        {
            this.MainParametr = criticalEventDate;
            SetType(type);
        }
        private void SetType(TimerRuleType type)
        {
            ruleType = type;

            switch (type)
            {
                case TimerRuleType.CanSubscribe:
                    predicate -= MustBePaid;
                    predicate += CanSubscribe;

                    toString = $"Запись возможна до {MainParametr}";
                    currentMessage = $"Запись звершена!";
                    break;
                case TimerRuleType.MustBePaid:
                    predicate -= CanSubscribe;
                    predicate += MustBePaid;

                    toString = $"После {MainParametr} оплата обязательна";
                    currentMessage = $"Нужно оплатить!";
                    break;
            }

            OnPropertyChanged();
        }
        private bool MustBePaid(DateTime dateTime) => dateTime > MainParametr;
        private bool CanSubscribe(DateTime dateTime) => dateTime <= MainParametr;

        private Predicate<DateTime> predicate;
    }
}
