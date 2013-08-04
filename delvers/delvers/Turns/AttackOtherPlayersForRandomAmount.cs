using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Turns
{
	using delvers.Characters;

	public class AttackOtherPlayersForRandomAmount : Turn
	{
		public override void PerformTurn(IList<Player> players, Player performingPlayer)
		{
			// pick a random player
			if (!players.Any())
			{
				return;
			}

			var randomIdx = Utilities.Randomizer.GetRandomValue(0, players.Count);

			var randomAttack = Utilities.Randomizer.GetRandomAttackValue();

			Console.WriteLine("\t{0} was attacked for {1} by {2}!!!!!", 
				players[randomIdx].Name, 
				randomAttack, 
				performingPlayer.Name);
			players[randomIdx].TakeDamage(randomAttack);
		}
	}
}
