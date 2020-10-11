using System;
using System.Collections.Generic;

namespace WarCardGame.Card
{
    public class CardWarGame : Card
    {
        internal CardWarGame(CardValueEnum cardValue, CardColorEnum cardColor) : base(cardValue, cardColor)
        {

        }

        public override int Value()
        {
            if (this.cardValue == CardValueEnum.Ace)
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
            foreach (CardValueEnum cardValue in (CardValueEnum[])Enum.GetValues(typeof(CardValueEnum)))
            {
                foreach (CardColorEnum cardColor in (CardColorEnum[])Enum.GetValues(typeof(CardColorEnum)))
                {
                    cards.Add(new CardWarGame(cardValue, cardColor));
                }
            }
            return cards;
        }
    }
}
