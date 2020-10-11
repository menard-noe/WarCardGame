using System;
using System.Collections.Generic;
using System.Linq;
using WarCardGame.Card;

namespace WarCardGame.Hand
{
    public class HandWarGame<T> : Hand<T> where T : CardWarGame
    {
        private readonly LinkedList<T> Cards;

        public HandWarGame() : base()
        {

            this.Cards = new LinkedList<T>();
        }

        public override void AddCard(T card)
        {
            this.Cards.AddLast(card);
        }

        public override void AddCards(List<T> cards)
        {
            cards.Shuffle();
            foreach (T card in cards)
            {
                this.AddCard(card);
            }
        }

        public override T PopTopCard() //check not empty
        {
            if (!this.IsEmpty())
            {
                T card = this.Cards.First.Value;
                this.Cards.RemoveFirst();
                return card;
            }
            else
            {
                throw new Exception("Hand is empty, can't pop card");
            }
        }

        public override List<T> GetAllCards()
        {
            return this.Cards.ToList();
        }

        public override bool IsEmpty()
        {
            return this.Cards.Count == 0;
        }

        public static HandWarGame<CardWarGame> ConvertStringsToCards(List<string> strings) //not safe, should use a proper DSL
        {
            HandWarGame<CardWarGame> hand = new HandWarGame<CardWarGame>();
            foreach (string card in strings)
            {
                Enum.TryParse(card.Substring(0, 1), out CardValueEnum value);
                CardColorEnum color = (CardColorEnum)card.Substring(1, 1)[0];

                hand.AddCard(new CardWarGame(value, color));
            }
            return hand;
        }
    }
}
