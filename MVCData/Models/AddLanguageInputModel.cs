using System.ComponentModel.DataAnnotations; 
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class AddLanguageInputModel
        {
            [DataType(DataType.Text)]
            [Display(Name = "Name:")]
            [Required(ErrorMessage = "A name is required")]
            public string Name { get; set; }

            public AddLanguageInputModel()
            {
                Name = string.Empty;
            }
        }
    }


