using DBLib.Defualts;

using FO.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLib.Masters
{
    public class DBHelper : BaseVM
    {
        private string connectionString;
        private AllData data;

        public DBHelper()
        {
            connectionString = Constants.HomeConnectionString;

            SetDefaultClasses();
            GetAllData();

            /*
            SetDefaultClassesAsync().Wait();
            GetAllDataAsync().Wait();
            */
        }
        public DBHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string ConnectionString
        {
            get => connectionString;
            set { connectionString = value; OnPropertyChanged(); }
        }
        public AllData Data
        {
            get => GetAllData();
            set { data= value; OnPropertyChanged(); }
        }
        public void RegenerateDB()
        {
            using (var context = new EventContext())
            {
                context.RegenerateDB();

                SetDefaultClasses();
                GetAllData();

                Console.WriteLine("--------------------");
                Console.WriteLine("База была пересоздана!");
                Console.WriteLine("--------------------");
            }
        }

        public async Task SetDefaultClassesAsync()
        {
            await Task.Run(() => SetDefaultClasses());
        }
        public async Task GetAllDataAsync()
        {
            await Task.Run(() => GetAllData());
        }

        private void SetDefaultClasses()
        {
            using (var eventContext = new EventContext())
            {
                var defaults = new DefaultDBRecords();

                if (eventContext.SHAClasses.ToList().Count != defaults.SHAClasses.Count)
                {
                    if (eventContext.SHAClasses.ToList().Count > 0)
                        foreach (var classes in eventContext.SHAClasses)
                            eventContext.SHAClasses.Remove(classes);

                    eventContext.SHAClasses.AddRange(defaults.SHAClasses);
                    eventContext.SaveChanges();
                }
            }
        }
        private AllData GetAllData()
        {
            using (var eventContext = new EventContext())
            {
                var activities = new List<Activity>();

                foreach (var @event in eventContext.Events)
                    activities.Add(
                        new Activity
                        {
                            Event = @event 
                        });

                data = new AllData
                {
                    SHAClasses = eventContext.SHAClasses.ToList(),
                    Changes = eventContext.LastEventsChanges.ToList(),
                    Dancers = eventContext.Dancers.ToList(),
                    Events = activities,
                    Groups = eventContext.GroupsOfOrganiziers.ToList(),
                    People = eventContext.People.ToList(),
                    Plans = eventContext.Plans.ToList(),
                    Clubs = eventContext.Clubs.ToList()
                };
            }

            return data;
        }
    }
}
