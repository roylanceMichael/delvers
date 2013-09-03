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
	/// Deal MGK DMG to all enemies within 2 squares.
	/// All players within 3 squares regain HP equal to your DEF
	/// TODO: Add to cards drawn, 1 of them
	/// </summary>
	public class Consecrate : NonInstantCard, ICard
	{
		private readonly Cleric clericPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public Consecrate(Cleric clericPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.clericPlayer = clericPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Consecrate";
			}
		}

		public void OptionalUse()
		{
			// TODO: Delete Optional Use
		}

		/// <summary>
		/// Deal MGK DMG to all enemies within 2 squares.
		/// All players within 3 squares regain HP equal to your DEF
		/// TODO: Implement ranged vs. melee
		/// TODO: Implement movement system for AOE DMG
		/// TODO: Implement movement system for AOE Heal
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

			// Deal MGK DMG to all enemies within 2 squares
			var damageTaken = Utilities.Randomizer.GetRandomValue(1, 6) + Utilities.Randomizer.GetRandomValue(1, 6) + this.clericPlayer.MagicPower;

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.clericPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
