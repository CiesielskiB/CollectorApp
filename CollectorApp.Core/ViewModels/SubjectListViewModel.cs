using CollectorApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorApp.Core.ViewModels
{
	public class SubjectListViewModel
	{
		public IEnumerable<Subject> Subjects { get; set; }
		public IEnumerable<Category> Categories { get; set; }
		public SubjectSearchModel FilterData { get; set; }
	}
}
