using System.Collections.Generic;
using WarCardGame.Card;
using WarCardGame.Game;
using WarCardGame.Hand;

namespace WarCardGame.GamingTable
{
    /***
     * 
     * Object representing a table on wich any instances of the same game will be played.
     * 
     ***/
    public class GamingTable : IGamingTable
    {
        public readonly TableHistory tableHistory = new TableHistory();

        public TableHistory PlayGameWhithGivenHand(Dictionary<int, HandWarGame<CardWarGame>> players)
        {
            GameWar game = new GameWar(players);

            GameHistory history = game.Play();
            tableHistory.AddGameHistory(history);

            return this.tableHistory;
        }

        public TableHistory PlayMultipleGames(int numberOfPlayers, int numberOfGames)
        {
            HashSet<int> idPlayers = new HashSet<int>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                idPlayers.Add(i);
            }

            for (int i = 0; i < numberOfGames; i++)
            {
                GameWar game = new GameWar(idPlayers);
                GameHistory history = game.Play();
                tableHistory.AddGameHistory(history);
            }

            return this.tableHistory;
        }
    }
}
