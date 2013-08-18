namespace delvers.Characters
{
	using delvers.Turns;

	public class Wizard : HumanPlayer
	{
		public Wizard(string name)
			: base(name)
		{
			this.Hp = 12;
		}
	}
}
