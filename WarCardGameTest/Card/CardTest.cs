using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WarCardGame.Card;

namespace WarCardGameTest.Card
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void CardComparisonGreaterThan()
        {
            CardWarGame a = new CardWarGame(CardValue.Five, CardColor.Clover);
            CardWarGame b = new CardWarGame(CardValue.Six, CardColor.Spade);

            Assert.IsFalse(a > b);
        }

        [TestMethod]
        public void CardComparisonGreaterThan2()
        {
            CardWarGame a = new CardWarGame(CardValue.Seven, CardColor.Clover);
            CardWarGame b = new CardWarGame(CardValue.Seven, CardColor.Spade);

            Assert.IsFalse(a > b);
        }

        [TestMethod]
        public void CardComparisonGreaterThan3()
        {
            CardWarGame a = new CardWarGame(CardValue.King, CardColor.Clover);
            CardWarGame b = new CardWarGame(CardValue.Ace, CardColor.Spade);

            Assert.IsFalse(a > b);
        }

        [TestMethod]
        public void CardComparisonSmallerThan()
        {
            CardWarGame a = new CardWarGame(CardValue.Five, CardColor.Clover);
            CardWarGame b = new CardWarGame(CardValue.Six, CardColor.Spade);

            Assert.IsTrue(a < b);
        }        
        
        [TestMethod]
        public void CardComparisonSmallerThan2()
        {
            CardWarGame a = new CardWarGame(CardValue.Seven, CardColor.Clover);
            CardWarGame b = new CardWarGame(CardValue.Seven, CardColor.Spade);

            Assert.IsFalse(a < b);
        }
    }
}
