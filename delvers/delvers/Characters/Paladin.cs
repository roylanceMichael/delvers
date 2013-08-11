namespace delvers.Characters
{
	using delvers.Turns;

	public class Paladin : HumanPlayer
	{
		public Paladin(string name, Turn turn)
			: base(name, turn)
		{
			this.Hp = 18;
		}
	}
}
