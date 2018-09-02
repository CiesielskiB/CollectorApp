using CollectorApp.Core.Contracts;
using CollectorApp.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollectorApp.WebUI.Controllers
{
    public class CategoryManagerController : Controller
    {
		IRepository<Category> context;
		public CategoryManagerController(IRepository<Category> categoriesContext)
		{
			context = categoriesContext;
		}

		public ActionResult Index()
		{
			List<Category> categories = context.Collection().ToList();
			return View(categories);
		}

		public ActionResult Create()
		{
			Category newCategory = new Category();
			return View(newCategory);
		}

		[HttpPost]
		public ActionResult Create(Category category)
		{
			if (!ModelState.IsValid)
			{
				return View(category);
			}
			else
			{
				context.Insert(category);
				context.Commit();
				return RedirectToAction("Index");
			}
		}

		public ActionResult Delete(string Id)
		{
			Category categoryToDelete = context.Find(Id);
			if (categoryToDelete != null)
			{
				return View(categoryToDelete);
			}
			else
			{
				return HttpNotFound();
			}
		}
		[HttpPost]
		[ActionName("Delete")]
		public ActionResult ConfirmDelete(string Id)
		{
			Category categoryToDelete = context.Find(Id);
			if (categoryToDelete != null)
			{
				context.Delete(Id);
				context.Commit();
				return RedirectToAction("Index");
			}
			else
			{
				return HttpNotFound();
			}
		}

		public ActionResult Edit(string Id)
		{
			Category categoryToEdit = context.Find(Id);
			if (categoryToEdit != null)
			{
				return View(categoryToEdit);
			}
			else
			{
				return HttpNotFound();
			}
		}
		[HttpPost]
		public ActionResult Edit(string Id, Category newCategorye)
		{
			Category categoryToEdit = context.Find(Id);
			if (categoryToEdit != null)
			{
				categoryToEdit.CategoryName = newCategorye.CategoryName;
				context.Commit();
				return RedirectToAction("Index");
			}
			else
			{
				return HttpNotFound();
			}
		}

		public ActionResult Details(string Id)
		{
			Category category = context.Find(Id);
			if (category != null) return View(category);
			else return HttpNotFound();
		}
	}
}