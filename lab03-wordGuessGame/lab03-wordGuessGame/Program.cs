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
    }
}
