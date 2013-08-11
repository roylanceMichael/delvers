using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Turns.Attacking
{
	public class RandomAmount : IAttackAmount
	{
		private readonly int lowestAmount;

		private readonly int highestAmount;

		public RandomAmount(int lowestAmount = 4, int highestAmount = 6)
		{
			this.lowestAmount = lowestAmount;
			this.highestAmount = highestAmount;
		}

		public int AttackAmount()
		{
			return Utilities.Randomizer.GetRandomValue(this.lowestAmount, this.highestAmount);
		}
	}
}
