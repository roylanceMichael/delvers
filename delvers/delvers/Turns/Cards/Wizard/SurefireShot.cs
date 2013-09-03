using System;
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
	/// +1 Mana: Deal 1d6+MGK DMG to a single Enemy.
	/// or
	/// -1 Mana: 1d6+MGK to a single enemy.
	/// or
	/// -2 Mana: 1d6+MGK DMG to a single enemy and you gain +2 MGK for 2 turns.
	/// </summary>
	public class SurefireShot : NonInstantCard, ICard
	{
		private readonly Wizard wizardPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public SurefireShot(Wizard wizardPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.wizardPlayer = wizardPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Surefire Shot";
			}
		}

		/// <summary>
		/// -1 Mana: 1d6+MGK to a single enemy
		/// TODO: implement Mana System
		/// </summary>
		public void OptionalUse()
		{
			// TODO: implement Mana system
		}

		/// <summary>
		/// -2 Mana: 1d6+MGK DMG to a single enemy and you gain +2 MGK for 2 turns.
		/// TODO: implement Mana System
		/// </summary>
		public void OptionalUse2()
		{
			// TODO: implement rage system
		}

		/// <summary>
		/// Range: 6
		/// +1 Mana: Deal MGK to a single Enemy.
		/// TODO: implement Mana System
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

			// +1 Mana: Deal MGK DMG to a single Enemy
			var damageTaken = this.wizardPlayer.MagicPower;

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.wizardPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
