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
	/// Play when you are hit by an enemy monster.  You take no DMG or status effects from that hit
	/// TODO: Add to cards drawn, 1 of them.
	/// </summary>
	public class TotalDefense : ICard
	{
		private readonly Archer archerPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public TotalDefense(Archer archerPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.archerPlayer = archerPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Total Defense";
			}
		}

		public void OptionalUse()
		{
			// TODO: remove this optional.
		}

		/// <summary>
		/// Play when you are hit by an enemy monster.  You take no DMG or status effects from that hit
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

			// Play when you are hit by an enemy monster.  You take no DMG or status effects from that hit
			// TODO: Make it so this does what it's supposed to.

		}
	}
}
