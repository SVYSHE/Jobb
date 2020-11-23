using Jobb.Models.Implementations;
using Jobb.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JobbTest.ModelTests
{
    [TestClass]
    public class CopyFileJobbTest
    {
        [TestMethod]
        public void GetNameTest()
        {
            string expected = "test";

            CopyFileJobb copyFileJobb = new CopyFileJobb("test", "abcdef", "ghijkl", "test");

            Assert.AreEqual(expected, copyFileJobb.Name);
        }

        [TestMethod]
        public void GetSourceDirectoryTest()
        {
            string expected = "test";

            CopyFileJobb copyFileJobb = new CopyFileJobb("a", "test", "b", "c");

            Assert.AreEqual(expected, copyFileJobb.SourceDirectory);
        }

        [TestMethod]
        public void GetTargetDirectoryTest()
        {
            string expected = "b";

            CopyFileJobb copyFileJobb = new CopyFileJobb("a", "test", "b", "c");

            Assert.AreEqual(expected, copyFileJobb.TargetDirectory);
        }

        [TestMethod]
        public void GetFileNameDirectoryTest()
        {
            string expected = "c";

            CopyFileJobb copyFileJobb = new CopyFileJobb("a", "test", "b", "c");

            Assert.AreEqual(expected, copyFileJobb.FileName);
        }

        [TestMethod]
        public void ReturnCodeIsSetToWaitingAfterConstructor()
        {
            const JobbReturnCode expected = JobbReturnCode.Waiting;

            var copyFileJobb = new CopyFileJobb("", "", "", "");

            Assert.AreEqual(expected, copyFileJobb.ReturnCode);
        }
        
        // TODO: Test Execute() Method.
    }
}