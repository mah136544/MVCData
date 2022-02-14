using MVCData.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Data
{
    [Table("Cities")]
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<PersonDB> People { get; set; }

        public Country Country { get; set; }
        public int CountryId { get; set; }

        public string PeopleString
        {
            get
            {
                List<PersonDB> peopleList = People;
                string peopleString;

                if (peopleList != null)
                {
                    peopleString = String.Format("{0}: ", peopleList.Count);

                    int i = 0;
                    foreach (var item in peopleList)
                    {
                        if (i > 0)
                        {
                            peopleString += ",";
                        }
                        peopleString += item.Name;
                        i++;
                    }
                }
                else
                {
                    peopleString = "0";
                }
                return peopleString;
            }
        }


        public City()
        {

        }

        public City(AddCityInputModel cityData)
        {
            Name = cityData.Name;
            CountryId = cityData.CountryId;
        }
    }
}

