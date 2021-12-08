using MVCData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Data
{
    public class MVCEFDbContext: DbContext
    {
    
        public DbSet<PersonDB>People { get; set; }
        public DbSet<MLink>MLinks { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country>Countries { get; set; }

        public MVCEFDbContext(DbContextOptions<MVCEFDbContext>options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonDB>()
           .HasOne(person => person.City)
           .WithMany(city => city.People)
           .HasForeignKey(person => person.CityId);

            modelBuilder.Entity<City>()
           .HasOne(city => city.Country)
           .WithMany(country => country.Cities)
           .HasForeignKey(city => city.CountryId);

            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Iran", CountryCode = "IR" });

            modelBuilder.Entity<City>().HasData(new City { Id = 1, Name = "Tehran", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { Id = 2, Name = "Shiraz", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { Id = 3, Name = "Mashhad", CountryId = 1 });





            modelBuilder.Entity<PersonDB>().HasData(new PersonDB { ID = 1, Name = "Mahnoush", CityId = 1, PhoneNumber = "0738090123" });
            modelBuilder.Entity<PersonDB>().HasData(new PersonDB { ID = 2, Name = "Donja", CityId = 2, PhoneNumber = "0748090124" });
            modelBuilder.Entity<PersonDB>().HasData(new PersonDB { ID = 3, Name = "Awa", CityId = 3, PhoneNumber = "0758090125" });

            modelBuilder.Entity<MLink>().HasData(new MLink { Name = "AJAX", Title = "AJAX", LinkURL = "/Ajax/Index" });
            modelBuilder.Entity<MLink>().HasData(new MLink { Name = "Cities", Title = "Cities", LinkURL = "/Cities/" });
            modelBuilder.Entity<MLink>().HasData(new MLink { Name = "Countries", Title = "Countries", LinkURL = "/Countries/" });
            modelBuilder.Entity<MLink>().HasData(new MLink { Name = "People", Title = "People", LinkURL = "/Home/" });



        }
    }
 }

