namespace delvers.Characters
{
	using delvers.Turns;

	public class Cleric : HumanPlayer
	{
		public Cleric(string name)
			: base(name)
		{
			this.Hp = 14;
			this.AttackPower = 1;
		}
	}
}
