using System;
using Questions;
using Game;
using Admin;
using HiScoreNamespace;

namespace Huvudmeny
{
    public class Program
    {
        private static string userName; // Declare userName at a scope accessible to both methods

        public static void Main(string[] args)
        {
            FreetextQuestion questions = new FreetextQuestion();
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("===== Quiz! =====");
                Console.WriteLine("1. Play");
                Console.WriteLine("2. Hi-score"); // lägg till hi-score uppgiften. Json?
                Console.WriteLine("3. Admin ");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string? userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("You selected Option 1.");
                        UserName(); // Call the UserName method for playing the game
                        PlayGame(userName); // Call the PlayGame method with the user's name


                        break;

                    case "2":
                        Console.WriteLine("You selected Option 2.");
                        // Add code for Hi-score here
                        Scoreboard displayscore = new Scoreboard();
                        displayscore.DisplayScore(); // Call the DisplayScore method from the HiScore class
                        break;

                    case "3":
                        Console.WriteLine("You selected Option 3.");
                        bool runAdmin = true;
                        System.Console.WriteLine("Select admin option: ");
                        while(runAdmin)
                        {
                            System.Console.WriteLine("1. Show all Questions of a specific type");
                            System.Console.WriteLine("2. Add a Question of a specific type");
                            System.Console.WriteLine("3. Show all Questions of every type");
                            System.Console.WriteLine("4. Remove a question?");
                            System.Console.WriteLine("5. Return");
                            userInput = Console.ReadLine();
                            switch(userInput)
                        
                            {
                                case "1":
                                    
                                    FreetextQuestion freetextQuestionManager = new FreetextQuestion();

                                    
                                    // Display all questions
                                    freetextQuestionManager.ShowFreetextQuestion();

                                    Console.WriteLine("Press any key to exit...");
                                    Console.ReadKey();
                                    break;
                                case "2":
                                    FreetextQuestion freetextQuestionManager= new FreetextQuestion();
                                    freetextQuestionManager.FreetextQuestionAdd();
                                    break;
                                case "3":
                                
                                
                                    break;
                                case "4":

                                    runAdmin = false;
                                    break;
                            }
                        }
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

    public static void UserName()
    {
        Console.WriteLine("What is your name?: ");
        userName = Console.ReadLine();
    }

    public static void PlayGame(string userName)
    {
        if (userName != null)
        {
            Console.WriteLine($"Welcome, {userName}! Starting the game...");
            // Add your game logic here ConsoleWriteLines osv
        }
        else
        {
            Console.WriteLine("Invalid user name.");
        }
    }
}
}