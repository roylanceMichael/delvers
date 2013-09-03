namespace delvers.Characters
{
	using delvers.Turns;

	public class Cleric : HumanPlayer
	{
		internal Cleric(string name)
			: base(name)
		{
			this.Hp = 14;
			this.AttackPower = 1;
            this.MagicPower = 3;
            this.DefensePower = 2;
		}
	}
}
