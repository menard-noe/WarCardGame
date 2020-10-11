using System.Collections.Generic;
using System.Linq;

namespace WarCardGame.Hand
{
    class HandWarGame<T> : Hand.Hand<T> where T : Card.CardWarGame
    {
        private readonly LinkedList<T> Cards; //protected ?

        public HandWarGame() : base()
        {

            this.Cards = new LinkedList<T>();
        }

        public override void AddCard(T card)
        {
            this.Cards.AddLast(card);
        }

        public override void AddCards(List<T> cards) //arraylist ?
        {
            foreach (T card in cards)
            {
                this.AddCard(card);
            }
        }

        public override T PopTopCard() //check not empty
        {
            T card = this.Cards.First.Value;
            this.Cards.RemoveFirst();
            return card;
        }

        public override List<T> GetAllCards()
        {
            return Cards.ToList();
        }

        public override bool IsEmpty()
        {
            return this.Cards.Count == 0;
        }
    }
}
