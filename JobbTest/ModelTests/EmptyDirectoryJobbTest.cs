using System.IO;
using Jobb.Models.Implementations;
using Jobb.Models.Implementations.Jobbs;
using Jobb.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JobbTest.ModelTests {
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
            var deleteJob = new EmptyDirectoryJobb("TestJob", new Schedule(), emptyDirectory).Execute();
            

            Assert.AreEqual(JobbReturnCode.Success, deleteJob);
        }

        [TestMethod]
        public void ExecuteEmptyDirectoryJobbMultipleFilesSuccess() {
            var expected = JobbReturnCode.Success;
            var testFolder = LocalResourceTestDataPath;
            CreateFolder(testFolder);

            for (int i = 0; i < 3; i++) {
                CreateFile(Path.Combine(emptyDirectory, i.ToString()));
            }

            var deleteJob = new EmptyDirectoryJobb("Testjobb", new Schedule(), LocalResourceTestDataPath).Execute();

            Assert.AreEqual(expected, deleteJob);
        }

        [TestMethod]
        public void ExecuteEmptyDirectoryJobbError() {
            var deleteJob = new EmptyDirectoryJobb("TestJob", new Schedule(), "invalidFilePath").Execute();
            Assert.AreEqual(JobbReturnCode.Error, deleteJob);
        }

        [TestMethod]
        public void ReturnCodeIsSetToWaitingAfterConstructor()
        {
            const JobbReturnCode expected = JobbReturnCode.Waiting;
            
            var deleteJob = new EmptyDirectoryJobb("TestJob", new Schedule(), emptyDirectory); 
            
            Assert.AreEqual(expected,deleteJob.ReturnCode);
        }

        [TestMethod]
        public void GetNameTest()
        {
            const string expected = "Testname";
            
            var deleteJob = new EmptyDirectoryJobb("Testname", new Schedule(), emptyDirectory);

            Assert.AreEqual(expected, deleteJob.Name);
        }

        [TestMethod]
        public void GetTargetDirectoryTest()
        {
            string expected = LocalResourceTestDataPath;
            
            var deleteJob = new EmptyDirectoryJobb("Test", new Schedule(), LocalResourceTestDataPath);
            
            Assert.AreEqual(expected, deleteJob.TargetDirectory);
        }
    }
}