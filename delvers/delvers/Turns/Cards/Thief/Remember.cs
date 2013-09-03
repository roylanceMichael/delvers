using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Turns.Cards.Thief
{
	using delvers.Characters;
	using delvers.Game;
	using delvers.Log;
	using delvers.Turns.Targetting;

	/// <summary>
	/// Melee
	/// Draw 1 normal attack from your discard pile and play it immediately
	/// TODO: Add this to cards Drawn, 3 of them
	/// </summary>
	public class Remember : NonInstantCard, ICard
	{
		private readonly Thief thiefPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public Remember(Thief thiefPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.thiefPlayer = thiefPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Remember";
			}
		}

		public void OptionalUse()
		{
			// TODO: delete this optional
		}

		/// <summary>
		/// melee
		/// Draw 1 normal attack from your discard pile and play it immediately
		/// TODO: Implement range vs melee
		/// TODO: Implement movement system
		/// TODO: Implement energy system
		/// TODO: Make this card do what it's actually supposed to.
		/// </summary>
		public void Use(AttackParameters attackParameters = null)
		{
			var monsters = this.gameBoard.GetMonsters().ToList();
			var monsterIdx = this.targetPlayer.TargetPlayer(monsters);

			if (monsterIdx < 0)
			{
				return;
			}
		}
	}
}
