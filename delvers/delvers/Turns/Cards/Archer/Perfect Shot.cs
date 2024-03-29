﻿using System;
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
	/// Deal 1d8 DMG to a single enemy
	/// Optional
	/// -1 Energy: add ATK to this DMG
	/// TODO: Add this to cards Drawn, 6 of them
	/// </summary>
	public class PerfectShot : NonInstantCard, ICard
	{
		private readonly Archer archerPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public PerfectShot(Archer archerPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.archerPlayer = archerPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Perfect Shot";
			}
		}

		/// <summary>
		/// Optional
		/// -1 Energy: add ATK to this DMG
		/// </summary>
		public void OptionalUse()
		{
			// TODO: Implement Energy system
		}

		/// <summary>
		/// Range: 8
		/// Deal 1d8 DMG to a single enemy
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

			// Deal 1d8 DMG to a single enemy
			var damageTaken = Utilities.Randomizer.GetRandomValue(1, 8);

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.archerPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
