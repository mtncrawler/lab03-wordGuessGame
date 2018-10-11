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
            Program.CreateFile(path);
            Assert.True(File.Exists(path));
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
