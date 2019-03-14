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
		private IRepository<Subject> subjectContext;
		private IRepository<BorrowedSubject> borrowedContext;

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
				Subject subjectToBorrow = subjectContext.Find(subjectId);
				borrow = new BorrowedSubject()
				{
					SubjectId = subjectId,
					Name = name,
					ReturnDate = returnDate
				};
				borrowedContext.Insert(borrow);
				borrowedContext.Commit();
				subjectToBorrow.IsBorrowed = true;
				subjectContext.Commit();
			}
		}

		public List<BorrowedSubject> GetBorrowedSubjects()
		{
			return borrowedContext.Collection().ToList();
		}

		public void ReturnSubject(string borrowedSubjectId)
		{
			BorrowedSubject borrowedSubjectToReturn = borrowedContext.Find(borrowedSubjectId);
			if (borrowedSubjectToReturn == null) throw new Exception("Item not borrowed");
			else
			{
				Subject subjectToBorrow = subjectContext.Find(borrowedSubjectToReturn.SubjectId);
				subjectToBorrow.IsBorrowed = false;
				subjectContext.Commit();
				borrowedContext.Delete(borrowedSubjectToReturn.Id);
				borrowedContext.Commit();
			}
		}
	}
}
