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

			if (players.Count == 0)
			{
				return -1;
			}

			return Utilities.Randomizer.GetRandomValue(0, players.Count);
		}

		public int TargetPlayer(IList<HumanPlayer> players)
		{
			if (players == null)
			{
				throw new ArgumentNullException("players");
			}

			if (players.Count == 0)
			{
				return -1;
			}

			return Utilities.Randomizer.GetRandomValue(0, players.Count);
		}
	}
}
