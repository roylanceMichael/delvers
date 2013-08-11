namespace delvers.Characters
{
	using delvers.Turns;

	public class Thief : HumanPlayer
	{
		public Thief(string name, Turn turn)
			: base(name, turn)
		{
			this.Hp = 14;
		}
	}
}
