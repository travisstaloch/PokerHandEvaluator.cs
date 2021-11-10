using NUnit.Framework;

namespace pheval.Tests
{
  [TestFixture]
  public class KnownRanks
  {
    [Test]
    public void Value() {
      var a = Eval.Eval5String("9c4c4s9d4h");
      var b = Eval.Eval5String("9c4c4s9d9h");

      Assert.AreEqual(a, 292);
      Assert.AreEqual(b, 236);
    }

    [Test]
    public void Comparison() {
      var a = Eval.Eval5String("9c4c4s9d4h");
      var b = Eval.Eval5String("9c4c4s9d9h");

      Assert.Less(b, a);
      Assert.LessOrEqual(b, a);
      Assert.Greater(a, b);
      Assert.GreaterOrEqual(a, b);
      Assert.AreNotEqual(a, b);
      Assert.True(a != b);
    }

    [Test]
    public void RankCategory() {
      var a = Eval.Eval5String("9c4c4s9d4h");
      var b = Eval.Eval5String("AsKsQsJsTs");

      Assert.AreEqual(Rank.Category.FullHouse, Rank.GetCategory(a));
      Assert.AreEqual(Rank.Category.StraightFlush, Rank.GetCategory(b));

      Assert.AreEqual("Full House", Rank.DescribeRankCategory(a));
      Assert.AreEqual("Straight Flush", Rank.DescribeRankCategory(b));
    }

    [Test]
    public void RankCategoryStraightFlushes() {
      var a = Eval.Eval5String("AcKcQcJcTc");
      var b = Eval.Eval5String("2d3d4d5d6d");
      var c = Eval.Eval5String("Th7h9h6h8h");

      Assert.AreEqual(Rank.Category.StraightFlush, Rank.GetCategory(a));
      Assert.AreEqual(Rank.Category.StraightFlush, Rank.GetCategory(b));
      Assert.AreEqual(Rank.Category.StraightFlush, Rank.GetCategory(c));

      Assert.AreEqual("Straight Flush", Rank.DescribeRankCategory(a));
      Assert.AreEqual("Straight Flush", Rank.DescribeRankCategory(b));
      Assert.AreEqual("Straight Flush", Rank.DescribeRankCategory(c));
    }

    [Test]
    public void RankCategoryFourOfAKinds() {
      var a = Eval.Eval5String("AcAdAsAhKs");
      var b = Eval.Eval5String("2d2s2c2h3s");
      var c = Eval.Eval5String("ThTsTcTd7d");

      Assert.AreEqual(Rank.Category.FourOfAKind, Rank.GetCategory(a));
      Assert.AreEqual(Rank.Category.FourOfAKind, Rank.GetCategory(b));
      Assert.AreEqual(Rank.Category.FourOfAKind, Rank.GetCategory(c));

      Assert.AreEqual("Four of a Kind", Rank.DescribeRankCategory(a));
      Assert.AreEqual("Four of a Kind", Rank.DescribeRankCategory(b));
      Assert.AreEqual("Four of a Kind", Rank.DescribeRankCategory(c));
    }

    [Test]
    public void RankCategoryFullHouses() {
      var a = Eval.Eval5String("AcAdKcKhKs");
      var b = Eval.Eval5String("2d3d2c3h3s");
      var c = Eval.Eval5String("7h8s8h8c7d");

      Assert.AreEqual(Rank.Category.FullHouse, Rank.GetCategory(a));
      Assert.AreEqual(Rank.Category.FullHouse, Rank.GetCategory(b));
      Assert.AreEqual(Rank.Category.FullHouse, Rank.GetCategory(c));

      Assert.AreEqual("Full House", Rank.DescribeRankCategory(a));
      Assert.AreEqual("Full House", Rank.DescribeRankCategory(b));
      Assert.AreEqual("Full House", Rank.DescribeRankCategory(c));
    }

    [Test]
    public void RankCategoryFlushes() {
      var a = Eval.Eval5String("Ac2c7cJcTc");
      var b = Eval.Eval5String("Kd3d8dTd5d");
      var c = Eval.Eval5String("Jh5h4h9hTh");

      Assert.AreEqual(Rank.Category.Flush, Rank.GetCategory(a));
      Assert.AreEqual(Rank.Category.Flush, Rank.GetCategory(b));
      Assert.AreEqual(Rank.Category.Flush, Rank.GetCategory(c));

      Assert.AreEqual("Flush", Rank.DescribeRankCategory(a));
      Assert.AreEqual("Flush", Rank.DescribeRankCategory(b));
      Assert.AreEqual("Flush", Rank.DescribeRankCategory(c));
    }

    [Test]
    public void RankCategoryStraights() {
      var a = Eval.Eval5String("AcKdQsJhTc");
      var b = Eval.Eval5String("KdQsJsTh9d");
      var c = Eval.Eval5String("6h5s4s3d2c");

      Assert.AreEqual(Rank.Category.Straight, Rank.GetCategory(a));
      Assert.AreEqual(Rank.Category.Straight, Rank.GetCategory(b));
      Assert.AreEqual(Rank.Category.Straight, Rank.GetCategory(c));

      Assert.AreEqual("Straight", Rank.DescribeRankCategory(a));
      Assert.AreEqual("Straight", Rank.DescribeRankCategory(b));
      Assert.AreEqual("Straight", Rank.DescribeRankCategory(c));
    }

    [Test]
    public void RankCategoryThreeOfAKinds() {
      var a = Eval.Eval5String("AcAdAsJhTc");
      var b = Eval.Eval5String("3d2sJs3h3c");
      var c = Eval.Eval5String("8h5s5d3d5c");

      Assert.AreEqual(Rank.Category.ThreeOfAKind, Rank.GetCategory(a));
      Assert.AreEqual(Rank.Category.ThreeOfAKind, Rank.GetCategory(b));
      Assert.AreEqual(Rank.Category.ThreeOfAKind, Rank.GetCategory(c));

      Assert.AreEqual("Three of a Kind", Rank.DescribeRankCategory(a));
      Assert.AreEqual("Three of a Kind", Rank.DescribeRankCategory(b));
      Assert.AreEqual("Three of a Kind", Rank.DescribeRankCategory(c));
    }

    [Test]
    public void RankCategoryTwoPairs() {
      var a = Eval.Eval5String("AcAdJsJhTc");
      var b = Eval.Eval5String("3d2sJs2h3c");
      var c = Eval.Eval5String("8h7s5d8d5c");

      Assert.AreEqual(Rank.Category.TwoPair, Rank.GetCategory(a));
      Assert.AreEqual(Rank.Category.TwoPair, Rank.GetCategory(b));
      Assert.AreEqual(Rank.Category.TwoPair, Rank.GetCategory(c));

      Assert.AreEqual("Two Pair", Rank.DescribeRankCategory(a));
      Assert.AreEqual("Two Pair", Rank.DescribeRankCategory(b));
      Assert.AreEqual("Two Pair", Rank.DescribeRankCategory(c));
    }

    [Test]
    public void RankCategoryOnePairs() {
      var a = Eval.Eval5String("AcAd7sJhTc");
      var b = Eval.Eval5String("9d2sJs2h3c");
      var c = Eval.Eval5String("2h6s5d8d5c");

      Assert.AreEqual(Rank.Category.OnePair, Rank.GetCategory(a));
      Assert.AreEqual(Rank.Category.OnePair, Rank.GetCategory(b));
      Assert.AreEqual(Rank.Category.OnePair, Rank.GetCategory(c));

      Assert.AreEqual("One Pair", Rank.DescribeRankCategory(a));
      Assert.AreEqual("One Pair", Rank.DescribeRankCategory(b));
      Assert.AreEqual("One Pair", Rank.DescribeRankCategory(c));
    }

    [Test]
    public void RankCategoryHighCards() {
      var a = Eval.Eval5String("Ac2d7sJhTc");
      var b = Eval.Eval5String("9d2s6cTs3c");
      var c = Eval.Eval5String("2hQs5d7d3c");

      Assert.AreEqual(Rank.Category.HighCard, Rank.GetCategory(a));
      Assert.AreEqual(Rank.Category.HighCard, Rank.GetCategory(b));
      Assert.AreEqual(Rank.Category.HighCard, Rank.GetCategory(c));

      Assert.AreEqual("High Card", Rank.DescribeRankCategory(a));
      Assert.AreEqual("High Card", Rank.DescribeRankCategory(b));
      Assert.AreEqual("High Card", Rank.DescribeRankCategory(c));
    }

    [Test]
    public void RankDescription() {
      var a = Eval.Eval5String("9c4c4s9d4h");
      var b = Eval.Eval5String("AsKsQsJsTs");

      Assert.AreEqual("Fours Full over Nines", Rank.DescribeRank(a));
      Assert.AreEqual("Royal Flush", Rank.DescribeRank(b));

      Assert.AreEqual("44499", Rank.DescribeRankShort(a));
      Assert.AreEqual("AKQJT", Rank.DescribeRankShort(b));

      Assert.False(Rank.IsFlush(a));
      Assert.True(Rank.IsFlush(b));
    }

    [Test]
    public void RankDescriptionStraightFlushes() {
      var a = Eval.Eval5String("6s2s5s3s4s");
      var b = Eval.Eval5String("8dTdJdQd9d");
      var c = Eval.Eval5String("6h8h5h7h4h");

      Assert.AreEqual("Six-High Straight Flush", Rank.DescribeRank(a));
      Assert.AreEqual("Queen-High Straight Flush", Rank.DescribeRank(b));
      Assert.AreEqual("Eight-High Straight Flush", Rank.DescribeRank(c));

      Assert.AreEqual("65432", Rank.DescribeRankShort(a));
      Assert.AreEqual("QJT98", Rank.DescribeRankShort(b));
      Assert.AreEqual("87654", Rank.DescribeRankShort(c));


      Assert.True(Rank.IsFlush(a));
      Assert.True(Rank.IsFlush(b));
      Assert.True(Rank.IsFlush(c));
    }

    [Test]
    public void RankDescriptionFourOfAKinds() {
      var a = Eval.Eval5String("AsAdAc2sAh");
      var b = Eval.Eval5String("QsQc3dQdQh");
      var c = Eval.Eval5String("3d3c8c3h3s");

      Assert.AreEqual("Four Aces", Rank.DescribeRank(a));
      Assert.AreEqual("Four Queens", Rank.DescribeRank(b));
      Assert.AreEqual("Four Treys", Rank.DescribeRank(c));

      Assert.AreEqual("AAAA2", Rank.DescribeRankShort(a));
      Assert.AreEqual("QQQQ3", Rank.DescribeRankShort(b));
      Assert.AreEqual("33338", Rank.DescribeRankShort(c));

      Assert.False(Rank.IsFlush(a));
      Assert.False(Rank.IsFlush(b));
      Assert.False(Rank.IsFlush(c));
    }

    [Test]
    public void RankDescriptionFullHouses() {
      var a = Eval.Eval5String("As2dAc2sAh");
      var b = Eval.Eval5String("3cQc3d3sQh");
      var c = Eval.Eval5String("8d7d8c8s7h");

      Assert.AreEqual("Aces Full over Deuces", Rank.DescribeRank(a));
      Assert.AreEqual("Treys Full over Queens", Rank.DescribeRank(b));
      Assert.AreEqual("Eights Full over Sevens", Rank.DescribeRank(c));

      Assert.AreEqual("AAA22", Rank.DescribeRankShort(a));
      Assert.AreEqual("333QQ", Rank.DescribeRankShort(b));
      Assert.AreEqual("88877", Rank.DescribeRankShort(c));

      Assert.False(Rank.IsFlush(a));
      Assert.False(Rank.IsFlush(b));
      Assert.False(Rank.IsFlush(c));
    }

    [Test]
    public void RankDescriptionFlushes() {
      var a = Eval.Eval5String("As2s3s7sTs");
      var b = Eval.Eval5String("2cQcTc7c4c");
      var c = Eval.Eval5String("2d4d3d8d5d");

      Assert.AreEqual("Ace-High Flush", Rank.DescribeRank(a));
      Assert.AreEqual("Queen-High Flush", Rank.DescribeRank(b));
      Assert.AreEqual("Eight-High Flush", Rank.DescribeRank(c));

      Assert.AreEqual("AT732", Rank.DescribeRankShort(a));
      Assert.AreEqual("QT742", Rank.DescribeRankShort(b));
      Assert.AreEqual("85432", Rank.DescribeRankShort(c));

      Assert.True(Rank.IsFlush(a));
      Assert.True(Rank.IsFlush(b));
      Assert.True(Rank.IsFlush(c));
    }

    [Test]
    public void RankDescriptionStraights() {
      var a = Eval.Eval5String("AsKcQdJdTh");
      var b = Eval.Eval5String("KsQcJdTd9h");
      var c = Eval.Eval5String("5h4d3d2cAs");

      Assert.AreEqual("Ace-High Straight", Rank.DescribeRank(a));
      Assert.AreEqual("King-High Straight", Rank.DescribeRank(b));
      Assert.AreEqual("Five-High Straight", Rank.DescribeRank(c));

      Assert.AreEqual("AKQJT", Rank.DescribeRankShort(a));
      Assert.AreEqual("KQJT9", Rank.DescribeRankShort(b));
      Assert.AreEqual("5432A", Rank.DescribeRankShort(c));

      Assert.False(Rank.IsFlush(a));
      Assert.False(Rank.IsFlush(b));
      Assert.False(Rank.IsFlush(c));

      Assert.AreEqual(Rank.Category.Straight, Rank.GetCategory(a));
      Assert.AreEqual(Rank.Category.Straight, Rank.GetCategory(b));
      Assert.AreEqual(Rank.Category.Straight, Rank.GetCategory(c));
    }

    [Test]
    public void RankDescriptionThreeOfAKinds() {
      var a = Eval.Eval5String("As2sAdAcTs");
      var b = Eval.Eval5String("6d6c2h6s4c");
      var c = Eval.Eval5String("9s4d9d8d9h");

      Assert.AreEqual("Three Aces", Rank.DescribeRank(a));
      Assert.AreEqual("Three Sixes", Rank.DescribeRank(b));
      Assert.AreEqual("Three Nines", Rank.DescribeRank(c));

      Assert.AreEqual("AAAT2", Rank.DescribeRankShort(a));
      Assert.AreEqual("66642", Rank.DescribeRankShort(b));
      Assert.AreEqual("99984", Rank.DescribeRankShort(c));

      Assert.False(Rank.IsFlush(a));
      Assert.False(Rank.IsFlush(b));
      Assert.False(Rank.IsFlush(c));
    }

    [Test]
    public void RankDescriptionTwoPairs() {
      var a = Eval.Eval5String("As2sAdTcTs");
      var b = Eval.Eval5String("6d2c4h6s4c");
      var c = Eval.Eval5String("9s7d9d7sAh");

      Assert.AreEqual("Aces and Tens", Rank.DescribeRank(a));
      Assert.AreEqual("Sixes and Fours", Rank.DescribeRank(b));
      Assert.AreEqual("Nines and Sevens", Rank.DescribeRank(c));

      Assert.AreEqual("AATT2", Rank.DescribeRankShort(a));
      Assert.AreEqual("66442", Rank.DescribeRankShort(b));
      Assert.AreEqual("9977A", Rank.DescribeRankShort(c));

      Assert.False(Rank.IsFlush(a));
      Assert.False(Rank.IsFlush(b));
      Assert.False(Rank.IsFlush(c));
    }

    [Test]
    public void RankDescriptionOnePairs() {
      var a = Eval.Eval5String("Qs2sQh3cTs");
      var b = Eval.Eval5String("5s2c3h6s3c");
      var c = Eval.Eval5String("TsQdTd7sAh");

      Assert.AreEqual("Pair of Queens", Rank.DescribeRank(a));
      Assert.AreEqual("Pair of Treys", Rank.DescribeRank(b));
      Assert.AreEqual("Pair of Tens", Rank.DescribeRank(c));

      Assert.AreEqual("QQT32", Rank.DescribeRankShort(a));
      Assert.AreEqual("33652", Rank.DescribeRankShort(b));
      Assert.AreEqual("TTAQ7", Rank.DescribeRankShort(c));

      Assert.False(Rank.IsFlush(a));
      Assert.False(Rank.IsFlush(b));
      Assert.False(Rank.IsFlush(c));
    }

    [Test]
    public void RankDescriptionHighCards() {
      var a = Eval.Eval5String("6s7s2d3c4h");
      var b = Eval.Eval5String("Qs3cAhKc2d");
      var c = Eval.Eval5String("4h9sTd7s2d");

      Assert.AreEqual("Seven-High", Rank.DescribeRank(a));
      Assert.AreEqual("Ace-High", Rank.DescribeRank(b));
      Assert.AreEqual("Ten-High", Rank.DescribeRank(c));

      Assert.AreEqual("76432", Rank.DescribeRankShort(a));
      Assert.AreEqual("AKQ32", Rank.DescribeRankShort(b));
      Assert.AreEqual("T9742", Rank.DescribeRankShort(c));

      Assert.False(Rank.IsFlush(a));
      Assert.False(Rank.IsFlush(b));
      Assert.False(Rank.IsFlush(c));
    }
  }
}