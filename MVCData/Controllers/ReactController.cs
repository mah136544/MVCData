using MVCData.Data;
using MVCData.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MVCData.Controllers
{
    [Authorize]
    public class ReactController : EFDBController
    {
        public ReactController(DatabaseMVCEFDbContext context) : base(context)
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult GetPeopleList()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel(this, EFDBContext);

            peopleViewModel.PrepareView();

            return Json(peopleViewModel.PeopleToDisplay);
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult GetCityList()
        {
            var dbCities = EFDBContext.Cities.ToList();
            var cities = new List<NameCl>();

            // Create a simpler list that only contains properties Id & Name:
            foreach (var dbCity in dbCities)
            {
                var city = new NameCl(dbCity);
                cities.Add(city);
            }

            return Json(cities);
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult GetLanguageList()
        {
            var dbLanguages = EFDBContext.Languages.ToList();
            var languages = new List<NameCl>();

            // Create a simpler list that only contains properties Id & Name:
            foreach (var dbLanguage in dbLanguages)
            {
                var language = new NameCl(dbLanguage);
                languages.Add(language);
            }

            return Json(languages);
        }

        public IActionResult DeletePerson(int id)
        {
            bool success;
            PeopleViewModel peopleViewModel = new PeopleViewModel(this, EFDBContext);

            success = peopleViewModel.DeletePersonByID(id);

            return StatusCode(success ? 200 : 404);
        }

        [HttpPost]
        public IActionResult AddPerson(ReactAddPersonInputModel personData)
        {
            bool success = false;
            PersonDB person = null;

            if (ModelState.IsValid)
            {
                person = new PersonDB(personData);

                EFDBContext.People.Add(person);
                EFDBContext.SaveChanges();

                if (personData.Languages != null)
                {
                    string[] languageIDList = personData.Languages.Split(',');
                    PersonLanguage pl;

                    foreach (var languageIDString in languageIDList)
                    {
                        int languageID;
                        if (int.TryParse(languageIDString, out languageID))
                        {
                            pl = new PersonLanguage();
                            pl.PersonId = person.ID;
                            pl.LanguageId = languageID;
                            EFDBContext.PersonLanguages.Add(pl);
                        }
                    }
                    EFDBContext.SaveChanges();
                }
                success = true;
            }

            return StatusCode(success ? 200 : 404);
        }
    }
}


