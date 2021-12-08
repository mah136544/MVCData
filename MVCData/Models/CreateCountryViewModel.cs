using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    
    public class CreateCountryViewModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "Name:")]
        [MaxLength(40, ErrorMessage = "Country Name Is Big ")]
        [Required(ErrorMessage = "A name is required")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Country Code:")]
        [MaxLength(2, ErrorMessage = " Max 2 characters For Country Cod")]
        [Required(ErrorMessage = "A country code is required")]
        public string CountryCode { get; set; }

        public CreateCountryViewModel()
        {
            Name = string.Empty;
            CountryCode = string.Empty;
        }
    }
}