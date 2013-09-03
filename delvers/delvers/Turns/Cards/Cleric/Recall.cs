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
	/// Draw 1 normal attack from your discard pile and play it immediately.
	/// TODO: Add to cards drawn, 3 of them
	/// </summary>
	public class Recall : NonInstantCard, ICard
	{
		private readonly Cleric clericPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public Recall(Cleric clericPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.clericPlayer = clericPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Recall";
			}
		}

		public void OptionalUse()
		{
			// TODO: Make this remove status effects
		}

		/// <summary>
		/// Instant
		/// Draw 1 normal attack from your discard pile and play it immediately.
		/// TODO: Implement ranged vs. melee
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

			// Draw 1 normal attack from your discard pile and play it immediately.
		}
	}
}
