using System;
using System.Threading;

class HangmanGame
{
    static void Main()
    {
        Console.WriteLine("Welcome to Hangman!");
        string secretWord = "";
        do
        {
            Console.Clear();
            Console.WriteLine("Player 1, please enter the secret word (letters and spaces only):");
            secretWord = Console.ReadLine().ToLower();

            if (!IsAllLettersAndSpaces(secretWord))
            {
                Console.WriteLine("Invalid secret word. It must contain letters and spaces only. Please try again.");
                Thread.Sleep(1000); // Pause for 1 second to display the message
            }
        } while (!IsAllLettersAndSpaces(secretWord));

        char[] guessedWord = new char[secretWord.Length];

        for (int i = 0; i < secretWord.Length; i++)
        {
            if (secretWord[i] == ' ')
            {
                guessedWord[i] = ' ';
            }
            else
            {
                guessedWord[i] = '_';
            }
        }

        int attempts = 6;
        string guessedLetters = "";

        Console.Clear(); // Clear the console

        Console.WriteLine("Player 2, you have 6 attempts to guess the word.");
        Console.WriteLine();

        while (attempts > 0)
        {
            Console.Clear(); // Clear the console

            Console.WriteLine("Word: " + new string(guessedWord));
            Console.WriteLine("Guessed letters: " + guessedLetters);
            Console.WriteLine("Attempts remaining: " + attempts);

            Console.Write("Guess a letter or a space: ");
            char guess = Char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (!Char.IsLetter(guess) && guess != ' ')
            {
                Console.WriteLine("Invalid input. Please enter a letter or a space.");
                Thread.Sleep(1000); // Pause for 1 second to display the message
                continue; // Skip the rest of the loop and restart
            }

            if (guessedLetters.Contains(guess))
            {
                Console.WriteLine("You already guessed that letter.");
                Thread.Sleep(1000); // Pause for 1 second to display the message
            }
            else
            {
                bool letterGuessed = false;
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i] == guess)
                    {
                        guessedWord[i] = guess;
                        letterGuessed = true;
                    }
                }

                if (!letterGuessed)
                {
                    Console.WriteLine("Incorrect guess.");
                    attempts--;
                    Thread.Sleep(1000); // Pause for 1 second to display the message
                }

                if (new string(guessedWord) == secretWord)
                {
                    Console.Clear(); // Clear the console
                    Console.WriteLine("Congratulations, you guessed the word: " + secretWord);
                    break;
                }
            }

            guessedLetters += guess;
        }

        if (attempts == 0)
        {
            Console.Clear(); // Clear the console
            Console.WriteLine("Sorry, you ran out of attempts. The word was: " + secretWord);
        }

        Console.WriteLine("Thanks for playing!");
    }

    static bool IsAllLettersAndSpaces(string str)
    {
        foreach (char c in str)
        {
            if (!Char.IsLetter(c) && c != ' ')
            {
                return false;
            }
        }
        return true;
    }
}
