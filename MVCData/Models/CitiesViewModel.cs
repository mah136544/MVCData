using MVCData.Data;
using Microsoft.AspNetCore.Mvc; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    
        public class CitiesViewModel: DBModel
        {
        public CitiesViewModel(Controller aController, MVCEFDbContext dbContext) : base(aController, dbContext)
        {

        }

        public City AddCity(CreateCityViewModel cityData)
        {
            City city = null;

            if (aController.ModelState.IsValid)
            {
                city = new City(cityData);

                AddCityToDB(city);
            }

            return city;
        }
        public int AddCityToDB(City aCity)
        {
            aCity.Id = 0;                                 // Set ID to 0 to allow addition to database

            EFDBContext.Cities.Add(aCity);
            EFDBContext.SaveChanges();
            return EFDBContext.Cities.Count();
        }

        public bool RemoveCityFromDB(int ID)
        {
            bool success = false;

            City city = EFDBContext.Cities.Find(ID);
            if (city != null)
            {
                Cities.Remove(city);
                EFDBContext.Cities.Remove(city);
                EFDBContext.SaveChanges();
                success = true;
            }
            return success;
        }

    }

   
}

    
    
    
    
    
