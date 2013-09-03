using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Turns.Cards.Cleric
{
	using delvers.Characters;
	using delvers.Game;
	using delvers.Log;
	using delvers.Turns.Attacking;
	using delvers.Turns.Targetting;

	/// <summary>
	/// Range: 6
	/// Deal 2d6 + MGK DMG to a single enemy
	/// Target player gets +2 DEF for turns = amount of spirit spent
	/// TODO: Add to cards drawn, 3 of them
	/// </summary>
	public class StrengthentheLine : NonInstantCard, ICard
	{
		private readonly Cleric clericPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public StrengthentheLine(Cleric clericPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.clericPlayer = clericPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Strengthen the Line";
			}
		}

		public void OptionalUse()
		{
			// TODO: Delete Optional Use
		}

		/// <summary>
		/// Range: 6
		/// Deal 2d6 + MGK DMG to a single enemy
		/// Target player gets +2 DEF for turns = amount of spirit spent
		/// TODO: Implement ranged vs. melee
		/// TODO: Implement spirit system
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

			// Deal 2d6 + MGK DMG to a single enemy
			var damageTaken = Utilities.Randomizer.GetRandomValue(1, 6) + Utilities.Randomizer.GetRandomValue(1, 6) + this.clericPlayer.MagicPower;

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.clericPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
