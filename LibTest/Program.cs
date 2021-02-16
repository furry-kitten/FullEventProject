using FO.Models;
using FO.Models.Rules;
using FO.Models.Перечисления;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var rules = new Rule();
            var dancer = new Dancer("Anya", "Monsicova", Gender.Female);
            var ruleDate = DateTime.Now.AddDays(10);
            var classes = new SHAClasses(new Direction() { Name = "JnJ", Comment = "" }, "RS", 18);
            var allClasses = new Classes[] { new Classes
            {
                Dancer = dancer,
                Points = 10,
                SHAClasses = classes
            } };

            rules.CreateTimerRule("Название", "Описание", ruleDate, TimerRule.TimerRuleType.CanSubscribe);
            rules.CreateСongruenceRule("Название", "Описание", classes, 10);

            var accepte = rules.Accepted(dancer, allClasses);

            Console.WriteLine(dancer.ToString());
            Console.WriteLine($"{accepte}");

            Console.ReadKey();
        }
    }
}
