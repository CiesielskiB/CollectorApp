using CollectorApp.Core.Contracts;
using CollectorApp.Core.Models;
using CollectorApp.Core.ViewModels;
using CollectorApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CollectorApp.WebUI.Controllers
{
	public class HomeController : Controller
	{
		IRepository<Subject> subjectContext;
		IRepository<Category> categoryContext;
		public HomeController(IRepository<Subject> subjects, IRepository<Category> categories)
		{
			subjectContext = subjects;
			categoryContext = categories;
		}

		public ActionResult Index(SubjectSearchModel filterData)
		{
			SubjectSearchService searchService = new SubjectSearchService(subjectContext);


			TempData["FilterData"] = searchService.RouteValuesSearches(filterData);
			SubjectListViewModel viewModel = new SubjectListViewModel();
			viewModel.FilterData = filterData;
			viewModel.Subjects = searchService.SubjetFiltering(filterData);
			viewModel.Categories = categoryContext.Collection().ToList();
			return View(viewModel);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult Details(string Id)
		{
			Subject subject = subjectContext.Find(Id);
			if (subject != null) return View(subject);
			else return HttpNotFound();
		}
	}
}