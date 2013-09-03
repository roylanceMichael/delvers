using System.Collections.Generic;

namespace delvers.Characters
{
	using System.Linq;

	using delvers.Game;
	using delvers.Log;
	using delvers.Turns.Attacking;
	using delvers.Turns.Cleanup;
	using delvers.Turns.Targetting;

	public class Monster : Player
	{
		internal Monster(string name)
			: base(name)
		{
			this.Hp = Utilities.Randomizer.GetRandomValue(15, 17);
		}

		public override void TakeTurn(IBoardGame gameBoard)
		{
			if (!this.CanTakeTurn)
			{
				return;
			}

			// hard code in specific abilities depending on the monster
			var cleanupTurn = new CleanupTurn(this);
			cleanupTurn.Cleanup();

			// simply attack right now
			var humanPlayers = gameBoard.GetHumanPlayers().ToList();
			var humanToAttack = new RandomPlayer().TargetPlayer(humanPlayers);

			if (humanToAttack < 0)
			{
				return;
			}

			var humanPlayer = humanPlayers[humanToAttack];
			var attackAmount = new StaticAmount().AttackAmount();
			var attackParameters = new AttackParameters
				                       {
					                       AdjustedAmount = attackAmount,
					                       OriginalAmount = attackAmount,
					                       PlayerAttacking = this,
					                       PlayerBeingAttacked = humanPlayer
				                       };

			humanPlayer.TakeDamage(gameBoard, attackParameters);

			GameLogger.LogFormat("{0} gave {1} damage to {2}", this.Name, attackAmount, attackParameters.ReportPlayersBeingAttacked());
		}
	}
}
