using System;
using System.Drawing;

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
        Clubs,
        Spades,
        Hearts,
        Diamonds
    }

    public class PlayingCard : ICloneable
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
            myValue = (int)rank;
        }

        /// <summary>
        /// Property to get set and store the card's rank. Must be between 1 and 13 (Ace and King) inclusive.
        /// </summary>
        protected Rank myRank;
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
        protected Suit mySuit;
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
        /// Property to get set the card's value determined by the game being played.
        /// </summary>
        protected int myValue;
        public int CardValue
        {
            get { return myValue; }
            set { myValue = value; }
        }

        /// <summary>
        /// Optional property to manually set a card's alternate value
        /// </summary>
        protected int? altValue = null;
        public int? AlternateValue
        {
            get { return altValue; }
            set { altValue = value; }
        }

        /// <summary>
        /// Property for the card being face up or face down
        /// </summary>
        protected bool isFaceUp;
        public bool IsFaceUp
        {
            get { return isFaceUp; }
            set { isFaceUp = value; }
        }

        /// <summary>
        /// Override the ToString method for the PlayingCard class
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            string theString;       //Variable to hold the output string
            const int WIDTH = 15;   //Width of the label

            //TODO add string for card is facedown

            //Build string to return
            theString = Rank.ToString() + " of " + Suit.ToString();
            //theString += String.Format("{0} {1}\n", "Card suit: ".PadRight(WIDTH), Suit.ToString());

            //Return the string
            return theString;
        }

        #region RELATIONAL OPERATORS
        public static bool operator ==(PlayingCard left, PlayingCard right) { return (left.CardValue == right.CardValue); }
        public static bool operator !=(PlayingCard left, PlayingCard right) { return (left.CardValue != right.CardValue); }
        public static bool operator <=(PlayingCard left, PlayingCard right) { return (left.CardValue <= right.CardValue); }
        public static bool operator >=(PlayingCard left, PlayingCard right) { return (left.CardValue >= right.CardValue); }
        public static bool operator <(PlayingCard left, PlayingCard right) { return (left.CardValue < right.CardValue); }
        public static bool operator >(PlayingCard left, PlayingCard right) { return (left.CardValue > right.CardValue); }
        #endregion

        /// <summary>
        /// Clone method for ICloneable interface for deep copying cards
        /// </summary>
        /// <returns>A system.object copy of the card</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            return (this.CardValue == ((PlayingCard)obj).CardValue);
        }

        public override int GetHashCode()
        {
            return (this.myValue * 10 + (int)this.mySuit);
        }

        public Bitmap GetCardImage()
        {
            Bitmap cards;
            cards = DurakClassLib.Properties.Resources.ResourceManager.GetObject("playingCards.png") as Bitmap;

            //TODO unhardcode the 13 and 4
            int cardWidth = cards.Width / 13;
            int cardHeight = cards.Height / 4;

            int locationX = (int)(cardWidth * ((int)this.Rank - 1));
            int locationY = (int)(cardHeight * ((int)this.Suit));

            Rectangle cardCrop = new Rectangle(new Point(locationX, locationY), new Size(cardWidth, cardHeight));

            int width = (int)this.Rank;
            int height = (int)this.Suit;



            // An empty bitmap which will hold the cropped image
            Bitmap cardImage = new Bitmap(cardWidth, cardHeight);

            Graphics g = Graphics.FromImage(cardImage);

            // Draw the given area (section) of the source image
            // at location 0,0 on the empty bitmap (bmp)
            g.DrawImage(cards, locationX, locationY, cardCrop, GraphicsUnit.Pixel);

            return cardImage;
        }

        public string Debug()
        {
            string theString;
            int WIDTH = 30;

            theString = String.Format("{0} {1}\n", "Card rank: ".PadRight(WIDTH), Rank.ToString());
            theString += String.Format("{0} {1}\n", "Card suit: ".PadRight(WIDTH), Suit.ToString());
            theString += String.Format("{0} {1}\n", "Is Face Up: ".PadRight(WIDTH), IsFaceUp.ToString());
            theString += String.Format("{0} {1}\n", "Card value: ".PadRight(WIDTH), CardValue.ToString());
            theString += String.Format("{0} {1}\n", "Alt value: ".PadRight(WIDTH), ((altValue != null) ? altValue.ToString() : "N/A"));

            return theString;
        }
    }
}

