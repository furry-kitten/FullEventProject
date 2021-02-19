using FO.Models;

using Microsoft.EntityFrameworkCore.ChangeTracking;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLib.Update
{
    internal class DBUpdater
    {
        public void UpdateData<T>(List<T> data)
        {
            using(var context = new EventContext())
                foreach (var item in data)
                    context.Update(item);
        }
    }
}
