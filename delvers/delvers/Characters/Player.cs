namespace delvers.Characters
{
	using System.Collections.Generic;
	using System.Linq;

	using delvers.Utilities;
	using delvers.Turns;

	public class Player
	{
		public Player(string name, Turn turn)
		{
			this.Name = name;
			this.Turn = turn;
		}

		protected static IList<Player> FilterAttackablePlayers<T>(IList<Player> players) where T: class 
		{
			return players
				.Where(player => player.GetType().InheritsImplementsOrIs(typeof(T)) &&
													player.IsAttackable)
				.ToList();
		}

		public string Name { get; private set; }

		public int Hp { get; protected set; }

		public Turn Turn { get; private set; }

		public void TakeDamage(int healthToSubtract)
		{
			if (this.Hp - healthToSubtract < 0)
			{
				this.Hp = 0;
			}
			else
			{
				this.Hp = this.Hp - healthToSubtract;
			}
		}

		public virtual string TakeTurn(IList<Player> players)
		{
			return string.Empty;
		}

		public bool CanTakeTurn
		{
			get
			{
				return this.Hp > 0;
			}
		}

		public bool IsAttackable
		{
			get
			{
				return this.Hp > 0;
			}
		}

		public bool IsDead
		{
			get
			{
				return this.Hp == 0;
			}
		}

		public override string ToString()
		{
			return string.Format("Name: {0}, Hp: {1}", this.Name, this.Hp);
		}
	}
}
