﻿namespace WarCardGame.Card
{
    public abstract class Card
    {
        protected readonly CardValueEnum cardValue;
        protected readonly CardColorEnum cardColor;
        protected Card(CardValueEnum cardValue, CardColorEnum cardColor)
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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var b2 = (Card)obj;
            return (this.cardValue == b2.cardValue && this.cardColor == b2.cardColor);
        }

        public override int GetHashCode()
        {
            return cardValue.GetHashCode() ^ cardColor.GetHashCode();
        }

        public abstract int Value();
        public CardColorEnum GetColor()
        {
            return this.cardColor;
        }

        public override string ToString()
        {
            return this.cardValue.ToString("D") + (char)this.cardColor;
        }
    }
}
