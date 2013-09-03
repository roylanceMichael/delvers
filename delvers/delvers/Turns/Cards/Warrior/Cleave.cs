using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Turns.Cards.Warrior
{
	using delvers.Characters;
	using delvers.Game;
	using delvers.Log;
	using delvers.Turns.Targetting;

	/// <summary>
	/// Melee
	/// Deal 1d6 DMG to all adjacent enemies
	/// Optional
	/// -3 Rage: Add ATK DMG for this attack
	/// </summary>
	public class Cleave : NonInstantCard, ICard
	{
		private readonly Warrior warriorPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public Cleave(Warrior warriorPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.warriorPlayer = warriorPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Cleave";
			}
		}

		/// <summary>
		/// Optional
		/// 3 Rage: Add ATK DMG to this attack
		/// </summary>
		public void OptionalUse()
		{
			// TODO: Implement rage system
		}

		/// <summary>
		/// Melee
		/// Deal 1d6 DMG to all adjacent enemies
		/// TODO: Implement range vs melee
		/// TODO: Implement movement system to do AOE DMG
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

			// Deal 1d6 DMG to all adjacent enemies
			var damageTaken = Utilities.Randomizer.GetRandomValue(1, 6);

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.warriorPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
