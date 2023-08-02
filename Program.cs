
using System.Text;

namespace HangMan
{
    internal class Program
    {
        const string CORRECT_GUESS_MESSAGE = "\nCorrect, >> {0} << is in the word\n";
        const string INCORRECT_GUESS_MESSAGE = "\nSorry, >> {0} << was not in the word.\n";
        const int MAX_TRIES = 6;

        static void Main(string[] args)
        {
            char response = 'y';
            char letterGuess;
            Random randomGenerator = new Random();
            List<string> gameAnswers = new List<string> { "computer", "paper", "printer", "light", "stapler", "window", "bomber", "airplane", "garden", "thermostat" };
        

            while (response == 'y')
            {
                Console.WriteLine();
                int randomNumber = randomGenerator.Next(gameAnswers.Count);

                string selectedWord = gameAnswers[randomNumber];
                string hiddenWord = new string('_', selectedWord.Length);
                int userTries = MAX_TRIES;

                Console.WriteLine("Welcome to Hangman!");
                Console.WriteLine($"Discover the word in {userTries} attempts by guessing the word using letters.");
                string tellLength = "This word has: " + selectedWord.Length + " letters. Good luck!";
                Console.WriteLine(tellLength);

                ConsoleColor CORRECT_GUESS_COLOR = ConsoleColor.Yellow;
                ConsoleColor INCORRECT_GUESS_COLOR = ConsoleColor.Red;

                while (hiddenWord.Contains("_") && userTries > 0)
                {

                    Console.WriteLine(" Guess a letter of the hidden word : ");
                    Console.WriteLine(hiddenWord);
                    letterGuess = Console.ReadKey().KeyChar;
                    letterGuess = char.ToLower(letterGuess);
                    bool containsLetter = false;
                    StringBuilder updatedHiddenWord = new StringBuilder(hiddenWord);

                    for (int i = 0; i < selectedWord.Length; i++)
                    {
                        if (selectedWord[i] == letterGuess)
                        {
                            updatedHiddenWord[i] = letterGuess;
                            containsLetter = true;
                        }
                    }

                    hiddenWord = updatedHiddenWord.ToString();

                    Console.Clear();
                    string guessMessage = string.Empty;
                    ConsoleColor foreGroundColor = CORRECT_GUESS_COLOR;

                    if (containsLetter == true)
                    {
                        guessMessage = CORRECT_GUESS_MESSAGE;
                    }
                    else
                    {
                        foreGroundColor = INCORRECT_GUESS_COLOR;
                        guessMessage = INCORRECT_GUESS_MESSAGE;
                        userTries--;
                    }
                    Console.ForegroundColor = foreGroundColor;
                    Console.WriteLine(guessMessage, letterGuess);
                    Console.ResetColor();
                    Console.WriteLine($"Tries : {userTries}");
                       
                }

                if (userTries == 0)
                {
                    Console.WriteLine("Sorry, you are out of tries !!");
                    Console.WriteLine($"The word was {selectedWord} ");
                }

                if (userTries != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"You guessed correct. The word was {hiddenWord}");
                    Console.ResetColor();
                }

                Console.WriteLine("Do you want to restart?");
                Console.WriteLine("Press any key to exit or \"Y\" to restart the game");
                response = Console.ReadKey().KeyChar;
                response = char.ToLower(response);
            }
        }
    }

}
