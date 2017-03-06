using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakClassLibrary
{
    class PlayerClass
    {

        private string myPlayerName;

        //player hand
        public List<PlayingCard> myhand = new List<PlayingCard> { };

        //hand size
        private int myhandSize;

        //mutators

        public string playerName
        {
            get
            {
                return myPlayerName;
            }
            set
            {
                //makes sure txt is alphanumeric 
                if (value.All(char.IsLetterOrDigit))
                {
                    myPlayerName = value;
                }
                else
                {
                    //throws an exception
                    throw(new ArgumentOutOfRangeException("value", value,
                    String.Format("Name cannot be {0}. It must only contain alphanumeric characters.", value)));
                }                    
            }
          
        }
        public int handSize
        {
            get
            {
                return myhandSize;
            }
            set
            {
                //TODO: VALIDATION!!!!!!!!!!!!¯\_ಠ_ಠ_/¯
                myhandSize = value;
            }
        }

        //TO-DO: ADD VALIDATION TO THE ADDING CARDS TO YOUR HAND

        public PlayerClass(List<PlayingCard> hand, string name )
        {
            playerName = name;
            myhand = hand;
            handSize = hand.Count();
        }



    }
}
