using CollectorApp.Core.Contracts;
using CollectorApp.Core.Models;
using CollectorApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollectorApp.WebUI.Controllers
{
	public class SubjectManagerController : Controller
	{
		IRepository<Subject> subjectContext;
		IRepository<Category> categoryContext;
		// GET: BookManager
		public SubjectManagerController(IRepository<Subject> subjects, IRepository<Category> categories)
		{
			subjectContext = subjects;
			categoryContext = categories;
		}

		public ActionResult Index()
		{
			List<Subject> subjects = subjectContext.Collection().ToList();
			return View(subjects);
		}

		public ActionResult Create()
		{
			SubjectManagerViewModel viewModel = new SubjectManagerViewModel();
			viewModel.Subject = new Subject();
			viewModel.SubjectCategories = categoryContext.Collection();
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Create(Subject subject, HttpPostedFileBase image)
		{
			if (!ModelState.IsValid)
			{
				return View(subject);
			}
			else
			{
				if(image != null)
				{
					subject.Image = subject.Id + Path.GetExtension(image.FileName);
					image.SaveAs(Server.MapPath("//Content//SubjectImages//") + subject.Image);
				}
				subjectContext.Insert(subject);
				subjectContext.Commit();
				return RedirectToAction("index");
			}
		}

		public ActionResult Delete(string Id)
		{
			Subject subjectToDelete = subjectContext.Find(Id);
			if (subjectToDelete != null)
			{
				return View(subjectToDelete);
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
			Subject subjectToDelete = subjectContext.Find(Id);
			if (subjectToDelete != null)
			{
				var imageToDelete = Server.MapPath("//Content//SubjectImages//") + subjectToDelete.Image;
				if (System.IO.File.Exists(imageToDelete))
				{
					System.IO.File.Delete(imageToDelete);
				}
				subjectContext.Delete(Id);
				subjectContext.Commit();
				return RedirectToAction("Index");
			}
			else
			{
				return HttpNotFound();
			}
		}

		public ActionResult Edit(string Id)
		{
			Subject subjectToEdit = subjectContext.Find(Id);
			if (subjectToEdit != null)
			{
				SubjectManagerViewModel viewModel = new SubjectManagerViewModel();
				viewModel.Subject = subjectToEdit;
				viewModel.SubjectCategories = categoryContext.Collection();
				return View(viewModel);
			}
			else
			{
				return HttpNotFound();
			}
		}
		[HttpPost]
		public ActionResult Edit(Subject subject, string Id, HttpPostedFileBase image)
		{
			Subject subjectToEdit = subjectContext.Find(Id);
			if (subjectToEdit != null)
			{
				if (!ModelState.IsValid) return View(subject);
				if(image != null)
				{
					var imageToDelete = Server.MapPath("//Content//SubjectImages//") + subjectToEdit.Image;
					if (System.IO.File.Exists(imageToDelete))
					{
						System.IO.File.Delete(imageToDelete);
					}
					subjectToEdit.Image = subject.Id + Path.GetExtension(image.FileName);
					image.SaveAs(Server.MapPath("//Content//SubjectImages//") + subjectToEdit.Image);
				}

				subjectToEdit.Title = subject.Title;
				subjectToEdit.Description = subject.Description;
				subjectToEdit.Category = subject.Category;
				subjectToEdit.Genre = subject.Genre;
				subjectToEdit.Publisher = subject.Publisher;
				subjectContext.Commit();
				return RedirectToAction("Index");
			}
			else
			{
				return HttpNotFound();
			}
		}


	}
}