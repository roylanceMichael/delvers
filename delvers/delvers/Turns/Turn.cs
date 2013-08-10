using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Turns
{
	using delvers.Characters;

	public abstract class Turn
	{
		public abstract string PerformTurn(IList<Player> players, Player performingPlayer);
	}
}
