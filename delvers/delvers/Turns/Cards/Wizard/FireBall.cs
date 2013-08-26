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
	/// -1 Mana: Deal 1d6+MGK DMG to a single enemy.
	/// or
	/// -2 Mana: Deal 1d6+MGK DMG to all enemies in a 2x2 area.
	/// or
	/// -3 Mana: Deal 1d6+MGK DMG to all enemies in a 3x3 area.
	/// </summary>
	public class FireBall : ICard
	{
		private readonly Wizard wizardPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public FireBall(Wizard wizardPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.wizardPlayer = wizardPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "FireBall";
			}
		}

		/// <summary>
		/// -2 Mana: Deal 1d6+MGK DMG to all enemies in a 2x2 area.
		/// TODO: implement Mana System
		/// TODO: Implement AOE System
		/// </summary>
		public void OptionalUse()
		{
			// TODO: implement Mana system
			// TODO: Implement movement system for AOE DMG
		}

		/// <summary>
		/// -3 Mana: Deal 1d6+MGK DMG to all enemies in a 3x3 area.
		/// TODO: implement Mana System
		/// </summary>
		public void OptionalUse2()
		{
			// TODO: implement rage system
		}

		/// <summary>
		/// Range: 6
		/// -1 Mana: Deal 1d6+MGK DMG to a single enemy.
		/// TODO: implement Mana System
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

			// -1 Mana: Deal 1d6+MGK DMG to a single enemy.
			var damageTaken = this.wizardPlayer.MagicPower;

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.wizardPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
