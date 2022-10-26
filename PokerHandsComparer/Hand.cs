namespace PokerHandsComparer
{
    public class Hand
    {
        protected HashSet<Card> Cards { get; }

        public Hand(params Card[] cards)
        {
            this.Cards = new HashSet<Card>();
            this.AddCards(cards);
        }

        public virtual IReadOnlyCollection<Card> CardsInHand => this.Cards;

        public virtual void AddCard(Card card)
        {
            if (card == null || this.Cards.Count == 8)
            {
                return;
            }

            this.Cards.Add(card);
        }

        public virtual void AddCards(params Card[] cards)
        {
            if (cards == null)
            {
                return;
            }

            foreach (var card in cards)
            {
                this.Cards.Add(card);
                if (this.Cards.Count == 8)
                {
                    return;
                }
            }
        }

        public virtual void RemoveCard(Card card)
        {
            if (card == null)
            {
                return;
            }

            this.Cards.Remove(card);
        }

        public override string ToString()
        {
            return string.Join(',', this.Cards);
        }
    }
}
