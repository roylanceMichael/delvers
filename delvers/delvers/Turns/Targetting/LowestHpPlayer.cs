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

			var lowestPlayer = players.OrderBy(t => t.Hp).First();

			return players.IndexOf(lowestPlayer);
		}
	}
}
