using MVCData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Data
{
    [Table("People")]
    public class PersonDB
    {
      [Key]
      public int ID { get; set; }
    
      [Required]
      public string Name { get; set; }
      public string PhoneNumber { get; set; }
      public string City { get; set; }
      
      public PersonDB()
        {

        }
      
       public PersonDB (CreatePersonViewModel personInfo)
      {
            Name = personInfo.Name;
            PhoneNumber = personInfo.PhoneNumber;
            City = personInfo.City;
      }
      public PersonDB(Person source)
      {
                Name = source.Name;
                PhoneNumber = source.PhoneNumber;
                City = source.City;
                ID = source.ID;
      }
   
  }
}