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
	/// Melee
	/// Charge in a straight line your move distance. 
	/// Deal 1d6 DMG to X different enemies you pass adjacent to,
	/// where X=Rage spent.
	/// Also, gain 2 DEF for every 2 Rage spent in this way
	/// </summary>
	public class IntoTheFray : NonInstantCard, ICard
	{
		private readonly Warrior warriorPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public IntoTheFray(Warrior warriorPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.warriorPlayer = warriorPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Defensive Strike";
			}
		}

		/// <summary>
		/// Optional
		/// 2 Rage: Gain +2 DEF until the end of your next turn
		/// </summary>
		public void OptionalUse()
		{
			// TODO: Implement rage system
		}

		/// <summary>
		/// Charge in a straight line your move distance. 
		/// Deal 1d6 DMG to X different enemies you pass adjacent to,
		/// where X=Rage spent.
		/// Also, gain 2 DEF for every 2 Rage spent in this way
		/// TODO: Implement move system. For now just attacking one monster
		/// TODO: Make this so it does what it's supposed to.
		/// TODO: Implement Rage system
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

			// Deal 1d6+ATK DMG to a single Enemy
			// TODO:  Make this do what it's supposed to do.
			var firstRoll = Utilities.Randomizer.GetRandomValue(1, 6);
			var damageTaken = firstRoll;

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.warriorPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
