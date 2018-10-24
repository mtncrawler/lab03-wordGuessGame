using System;
using Xunit;
using lab03_wordGuessGame;
using System.IO;
using System.Text;

namespace wordGuessGameTest
{
    public class UnitTest1
    {
        [Fact]
        public void CreateFileExists()
        {
            string path = "../../../test.txt";
            string[] initialWords = { "georgia" };
            Program.CreateFile(path, initialWords);
            Assert.True(File.Exists(path));
        }

        [Fact]
        public void FileDeleted()
        {
            string path = "../../../test.txt";
            Program.DeleteFile(path);
            Assert.True(!File.Exists(path));
        }

        [Fact]
        public void WordWasRemoved()
        {
            string path = "../../../test.txt";
            string[] initialWords = { "georgia", "pickles", "volcano" };
            Program.CreateFile(path, initialWords);
            Program.RemoveWord(path, "pickles");
            string[] expectedWords = { "georgia", "volcano" };
            Assert.DoesNotContain("pickles", Program.ReadWords(path));
        }

        [Fact]
        public void PlayGame()
        {
            string path = "../../../test.txt";
            string[] initialWords = { "banana", "fox", "long" };
            Program.CreateFile(path, initialWords);
            //Assert.Equal()
        }

        [Fact]
        public void WordAdded()
        {
            string path = "../../../test.txt";
            Program.AddWord(path, "chocolate");

            Assert.Contains("chocolate", Program.ReadWords(path));
        }

        [Fact]
        public void RetrieveAllWords()
        {
            string path = "../../../test.txt";
            string[] words =
            {
                "banana",
                "fox",
                "long",
                "chocolate"
            };

            Assert.Equal(words.Length, Program.ReadWords(path).Length);
        }

        [Fact]
        public void ValidLetterGuessed()
        {
            string path = "../../../test.txt";
            string letter = "b";

            Assert.Contains(letter, Program.ReadWords(path)[0]);
        }

        [Fact]
        public void InvalidLetterGuessed()
        {
            string path = "../../../test.txt";
            string letter = "x";

            Assert.DoesNotContain(letter, Program.ReadWords(path)[0]);
        }

    }
}
