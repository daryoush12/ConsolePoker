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
            hand[1] = new Card(2, CardCountry.hearts);
            hand[2] = new Card(3, CardCountry.hearts);
            hand[3] = new Card(4, CardCountry.hearts);
            hand[4] = new Card(5, CardCountry.hearts);

            Card[] hand2 = new Card[5];
            hand2[0] = new Card(1, CardCountry.diamonds);
            hand2[1] = new Card(2, CardCountry.diamonds);
            hand2[2] = new Card(3, CardCountry.diamonds);
            hand2[3] = new Card(4, CardCountry.diamonds);
            hand2[4] = new Card(5, CardCountry.diamonds);

            Card[] hand3 = new Card[5];
            hand3[0] = new Card(1, CardCountry.clubs);
            hand3[1] = new Card(2, CardCountry.clubs);
            hand3[2] = new Card(3, CardCountry.clubs);
            hand3[3] = new Card(4, CardCountry.clubs);
            hand3[4] = new Card(5, CardCountry.clubs);

            Card[] hand4 = new Card[5];
            hand4[0] = new Card(1, CardCountry.spades);
            hand4[1] = new Card(2, CardCountry.spades);
            hand4[2] = new Card(3, CardCountry.spades);
            hand4[3] = new Card(4, CardCountry.spades);
            hand4[4] = new Card(5, CardCountry.spades);

            Card[] hand5 = new Card[5];
            hand5[0] = new Card(1, CardCountry.diamonds);
            hand5[1] = new Card(2, CardCountry.hearts);
            hand5[2] = new Card(3, CardCountry.diamonds);
            hand5[3] = new Card(4, CardCountry.clubs);
            hand5[4] = new Card(5, CardCountry.spades);

            GameHandler Handler = new GameHandler();
            Assert.IsTrue(Handler.isFlush(hand));

            Assert.IsTrue(Handler.isFlush(hand2));

            Assert.IsTrue(Handler.isFlush(hand3));

            Assert.IsTrue(Handler.isFlush(hand4));

            Assert.IsFalse(Handler.isFlush(hand5));


        }

        [TestMethod]
        public void TestHandEvaluationStraight()
        {
            Card[] hand = new Card[5];
            hand[0] = new Card(1, CardCountry.hearts);
            hand[1] = new Card(2, CardCountry.hearts);
            hand[2] = new Card(3, CardCountry.hearts);
            hand[3] = new Card(4, CardCountry.hearts);
            hand[4] = new Card(5, CardCountry.hearts);

            GameHandler Handler = new GameHandler();
            Assert.IsTrue(Handler.isStraight(hand));
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

            GameHandler Handler = new GameHandler();
            Assert.IsTrue(Handler.isStraightFlush(hand));
        }

        [TestMethod]
        public void TestGameHandling()
        {

        }
    }
}
