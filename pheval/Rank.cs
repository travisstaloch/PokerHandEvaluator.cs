/*
 *  Copyright 2016-2019 Henry Lee
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

namespace pheval
{
    public class Rank
    {
        public enum Category
        {
            StraightFlush = 1,
            FourOfAKind,
            FullHouse,
            Flush,
            Straight,
            ThreeOfAKind,
            TwoPair,
            OnePair,
            HighCard,
        }
        static string[] category_description = {
          "",
          "Straight Flush",
          "Four of a Kind",
          "Full House",
          "Flush",
          "Straight",
          "Three of a Kind",
          "Two Pair",
          "One Pair",
          "High Card",
        };

        public static Category GetCategory(int rank)
        {
            if (rank > 6185) return Category.HighCard;        // 1277 high card
            if (rank > 3325) return Category.OnePair;         // 2860 one pair
            if (rank > 2467) return Category.TwoPair;         //  858 two pair
            if (rank > 1609) return Category.ThreeOfAKind;  //  858 three-kind
            if (rank > 1599) return Category.Straight;         //   10 straights
            if (rank > 322) return Category.Flush;            // 1277 flushes
            if (rank > 166) return Category.FullHouse;       //  156 full house
            if (rank > 10) return Category.FourOfAKind;   //  156 four-kind
            return Category.StraightFlush;                    //   10 straight-flushes
        }

        public static string DescribeCategory(Category category)
        {
            return category_description[(int)category];
        }

        public static string DescribeRankCategory(int rank)
        {
            return category_description[(int)GetCategory(rank)];
        }

        public static string DescribeRank(int rank)
        {
           return RankDesc.rank_description[rank,1];
        }

        public static string DescribeRankShort(int rank)
        {
            return RankDesc.rank_description[rank,0];
        }

        public static bool IsFlush(int rank)
        {
            switch (GetCategory(rank))
            {
                case Category.StraightFlush:
                case Category.Flush:
                    return true;
                default:
                    return false;
            }
        }
    }
}