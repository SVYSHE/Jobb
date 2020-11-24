using Jobb.Models.Implementations;
using Jobb.Models.Implementations.Jobbs;
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
            const string expected = "test";

            var copyFileJobb = new CopyFileJobb("test",new Schedule(), "abcdef", "ghijkl", "test");

            Assert.AreEqual(expected, copyFileJobb.Name);
        }

        [TestMethod]
        public void GetSourceDirectoryTest()
        {
            const string expected = "test";

            var copyFileJobb = new CopyFileJobb("a",new Schedule(), "test", "b", "c");

            Assert.AreEqual(expected, copyFileJobb.SourceDirectory);
        }

        [TestMethod]
        public void GetTargetDirectoryTest()
        {
            const string expected = "b";

            var copyFileJobb = new CopyFileJobb("a", new Schedule(), "test", "b", "c");

            Assert.AreEqual(expected, copyFileJobb.TargetDirectory);
        }

        [TestMethod]
        public void GetFileNameDirectoryTest()
        {
            const string expected = "c";

            var copyFileJobb = new CopyFileJobb("a",new Schedule(), "test", "b", "c");

            Assert.AreEqual(expected, copyFileJobb.FileName);
        }

        [TestMethod]
        public void ReturnCodeIsSetToWaitingAfterConstructor()
        {
            const JobbReturnCode expected = JobbReturnCode.Waiting;

            var copyFileJobb = new CopyFileJobb("", new Schedule(), "", "", "");

            Assert.AreEqual(expected, copyFileJobb.ReturnCode);
        }
        
        // TODO: Test Execute() Method.
    }
}