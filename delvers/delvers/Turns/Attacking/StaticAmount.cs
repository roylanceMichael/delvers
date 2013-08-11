using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Turns.Attacking
{
	public class StaticAmount : IAttackAmount
	{
		private readonly int amount;
		public StaticAmount(int amount = 2)
		{
			this.amount = amount;
		}

		public int AttackAmount()
		{
			return this.amount;
		}
	}
}
