using System.Collections.Generic;

namespace delvers.Characters
{
	using delvers.Game;
	using delvers.Turns.Cards;
	using delvers.Turns.Cleanup;
	using delvers.Turns.Discard;
	using delvers.Utilities;

	public class HumanPlayer : Player
	{
		public HumanPlayer(string name)
			: base(name)
		{
			this.CurrentCards = new List<ICard>();
			this.DrawnCards = new List<ICard>();
			this.CardsToDrawFrom = new List<ICard>();
		}

		public IList<ICard> CardsToDrawFrom { get; private set; }

		public IList<ICard> DrawnCards { get; private set; } 

		public IList<ICard> CurrentCards { get; private set; }

		public int AttackPower { get; set; }

		public override void TakeTurn(IBoardGame gameBoard)
		{
			if (!this.CanTakeTurn)
			{
				return;
			}

			// perform discard cards
			var discardCards = new DiscardCards(this);
			discardCards.Discard();

			// perform draw
			this.DrawCard(gameBoard);

			// use a card
			var randCardIdx = Randomizer.GetRandomValue(0, this.CurrentCards.Count - 1);
			var card = this.CurrentCards[randCardIdx];
			card.Use();
			this.CurrentCards.RemoveAt(randCardIdx);

			// cleanup
			var cleanupTurn = new CleanupTurn(this);
			cleanupTurn.Cleanup();
		}

		public virtual void DrawCard(IBoardGame gameBoard)
		{
			
		}
	}
}
