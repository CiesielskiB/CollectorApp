using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorApp.Core.Models
{
	public class Subject : BaseEntity
	{
		[Required]
		public string Title { get; set; }
		public string Description { get; set; }

		public string Category { get; set; }
		[Required]
		public string Genre { get; set; }
		[Required]
		public string Publisher { get; set; }
		public string Image { get; set; }
		public bool IsBorrowed { get; set; }

		public Subject()
		{
			IsBorrowed = false;
		}
	}
}
