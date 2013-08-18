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
			Player player;
			switch (classType.ToLower())
			{

				case "archer":
					player = new Archer(name);
					break;
				case "cleric":
					player = new Cleric(name);
					break;
				case "thief":
					player = new Thief(name);
					break;
				case "paladin":
					player = new Paladin(name);
					break;
				case "warrior":
					player = new Warrior(name);
					break;
				case "wizard":
					player = new Wizard(name);
					break;
				default:
					player = new Monster(name);
					break;
			}
			return player;
		}

	}
}
