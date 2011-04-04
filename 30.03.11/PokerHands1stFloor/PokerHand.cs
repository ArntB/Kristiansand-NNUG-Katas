using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    public class PokerHand
    {
        private string[] _hand;
        private Dictionary<char, int> _cardRanking = new Dictionary<char, int>
                                                         {
                                                             {'T',10},
                                                             {'J',11}, 
                                                             { 'Q', 12} , 
                                                             {'K', 13},
                                                             { 'A', 14}
                                                         };
        public PokerHand(string hand)
        {
            _hand = hand.Split(' ').OrderBy(GetRank).ToArray();
        }

        private int GetRank(string card)
        {
            if( card[0] > '9' )
            {
                return _cardRanking[card[0]];
            }

            return int.Parse(card[0].ToString());
        }

        public string[] Hand
        {
            get { return _hand; }
        }

        public bool IsPair()
        {
            //assuming the cards are sorted
            for (var i = 1; i < Hand.Length; i++ )
            {   
                if (Hand[i][0] == Hand[i-1][0])
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsThreeOfAKind()
        {
            for (var i = 2; i < Hand.Length; i++)
            {
                if (Hand[i][0] == Hand[i - 1][0] && Hand[i][0] == Hand[i - 2][0])
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsFourOfAKind()
        {
            for (var i = 3; i < Hand.Length; i++)
            {
                if (Hand[i][0] == Hand[i - 1][0] && Hand[i][0] == Hand[i - 2][0] && Hand[i][0] == Hand[i - 3][0])
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsDoublePair()
        {
            int paircount = 0;
            for (var i = 1; i < Hand.Length; i++)
            {
                if (Hand[i][0] == Hand[i - 1][0])
                {
                    paircount++;
                    i++;
                }
            }
            return paircount == 2;
        }

        public bool IsStraight()
        {
            for (var i = 1; i < Hand.Length; i++)
            {
                if (GetRank(Hand[i]) - GetRank(Hand[i - 1]) != 1)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsFlush()
        {
            for (var i = 1; i < Hand.Length; i++)
            {
                if(GetSuite(i) !=  GetSuite(i-1))
                {
                    return false;
                }
            }
            return true;
        }

        private char GetSuite(int i)
        {
            return Hand[i][1];
        }

        public bool IsFullHouse()
        {
            return IsThreeOfAKind() && IsPair();
        }
    }
}