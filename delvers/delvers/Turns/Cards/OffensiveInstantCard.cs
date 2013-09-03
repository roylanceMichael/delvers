using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Turns.Cards
{
	using delvers.Game;

	public class OffensiveInstantCard
	{
		public bool IsDefensiveInstant
		{
			get
			{
				return false;
			}
		}

		public bool IsOffensiveInstant
		{
			get
			{
				return true;
			}
		}

		public virtual bool CanUse(AttackParameters attackParameters = null)
		{
			return true;
		}
	}
}
