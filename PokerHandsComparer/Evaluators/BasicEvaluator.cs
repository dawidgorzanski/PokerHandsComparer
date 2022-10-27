namespace PokerHandsComparer.Evaluators
{
    internal class BasicEvaluator
    {
        protected bool HandIsNullOrNotEnoughCards(Hand hand)
        {
            return hand == null || hand.CardsInHand.Count < 5;
        }

        protected bool CardsAreSequential(IEnumerable<Card> cards)
        {
            var ranksWhenAceIsAce = cards.Select(c => (int)c.Rank).OrderBy(x => x).ToList();
            var aceTreatedAsAce = ranksWhenAceIsAce.Zip(ranksWhenAceIsAce.Skip(1), (a, b) => (a + 1) == b).All(x => x);
            if (aceTreatedAsAce)
            {
                return true;
            }

            var ranksWhenAceIsOne = cards.Select(c => c.Rank == CardRank.Ace ? 1 : (int)c.Rank).OrderBy(x => x).ToList();
            var aceTreatedAsOne = ranksWhenAceIsOne.Zip(ranksWhenAceIsOne.Skip(1), (a, b) => (a + 1) == b).All(x => x);
            return aceTreatedAsOne;
        }
    }
}
