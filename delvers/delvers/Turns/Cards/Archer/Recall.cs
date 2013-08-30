using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Turns.Cards.Archer
{
	using delvers.Characters;
	using delvers.Game;
	using delvers.Log;
	using delvers.Turns.Targetting;

	/// <summary>
	/// instant
	/// Draw a normal attack card from your discard pile and play it immediately.
	/// TODO: Add to cards drawn, 3 of them.
	/// </summary>
	public class Recall : ICard
	{
		private readonly Archer archerPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public Recall(Archer archerPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.archerPlayer = archerPlayer;
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
			// TODO: remove this optional.
		}

		/// <summary>
		/// Draw a normal attack card from your discard pile and play it immediately.
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

			// Draw a normal attack card from your discard pile and play it immediately.
			// TODO: Make it so this does what it's supposed to.

		}
	}
}
