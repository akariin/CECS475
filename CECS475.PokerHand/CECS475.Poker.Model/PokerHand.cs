using System;
using System.Collections.Generic;
using System.Text;

namespace CECS475.Poker.Cards
{
    public class PokerHand : IComparable<PokerHand>
    {
        public enum HandType
        {
            HighCard,
            Pair,
            TwoPair,
            ThreeOfKind,
            Straight,
            Flush,
            FullHouse,
            FourOfKind,
            StraightFlush,
            RoyalFlush
        }
        private List<Card> sortedHand = new List<Card>();
        public PokerHand(List<Card> pHand, HandType pType)
        {
            sortedHand = pHand;
            sortedHand.Sort();
            Hand = sortedHand;
            PokerHandType = pType;
        }
        public List<Card> Hand
        {
            get;
        }
        public HandType PokerHandType
        {
            get;
        }

        public int CompareTo(PokerHand other)
        {
            PokerHand h = other;
            int i = this.PokerHandType.CompareTo(h.PokerHandType);
            //Check if same hand type
            if (i == 0)
            {
                //Continously compare the high cards
                for (int j = 5; j > 0; j--)
                {
                    if (this.Hand[j - 1].CompareTo(h.Hand[j - 1]) != 0)
                    {
                        return this.Hand[j - 1].CompareTo(h.Hand[j - 1]);
                    }
                }
                return i;
            }
            else
            {
                return i;
            }
        }
    }
}
