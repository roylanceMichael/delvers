using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Turns.Cards.Cleric
{
	using delvers.Characters;
	using delvers.Game;
	using delvers.Log;
	using delvers.Turns.Attacking;
	using delvers.Turns.Targetting;

	/// <summary>
	/// Range: 6
	/// Target player gets +2 DEF for 2 turns
	/// TODO: Add to cards drawn, 4 of them
	/// </summary>
	public class Defend : NonInstantCard, ICard
	{
		private readonly Cleric clericPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public Defend(Cleric clericPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.clericPlayer = clericPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Defend";
			}
		}

		public void OptionalUse()
		{
			// TODO: Delete Optional Use
		}

		/// <summary>
		/// Range: 6
		/// Instant
		/// Target player gets +2 DEF for 2 turns
		/// TODO: Implement ranged vs. melee
		/// TODO: implement status effects over turns
		/// TODO: Make this do what its supposed to do.
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

			// Target player gets +2 DEF for 2 turns
		}
	}
}
