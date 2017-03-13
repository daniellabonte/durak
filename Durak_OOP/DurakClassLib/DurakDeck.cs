/**DurackDeck.cs
 * 
 * Class that build a list of PlayingCard objects that represent a deck of cards
 * 
 * Author:  
 * Since:   January 25, 2017
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakClassLibrary
{
    /// <summary>
    /// Enumeration for the different sizes of decks for durak gameplay
    /// </summary>
    enum DeckSize
    {
        Small = 20,
        Medium = 36,
        Large = 52
    }

    public class DurakDeck
    {
        /// <summary>
        /// List of playing cards that comprise the DurackDeck object
        /// </summary>
        public List<PlayingCard> myDeck = new List<PlayingCard> { };

        /// <summary>
        /// The number of cards in the deck
        /// </summary>
        private int mySize;
        public int Size
        {
            set
            {
                if (value == (int)DeckSize.Small || value == (int)DeckSize.Medium || value == (int)DeckSize.Large)
                    mySize = value;
                else
                    throw (new ArgumentOutOfRangeException("Value", value,
                        String.Format("Deck size is out of range. It can be {0}, {1}, or {2} cards.",
                        (int)DeckSize.Small, (int)DeckSize.Medium, (int)DeckSize.Large)));
            }
            get { return mySize; }

        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="size"></param>
        public DurakDeck(int size)
        {
            Size = size;
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DurakDeck()
        {
            Size = (int)DeckSize.Medium;
        }

        /// <summary>
        /// Sets the deck up according to the deck's size 
        /// </summary>
        public void SetDeck()
        {
            //Switch case to determine how to create the deck depending on deck size
            Rank startRank = 0;     //Variable where to start building the deck
            switch (Size)
            {
                case 52:
                    startRank = Rank.Two;
                    break;
                case 36:
                    startRank = Rank.Six;
                    break;
                case 20:
                    startRank = Rank.Ten;
                    break;
                default:
                    //TODO this error appears twice, one can be taken out methinks
                    throw (new ArgumentOutOfRangeException("Value", Size,
                        String.Format("Deck size is out of range. It can be {0}, {1}, or {2} cards.",
                        (int)DeckSize.Small, (int)DeckSize.Medium, (int)DeckSize.Large)));
            }

            //loops through the suits and ranks setting each card in the deck
            for (Suit i = PlayingCard.MIN_SUIT; i <= PlayingCard.MAX_SUIT; i++)
            {
                myDeck.Add(new PlayingCard(Rank.Ace, i));
                for (Rank j = startRank; j <= PlayingCard.MAX_RANK; j++)
                    myDeck.Add(new PlayingCard((Rank)j, (Suit)i));
            }
        }

        public PlayingCard DrawNextCard()
        {
            PlayingCard drawnCard = myDeck[0];  //gets the first card and stores it
            myDeck.RemoveAt(0);                 //removes the card from the list

            return drawnCard;
        }

        /// <summary>
        /// Shuffles the deck
        /// </summary>
        public void Shuffle()
        {
            List<PlayingCard> newDeck = new List<PlayingCard>();
            bool[] assigned = new bool[mySize];
            Random sourceGen = new Random();
            for (int i = 0; i < mySize; i++)
            {
                int sourceCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next(mySize);
                    if (assigned[sourceCard] == false)
                        foundCard = true;
                }
                assigned[sourceCard] = true;
                newDeck.Add(myDeck[sourceCard]);
            }
            newDeck.CopyTo(myDeck.Cast<PlayingCard>().ToArray());
        }


        public override string ToString()
        {
            string theString = "";

            for (int i = 0; i <= this.myDeck.Count() - 1; i++)
            {
                PlayingCard card = (PlayingCard)myDeck[i];
                theString += card.ToString() + "\n";
            }
            return theString;
        }

        private static void Print(string s)
        {
            Console.WriteLine(s);
        }

        //get the trump card
        public PlayingCard GetTrumpCard()
        {
            return (PlayingCard)myDeck.ElementAt(myDeck.Count() - 1);
        }

    }
}
