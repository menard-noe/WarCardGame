
using System;
using System.Collections.Generic;
using System.Linq;

namespace WarCardGame.Dealer
{
    class DealerWarGame/*<T> where T : Hand.HandWarGame<Card.CardWarGame>*/
    {
        List<Tuple<int, Hand.HandWarGame<Card.CardWarGame>>> playersAndHand;

        //List<Player>
        //Hand.HandWarGame<Card.CardWarGame>
        public DealerWarGame(int[] playerId) //add player here ?
        {

            playersAndHand = new List<Tuple<int, Hand.HandWarGame<Card.CardWarGame>>>();
        }
        public void Play(List<Tuple<int, Hand.HandWarGame<Card.CardWarGame>>> playersAndHand)
        {
            //CheckHandsNoDuplicate((List<Hand.HandWarGame<Card.CardWarGame>>)playersAndHand.Select(x => x.Item2));

            this.playersAndHand.AddRange(playersAndHand);

            this.LaunchGame();
            // ...
            //Play()
        }
        public void PlayAndDistributeHands(List<int> players)
        {
            // ...
            //Play()
        }

        private void LaunchGame() //playGame
        {
            while (true){
                this.RemovePlayerWithNoCardsLeft();

                if (this.DoWeHaveAWinner()){
                    Console.Out.WriteLine("Winner : " + playersAndHand[0].Item1);
                    return;
                }
                else if (this.DoWeHaveATie()){
                    Console.Out.WriteLine("We have a draw");
                    return;
                }
                else {
                    this.PlayNextTurn();
                }
            }
        }

        private void RemovePlayerWithNoCardsLeft()
        {
            List<Tuple<int, Hand.HandWarGame<Card.CardWarGame>>> playersWithHandNotEmpty = new List<Tuple<int, Hand.HandWarGame<Card.CardWarGame>>>();

            foreach (Tuple<int, Hand.HandWarGame<Card.CardWarGame>> player in this.playersAndHand)
            {
                if (!player.Item2.IsEmpty())
                {
                    playersWithHandNotEmpty.Add(player);
                }
            }

            this.playersAndHand = playersWithHandNotEmpty;
        }        
        
        private bool DoWeHaveAWinner()
        {
            return this.playersAndHand.Count == 1;
        }        
        
        private bool DoWeHaveATie()
        {
            return this.playersAndHand.Count == 0;
        }


        private void PlayNextTurn()
        {
            List<Card.CardWarGame> pot = new List<Card.CardWarGame>();

            this.GetWinnerOfTurn(this.playersAndHand, ref pot);
        }

        private void GetWinnerOfTurn(List<Tuple<int, Hand.HandWarGame<Card.CardWarGame>>> players, ref List<Card.CardWarGame> pot) //ref pas forcement nescessiare ? //add calsse arbitre pour gérer le tour ?
        {
            List<Tuple<int, Hand.HandWarGame<Card.CardWarGame>>> winners = new List<Tuple<int, Hand.HandWarGame<Card.CardWarGame>>>();
            Card.CardWarGame betterCard = null;


            foreach (Tuple<int, Hand.HandWarGame<Card.CardWarGame>> player in players)
            {
                if (!player.Item2.IsEmpty())
                {
                    Card.CardWarGame card = player.Item2.PopTopCard();
                    pot.Add(card);

                    if (betterCard == null){
                        betterCard = card;
                        winners.Add(player);
                    }
                    else
                    {
                        switch (CompareCard(betterCard, card))
                        {
                            case -1:

                                break;
                            case 0:
                                winners.Add(player);
                                break;
                            case 1:
                                betterCard = card;
                                winners.Clear();
                                winners.Add(player);
                                break;
                        }
                    }

                }
            }

            if (winners.Count > 1)
            {
                Console.Out.WriteLine("Draw between some players");
                GetWinnerOfTurn(winners, ref pot);
            }
            else if (winners.Count == 1)
            {
                Console.Out.WriteLine("Player " + winners[0].Item1 + "won the pot");
            }
            else
            {
                Console.Out.WriteLine("No one won the pot");
            }

        }

        private static int CompareCard(Card.CardWarGame a, Card.CardWarGame b)
        {
            if (a > b)
            {
                return -1;
            } 
            else if (a < b)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private static void CheckHandsNoDuplicate(List<Hand.HandWarGame<Card.CardWarGame>> hands)
        {
            Dictionary<Card.CardWarGame, bool> cards = new Dictionary<Card.CardWarGame, bool>();

            foreach(Hand.HandWarGame<Card.CardWarGame> hand in hands)
            {
                foreach (Card.CardWarGame card in hand.GetAllCards())
                {
                    if (!cards.ContainsKey(card)){
                        cards.Add(card, true); //TODO overide equals
                    }
                    else
                    {
                        throw new ArgumentException("Some cards are identical : " + card.ToString());
                    }
                }

            }
        }
    }
}
