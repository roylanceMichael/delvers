using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Game
{
	using delvers.Characters;

	public class AttackParameters
	{
		private readonly List<Player> additionalPlayersBeingAttacked = new List<Player>();
 
		public Player PlayerBeingAttacked { get; set; }
		
		public Player PlayerAttacking { get; set; }

		public int OriginalAmount { get; set; }

		public int AdjustedAmount { get; set; }

		public void AddPlayerBeingAttacked(Player player)
		{
			this.additionalPlayersBeingAttacked.Add(player);
		}

		public string ReportPlayersBeingAttacked()
		{
			var tmpArray = new List<Player> { this.PlayerBeingAttacked };
			tmpArray.AddRange(this.additionalPlayersBeingAttacked);

			return string.Join(",", tmpArray.Select(player => player.Name));
		}
	}
}
