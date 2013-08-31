using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Turns.Cards.Wizard
{
    using delvers.Characters;
    using delvers.Game;
    using delvers.Log;
    using delvers.Turns.Attacking;
    using delvers.Turns.Targetting;

    /// <summary>
    /// Range: 6
    /// 0 Mana: Deal 2d6+MGK DMG to a single enemy
    /// or
    /// -2 Mana: Deal 2d6+MGK DMG to a single enemy and it is immobilized and cannot move its next turn
    /// </summary>
    public class FrostBolt : ICard
    {
        private readonly Wizard wizardPlayer;
        private readonly IBoardGame gameBoard;
        private readonly ITargetPlayer targetPlayer;

        public FrostBolt(Wizard wizardPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
        {
            this.wizardPlayer = wizardPlayer;
            this.gameBoard = gameBoard;
            this.targetPlayer = targetPlayer;
        }

        public string Name
        {
            get
            {
                return "Frostbolt";
            }
        }

        /// <summary>
		/// -2 Mana: Deal 2d6+MGK DMG to a single enemy and it is immobilized and cannot move its next turn
		/// TODO: Impliment movement and status effect tracker for immobilization
        /// </summary>
        public void OptionalUse()
        {
            // TODO: implement Mana system
        }

        /// <summary>
        /// Range: 6
        /// 0 Mana: Deal 2d6+MGK DMG to a single enemy
        /// TODO: Implement ranged vs. melee
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

			// 0 Mana: Deal 2d6+MGK DMG to a single enemy
            // TODO: Implement Mana System
            // TODO: Implement Movement and status effect system
            var firstRoll = Utilities.Randomizer.GetRandomValue(1, 6);
            var secondRoll = Utilities.Randomizer.GetRandomValue(1, 6);
            var damageTaken = firstRoll + secondRoll + this.wizardPlayer.MagicPower;

            monster.TakeDamage(damageTaken);

            GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.wizardPlayer.Name, this.Name, damageTaken, monster.Name);
        }
    }
}
