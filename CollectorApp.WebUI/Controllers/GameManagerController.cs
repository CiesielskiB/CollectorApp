using CollectorApp.Core.Contracts;
using CollectorApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollectorApp.WebUI.Controllers
{
    public class GameManagerController : Controller
    {
		IRepository<Game> context;
		public GameManagerController(IRepository<Game> gamesContext)
		{
			context = gamesContext;
		}

		public ActionResult Index()
		{
			List<Game> games = context.Collection().ToList();
			return View(games);
		}

		public ActionResult Create()
		{
			Game newGame = new Game();
			return View(newGame);
		}

		[HttpPost]
		public ActionResult Create(Game game)
		{
			if (!ModelState.IsValid)
			{
				return View(game);
			}
			else
			{
				context.Insert(game);
				context.Commit();
				return RedirectToAction("Index");
			}
		}

		public ActionResult Delete(string Id)
		{
			Game gameToDelete = context.Find(Id);
			if (gameToDelete != null)
			{
				return View(gameToDelete);
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
			Game gameToDelete = context.Find(Id);
			if (gameToDelete != null)
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
			Game gameToEdit = context.Find(Id);
			if (gameToEdit != null)
			{
				return View(gameToEdit);
			}
			else
			{
				return HttpNotFound();
			}
		}
		[HttpPost]
		public ActionResult Edit(string Id, Game newGame)
		{
			Game gameToEdit = context.Find(Id);
			if (gameToEdit != null)
			{
				gameToEdit.Title = newGame.Title;
				gameToEdit.Description = newGame.Description;
				gameToEdit.Genre = newGame.Genre;
				gameToEdit.Publisher = newGame.Publisher;
				gameToEdit.Discs = newGame.Discs;
				gameToEdit.Developer = newGame.Developer;
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
			Game game = context.Find(Id);
			if (game != null) return View(game);
			else return HttpNotFound();
		}
	}
}