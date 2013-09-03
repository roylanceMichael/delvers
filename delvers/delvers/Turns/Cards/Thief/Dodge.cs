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
	/// Take no DMG or effects from a single monster attack.
	/// TODO: Add this to cards Drawn, 1 of them
	/// </summary>
	public class Dodge : DefensiveInstantCard, ICard
	{
		private readonly Thief thiefPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public Dodge(Thief thiefPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.thiefPlayer = thiefPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Dodge";
			}
		}

		public void OptionalUse()
		{
			// TODO: delete this optional
		}

		/// <summary>
		/// melee
		/// Take no DMG or effects from a single monster attack.
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
