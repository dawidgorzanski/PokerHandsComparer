namespace PokerHandsComparer.Evaluators
{
    internal sealed class EvaluationResult
    {
        public bool PokerHandFound { get; private set; }
        public IList<Card> UsedCards { get; private set; } = new List<Card>();

        private EvaluationResult()
        {
        }

        public static EvaluationResult Unsuccessful()
        {
            return new EvaluationResult();
        }

        public static EvaluationResult Successful(List<Card> usedCards)
        {
            return new EvaluationResult
            {
                PokerHandFound = true,
                UsedCards = usedCards
            };
        }
    }
}
