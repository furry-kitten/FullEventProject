using FO.Models;
using FO.Models.Перечисления;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using System;
using System.Threading.Tasks;

namespace DBLib
{
    public class EventContext : DbContext
    {
        public EventContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Dancer> Dancers { get; set; }
        public DbSet<GroupOfOrganiziers> GroupsOfOrganiziers { get; set; }
        public DbSet<SHAClasses> SHAClasses { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<LastEventsChanges> LastEventsChanges { get; set; }
        public DbSet<Periodicity> Periodicities { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Club> Clubs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(Constants.CreatingString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property((p) => p.Gender)
                .HasConversion<string>();

            modelBuilder.Entity<Nomination>()
                .Property((p) => p.Direction)
                .HasConversion<string>();

            modelBuilder.Entity<SHAClasses>()
                .Property((p) => p.Direction)
                .HasConversion<string>();

            modelBuilder.Entity<Event>()
                .Property((p) => p.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Dancer)
                .WithOne(d => d.Person)
                .HasForeignKey<Dancer>(fk => fk.PersonKey);

            modelBuilder.Entity<Event>()
                .HasMany((p) => p.Dancers)
                .WithMany((f) => f.EventSubList);

            modelBuilder.Entity<GroupOfOrganiziers>()
                .HasOne((g) => g.Event)
                .WithOne((e) => e.Organiziers)
                .HasForeignKey<Event>((fk) => fk.GroupId);

            modelBuilder.Entity<Periodicity>()
                .HasOne((g) => g.Event)
                .WithOne((e) => e.Periodicity)
                .HasForeignKey<Event>((fk) => fk.PeriodicityId);

            modelBuilder.Entity<LastEventsChanges>()
                .HasMany((p) => p.Dancers)
                .WithOne();

            modelBuilder.Entity<LastEventsChanges>()
                .HasMany((p) => p.Events)
                .WithOne();

            modelBuilder.Entity<GroupOfOrganiziers>()
                .HasMany(p => p.Dancers)
                .WithOne();

            modelBuilder.Entity<Event>()
                .HasMany((p) => p.Nominations)
                .WithOne();

            modelBuilder.Entity<Club>()
                .HasOne(p => p.Group)
                .WithOne(d => d.Club)
                .HasForeignKey<GroupOfOrganiziers>(fk => fk.IdClub);

            //modelBuilder.Entity<Rule>().ToTable("RuleView", t => t.ExcludeFromMigrations());
        }

        public void RegenerateDB()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
