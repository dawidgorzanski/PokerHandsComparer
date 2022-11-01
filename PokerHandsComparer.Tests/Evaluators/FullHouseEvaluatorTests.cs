using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandsComparer.Evaluators;

namespace PokerHandsComparer.Tests.Evaluators
{
    [TestClass]
    public class FullHouseEvaluatorTests
    {
        [DataTestMethod]
        [DynamicData(nameof(GetEvaluationTestData), DynamicDataSourceType.Method)]
        public void Evaluate_ReturnsCorrectResult(Hand hand, bool pokerHandFound, Card[]? expectedCards)
        {
            var evaluator = new FullHouseEvaluator();
            var result = evaluator.Evaluate(hand);
            Assert.AreEqual(pokerHandFound, result.PokerHandFound);
            if (pokerHandFound)
            {
                CollectionAssert.AreEqual(expectedCards, result.UsedCards.ToArray());
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
                new Hand(Card.Spades.Ace, Card.Diamonds.Ace, Card.Clubs.Ace, Card.Hearts.Seven, Card.Spades.Seven),
                true,
                new [] { Card.Clubs.Ace, Card.Diamonds.Ace, Card.Spades.Ace, Card.Hearts.Seven, Card.Spades.Seven },
            };
            yield return new object[]
            {
                new Hand(Card.Spades.Seven, Card.Diamonds.Seven, Card.Clubs.Seven, Card.Hearts.Ace, Card.Spades.Ace),
                true,
                new [] { Card.Clubs.Seven, Card.Diamonds.Seven, Card.Spades.Seven, Card.Hearts.Ace, Card.Spades.Ace },
            };
            yield return new object[]
            {
                new Hand(Card.Spades.Seven, Card.Diamonds.Seven, Card.Clubs.Seven, Card.Hearts.Ace, Card.Spades.Ace, Card.Clubs.Ace),
                true,
                new [] { Card.Clubs.Ace, Card.Hearts.Ace, Card.Spades.Ace, Card.Clubs.Seven, Card.Diamonds.Seven },
            };
            yield return new object[]
            {
                new Hand(Card.Spades.Seven, Card.Diamonds.Seven, Card.Clubs.Six, Card.Diamonds.Six, Card.Hearts.Ace, Card.Spades.Ace, Card.Clubs.Ace),
                true,
                new [] { Card.Clubs.Ace, Card.Hearts.Ace, Card.Spades.Ace, Card.Diamonds.Seven, Card.Spades.Seven },
            };
        }
    }
}
