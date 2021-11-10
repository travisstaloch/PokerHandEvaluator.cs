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
    public enum RankCategory
    {
        STRAIGHT_FLUSH = 1,
        FOUR_OF_A_KIND,
        FULL_HOUSE,
        FLUSH,
        STRAIGHT,
        THREE_OF_A_KIND,
        TWO_PAIR,
        ONE_PAIR,
        HIGH_CARD,
    }
    class Rank
    {
        static string[] rank_category_description = {
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

        public static RankCategory get_rank_category(int rank)
        {
            if (rank > 6185) return RankCategory.HIGH_CARD;        // 1277 high card
            if (rank > 3325) return RankCategory.ONE_PAIR;         // 2860 one pair
            if (rank > 2467) return RankCategory.TWO_PAIR;         //  858 two pair
            if (rank > 1609) return RankCategory.THREE_OF_A_KIND;  //  858 three-kind
            if (rank > 1599) return RankCategory.STRAIGHT;         //   10 straights
            if (rank > 322) return RankCategory.FLUSH;            // 1277 flushes
            if (rank > 166) return RankCategory.FULL_HOUSE;       //  156 full house
            if (rank > 10) return RankCategory.FOUR_OF_A_KIND;   //  156 four-kind
            return RankCategory.STRAIGHT_FLUSH;                    //   10 straight-flushes
        }

        public static string describe_rank_category(RankCategory category)
        {
            return rank_category_description[(int)category];
        }

        public static string describe_rank(int rank)
        {
            return rank_category_description[(int)get_rank_category(rank)];
        }

        //public static string describe_rank(int rank)
        //{
        //    return rank_description[rank][1];
        //}

        //public static string describe_sample_hand(int rank)
        //{
        //    return rank_description[rank][0];
        //}

        public static bool is_flush(int rank)
        {
            switch (get_rank_category(rank))
            {
                case RankCategory.STRAIGHT_FLUSH:
                case RankCategory.FLUSH:
                    return true;
                default:
                    return false;
            }
        }
    }
}