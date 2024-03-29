﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Turns.Cards.Warrior
{
	using delvers.Characters;
	using delvers.Game;
	using delvers.Log;
	using delvers.Turns.Attacking;
	using delvers.Turns.Targetting;

	/// <summary>
	/// Melee
	/// Deal 1d6+ATK DMG to a single Enemy.
	/// Optional:
	/// -1 Rage: Gain HP equal to your heal value. (heal value = 25% rounded to nearest integer)
	/// </summary>
	public class RejuvenatingStrike : NonInstantCard, ICard
	{
		private readonly Warrior warriorPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public RejuvenatingStrike(Warrior warriorPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.warriorPlayer = warriorPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Rejuventating Strike";
			}
		}

		/// <summary>
		/// 1 Rage: Gain HP equal to your heal value
		/// </summary>
		public void OptionalUse()
		{
			// TODO: implement rage system
		}

		/// <summary>
		/// Melee:
		/// Deal 1d6+ATK DMG to a single Enemy.
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

			// Deal 1d6+ATK DMG to a single Enemy
			var damageTaken = Utilities.Randomizer.GetRandomValue(1, 6) + this.warriorPlayer.AttackPower;

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.warriorPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
