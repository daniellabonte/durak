using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakClassLibrary
{
    public class DurakDeck
    {

        private int mySize;
        public List<PlayingCard> myDeck = new List<PlayingCard> { };


        //shuffle the deck
        //draw next card


        #region Properties
        public int Size
        {
            set
            {
                if (value == 36) mySize = 36;
                else throw (new ArgumentOutOfRangeException("Value", value, "Argument was out of range"));
            }
            get { return mySize; }

        }
        #endregion

        /// <summary>
        /// Sets the deck up 
        /// </summary>
        public void SetDeck()
        {
            //loops through all suits and ranks to create deck
            for (Suit i = PlayingCard.MIN_SUIT; i <= PlayingCard.MAX_SUIT; i++)
                for (Rank j = PlayingCard.MIN_RANK; j <= PlayingCard.MAX_RANK; j++)
                    myDeck.Add(new PlayingCard((Rank)j, (Suit)i));
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
