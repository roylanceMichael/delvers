using System;
using System.Collections.Generic;

namespace delvers
{
	using delvers.Builders;
	using delvers.Characters;
	using delvers.Game;

	class Program
	{
		static void Main(string[] args)
		{
			// want to get in a state where two users are taking turns to do something
			var builder = new CharacterBuilder();

			var users = new List<Player> { 
				builder.BuildCharacter("mike", "cleric"), 
				builder.BuildCharacter("mike", "wizard"), 
				builder.BuildCharacter("monster_1", "monster"),
				builder.BuildCharacter("monster_2", "monster")};

			var boardGame = new BoardGame(users);
			boardGame.StartGame();


			Console.ReadLine();
		}
	}
}
