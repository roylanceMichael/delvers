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
	/// +1 Mana: MGK DMG to all enemies in a 2x2 area.
	/// or
	/// -1 Mana: MGK DMG to all enemies in a 2x2 area AND those enemies are also slowed.
	/// or
	/// -3 Mana: 1d6+MGK DMG to all enemies in a 2x2 area and those enemies are also slowed.
	/// </summary>
	public class ColdSnap : ICard
	{
		private readonly Wizard wizardPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public ColdSnap(Wizard wizardPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.wizardPlayer = wizardPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Cold Snap";
			}
		}

		/// <summary>
		/// -1 Mana: MGK DMG to all enemies in a 2x2 area AND those enemies are also slowed.
		/// TODO: implement Mana System
		/// </summary>
		public void OptionalUse()
		{
			// TODO: implement Mana system
			// TODO: Implement movement system for AOE DMG
		}

		/// <summary>
		/// -3 Mana: MGK DMG to all enemies in a 2x2 area.
		/// TODO: implement Mana System
		/// </summary>
		public void OptionalUse2()
		{
			// TODO: implement Mana system
		}

		/// <summary>
		/// Range: 6
		/// +1 Mana: Deal MGK to all enemies in a 2x2 area.
		/// TODO: implement Mana System
		/// TODO: Implement movement system for AOE
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

			// +1 Mana: Deal MGK DMG to all Enemies in a 2x2 area.
			var damageTaken = this.wizardPlayer.MagicPower;

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.wizardPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
