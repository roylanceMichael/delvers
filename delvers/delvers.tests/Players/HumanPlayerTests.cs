using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace delvers.tests.Players
{
	using System.Collections.Generic;
	using System.Linq;

	using delvers.Builders;
	using delvers.Characters;
	using delvers.Game;

	[TestClass]
	public class HumanPlayerTests
	{
		private static BoardGame SetupBoardGame(Player playerToTest, int monsterNum = 1)
		{
			var players = new List<Player> { playerToTest };
			var builder = new CharacterBuilder();

			for (var i = 0; i < monsterNum; i++)
			{
				var monster = builder.BuildCharacter("monster", "Monster" + i);
				players.Add(monster);
			}
			
			var boardGame = new BoardGame(players);

			return boardGame;
		}

		[TestMethod]
		public void AttackCorrectly()
		{
			// arrange
			var builder = new CharacterBuilder();
			var humanPlayer = builder.BuildCharacter("cleric", "Someone");

			// act

			// assert
			Assert.IsTrue(humanPlayer.CanTakeTurn);
		}

		[TestMethod]
		public void AttackCorrectly1()
		{
			// arrange
			var builder = new CharacterBuilder();
			var humanPlayer = builder.BuildCharacter("cleric", "SomePlayer1");
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
