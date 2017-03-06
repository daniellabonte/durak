using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakClassLibrary
{
    /// <summary>
    /// Enumeration for the face value of the card
    /// </summary>
    public enum Rank
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    /// <summary>
    /// Enumeratioin for the suit of the card
    /// </summary>
    public enum Suit
    {
        Spades,
        Hearts,
        Clubs,
        Diamonds
    }

    public class PlayingCard
    {
        //Constants
        public const Suit MIN_SUIT = Suit.Spades;
        public const Suit MAX_SUIT = Suit.Diamonds;
        public const Rank MIN_RANK = Rank.Ace;
        public const Rank MAX_RANK = Rank.King;

        /// <summary>
        /// Constructor - initializes new card instances
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="suit"></param>
        public PlayingCard(Rank rank, Suit suit)
        {
            Suit = suit;
            Rank = rank;
        }

        /// <summary>
        /// Property to get set and store the card's rank. Must be between 1 and 13 (Ace and King) inclusive.
        /// </summary>
        private Rank myRank;
        public Rank Rank
        {
            set
            {
                //Card rank is out of range
                if (value < Rank.Ace || value > Rank.King)
                {
                    // throw an exception with a descriptive message
                    throw (new ArgumentOutOfRangeException("value", value,
                        String.Format("Rank cannot be {0}. It must be between Ace and King inclusive.", value)));
                }
                myRank = value;
            }
            get { return myRank; }
        }

        /// <summary>
        /// Property to get set and store the card's suit. Must be between 0 and 3 (Spades and Diamonds) inclusive.
        /// </summary>
        private Suit mySuit;
        public Suit Suit
        {
            set
            {
                //Card suit is out of range
                if (value < Suit.Spades || value > Suit.Diamonds)
                {
                    // throw an exception with a descriptive message
                    throw (new ArgumentOutOfRangeException("value", value,
                        String.Format("Suit cannot be {0}. It must be between Spades and Diamonds inclusive.", value)));
                }
                mySuit = value;
            }
            get { return mySuit; }
        }

        /// <summary>
        /// Override the ToString method for the PlayingCard class
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            string theString;       //Variable to hold the output string
            const int WIDTH = 15;   //Width of the label

            //Build string to return
            theString = String.Format("{0} {1}\n", "Card rank: ".PadRight(WIDTH), Rank);
            theString += String.Format("{0} {1}\n", "Card suit: ".PadRight(WIDTH), Suit);

            //Return the string
            return theString;
        }
    }
}

