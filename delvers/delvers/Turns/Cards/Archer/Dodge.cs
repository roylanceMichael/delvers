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
	/// Take 1/2 DMG and no status effects from a monster hit or remove all status effects from yourself
	/// TODO: Add to cards drawn, 3 of them.
	/// </summary>
	public class Dodge :DefensiveInstantCard, ICard
	{
		private readonly Archer archerPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public Dodge(Archer archerPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.archerPlayer = archerPlayer;
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
			// TODO: remove this optional or add the optional OR useage.
		}

		/// <summary>
		/// Take 1/2 DMG and no status effects from a monster hit or remove all status effects from yourself
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

			// Take 1/2 DMG and no status effects from a monster hit or remove all status effects from yourself
			// TODO: Make it so this does what it's supposed to.

		}
	}
}
