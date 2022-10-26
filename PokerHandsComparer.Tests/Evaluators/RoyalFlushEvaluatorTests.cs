using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandsComparer.Evaluators;

namespace PokerHandsComparer.Tests.Evaluators
{
    [TestClass]
    public class RoyalFlushEvaluatorTests
    {
        [DataTestMethod]
        [DynamicData(nameof(GetEvaluationTestData), DynamicDataSourceType.Method)]
        public void Evaluate_ReturnsCorrectResult(Hand hand, bool pokerHandFound)
        {
            var evaluator = new RoyalFlushEvaluator();
            var result = evaluator.Evaluate(hand);
            Assert.AreEqual(pokerHandFound, result.PokerHandFound);
        }

        private static IEnumerable<object[]> GetEvaluationTestData()
        {
            yield return new object[] { null!, false };
            yield return new object[] { new Hand(), false };
            yield return new object[] { new Hand(Card.Spades.Ace), false };
            yield return new object[] { new Hand(Card.Spades.Ace, Card.Spades.King, Card.Spades.Five, Card.Spades.Four, Card.Spades.Seven), false };
            yield return new object[] { new Hand(Card.Spades.Ace, Card.Clubs.King, Card.Hearts.Five, Card.Diamonds.Four, Card.Spades.Seven), false };
            yield return new object[] { new Hand(Card.Spades.Ace, Card.Spades.King, Card.Spades.Queen, Card.Spades.Jack, Card.Spades.Ten), true };
            yield return new object[] { new Hand(Card.Spades.Ten, Card.Spades.Jack, Card.Spades.Queen, Card.Spades.King, Card.Spades.Ace), true };
            yield return new object[] { new Hand(Card.Spades.Ten, Card.Hearts.Ace, Card.Diamonds.Ten, Card.Spades.Jack, Card.Spades.Queen, Card.Spades.King, Card.Spades.Ace), true };
        }
    }
}
