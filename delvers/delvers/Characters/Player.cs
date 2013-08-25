namespace delvers.Characters
{
	using System.Collections.Generic;
	using System.Linq;

	using delvers.Game;
	using delvers.Utilities;
	using delvers.Turns;

	public class Player
	{
		public Player(string name)
		{
			this.Name = name;
		}

		protected static IList<Player> FilterAttackablePlayers<T>(IList<Player> players) where T : class
		{
			return players.Where(player => player.GetType().InheritsImplementsOrIs(typeof(T)) && player.IsAttackable).ToList();
		}

		public string Name { get; private set; }

		public int Hp { get; protected set; }

		public virtual void TakeDamage(int healthToSubtract)
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

		public virtual void TakeTurn(IBoardGame boardGame)
		{
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
