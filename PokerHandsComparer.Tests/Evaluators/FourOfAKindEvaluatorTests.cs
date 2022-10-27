using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandsComparer.Evaluators;

namespace PokerHandsComparer.Tests.Evaluators
{
    [TestClass]
    public class FourOfAKindEvaluatorTests
    {
        [DataTestMethod]
        [DynamicData(nameof(GetEvaluationTestData), DynamicDataSourceType.Method)]
        public void Evaluate_ReturnsCorrectResult(Hand hand, bool pokerHandFound, Card[]? expectedCards)
        {
            var evaluator = new FourOfAKindEvaluator();
            var result = evaluator.Evaluate(hand);
            Assert.AreEqual(pokerHandFound, result.PokerHandFound);
            if (pokerHandFound)
            {
                CollectionAssert.AreEqual(
                    expectedCards?.OrderBy(c => c.Rank).ThenBy(c => c.Suit).ToArray(),
                    result.UsedCards.OrderBy(c => c.Rank).ThenBy(c => c.Suit).ToArray());
            }
        }

        private static IEnumerable<object[]> GetEvaluationTestData()
        {
            yield return new object[]
            {
                null!,
                false,
                null!,
            };
            yield return new object[]
            {
                new Hand(),
                false,
                null!
            };
            yield return new object[]
            {
                new Hand(Card.Spades.Ace),
                false,
                null!,
            };
            yield return new object[]
            {
                new Hand(Card.Spades.Ace, Card.Spades.King, Card.Spades.Five, Card.Spades.Four, Card.Spades.Seven),
                false,
                null!,
            };
            yield return new object[]
            {
                new Hand(Card.Spades.Ace, Card.Diamonds.Ace, Card.Clubs.Ace, Card.Hearts.Ace, Card.Spades.Seven),
                true,
                new [] { Card.Spades.Ace, Card.Diamonds.Ace, Card.Clubs.Ace, Card.Hearts.Ace, Card.Spades.Seven }
            };
            yield return new object[]
            {
                new Hand(Card.Spades.Seven, Card.Spades.Ace, Card.Diamonds.Ace, Card.Clubs.Ace, Card.Hearts.Ace),
                true,
                new [] { Card.Spades.Ace, Card.Diamonds.Ace, Card.Clubs.Ace, Card.Hearts.Ace, Card.Spades.Seven }
            };
            yield return new object[]
            {
                new Hand(Card.Spades.Seven, Card.Spades.Eight, Card.Diamonds.Ace, Card.Clubs.Ace, Card.Hearts.Ace),
                false,
                null!,
            };
        }
    }
}
