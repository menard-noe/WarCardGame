using System.Collections.Generic;
using WarCardGame.Card;
using WarCardGame.Hand;

namespace WarCardGame.Game
{
    internal class PlayerWar
    {
        private readonly int Id;
        private HandWarGame<CardWarGame> Hand;

        internal PlayerWar(int id)
        {
            this.Id = id;
        }

        internal PlayerWar(int id, HandWarGame<CardWarGame> hand) : this(id)
        {
            this.Hand = hand;
        }

        internal void SetHand(HandWarGame<CardWarGame> hand)
        {
            this.Hand = hand;
        }

        internal int GetId()
        {
            return this.Id;
        }

        internal bool IsDeckEmpty()
        {
            return this.Hand.IsEmpty();
        }

        internal CardWarGame PopTopCardOfDeck()
        {
            return this.Hand.PopTopCard();
        }

        internal void AddCards(List<CardWarGame> cards)
        {
            this.Hand.AddCards(cards);
        }
    }
}
