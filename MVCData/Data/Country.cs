using MVCData.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Data
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "Country Name Is Big ")]
        public string Name { get; set; }

        [Required]
        [MaxLength(2, ErrorMessage = " Max 2 characters For Country Cod")]
        public string CountryCode { get; set; }

        public List<City> Cities { get; set; }

        public Country()
        {

        }

        public Country(CreateCountryViewModel countryData)
        {
            Name = countryData.Name;
            CountryCode = countryData.CountryCode.ToUpper();
        }
    }
}

