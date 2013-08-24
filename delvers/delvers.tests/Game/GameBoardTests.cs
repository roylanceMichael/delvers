using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.tests.Game
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using delvers.Builders;
	using delvers.Characters;
	using delvers.Game;

	[TestClass]
	public class GameBoardTests
	{			
		[TestMethod]
		public void VerifyGameEndsWhenOneTeamIsDead()
		{
			// arrange
			var archer = new Archer("CoolArcher");
			var players = new List<Player> { archer, new Monster("BadMonster") };

			var boardGame = new BoardGame(players, false);

			// act
			Assert.IsFalse(boardGame.GameEnded());
			archer.TakeDamage(archer.Hp);

			// assert
			Assert.IsTrue(boardGame.GameEnded());
		}
	}
}
