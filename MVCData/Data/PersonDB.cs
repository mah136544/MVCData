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
     
        public City City { get; set; }
        public int CityId { get; set; }
        
        public List<PersonLanguage> Languages { get; set; }

        public string LanguagesString
        {
            get
            {
                List<PersonLanguage> languageList = Languages;
                string languageString;

                if (languageList != null)
                {
                    languageString = String.Format("{0}: ", languageList.Count);

                    int i = 0;
                    foreach (var item in languageList)
                    {
                        if (i > 0)
                        {
                            languageString += ",";
                        }
                        languageString += item.Language.Name;
                        i++;
                    }
                }
                else
                {
                    languageString = "0";
                }
                return languageString;
            }
        }

        public PersonDB()
        {

        }

        public PersonDB(CreatePersonViewModel personData)
        {
            Name = personData.Name;
            PhoneNumber = personData.PhoneNumber;
            CityId = personData.CityId;
        }

        public PersonDB(Person source)
        {
            Name = source.Name;
            PhoneNumber = source.PhoneNumber;
            ID = source.ID;
        }
    }

}








