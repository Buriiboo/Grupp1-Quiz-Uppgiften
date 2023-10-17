﻿using System;

class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("===== Quiz! =====");
            Console.WriteLine("1. Play");
            Console.WriteLine("2. Hi-score"); // lägg till hi-score uppgiften. Json?
            Console.WriteLine("3. Admin ");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.WriteLine("You selected Option 1.");
                    UserName(); // Call the UserName method for playing the game
                    break;

                case "2":
                    Console.WriteLine("You selected Option 2.");
                    // Add code for Hi-score here
                    break;

                case "3":
                    Console.WriteLine("You selected Option 3.");
                    // Add code for admin-options here
                    break;

                case "4":
                    isRunning = false;
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine(); // Add a line break for readability
        }
    }

    static void UserName()
    {
        Console.WriteLine("What is your name?: ");
        string name = Console.ReadLine();
        PlayGame(name); // Call the PlayGame method with the user's name
    }

    static void PlayGame(string userName)
    {
        Console.WriteLine($"Welcome, {userName}! Starting the game...");
        // Add your game logic here
    }
}
