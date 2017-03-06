using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakClassLibrary
{
    //th game logic should only handle two players. the AI player as well as the human player
    class GameClass
    {
        //ATTRIBUTES

        //deck (holds the playing card deck)
        private DurakDeck myGameDeck;

        //Players (holds the players currently playing)
        public List<PlayerClass> myGamePlayers = new List<PlayerClass> { };

        //trumpCard
        private PlayingCard myTrumpCard;

        //Player size(amount of players)
        private int myPlayerSize;

        //river (attack/defend cards in the pile)
        public List<PlayingCard> myGameRiver = new List<PlayingCard> { };


        //CONSTRUCTOR
        public GameClass(List<PlayerClass> gamePlayers)
        {
            //add validation to the setting players
            myGamePlayers = gamePlayers;                //sets the players
            myPlayerSize = myGamePlayers.Count();       //sets player count
            myGameDeck.setDeck();                       //sets the deck
            myTrumpCard = myGameDeck.GetTrumpCard();    //sets the trump card

            //call the main game logic
        }

        //Mutators

        //Remove players
        //public PlayingCard RemovePlayer(PlayingCard removingPlayer)
        //{
        //    //find the value of the player in the list

        //}

        //add players
        public void AddPlayer(PlayerClass addingPlayer)
        {
            //adds players to the game
            myGamePlayers.Add(addingPlayer);
        }

        //IsValidCard
        //checks the currently played cards to ensure that the card 
        //that the player selected can be played


        //draw cards which adds the amount of cards needed 
        //to ensure that the player has 6 cards ub there hand



        //main attack logic
        //checks the cards can be played each time a card is placed(IsValidCard)
        //checks who won

        //if the attacker wins(i.e the defender cant play anything)
        //move the river cards into the defenders hand

        //else if the defender wins the round
        //get rid of the cards in the river
        //make the defender the new attacker


    }
}
