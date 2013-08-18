using System.Collections.Generic;
using System.Linq;

namespace delvers.Characters
{
	using delvers.Game;
	using delvers.Turns;
	using delvers.Turns.Cards;
	using delvers.Turns.Cleanup;
	using delvers.Turns.Discard;
	using delvers.Turns.Draw;
	using delvers.Utilities;

	public class HumanPlayer : Player
	{
		public HumanPlayer(string name)
			: base(name)
		{
			this.Cards = new List<ICard>();
		}

		public IList<ICard> Cards { get; private set; } 

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
			var drawCards = new DrawCards(this, gameBoard);
			drawCards.Draw();

			// use a card
			var randCardIdx = Randomizer.GetRandomValue(0, this.Cards.Count - 1);
			var card = this.Cards[randCardIdx];
			card.Use();
			this.Cards.RemoveAt(randCardIdx);

			// cleanup
			var cleanupTurn = new CleanupTurn(this);
			cleanupTurn.Cleanup();
		}
	}
}
