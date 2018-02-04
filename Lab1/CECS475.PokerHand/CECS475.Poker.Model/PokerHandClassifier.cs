using System;
using System.Collections.Generic;
using System.Text;

namespace CECS475.Poker.Cards
{
    public class PokerHandClassifier
    {
        public static PokerHand ClassifyHand(IEnumerable<Card> original)
        {
            List<Card> copy = (List<Card>) original;
            copy.Sort();
            int[] ofKind = new int[] { 1, 1 };
            int j = 0; //Used to go to next index in ofKind when some(2-4) kind is found
            bool isStraight = true;
            bool isFlush = true;
        
            for(int i = 0; i < 4; i++)
            {
                //Check for pairs, 3 & 4 of kinds
                if(copy[i].CompareTo(copy[i+1]) == 0)
                {
                    ofKind[j] = ofKind[j] + 1;
                }
                else if(ofKind[0] != 1)
                {
                    j = 1;
                }
                
                //Check for straight
                if(copy[i].Kind != copy[i+1].Kind - 1)
                {
                    isStraight = false;
                }
                //Check for flush
                if(copy[i].Suit.CompareTo(copy[i+1].Suit) != 0)
                {
                    isFlush = false;
                }
            }

            //Check Straight Flush
            if (isStraight && isFlush)
            {
                if((int) copy[0].Kind == 10)
                {
                    //Royal Flush
                    return new PokerHand((List<Card>)original, (PokerHand.HandType) 9);
                }
                else
                {
                    //Straight Flush
                    return new PokerHand((List<Card>)original, (PokerHand.HandType) 8);
                }
            }
            //Check Straight
            else if (isStraight)
            {
                return new PokerHand((List<Card>)original, (PokerHand.HandType) 4);
            }
            //Check Flush
            else if (isFlush)
            {
                return new PokerHand((List<Card>)original, (PokerHand.HandType) 5);
            }
            //Check 4 of Kind
            else if (ofKind[0] == 4)
            {
                return new PokerHand((List<Card>)original, (PokerHand.HandType) 7);
            }
            //Check Full House
            else if ((ofKind[0] == 2 && ofKind[1] == 3) || (ofKind[0] == 3 && ofKind[1] == 2))
            {
                return new PokerHand((List<Card>)original, (PokerHand.HandType)6);
            }
            //Check 3 of Kind
            else if(ofKind[0] == 3)
            {
                return new PokerHand((List<Card>)original, (PokerHand.HandType) 3);
            }
            //Check Pair
            else if(ofKind[0] == 2)
            {
                //Check if there is another Pair
                if (ofKind[1] == 2)
                {
                    //2 Pair
                    return new PokerHand((List<Card>) original, (PokerHand.HandType) 2);
                }
                else
                {
                    //Pair
                    return new PokerHand((List<Card>)original, (PokerHand.HandType) 1);
                }
            }
            else
            {
                //High Card
                return new PokerHand((List<Card>)original, (PokerHand.HandType) 0);
            }
        }
    }
}
