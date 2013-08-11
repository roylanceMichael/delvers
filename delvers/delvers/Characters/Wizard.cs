namespace delvers.Characters
{
	using delvers.Turns;

	public class Wizard : HumanPlayer
	{
		public Wizard(string name, Turn turn)
			: base(name, turn)
		{
			this.Hp = 12;
		}
	}
}
