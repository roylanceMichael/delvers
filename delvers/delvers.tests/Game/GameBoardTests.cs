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
			var builder = new CharacterBuilder();
			var archer = builder.BuildCharacter("archer", "CoolArcher");
			var players = new List<Player> { archer, builder.BuildCharacter("monster", "BadMonster") };

			var boardGame = new BoardGame(players, false);

			// act
			Assert.IsFalse(boardGame.GameEnded());
			archer.TakeDamage(archer.Hp);

			// assert
			Assert.IsTrue(boardGame.GameEnded());
		}
	}
}
