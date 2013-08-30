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
	/// Take 1/2 DMG from a monster hit and no status effects OR remove all status effects from yourself
	/// TODO:  Actually make this card do what it's supposed to do.
	/// TODO: Impliment instant system.
	/// TODO: Add this to cards drawn.
	/// </summary>
	public class ShieldBlock : ICard
	{
		private readonly Warrior warriorPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public ShieldBlock(Warrior warriorPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.warriorPlayer = warriorPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Shield Block";
			}
		}

		public void OptionalUse()
		{
			// TODO: Remove this Optional
		}

		/// <summary>
		/// Instant
		/// Take 1/2 DMG from a monster hit and no status effects OR remove all status effects from yourself
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
