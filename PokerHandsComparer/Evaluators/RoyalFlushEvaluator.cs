namespace PokerHandsComparer.Evaluators
{
    internal class RoyalFlushEvaluator : BasicEvaluator, IEvaluator
    {
        public EvaluationResult Evaluate(Hand hand)
        {
            if (base.HandIsNullOrNotEnoughCards(hand))
            {
                return EvaluationResult.Unsuccessful();
            }

            var suitWithAtLeast5Cards = hand.CardsInHand.GroupBy(c => c.Suit).FirstOrDefault(s => s.Count() >= 5)?.OrderByDescending(c => c.Rank).ToList();

            // there aren't at least 5 cards in the same suit so it cannot be Royal Flush
            if (suitWithAtLeast5Cards == null)
            {
                return EvaluationResult.Unsuccessful();
            }

            if (suitWithAtLeast5Cards[0].Rank == CardRank.Ace
                    && suitWithAtLeast5Cards[1].Rank == CardRank.King
                    && suitWithAtLeast5Cards[2].Rank == CardRank.Queen
                    && suitWithAtLeast5Cards[3].Rank == CardRank.Jack
                    && suitWithAtLeast5Cards[4].Rank == CardRank.Ten)
            {
                return EvaluationResult.Successful(suitWithAtLeast5Cards);
            }

            return EvaluationResult.Unsuccessful();
        }
    }
}
