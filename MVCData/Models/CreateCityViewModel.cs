using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class CreateCityViewModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "Name:")]
        [Required(ErrorMessage = "A name is required")]
        public string Name { get; set; }

        [Display(Name = "Country:")]
        public int CountryId { get; set; }

        public CreateCityViewModel()
        {
            Name = string.Empty;
            CountryId = 0;
        }
    }
}

