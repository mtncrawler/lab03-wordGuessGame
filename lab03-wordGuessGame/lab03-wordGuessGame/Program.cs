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
            CreateFile(path);
            AddWord(path, "cookie");
            foreach (string word in ReadWords(path))
            {
                Console.WriteLine(word);
            }
            
            //DeleteFile(path);
            
        }

        public static void CreateFile(string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    try
                    {
                        sw.WriteLine("banana");
                        sw.WriteLine("london");
                        sw.WriteLine("sausage");
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

        //public static void RemoveWord(string path, string wordToRemove)
        //{
        //    try
        //    {
        //        string[] currentWords = ReadWords(path);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
