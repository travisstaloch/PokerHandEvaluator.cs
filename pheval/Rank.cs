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

        public static Category get_category(int rank)
        {
            if (rank > 6185) return Category.HIGH_CARD;        // 1277 high card
            if (rank > 3325) return Category.ONE_PAIR;         // 2860 one pair
            if (rank > 2467) return Category.TWO_PAIR;         //  858 two pair
            if (rank > 1609) return Category.THREE_OF_A_KIND;  //  858 three-kind
            if (rank > 1599) return Category.STRAIGHT;         //   10 straights
            if (rank > 322) return Category.FLUSH;            // 1277 flushes
            if (rank > 166) return Category.FULL_HOUSE;       //  156 full house
            if (rank > 10) return Category.FOUR_OF_A_KIND;   //  156 four-kind
            return Category.STRAIGHT_FLUSH;                    //   10 straight-flushes
        }

        public static string describe_category(Category category)
        {
            return category_description[(int)category];
        }

        public static string describe_rank_category(int rank)
        {
            return category_description[(int)get_category(rank)];
        }

        public static string describe_rank(int rank)
        {
           return RankDesc.rank_description[rank,1];
        }

        //public static string describe_sample_hand(int rank)
        //{
        //    return rank_description[rank][0];
        //}

        public static bool is_flush(int rank)
        {
            switch (get_category(rank))
            {
                case Category.STRAIGHT_FLUSH:
                case Category.FLUSH:
                    return true;
                default:
                    return false;
            }
        }
    }
}