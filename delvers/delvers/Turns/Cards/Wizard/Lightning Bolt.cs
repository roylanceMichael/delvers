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
	/// 0 Mana: Deal 1d6+MGK DMG to a single Enemy.
	/// or
	/// -3 Mana: Deal 1d6+MGK DMG to a single enemy and all enemies adjacent to it
	/// </summary>
	public class LightningBolt : ICard
	{
		private readonly Wizard wizardPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public LightningBolt(Wizard wizardPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.wizardPlayer = wizardPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Lightning Bolt";
			}
		}

		/// <summary>
		/// -3 Mana: Deal 1d6+MGK DMG to a single enemy and all enemies adjacent to it
		/// TODO: Implement move system for AOE spell
		/// TODO: implement Mana System
		/// </summary>
		public void OptionalUse()
		{
			// TODO: implement Mana system
		}

		/// <summary>
		/// Range: 6
		/// 0 Mana: Deal MGK to a single Enemy.
		/// TODO: implement Mana System
		/// TODO: Implement ranged vs. melee
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

			// 0 Mana: Deal 1d6+MGK DMG to target enemey and all enemies adjacent to it.
			// TODO: Implement movement for AOE Damage.
			var damageTaken = Utilities.Randomizer.GetRandomValue(1, 6);

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.wizardPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
