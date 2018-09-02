using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorApp.Core.Models
{
	public class Subject : BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string Category { get; set; }
		public string Genre { get; set; }
		public string Publisher { get; set; }
		public string Image { get; set; }
	}
}
