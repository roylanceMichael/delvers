using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Game
{
	using delvers.Builders;
	using delvers.Characters;

	public class BoardGame
	{
		private readonly List<Player> players;
		private readonly List<Player> deadMonsters;

		public BoardGame(List<Player> players)
		{
			this.players = players;
			this.deadMonsters = new List<Player>();
		}

		public IEnumerable<string> StartGame()
		{
			var log = new List<string>();
			var turnNumber = 1;
			
			// do while game is still in progress
			while(!this.GameEnded())
			{
				// perform turn for all users
				log.Add("--- TURN " + turnNumber + " ---");
				log.AddRange(this.players.Select(player => player.TakeTurn(this.players)));
				log.Add("-");
				log.AddRange(this.players.Select(player => player.ToString()));

				this.HandleMonstersAfterTurn();

				turnNumber++;
			}

			return log;
		}

		private void HandleMonstersAfterTurn()
		{
			// if there aren't any more monsters left
			var aliveMonsters = this.GetMonsters().Where(monster => !monster.IsDead).ToList();

			if (aliveMonsters.Any())
			{
				return;
			}

			// remove all monsters from list
			foreach (var monster in this.GetMonsters())
			{
				this.deadMonsters.Add(monster);
				this.players.Remove(monster);
			}

			var characterBuilder = new CharacterBuilder();
			for (var i = 0; i < this.GetHumanPlayers().Count(); i++)
			{
				var newMonster = characterBuilder.BuildCharacter("monster", "monster_" + (this.deadMonsters.Count + i + 1));
				this.players.Add(newMonster);
			}
		}

		/// <summary>
		/// game ends when human players have no more health left
		/// </summary>
		/// <returns></returns>
		public bool GameEnded()
		{
			return this.GetHumanPlayers().All(player => player.IsDead);
		}

		private IEnumerable<Player> GetHumanPlayers()
		{
			return 
				this.players
				.Where(player => Utilities.Randomizer.InheritsImplementsOrIs(player.GetType(), typeof(HumanPlayer)))
				.ToList();
		}

		private IEnumerable<Player> GetMonsters()
		{
			return
						this.players
						.Where(player => Utilities.Randomizer.InheritsImplementsOrIs( player.GetType(), typeof(Monster)))
						.ToList();
		}
	}
}
