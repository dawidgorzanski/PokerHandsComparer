using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandsComparer.Evaluators;

namespace PokerHandsComparer.Tests.Evaluators
{
    [TestClass]
    public class RoyalFlushEvaluatorTests
    {
        [DataTestMethod]
        [DynamicData(nameof(GetEvaluationTestData), DynamicDataSourceType.Method)]
        public void Evaluate_ReturnsCorrectResult(Hand hand, bool pokerHandFound, Card[]? expectedCards)
        {
            var evaluator = new RoyalFlushEvaluator();
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
                null!
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
                null!
            };
            yield return new object[]
            { 
                new Hand(Card.Spades.Ace, Card.Spades.King, Card.Spades.Five, Card.Spades.Four, Card.Spades.Seven),
                false,
                null!
            };
            yield return new object[]
            {
                new Hand(Card.Spades.Ace, Card.Clubs.King, Card.Hearts.Five, Card.Diamonds.Four, Card.Spades.Seven),
                false,
                null!
            };
            yield return new object[]
            {
                new Hand(Card.Spades.Ace, Card.Spades.King, Card.Spades.Queen, Card.Spades.Jack, Card.Spades.Ten),
                true,
                new [] { Card.Spades.Ace, Card.Spades.King, Card.Spades.Queen, Card.Spades.Jack, Card.Spades.Ten },
            };
            yield return new object[]
            {
                new Hand(Card.Spades.Ten, Card.Spades.Jack, Card.Spades.Queen, Card.Spades.King, Card.Spades.Ace),
                true,
                new [] { Card.Spades.Ace, Card.Spades.King, Card.Spades.Queen, Card.Spades.Jack, Card.Spades.Ten },
            };
            yield return new object[]
            {
                new Hand(Card.Spades.Ten, Card.Hearts.Ace, Card.Diamonds.Ten, Card.Spades.Jack, Card.Spades.Queen, Card.Spades.King, Card.Spades.Ace),
                true,
                new [] { Card.Spades.Ace, Card.Spades.King, Card.Spades.Queen, Card.Spades.Jack, Card.Spades.Ten },
            };
        }
    }
}
