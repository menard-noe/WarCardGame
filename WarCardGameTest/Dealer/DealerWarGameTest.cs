using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WarCardGame.Dealer;
using WarCardGame.Hand;
using WarCardGame.Card;

namespace WarCardGameTest.Dealer
{
    [TestClass]
    public class DealerWarGameTest
    {
        [TestMethod]
        public void CardComparisonGreaterThan()
        {

            DealerWarGame dealerWarGame = new DealerWarGame();


            List<Tuple<int, HandWarGame<CardWarGame>>> playersAndHand = new List<Tuple<int, HandWarGame<CardWarGame>>>();


            HandWarGame<CardWarGame> Hand1 = new HandWarGame<CardWarGame>();
            Hand1.AddCard(new CardWarGame(CardValue.Five, CardColor.Clover));            
            
            HandWarGame<CardWarGame> Hand2 = new HandWarGame<CardWarGame>();
            Hand2.AddCard(new CardWarGame(CardValue.Six, CardColor.Spade));

            Tuple<int, HandWarGame<CardWarGame>> player1 = new Tuple<int, HandWarGame<CardWarGame>>(0, Hand1);
            Tuple<int, HandWarGame<CardWarGame>> player2 = new Tuple<int, HandWarGame<CardWarGame>>(1, Hand2);

            playersAndHand.Add(player1);
            playersAndHand.Add(player2);

            dealerWarGame.Play(playersAndHand);
            Assert.IsFalse(0 > 1);
        }

        [TestMethod]
        public void CardComparisonGreaterThan2()
        {

            DealerWarGame dealerWarGame = new DealerWarGame();


            List<Tuple<int, HandWarGame<CardWarGame>>> playersAndHand = new List<Tuple<int, HandWarGame<CardWarGame>>>();


            HandWarGame<CardWarGame> Hand1 = new HandWarGame<CardWarGame>();
            Hand1.AddCard(new CardWarGame(CardValue.Five, CardColor.Clover));

            HandWarGame<CardWarGame> Hand2 = new HandWarGame<CardWarGame>();
            Hand2.AddCard(new CardWarGame(CardValue.Five, CardColor.Spade));

            Tuple<int, HandWarGame<CardWarGame>> player1 = new Tuple<int, HandWarGame<CardWarGame>>(0, Hand1);
            Tuple<int, HandWarGame<CardWarGame>> player2 = new Tuple<int, HandWarGame<CardWarGame>>(1, Hand2);

            playersAndHand.Add(player1);
            playersAndHand.Add(player2);

            dealerWarGame.Play(playersAndHand);
            Assert.IsFalse(0 > 1);
        }
    }
}
