using System;
using System.IO;
using System.Text;


namespace lab03_wordGuessGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string path = "../../../myWords.txt";
            string[] initialWords = { "banana", "sausage", "London" };
            CreateFile(path, initialWords);

            PlayGame(path);
            //AddWord(path, "cookie");
            //RemoveWord(path, "banana");

            //foreach (string word in ReadWords(path))
            //{
            //    Console.WriteLine(word);
            //}
            //DeleteFile(path);

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
            string[] emptyCharWordToBeGuessed = new string[gameSolutionWord.Length];

            for (int i = 0; i < gameSolutionWord.Length; i++)
            {
                emptyCharWordToBeGuessed[i] = " _ ";
            }

            foreach (string letter in emptyCharWordToBeGuessed)
            {
                Console.Write(letter);
            }
            Console.WriteLine();
        }
    }
}
