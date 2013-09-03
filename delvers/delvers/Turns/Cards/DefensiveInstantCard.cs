using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Turns.Cards
{
	using delvers.Game;

	public class DefensiveInstantCard
	{
		public bool IsDefensiveInstant
		{
			get
			{
				return true;
			}
		}

		public bool IsOffensiveInstant
		{
			get
			{
				return false;
			}
		}

		public virtual bool CanUse(AttackParameters attackParameters = null)
		{
			return true;
		}
	}
}
