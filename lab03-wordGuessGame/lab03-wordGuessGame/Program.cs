using System;
using System.IO;
using System.Linq;
using System.Text;


namespace lab03_wordGuessGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = "../../../myWords.txt";
            string[] initialWords = { "banana", "fox", "long" };
            CreateFile(path, initialWords);

            WelcomeMenu(path);

            //DeleteFile(path);

        }

        public static void WelcomeMenu(string path)
        {
            Console.WriteLine("Welcome to the Guessing Game!");
            Console.WriteLine("Please select an option:");
            Console.WriteLine(" 1 - Play Game");
            Console.WriteLine(" 2 - Edit Game");
            Console.WriteLine(" 3 - Exit");
            int userOptionSelected = Int32.Parse(Console.ReadLine());

            switch (userOptionSelected)
            {
                case 1:
                    PlayGame(path);
                    break;
                case 2:
                    EditGameMenu(path);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }

        public static void EditGameMenu(string path)
        {
            Console.WriteLine("Edit Game Menu");
            Console.WriteLine("Please select an option:");
            Console.WriteLine(" 1 - View Words");
            Console.WriteLine(" 2 - Add Word");
            Console.WriteLine(" 3 - Remove");
            Console.WriteLine(" 4 - Return Home");
            int userOptionSelected = Int32.Parse(Console.ReadLine());

            switch (userOptionSelected)
            {
                case 1:
                    foreach (string word in ReadWords(path))
                    {
                        Console.WriteLine(word);
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter a word to add to the game: ");
                    string userNewWordToAdd = Console.ReadLine();
                    AddWord(path, userNewWordToAdd);
                    break;
                case 3:
                    Console.WriteLine("Enter a word to remove from the game: ");
                    string userWordToRemove = Console.ReadLine();
                    RemoveWord(path, userWordToRemove);
                    break;
                case 4:
                    WelcomeMenu(path);
                    break;

            }

        }

        public static void CreateFile(string path, string[] initialWords)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    try
                    {
                        foreach (string word in initialWords)
                        {
                            sw.WriteLine(word);
                        }

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        sw.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static string[] ReadWords(string path)
        {
            try
            {
                string[] myWords = File.ReadAllLines(path);
                return myWords;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void AddWord(string path, string newWord)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(newWord);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public static void RemoveWord(string path, string wordToRemove)
        {
            try
            {
                string[] currentWords = ReadWords(path);

                for (int i = 0; i < currentWords.Length; i++)
                {
                    if (wordToRemove == currentWords[i])
                    {
                        currentWords[i] = null;
                    }
                }

                DeleteFile(path);

                using (StreamWriter sw = new StreamWriter(path))
                {
                    try
                    {
                        foreach (string word in currentWords)
                        {
                            if (word != null)
                            {
                                sw.WriteLine(word);
                            }
                        }

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        sw.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void PlayGame(string path)
        {
            Random rand = new Random();
            string[] wordsForGame = ReadWords(path);
            int randomIndex = rand.Next(wordsForGame.Length);
            string gameSolutionWord = wordsForGame[randomIndex];
            string[] hiddenWordToBeGuessed = new string[gameSolutionWord.Length];

            for (int i = 0; i < gameSolutionWord.Length; i++)
            {
                hiddenWordToBeGuessed[i] = " _ ";
            }

            foreach (string letter in hiddenWordToBeGuessed)
            {
                Console.Write(letter);
            }
            Console.WriteLine();

            bool success = false;
            string guessedLetters = "";
            while (!success)
            {
                Console.WriteLine("Can you guess a letter?");
                string userLetterGuess = Console.ReadLine();
                
                guessedLetters += userLetterGuess;

                for (int i = 0; i < hiddenWordToBeGuessed.Length; i++)
                {
                    if (String.Equals(hiddenWordToBeGuessed[i], userLetterGuess, StringComparison.CurrentCultureIgnoreCase))
                    {
                        hiddenWordToBeGuessed[i] = userLetterGuess;
                    }
                }

                if (gameSolutionWord.Contains(userLetterGuess))
                {
                    for (int i = 0; i < gameSolutionWord.Length; i++)
                    {
                        if (gameSolutionWord[i].ToString() == userLetterGuess)
                        {
                            hiddenWordToBeGuessed[i] = userLetterGuess;
                        }
                    }
                }

                Console.WriteLine($"Letters you guessed: {guessedLetters}");
                foreach (string letter in hiddenWordToBeGuessed)
                {
                    Console.Write(letter);
                }
                Console.WriteLine();
                
                if (!hiddenWordToBeGuessed.Contains(" _ "))
                {
                    Console.WriteLine("Well done, you got it!");
                    success = true;
                }

            }
        }
    }
}
