namespace delvers.Characters
{
	using delvers.Turns;

	public class Archer : HumanPlayer
	{
		public Archer(string name, Turn turn)
			: base(name, turn)
		{
			this.Hp = 12;
		}
	}
}
