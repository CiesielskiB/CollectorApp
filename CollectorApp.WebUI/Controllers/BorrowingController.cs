using CollectorApp.Core.Contracts;
using CollectorApp.Core.Models;
using CollectorApp.Core.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CollectorApp.WebUI.Controllers
{
	public class BorrowingController : Controller
    {
		IRepository<BorrowedSubject> borrowedSubjectsContext;
		IRepository<Subject> SubjectContext;
		IBorrowingService BorrowingService;
		// GET: Borrowing
		public BorrowingController(IRepository<BorrowedSubject> borrowedSubjects, IBorrowingService borrowingService, IRepository<Subject> subjects)
		{
			borrowedSubjectsContext = borrowedSubjects;
			BorrowingService = borrowingService;
			SubjectContext = subjects;
		}
		public ActionResult Index()
        {
            return View(borrowedSubjectsContext.Collection().ToList());
        }

		public ActionResult Borrowing(string subjectId)
		{
			Subject subjectToBorrow = SubjectContext.Find(subjectId);
			if (subjectToBorrow == null) return HttpNotFound();
			else
			{
				return PartialView(subjectToBorrow);
			}
		}

		[HttpPost]
		public ActionResult Borrowing(string subjectId,DateTimeOffset returnDate,string name)
		{

				try
				{
					BorrowingService.BorrowSubject(subjectId,returnDate,name);
					return RedirectToAction("index", "Home", new { area = "" });
			}
				catch (Exception ex)
				{
					return View("Error", new HandleErrorInfo(ex, "Borrowing", "Borrowing"));
				}

			

		}

		public ActionResult Returning(string subjectId)
		{
			Subject subjectToReturn = SubjectContext.Find(subjectId);
			BorrowedSubject borrowed = borrowedSubjectsContext.Collection().FirstOrDefault(i => i.SubjectId == subjectId);
			ReturningViewModel viewModel = new ReturningViewModel
			{
				Subject = subjectToReturn,
				BorrowedSubject = borrowed
			};
			if (subjectToReturn == null) return HttpNotFound();
			else
			{
				return PartialView(viewModel);
			}
		}

		[HttpPost]
		[ActionName("Returning")]
		public ActionResult ConfirmReturn(string Id)
		{
			try
			{
				BorrowingService.ReturnSubject(Id);
				return RedirectToAction("index", "Home", new { area = "" });
			}
			catch (Exception ex)
			{
				return View("Error", new HandleErrorInfo(ex, "Borrowing", "Returning"));
			}

		}

		public PartialViewResult DetailsBorrow()
		{
			return PartialView();
		}
		public PartialViewResult DetailsReturn(string subjectId)
		{
			Subject subjectToReturn = SubjectContext.Find(subjectId);
			BorrowedSubject borrowed = borrowedSubjectsContext.Collection().FirstOrDefault(i => i.SubjectId == subjectId);
			ReturningViewModel viewModel = new ReturningViewModel
			{
				Subject = subjectToReturn,
				BorrowedSubject = borrowed
			};
				return PartialView(viewModel);
		}
	}
}