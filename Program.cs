namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char response = 'y';
            char letterGuess;

            while (response == 'y')
            {
                Console.WriteLine();
                Random randomGenerator = new Random();
                int randomNumber = randomGenerator.Next(0, 10);

                List<string> gameAnswers = new List<string> { "computer", "paper", "printer", "light", "stapler", "window", "bomber", "airplane", "garden", "thermostat" };
                //or i can add them like this
                //gameAnswers.Add("Computer");
                //gameAnswers.Add("Paper");
                //gameAnswers.Add("Printer");
                //gameAnswers.Add("Light");
                //gameAnswers.Add("Stapler");
                //gameAnswers.Add("Window");

                string selectedWord = gameAnswers[randomNumber];
                string hiddenWord = gameAnswers[randomNumber];
                int userTries = 6;

                for (int i = 0; i < selectedWord.Length; i++)
                {
                    hiddenWord = hiddenWord.Remove(i, 1);
                    hiddenWord = hiddenWord.Insert(i, "_");
                }

                while (hiddenWord.Contains("_") && userTries > 0)
                {
                    Console.WriteLine("Welcome to Hangman!");
                    Console.WriteLine("Discover the word in 6 attempts by guessing the word using letters.");
                    string tellLength = "This word has: " + selectedWord.Length + " letters. Good luck!";
                    Console.WriteLine(tellLength);
                    Console.WriteLine(" Guess a letter of the hidden word : ");
                    Console.WriteLine(hiddenWord);
                    char.TryParse(Console.ReadLine().ToLower(), out letterGuess);
                    bool containsLetter = false;
                    for (int i = 0; i < selectedWord.Length; i++)
                    {
                        if (selectedWord[i] == letterGuess)
                        {
                            hiddenWord = hiddenWord.Remove(i, 1);
                            hiddenWord = hiddenWord.Insert(i, letterGuess.ToString());
                            containsLetter = true;
                        }
                    }
                    if (containsLetter == true)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Correct, >> {letterGuess} << is in the word\n");
                        Console.ResetColor();
                        Console.WriteLine($"Tries : {userTries}");
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Sorry, >> {letterGuess} << was not in the word.\n");
                        Console.ResetColor();
                        userTries--;
                        Console.WriteLine($"Tries : {userTries}");
                    }
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
                }
                Console.WriteLine("Do you want to restart?");
                Console.WriteLine("Press any key to exit or \"Y\" to restart the game");
                response = Console.ReadKey().KeyChar;
                response = char.ToLower(response);
            }
        }
    }
}