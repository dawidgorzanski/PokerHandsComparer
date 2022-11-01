namespace PokerHandsComparer.Evaluators
{
    internal class BasicEvaluator
    {
        protected bool HandIsNullOrNotEnoughCards(Hand hand)
        {
            return hand == null || hand.CardsInHand.Count < 5;
        }

        protected bool FiveCardsAreSequential(IEnumerable<Card> cards, out IEnumerable<Card> cardsInSequence)
        {
            const int requiredNumberOfCardsInSequence = 5;
            cardsInSequence = new List<Card>();

            var cardsOrderedByRankWhenAceIsAce = cards.OrderByDescending(c => (int)c.Rank).ToList();
            var previousCard = cardsOrderedByRankWhenAceIsAce.First();
            var currentSequence = new List<Card> { previousCard };
            foreach (var card in cardsOrderedByRankWhenAceIsAce.Skip(1))
            {
                if ((int)previousCard.Rank - 1 == (int)card.Rank)
                {
                    currentSequence.Add(card);
                }
                else
                {
                    currentSequence.Clear();
                    currentSequence.Add(card);
                }

                if (currentSequence.Count == requiredNumberOfCardsInSequence)
                {
                    cardsInSequence = currentSequence;
                    return true;
                }

                previousCard = card;
            }

            var cardsOrderedByRankWhenAceIsOne = cards.OrderByDescending(c => c.Rank == CardRank.Ace ? 1 : (int)c.Rank).ToList();
            previousCard = cardsOrderedByRankWhenAceIsOne.First();
            currentSequence = new List<Card> { previousCard };
            foreach (var card in cardsOrderedByRankWhenAceIsOne.Skip(1))
            {
                var rank = card.Rank == CardRank.Ace ? 1 : (int)card.Rank;
                if ((int)previousCard.Rank - 1 == rank)
                {
                    currentSequence.Add(card);
                }
                else
                {
                    currentSequence.Clear();
                    currentSequence.Add(card);
                }

                if (currentSequence.Count == requiredNumberOfCardsInSequence)
                {
                    cardsInSequence = currentSequence;
                    return true;
                }

                previousCard = card;
            }

            return false;
        }
    }
}
