using System.IO;
using Jobb.Models.Implementations;
using Jobb.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JobbTest.ModelTests
{
    [TestClass]
    public class EmptyDirectoryJobbTest : TestBase
    {
        private string emptyDirectory;
        private readonly string testFile = "emptyTestFile.txt";

        [TestInitialize]
        public void Init() {
            emptyDirectory = Path.Combine(LocalResourceTestDataPath, "EmptyDirectory");
            CreateFolder(emptyDirectory);
            CreateFile(Path.Combine(emptyDirectory, testFile));
        }

        [TestMethod]
        public void ExecuteEmptyDirectoryJobbSuccess() {        
            var deleteJob = new EmptyDirectoryJobb("TestJob", emptyDirectory).Execute();

            Assert.AreEqual(JobbReturnCode.Success, deleteJob);
        }

        [TestMethod]
        public void ExecuteEmptyDirectoryJobbError() {
            var deleteJob = new EmptyDirectoryJobb("TestJob", "invalidFilePath").Execute();
            Assert.AreEqual(JobbReturnCode.Error, deleteJob);
        }

        [TestMethod]
        public void ReturnCodeIsSetToWaitingAfterConstructor()
        {
            const JobbReturnCode expected = JobbReturnCode.Waiting;
            
            var deleteJob = new EmptyDirectoryJobb("TestJob", emptyDirectory); 
            
            Assert.AreEqual(expected,deleteJob.ReturnCode);
        }

        [TestMethod]
        public void GetNameTest()
        {
            const string expected = "Testname";
            
            var deleteJob = new EmptyDirectoryJobb("Testname", emptyDirectory);

            Assert.AreEqual(expected, deleteJob.Name);
        }
    }
}