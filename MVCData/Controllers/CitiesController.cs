using MVCData.Data;
using MVCData.Models; 
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Controllers
{
    public class CitiesController : EFDBController
    {
        public CitiesController(DatabaseMVCEFDbContext context) : base(context)
        {

        }

        public IActionResult Index()
        {
            CitiesViewModel citiesViewModel = new CitiesViewModel(this, EFDBContext);


            return View(citiesViewModel);
        }

        [HttpPost]
        public IActionResult AddCity(CreateCityViewModel cityData)
        {
            CitiesViewModel citiesViewModel = new CitiesViewModel(this, EFDBContext);

            citiesViewModel.AddCity(cityData);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteCity(int id)
        {
            CitiesViewModel citiesViewModel = new CitiesViewModel(this, EFDBContext);
            citiesViewModel.RemoveCityFromDB(id);

            return RedirectToAction("Index");
        }

    }
}




