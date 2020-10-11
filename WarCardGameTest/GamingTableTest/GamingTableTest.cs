using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WarCardGame.Card;
using WarCardGame.Game;
using WarCardGame.GamingTable;
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

            foreach (GameHistory gameHistory in tableHistory.GetHistories())
            {
                sum += gameHistory.GetNumberOfFolds();
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
            Hand1.AddCard(new CardWarGame(CardValueEnum.Five, CardColorEnum.Clover));
            Hand1.AddCard(new CardWarGame(CardValueEnum.Six, CardColorEnum.Clover));
            Hand1.AddCard(new CardWarGame(CardValueEnum.Seven, CardColorEnum.Clover));
            Hand1.AddCard(new CardWarGame(CardValueEnum.Height, CardColorEnum.Clover));

            HandWarGame<CardWarGame> Hand2 = new HandWarGame<CardWarGame>();
            Hand2.AddCard(new CardWarGame(CardValueEnum.Five, CardColorEnum.Spade));
            Hand2.AddCard(new CardWarGame(CardValueEnum.Six, CardColorEnum.Spade));
            Hand2.AddCard(new CardWarGame(CardValueEnum.Seven, CardColorEnum.Spade));
            Hand2.AddCard(new CardWarGame(CardValueEnum.Height, CardColorEnum.Spade));

            HandWarGame<CardWarGame> Hand3 = new HandWarGame<CardWarGame>();
            Hand3.AddCard(new CardWarGame(CardValueEnum.Five, CardColorEnum.Heart));
            Hand3.AddCard(new CardWarGame(CardValueEnum.Six, CardColorEnum.Heart));
            Hand3.AddCard(new CardWarGame(CardValueEnum.Seven, CardColorEnum.Heart));
            Hand3.AddCard(new CardWarGame(CardValueEnum.Height, CardColorEnum.Heart));

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
            Hand2.AddCard(new CardWarGame(CardValueEnum.Five, CardColorEnum.Spade));
            Hand2.AddCard(new CardWarGame(CardValueEnum.Six, CardColorEnum.Spade));
            Hand2.AddCard(new CardWarGame(CardValueEnum.Seven, CardColorEnum.Spade));
            Hand2.AddCard(new CardWarGame(CardValueEnum.Height, CardColorEnum.Spade));

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
