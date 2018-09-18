using CollectorApp.Core.Contracts;
using CollectorApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorApp.Services
{
	public class BorrowingService : IBorrowingService
	{
		IRepository<Subject> subjectContext;
		IRepository<BorrowedSubject> borrowedContext;

		public BorrowingService(IRepository<Subject> subjects, IRepository<BorrowedSubject> borrowedSubjects)
		{
			this.subjectContext = subjects;
			this.borrowedContext = borrowedSubjects;
		}

		public void BorrowSubject(string subjectId, DateTimeOffset returnDate, string name)
		{
			BorrowedSubject borrow = borrowedContext.Collection().FirstOrDefault(i => i.SubjectId == subjectId);
			if (borrow != null) throw new Exception("Item already borrowed");
			else
			{
				borrow = new BorrowedSubject()
				{
					SubjectId = subjectId,
					Name = name,
					ReturnDate = returnDate
				};
				borrowedContext.Insert(borrow);
				borrowedContext.Commit();
			}
		}

		public List<BorrowedSubject> GetBorrowedSubjects()
		{
			return borrowedContext.Collection().ToList();
		}

		public void ReturnSubject(string borrowedSubjectId)
		{
			BorrowedSubject subjectToReturn = borrowedContext.Find(borrowedSubjectId);
			if(subjectToReturn == null) throw new Exception("Item not borrowed");
			else
			{
				borrowedContext.Delete(borrowedSubjectId);
				borrowedContext.Commit();
			}
		}
	}
}
