﻿namespace delvers.Characters
{
	using System.Collections.Generic;
	using System.Linq;

	using delvers.Game;
	using delvers.Log;
	using delvers.Turns;
	using delvers.Turns.Cards;
	using delvers.Turns.Cards.Wizard;
	using delvers.Turns.Targetting;
	using delvers.Utilities;

	public class Wizard : HumanPlayer
	{
		internal Wizard(string name)
			: base(name)
		{
			this.Hp = 12;
			this.AttackPower = 2;
			this.MagicPower = 3;
			this.DefensePower = 1;
		}

		public override void DrawCard(IBoardGame gameBoard)
		{
			if (CurrentCards.Count > 4)
			{
				GameLogger.LogFormat("{0} drew no cards because they have {1} already.", this.Name, this.CurrentCards.Count);
				return;
			}

			var iter = 0;
			while (this.CurrentCards.Count < 5 && iter < 5)
			{
				// select from the list of cards to draw from
				if (this.CardsToDrawFrom.Any())
				{
					var randCardIdx = Randomizer.GetRandomValue(0, this.CardsToDrawFrom.Count - 1);
					var firstCard = this.CardsToDrawFrom[randCardIdx];

					GameLogger.LogFormat("{0} drew {1}.", this.Name, firstCard.Name);
					this.CurrentCards.Add(firstCard);
				}
				else
				{
					// reshuffle
					foreach (var card in this.DrawnCards)
					{
						this.CardsToDrawFrom.Add(card);
					}

					this.DrawnCards.Clear();
				}

				iter++;
			}
		}

		public override void Initialize(IBoardGame gameBoard)
		{
			for (var i = 0; i < 4; i++)
			{
				var card = new DrainLife(this, gameBoard, new LowestHpPlayer());
				this.CardsToDrawFrom.Add(card);
			}

			for (var i = 0; i < 6; i++)
			{
				var card = new MagicMissile(this, gameBoard, new LowestHpPlayer());
				this.CardsToDrawFrom.Add(card);
			}

			for (var i = 0; i < 6; i++)
			{
				var card = new DragonFlame(this, gameBoard, new LowestHpPlayer());
				this.CardsToDrawFrom.Add(card);
			}

			for (var i = 0; i < 3; i++)
			{
				var card = new FrostBolt(this, gameBoard, new LowestHpPlayer());
				this.CardsToDrawFrom.Add(card);
			}

			for (var i = 0; i < 6; i++)
			{
				var card = new SurefireShot(this, gameBoard, new LowestHpPlayer());
				this.CardsToDrawFrom.Add(card);
			}

			for (var i = 0; i < 3; i++)
			{
				var card = new LightningBolt(this, gameBoard, new LowestHpPlayer());
				this.CardsToDrawFrom.Add(card);
			}

			for (var i = 0; i < 6; i++)
			{
				var card = new ColdSnap(this, gameBoard, new LowestHpPlayer());
				this.CardsToDrawFrom.Add(card);
			}

			for (var i = 0; i < 1; i++)
			{
				var card = new FireBall(this, gameBoard, new LowestHpPlayer());
				this.CardsToDrawFrom.Add(card);
			}

			for (var i = 0; i < 1; i++)
			{
				var card = new BallOfForce(this, gameBoard, new LowestHpPlayer());
				this.CardsToDrawFrom.Add(card);
			}
		}
	}
}
