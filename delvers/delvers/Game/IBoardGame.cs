using System.Collections.Generic;

namespace delvers.Game
{
	using delvers.Characters;

	public interface IBoardGame
	{
		IList<Player> Players { get; }
		IList<Player> DeadMonsters { get; }

		IEnumerable<string> StartGame();
		bool GameEnded();
		IEnumerable<HumanPlayer> GetHumanPlayers();
		IEnumerable<Player> GetMonsters();
	}
}
