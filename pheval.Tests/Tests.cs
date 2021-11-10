using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Linq;
using pheval;

namespace pheval.Tests
{
    [TestFixture()]
    public class Test
    {
        [DllImport("pheval")]
        public static extern int evaluate_5cards(int a, int b, int c, int d, int e);
        [DllImport("pheval")]
        public static extern int evaluate_6cards(int a, int b, int c, int d, int e, int f);
        [DllImport("pheval")]
        public static extern int evaluate_7cards(int a, int b, int c, int d, int e, int f, int g);

        [Test()]
        public void CompareRanks10K()
        {
            Random rnd = new Random();
            foreach (int _ in Enumerable.Range(0, 100000))
            {
                byte[] ids = Enumerable.Range(0, 52)
                    .OrderBy(x => rnd.Next())
                    .Take(7)
                    .Select(id => (byte)id)
                    .ToArray();
                Card[] cards = Card.Cards(ids);
                // Console.WriteLine(Card.CardsToString(cards));
                {
                    int rank = Eval.Eval5Ids(ids);
                    int expected_rank = evaluate_5cards(ids[0], ids[1], ids[2], ids[3], ids[4]);
                    Assert.AreEqual(rank, expected_rank);
                }
                {
                    int rank = Eval.Eval6Ids(ids);
                    int expected_rank = evaluate_6cards(ids[0], ids[1], ids[2], ids[3], ids[4], ids[5]);
                    Assert.AreEqual(rank, expected_rank);
                }
                {
                    int rank = Eval.Eval7Ids(ids);
                    int expected_rank = evaluate_7cards(ids[0], ids[1], ids[2], ids[3], ids[4], ids[5], ids[6]);
                    Assert.AreEqual(rank, expected_rank);
                }
            }
        }

        [Test()]
        public void Simple() 
        {
            {
                // convert Card to and from string
                Assert.AreEqual(0, (new Card("2c")).id);
                Assert.AreEqual(4, (new Card("3c")).id);
                Assert.AreEqual("2c", (new Card(0)).ToString());
                // convert 'hand' of Cards to and from string
                var ids = new byte[] { 0, 4, 8, 12, 16 };
                var hand = "2c3c4c5c6c";
                Assert.AreEqual(hand, Card.CardsToString(Card.Cards(ids)));
                Assert.AreEqual(ids, Card.Cards(hand).Select(c => c.id));
            }
            // check a few rank categories, their descriptions, and the rank description
            {
                int rank = Eval.Eval5String("ackcqcjctc");
                Assert.AreEqual(Rank.Category.STRAIGHT_FLUSH, Rank.get_category(rank));
                Assert.AreEqual("Straight Flush", Rank.describe_rank_category(rank));
                Assert.AreEqual("Royal Flush", Rank.describe_rank(rank));
            }
            {
                int rank = Eval.Eval5String("kcqcjctc9c");
                Assert.AreEqual(Rank.Category.STRAIGHT_FLUSH, Rank.get_category(rank));
                Assert.AreEqual("Straight Flush", Rank.describe_rank_category(rank));
                Assert.AreEqual("King-High Straight Flush", Rank.describe_rank(rank));
            }
            {
                int rank = Eval.Eval5String("7s5s4s3s2d");
                Assert.AreEqual(Rank.Category.HIGH_CARD, Rank.get_category(rank));
                Assert.AreEqual("High Card", Rank.describe_rank_category(rank));
                Assert.AreEqual("Seven-High", Rank.describe_rank(rank));
            }

        }
    }
}
