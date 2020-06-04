using System;
using System.Collections.Generic;
using System.Linq;


namespace Deck_of_Cards
{
// ///////////////////////////////////////  CARD CLASS //////////////////////////////////////////////////////////////
    public class Card
    {
        private string stringVal; // Ace, 2,3,4,5,6,7,8,9,10, Jack, Queen, King
        private string suit; // Clubs, Spades, Hearts, Diamonds
        private int val; // 1 - 13
        public string StringVal
        {
            get {return this.stringVal;}
            set {stringVal = value;}
        }
        public string Suit
        {
            get {return this.suit;}
            set {suit = value;}
        }
        public int Val
        {
            get {return this.val;}
            set {val = value;}
        }
    }

// ///////////////////////////////////////  DECK CLASS ////////////////////////////////////////////////////////////////
    public class Deck
    {
        // arrays for building the deck //
        private string[] StringValues = {"Ace","2","3","4","5","6","7","8","9","10","Jack","Queen","King"};
        private string[] Suits = {"Clubs", "Spades", "Hearts", "Diamonds"};
        private int[] IntValues = {1,2,3,4,5,6,7,8,9,10,11,12,13};
        // Dictonary for associating string valsues with int valsues //
        private Dictionary<string, int> CardIntValues = new Dictionary<string, int>();
        //List for storing the cards //
        public List<Card> cards = new List<Card>();
        // constructor for building new deck //
        public Deck()
        {
            for(int i=0; i < StringValues.Length; i++)
            {
                CardIntValues[StringValues[i]] = IntValues[i]; 
            }
            BuildDeck();
        }
        private void BuildDeck()
        {
            foreach(string suit in Suits)
            {
                foreach(string val in StringValues)
                {
                    Card playingCard = new Card();
                    playingCard.Suit = suit;
                    playingCard.StringVal = val;
                    playingCard.Val = CardIntValues[val];
                    cards.Add(playingCard);
                }
            }
        }
        public Card Deal()
        {
            Card card = cards[cards.Count - 1];

            this.cards.RemoveAt(cards.Count - 1);
            return card;
        }
        public void Reset()
        {
            this.cards = new List<Card>();
            this.BuildDeck();
        }
        public void Shuffle()
        {
            Random rand = new Random();
            int n = this.cards.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n+1);
                Card Temp = cards[k];
                cards[k] = cards[n];
                cards[n] = Temp;
            }
        }
    }


// ///////////////////////////////////////  PLAYER CLASS ////////////////////////////////////////////////////////////////

    public class Player
    {
        private string Name;
        public string name
        {
            get{return this.Name;}
            set{this.Name = value;}
        }
        private List<Card> Hand;
        public List<Card> hand
        {
            get{return this.Hand;}
            set{this.Hand = value;}
        }
        // constructor //
        public Player(int handSize, Deck deck)
        {
            List<Card> newHand = new List<Card>();

            for(int i=0; i<handSize; i++)
            {
                newHand.Add(deck.Deal());
            }
            this.Hand = newHand;
        }
        public Card Draw(Deck deck)
        {
            Card NewCard = deck.Deal();
            this.hand.Add(NewCard);
            return NewCard;
        }
        public Card Discard(int idx)
        {
            if(this.hand.ElementAtOrDefault(idx)!=null)
            {
                Card card = this.hand[idx];
                this.hand.RemoveAt(idx);
                return card;
            }
            else
            {
                Console.WriteLine("null");
                return null;
            }
        }
    }
}