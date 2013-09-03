using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Turns.Cards.Archer
{
	using delvers.Characters;
	using delvers.Game;
	using delvers.Log;
	using delvers.Turns.Targetting;

	/// <summary>
	/// Range: 8
	/// Deal 2d8 + ATK DMG to a single enemy
	/// Optional
	/// -3 Energy: Gain 2 ATK for this attack and until the end of your next turn
	/// TODO: Add this to cards Drawn, 3 of them
	/// TODO: implement status effects over turns system
	/// </summary>
	public class Headshot : NonInstantCard, ICard
	{
		private readonly Archer archerPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public Headshot(Archer archerPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.archerPlayer = archerPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Headshot";
			}
		}

		/// <summary>
		/// Optional
		/// -3 Energy: Gain 2 ATK for this attack and until the end of your next turn
		/// </summary>
		public void OptionalUse()
		{
			// TODO: Implement Energy system
			// TODO: implement status effects over turns system
		}

		/// <summary>
		/// Range: 8
		/// Deal 2d8 + ATK DMG to a single enemy
		/// TODO: Implement range vs melee
		/// TODO: Implement movement system
		/// TODO: Implement energy system
		/// </summary>
		public void Use(AttackParameters attackParameters = null)
		{
			var monsters = this.gameBoard.GetMonsters().ToList();
			var monsterIdx = this.targetPlayer.TargetPlayer(monsters);

			if (monsterIdx < 0)
			{
				return;
			}

			var monster = monsters[monsterIdx];

			// Deal 2d8 + ATK DMG to a single enemy
			var firstRoll = Utilities.Randomizer.GetRandomValue(1, 8);
			var secondRoll = Utilities.Randomizer.GetRandomValue(1, 8);
			var damageTaken = firstRoll + secondRoll + this.archerPlayer.AttackPower;

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.archerPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
