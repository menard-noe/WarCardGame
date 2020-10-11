using System;
using System.Collections.Generic;

namespace WarCardGame.Game
{
    public class GameHistory
    {
        private readonly Queue<string> actions; //actions should be object and not string
        private int winnerId;
        private int numberOfFolds = 0;

        public GameHistory()
        {
            this.actions = new Queue<string>();
            this.winnerId = -1;
        }

        public void SetWinner(int id)
        {
            this.winnerId = id;
        }

        public int GetWinner()
        {
            return this.winnerId;
        }

        public void AddAction(string action)
        {
            this.actions.Enqueue(action);
        }

        public void IncreamentNumberOfFolds()
        {
            this.numberOfFolds += 1;
        }

        public int GetNumberOfFolds()
        {
            return this.numberOfFolds;
        }

        public void PrintHistory()
        {
            Console.WriteLine("New game :");
            while (this.actions.Count != 0)
            {
                Console.WriteLine(this.actions.Dequeue());
            }

            if (this.winnerId != -1)
            {
                Console.WriteLine("The winner of the game is Player " + this.winnerId + " who won in " + numberOfFolds + " folds");
            }
            else
            {
                Console.WriteLine("Game ended on a draw");
            }

            Console.WriteLine();
            Console.WriteLine();
        }


    }
}
