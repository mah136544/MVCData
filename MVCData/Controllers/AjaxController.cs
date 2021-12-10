using Microsoft.AspNetCore.Mvc;
using MVCData.Models;
using MVCData.Data; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Controllers
{
    public class AjaxController : EFDBController
    {
       public AjaxController(DatabaseMVCEFDbContext context): base(context)
        {
        }
       
        public IActionResult Index()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel(this, EFDBContext);
            return View(peopleViewModel);
        }

        public IActionResult GetPeopleList()
    {
           PeopleViewModel peopleViewModel = new PeopleViewModel(this, EFDBContext);

           peopleViewModel.PrepareView();

           return PartialView("_PeopleListPartial", peopleViewModel);
    }

    [HttpPost]
    public IActionResult GetPersonByIndex(int personIndex)
    {
          PeopleViewModel peopleViewModel = new PeopleViewModel(this, EFDBContext);
            Person person = null;
            if (personIndex >= 0 && personIndex < peopleViewModel.People.Count)
            {
                PersonDB PersondB = peopleViewModel.People[personIndex];
                person = new Person(PersondB);
                person.ItemIndex = personIndex;
            }

            return PartialView("_PersonDetailsPartial", person);
            }

      [HttpPost]
        public IActionResult DeletePersonByIndex(int personIndex)
         {
            bool success;
            PeopleViewModel peopleViewModel = new PeopleViewModel(this, EFDBContext);

           success = peopleViewModel.DeletePerson(personIndex);

        return StatusCode(success ? 200 : 404);
    }
  }

}

   
