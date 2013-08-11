using System.Collections.Generic;
using System.Linq;

namespace delvers.Turns
{
	using delvers.Characters;
	using delvers.Turns.Attacking;
	using delvers.Turns.Targetting;

	public class Turn
	{
		private readonly IAttackAmount attackAmount;

		private readonly ITargetPlayer targetPlayer;

		public Turn(IAttackAmount attackAmount, ITargetPlayer targetplayer)
		{
			this.attackAmount = attackAmount;
			this.targetPlayer = targetplayer;
		}

		public Turn()
		{
			this.attackAmount = new StaticAmount();
			this.targetPlayer = new RandomPlayer();
		}

		public string PerformTurn(IList<Player> players, Player performingPlayer)
		{
			if (players == null || !players.Any() || performingPlayer == null)
			{
				return string.Empty;
			}

			var targettedPlayerIdx = this.targetPlayer.TargetPlayer(players);
			var targettedPlayer = players[targettedPlayerIdx];
			var amount = this.attackAmount.AttackAmount();
			targettedPlayer.TakeDamage(amount);

			return string.Format("\t{0} was attacked for {1} by {2}!",
				targettedPlayer.Name,
				amount,
				performingPlayer.Name);
		}
	}
}
