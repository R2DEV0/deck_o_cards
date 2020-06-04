using System;

namespace Deck_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck NewDeck = new Deck();

            Console.WriteLine(NewDeck.cards.Count);

            // Test the length of the deck after multiple deals //
            NewDeck.Deal();
            NewDeck.Deal();
            NewDeck.Deal();
            Console.WriteLine(NewDeck.cards.Count);

            // Test Deck.Reset() //
            NewDeck.Reset();
            Console.WriteLine(NewDeck.cards.Count);

            // Test Shuffle method //
            Console.WriteLine("Shuffling deck...");
            NewDeck.Shuffle();
            foreach (Card playingCard in NewDeck.cards)
            {
                Console.WriteLine($"{playingCard.StringVal} of {playingCard.Suit}, which has a numerical value of {playingCard.Val}");
            }

            // Instantiate a Player Object //
            Player PlayerOne = new Player(5, NewDeck);

            // Verify player has a hand of 5 playing cards //
            Console.WriteLine(PlayerOne.hand.Count);

            // Test discard method //
            Console.WriteLine();
            Console.WriteLine($"Discarding the card at index 3...");
            Console.WriteLine();

            PlayerOne.Discard(3);

            foreach (Card PC in PlayerOne.hand)
            {
                Console.WriteLine($"{PC.StringVal} of {PC.Suit}");
            }

            // Test that discard method returns null if index doesn't exist //
            Console.WriteLine(PlayerOne.Discard(12));
        }
    }
}
