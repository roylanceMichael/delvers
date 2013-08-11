namespace delvers.Characters
{
	using delvers.Turns;

	public class Cleric : HumanPlayer
	{
		public Cleric(string name, Turn turn)
			: base(name, turn)
		{
			this.Hp = 14;
		}
	}
}
