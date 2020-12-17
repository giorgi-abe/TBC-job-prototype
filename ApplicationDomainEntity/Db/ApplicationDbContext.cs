using ApplicationDomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomainEntity.Db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Person> PersonTb { get; set; }
        public DbSet<PhoneNumber> PhoneNumberTb { get; set; }
        public DbSet<ConnectedPerson> ConnectedPersonTb { get; set; }
        public DbSet<City> CityTb { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(
                @"Data source=WINDOWS-2030BTI;Database=PersonApp;Trusted_Connection=true;MultipleActiveResultSets=true;");

        }
        protected internal virtual void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasMany<PhoneNumber>(g => g.Numbers)
                .WithOne(e => e.Person)
                .HasForeignKey(e => e.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Person>()
                .HasMany<ConnectedPerson>(g => g.ConnectedPeople)
                .WithOne(e => e.Person)
                .HasForeignKey(e => e.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
