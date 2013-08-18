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
				builder.BuildCharacter("cleric", "mike"), 
				builder.BuildCharacter("wizard", "jeff"), 
				builder.BuildCharacter("monster", "monster_1"),
				builder.BuildCharacter("monster", "monster_2")};

			var boardGame = new BoardGame(users);
			var logs = boardGame.StartGame();

			foreach (var log in logs)
			{
				Console.WriteLine(log);
			}

			Console.ReadLine();
		}
	}
}
