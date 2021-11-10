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
        [Test]
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
                Assert.AreEqual(Rank.Category.StraightFlush, Rank.GetCategory(rank));
                Assert.AreEqual("Straight Flush", Rank.DescribeRankCategory(rank));
                Assert.AreEqual("Royal Flush", Rank.DescribeRank(rank));
            }
            {
                int rank = Eval.Eval5String("kcqcjctc9c");
                Assert.AreEqual(Rank.Category.StraightFlush, Rank.GetCategory(rank));
                Assert.AreEqual("Straight Flush", Rank.DescribeRankCategory(rank));
                Assert.AreEqual("King-High Straight Flush", Rank.DescribeRank(rank));
            }
            {
                int rank = Eval.Eval5String("7s5s4s3s2d");
                Assert.AreEqual(Rank.Category.HighCard, Rank.GetCategory(rank));
                Assert.AreEqual("High Card", Rank.DescribeRankCategory(rank));
                Assert.AreEqual("Seven-High", Rank.DescribeRank(rank));
            }
        }

        [DllImport("pheval")]
        public static extern int evaluate_5cards(int a, int b, int c, int d, int e);
        [DllImport("pheval")]
        public static extern int evaluate_6cards(int a, int b, int c, int d, int e, int f);
        [DllImport("pheval")]
        public static extern int evaluate_7cards(int a, int b, int c, int d, int e, int f, int g);

        [Test]
        public void CompareRanks1K()
        {
            Random rnd = new Random();
            foreach (int _ in Enumerable.Range(0, 1000))
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


        [Test]
        public void All5CardCombos() 
        {
            for (byte a = 0;  a < 48; a += 1) {
                for (byte b = (byte)(a + 1); b <  49; b += 1) {
                    for (byte c = (byte)(b + 1); c <  50; c += 1) {
                        for (byte d = (byte)(c + 1); d <  51; d += 1) {
                            for (byte e = (byte)(d + 1); e <  52; e += 1) {
                                int expected_rank = evaluate_5cards(a, b, c, d, e);
                                int actual_rank = Eval.Eval5(a, b, c, d, e);
                                Assert.AreEqual(expected_rank, actual_rank);
                            }
                        }
                    }
                }
            }
        }

        [Test]
        public void All6CardCombos()
        {
            for (byte a = 0;  a < 47; a += 1) {
                for (byte b = (byte)(a + 1); b <  48; b += 1) {
                    for (byte c = (byte)(b + 1); c <  49; c += 1) {
                        for (byte d = (byte)(c + 1); d <  50; d += 1) {
                            for (byte e = (byte)(d + 1); e <  51; e += 1) {
                                for (byte f = (byte)(e + 1); f <  52; f += 1) {
                                    int expected_rank = evaluate_6cards(a, b, c, d, e, f);
                                    int actual_rank = Eval.Eval6(a, b, c, d, e, f);
                                    Assert.AreEqual(expected_rank, actual_rank);
                                }
                            }
                        }
                    }
                }
            }
        }

        [Test]
        public void All7CardCombos()
        {
            for (byte a = 0;  a < 46; a += 1) {
                for (byte b = (byte)(a + 1); b <  47; b += 1) {
                    for (byte c = (byte)(b + 1); c <  48; c += 1) {
                        for (byte d = (byte)(c + 1); d <  49; d += 1) {
                            for (byte e = (byte)(d + 1); e <  50; e += 1) {
                                for (byte f = (byte)(e + 1); f <  51; f += 1) {
                                    for (byte g = (byte)(f + 1); g <  52; g += 1) {
                                        int expected_rank = evaluate_7cards(a, b, c, d, e, f, g);
                                        int actual_rank = Eval.Eval7(a, b, c, d, e, f, g);
                                        Assert.AreEqual(expected_rank, actual_rank);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
