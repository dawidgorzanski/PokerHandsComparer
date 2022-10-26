namespace PokerHandsComparer.Evaluators
{
    internal interface IEvaluator
    {
        EvaluationResult Evaluate(Hand hand);
    }
}
