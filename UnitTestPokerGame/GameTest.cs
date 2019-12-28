using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerGame;

namespace UnitTestPokerGame
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void TestHandEvaluationFlush()
        {
            Card[] hand = new Card[5];
            hand[0] = new Card(1, CardCountry.hearts);
            hand[1] = new Card(7, CardCountry.hearts);
            hand[2] = new Card(3, CardCountry.hearts);
            hand[3] = new Card(7, CardCountry.hearts);
            hand[4] = new Card(5, CardCountry.hearts);

            Card[] hand2 = new Card[5];
            hand2[0] = new Card(1, CardCountry.diamonds);
            hand2[1] = new Card(7, CardCountry.diamonds);
            hand2[2] = new Card(3, CardCountry.diamonds);
            hand2[3] = new Card(7, CardCountry.diamonds);
            hand2[4] = new Card(5, CardCountry.diamonds);

            Card[] hand3 = new Card[5];
            hand3[0] = new Card(1, CardCountry.clubs);
            hand3[1] = new Card(7, CardCountry.clubs);
            hand3[2] = new Card(3, CardCountry.clubs);
            hand3[3] = new Card(10, CardCountry.clubs);
            hand3[4] = new Card(5, CardCountry.clubs);

            Card[] hand4 = new Card[5];
            hand4[0] = new Card(1, CardCountry.spades);
            hand4[1] = new Card(5, CardCountry.spades);
            hand4[2] = new Card(10, CardCountry.spades);
            hand4[3] = new Card(4, CardCountry.spades);
            hand4[4] = new Card(12, CardCountry.spades);

            Card[] hand5 = new Card[5];
            hand5[0] = new Card(7, CardCountry.diamonds);
            hand5[1] = new Card(2, CardCountry.hearts);
            hand5[2] = new Card(10, CardCountry.diamonds);
            hand5[3] = new Card(7, CardCountry.clubs);
            hand5[4] = new Card(5, CardCountry.spades);

            HandEvaluator eval = new HandEvaluator();
            HandType result1 = eval.Evaluate(hand);
            HandType result2 = eval.Evaluate(hand2);
            HandType result3 = eval.Evaluate(hand3);
            HandType result4 = eval.Evaluate(hand4);
            HandType result5 = eval.Evaluate(hand5);

            Assert.AreEqual("Flush",result1.name);
            Assert.AreEqual("Flush", result2.name);
            Assert.AreEqual("Flush", result3.name);
            Assert.AreEqual("Flush", result4.name);
            Assert.AreEqual("Nothing", result5.name);

        }

        [TestMethod]
        public void TestHandEvaluationStraight()
        {
            Card[] hand = new Card[5];
            hand[0] = new Card(1, CardCountry.hearts);
            hand[1] = new Card(2, CardCountry.clubs);
            hand[2] = new Card(3, CardCountry.hearts);
            hand[3] = new Card(4, CardCountry.hearts);
            hand[4] = new Card(5, CardCountry.hearts);


            HandEvaluator eval = new HandEvaluator();
            HandType result1 = eval.Evaluate(hand);
            Assert.AreEqual("Straight", result1.name);
        }

        [TestMethod]
        public void TestHandEvaluationStraightFlush()
        {
            Card[] hand = new Card[5];
            hand[0] = new Card(1, CardCountry.hearts);
            hand[1] = new Card(2, CardCountry.hearts);
            hand[2] = new Card(3, CardCountry.hearts);
            hand[3] = new Card(4, CardCountry.hearts);
            hand[4] = new Card(5, CardCountry.hearts);

            HandEvaluator eval = new HandEvaluator();
            HandType result1 = eval.Evaluate(hand);
            Assert.AreEqual("Royal Flush", result1.name);
        }

        [TestMethod]
        public void TestHandEvaluation2Pairs()
        {
            Card[] hand = new Card[5];
            hand[0] = new Card(2, CardCountry.hearts);
            hand[1] = new Card(2, CardCountry.spades);
            hand[2] = new Card(4, CardCountry.hearts);
            hand[3] = new Card(4, CardCountry.spades);
            hand[4] = new Card(5, CardCountry.hearts);

            GameHandler Handler = new GameHandler();
            //Assert.IsTrue(Handler.is2Pairs(hand));
        }

        [TestMethod]
        public void TestHandEvaluationThreeOfKind()
        {
            Card[] hand = new Card[5];
            hand[0] = new Card(2, CardCountry.hearts);
            hand[1] = new Card(2, CardCountry.spades);
            hand[2] = new Card(2, CardCountry.diamonds);
            hand[3] = new Card(4, CardCountry.spades);
            hand[4] = new Card(5, CardCountry.hearts);

            HandEvaluator eval = new HandEvaluator();
            HandType result1 = eval.Evaluate(hand);
            Assert.AreEqual("Three of kind", result1.name);
        }
    }
}
