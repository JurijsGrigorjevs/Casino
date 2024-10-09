using System;
using System.Collections.Generic;
using Casino;
using Casino.TwentyOne;


// TwentyOne Game
namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            // Constructor chaining
            var newDictionary = new Dictionary<string, string>();
            //Player newPlayer = new Player("Jurijs");
            var newPlayer = new Player("Jurijs");
            const string casinoName = "Grand Hotel and Casino";




            Console.WriteLine("Welcome to the Grand Hotel and Casino. Let's start by telling me your name.");
            string playerName = Console.ReadLine();

            Console.WriteLine("And how much money did you bring today?");
            int bank = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Hello, {0}. Would you like to join a game of 21 right now?", playerName);
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "ya") 
            {
                Player player = new Player(playerName, bank);
                Game game = new TwentyOneGame();
                game += player;
                player.isActivelyPlaying = true;
                while (player.isActivelyPlaying && player.Balance > 0)
                {
                    game.Play(); 
                }
                game -= player;
                Console.WriteLine("Thank you for playing!");
            }
            Console.WriteLine("Feel free look around the casino. Bye for now.");
            Console.Read();
        }


    }
        
}

