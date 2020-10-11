using System.Collections.Generic;

namespace WarCardGame.Dealer
{
    class Player
    {
        private readonly int Id;
        private Hand.HandWarGame<Card.CardWarGame> Hand;

        internal Player(int id)
        {
            this.Id = id;
        }        
        
        internal Player(int id, Hand.HandWarGame<Card.CardWarGame> hand) : this(id)
        {
            this.Hand = hand;
        }

        internal void SetHand(Hand.HandWarGame<Card.CardWarGame> hand)
        {
            this.Hand = hand;
        }

        public int GetId()
        {
            return this.Id;
        }

        public bool IsDeckEmpty()
        {
            return this.Hand.IsEmpty();
        }

        public Card.CardWarGame PopTopCardOfDeck()
        {
            return this.Hand.PopTopCard();
        }

        internal void AddCards(List<Card.CardWarGame> cards)
        {
            this.Hand.AddCards(cards);
        }
    }
}
