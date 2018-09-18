using CollectorApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorApp.Core.Contracts
{
	public interface IBorrowingService
	{
		void BorrowSubject(string subjectId,DateTimeOffset returnDate,string name);
		void ReturnSubject(string borrowedSubjectId);
		List<BorrowedSubject> GetBorrowedSubjects();
	}
}
