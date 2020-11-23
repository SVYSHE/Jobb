using Jobb.Models.Implementations;
using Jobb.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JobbTest.ModelTests
{
    [TestClass]
    public class EmptyDirectoryJobbTest
    {
        [TestMethod]
        public void ReturnCodeIsSetToWaitingAfterConstructor()
        {
            const JobbReturnCode expected = JobbReturnCode.Waiting;
            
            var deleteJob = new EmptyDirectoryJobb("TestJob", @"C:\"); 
            
            Assert.AreEqual(expected,deleteJob.ReturnCode);
        }

        [TestMethod]
        public void getNameTest()
        {
            const string expected = "Testname";
            
            var deleteJob = new EmptyDirectoryJobb("Testname", @"C:\");
            
            Assert.AreEqual(expected, deleteJob.Name);
        }
    }
}