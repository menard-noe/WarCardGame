using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WarCardGame.Card;
using WarCardGame.Game;
using WarCardGame.Hand;

namespace WarCardGameTest.DealerTest
{
    [TestClass]
    public class DealerWarGameTest
    {
        [TestMethod]
        public void HandOneCardTest()
        {
            Dictionary<int, HandWarGame<CardWarGame>> players = new Dictionary<int, HandWarGame<CardWarGame>>();

            HandWarGame<CardWarGame> Hand1 = new HandWarGame<CardWarGame>();
            Hand1.AddCard(new CardWarGame(CardValueEnum.Five, CardColorEnum.Clover));

            HandWarGame<CardWarGame> Hand2 = new HandWarGame<CardWarGame>();
            Hand2.AddCard(new CardWarGame(CardValueEnum.Six, CardColorEnum.Spade));

            players.Add(1, Hand1);
            players.Add(2, Hand2);

            GameWar dealerWarGame = new GameWar(players);

            dealerWarGame.Play();
            GameHistory history = dealerWarGame.GetHistory();
            Assert.AreEqual(2, history.GetWinner());
        }

        [TestMethod]
        public void HandOneCardEqualValueTest()
        {
            Dictionary<int, HandWarGame<CardWarGame>> players = new Dictionary<int, HandWarGame<CardWarGame>>();

            HandWarGame<CardWarGame> Hand1 = new HandWarGame<CardWarGame>();
            Hand1.AddCard(new CardWarGame(CardValueEnum.Five, CardColorEnum.Clover));

            HandWarGame<CardWarGame> Hand2 = new HandWarGame<CardWarGame>();
            Hand2.AddCard(new CardWarGame(CardValueEnum.Five, CardColorEnum.Spade));

            players.Add(1, Hand1);
            players.Add(2, Hand2);

            GameWar dealerWarGame = new GameWar(players);

            dealerWarGame.Play();
            GameHistory history = dealerWarGame.GetHistory();
            Assert.AreEqual(-1, history.GetWinner());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SameCardInDifferentHandTest()
        {
            Dictionary<int, HandWarGame<CardWarGame>> players = new Dictionary<int, HandWarGame<CardWarGame>>();

            HandWarGame<CardWarGame> Hand1 = new HandWarGame<CardWarGame>();
            Hand1.AddCard(new CardWarGame(CardValueEnum.Five, CardColorEnum.Spade));

            HandWarGame<CardWarGame> Hand2 = new HandWarGame<CardWarGame>();
            Hand2.AddCard(new CardWarGame(CardValueEnum.Five, CardColorEnum.Spade));

            players.Add(1, Hand1);
            players.Add(2, Hand2);

            GameWar dealerWarGame = new GameWar(players);

            dealerWarGame.Play();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SameCardInDifferentHandTest2()
        {
            Dictionary<int, HandWarGame<CardWarGame>> players = new Dictionary<int, HandWarGame<CardWarGame>>();

            CardWarGame card = new CardWarGame(CardValueEnum.Five, CardColorEnum.Spade);

            HandWarGame<CardWarGame> Hand1 = new HandWarGame<CardWarGame>();
            Hand1.AddCard(card);

            HandWarGame<CardWarGame> Hand2 = new HandWarGame<CardWarGame>();
            Hand2.AddCard(card);

            players.Add(1, Hand1);
            players.Add(2, Hand2);

            GameWar dealerWarGame = new GameWar(players);

            dealerWarGame.Play();
        }

        [TestMethod]
        public void TieBreakSameNumberOfCardTest()
        {
            Dictionary<int, HandWarGame<CardWarGame>> players = new Dictionary<int, HandWarGame<CardWarGame>>();

            HandWarGame<CardWarGame> Hand1 = new HandWarGame<CardWarGame>();
            Hand1.AddCard(new CardWarGame(CardValueEnum.Five, CardColorEnum.Spade));
            Hand1.AddCard(new CardWarGame(CardValueEnum.Three, CardColorEnum.Spade));
            Hand1.AddCard(new CardWarGame(CardValueEnum.Ace, CardColorEnum.Spade));

            HandWarGame<CardWarGame> Hand2 = new HandWarGame<CardWarGame>();
            Hand2.AddCard(new CardWarGame(CardValueEnum.Five, CardColorEnum.Clover));
            Hand2.AddCard(new CardWarGame(CardValueEnum.Ace, CardColorEnum.Clover));
            Hand2.AddCard(new CardWarGame(CardValueEnum.King, CardColorEnum.Clover));

            players.Add(1, Hand1);
            players.Add(2, Hand2);

            GameWar dealerWarGame = new GameWar(players);

            dealerWarGame.Play();
            GameHistory history = dealerWarGame.GetHistory();
            Assert.AreEqual(1, history.GetWinner());
        }

        [TestMethod]
        public void TieBreakNotTheSameNumberOfCardTest()
        {
            Dictionary<int, HandWarGame<CardWarGame>> players = new Dictionary<int, HandWarGame<CardWarGame>>();

            HandWarGame<CardWarGame> Hand1 = new HandWarGame<CardWarGame>();
            Hand1.AddCard(new CardWarGame(CardValueEnum.Five, CardColorEnum.Spade));
            Hand1.AddCard(new CardWarGame(CardValueEnum.Ace, CardColorEnum.Spade));

            HandWarGame<CardWarGame> Hand2 = new HandWarGame<CardWarGame>();
            Hand2.AddCard(new CardWarGame(CardValueEnum.Five, CardColorEnum.Clover));
            Hand2.AddCard(new CardWarGame(CardValueEnum.Three, CardColorEnum.Clover));
            Hand2.AddCard(new CardWarGame(CardValueEnum.King, CardColorEnum.Clover));

            players.Add(1, Hand1);
            players.Add(2, Hand2);

            GameWar dealerWarGame = new GameWar(players);

            dealerWarGame.Play();
            GameHistory history = dealerWarGame.GetHistory();
            Assert.AreEqual(2, history.GetWinner());
        }

    }
}
