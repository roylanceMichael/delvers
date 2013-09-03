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
	/// Deal 1d8 + MGK DMG to X enemies, where X equals the amount of energy spent.
	/// TODO: Add to cards drawn, 1 of them.
	/// </summary>
	public class MagicArrow : NonInstantCard, ICard
	{
		private readonly Archer archerPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public MagicArrow(Archer archerPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.archerPlayer = archerPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Magic Arrow";
			}
		}

		public void OptionalUse()
		{
			// TODO: remove this optional
		}

		/// <summary>
		/// Range: 8
		/// Deal 1d8 + MGK DMG to X enemies, where X equals the amount of energy spent.
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

			// Deal 1d8 + MGK DMG to X enemies, where X equals the amount of energy spent.
			// TODO: figure out how to make this do what it's supposed to and target multiple enemies.
			var damageTaken = Utilities.Randomizer.GetRandomValue(1, 8) + this.archerPlayer.AttackPower;

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.archerPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
