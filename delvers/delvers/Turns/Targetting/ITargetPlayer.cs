using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Turns.Targetting
{
	using delvers.Characters;

	public interface ITargetPlayer
	{
		int TargetPlayer(IList<Player> players);
	}
}
