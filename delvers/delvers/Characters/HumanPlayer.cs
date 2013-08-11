using System.Collections.Generic;
using System.Linq;

namespace delvers.Characters
{
	using delvers.Turns;

	public class HumanPlayer : Player
	{
		public HumanPlayer(string name, Turn turn)
			: base(name, turn)
		{
		}

		public override string TakeTurn(IList<Player> players)
		{
			if (!this.CanTakeTurn)
			{
				return string.Empty;
			}

			// select the players that aren't me
			return this.Turn.PerformTurn(FilterAttackablePlayers<Monster>(players), this);
		}
	}
}
