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

			this.DrawCardsForHumanPlayersAtBeginningOfGame();

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

				this.ResetInstantCardUsage();

				if (this.addMoreMonstersUntilPlayersDie)
				{
					this.HandleMonstersAfterTurn();
				}
				
				turnNumber++;
			}

			return GameLogger.GameLogs();
		}

		private void ResetInstantCardUsage()
		{
			// reset instants for each players
			foreach (var humanPlayer in this.GetHumanPlayers())
			{
				// ugh, will fix this. i hate casting
				((HumanPlayer)humanPlayer).UsedInstantCard = false;
			}
		}

		private void DrawCardsForHumanPlayersAtBeginningOfGame()
		{
			// have all players draw cards at the beginning of the game
			foreach (var humanPlayer in this.GetHumanPlayers())
			{
				// ugh, this indicates not a pretty design. will fix
				humanPlayer.Initialize(this);
				humanPlayer.DrawCard(this);
			}
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
			if (this.addMoreMonstersUntilPlayersDie)
			{
				return this.GetHumanPlayers().All(player => player.IsDead);
			}
			
			var monstersWin = this.GetHumanPlayers().Count(player => player.IsAttackable) == 0;
			
			if (monstersWin)
			{
				return true;
			}

			var playersWin = this.GetMonsters().Count(player => player.IsAttackable) == 0;
			return playersWin;
		}

		public IEnumerable<HumanPlayer> GetHumanPlayers()
		{
			return this.Players
				.Where(player => Utilities.Randomizer.InheritsImplementsOrIs(player.GetType(), typeof(HumanPlayer)))
				.Cast<HumanPlayer>()
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
