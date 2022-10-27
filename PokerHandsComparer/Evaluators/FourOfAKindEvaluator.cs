namespace PokerHandsComparer.Evaluators
{
    internal class FourOfAKindEvaluator : BasicEvaluator, IEvaluator
    {
        public EvaluationResult Evaluate(Hand hand)
        {
            if (base.HandIsNullOrNotEnoughCards(hand))
            {
                return EvaluationResult.Unsuccessful();
            }

            var cardsByRank = hand.CardsInHand.GroupBy(c => c.Rank);
            foreach (var cardsGroup in cardsByRank)
            {
                if (cardsGroup.Count() == 4)
                {
                    var maxCardBesideFourOfAKind = hand.CardsInHand.Where(c => !cardsGroup.Contains(c)).OrderByDescending(c => c.Rank).First();
                    var cardsToReturn = cardsGroup.ToList();
                    cardsToReturn.Add(maxCardBesideFourOfAKind);
                    return EvaluationResult.Successful(cardsToReturn);
                }
            }

            return EvaluationResult.Unsuccessful();
        }
    }
}
