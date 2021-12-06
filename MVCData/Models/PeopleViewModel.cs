using MVCData.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class PeopleViewModel
    {
        private Controller aController;
        private readonly MVCEFDbContext EFDBContext;
        private string searchFor;

        public  List<PersonDB> People;
        public List<MLink> MLinks;
        
        public readonly List<Person> PeopleToDisplay;
        public readonly List<string> TableRowClasses;

        
            
        

        public string SearchFor { get => searchFor; set { searchFor = value; } }

        

        public PeopleViewModel(Controller aController, MVCEFDbContext efdbContext)
        {
            this.aController = aController;
            EFDBContext = efdbContext;
            PeopleToDisplay = new List<Person>();

            TableRowClasses = new List<string>();
            TableRowClasses.Add("tableRowOdd");
            TableRowClasses.Add("tableRowEven");
            ReadDB();
            
        }
        public void ReadDB()
        {
            People = EFDBContext.People.ToList();
            MLinks = EFDBContext.MLinks.ToList();
        }
        
        
        
        public void PrepareView()
        {
            int peopleToDisplayIndex = 0;
            bool addPerson = false;

            

            PeopleToDisplay.Clear();

            foreach (var person in People)
            {
                if (searchFor != null && searchFor.Length > 0)
                {
                    if (person.Name.Contains(searchFor) || person.City.Contains(searchFor))
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
                    personInPeopleToDisplayList.ItemIndex = peopleToDisplayIndex;   // Assign a new ItemIndex (which is its index in the PeopleToDisplay list)

                    PeopleToDisplay.Add(personInPeopleToDisplayList);
                    peopleToDisplayIndex++;
                }
            }
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

       public bool DeletPersonByID(int aPersonID)
        {

            return RemovePersonFromDB(aPersonID);
        }

         
        public PersonDB AddPerson(CreatePersonViewModel personData)
        {
            PersonDB  person = null;

            if (aController.ModelState.IsValid)
            {
                person = new PersonDB(personData);

                AddPersonToDB(person);
            }

            return person;
        }


        public bool RemovePersonFromDB(int ID)
        {
            bool success = false;

            PersonDB PersondB = EFDBContext.People.Find(ID);
            if (PersondB != null)
            {
                People.Remove(PersondB);
                EFDBContext.People.Remove(PersondB);
                EFDBContext.SaveChanges();
                success = true;
            }
            return success;
        }


        public int AddPersonToDB(PersonDB aPerson)
        {
            aPerson.ID = 0;                 // Set ID to 0 to allow addition to database

            EFDBContext.People.Add(aPerson);
            EFDBContext.SaveChanges();
            return EFDBContext.People.Count();
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












