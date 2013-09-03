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
	/// +1 Spirit: Deal 1d6 DMG to a single Enemy.
	/// OR
	/// 0 Spirit: Deal 1d6 + MGK DMG to a single enemy.
	/// OR
	/// -1 Spirit: 1d6 + MGK to a single enemy and target player gets +2 DEF for 2 turns.
	/// TODO: Add to cards drawn, 6 of them
	/// </summary>
	public class HolyBolt : NonInstantCard, ICard
	{
		private readonly Cleric clericPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public HolyBolt(Cleric clericPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.clericPlayer = clericPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Holy Bolt";
			}
		}

		/// <summary>
		/// 0 Spirit: 1d6 + MGK to a single enemy.
		/// TODO: implement Spirit System
		/// </summary>
		public void OptionalUse()
		{
			// TODO: implement Mana system
		}

		/// <summary>
		/// -1 Spirit: 1d6 + MGK to a single enemy and target player gets +2 DEF for 2 turns.
		/// TODO: implement Spirit System
		/// TODO: Implement status effects over turns system
		/// </summary>
		public void OptionalUse2()
		{
			// TODO: implement Mana system
		}

		/// <summary>
		/// Range: 6
		/// +1 Spirit: Deal 1d6 DMG to a single Enemy.
		/// TODO: implement Spirit System
		/// TODO: Implement ranged vs. melee
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

			// +1 Spirit: Deal 1d6 DMG to a single Enemy
			// TODO Implement Spirit System
			var damageTaken = Utilities.Randomizer.GetRandomValue(1, 6);

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.clericPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
