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

	public class Warrior : HumanPlayer
	{
		public Warrior(string name)
			: base(name)
		{
			this.Hp = 18;
			this.AttackPower = 2;
            this.MagicPower = 1;
            this.DefensePower = 3;
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

			while (this.CurrentCards.Count < 5)
			{
				// select from the list of cards to draw from
				if (this.CardsToDrawFrom.Any())
				{
					var randCardIdx = Randomizer.GetRandomValue(0, this.CardsToDrawFrom.Count - 1);
					var firstCard = this.CardsToDrawFrom[randCardIdx];

					GameLogger.LogFormat("{0} drew {1}.", this.Name, firstCard.Name);
					this.CurrentCards.Add(firstCard);
					this.CardsToDrawFrom.Remove(firstCard);
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
			}
		}

		private void InitializeCards(IBoardGame gameBoard)
		{
			for (var i = 0; i < 5; i++)
			{
				var card = new RejuvenatingStrike(this, gameBoard, new LowestHpPlayer());
				this.CardsToDrawFrom.Add(card);
			}

			for (var i = 0; i < 3; i++)
			{
				var card = new MockingBlow(this, gameBoard, new LowestHpPlayer());
				this.CardsToDrawFrom.Add(card);
			}

			this.DoneInitialization = true;
		}
	}
}
