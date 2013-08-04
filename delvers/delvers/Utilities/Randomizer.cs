using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Utilities
{
	public static class Randomizer
	{
		private static readonly Random Random = new Random();

		public static int GetRandomHp()
		{
			return Random.Next(4, 6);
		}

		public static int GetRandomAttackValue()
		{
			return Random.Next(2, 6);
		}

		public static int GetRandomValue(int start, int end)
		{
			return Random.Next(start, end);
		}
	}
}
