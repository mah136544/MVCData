using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCData.Models;
using MVCData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Controllers
{
    public class HomeController : EFDBController
    {
        public HomeController(DatabaseMVCEFDbContext context) : base(context)
        {
        }

        public IActionResult Index(string searchFor)
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel(this, EFDBContext);

            peopleViewModel.SearchFor = searchFor;
            
            peopleViewModel.PrepareView();

            return View(peopleViewModel);
        }

        public IActionResult PersonDetails(int id)
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel(this, EFDBContext);

            peopleViewModel.PrepareView();

            Person person = peopleViewModel.FindPersonByID(id);

            return View(person);
        }



        [HttpPost]
        public IActionResult AddPerson(CreatePersonViewModel personData)
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel(this, EFDBContext );

            peopleViewModel.AddPerson(personData);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult UpdatePerson(UpdatePersonViewModel personData)
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel(this, EFDBContext);

            peopleViewModel.UpdatePerson(personData);

            return RedirectToAction("Index");
        }


        public IActionResult DeletePerson(int id)
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel(this, EFDBContext);
            peopleViewModel.DeletePerson(id);

            return RedirectToAction("Index");
        }
    }
}



    