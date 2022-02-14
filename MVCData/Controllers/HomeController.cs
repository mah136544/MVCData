using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCData.Models;
using MVCData.Data;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Controllers
{
    
       [Authorize]
        public class HomeController : EFDBController
        {
            public HomeController(DatabaseMVCEFDbContext context) : base(context)
            {
            }

            [AllowAnonymous]
            public IActionResult Index()
            {
                return View();
            }

            public IActionResult People(string searchFor)
            {
                PeopleViewModel peopleViewModel = new PeopleViewModel(this, EFDBContext);

                peopleViewModel.SearchFor = searchFor;
               
                peopleViewModel.PrepareView();

                return View(peopleViewModel);
            }

            public IActionResult EditPerson(int id)
            {
                PeopleViewModel peopleViewModel = new PeopleViewModel(this, EFDBContext);

                peopleViewModel.PrepareView();

                Person person = peopleViewModel.FindPersonByID(id);

                return View(person);
            }

            [HttpPost]
            public IActionResult AddPerson(AddPersonInputModel personData)
            {
                PersonDB person = null;

                if (ModelState.IsValid)
                {
                    person = new PersonDB(personData);

                    EFDBContext.People.Add(person);
                    EFDBContext.SaveChanges();

                    int[] languageIDList = personData.Languages;
                    if (languageIDList != null)
                    {
                        PersonLanguage pl;

                        foreach (var languageID in languageIDList)
                        {
                            pl = new PersonLanguage();
                            pl.PersonId = person.ID;
                            pl.LanguageId = languageID;
                            EFDBContext.PersonLanguages.Add(pl);
                        }
                        EFDBContext.SaveChanges();
                    }
                }

                return RedirectToAction("People");
            }

            [HttpPost]
            public IActionResult EditPerson(EditPersonInputModel personData)
            {
                if (ModelState.IsValid)
                {
                    EFDBContext.PersonLanguages.ToList();         // Read PersonLanguages table

                    int id = personData.Id;
                    var person = EFDBContext.People.Find(id);

                    if (person != null)
                    {
                        person.Name = personData.Name;
                        person.PhoneNumber = personData.PhoneNumber;
                        person.CityId = personData.CityId;

                        PersonLanguage pl;
                        int[] languageIDList = personData.Languages;

                        if (languageIDList != null)
                        {
                            if (person.Languages != null)
                            {
                                person.Languages.Clear();

                                foreach (var languageID in languageIDList)
                                {
                                    pl = new PersonLanguage();
                                    pl.PersonId = id;
                                    pl.LanguageId = languageID;
                                    person.Languages.Add(pl);
                                }
                            }
                            else
                            {       // Person doesn't have any languages..
                                foreach (var languageID in languageIDList)
                                {
                                    pl = new PersonLanguage();
                                    pl.PersonId = id;
                                    pl.LanguageId = languageID;
                                    EFDBContext.PersonLanguages.Add(pl);
                                }
                            }
                        }

                        EFDBContext.People.Update(person);
                        EFDBContext.SaveChanges();
                    }
                }

                return RedirectToAction("People");
            }

            public IActionResult DeletePerson(int id)
            {
                PersonDB dBPerson = EFDBContext.People.Find(id);
                if (dBPerson != null)
                {
                    EFDBContext.People.Remove(dBPerson);
                    EFDBContext.SaveChanges();
                }

                return RedirectToAction("People");
            }
        }
    }

