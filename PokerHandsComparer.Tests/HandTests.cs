using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHandsComparer.Tests
{
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void AddCard_DoNothing_WhenCardIsNull()
        {
            var hand = new Hand();
            hand.AddCard(null!);
            Assert.AreEqual(0, hand.CardsInHand.Count);
        }

        [TestMethod]
        public void AddCard_AddsCardToCollection()
        {
            var hand = new Hand();
            hand.AddCard(Card.Clubs.Ace);
            Assert.AreEqual(1, hand.CardsInHand.Count);
            Assert.AreEqual(Card.Clubs.Ace, hand.CardsInHand.First());
        }

        [TestMethod]
        public void AddCard_AddsCardOnlyOnce_WhenCardsAreDuplicated()
        {
            var hand = new Hand();
            hand.AddCard(Card.Clubs.Ace);
            hand.AddCard(Card.Clubs.Ace);
            Assert.AreEqual(1, hand.CardsInHand.Count);
            Assert.AreEqual(Card.Clubs.Ace, hand.CardsInHand.First());
        }

        [TestMethod]
        public void AddCard_CannotAddMoreThan8Cards()
        {
            var hand = new Hand();
            hand.AddCard(Card.Clubs.Ace);
            hand.AddCard(Card.Clubs.King);
            hand.AddCard(Card.Clubs.Queen);
            hand.AddCard(Card.Clubs.Jack);
            hand.AddCard(Card.Clubs.Ten);
            hand.AddCard(Card.Clubs.Nine);
            hand.AddCard(Card.Clubs.Eight);
            hand.AddCard(Card.Clubs.Seven);
            hand.AddCard(Card.Clubs.Six);
            hand.AddCard(Card.Clubs.Five);
            hand.AddCard(Card.Clubs.Four);
            Assert.AreEqual(8, hand.CardsInHand.Count);
        }

        [TestMethod]
        public void AddCards_DoNothing_WhenCardsAreNull()
        {
            var hand = new Hand();
            hand.AddCards(null!);
            Assert.AreEqual(0, hand.CardsInHand.Count);
        }

        [TestMethod]
        public void AddCards_AddsCardsToCollection()
        {
            var hand = new Hand();
            hand.AddCards(Card.Clubs.Ace, Card.Clubs.King);
            Assert.AreEqual(2, hand.CardsInHand.Count);
            Assert.AreEqual(Card.Clubs.Ace, hand.CardsInHand.ElementAt(0));
            Assert.AreEqual(Card.Clubs.King, hand.CardsInHand.ElementAt(1));
        }

        [TestMethod]
        public void AddCards_AddsCardsOnlyOnce()
        {
            var hand = new Hand();
            hand.AddCards(Card.Clubs.Ace, Card.Clubs.Ace);
            Assert.AreEqual(1, hand.CardsInHand.Count);
            Assert.AreEqual(Card.Clubs.Ace, hand.CardsInHand.First());
        }

        [TestMethod]
        public void AddCards_CannotAddMoreThan8Cards()
        {
            var hand = new Hand();
            hand.AddCards(
                Card.Clubs.Ace,
                Card.Clubs.King,
                Card.Clubs.Queen,
                Card.Clubs.Jack,
                Card.Clubs.Ten,
                Card.Clubs.Nine,
                Card.Clubs.Eight,
                Card.Clubs.Seven,
                Card.Clubs.Six);
            Assert.AreEqual(8, hand.CardsInHand.Count);
        }

        [TestMethod]
        public void RemoveCard_DoNothing_WhenCardIsNull()
        {
            var hand = new Hand();
            hand.AddCards(Card.Clubs.Ace);
            hand.RemoveCard(null!);
            Assert.AreEqual(1, hand.CardsInHand.Count);
        }

        [TestMethod]
        public void RemoveCard_RemovesCard()
        {
            var hand = new Hand();
            hand.AddCards(Card.Clubs.Ace);
            hand.RemoveCard(Card.Clubs.Ace);
            Assert.AreEqual(0, hand.CardsInHand.Count);
        }
    }
}
