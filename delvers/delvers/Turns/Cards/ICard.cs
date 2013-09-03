namespace delvers.Turns.Cards
{
	using delvers.Characters;
	using delvers.Game;

	public interface ICard
	{
		string Name { get; }

		bool CanUse(AttackParameters attackParameters = null);

		bool IsDefensiveInstant { get; }
		bool IsOffensiveInstant { get; }

		void OptionalUse();
		void Use(AttackParameters attackParameters = null);
	}
}
