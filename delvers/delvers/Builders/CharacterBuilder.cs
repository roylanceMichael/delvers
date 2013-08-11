namespace delvers.Builders
{
	using delvers.Characters;
	using delvers.Turns;
	using delvers.Turns.Attacking;
	using delvers.Turns.Targetting;

	public class CharacterBuilder
	{
		public Player BuildCharacter(string classType, string name)
		{
			var standardHumanPlayerTurn = new Turn(new RandomAmount(), new LowestHpPlayer());
			var standardMonsterTurn = new Turn(new StaticAmount(), new RandomPlayer());

			Player player;
			switch (classType.ToLower())
			{

				case "archer":
					player = new Archer(name, standardHumanPlayerTurn);
					break;
				case "cleric":
					player = new Cleric(name, standardHumanPlayerTurn);
					break;
				case "thief":
					player = new Thief(name, standardHumanPlayerTurn);
					break;
				case "paladin":
					player = new Paladin(name, standardHumanPlayerTurn);
					break;
				case "warrior":
					player = new Warrior(name, standardHumanPlayerTurn);
					break;
				case "wizard":
					player = new Wizard(name, standardHumanPlayerTurn);
					break;
				default:
					player = new Monster(name, standardMonsterTurn);
					break;
			}
			return player;
		}

	}
}
