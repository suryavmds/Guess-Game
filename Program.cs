using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Generating a random number between 1 and 100
        Random random = new Random();
        int targetNumber = random.Next(1, 101);

        // variables to hold user's guess and list of guesses
        int userGuess = 0;
        List<Guess> guessHistory = new List<Guess>();

        Console.WriteLine("Welcome to the Guessing Game!");
        Console.WriteLine("Try to guess the hidden number between 1 and 100.");

        // The game loop starts here
        do
        {
            Console.Write("Enter your guess: ");
            string input = Console.ReadLine();

            // Parsing the user input and validating it
            if (!int.TryParse(input, out userGuess) || userGuess < 1 || userGuess > 100)
            {
                Console.WriteLine("Invalid input! Please enter a number between 1 and 100.");
                continue;
            }

            // Checking if the user has guessed the same number before
            int previousIndex = guessHistory.FindIndex(g => g.UserGuess == userGuess);
            if (previousIndex != -1)
            {
                int turnsAgo = guessHistory.Count - previousIndex;
                Console.WriteLine($"You guessed this number {turnsAgo} turns ago!");
            }

            // Adding the guess to the list
            guessHistory.Add(new Guess(userGuess));

            // Checking if the user's guess is correct
            if (userGuess == targetNumber)
            {
                Console.WriteLine($"You Won! The answer was {targetNumber}.");
                break;
            }
            else if (userGuess > targetNumber)
            {
                Console.WriteLine("Too high! Try again.");
            }
            else
            {
                Console.WriteLine("Too low! Try again.");
            }

        } while (true);

        // Displaying the game summary
        Console.WriteLine("Game Summary:");
        foreach (var guess in guessHistory)
        {
            Console.WriteLine($"You guessed {guess.UserGuess} at {guess.GuessTime}");
        }

        Console.WriteLine("Thanks for playing!");
    }
}
