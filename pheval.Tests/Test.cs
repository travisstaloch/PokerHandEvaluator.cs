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
                    int rank = Eval.eval5Ids(ids);
                    int expected_rank = evaluate_5cards(ids[0], ids[1], ids[2], ids[3], ids[4]);
                    Assert.AreEqual(rank, expected_rank);
                }
                {
                    int rank = Eval.eval6Ids(ids);
                    int expected_rank = evaluate_6cards(ids[0], ids[1], ids[2], ids[3], ids[4], ids[5]);
                    Assert.AreEqual(rank, expected_rank);
                }
                {
                    int rank = Eval.eval7Ids(ids);
                    int expected_rank = evaluate_7cards(ids[0], ids[1], ids[2], ids[3], ids[4], ids[5], ids[6]);
                    Assert.AreEqual(rank, expected_rank);
                }
            }
        }
    }
}
