using System.Collections.Generic;

namespace WarCardGame.Hand
{
    public abstract class Hand<T> where T : Card.Card
    {
        protected Hand()
        {
        }

        public abstract void AddCard(T card);


        public abstract void AddCards(List<T> cards);


        public abstract T PopTopCard(); 
        
        public abstract List<T> GetAllCards();

        public abstract bool IsEmpty();

    }
}
