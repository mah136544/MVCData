using Microsoft.AspNetCore.Mvc;
using MVCData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel(this);
            return View(peopleViewModel);
    }

        public IActionResult GetPeopleList()
    {
           PeopleViewModel peopleViewModel = new PeopleViewModel(this);

           peopleViewModel.PrepareView();

           return PartialView("_PeopleListPartial", peopleViewModel);
    }

    [HttpPost]
    public IActionResult GetPersonById(int personID)
    {
          PeopleViewModel peopleViewModel = new PeopleViewModel(this);
          Person person = peopleViewModel.FindPersonByID(personID);

          return PartialView("_PersonDetailsPartial", person);
    }

    [HttpPost]
    public IActionResult DeletePersonById(int personID)
    {
        bool success;
        PeopleViewModel peopleViewModel = new PeopleViewModel(this);

        success = peopleViewModel.DeletePersonByID(personID);

        return StatusCode(success ? 200 : 404);
    }
  }

}

   
