using CollectorApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorApp.Core.ViewModels
{
	public class ReturningViewModel
	{
		public Subject Subject { get; set; }
		public BorrowedSubject BorrowedSubject { get; set; }
	}

}
