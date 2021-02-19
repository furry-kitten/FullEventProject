using DBLib.Masters;

using FO.Models;
using FO.Models.Rules.Enums;
using FO.Models.Перечисления;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DBLibTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var dBHelper = new DBHelper();
            var settings = new UserSettings();
            var rule = new Rule();

            var data = GetAllData(dBHelper.Data.SHAClasses);

            rule.CreateTimerRule("1", "-", DateTime.Now.AddDays(3), TimerRuleType.MustBePaid);
            rule.CreateTimerRule("1", "-", DateTime.Now.AddDays(4), TimerRuleType.CanSubscribe);

            foreach (var danser in data.Dancers)
                Console.WriteLine($"{danser}\n");

            foreach (var danser in data.SHAClasses)
                Console.WriteLine($"{danser}\n");

            foreach (var danser in data.Groups)
                Console.WriteLine($"{danser}\n");

            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine(settings.FilePath);

            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"{rule} {DateTime.Now} {rule.Accepted(data.Dancers[0])} {rule.MustBePaid()}");

            Console.ReadKey();
        }

        private static AllData GetAllData(List<SHAClasses> shaClasses)
        {
            var people = new List<Person>();
            var events = new List<Activity>();
            var dancers = new List<Dancer>();
            var changes = new List<LastEventsChanges>();
            var groups = new List<GroupOfOrganiziers>();
            var plans = new List<Plan>();

            for (int i = 0; i < 10; i++)
            {
                people.Add(new Person
                {
                    Name = $"{i}",
                    Sername = $"{i}{i}",
                    Patronym = $"{i}{i}{i}",
                    Gender = Gender.Female
                });

                dancers.Add(new Dancer(people[i], 0));

            }

            var rdmCount = new Random();

            for (int i = 0; i < 3; i++)
            {
                var dancersInGroup = new List<Dancer>();
                var count = rdmCount.Next(0, 5);
                var rdm = new Random(count);

                for (int j = 0; j < count; j++)
                {
                    var index = rdm.Next(0, dancers.Count - 1);

                    dancersInGroup.Add(dancers[index]);
                }

                groups.Add(
                    new GroupOfOrganiziers
                    {
                        Name = $"{i}",
                        Dancers = dancersInGroup
                    });
            }

            foreach (var dancer in dancers)
                dancer.Classes = new List<Classes>
                {
                    new Classes(dancer, shaClasses.ToList().Find(c => c.Direction == Direction.JnJ), Convert.ToByte(dancers.IndexOf(dancer))),
                    new Classes(dancer, shaClasses.ToList().Find(c => c.Direction == Direction.Classic), Convert.ToByte(dancers.IndexOf(dancer)))
                };

            return new AllData()
            {
                Changes = changes,
                Dancers = dancers,
                Events = events,
                Groups = groups,
                People = people,
                Plans = plans,
                SHAClasses = shaClasses
            };
        }
    }
}
