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
	/// Instant
	/// You Take no Damage or status effects from a monster hit.
	/// TODO: Add to cards drawn, 1 of them
	/// </summary>
	public class TotalDefense : ICard
	{
		private readonly Cleric clericPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public TotalDefense(Cleric clericPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.clericPlayer = clericPlayer;
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
			// TODO: Make this remove status effects
		}

		/// <summary>
		/// Instant
		/// You Take no Damage or status effects from a monster hit.
		/// TODO: Implement ranged vs. melee
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

			// You Take no Damage or status effects from a monster hit.
		}
	}
}
