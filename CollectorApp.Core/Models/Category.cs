using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorApp.Core.Models
{
	public class Category : BaseEntity
	{
		[DisplayName("Category")]
		public string CategoryName { get; set; }
	}
}
