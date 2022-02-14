using MVCData.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData.Controllers;

namespace MVCData.Models
{
    public class PeopleViewModel :DBModel 
    {
        private string searchFor;
        
        public readonly List<Person> PeopleToDisplay;

        public string SearchFor { get => searchFor; set { searchFor = value; } }


        public PeopleViewModel(Controller aController, DatabaseMVCEFDbContext dbContext): base(aController,dbContext)
        {
            
            PeopleToDisplay = new List<Person>();
        }
        
        public override void PrepareView()
        {
            int peopleToDisplayIndex = 0;
            bool addPerson = false;

            PeopleToDisplay.Clear();

            foreach (var person in People)
            {
                if (searchFor != null && searchFor.Length > 0)
                {
                    if (person.Name.Contains(searchFor) || person.City.Name.Contains(searchFor))
                    {
                        addPerson = true;
                    }
                    else
                        addPerson = false;
                }
                else        // No filtering..
                    addPerson = true;

                if (addPerson)
                {
                    Person personInPeopleToDisplayList = new Person(person);    // Create a copy of person
                    personInPeopleToDisplayList.ItemIndex = peopleToDisplayIndex;   // Assign an ItemIndex (which is its index in the PeopleToDisplay list)

                    PeopleToDisplay.Add(personInPeopleToDisplayList);
                    peopleToDisplayIndex++;
                }
            }
        }

        public PersonDB AddPerson(AddPersonInputModel personData)
        {
            PersonDB person = null;

            if (aController.ModelState.IsValid)
            {
                person = new PersonDB(personData);

                AddPersonToDB(person);

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

            return person;
        }

        public bool EditPerson(EditPersonInputModel personData)
        {
            bool success = false;

            if (aController.ModelState.IsValid)
            {
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

            return success;
        }

        public bool DeletePerson(int itemIndex)
        {
            bool success = false;
            if (itemIndex >= 0 && itemIndex < People.Count)
            {
                success = RemovePersonFromDB(People[itemIndex].ID);
            }
            return success;
        }

        public bool DeletePersonByID(int aPersonID)
        {
            return RemovePersonFromDB(aPersonID);
        }

        public Person FindPersonByID(int aPersonID)
        {
            Person person = null;

            foreach (var item in PeopleToDisplay)
            {
                if (item.ID == aPersonID)
                {
                    person = item;
                    break;
                }
            }
            return person;
        }
        public PersonDB FindDBPersonByID(int aPersonID)
        {
            PersonDB person = null;

            foreach (var item in People)
            {
                if (item.ID == aPersonID)
                {
                    person = item;
                    break;
                }
            }
            return person;
        }

    }

    }


