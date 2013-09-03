using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delvers.tests.InstantCardSystem.Warrior
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using delvers.Builders;
	using delvers.Characters;
	using delvers.Game;
	using delvers.Turns.Cards.Warrior;

	[TestClass]
	public class ShareTheLoadTests
	{
		[TestMethod]
		public void WarriorTakesDamageWhenOtherHumanPlayerIsHitFromMonster()
		{
			// arrange
			var builder = new CharacterBuilder();
			var cleric = (Cleric)builder.BuildCharacter("cleric", "TestUser1");
			var warrior = (Warrior)builder.BuildCharacter("warrior", "TestUser");
			var monster = builder.BuildCharacter("monster", "TestMonster");

			var gameBoard = new BoardGame(new List<Player> { warrior, monster, cleric }, false);
			warrior.Initialize(gameBoard);
			cleric.Initialize(gameBoard);

			var shareTheLoadCard = warrior.CardsToDrawFrom.First(card => card.GetType() == typeof(ShareTheLoad));
			warrior.CurrentCards.Add(shareTheLoadCard);
			warrior.CardsToDrawFrom.Remove(shareTheLoadCard);

			var healthBefore = cleric.Hp;
			var attackParameters = new AttackParameters
															 {
																 AdjustedAmount = 4,
																 OriginalAmount = 4,
																 PlayerAttacking = monster,
																 PlayerBeingAttacked = cleric
															 };
			// act
			cleric.TakeDamage(gameBoard, attackParameters);

			// assert
			Assert.AreEqual(healthBefore - 2, cleric.Hp);
		}

		[TestMethod]
		public void WarriorTakesDoesNotUseInstantCardWhenTakenDamageAndHasShareTheLoad()
		{
			// arrange
			var builder = new CharacterBuilder();
			var cleric = (Cleric)builder.BuildCharacter("cleric", "TestUser1");
			var warrior = (Warrior)builder.BuildCharacter("warrior", "TestUser");
			var monster = builder.BuildCharacter("monster", "TestMonster");

			var gameBoard = new BoardGame(new List<Player> { warrior, monster, cleric }, false);
			warrior.Initialize(gameBoard);
			cleric.Initialize(gameBoard);

			var shareTheLoadCard = warrior.CardsToDrawFrom.First(card => card.GetType() == typeof(ShareTheLoad));
			warrior.CurrentCards.Add(shareTheLoadCard);
			warrior.CardsToDrawFrom.Remove(shareTheLoadCard);

			Assert.IsFalse(warrior.UsedInstantCard);
			var warriorHp = warrior.Hp;
			var attackParameters = new AttackParameters
			{
				AdjustedAmount = 4,
				OriginalAmount = 4,
				PlayerAttacking = monster,
				PlayerBeingAttacked = cleric
			};

			// act
			warrior.TakeDamage(gameBoard, attackParameters);

			// assert
			Assert.IsFalse(warrior.UsedInstantCard);
			Assert.AreEqual(warriorHp - 4, warrior.Hp);
		}

		[TestMethod]
		public void ShareTheLoadIsNotRemovedWhenDefensiveInstantCardNotUsedOnSelf()
		{
			// arrange
			var builder = new CharacterBuilder();
			var cleric = (Cleric)builder.BuildCharacter("cleric", "TestUser1");
			var warrior = (Warrior)builder.BuildCharacter("warrior", "TestUser");
			var monster = builder.BuildCharacter("monster", "TestMonster");

			var gameBoard = new BoardGame(new List<Player> { warrior, monster, cleric }, false);
			warrior.Initialize(gameBoard);
			cleric.Initialize(gameBoard);

			var shareTheLoadCard = warrior.CardsToDrawFrom.First(card => card.GetType() == typeof(ShareTheLoad));
			warrior.CurrentCards.Add(shareTheLoadCard);
			warrior.CardsToDrawFrom.Remove(shareTheLoadCard);

			Assert.IsFalse(warrior.UsedInstantCard);
			Assert.AreEqual(1, warrior.CurrentCards.Count);
			var warriorHp = warrior.Hp;
			var attackParameters = new AttackParameters
			{
				AdjustedAmount = 4,
				OriginalAmount = 4,
				PlayerAttacking = monster,
				PlayerBeingAttacked = cleric
			};

			// act
			warrior.TakeDamage(gameBoard, attackParameters);

			// assert
			Assert.IsFalse(warrior.UsedInstantCard);
			Assert.AreEqual(warriorHp - 4, warrior.Hp);
			Assert.AreEqual(1, warrior.CurrentCards.Count);
		}
	}
}
