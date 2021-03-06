﻿using System;
using System.Collections.Generic;
using WarCardGame.Game;

namespace WarCardGame.GamingTable
{
    public class TableHistory
    {
        readonly Dictionary<int, int> scoreboard = new Dictionary<int, int>();
        readonly List<GameHistory> histories = new List<GameHistory>();
        int numberOfPartiesPlayed = 0;

        public TableHistory()
        {
            scoreboard.Add(-1, 0); //number of draw 
        }

        // TODO : if a player never win a game he doesn't appear in the leadeboard at the moment.
        public void AddGameHistory(GameHistory gameHistory)
        {
            histories.Add(gameHistory);

            int idWinner = gameHistory.GetWinner();
            int scoreWinner = scoreboard.GetValueOrDefault(idWinner, 0);
            scoreboard[idWinner] = scoreWinner + 1;

            numberOfPartiesPlayed += 1;
        }

        public void PrintScoreBoard()
        {
            Console.WriteLine("-------------ScoreBoard-----------");

            foreach (int playerId in scoreboard.Keys)
            {
                if (playerId != -1)
                {
                    Console.WriteLine("Player " + playerId + " : " + scoreboard[playerId]);
                }
                else
                {
                    Console.WriteLine("Draw" + " : " + scoreboard[playerId]);
                }
            }

            Console.WriteLine("Number of parties played : " + numberOfPartiesPlayed);
        }

        public void PrintDetailledHistory()
        {
            foreach (GameHistory gameHistory in histories)
            {
                gameHistory.PrintHistory();
            }

            this.PrintScoreBoard();
        }

        public List<GameHistory> GetHistories()
        {
            return this.histories;
        }

        public Dictionary<int, int> GetScoreBoard()
        {
            return this.scoreboard;
        }
    }
}
