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
	/// Instant
	/// Play when any other player takes DMG.  You each take 1/2 that damage.  You take the higher number for odd numbers.
	/// TODO:  Actually make this card do what it's supposed to do.
	/// TODO: Impliment instant system.
	/// TODO: Add this to cards drawn.
	/// </summary>
	public class ShareTheLoad : ICard
	{
		private readonly Warrior warriorPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public ShareTheLoad(Warrior warriorPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.warriorPlayer = warriorPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Share the Load";
			}
		}

		public void OptionalUse()
		{
			// TODO: Remove this Optional
		}

		/// <summary>
		/// Instant
		/// Play when any other player takes DMG.  You each take 1/2 that damage.  You take the higher number for odd numbers.
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

			// TODO:  Make this do what its supposed to do.

		}
	}
}
