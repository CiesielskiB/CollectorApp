using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorApp.Core.Models
{
	public class BorrowedSubject : BaseEntity
	{
		public string SubjectId { get; set; }
		public DateTimeOffset ReturnDate { get; set; }
		public string Name { get; set; }
	}
}
