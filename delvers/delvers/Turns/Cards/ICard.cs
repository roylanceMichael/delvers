namespace delvers.Turns.Cards
{
	using delvers.Characters;

	public interface ICard
	{
		string Name { get; }

		void OptionalUse();
		void Use();
	}
}
