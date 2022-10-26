namespace PokerHandsComparer.Evaluators
{
    internal class RoyalFlushEvaluator : BasicEvaluator
    {
        public EvaluationResult Evaluate(Hand hand)
        {
            if (base.HandIsNullOrNotEnoughCards(hand))
            {
                return EvaluationResult.Unsuccessful();
            }

            var orderedCardsBySuit = hand.CardsInHand.GroupBy(c => c.Suit).ToDictionary(c => c.Key, c => c.OrderBy(c => c.Rank).ToList());
            var suitsWithAtLeast5Cards = orderedCardsBySuit.Where(group => group.Value.Count >= 5).ToList();

            // there aren't at least 5 cards in the same suit so it cannot be Royal Flush
            if (!suitsWithAtLeast5Cards.Any())
            {
                return EvaluationResult.Unsuccessful();
            }

            foreach (var suitWithAtLeast5Cards in suitsWithAtLeast5Cards)
            {
                if (suitWithAtLeast5Cards.Value[0].Rank == CardRank.Ten
                    && suitWithAtLeast5Cards.Value[1].Rank == CardRank.Jack
                    && suitWithAtLeast5Cards.Value[2].Rank == CardRank.Queen
                    && suitWithAtLeast5Cards.Value[3].Rank == CardRank.King
                    && suitWithAtLeast5Cards.Value[4].Rank == CardRank.Ace)
                {
                    return EvaluationResult.Successful(suitWithAtLeast5Cards.Value);
                }
            }

            return EvaluationResult.Unsuccessful();
        }
    }
}
