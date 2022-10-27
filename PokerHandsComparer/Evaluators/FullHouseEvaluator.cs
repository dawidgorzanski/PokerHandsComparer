namespace PokerHandsComparer.Evaluators
{
    internal class FullHouseEvaluator : BasicEvaluator, IEvaluator
    {
        public EvaluationResult Evaluate(Hand hand)
        {
            if (base.HandIsNullOrNotEnoughCards(hand))
            {
                return EvaluationResult.Unsuccessful();
            }

            var cardsByRank = hand.CardsInHand.OrderByDescending(c => c.Rank).ThenBy(c => c.Suit).GroupBy(c => c.Rank);
            List<Card>? threeOfAKind = null;
            List<Card>? pair = null;

            foreach (var group in cardsByRank)
            {
                if (threeOfAKind == null && group.Count() >= 3)
                {
                    threeOfAKind = group.ToList();
                    continue;
                }

                if (pair == null && group.Count() >= 2)
                {
                    pair = group.Take(2).ToList();
                    continue;
                }
            }

            if (threeOfAKind != null && pair != null)
            {
                var cards = new List<Card>();
                cards.AddRange(threeOfAKind);
                cards.AddRange(pair);
                return EvaluationResult.Successful(cards);
            }

            return EvaluationResult.Unsuccessful();
        }
    }
}
