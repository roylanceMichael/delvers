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
	/// Move your speed as part of this attack.  Deal 2d4 + ATK DMG
	/// to X different enemies you pass adjacent to, where
	/// X = amount of energy spent.  Cannot hit the same enemy twice.
	/// TODO: Add this to cards Drawn, 1 of them
	/// </summary>
	public class StickandMove : ICard
	{
		private readonly Thief thiefPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public StickandMove(Thief thiefPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.thiefPlayer = thiefPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Stick and Move";
			}
		}

		public void OptionalUse()
		{
			// TODO: delete this optional
		}

		/// <summary>
		/// melee
		/// Move your speed as part of this attack.  Deal 2d4 + ATK DMG
		/// to X different enemies you pass adjacent to, where
		/// X = amount of energy spent.  Cannot hit the same enemy twice.
		/// TODO: Implement range vs melee
		/// TODO: Implement movement system
		/// TODO: Implement energy system
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

			/// Move your speed as part of this attack.  Deal 2d4 + ATK DMG
			/// to X different enemies you pass adjacent to, where
			/// X = amount of energy spent.  Cannot hit the same enemy twice.
			var damageTaken = Utilities.Randomizer.GetRandomValue(1, 4) + Utilities.Randomizer.GetRandomValue(1, 4) + this.thiefPlayer.AttackPower;

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.thiefPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
