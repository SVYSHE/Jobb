using System.IO;
using Jobb.Models.Implementations;
using Jobb.Models.Implementations.Jobbs;
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

            var copyFileJobb = new CopyFileJobb(
                new CopyFileJobbParameters {
                    Name = "test",
                    Schedule = new Schedule(),
                    SourceDirectory = fromDirectory,
                    TargetDirectory = toDirectory,
                    FileName = fileToCopy
                }
            );

            Assert.AreEqual(expected, copyFileJobb.Parameters.Name);
        }

        [TestMethod]
        public void GetSourceDirectoryTest() {
            var copyFileJobb = new CopyFileJobb(new CopyFileJobbParameters {
                Name = "a",
                Schedule = new Schedule(),
                SourceDirectory = fromDirectory,
                TargetDirectory = toDirectory,
                FileName = fileToCopy
            });

            Assert.AreEqual(fromDirectory, copyFileJobb.Parameters.SourceDirectory);
        }

        [TestMethod]
        public void GetTargetDirectoryTest() {
            var copyFileJobb = new CopyFileJobb(new CopyFileJobbParameters {
                Name = "a",
                Schedule = new Schedule(),
                SourceDirectory = fromDirectory,
                TargetDirectory = toDirectory,
                FileName = fileToCopy
            });

            Assert.AreEqual(toDirectory, copyFileJobb.Parameters.TargetDirectory);
        }

        [TestMethod]
        public void GetFileNameDirectoryTest() {
            var copyFileJobb = new CopyFileJobb(new CopyFileJobbParameters {
                Name = "a",
                Schedule = new Schedule(),
                SourceDirectory = fromDirectory,
                TargetDirectory = toDirectory,
                FileName = fileToCopy
            });

            Assert.AreEqual(fileToCopy, copyFileJobb.Parameters.FileName);
        }

        [TestMethod]
        public void ReturnCodeIsSetToWaitingAfterConstructor() {
            const JobbReturnCode expected = JobbReturnCode.Waiting;

            var copyFileJobb = new CopyFileJobb(new CopyFileJobbParameters {
                Name = "a",
                Schedule = new Schedule(),
                SourceDirectory = "a",
                TargetDirectory = "a",
                FileName = "a"
            });

            Assert.AreEqual(expected, copyFileJobb.Parameters.ReturnCode);
        }

        [TestMethod]
        public void ExecuteCopyFileJobbSuccess() {
            var copyFileJobb = new CopyFileJobb(new CopyFileJobbParameters {
                Name = "a",
                Schedule = new Schedule(),
                SourceDirectory = fromDirectory,
                TargetDirectory = toDirectory,
                FileName = fileToCopy
            }).Execute();

            Assert.AreEqual(JobbReturnCode.Success, copyFileJobb);
        }

        [TestMethod]
        public void ExecuteCopyFileJobbError() {
            var copyFileJobb = new CopyFileJobb(new CopyFileJobbParameters {
                Name = "a",
                Schedule = new Schedule(),
                SourceDirectory = fromDirectory,
                TargetDirectory = "invalidFolderPath",
                FileName = fileToCopy
            }).Execute();

            Assert.AreEqual(JobbReturnCode.Error, copyFileJobb);
        }
    }
}