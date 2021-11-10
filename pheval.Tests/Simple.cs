using NUnit.Framework;
using System.Linq;

namespace pheval.Tests
{
[TestFixture]
public class Simple
{
    [Test]
    public void Conversion()
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

    [Test]
    public void RankCategories()
    {
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
}
}