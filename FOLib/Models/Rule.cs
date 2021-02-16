using FO.Models.Rules;
using FO.Models.Перечисления;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models
{
    public class Rule : BaseRule
    {
        private List<СongruenceRule> congruenceRules = new List<СongruenceRule>();
        private List<TimerRule> timerRules = new List<TimerRule>();
        private Func<bool> func;

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
        public TimerRule CreateTimerRule(string name, string decription, DateTime criticalEventDate, TimerRule.TimerRuleType type)
        {
            var rule = new TimerRule(name, decription, criticalEventDate, type);

            timerRules.Add(rule);

            return rule;
        }
        public СongruenceRule CreateСongruenceRule(string name, string decription, SHAClasses classes, byte minPoints)
        {
            var class1 = new Classes()
            {
                Points = minPoints,
                SHAClasses = classes
            };
            var rule = СongruenceRule.CreateСongruenceRule(name, decription, class1, minPoints);

            congruenceRules.Add(rule);

            return rule;
        }
        public bool Accepted(Dancer dancer, Classes[] dancerClasses)
        {
            var accept = true;
            var classes = dancerClasses.Where((item) => item.Dancer.Equals(dancer));

            foreach (var rule in timerRules)
                accept &= rule.Accept(DateTime.Now);

            foreach (var rule in congruenceRules)
                accept &= RightClass(rule, classes);

            return accept;
        }

        private bool RightClass(СongruenceRule rule, IEnumerable<Classes> classes)
        {
            var accept = false;

            foreach (var Class in classes)
                accept |= rule.Accept(Class);

            return accept;
        }
    }
}
