﻿using System.Collections.Generic;
using System.Linq;

namespace delvers.Characters
{
	using delvers.Turns;

	public class Monster : Player
	{
		public Monster(string name, Turn turn)
			: base(name, turn)
		{
			this.Hp = Utilities.Randomizer.GetRandomValue(15, 17);
		}

		public override string TakeTurn(IList<Player> players)
		{
			if (!this.CanTakeTurn)
			{
				return string.Empty;
			}

			return this.Turn.PerformTurn(FilterAttackablePlayers<HumanPlayer>(players), this);
		}
	}
}
