using System;
using System.Collections.Generic;
using CECS475.Poker.Cards;
namespace PrintTest
{
    class Program
    {
        static void Main(string[] args)
        {
            PokerHand h1 = PokerHandClassifier.ClassifyHand(new List<Card> {
                new Card(Card.CardKind.Queen, Card.CardSuit.Clubs),
                new Card(Card.CardKind.Jack, Card.CardSuit.Clubs),
                new Card(Card.CardKind.Ten, Card.CardSuit.Hearts),
                new Card(Card.CardKind.Two, Card.CardSuit.Diamonds),
                new Card(Card.CardKind.Five, Card.CardSuit.Spades)});

            PokerHand h2 = PokerHandClassifier.ClassifyHand(new List<Card> {
                new Card(Card.CardKind.Queen, Card.CardSuit.Diamonds),
                new Card(Card.CardKind.Jack, Card.CardSuit.Diamonds),
                new Card(Card.CardKind.Three, Card.CardSuit.Hearts),
                new Card(Card.CardKind.Two, Card.CardSuit.Diamonds),
                new Card(Card.CardKind.Five, Card.CardSuit.Spades)});

            Console.WriteLine(h1.CompareTo(h2));

        }
    }
}
