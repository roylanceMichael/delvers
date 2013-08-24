namespace delvers.Characters
{
	using delvers.Turns;

	public class Paladin : HumanPlayer
	{
		public Paladin(string name)
			: base(name)
		{
			this.Hp = 18;
			this.AttackPower = 1;
            this.MagicPower = 2;
            this.DefensePower = 3;
		}
	}
}
