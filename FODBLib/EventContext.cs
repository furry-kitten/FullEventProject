using FO.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FODBLib
{
    internal class EventContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Dancer> Dancers { get; set; }
        public DbSet<GroupOfOrganiziers> GroupsOfOrganiziers { get; set; }
        public DbSet<SHAClasses> SHAClasses { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<LastEventsChanges> LastEventsChanges { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasKey<Guid>((i) => i.Id)
                ;
        }
    }
}
