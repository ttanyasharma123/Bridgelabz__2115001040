using System;
using System.IO;

public class FileProcessor
{
    // Writes content to a file
    public void WriteToFile(string filename, string content)
    {
        if (string.IsNullOrWhiteSpace(filename)) throw new ArgumentException("Filename cannot be empty.");
        File.WriteAllText(filename, content);
    }

    // Reads content from a file
    public string ReadFromFile(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename)) throw new ArgumentException("Filename cannot be empty.");
        if (!File.Exists(filename)) throw new FileNotFoundException("File not found.");

        return File.ReadAllText(filename);
    }
}




.Net Unit Test Cases 

using NUnit.Framework;
using System;
using System.IO;

namespace FileProcessorTests
{
    [TestFixture]
    public class FileProcessorTests
    {
        private FileProcessor _fileProcessor;
        private string _testFilePath;

        [SetUp]
        public void Setup()
        {
            _fileProcessor = new FileProcessor();
            _testFilePath = "testfile.txt"; // Temporary test file
        }

        [Test]
        public void WriteToFile_ContentIsWrittenSuccessfully()
        {
            string content = "Hello, NUnit!";
            _fileProcessor.WriteToFile(_testFilePath, content);

            Assert.IsTrue(File.Exists(_testFilePath)); // Check if file exists
            string readContent = File.ReadAllText(_testFilePath);
            Assert.AreEqual(content, readContent); // Verify content
        }

        [Test]
        public void ReadFromFile_ReturnsCorrectContent()
        {
            string content = "Test content";
            File.WriteAllText(_testFilePath, content); // Create file manually

            string readContent = _fileProcessor.ReadFromFile(_testFilePath);
            Assert.AreEqual(content, readContent);
        }

        [Test]
        public void ReadFromFile_FileDoesNotExist_ThrowsFileNotFoundException()
        {
            string nonExistentFile = "nofile.txt";
            Assert.Throws<FileNotFoundException>(() => _fileProcessor.ReadFromFile(nonExistentFile));
        }

        [Test]
        public void WriteToFile_InvalidFilename_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _fileProcessor.WriteToFile("", "Some content"));
        }

        [TearDown]
        public void Cleanup()
        {
            if (File.Exists(_testFilePath))
                File.Delete(_testFilePath); // Cleanup after tests
        }
    }
}



