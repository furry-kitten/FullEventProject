using DBLib.Masters;

using FO.Models;
using FO.Models.ForClient;
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

            var data = GetAllData(dBHelper.Data.SHAClasses);

            foreach (var danser in data.Dancers)
                Console.WriteLine($"{danser}\n");

            Console.WriteLine("---------------------------------------------------");
            //CheckRules(data);
            CheckLECAddition(data);

            foreach (var danser in data.Dancers)
                Console.WriteLine($"{danser}\n");

            Console.WriteLine(UserSettings.CurrentDirectory);

            Console.ReadKey();
        }

        private static void CheckLECAddition(AllData data)
        {
            var @event = data.Activities[0].Event;
            var changes = new Dictionary<Dancer, Dictionary<Direction, byte>>();

            foreach(var dancer in data.Dancers)
            {
                var dancerChanges = new Dictionary<Direction, byte>();

                dancerChanges.Add(Direction.Classic, 0);
                dancerChanges.Add(Direction.JnJ, 0);

                changes.Add(dancer, dancerChanges);
            }

            data.AddAllEventChanges(@event, changes);
        }
        private static void CheckRules(AllData data)
        {
            var rule = new Rule();

            rule.CreateTimerRule("1", "-", DateTime.Now.AddDays(3), TimerRuleType.MustBePaid);
            rule.CreateTimerRule("1", "-", DateTime.Now.AddDays(4), TimerRuleType.CanSubscribe);

            foreach (var danser in data.Dancers)
                Console.WriteLine($"{danser}\n");

            var shac = data.SHAClasses.OrderBy(c => c.Direction).ThenBy(c => c.Significance);
            foreach (var danser in shac)
                Console.WriteLine($"{danser}\n");

            foreach (var danser in data.Groups)
                Console.WriteLine($"{danser}\n");

            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"{rule} {DateTime.Now} {rule.Accepted(data.Dancers[0])} {rule.MustBePaid()}");
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
            {
                var significance = Convert.ToInt32(dancer.Person.Name) % 5 + 1;
                dancer.Classes = new List<Classes>
                {
                    new Classes(dancer, shaClasses.ToList().Find(c => c.Direction == Direction.JnJ && c.Significance == significance), Convert.ToByte(dancers.IndexOf(dancer)))
                    {
                        Points = Convert.ToByte(rdmCount.Next(0, 24))
                    },
                    new Classes(dancer, shaClasses.ToList().Find(c => c.Direction == Direction.Classic), Convert.ToByte(dancers.IndexOf(dancer)))
                    {
                        Points = Convert.ToByte(rdmCount.Next(0, 24))
                    }
                };
            }

            events.Add(new Activity
            {
                Event = new Event
                {
                    Name = "Кубок АСХ",
                    Dancers = dancers,
                    Organiziers = groups[0],
                    Type = EventType.Сompetition,
                    LastEventsChanges = new List<LastEventsChanges>()
                }
            });

            return new AllData()
            {
                Changes = changes,
                Dancers = dancers,
                Activities = events,
                Groups = groups,
                People = people,
                Plans = plans,
                SHAClasses = shaClasses
            };
        }
    }
}
