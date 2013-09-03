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
	/// Deal 1d6 + DEF DMG to a single Enemy
	/// Optional
	/// -3 Rage: +2 Defense for this attack until the end of your next turn.
	/// </summary>
	public class ShieldBash : NonInstantCard, ICard
	{
		private readonly Warrior warriorPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public ShieldBash(Warrior warriorPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.warriorPlayer = warriorPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Shield Bash";
			}
		}

		/// <summary>
		/// Optional
		/// -3 Rage: +2 Defense for this attack until the end of your next turn.
		/// </summary>
		public void OptionalUse()
		{
			// TODO: Implement rage system
		}

		/// <summary>
		/// Melee
		/// Deal 1d6 + DEF DMG to a single Enemy
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

			// Deal 1d6 + DEF DMG to a single Enemy
			var damageTaken = Utilities.Randomizer.GetRandomValue(1, 6) + this.warriorPlayer.DefensePower;

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.warriorPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
