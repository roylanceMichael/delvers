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
	/// Play when any player is hit by an enemy.  That enemy takes DMG equal to your ATK.
	/// TODO: Add to cards drawn, 3 of them.
	/// </summary>
	public class Retaliate : DefensiveInstantCard, ICard
	{
		private readonly Archer archerPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public Retaliate(Archer archerPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.archerPlayer = archerPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Retaliate";
			}
		}

		public void OptionalUse()
		{
			// TODO: remove this optional.
		}

		/// <summary>
		/// Play when any player is hit by an enemy.  That enemy takes DMG equal to your ATK.
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

			// Play when any player is hit by an enemy.  That enemy takes DMG equal to your ATK.
			// TODO: Make it so this does what it's supposed to.

		}
	}
}
