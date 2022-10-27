namespace PokerHandsComparer.Evaluators
{
    internal class StraightFlushEvaluator : BasicEvaluator, IEvaluator
    {
        public EvaluationResult Evaluate(Hand hand)
        {
            if (base.HandIsNullOrNotEnoughCards(hand))
            {
                return EvaluationResult.Unsuccessful();
            }

            var suitWithAtLeast5Cards = hand.CardsInHand.GroupBy(c => c.Suit).FirstOrDefault(s => s.Count() >= 5)?.OrderBy(c => c.Rank).ToList();

            // there aren't at least 5 cards in the same suit so it cannot be Straight Flush
            if (suitWithAtLeast5Cards == null)
            {
                return EvaluationResult.Unsuccessful();
            }

            if (base.CardsAreSequential(suitWithAtLeast5Cards))
            {
                return EvaluationResult.Successful(suitWithAtLeast5Cards);
            }

            return EvaluationResult.Unsuccessful();
        }
    }
}
