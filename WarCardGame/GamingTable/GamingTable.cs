using System.Collections.Generic;
using WarCardGame.Card;
using WarCardGame.Dealer;
using WarCardGame.Hand;

namespace WarCardGame.GamingTable
{
    public class GamingTable : IGamingTable
    {
        public readonly TableHistory tableHistory = new TableHistory();

        public TableHistory PlayGameWhithGivenHand(Dictionary<int, HandWarGame<CardWarGame>> players)
        {
            DealerWarGame game = new DealerWarGame(players);

            GameHistory history = game.Play();
            tableHistory.AddGameHistory(history);

            return this.tableHistory;
        }

        public TableHistory PlayMultipleGames(int numberOfPlayers, int numberOfGames)
        {
            HashSet<int> idPlayers = new HashSet<int>();
            for(int i = 0; i < numberOfPlayers; i++)
            {
                idPlayers.Add(i);
            }

            for (int i = 0; i < numberOfGames; i++)
            {
                DealerWarGame game = new DealerWarGame(idPlayers);
                GameHistory history = game.Play();
                tableHistory.AddGameHistory(history);
            }

            return this.tableHistory;
        }
    }
}
