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
	/// Deal your DEF in DMG to a Single enemy
	/// and gain DEF until the end of your next turn
	/// Optional
	/// NONE
	/// </summary>
	public class MagicDefense : ICard
	{
		private readonly Warrior warriorPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public MagicDefense(Warrior warriorPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.warriorPlayer = warriorPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Magic Defense";
			}
		}

		/// <summary>
		/// TODO: Remove this Optional
		/// </summary>
		public void OptionalUse()
		{
			// TODO: Implement rage system
		}

		/// <summary>
		/// Melee
		/// Deal your DEF in DMG to a Single enemy
		/// and gain DEF until the end of your next turn
		/// TODO: Implement range vs melee
		/// TODO: Implement concept of DEF until the end of your turn
		/// TODO: Implement until end of next turn for the + DEF
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

			// Deal DEF in DMG to a single enemy
			var damageTaken = this.warriorPlayer.DefensePower;

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.warriorPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
