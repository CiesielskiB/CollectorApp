using CollectorApp.Core.Contracts;
using CollectorApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollectorApp.WebUI.Controllers
{
	public class BookManagerController : Controller
	{
		IRepository<Book> context;
		// GET: BookManager
		public BookManagerController(IRepository<Book> booksContext)
		{
			context = booksContext;
		}

		public ActionResult Index()
		{
			List<Book> books = context.Collection().ToList();
			return View(books);
		}

		public ActionResult Create()
		{
			Book newBook = new Book();
			return View(newBook);
		}

		[HttpPost]
		public ActionResult Create(Book book)
		{
			if (!ModelState.IsValid)
			{
				return View(book);
			}
			else
			{
				context.Insert(book);
				context.Commit();
				return RedirectToAction("Index");
			}
		}

		public ActionResult Delete(string Id)
		{
			Book bookToDelete = context.Find(Id);
			if (bookToDelete != null)
			{
				return View(bookToDelete);
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
			Book bookToDelete = context.Find(Id);
			if (bookToDelete != null)
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
			Book bookToEdit = context.Find(Id);
			if (bookToEdit != null)
			{
				return View(bookToEdit);
			}
			else
			{
				return HttpNotFound();
			}
		}
		[HttpPost]
		public ActionResult Edit(string Id, Book newBook)
		{
			Book bookToEdit = context.Find(Id);
			if (bookToEdit != null)
			{
				bookToEdit.Title = newBook.Title;
				bookToEdit.Description = newBook.Description;
				bookToEdit.Genre = newBook.Genre;
				bookToEdit.Publisher = newBook.Publisher;
				bookToEdit.NumberOfPages = newBook.NumberOfPages;
				bookToEdit.Author = newBook.Author;
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
			Book book = context.Find(Id);
			if (book != null) return View(book);
			else return HttpNotFound();
		}

	}
}