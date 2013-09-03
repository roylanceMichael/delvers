using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.Turns.Cards.Warrior
{
	using delvers.Characters;
	using delvers.Game;
	using delvers.Log;
	using delvers.Turns.Targetting;

	/// <summary>
	/// Instant
	/// Play when any other player takes DMG.  You each take 1/2 that damage.  You take the higher number for odd numbers.
	/// TODO: Actually make this card do what it's supposed to do.
	/// TODO: Impliment instant system.
	/// TODO: Add this to cards drawn.
	/// </summary>
	public class ShareTheLoad : DefensiveInstantCard, ICard
	{
		private readonly Warrior warriorPlayer;

		public ShareTheLoad(Warrior warriorPlayer)
		{
			this.warriorPlayer = warriorPlayer;
		}

		public string Name
		{
			get
			{
				return "Share the Load";
			}
		}

		public override bool CanUse(AttackParameters attackParameters = null)
		{
			if (attackParameters != null && attackParameters.PlayerBeingAttacked.Name != this.warriorPlayer.Name)
			{
				return true;
			}

			return false;
		}

		public void OptionalUse()
		{
			// TODO: Remove this Optional
		}

		/// <summary>
		/// Instant
		/// Play when any other player takes DMG.  You each take 1/2 that damage.  You take the higher number for odd numbers.
		/// </summary>
		public void Use(AttackParameters attackParameters = null)
		{
			if (attackParameters == null)
			{
				throw new ArgumentNullException("attackParameters");
			}

			var amountToTake = (int)(attackParameters.OriginalAmount / 2);
			this.warriorPlayer.TakeDamage(amountToTake);
			attackParameters.AdjustedAmount = attackParameters.OriginalAmount - amountToTake;
			this.warriorPlayer.UsedInstantCard = true;
			attackParameters.AddPlayerBeingAttacked(this.warriorPlayer);

			GameLogger.LogFormat("{0} used the instant defensive card {1} taking {2} hp from {3} for {4}", 
				this.warriorPlayer.Name, 
				this.Name, 
				amountToTake, 
				attackParameters.PlayerAttacking.Name,
				attackParameters.PlayerBeingAttacked.Name);
		}
	}
}
