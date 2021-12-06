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


        public MVCEFDbContext(DbContextOptions<MVCEFDbContext>options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PersonDB>().HasData(new PersonDB { ID = 1, Name = "Mahnoush", City = "Göteborg", PhoneNumber = "0738090123" });
            modelBuilder.Entity<PersonDB>().HasData(new PersonDB { ID = 2, Name = "Donja", City = "Stockholm", PhoneNumber = "0748090124" });
            modelBuilder.Entity<PersonDB>().HasData(new PersonDB { ID = 3, Name = "Awa", City = "Ystad", PhoneNumber = "0758090125" });
            modelBuilder.Entity<PersonDB>().HasData(new PersonDB { ID = 4, Name = "Diana", City = "Malmö", PhoneNumber = "0768090126" });
            modelBuilder.Entity<PersonDB>().HasData(new PersonDB { ID = 5, Name = "Eva", City = "Karlstad", PhoneNumber = "0778090127" });
            modelBuilder.Entity<PersonDB>().HasData(new PersonDB { ID = 6, Name = "Adam", City = "Ystad", PhoneNumber = "0788090128" });


            modelBuilder.Entity<MLink>().HasData(new MLink { Name = "AJAX", Title = "AJAX", LinkURL = "/Ajax/Index" });
           
        }
    }
 }

