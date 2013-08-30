using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Turns.Cards.Warrior
{
	using delvers.Characters;
	using delvers.Game;
	using delvers.Log;
	using delvers.Turns.Targetting;

	/// <summary>
	/// Melee
	/// Deal 2d6+ATK DMG to a single enemy
	/// Optional
	/// 2 Rage: that the enemy must attack you with all attacks on its next turn
	/// </summary>
	public class MockingBlow : ICard
	{
		private readonly Warrior warriorPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public MockingBlow(Warrior warriorPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.warriorPlayer = warriorPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Mocking Blow";
			}
		}

		/// <summary>
		/// Optional
		/// 2 Rage: that the enemy must attack you with all attacks on its next turn
		/// TODO: Implement monster attack priority so monster attacks warrior.
		/// </summary>
		public void OptionalUse()
		{
			// TODO: Implement rage system
		}

		/// <summary>
		/// Melee
		/// Deal 2d6+ATK DMG to a single enemy
		/// TODO: Implement range vs melee
		/// </summary>
		public void Use()
		{
			var monsters = this.gameBoard.GetMonsters().ToList();
			var monsterIdx = this.targetPlayer.TargetPlayer(monsters);

			if (monsterIdx < 0)
			{
				return;
			}

			var monster = monsters[monsterIdx];

			// Deal 2d6+ATK DMG to a single Enemy
			var firstRoll = Utilities.Randomizer.GetRandomValue(1, 6);
			var secondRoll = Utilities.Randomizer.GetRandomValue(1, 6);
			var damageTaken = firstRoll + secondRoll + this.warriorPlayer.AttackPower;

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.warriorPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
