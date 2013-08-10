namespace delvers.Builders
{
	using delvers.Characters;
	using delvers.Turns;

	public class CharacterBuilder
	{
		public Player BuildCharacter(string classType, string name)
		{
			var turn = new AttackOtherPlayersForRandomAmount();
			Player player;
			switch (classType.ToLower())
			{

				case "archer":
					player = new Archer(name, turn);
					break;
				case "cleric":
					player = new Cleric(name, turn);
					break;
				case "thief":
					player = new Thief(name, turn);
					break;
				case "paladin":
					player = new Paladin(name, turn);
					break;
				case "warrior":
					player = new Warrior(name, turn);
					break;
				case "wizard":
					player = new Wizard(name, turn);
					break;
				default:
					player = new Monster(name, turn);
					break;
			}
			return player;
		}

	}
}
