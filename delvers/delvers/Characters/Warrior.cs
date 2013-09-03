namespace delvers.Characters
{
	using System.Linq;

	using delvers.Game;
	using delvers.Log;
	using delvers.Turns.Cards.Warrior;
	using delvers.Turns.Targetting;
	using delvers.Utilities;

	public class Warrior : HumanPlayer
	{
		internal Warrior(string name)
			: base(name)
		{
			this.Hp = 18;
			this.AttackPower = 2;
			this.MagicPower = 1;
			this.DefensePower = 3;
			this.Rage = 0;
		}

		public int Rage { get; set; }

		public override void TakeDamage(IBoardGame gameBoard, AttackParameters attackParameters)
		{
			base.TakeDamage(gameBoard, attackParameters);
			this.Rage += 1;
		}

		public override void DrawCard(IBoardGame gameBoard)
		{
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

		public override void Initialize(IBoardGame gameBoard)
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

			for (var i = 0; i < 3; i++)
			{
				var card = new DefensiveStrike(this, gameBoard, new LowestHpPlayer());
				this.CardsToDrawFrom.Add(card);
			}

			for (var i = 0; i < 3; i++)
			{
				var card = new MagicDefense(this, gameBoard, new LowestHpPlayer());
				this.CardsToDrawFrom.Add(card);
			}

			for (var i = 0; i < 6; i++)
			{
				var card = new SwordAttack(this, gameBoard, new LowestHpPlayer());
				this.CardsToDrawFrom.Add(card);
			}

			for (var i = 0; i < 1; i++)
			{
				var card = new IntoTheFray(this, gameBoard, new LowestHpPlayer());
				this.CardsToDrawFrom.Add(card);
			}

			for (var i = 0; i < 6; i++)
			{
				var card = new Cleave(this, gameBoard, new LowestHpPlayer());
				this.CardsToDrawFrom.Add(card);
			}

			for (var i = 0; i < 6; i++)
			{
				var card = new SwordSlash(this, gameBoard, new LowestHpPlayer());
				this.CardsToDrawFrom.Add(card);
			}

			for (var i = 0; i < 6; i++)
			{
				var card = new ShieldBash(this, gameBoard, new LowestHpPlayer());
				this.CardsToDrawFrom.Add(card);
			}

			for (var i = 0; i < 1; i++)
			{
				var card = new HeavyBlow(this, gameBoard, new LowestHpPlayer());
				this.CardsToDrawFrom.Add(card);
			}

			for (var i = 0; i < 3; i++)
			{
				var card = new ShareTheLoad(this);
				this.CardsToDrawFrom.Add(card);
			}
		}
	}
}
