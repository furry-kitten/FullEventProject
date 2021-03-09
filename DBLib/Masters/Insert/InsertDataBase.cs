using FO.Models;
using FO.Models.ForClient;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace DBLib.Masters.Insert
{
    internal class InsertDataBase
    {
        public void InsertAllNewData(AllData data, bool refresh = false)
        {
            using (var context = new EventContext())
            {
                if (refresh)
                    context.RegenerateDB();

                context.NominationCompetitors.AddRange(data.NominationCompetitors);
                context.LastEventsChanges.AddRange(data.Changes);
                context.Periodicities.AddRange(data.Periodicities);
                context.Plans.AddRange(data.Plans);
                context.Events.AddRange(GetEvents(data.Activities));
                context.Classes.AddRange(data.Classes);
                context.GroupsOfOrganiziers.AddRange(data.Groups);
                context.Clubs.AddRange(data.Clubs);
                context.People.AddRange(data.People);
                context.Dancers.AddRange(data.Dancers);
                context.SHAClasses.AddRange(data.SHAClasses);

                context.SaveChanges();
            }
        }
        public void Refresh(AllData data) => InsertAllNewData(data, true);

        private void AddDancers(EventContext context, List<Dancer> dancers)
        {
            using(context)
            foreach (var dancer in dancers)
            {
                    try
                    {
                        context.Dancers.Add(dancer);
                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
            }
        }
        private List<Event> GetEvents(List<Activity> activities)
        {
            var events = new List<Event>();

            foreach (var activity in activities)
            {
                events.Add(activity.Event);
            }

            return events;
        }
    }
}
