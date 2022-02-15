using MVCData.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Data
{
    public class DatabaseMVCEFDbContext: IdentityDbContext<ApplicationUser>
    {
    
        public DbSet<PersonDB>People { get; set; }
        //public DbSet<MLink>MLinks { get; set; }
        public DbSet<DBCity> Cities { get; set; }
        public DbSet<Country>Countries { get; set; }
        public DbSet<PersonLanguage>PersonLanguages { get; set; }
        public DbSet<DBLanguage>Languages { get; set; }
        
        public DbSet<ApplicationUser>Users { get; set; }

        public DatabaseMVCEFDbContext(DbContextOptions<DatabaseMVCEFDbContext>options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          // Build Person language association table 
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

          modelBuilder.Entity<DBCity>()
         .HasOne(city => city.Country)
         .WithMany(country => country.Cities)
         .HasForeignKey(city => city.CountryId);

            //Add country
            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "IRAN",CountryCode= "IR"});
            modelBuilder.Entity<Country>().HasData(new Country { Id = 2, Name = "Norge", CountryCode = "NO" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 3, Name = "USA", CountryCode = "US" });

            //Add City
            modelBuilder.Entity<DBCity>().HasData(new DBCity { Id = 1, Name = "Tehran", CountryId = 1 });
            modelBuilder.Entity<DBCity>().HasData(new DBCity { Id = 2, Name = "Shiraz", CountryId = 1 });
            modelBuilder.Entity<DBCity>().HasData(new DBCity { Id = 3, Name = "Mashhad", CountryId = 1 });

            //Add people
            modelBuilder.Entity<PersonDB>().HasData(new PersonDB { ID = 1, Name = "Mahnoush", CityId = 1, PhoneNumber = "0738090123" });
            modelBuilder.Entity<PersonDB>().HasData(new PersonDB { ID = 2, Name = "Donja", CityId = 2, PhoneNumber = "0748090124" });
            modelBuilder.Entity<PersonDB>().HasData(new PersonDB { ID = 3, Name = "Awa", CityId = 3, PhoneNumber = "0758090125" });
            
           //Add Language

            modelBuilder.Entity<DBLanguage>().HasData(new DBLanguage { Id = 1, Name = "Svenska" });
            modelBuilder.Entity<DBLanguage>().HasData(new DBLanguage { Id = 2, Name = "Norska" });
            modelBuilder.Entity<DBLanguage>().HasData(new DBLanguage { Id = 3, Name = "Danska" });
            modelBuilder.Entity<DBLanguage>().HasData(new DBLanguage { Id = 4, Name = "Persiska" });
            modelBuilder.Entity<DBLanguage>().HasData(new DBLanguage { Id = 5, Name = "Arabiska" });

            // Add peolpe with language
            
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 1, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 2, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 3, LanguageId = 1 });

            string adminRoleId = Guid.NewGuid().ToString();
            string adminUserId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();

            // Add user roles:
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = userRoleId, Name = "User", NormalizedName = "USER" });

            var hasher = new PasswordHasher<ApplicationUser>();

            // Add an admin user:
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = adminUserId,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = hasher.HashPassword(null, "@Maham1d"),
                FirstName = "Admin",
                LastName = "Admin",
                BirthDate = "1998-11-18"
            });

            // Set user admin role to admin
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminUserId
            });

        }
    }
}







