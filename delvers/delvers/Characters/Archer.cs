namespace delvers.Characters
{
	using delvers.Turns;

	public class Archer : HumanPlayer
	{
		public Archer(string name)
			: base(name)
		{
			this.Hp = 12;
		}
	}
}
