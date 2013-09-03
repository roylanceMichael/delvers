using System.Collections.Generic;

namespace delvers.Characters
{
	using System.Linq;

	using delvers.Game;
	using delvers.Turns.Cards;
	using delvers.Turns.Cleanup;
	using delvers.Turns.Discard;
	using delvers.Utilities;

	public class HumanPlayer : Player
	{
		protected bool DoneInitialization;

		internal HumanPlayer(string name)
			: base(name)
		{
			this.CurrentCards = new List<ICard>();
			this.DrawnCards = new List<ICard>();
			this.CardsToDrawFrom = new List<ICard>();
			this.DoneInitialization = false;
		}

		public bool UsedInstantCard { get; set; }

		public IList<ICard> CardsToDrawFrom { get; private set; }

		public IList<ICard> DrawnCards { get; private set; }

		public IList<ICard> CurrentCards { get; private set; }

		public int AttackPower { get; set; }

		public int MagicPower { get; set; }

		public int DefensePower { get; set; }

		public override void TakeDamage(IBoardGame gameBoard, AttackParameters attackParameters)
		{
			var humanPlayers = gameBoard.GetHumanPlayers();

			// all of them will play defensive cards
			foreach (var humanPlayer in humanPlayers)
			{
				var defensiveInstant = humanPlayer.CurrentCards.FirstOrDefault(card => card.IsDefensiveInstant);
				if (defensiveInstant != null && !humanPlayer.UsedInstantCard && defensiveInstant.CanUse(attackParameters))
				{
					defensiveInstant.Use(attackParameters);
					humanPlayer.CurrentCards.Remove(defensiveInstant);
				}
			}

			// we'll take damage here
			base.TakeDamage(gameBoard, attackParameters);
		}

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

			if (this.CurrentCards.Any())
			{
				// use a card that's not defensive
				var nonDefensiveInstantCards = this.CurrentCards.Where(card1 => !card1.IsDefensiveInstant).ToList();
				var randCardIdx = Randomizer.GetRandomValue(0, nonDefensiveInstantCards.Count() - 1);
				var card = nonDefensiveInstantCards.ElementAt(randCardIdx);
				card.Use();
				this.CurrentCards.RemoveAt(randCardIdx);
			}

			// cleanup
			var cleanupTurn = new CleanupTurn(this);
			cleanupTurn.Cleanup();
		}

		public virtual void DrawCard(IBoardGame gameBoard)
		{

		}

		public virtual void Initialize(IBoardGame gameBoard)
		{
			
		}
	}
}
