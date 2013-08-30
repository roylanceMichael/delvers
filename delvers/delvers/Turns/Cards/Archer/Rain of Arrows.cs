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
	/// Deal ATK DMG to all enemies in a 2x2 area
	/// Optional
	/// -1 energy: Deal ATK DMG to all enemies in a 3x3 area
	/// or
	/// -3 energy: Deal ATK DMG to all enemies on the board.
	/// TODO: Add this to cards Drawn, 1 of them
	/// </summary>
	public class RainofArrows : ICard
	{
		private readonly Archer archerPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public RainofArrows(Archer archerPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.archerPlayer = archerPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Rain of Arrows";
			}
		}

		/// <summary>
		/// Optional
		/// -1 energy: Deal ATK DMG to all enemies in a 3x3 area
		/// or
		/// -3 energy: Deal ATK DMG to all enemies on the board.
		/// </summary>
		public void OptionalUse()
		{
			// TODO: Implement Energy system
			// TODO: Add another optional use
			// TODO: implement damage over time system
		}

		/// <summary>
		/// Range: 8
		/// Deal ATK DMG to all enemies in a 2x2 area
		/// TODO: Implement range vs melee
		/// TODO: Implement movement system
		/// TODO: Implement energy system
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

			// Deal ATK DMG to all enemies in a 2x2 area
			// TODO: implement movement system for AOE
			var damageTaken = this.archerPlayer.AttackPower;

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.archerPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
