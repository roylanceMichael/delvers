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

		public void StartGame()
		{
			// do while game is still in progress
			for (var i = 1; i < 6; i++)
			{
				// perform turn for all users
				foreach (var player in this.players)
				{
					player.TakeTurn(this.players);
				}

				var reportPlayerStatus = new StringBuilder();
				foreach (var player in this.players)
				{
					reportPlayerStatus.AppendLine(player.ToString());
				}
				Console.WriteLine(reportPlayerStatus.ToString());
			}
		}
	}
}
