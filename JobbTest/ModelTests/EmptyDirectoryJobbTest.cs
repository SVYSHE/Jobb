using System.IO;
using Jobb.Exceptions;
using Jobb.Models.Implementations;
using Jobb.Models.Implementations.Jobbs;
using Jobb.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JobbTest.ModelTests {
    [TestClass]
    public class EmptyDirectoryJobbTest : TestBase {
        private string emptyDirectory;
        private readonly string testFile = "emptyTestFile.txt";

        [TestInitialize]
        public void Init() {
            emptyDirectory = Path.Combine(LocalResourceTestDataPath, "EmptyDirectory");
            CreateFolder(emptyDirectory);
            CreateFile(Path.Combine(emptyDirectory, testFile));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidJobbParametersException))]
        public void ExecuteJobbNullInParametersInvalid() {
            var param = new EmptyDirectoryJobbParameters {
                Name = "abc",
                TargetDirectory = "abc",
                Schedule = null
            };
            _ = new EmptyDirectoryJobb(param);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidJobbParametersException))]
        public void ExecuteJobbEmptyStringInParametersInvalid() {
            var param = new EmptyDirectoryJobbParameters {
                Name = "",
                TargetDirectory = "abc",
                Schedule = null
            };
            _ = new EmptyDirectoryJobb(param);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidJobbParametersException))]
        public void ExecuteJobbParametersAreNullInvalid() {
            _ = new EmptyDirectoryJobb(null);
        }

        [TestMethod]
        public void ExecuteEmptyDirectoryJobbSuccess() {
            var deleteJob = new EmptyDirectoryJobb(
                new EmptyDirectoryJobbParameters {
                    Name = "TestJob",
                    Schedule = new Schedule(),
                    TargetDirectory = emptyDirectory
                }).Execute();

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

            var deleteJob = new EmptyDirectoryJobb(
                new EmptyDirectoryJobbParameters {
                    Name = "Testjobb",
                    Schedule = new Schedule(),
                    TargetDirectory = LocalResourceTestDataPath
                }).Execute();

            Assert.AreEqual(expected, deleteJob);
        }

        [TestMethod]
        public void ExecuteEmptyDirectoryJobbError() {
            var deleteJob = new EmptyDirectoryJobb(
                new EmptyDirectoryJobbParameters {
                    Name = "TestJob",
                    Schedule = new Schedule(),
                    TargetDirectory = "invalidFilePath"
                }).Execute();

            Assert.AreEqual(JobbReturnCode.Error, deleteJob);
        }

        [TestMethod]
        public void ReturnCodeIsSetToWaitingAfterConstructor() {
            const JobbReturnCode expected = JobbReturnCode.Waiting;

            var deleteJob = new EmptyDirectoryJobb(
                new EmptyDirectoryJobbParameters {
                    Name = "TestJob",
                    Schedule = new Schedule(),
                    TargetDirectory = emptyDirectory
                });

            Assert.AreEqual(expected, deleteJob.Parameters.ReturnCode);
        }

        [TestMethod]
        public void GetNameTest() {
            const string expected = "Testname";

            var deleteJob = new EmptyDirectoryJobb(
                new EmptyDirectoryJobbParameters {
                    Name = "Testname",
                    Schedule = new Schedule(),
                    TargetDirectory = emptyDirectory
                });

            Assert.AreEqual(expected, deleteJob.Parameters.Name);
        }

        [TestMethod]
        public void GetTargetDirectoryTest() {
            string expected = LocalResourceTestDataPath;

            var deleteJob = new EmptyDirectoryJobb(
                new EmptyDirectoryJobbParameters {
                    Name = "Test",
                    Schedule = new Schedule(),
                    TargetDirectory = LocalResourceTestDataPath
                });

            Assert.AreEqual(expected, deleteJob.Parameters.TargetDirectory);
        }
    }
}