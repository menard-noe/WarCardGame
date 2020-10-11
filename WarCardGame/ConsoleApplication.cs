using System;
using System.Collections.Generic;
using System.Linq;
using WarCardGame.Card;
using WarCardGame.GamingTable;
using WarCardGame.Hand;

namespace WarCardGame
{
    public class ConsoleApplication
    {
        static void Main(string[] args)
        {
            LaunchCMD();
        }

        public static void LaunchCMD()
        {
            Console.WriteLine("1  Play a single game with a given hand for each player");
            Console.WriteLine("2  Play multiple games with a predetermined number of players");
            Console.WriteLine("Pick the number corresponding to the mod you want : ");

            int choice = int.Parse(Console.ReadLine()); // not safe 

            switch (choice)
            {
                case 1:
                    PlayGameWhithGivenHand();
                    break;
                case 2:
                    PlayMultipleGames();
                    break;
                default:
                    Console.WriteLine("Unknown input");
                    break;

            }
        }

        public static void PlayMultipleGames() //NOT SAFE AT ALL. If wrong input exceptions not caught at all.
        {
            Console.WriteLine("You selected Play multiple games");

            Console.WriteLine("Select number of players : ");
            int numberPlayers = int.Parse(Console.ReadLine());

            Console.WriteLine("Select number of games to play : ");
            int numberGamesToPlay = int.Parse(Console.ReadLine());

            IGamingTable gamingTable = new GamingTable.GamingTable();
            TableHistory tableHistory = gamingTable.PlayMultipleGames(numberPlayers, numberGamesToPlay);

            tableHistory.PrintDetailledHistory();
        }

        public static void PlayGameWhithGivenHand() //NOT SAFE AT ALL. If wrong input exceptions not caught at all.
        {
            Console.WriteLine("You selected Play game with given hand");

            Console.WriteLine("Select number of players : ");
            int numberPlayers = int.Parse(Console.ReadLine());

            Dictionary<int, HandWarGame<CardWarGame>> players = new Dictionary<int, HandWarGame<CardWarGame>>();

            for (int i = 1; i <= numberPlayers; i++)
            {
                Console.WriteLine("Select cards with an input like '4H 3S 1C 13D ...' for player " + i + " :");

                List<String> cardsToConvert = Console.ReadLine().Split(" ").ToList(); //not safe
                HandWarGame<CardWarGame> cards = HandWarGame<CardWarGame>.ConvertStringsToCards(cardsToConvert); // should be done with a proper dsl
                players.Add(i, cards);
            }

            IGamingTable gamingTable = new GamingTable.GamingTable();
            TableHistory tableHistory = gamingTable.PlayGameWhithGivenHand(players);

            tableHistory.PrintDetailledHistory();
        }
    }
}
