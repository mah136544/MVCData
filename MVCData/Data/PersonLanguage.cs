using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Data
{
    [Table("PersonLanguages")]
    public class PersonLanguage
    {
        public int PersonId { get; set; }
        public PersonDB Person { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
