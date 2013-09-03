namespace delvers.Characters
{
	using delvers.Turns;

	public class Thief : HumanPlayer
	{
		internal Thief(string name)
			: base(name)
		{
			this.Hp = 14;
			this.AttackPower = 3;
            this.MagicPower = 1;
            this.DefensePower = 2;
		}
	}
}
