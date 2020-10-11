using System;
using System.Collections.Generic;

namespace WarCardGame.Card
{
    public class CardWarGame : Card
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

        public static List<CardWarGame> GetAllCardsCombination()
        {
            List<CardWarGame> cards = new List<CardWarGame>();
            foreach (CardValue cardValue in (CardValue[])Enum.GetValues(typeof(CardValue)))
            {
                foreach (CardColor cardColor in (CardColor[])Enum.GetValues(typeof(CardColor)))
                {
                    cards.Add(new CardWarGame(cardValue, cardColor)); 
                }
            }
            return cards;
        }
    }
}
