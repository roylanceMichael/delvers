using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Game
{
	using delvers.Characters;

	public interface IBoardGame
	{
		IList<Player> Players { get; }
		IList<Player> DeadMonsters { get; }

		IEnumerable<string> StartGame();
		bool GameEnded();
		IEnumerable<Player> GetHumanPlayers();
		IEnumerable<Player> GetMonsters();
	}
}
