using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class Person
    {
        private int itemIndex;

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }

        public int ID { get; set; }
        public int ItemIndex { get => itemIndex; set { itemIndex = value; } }

        public string RowClass { get; set; }

        public string CookieString
        {
            get { return $"{Name},{PhoneNumber},{City}\r\n"; }
            set
            {
                string[] cookieParameters = value.Split(',');
                if (cookieParameters.Length > 0)
                {
                    Name = cookieParameters[0];
                }
                if (cookieParameters.Length > 1)
                {
                    PhoneNumber = cookieParameters[1];
                }
                if (cookieParameters.Length > 2)
                {
                    City = cookieParameters[2];
                }
            }
        }

        public Person()
        {
            Name = string.Empty;
            PhoneNumber = string.Empty;
            City = string.Empty;
        }

        public Person(Person source)
        {
            Name = source.Name;
            PhoneNumber = source.PhoneNumber;
            City = source.City;
            ID = source.ID;
            itemIndex = source.itemIndex;
        }

        public Person(CreatePersonViewModel personData)
        {
            Name = personData.Name;
            PhoneNumber = personData.PhoneNumber;
            City = personData.City;
        }

        public Person(string aName, string aCity, string aPhoneNumber)
        {
            Name = aName;
            City = aCity;
            PhoneNumber = aPhoneNumber;
        }
    }
}


    
    
  