namespace WarCardGame.Card
{
    internal class CardWarGame : Card
    {
        internal CardWarGame(CardValue cardValue, CardColor cardColor) : base(cardValue, cardColor)
        {

        }

        public override int Value()
        {
            if (this.cardValue == CardValue.Ace)
            {
                return 14;
            }
            else
            {
                return (int)this.cardValue;
            }
        }
    }
}
