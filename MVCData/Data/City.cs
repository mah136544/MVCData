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

        public City()
        {

        }

        public City(CreateCityViewModel cityData)
        {
            Name = cityData.Name;
            CountryId = cityData.CountryId;
        }
    }
}

