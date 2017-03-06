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

            myGameDeck.SetDeck();
            PlayingCard testCard = new PlayingCard(Rank.Ace, Suit.Clubs);
            Console.WriteLine(myGameDeck.ToString());

           Console.WriteLine(testCard.Debug());
            Console.ReadKey();
        }
    }
}
