using System.Linq;

namespace delvers.Turns.Cards
{
	using delvers.Characters;
	using delvers.Game;
	using delvers.Log;
	using delvers.Turns.Attacking;
	using delvers.Turns.Targetting;

	public class AttackCard : ICard
	{
		private readonly HumanPlayer player;
		private readonly IBoardGame gameBoard;
		private readonly ITargetPlayer targetPlayer;
		private readonly IAttackAmount attackAmount;

		public AttackCard(HumanPlayer player, IBoardGame gameBoard, ITargetPlayer targetPlayer, IAttackAmount attackAmount)
		{
			this.player = player;
			this.gameBoard = gameBoard;
			this.targetPlayer = targetPlayer;
			this.attackAmount = attackAmount;
		}

		public string Name
		{
			get
			{
				return "Attack";
			}
		}

		public void Use()
		{
			var monsters = this.gameBoard.GetMonsters().ToList();
			var monsterIdx = this.targetPlayer.TargetPlayer(monsters);
			
			if (monsterIdx < 0)
			{
				return;
			}

			var monster = monsters[monsterIdx];
			var damageTaken = this.attackAmount.AttackAmount();
			
			monster.TakeDamage(damageTaken);

			GameLogger.LogFormat("{0} gave {1} damage to {2}", this.player.Name, damageTaken, monster.Name);
		}
	}
}
