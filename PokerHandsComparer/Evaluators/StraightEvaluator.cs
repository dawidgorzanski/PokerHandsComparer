namespace PokerHandsComparer.Evaluators
{
    internal class StraightEvaluator : BasicEvaluator, IEvaluator
    {
        public EvaluationResult Evaluate(Hand hand)
        {
            if (base.HandIsNullOrNotEnoughCards(hand))
            {
                return EvaluationResult.Unsuccessful();
            }

            if (base.FiveCardsAreSequential(hand.CardsInHand, out var cardsInSequence))
            {
                return EvaluationResult.Successful(cardsInSequence);
            }

            return EvaluationResult.Unsuccessful();
        }
    }
}
