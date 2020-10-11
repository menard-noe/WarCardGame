using System;
using System.Collections.Generic;
using System.Text;

namespace WarCardGame.Dealer
{
    class Player
    {
        private readonly int Id;
        private Hand.Hand<Card.Card> Hand;

        internal Player(int id)
        {
            this.Id = id;
        }        
        
        internal Player(int id, Hand.Hand<Card.Card> hand) : this(id)
        {
            this.Hand = hand;
        }

        internal void SetHand(Hand.Hand<Card.Card> hand)
        {
            this.Hand = hand;
        }

        /*getHand()
        {

        }*/


    }
}
