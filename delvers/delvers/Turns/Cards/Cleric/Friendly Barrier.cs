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
	/// Range: 6
	/// Instant
	/// Target player takes 1/2 DMG and no status effects from a monster hit
	/// OR
	/// Remove all status effects from target player
	/// TODO: Add to cards drawn, 5 of them
	/// </summary>
	public class FriendlyBarrier : ICard
	{
		private readonly Cleric clericPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public FriendlyBarrier(Cleric clericPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.clericPlayer = clericPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Friendly Barrier";
			}
		}

		public void OptionalUse()
		{
			// TODO: Make this remove status effects
		}

		/// <summary>
		/// Range: 6
		/// Instant
		/// Target player takes 1/2 DMG and no status effects from a monster hit
		/// TODO: Implement ranged vs. melee
		/// TODO: implement status effects over turns
		/// TODO: Make this do what its supposed to do.
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

			// Target player takes 1/2 DMG and no status effects from a monster hit
		}
	}
}
