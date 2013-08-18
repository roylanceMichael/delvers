using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Game
{
	using delvers.Builders;
	using delvers.Characters;
	using delvers.Log;

	public class BoardGame : IBoardGame
	{
		private readonly bool addMoreMonstersUntilPlayersDie;
		public BoardGame(IList<Player> players, bool addMoreMonstersUntilPlayersDie = true)
		{
			this.Players = players;
			this.DeadMonsters = new List<Player>();
			this.addMoreMonstersUntilPlayersDie = addMoreMonstersUntilPlayersDie;
		}

		public IList<Player> Players { get; private set; }
		public IList<Player> DeadMonsters { get; private set; }

		public IEnumerable<string> StartGame()
		{
			GameLogger.ResetLog();
			var turnNumber = 1;
			
			// do while game is still in progress
			while(!this.GameEnded())
			{
				// perform turn for all users
				GameLogger.LogTurnStart(turnNumber);
				
				foreach (var player in this.Players)
				{
					player.TakeTurn(this);
				}

				// log end of turn statistics
				GameLogger.LogTurnEnd(this.Players);

				if (this.addMoreMonstersUntilPlayersDie)
				{
					this.HandleMonstersAfterTurn();
				}
				
				turnNumber++;
			}

			return GameLogger.GameLogs();
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
				this.DeadMonsters.Add(monster);
				this.Players.Remove(monster);
			}

			var characterBuilder = new CharacterBuilder();
			for (var i = 0; i < this.GetHumanPlayers().Count(); i++)
			{
				var newMonster = characterBuilder.BuildCharacter("monster", "monster_" + (this.DeadMonsters.Count + i + 1));
				this.Players.Add(newMonster);
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

		public IEnumerable<Player> GetHumanPlayers()
		{
			return 
				this.Players
				.Where(player => Utilities.Randomizer.InheritsImplementsOrIs(player.GetType(), typeof(HumanPlayer)))
				.ToList();
		}

		public IEnumerable<Player> GetMonsters()
		{
			return
						this.Players
						.Where(player => Utilities.Randomizer.InheritsImplementsOrIs( player.GetType(), typeof(Monster)))
						.ToList();
		}
	}
}
