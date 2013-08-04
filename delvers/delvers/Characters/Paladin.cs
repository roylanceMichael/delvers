﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Characters
{
	using delvers.Turns;

	public class Paladin : Player
	{
		public Paladin(string name, Turn turn)
			: base(name, turn)
		{
			this.Hp = 18;
		}
	}
}
