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
        //[Fact]
        //public void ReadFileWorks()
        //{
        //    string path = "../../../test.txt";
        //    Program.ReadFile(path);
        //    Assert.True(File.Exists());
        //}
    }
}
