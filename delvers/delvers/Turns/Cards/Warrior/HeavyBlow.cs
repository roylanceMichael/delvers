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
	/// 1 Rage: deal 1d6+ATK DMG to a single enemy
	/// 2 Rage: deal 2d6+ATK DMG to a single enemy
	/// 3 Rage: deal 3d6+ATK DMG to a single enemy
	/// </summary>
	public class HeavyBlow : NonInstantCard, ICard
	{
		private readonly Warrior warriorPlayer;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;

		public HeavyBlow(Warrior warriorPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
		{
			this.warriorPlayer = warriorPlayer;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
		}

		public string Name
		{
			get
			{
				return "Heavy Blow";
			}
		}

		/// <summary>
		/// Optional
		/// </summary>
		public void OptionalUse()
		{
			// TODO: Implement rage system
		}

		/// <summary>
		/// Melee
		/// 1 Rage: deal 1d6+ATK DMG to a single enemy
		/// 2 Rage: deal 2d6+ATK DMG to a single enemy
		/// 3 Rage: deal 3d6+ATK DMG to a single enemy
		/// TODO: Implement range vs melee
		/// TODO: Make this attack work how it's supposed to.
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

	
			var firstRoll = Utilities.Randomizer.GetRandomValue(1, 6);
			var secondRoll = Utilities.Randomizer.GetRandomValue(1, 6);
			var damageTaken = firstRoll + secondRoll + this.warriorPlayer.AttackPower;

			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.warriorPlayer.Name, this.Name, damageTaken, monster.Name);
		}
	}
}
