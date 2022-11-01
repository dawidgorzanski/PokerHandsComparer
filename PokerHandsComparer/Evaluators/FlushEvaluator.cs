namespace PokerHandsComparer.Evaluators
{
    internal class FlushEvaluator : BasicEvaluator, IEvaluator
    {
        public EvaluationResult Evaluate(Hand hand)
        {
            if (base.HandIsNullOrNotEnoughCards(hand))
            {
                return EvaluationResult.Unsuccessful();
            }

            var suitWithAtLeast5Cards = hand.CardsInHand.GroupBy(c => c.Suit)
                .FirstOrDefault(s => s.Count() >= 5)?.OrderByDescending(c => c.Rank).ToList();

            if (suitWithAtLeast5Cards != null)
            {
                return EvaluationResult.Successful(suitWithAtLeast5Cards);
            }

            return EvaluationResult.Unsuccessful();
        }
    }
}
