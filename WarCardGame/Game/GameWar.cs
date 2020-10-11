
using System;
using System.Collections.Generic;
using System.Linq;
using WarCardGame.Card;
using WarCardGame.Hand;

namespace WarCardGame.Game
{
    /***
     * 
     * Object representing a single instance of the game War.
     * 
     * ***/
    public class GameWar
    {
        List<PlayerWar> players = new List<PlayerWar>();
        readonly GameHistory gameHistory = new GameHistory();

        public GameWar(HashSet<int> playersId) : this(DistributeHands(playersId))
        {

        }

        public GameWar(Dictionary<int, HandWarGame<CardWarGame>> playersIdAndCorrespondingHand)
        {
            CheckHandsNoDuplicate(playersIdAndCorrespondingHand.Values.ToList());
            foreach (int playerId in playersIdAndCorrespondingHand.Keys)
            {
                this.players.Add(new PlayerWar(playerId, playersIdAndCorrespondingHand[playerId]));
            }
        }

        public GameHistory Play()
        {
            this.PlayAllTurns();
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


        private void PlayAllTurns()
        {
            while (true)
            {
                this.RemovePlayerWithNoCardsLeft();

                if (this.DoWeHaveAWinner())
                {
                    this.gameHistory.SetWinner(players[0].GetId());
                    return;
                }
                else if (this.DoWeHaveATie())
                {
                    this.gameHistory.AddAction("We have a draw, all the players have no card left");
                    return;
                }
                else
                {
                    this.PlayNextTurn();
                }
            }
        }

        private void RemovePlayerWithNoCardsLeft()
        {
            List<PlayerWar> playersWithHandNotEmpty = new List<PlayerWar>();

            foreach (PlayerWar player in this.players)
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

            this.GetWinnerOfTurnAndGiveHimPot(this.players, pot);
            this.gameHistory.IncreamentNumberOfFolds();
        }

        private void GetWinnerOfTurnAndGiveHimPot(List<PlayerWar> players, List<CardWarGame> pot) //add classe arbitre pour gérer le tour ?
        {
            List<PlayerWar> winners = this.GetWinnersOfPop(players, pot); //each player pop a card from thei hand, we might end up in a tie so we have multiple winners.          

            if (winners.Count > 1)
            {
                this.gameHistory.AddAction("Draw between some players, entering TieBreaker");
                List<PlayerWar> winnersWithDeckNotEmpty = this.BurnCard(winners, pot); // if deck empty, can't burn card and so the player lose
                GetWinnerOfTurnAndGiveHimPot(winnersWithDeckNotEmpty, pot); // call the method recursivly to differentiate the winners of the pop
            }
            else if (winners.Count == 1)
            {
                this.gameHistory.AddAction("Player " + winners[0].GetId() + " won the pot containing cards : " + String.Join(", ", pot)); //only one winner so winners[0] is ok to use
                winners[0].AddCards(pot);
            }
            else //all players lost
            {
                Console.Out.WriteLine("No one won the pot");
            }

        }

        private List<PlayerWar> BurnCard(List<PlayerWar> winners, List<CardWarGame> pot)
        {
            List<PlayerWar> winnersWithDeckNotEmpty = new List<PlayerWar>();

            foreach (PlayerWar player in winners)
            {
                if (!player.IsDeckEmpty())
                {
                    CardWarGame card = player.PopTopCardOfDeck();
                    pot.Add(card);
                    winnersWithDeckNotEmpty.Add(player);
                    gameHistory.AddAction("Player " + player.GetId() + " burned the card " + card);
                }
                else
                {
                    gameHistory.AddAction(player.GetId() + "has no more card left, he can't burn a card");
                }
            }
            return winnersWithDeckNotEmpty;
        }

        private List<PlayerWar> GetWinnersOfPop(List<PlayerWar> players, List<CardWarGame> pot)
        {
            CardWarGame betterCard = null;
            List<PlayerWar> winners = new List<PlayerWar>();

            foreach (PlayerWar player in players)
            {
                if (!player.IsDeckEmpty())
                {
                    CardWarGame card = player.PopTopCardOfDeck();
                    pot.Add(card);
                    this.gameHistory.AddAction("Player " + player.GetId() + " played card " + card);

                    if (betterCard == null)
                    {
                        betterCard = card;
                        winners.Add(player);
                    }
                    else
                    {
                        switch (CompareCard(betterCard, card))
                        {
                            case -1:
                                // your cart is worse than the betteCard so you're not part of the winners.
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
            return winners;
        }

        private static int CompareCard(CardWarGame a, CardWarGame b) // return 1 if >, 0 if == and -1 if < 
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

            foreach (HandWarGame<CardWarGame> hand in hands)
            {
                foreach (CardWarGame card in hand.GetAllCards())
                {
                    if (!cards.ContainsKey(card))
                    {
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
