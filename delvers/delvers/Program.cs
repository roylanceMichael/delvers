using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers
{
	using delvers.Characters;
	using delvers.Game;
	using delvers.Turns;

	class Program
	{
		static void Main(string[] args)
		{
			// want to get in a state where two users are taking turns to do something
			var users = new List<Player> { 
				new Warrior("Mike", new AttackOtherPlayersForRandomAmount()), 
				new Wizard("Jeff", new AttackOtherPlayersForRandomAmount()), 
				new Monster("Monster1", new AttackOtherPlayersForRandomAmount()),
				new Monster("Monster2", new AttackOtherPlayersForRandomAmount()),
				new Monster("Monster3", new AttackOtherPlayersForRandomAmount()),
				new Monster("Monster4", new AttackOtherPlayersForRandomAmount()),
				new Monster("Monster5", new AttackOtherPlayersForRandomAmount())};

			var boardGame = new BoardGame(users);
			boardGame.StartGame();


			Console.ReadLine();
		}
	}
}
