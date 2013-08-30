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
	/// Deal 1d8 dmg to 2 Different enemies
	/// Optional
	/// -3 Energy: Add ATK DMG for both attacks
	/// TODO: Add this to cards Drawn, 6 of them
	/// </summary>
	public class TwinStrike : ICard
	{
		private readonly Archer archerPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public TwinStrike(Archer archerPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.archerPlayer = archerPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Twin Strike";
			}
		}

		/// <summary>
		/// Optional
		/// 3 Engery: Add ATK DMG to this attack
		/// </summary>
		public void OptionalUse()
		{
			// TODO: Implement rage system
			// TODO: Implement Energy System
		}

		/// <summary>
		/// Range: 8
		/// Deal 1d8 dmg to 2 Different enemies
		/// TODO: Implement range vs melee
		/// TODO: Implement movement system
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

			// Deal 1d8 dmg to 2 Different enemies
			// TODO: Select another target to do DMG to.
			var damageTaken = Utilities.Randomizer.GetRandomValue(1, 8);

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.archerPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
