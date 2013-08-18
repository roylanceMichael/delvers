namespace delvers.Characters
{
	using delvers.Turns;

	public class Warrior : HumanPlayer
	{
		public Warrior(string name)
			: base(name)
		{
			this.Hp = 18;
		}
	}
}
