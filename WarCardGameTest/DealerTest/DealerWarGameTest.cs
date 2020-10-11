using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WarCardGame.Dealer;
using WarCardGame.Hand;
using WarCardGame.Card;
using System;

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
            Hand1.AddCard(new CardWarGame(CardValue.Five, CardColor.Clover));

            HandWarGame<CardWarGame> Hand2 = new HandWarGame<CardWarGame>();
            Hand2.AddCard(new CardWarGame(CardValue.Six, CardColor.Spade));

            players.Add(1, Hand1);
            players.Add(2, Hand2);

            DealerWarGame dealerWarGame = new DealerWarGame(players);

            dealerWarGame.Play();
            GameHistory history = dealerWarGame.GetHistory();
            Assert.AreEqual(2, history.GetWinner());
        }

        [TestMethod]
        public void HandOneCardEqualValueTest()
        {
            Dictionary<int, HandWarGame<CardWarGame>> players = new Dictionary<int, HandWarGame<CardWarGame>>();

            HandWarGame<CardWarGame> Hand1 = new HandWarGame<CardWarGame>();
            Hand1.AddCard(new CardWarGame(CardValue.Five, CardColor.Clover));

            HandWarGame<CardWarGame> Hand2 = new HandWarGame<CardWarGame>();
            Hand2.AddCard(new CardWarGame(CardValue.Five, CardColor.Spade));

            players.Add(1, Hand1);
            players.Add(2, Hand2);

            DealerWarGame dealerWarGame = new DealerWarGame(players);

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
            Hand1.AddCard(new CardWarGame(CardValue.Five, CardColor.Spade));

            HandWarGame<CardWarGame> Hand2 = new HandWarGame<CardWarGame>();
            Hand2.AddCard(new CardWarGame(CardValue.Five, CardColor.Spade));

            players.Add(1, Hand1);
            players.Add(2, Hand2);

            DealerWarGame dealerWarGame = new DealerWarGame(players);

            dealerWarGame.Play();
        }        
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SameCardInDifferentHandTest2()
        {
            Dictionary<int, HandWarGame<CardWarGame>> players = new Dictionary<int, HandWarGame<CardWarGame>>();

            CardWarGame card = new CardWarGame(CardValue.Five, CardColor.Spade);

            HandWarGame<CardWarGame> Hand1 = new HandWarGame<CardWarGame>();
            Hand1.AddCard(card);

            HandWarGame<CardWarGame> Hand2 = new HandWarGame<CardWarGame>();
            Hand2.AddCard(card);

            players.Add(1, Hand1);
            players.Add(2, Hand2);

            DealerWarGame dealerWarGame = new DealerWarGame(players);

            dealerWarGame.Play();
        }        
        
        [TestMethod]
        public void TieBreakSameNumberOfCardTest()
        {
            Dictionary<int, HandWarGame<CardWarGame>> players = new Dictionary<int, HandWarGame<CardWarGame>>();

            HandWarGame<CardWarGame> Hand1 = new HandWarGame<CardWarGame>();
            Hand1.AddCard(new CardWarGame(CardValue.Five, CardColor.Spade));
            Hand1.AddCard(new CardWarGame(CardValue.Three, CardColor.Spade));
            Hand1.AddCard(new CardWarGame(CardValue.Ace, CardColor.Spade));

            HandWarGame<CardWarGame> Hand2 = new HandWarGame<CardWarGame>();
            Hand2.AddCard(new CardWarGame(CardValue.Five, CardColor.Clover));
            Hand2.AddCard(new CardWarGame(CardValue.Ace, CardColor.Clover));
            Hand2.AddCard(new CardWarGame(CardValue.King, CardColor.Clover));

            players.Add(1, Hand1);
            players.Add(2, Hand2);

            DealerWarGame dealerWarGame = new DealerWarGame(players);

            dealerWarGame.Play();
            GameHistory history = dealerWarGame.GetHistory();
            Assert.AreEqual(1, history.GetWinner());
        }        
        
        [TestMethod]
        public void TieBreakNotTheSameNumberOfCardTest()
        {
            Dictionary<int, HandWarGame<CardWarGame>> players = new Dictionary<int, HandWarGame<CardWarGame>>();

            HandWarGame<CardWarGame> Hand1 = new HandWarGame<CardWarGame>();
            Hand1.AddCard(new CardWarGame(CardValue.Five, CardColor.Spade));
            Hand1.AddCard(new CardWarGame(CardValue.Ace, CardColor.Spade));

            HandWarGame<CardWarGame> Hand2 = new HandWarGame<CardWarGame>();
            Hand2.AddCard(new CardWarGame(CardValue.Five, CardColor.Clover));
            Hand2.AddCard(new CardWarGame(CardValue.Three, CardColor.Clover));
            Hand2.AddCard(new CardWarGame(CardValue.King, CardColor.Clover));

            players.Add(1, Hand1);
            players.Add(2, Hand2);

            DealerWarGame dealerWarGame = new DealerWarGame(players);

            dealerWarGame.Play();
            GameHistory history = dealerWarGame.GetHistory();
            Assert.AreEqual(2, history.GetWinner());
        }

    }
}
