using MVCData.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class PeopleViewModel :DBModel 
    {
        private string searchFor;
        
        public readonly List<Person> PeopleToDisplay;

        public string SearchFor { get => searchFor; set { searchFor = value; } }

        public PeopleViewModel(Controller aController, MVCEFDbContext dbContext): base(aController,dbContext)
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
        public PersonDB AddPerson(CreatePersonViewModel personData)
        {
            PersonDB person = null;

            if (aController.ModelState.IsValid)
            {
                person = new PersonDB(personData);

                AddPersonToDB(person);
            }

            return person;
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

        public PersonDB FindPersonByID(int aPersonID)
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












         
        




