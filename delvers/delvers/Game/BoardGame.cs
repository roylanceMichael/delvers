using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Game
{
	using delvers.Characters;

	public class BoardGame
	{
		private readonly List<Player> players;
		public BoardGame(List<Player> players)
		{
			this.players = players;
		}

		public IEnumerable<string> StartGame()
		{
			var log = new List<string>();
			// do while game is still in progress
			for (var i = 1; i < 6; i++)
			{
				// perform turn for all users
				log.AddRange(this.players.Select(player => player.TakeTurn(this.players)));
				log.AddRange(this.players.Select(player => player.ToString()));
			}

			return log;
		}
	}
}
