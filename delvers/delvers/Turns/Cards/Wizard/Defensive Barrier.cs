﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Turns.Cards.Wizard
{
	using delvers.Characters;
	using delvers.Game;
	using delvers.Log;
	using delvers.Turns.Attacking;
	using delvers.Turns.Targetting;

	/// <summary>
	/// Range: 6
	/// Any single player takes 1/2 DMG from a hit (ignoring status effects) OR remove all status effectts from a single player.
	/// TODO: Make it so wizard draws this card in Wizard.cs 3 of them
	/// TODO: implement instant system that rejens in cleanup phase
	/// </summary>
	public class DefensiveBarrier : DefensiveInstantCard, ICard
	{
		private readonly Wizard wizardPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public DefensiveBarrier(Wizard wizardPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.wizardPlayer = wizardPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Defensive Barrier";
			}
		}

		public void OptionalUse()
		{
			// TODO: Delete this optional use.
		}

		public void Use(AttackParameters attackParameters = null)
		{
			var monsters = this.gameBoard.GetMonsters().ToList();
			var monsterIdx = this.targetPlayer.TargetPlayer(monsters);

			if (monsterIdx < 0)
			{
				return;
			}

			var monster = monsters[monsterIdx];

			// Any single player takes 1/2 DMG from a hit (ignoring status effects) OR remove all status effectts from a single player.
			// TODO: Change this to actually do what it says.
			var damageTaken = Utilities.Randomizer.GetRandomValue(1, 6) + this.wizardPlayer.MagicPower;

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.wizardPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
