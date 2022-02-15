using MVCData.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData.Controllers;

namespace MVCData.Models
{
    public class CountriesViewModel : DBModel
    {
        public CountriesViewModel(Controller aController, DatabaseMVCEFDbContext dbContext) : base(aController, dbContext)
        {

        }

        

        public Country AddCountry(AddCountryInputModel countryData)
        {
            Country country = null;

            if (aController.ModelState.IsValid)
            {
                country = new Country(countryData);

                AddCountryToDB(country);
            }

            return country;
        }

        public int AddCountryToDB(Country aCountry)
        {
            aCountry.Id = 0;                                 // Set ID to 0 to allow addition to database

            EFDBContext.Countries.Add(aCountry);
            EFDBContext.SaveChanges();
            return EFDBContext.Countries.Count();
        }

        public bool RemoveCountryFromDB(int ID)
        {
            bool success = false;

            Country country = EFDBContext.Countries.Find(ID);
            if (country != null)
            {
                Countries.Remove(country);
                EFDBContext.Countries.Remove(country);
                EFDBContext.SaveChanges();
                success = true;
            }
            return success;
        }
    }
}

