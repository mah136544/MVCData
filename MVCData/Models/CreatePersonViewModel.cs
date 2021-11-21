using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class CreatePersonViewModel
    {  
            [DataType(DataType.Text)]
            [Display(Name = "Name:")]
            [Required(ErrorMessage = "A name is required")]
            public string Name { get; set; }

            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Phone Number:")]
            public string PhoneNumber { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "City:")]
            public string City { get; set; }

            public CreatePersonViewModel()
            {
                Name = string.Empty;
                PhoneNumber = string.Empty;
                City = string.Empty;
            }
        }
    }


