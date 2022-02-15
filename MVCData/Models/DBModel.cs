using MVCData.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData.Controllers;

namespace MVCData.Models
{
    public class DBModel 
    {
        protected Controller aController;
        public readonly DatabaseMVCEFDbContext EFDBContext;

        public List<PersonDB> People;
        public List<DBCity> Cities;
        public List<MLink> MLinks;
        public List<DBLanguage> Languages;
        public List<PersonLanguage> personlanguages;
        public List<Country> Countries;
       
       
        public readonly List<string> TableRowClasses;

        public DBModel(Controller aController, DatabaseMVCEFDbContext dbContext)
        {
            this.aController = aController;
            EFDBContext = dbContext;

            TableRowClasses = new List<string>();
            TableRowClasses.Add("tableRowOdd");
            TableRowClasses.Add("tableRowEven");

            ReadDB();
            
        }




        public virtual void ReadDB()
        {
        People= EFDBContext.People.ToList();
        Languages = EFDBContext.Languages.ToList();
        personlanguages = EFDBContext.PersonLanguages.ToList();
        Cities = EFDBContext.Cities.ToList();
        Countries = EFDBContext.Countries.ToList();
            //MLinks = EFDBContext.MLinks.ToList(); 

            aController.ViewBag.Languages = Languages;   //  Make Language list för för AddPerson    
            aController.ViewBag.Mlinks = MLinks;         //Make MLinks for the Layout

            aController.ViewBag.Cities = Cities;              // Make City List för Partial View AddPerson
        
            aController.ViewBag.Countries = Countries;       // Make Country List för Partial View AddCity
        
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

