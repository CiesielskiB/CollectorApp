using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorApp.Core.Models
{
	public class Book : Subject
	{
		public string Author { get; set; }
		public int NumberOfPages { get; set; }
	}
}
