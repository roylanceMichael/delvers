using System;
using System.Collections.Generic;

namespace delvers.Turns.Targetting
{
	using delvers.Characters;

	public class RandomPlayer : ITargetPlayer
	{
		public int TargetPlayer(IList<Player> players)
		{
			if (players == null)
			{
				throw new ArgumentNullException("players");
			}

			return Utilities.Randomizer.GetRandomValue(0, players.Count);
		}
	}
}
