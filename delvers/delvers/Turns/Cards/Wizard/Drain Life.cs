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
    /// Deal 1d6+MGK DMG to a single Enemy.
    /// Optional:
    /// -1 Mana: Gain HP equal to your heal value. (heal value = 25% rounded to nearest integer)
    /// </summary>
    public class DrainLife : ICard
    {
        private readonly Wizard wizardPlayer;
        private readonly IBoardGame gameBoard;
        private readonly ITargetPlayer targetPlayer;

        public DrainLife(Wizard wizardPlayer, IBoardGame gameBoard, ITargetPlayer targetPlayer)
        {
            this.wizardPlayer = wizardPlayer;
            this.gameBoard = gameBoard;
            this.targetPlayer = targetPlayer;
        }

        public string Name
        {
            get
            {
                return "Drain Life";
            }
        }

        /// <summary>
        /// 1 Mana: Gain HP equal to your heal value
        /// </summary>
        public void OptionalUse()
        {
            // TODO: implement Mana system
        }

        /// <summary>
        /// Range: 6
        /// Deal 1d6+MGK DMG to a single Enemy.
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

            // Deal 1d6+MGK DMG to a single Enemy
            var damageTaken = Utilities.Randomizer.GetRandomValue(1, 6) + this.wizardPlayer.MagicPower;

            monster.TakeDamage(damageTaken);

            GameLogger.LogFormat("{0} used the {1} and gave {2} damage to {3}", this.wizardPlayer.Name, this.Name, damageTaken, monster.Name);
        }
    }
}
