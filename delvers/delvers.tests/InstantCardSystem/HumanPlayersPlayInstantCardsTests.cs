using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.tests.InstantCardSystem
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using delvers.Builders;
	using delvers.Characters;
	using delvers.Game;

	[TestClass]
	public class HumanPlayersPlayInstantCardsTests
	{
		[TestMethod]
		public void HumanPlayerPlaysInstantCardWhenHeIsAttackedByAMonster()
		{
			// arrange
			var builder = new CharacterBuilder();
			var warrior = builder.BuildCharacter("warrior", "TestUser");
			var monster = builder.BuildCharacter("monster", "TestMonster");

			var gameBoard = new BoardGame(new List<Player> { warrior, monster }, false);
			((HumanPlayer)warrior).Initialize(gameBoard);

			// act


			// assert
		}
	}
}
