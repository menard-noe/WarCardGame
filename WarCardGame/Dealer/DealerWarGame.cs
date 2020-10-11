
using System;
using System.Collections.Generic;
using System.Linq;
using WarCardGame.Hand;
using WarCardGame.Card;

namespace WarCardGame.Dealer
{
    class DealerWarGame/*<T> where T : Hand.HandWarGame<CardWarGame>*/
    {
        List<Player> players = new List<Player>();
        readonly GameHistory gameHistory = new GameHistory(); 

        public DealerWarGame(HashSet<int> playersId):this(DistributeHands(playersId))
        {

        }

        public DealerWarGame(Dictionary<int, HandWarGame<CardWarGame>> playersIdAndCorrespondingHand) //add player here ?
        {
            CheckHandsNoDuplicate(playersIdAndCorrespondingHand.Values.ToList());
            foreach (int playerId in playersIdAndCorrespondingHand.Keys)
            {
                this.players.Add(new Player(playerId, playersIdAndCorrespondingHand[playerId]));
            }
        }

        public GameHistory Play()
        {
            this.LaunchGame();
            return this.gameHistory;

        }
        public static Dictionary<int, HandWarGame<CardWarGame>> DistributeHands(HashSet<int> playersId)
        {
            List<CardWarGame> allCards = CardWarGame.GetAllCardsCombination();
            allCards.Shuffle();

            Dictionary<int, HandWarGame<CardWarGame>> playersIdAndCorrespondingHand = new Dictionary<int, HandWarGame<CardWarGame>>();

            foreach (int playerId in playersId)
            {
                playersIdAndCorrespondingHand.Add(playerId, new HandWarGame<CardWarGame>());
            }

            for (int i = 0; i < allCards.Count; i++)
            {
                playersIdAndCorrespondingHand[i % playersId.Count].AddCard(allCards[i]);
            }

            return playersIdAndCorrespondingHand;
        }


        private void LaunchGame() //playGame
        {
            while (true){
                this.RemovePlayerWithNoCardsLeft();

                if (this.DoWeHaveAWinner()){
                    this.gameHistory.SetWinner(players[0].GetId());
                    return;
                }
                else if (this.DoWeHaveATie()){
                    this.gameHistory.AddAction("We have a draw, all the players have no card left");
                    return;
                }
                else {
                    this.PlayNextTurn();
                }
            }
        }

        private void RemovePlayerWithNoCardsLeft()
        {
            List<Player> playersWithHandNotEmpty = new List<Player>();

            foreach (Player player in this.players)
            {
                if (!player.IsDeckEmpty())
                {
                    playersWithHandNotEmpty.Add(player);
                }
                else
                {
                    this.gameHistory.AddAction("Player " + player.GetId() + " lost the game");
                }
            }

            this.players = playersWithHandNotEmpty;
        }        
        
        private bool DoWeHaveAWinner()
        {
            return this.players.Count == 1;
        }        
        
        private bool DoWeHaveATie()
        {
            return this.players.Count == 0;
        }


        private void PlayNextTurn()
        {
            List<CardWarGame> pot = new List<CardWarGame>();

            this.GetWinnerOfTurnAndGiveHimPot(this.players, ref pot);
            this.gameHistory.increamentNumberOfFolds();
        }

        private void GetWinnerOfTurnAndGiveHimPot(List<Player> players, ref List<CardWarGame> pot) //ref pas forcement nescessiare ? //add classe arbitre pour gérer le tour ?
        {
            List<Player> winners = new List<Player>();
            CardWarGame betterCard = null;


            foreach (Player player in players)
            {
                if (!player.IsDeckEmpty())
                {
                    CardWarGame card = player.PopTopCardOfDeck();
                    pot.Add(card);
                    this.gameHistory.AddAction("Player " + player.GetId() + " played card " + card);

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
                List<Player> winnersAmongWinners = new List<Player>();
                this.gameHistory.AddAction("Draw between some players, entering TieBreaker");

                //burn card
                foreach (Player player in winners)
                {
                    if (!player.IsDeckEmpty())
                    {
                        CardWarGame card = player.PopTopCardOfDeck();
                        pot.Add(card);
                        winnersAmongWinners.Add(player);
                        gameHistory.AddAction("Player " + player.GetId() + " burned the card " + card);
                    }
                    else
                    {
                        gameHistory.AddAction(player.GetId() + "has no more card left, he can't burn a card");
                    }
                }

                // TODO refactor
                GetWinnerOfTurnAndGiveHimPot(winnersAmongWinners, ref pot);
            }
            else if (winners.Count == 1)
            {
                this.gameHistory.AddAction("Player " + winners[0].GetId() + " won the pot containing cards : " + String.Join(", ", pot));
                winners[0].AddCards(pot);
            }
            else
            {
                Console.Out.WriteLine("No one won the pot");
            }

        }

        private static int CompareCard(CardWarGame a, CardWarGame b)
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

        private static void CheckHandsNoDuplicate(List<HandWarGame<CardWarGame>> hands)
        {
            Dictionary<CardWarGame, bool> cards = new Dictionary<CardWarGame, bool>();

            foreach(HandWarGame<CardWarGame> hand in hands)
            {
                foreach (CardWarGame card in hand.GetAllCards())
                {
                    if (!cards.ContainsKey(card)){
                        cards.Add(card, true);
                    }
                    else
                    {
                        throw new ArgumentException("Some cards are identical : " + card.ToString());
                    }
                }

            }
        }

        public GameHistory GetHistory()
        {
            return this.gameHistory;
        }
    }
}
