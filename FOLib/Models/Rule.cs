using FO.Models.Rules;
using FO.Models.Rules.Enums;

using System;
using System.Collections.Generic;
using System.Linq;

namespace FO.Models
{
    public class Rule : BaseRule
    {
        private List<CongruenceRule> congruenceRules = new List<CongruenceRule>();
        private List<TimerRule> timerRules = new List<TimerRule>();

        public Rule() { }

        /*
        public void CreatRule(string name, string decription, RuleType type)
        {
            switch (type)
            {
                case RuleType.Timer:
                    CreateTimerRule(name, decription);
                    break;
                case RuleType.Сongruence:
                    CreateСongruenceRule(name, decription);
                    break;
                case RuleType.All:
                    CreateTimerRule(name, decription);
                    CreateСongruenceRule(name, decription);
                    break;
                default:
                    return;
            }
        }
        */
        public void CreateTimerRule(string name, string decription, DateTime criticalEventDate, TimerRuleType type)
        {
            var rule = new TimerRule(name, decription, criticalEventDate, type);

            timerRules.Add(rule);
        }
        public void CreateСongruenceRule(string name, string decription, SHAClasses classes, byte minPoints)
        {
            var class1 = new Classes()
            {
                Points = minPoints,
                SHAClasses = classes
            };
            var rule = CongruenceRule.CreateСongruenceRule(name, decription, class1, minPoints);

            congruenceRules.Add(rule);
        }
        public bool Accepted(Dancer dancer)
        {
            var accept = true;
            var classes = dancer.Classes;
            var canSubscribeRules = timerRules.Where((type) => type.RuleType == TimerRuleType.CanSubscribe);

            foreach (var rule in canSubscribeRules)
                accept &= rule.Accept(DateTime.Now);

            foreach (var rule in congruenceRules)
                accept &= RightClass(rule, classes);

            return accept;
        }
        public bool MustBePaid()
        {
            var mustBePaidRules = timerRules.Where((type) => type.RuleType == TimerRuleType.MustBePaid);

            foreach (var rule in mustBePaidRules)
                if (!rule.MustBePaid())
                    return false;

            return true;
        }
        public void DeleteOldTimerRules()
        {
            var rules = timerRules.Where((p) => p.MainParametr < DateTime.Now).ToArray();

            foreach(var rule in rules)
            timerRules.RemoveAt(timerRules.IndexOf(rule));
        }
        public void ChangeTimerRules(DateTime criticalEventDate, TimerRuleType ruleType)
        {
            var rule = timerRules.Find((r) => r.RuleType == ruleType);

            rule.MainParametr = criticalEventDate;
        }
        public void ChangeToNextDate(Periodicity periodicity)
        {
            foreach (var rule in timerRules)
                periodicity.ChangeEventDate(rule.MainParametr);
        }

        private bool RightClass(CongruenceRule rule, IEnumerable<Classes> classes)
        {
            var accept = false;

            foreach (var Class in classes)
                accept |= rule.Accept(Class);

            return accept;
        }

        public override string ToString()
        {
            var str = string.Empty;

            foreach (var timer in timerRules)
                str += $"{timer} \n";

            return str;
        }
    }
}
