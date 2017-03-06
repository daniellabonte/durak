using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurakClassLibrary;

namespace DurakTester
{
    class Program
    {
        static void Main(string[] args)
        {
          //  PlayingCard testCard = new PlayingCard(Rank.Jack, Suit.Hearts);

            DurakDeck myGameDeck= new DurakDeck();

            myGameDeck.setDeck();

            Console.WriteLine(myGameDeck.ToString());

           // Console.WriteLine(testCard.ToString());
            Console.ReadKey();
        }
    }
}
