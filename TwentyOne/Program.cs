﻿using System;
using System.Collections.Generic;
using System.IO;
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
            //var newDictionary = new Dictionary<string, string>();
            //Player newPlayer = new Player("Jurijs");
            //var newPlayer = new Player("Jurijs");
            //const string casinoName = "Grand Hotel and Casino";

            // GUIDs (Globally Unique Identifiers)
            //Guid identifier = new Guid();
            //Guid identifier = Guid.NewGuid();



            Console.WriteLine("Welcome to the Grand Hotel and Casino. Let's start by telling me your name.");
            string playerName = Console.ReadLine();

            // Exception Handling
            bool validAnswer = false;
            int bank = 0;
            while (!validAnswer)
            {
                Console.WriteLine("And how much money did you bring today?");
                // int is the same like ToIn32
                validAnswer = int.TryParse(Console.ReadLine(), out bank);
                if (!validAnswer) Console.WriteLine("Please enter digits only, no decimals");
            }

            //Console.WriteLine("And how much money did you bring today?");
            //int bank = Convert.ToInt32(Console.ReadLine());



            Console.WriteLine("Hello, {0}. Would you like to join a game of 21 right now?", playerName);
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "ya") 
            {
                Player player = new Player(playerName, bank);



                //GUIDs(Globally Unique Identifiers)
                player.Id = Guid.NewGuid();
                using (StreamWriter file = new StreamWriter(@"C:\Users\Public\Casino\log_text_test\log.txt", true))
                {
                    file.WriteLine(player.Id);
                }

                Game game = new TwentyOneGame();
                game += player;
                player.isActivelyPlaying = true;
                // Try/catch
                while (player.isActivelyPlaying && player.Balance > 0)
                {
                    try
                    {
                        game.Play();
                    }
                    catch (FraudException)
                    {
                        Console.WriteLine("Security! Kick this person out.");
                        Console.ReadLine();
                        return;
                    }
                    catch (Exception) 
                    {
                        Console.WriteLine("An error occurred. Please contact your System Administrator.");
                        Console.ReadLine();
                        return;
                    }


                }
                game -= player;
                Console.WriteLine("Thank you for playing!");
            }
            Console.WriteLine("Feel free look around the casino. Bye for now.");
            Console.Read();
        }


    }
        
}

