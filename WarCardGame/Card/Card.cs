namespace WarCardGame.Card
{
    internal abstract class Card
    {
        protected readonly CardValue cardValue;
        protected readonly CardColor cardColor;
        protected Card(CardValue cardValue, CardColor cardColor)
        {
            this.cardValue = cardValue;
            this.cardColor = cardColor;
        }

        public static bool operator >(Card a, Card b)
        {
            return a.Value() > b.Value();
        }
        public static bool operator <(Card a, Card b)
        {
            return a.Value() < b.Value();
        }

        public abstract int Value();
        public CardColor GetColor()
        {
            return this.cardColor;
        }
    }
}
