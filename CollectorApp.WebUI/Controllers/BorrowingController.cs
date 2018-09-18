using CollectorApp.Core.Contracts;
using CollectorApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
		public ActionResult Borrowing(string Id, DateTimeOffset returnDate,string name)
		{
			try
			{
				BorrowingService.BorrowSubject(Id, returnDate, name);
				return RedirectToAction("index", "Home", new { area = "" });
			}
			catch (Exception ex)
			{
				return View("Error", new HandleErrorInfo(ex, "Borrowing", "Borrowing"));
			}

		}
    }
}