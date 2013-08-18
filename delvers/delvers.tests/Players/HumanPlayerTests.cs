using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace delvers.tests.Players
{
	using System.Collections.Generic;
	using System.Linq;

	using delvers.Characters;
	using delvers.Game;

	[TestClass]
	public class HumanPlayerTests
	{
		private static BoardGame SetupBoardGame(Player playerToTest, int monsterNum = 1)
		{
			var players = new List<Player> { playerToTest };
			
			for (var i = 0; i < monsterNum; i++)
			{
				var monster = new Monster("Monster" + i);
				players.Add(monster);
			}
			
			var boardGame = new BoardGame(players);

			return boardGame;
		}

		[TestMethod]
		public void AttackCorrectly()
		{
			// arrange
			var humanPlayer = new Cleric("Somebody");

			// act

			// assert
			Assert.IsTrue(humanPlayer.CanTakeTurn);
		}

		[TestMethod]
		public void AttackCorrectly1()
		{
			// arrange
			var humanPlayer = new Cleric("Somebody");
			var boardGame = SetupBoardGame(humanPlayer);
			var monster = boardGame.GetMonsters().First();
			var monsterHp = monster.Hp;

			// act
			
			humanPlayer.TakeTurn(boardGame);

			// assert
			Assert.IsTrue(monsterHp > monster.Hp);
		}
	}
}
