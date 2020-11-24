using System.IO;
using Jobb.Models.Implementations;
using Jobb.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JobbTest.ModelTests {
    [TestClass]
    public class CopyFileJobbTest : TestBase {
        private string fromDirectory;
        private string toDirectory;
        private readonly string fileToCopy = "helloWorld.txt";

        [TestInitialize]
        public void Init() {
            fromDirectory = Path.Combine(LocalResourceTestDataPath, "fromDirectory");
            CreateFolder(fromDirectory);
            CreateFile(Path.Combine(fromDirectory, fileToCopy));
            toDirectory = Path.Combine(LocalResourceTestDataPath, "toDirectory");
            CreateFolder(toDirectory);
        }

        [TestMethod]
        public void GetNameTest() {
            string expected = "test";

            var copyFileJobb = new CopyFileJobb("test", fromDirectory, toDirectory, fileToCopy);

            Assert.AreEqual(expected, copyFileJobb.Name);
        }

        [TestMethod]
        public void GetSourceDirectoryTest() {
            var copyFileJobb = new CopyFileJobb("a", fromDirectory, toDirectory, fileToCopy);

            Assert.AreEqual(fromDirectory, copyFileJobb.SourceDirectory);
        }

        [TestMethod]
        public void GetTargetDirectoryTest() {
            var copyFileJobb = new CopyFileJobb("a", fromDirectory, toDirectory, fileToCopy);

            Assert.AreEqual(toDirectory, copyFileJobb.TargetDirectory);
        }

        [TestMethod]
        public void GetFileNameDirectoryTest() {
            var copyFileJobb = new CopyFileJobb("a", fromDirectory, toDirectory, fileToCopy);

            Assert.AreEqual(fileToCopy, copyFileJobb.FileName);
        }

        [TestMethod]
        public void ReturnCodeIsSetToWaitingAfterConstructor() {
            const JobbReturnCode expected = JobbReturnCode.Waiting;

            var copyFileJobb = new CopyFileJobb("", "", "", "");

            Assert.AreEqual(expected, copyFileJobb.ReturnCode);
        }

        [TestMethod]
        public void ExecuteCopyFileJobbSuccess() {
            var copyFileJobb = new CopyFileJobb("a", fromDirectory, toDirectory, fileToCopy).Execute();

            Assert.AreEqual(JobbReturnCode.Success, copyFileJobb);
        }

        [TestMethod]
        public void ExecuteCopyFileJobbError() {
            var copyFileJobb = new CopyFileJobb("a", fromDirectory, "invalidFolderPath", fileToCopy).Execute();

            Assert.AreEqual(JobbReturnCode.Error, copyFileJobb);
        }
    }
}