using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WarCardGame.Dealer;
using WarCardGame.GamingTable;
using WarCardGame.Card;
using WarCardGame.Hand;

namespace WarCardGameTest.GamingTableTest
{
    [TestClass]
    public class GamingTableTest
    {
        const int numberGamesToPlay = 1000;

        [TestMethod, Timeout(50 * numberGamesToPlay)] // ms
        public void CheckNoInfiniteLoop()
        {
            IGamingTable gamingTable = new GamingTable();

            TableHistory tableHistory = gamingTable.PlayMultipleGames(2, numberGamesToPlay);

            int sum = 0;

            foreach(GameHistory gameHistory in tableHistory.GetHistories())
            {
                sum += gameHistory.numberOfFolds;
            }
            Console.WriteLine("Average number of fold per game : " + sum / numberGamesToPlay);

            tableHistory.PrintScoreBoard();
        }

        [TestMethod]
        public void CheckSpecialHands()
        {
            IGamingTable gamingTable = new GamingTable();

            Dictionary<int, HandWarGame<CardWarGame>> players = new Dictionary<int, HandWarGame<CardWarGame>>();

            HandWarGame<CardWarGame> Hand1 = new HandWarGame<CardWarGame>();
            Hand1.AddCard(new CardWarGame(CardValue.Five, CardColor.Clover));
            Hand1.AddCard(new CardWarGame(CardValue.Six, CardColor.Clover));
            Hand1.AddCard(new CardWarGame(CardValue.Seven, CardColor.Clover));
            Hand1.AddCard(new CardWarGame(CardValue.Height, CardColor.Clover));

            HandWarGame<CardWarGame> Hand2 = new HandWarGame<CardWarGame>();
            Hand2.AddCard(new CardWarGame(CardValue.Five, CardColor.Spade));            
            Hand2.AddCard(new CardWarGame(CardValue.Six, CardColor.Spade));            
            Hand2.AddCard(new CardWarGame(CardValue.Seven, CardColor.Spade));            
            Hand2.AddCard(new CardWarGame(CardValue.Height, CardColor.Spade));            
            
            HandWarGame<CardWarGame> Hand3 = new HandWarGame<CardWarGame>();
            Hand3.AddCard(new CardWarGame(CardValue.Five, CardColor.Heart));
            Hand3.AddCard(new CardWarGame(CardValue.Six, CardColor.Heart));
            Hand3.AddCard(new CardWarGame(CardValue.Seven, CardColor.Heart));
            Hand3.AddCard(new CardWarGame(CardValue.Height, CardColor.Heart));

            players.Add(1, Hand1);
            players.Add(2, Hand2);            
            players.Add(3, Hand3);


            TableHistory tableHistory = gamingTable.PlayGameWhithGivenHand(players);
            Assert.AreEqual(-1, tableHistory.GetHistories()[0].GetWinner()); //No winner
        }

        [TestMethod]
        public void CheckSpecialHands2()
        {
            GamingTable gamingTable = new GamingTable();

            Dictionary<int, HandWarGame<CardWarGame>> players = new Dictionary<int, HandWarGame<CardWarGame>>();

            HandWarGame<CardWarGame> Hand1 = new HandWarGame<CardWarGame>();

            HandWarGame<CardWarGame> Hand2 = new HandWarGame<CardWarGame>();
            Hand2.AddCard(new CardWarGame(CardValue.Five, CardColor.Spade));
            Hand2.AddCard(new CardWarGame(CardValue.Six, CardColor.Spade));
            Hand2.AddCard(new CardWarGame(CardValue.Seven, CardColor.Spade));
            Hand2.AddCard(new CardWarGame(CardValue.Height, CardColor.Spade));

            HandWarGame<CardWarGame> Hand3 = new HandWarGame<CardWarGame>();

            players.Add(1, Hand1);
            players.Add(2, Hand2);
            players.Add(3, Hand3);


            TableHistory tableHistory = gamingTable.PlayGameWhithGivenHand(players);
            Assert.AreEqual(2, tableHistory.GetHistories()[0].GetWinner());
        }
        
        [TestMethod]
        public void CheckSpecialHands3()
        {
            IGamingTable gamingTable = new GamingTable();

            Dictionary<int, HandWarGame<CardWarGame>> players = new Dictionary<int, HandWarGame<CardWarGame>>();

            HandWarGame<CardWarGame> Hand1 = new HandWarGame<CardWarGame>();

            HandWarGame<CardWarGame> Hand2 = new HandWarGame<CardWarGame>();

            HandWarGame<CardWarGame> Hand3 = new HandWarGame<CardWarGame>();

            players.Add(1, Hand1);
            players.Add(2, Hand2);
            players.Add(3, Hand3);


            TableHistory tableHistory = gamingTable.PlayGameWhithGivenHand(players);
            Assert.AreEqual(-1, tableHistory.GetHistories()[0].GetWinner()); //No winner
        }
    }
}
