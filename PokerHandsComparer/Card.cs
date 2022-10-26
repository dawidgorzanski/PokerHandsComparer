namespace PokerHandsComparer
{
    public enum CardSuit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public enum CardRank
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }

    public class Card : IEquatable<Card?>
    {
        public static CardBuilder Clubs = new CardBuilder(CardSuit.Clubs);
        public static CardBuilder Diamonds = new CardBuilder(CardSuit.Diamonds);
        public static CardBuilder Hearts = new CardBuilder(CardSuit.Hearts);
        public static CardBuilder Spades = new CardBuilder(CardSuit.Spades);

        public virtual CardSuit Suit { get; protected set; }
        public virtual CardRank Rank { get; protected set; }

        public Card(CardSuit suit, CardRank rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }

        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Card);
        }

        public bool Equals(Card? other)
        {
            return other is not null &&
                   this.Suit == other.Suit &&
                   this.Rank == other.Rank;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Suit, this.Rank);
        }

        public override string ToString()
        {
            return $"{this.Suit} of {this.Rank}";
        }

        public static bool operator ==(Card? left, Card? right)
        {
            return EqualityComparer<Card>.Default.Equals(left, right);
        }

        public static bool operator !=(Card? left, Card? right)
        {
            return !(left == right);
        }

        public class CardBuilder
        {
            private readonly CardSuit cardSuit;

            public CardBuilder(CardSuit cardSuit)
            {
                this.cardSuit = cardSuit;
            }

            public Card Two => new(this.cardSuit, CardRank.Two);
            public Card Three => new(this.cardSuit, CardRank.Three);
            public Card Four => new(this.cardSuit, CardRank.Four);
            public Card Five => new(this.cardSuit, CardRank.Five);
            public Card Six => new(this.cardSuit, CardRank.Six);
            public Card Seven => new(this.cardSuit, CardRank.Seven);
            public Card Eight => new(this.cardSuit, CardRank.Eight);
            public Card Nine => new(this.cardSuit, CardRank.Nine);
            public Card Ten => new(this.cardSuit, CardRank.Ten);
            public Card Jack => new(this.cardSuit, CardRank.Jack);
            public Card Queen => new(this.cardSuit, CardRank.Queen);
            public Card King => new(this.cardSuit, CardRank.King);
            public Card Ace => new(this.cardSuit, CardRank.Ace);
        }
    }
}
