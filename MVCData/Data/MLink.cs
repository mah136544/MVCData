using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Data
{
    [Table("MLinks")]
    public class MLink
    {
		[Key]
		[MaxLength(20)]
		public string Name { get; set; }

		[Required]
		[MaxLength(20)]
		public string Title { get; set; }

		[Required]
		public string LinkURL { get; set; }
	}
}
