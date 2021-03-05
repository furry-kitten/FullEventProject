using FO.Models;
using FO.Models.ForClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLib.Masters.Update
{
    internal class UpdateDataBase
    {
        public void UpdateAllDB(AllData data)
        {
            UpdatePerson(data.People);
        }

        public void UpdatePerson(List<Person> newData)
        {
            var dbData = new EventContext().People;
            var dataToUpdate = new List<Person>();

            foreach(var person in newData)
            {
                try
                {
                    dataToUpdate.Add(dbData.First((p) => p.Id == person.Id));
                }
                catch(ArgumentNullException e)
                {
                    continue;
                }
            }

            if (dataToUpdate.Count != 0)
                UpdateItem(dataToUpdate);
        }

        public void UpdateItem<T>(List<T> items) where T : DBClass
        {
            using(var context = new EventContext())
            {
                context.UpdateRange(items);
            }
        }
    }
}
