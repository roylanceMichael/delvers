//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace delvers.Turns.Draw
//{
//	using delvers.Characters;
//	using delvers.Game;
//	using delvers.Log;
//	using delvers.Turns.Attacking;
//	using delvers.Turns.Cards;
//	using delvers.Turns.Targetting;

//	public class DrawCards
//	{
//		private readonly HumanPlayer player;
//		private readonly IBoardGame gameBoard;

//		public DrawCards(HumanPlayer player, IBoardGame gameBoard)
//		{
//			this.player = player;
//			this.gameBoard = gameBoard;
//		}

//		public void Draw()
//		{
//			if (this.player.CurrentCards.Count >= 5)
//			{
//				GameLogger.LogFormat("{0} drew no cards because they have {1} already.", this.player.Name, this.player.CurrentCards.Count);
//				return;
//			}

//			while (this.player.CurrentCards.Count < 5)
//			{
//				// draw a card from the bag
//				var attackCard = new AttackCard(this.player, gameBoard, new LowestHpPlayer(), new RandomAmount());
//				this.player.CurrentCards.Add(attackCard);
//				GameLogger.LogFormat("{0} drew {1}.", this.player.Name, attackCard.Name);
//			}
//		}
//	}
//}
