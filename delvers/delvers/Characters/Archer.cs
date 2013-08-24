namespace delvers.Characters
{
	using delvers.Turns;

	public class Archer : HumanPlayer
	{
		public Archer(string name)
			: base(name)
		{
			this.Hp = 12;
			this.AttackPower = 3;
            this.MagicPower = 2;
            this.DefensePower = 1;
		}
	}
}
