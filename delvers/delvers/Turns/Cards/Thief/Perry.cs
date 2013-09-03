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
	/// Take 1/2 DMG and no status effects from a hit
	/// OR
	/// Remove all status effects from yourself.
	/// TODO: Add this to cards Drawn, 2 of them
	/// </summary>
	public class Perry : DefensiveInstantCard, ICard
	{
		private readonly Thief thiefPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public Perry(Thief thiefPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.thiefPlayer = thiefPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Perry";
			}
		}

		public void OptionalUse()
		{
			// TODO: Remove all status effects from yourself
		}

		/// <summary>
		/// melee
		/// Take 1/2 DMG and no status effects from a hit
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
