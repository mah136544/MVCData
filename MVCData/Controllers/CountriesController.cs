using MVCData.Data;
using MVCData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountriesController : EFDBController
    {
        public CountriesController(DatabaseMVCEFDbContext context) : base(context)
        {
        }

        public IActionResult Index()
        {
            CountriesViewModel countyViewModel = new CountriesViewModel(this, EFDBContext);

            return View(countyViewModel);
        }

        [HttpPost]
        public IActionResult AddCountry(AddCountryInputModel countryData)
        {
            CountriesViewModel countyViewModel = new CountriesViewModel(this, EFDBContext);

            countyViewModel.AddCountry(countryData);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteCountry(int id)
        {
            CountriesViewModel countyViewModel = new CountriesViewModel(this, EFDBContext);
            countyViewModel.RemoveCountryFromDB(id);

            return RedirectToAction("Index");
        }
    }
}

