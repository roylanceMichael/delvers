using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace delvers.ui.Controllers
{
	using delvers.Builders;
	using delvers.Characters;
	using delvers.Game;
	using delvers.ui.Models;

	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		[HttpPut]
		public JsonResult Play(List<Dictionary<string, string>> players)
		{
			// simulate the game being played currently
			var characterBuilder = new CharacterBuilder();

			var gamePlayers = players.Select(player => characterBuilder.BuildCharacter(player["PClass"], player["Name"])).ToList();
			for (var i = 0; i < players.Count; i++)
			{
				var monster = characterBuilder.BuildCharacter("monster", "monster_" + (i + 1));
				gamePlayers.Add(monster);
			}

			var boardGame = new BoardGame(gamePlayers, false);
			var gameResults = boardGame.StartGame();

			return Json(new { results = gameResults}, JsonRequestBehavior.AllowGet);
		}
	}
}
