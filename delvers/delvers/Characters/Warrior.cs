namespace delvers.Characters
{
	using delvers.Turns;

	public class Warrior : HumanPlayer
	{
		public Warrior(string name, Turn turn)
			: base(name, turn)
		{
			this.Hp = 18;
		}
	}
}
