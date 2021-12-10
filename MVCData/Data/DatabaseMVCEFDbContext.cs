using MVCData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Data
{
    public class DatabaseMVCEFDbContext: DbContext
    {
    
        public DbSet<PersonDB>People { get; set; }
        public DbSet<MLink>MLinks { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country>Countries { get; set; }
        public DbSet<PersonLanguage>PersonLanguages { get; set; }
        public DbSet<Language>Languages { get; set; }
        public DatabaseMVCEFDbContext(DbContextOptions<DatabaseMVCEFDbContext>options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<PersonLanguage>().HasKey(pl => new { pl.PersonId, pl.LanguageId });

          modelBuilder.Entity<PersonLanguage>()
         .HasOne(pl => pl.Person)
         .WithMany(person => person.Languages)
         .HasForeignKey(pl => pl.PersonId);

          modelBuilder.Entity<PersonLanguage>()
         .HasOne(pl => pl.Language)
         .WithMany(language => language.People)
         .HasForeignKey(pl => pl.LanguageId);

          modelBuilder.Entity<PersonDB>()
         .HasOne(person => person.City)
         .WithMany(city => city.People)
         .HasForeignKey(person => person.CityId);

          modelBuilder.Entity<City>()
         .HasOne(city => city.Country)
         .WithMany(country => country.Cities)
         .HasForeignKey(city => city.CountryId);


            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "IRAN",CountryCode= "IR"});
            modelBuilder.Entity<Country>().HasData(new Country { Id = 2, Name = "Norge", CountryCode = "NO" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 3, Name = "USA", CountryCode = "US" });

            modelBuilder.Entity<City>().HasData(new City { Id = 1, Name = "Tehran", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { Id = 2, Name = "Shiraz", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { Id = 3, Name = "Mashhad", CountryId = 1 });


            modelBuilder.Entity<PersonDB>().HasData(new PersonDB { ID = 1, Name = "Mahnoush", CityId = 1, PhoneNumber = "0738090123" });
            modelBuilder.Entity<PersonDB>().HasData(new PersonDB { ID = 2, Name = "Donja", CityId = 2, PhoneNumber = "0748090124" });
            modelBuilder.Entity<PersonDB>().HasData(new PersonDB { ID = 3, Name = "Awa", CityId = 3, PhoneNumber = "0758090125" });

            modelBuilder.Entity<MLink>().HasData(new MLink { Name = "AJAX", Title = "AJAX", LinkURL = "/Ajax/Index" });
            modelBuilder.Entity<MLink>().HasData(new MLink { Name = "Cities", Title = "Cities", LinkURL = "/Cities/" });
            modelBuilder.Entity<MLink>().HasData(new MLink { Name = "Countries", Title = "Countries", LinkURL = "/Countries/" });
            modelBuilder.Entity<MLink>().HasData(new MLink { Name = "Languages", Title = "Languages", LinkURL = "/Languages/" });
            modelBuilder.Entity<MLink>().HasData(new MLink { Name = "People", Title = "People", LinkURL = "/Home/" });


            modelBuilder.Entity<Language>().HasData(new Language { Id = 1, Name = "Svenska" });
            modelBuilder.Entity<Language>().HasData(new Language { Id = 2, Name = "Norska" });
            modelBuilder.Entity<Language>().HasData(new Language { Id = 3, Name = "Danska" });
            modelBuilder.Entity<Language>().HasData(new Language { Id = 4, Name = "Persiska" });
            modelBuilder.Entity<Language>().HasData(new Language { Id = 5, Name = "Arabiska" });

            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 1, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 2, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 3, LanguageId = 1 });

        }
    }
}




