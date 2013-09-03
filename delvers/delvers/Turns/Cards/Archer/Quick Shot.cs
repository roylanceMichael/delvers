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
	/// Deal 1d8 + ATK + MGK DMG to a single enemy
	/// Optional
	/// -1 Energy: Substitute MGK for ATK DMG
	/// TODO: Add this to cards Drawn, 6 of them
	/// </summary>
	public class QuickShot : NonInstantCard, ICard
	{
		private readonly Archer archerPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public QuickShot(Archer archerPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.archerPlayer = archerPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Quick Shot";
			}
		}

		/// <summary>
		/// Optional
		/// -1 Energy: Substitute MGK for ATK DMG
		/// </summary>
		public void OptionalUse()
		{
			// TODO: Implement Energy system
		}

		/// <summary>
		/// Range: 8
		/// Deal 1d8 + ATK + MGK DMG to a single enemy
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

			// Deal 1d8 + ATK + MGK DMG to a single enemy
			var damageTaken = Utilities.Randomizer.GetRandomValue(1, 8) + this.archerPlayer.AttackPower + this.archerPlayer.MagicPower;

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.archerPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
