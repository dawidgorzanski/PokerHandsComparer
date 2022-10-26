namespace PokerHandsComparer.Evaluators
{
    internal class BasicEvaluator
    {
        protected bool HandIsNullOrNotEnoughCards(Hand hand)
        {
            return hand == null || hand.CardsInHand.Count < 5;
        }
    }
}
