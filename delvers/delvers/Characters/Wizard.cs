namespace delvers.Characters
{
	using System.Collections.Generic;
	using System.Linq;

	using delvers.Game;
	using delvers.Log;
	using delvers.Turns;
	using delvers.Turns.Cards;
	using delvers.Turns.Cards.Warrior;
	using delvers.Turns.Targetting;
	using delvers.Utilities;

	public class Wizard : HumanPlayer
	{
		public Wizard(string name)
			: base(name)
		{
			this.Hp = 12;
			this.AttackPower = 2;
			this.MagicPower = 3;
			this.DefensePower = 1;
		}

		public override void DrawCard(IBoardGame gameBoard)
		{
			if (!this.DoneInitialization)
			{
				this.InitializeCards(gameBoard);
			}

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
					this.CardsToDrawFrom.Remove(firstCard);
					this.DrawnCards.Add(firstCard);
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

		private void InitializeCards(IBoardGame gameBoard)
		{
			for (var i = 0; i < 4; i++)
			{
				var card = new DrainLife(this, gameBoard, new LowestHpPlayer());
				this.CardsToDrawFrom.Add(card);
			}

			this.DoneInitialization = true;
		}
	}
}
