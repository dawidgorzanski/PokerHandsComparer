using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHandsComparer.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void BuilderShouldBuildCorrectCards()
        {
            var possibleCardRanks = Enum.GetValues<CardRank>();
            var cardBuilderProperties = Card.Clubs.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty);
            foreach (var cardRank in possibleCardRanks)
            {
                var builderProperty = cardBuilderProperties.First(p => p.Name == cardRank.ToString());
                AssertCardIsCorrect(builderProperty.GetValue(Card.Clubs) as Card, CardSuit.Clubs, cardRank);
                AssertCardIsCorrect(builderProperty.GetValue(Card.Diamonds) as Card, CardSuit.Diamonds, cardRank);
                AssertCardIsCorrect(builderProperty.GetValue(Card.Hearts) as Card, CardSuit.Hearts, cardRank);
                AssertCardIsCorrect(builderProperty.GetValue(Card.Spades) as Card, CardSuit.Spades, cardRank);
            }
        }

        [TestMethod]
        public void CardsShouldBeEqualWhenBothSuitAndRankAreTheSame()
        {
            var card1 = new Card(CardSuit.Spades, CardRank.Ace);
            var card2 = new Card(CardSuit.Spades, CardRank.Ace);
            Assert.IsTrue(card1.Equals(card2));
        }

        [TestMethod]
        public void CardsShouldNotBeEqualWhenSuitsAreNotTheSame()
        {
            var card1 = new Card(CardSuit.Spades, CardRank.Ace);
            var card2 = new Card(CardSuit.Diamonds, CardRank.Ace);
            Assert.IsFalse(card1.Equals(card2));
        }

        [TestMethod]
        public void CardsShouldNotBeEqualWhenRanksAreNotTheSame()
        {
            var card1 = new Card(CardSuit.Spades, CardRank.Ace);
            var card2 = new Card(CardSuit.Spades, CardRank.King);
            Assert.IsFalse(card1.Equals(card2));
        }

        [TestMethod]
        public void CardsShouldNotBeEqualWhenUsingOperatorAndSuitsAreNotTheSame()
        {
            var card1 = new Card(CardSuit.Spades, CardRank.Ace);
            var card2 = new Card(CardSuit.Diamonds, CardRank.Ace);
            Assert.IsFalse(card1 == card2);
            Assert.IsTrue(card1 != card2);
        }

        [TestMethod]
        public void CardsShouldNotBeEqualWhenUsingOperatorAndRanksAreNotTheSame()
        {
            var card1 = new Card(CardSuit.Spades, CardRank.Ace);
            var card2 = new Card(CardSuit.Spades, CardRank.King);
            Assert.IsFalse(card1 == card2);
            Assert.IsTrue(card1 != card2);
        }

        private static void AssertCardIsCorrect(Card? card, CardSuit exptectedSuit, CardRank expectedRank)
        {
            Assert.IsNotNull(card);
            Assert.AreEqual(expectedRank, card.Rank);
            Assert.AreEqual(exptectedSuit, card.Suit);
        }
    }
}
