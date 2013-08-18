using System;
using System.Collections.Generic;
using System.Linq;

namespace delvers.Turns.Targetting
{
	using delvers.Characters;

	public class LowestHpPlayer : ITargetPlayer
	{
		public int TargetPlayer(IList<Player> players)
		{
			if (players == null || !players.Any())
			{
				throw new ArgumentNullException("players");
			}

			var attackablePlayers = players.Where(player => player.IsAttackable).ToList();

			if (!attackablePlayers.Any())
			{
				return -1;
			}

			var lowestPlayer = attackablePlayers.OrderBy(player => player.Hp).First();

			return players.IndexOf(lowestPlayer);
		}
	}
}
