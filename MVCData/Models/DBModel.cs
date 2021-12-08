using MVCData.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class DBModel 
    {
        protected Controller aController;
        protected readonly MVCEFDbContext EFDBContext;

        public List<PersonDB> People;
        public List<MLink> MLinks;
        public List<City> Cities;
        public List<Country> Countries;
       
        public readonly List<string> TableRowClasses;


        public DBModel(Controller aController, MVCEFDbContext dbContext)
        {
            this.aController = aController;
            EFDBContext = dbContext;

            TableRowClasses = new List<string>();
            TableRowClasses.Add("tableRowOdd");
            TableRowClasses.Add("tableRowEven");

            ReadDB();
        }
        public void ReadDB()
        {
        People= EFDBContext.People.ToList();
        MLinks = EFDBContext.MLinks.ToList();
            //dynamic MLinks = null;
        Cities = EFDBContext.Cities.ToList();
        Countries = EFDBContext.Countries.ToList();
       
        aController.ViewBag.Cities = Cities;         // Make City List för Partial View AddPerson
        aController.ViewBag.Countries = Countries;   // Make City List för Partial View AddCity
        aController.ViewBag.MLinks = MLinks; 
        }

        public bool RemovePersonFromDB(int ID)
        {
            bool success = false;

            PersonDB dBPerson = EFDBContext.People.Find(ID);
            if (dBPerson != null)
            {
                People.Remove(dBPerson);
                EFDBContext.People.Remove(dBPerson);
                EFDBContext.SaveChanges();
                success = true;
            }
            return success;
        }

        public int AddPersonToDB(PersonDB aPerson)
        {
            aPerson.ID = 0;                                 // Set ID to 0 to allow addition to database

            EFDBContext.People.Add(aPerson);
            EFDBContext.SaveChanges();
            return EFDBContext.People.Count();
        }

        public virtual void PrepareView()
        {

        }





    }


}

