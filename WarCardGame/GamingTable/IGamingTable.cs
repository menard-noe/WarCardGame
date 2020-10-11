using System.Collections.Generic;
using WarCardGame.Card;
using WarCardGame.Hand;

namespace WarCardGame.GamingTable
{
    public interface IGamingTable
    {
        public TableHistory PlayMultipleGames(int numberOfPlayers, int numberOfGames);
        public TableHistory PlayGameWhithGivenHand(Dictionary<int, HandWarGame<CardWarGame>> players);
    }
}
