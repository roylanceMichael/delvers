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
	/// Deal DEF DMG to a single enemy
	/// Optional
	/// -2 Rage: +1d6 DMG to this attack
	/// </summary>
	public class SwordSlash : NonInstantCard, ICard
	{
		private readonly Warrior warriorPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public SwordSlash(Warrior warriorPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.warriorPlayer = warriorPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Sword Slash";
			}
		}

		/// <summary>
		/// Optional
		/// 2 Rage: +1d6 DMG to this attack
		/// </summary>
		public void OptionalUse()
		{
			// TODO: Implement rage system
		}

		/// <summary>
		/// Melee
		/// Deal DEF DMG to a single enemy
		/// TODO: Implement range vs melee
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

			// Deal DEF DMG to a single enemy
			var damageTaken = this.warriorPlayer.DefensePower;

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.warriorPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
