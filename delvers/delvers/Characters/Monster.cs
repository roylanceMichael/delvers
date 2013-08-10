using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Characters
{
	using delvers.Turns;

	public class Monster : Player
	{
		public Monster(string name, Turn turn)
			: base(name, turn)
		{
			this.Hp = Utilities.Randomizer.GetRandomHp();
		}

		public override string TakeTurn(IList<Player> players)
		{
			if (this.Hp < 0)
			{
				return string.Empty;
			}

			// get list of valid people to attack
			var playersToAttack = players.Where(t => 
				t.GetType() != typeof(Monster) &&
				t.Hp > 0).ToList();
			return this.Turn.PerformTurn(playersToAttack, this);
		}
	}
}
