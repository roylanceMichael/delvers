namespace delvers.Characters
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using delvers.Turns;

	public class Player
	{
		public Player(string name, Turn turn)
		{
			this.Name = name;
			this.Turn = turn;
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
			// if a player is at 0 hit points, we don't perform any actions
			if (this.Hp == 0)
			{
				return string.Empty;
			}

			// select the players that aren't me
			var validPlayersToHit = players.Where(player => 
				player.GetType() == typeof(Monster) && 
				player.Hp > 0).ToList();

			return this.Turn.PerformTurn(validPlayersToHit, this);
		}

		public override string ToString()
		{
			return string.Format("Name: {0}, Hp: {1}", this.Name, this.Hp);
		}
	}
}
