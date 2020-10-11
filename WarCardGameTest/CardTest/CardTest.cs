using Microsoft.VisualStudio.TestTools.UnitTesting;
using WarCardGame.Card;

namespace WarCardGameTest.CardTest
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void CardComparisonGreaterThan()
        {
            CardWarGame a = new CardWarGame(CardValueEnum.Five, CardColorEnum.Clover);
            CardWarGame b = new CardWarGame(CardValueEnum.Six, CardColorEnum.Spade);

            Assert.IsFalse(a > b);
        }

        [TestMethod]
        public void CardComparisonGreaterThan2()
        {
            CardWarGame a = new CardWarGame(CardValueEnum.Seven, CardColorEnum.Clover);
            CardWarGame b = new CardWarGame(CardValueEnum.Seven, CardColorEnum.Spade);

            Assert.IsFalse(a > b);
        }

        [TestMethod]
        public void CardComparisonGreaterThan3()
        {
            CardWarGame a = new CardWarGame(CardValueEnum.King, CardColorEnum.Clover);
            CardWarGame b = new CardWarGame(CardValueEnum.Ace, CardColorEnum.Spade);

            Assert.IsFalse(a > b);
        }

        [TestMethod]
        public void CardComparisonSmallerThan()
        {
            CardWarGame a = new CardWarGame(CardValueEnum.Five, CardColorEnum.Clover);
            CardWarGame b = new CardWarGame(CardValueEnum.Six, CardColorEnum.Spade);

            Assert.IsTrue(a < b);
        }

        [TestMethod]
        public void CardComparisonSmallerThan2()
        {
            CardWarGame a = new CardWarGame(CardValueEnum.Seven, CardColorEnum.Clover);
            CardWarGame b = new CardWarGame(CardValueEnum.Seven, CardColorEnum.Spade);

            Assert.IsFalse(a < b);
        }
    }
}
