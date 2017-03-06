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
                if (value == 36)
                {
                    mySize = 36;
                }
                else
                {
                    throw (new ArgumentOutOfRangeException("Value", value, "Argument was out of range"));
                }
            }
            get
            {
                return mySize;
            }

        }
        #endregion

        /// <summary>
        /// Sets the deck up 
        /// </summary>
        public void setDeck()
        {
            //loops throught
            for (Suit i = PlayingCard.MAX_SUIT; i < PlayingCard.MAX_SUIT; i++)
            {
                for (Rank j = PlayingCard.MIN_RANK; j < PlayingCard.MAX_RANK; j++)
                {
                    PlayingCard myCard = new PlayingCard((Rank)j, (Suit)i);
                    myDeck.Add(myCard);
                }
            }
        }

        public override string ToString()
        {
            string theString = "";

            for(int i = 0; i <3; i++)
            {
                 PlayingCard card = myDeck[i];

                theString += "\nRank " + card.Rank + "\nSuit " + card.Suit + "\n";
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
            return (PlayingCard) myDeck.ElementAt(myDeck.Count() - 1);
        }

    }
}
