using System.IO;
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
            
            var deleteJob = new EmptyDirectoryJobb("TestJob", @"abc123"); 
            
            Assert.AreEqual(expected,deleteJob.ReturnCode);
        }

        [TestMethod]
        public void GetNameTest()
        {
            const string expected = "Testname";
            
            var deleteJob = new EmptyDirectoryJobb("Testname", @"abc123");
            
            Assert.AreEqual(expected, deleteJob.Name);
        }

        [TestMethod]
        public void GetTargetDirectoryTest()
        {
            string expected = @"C:\Test";
            
            var deleteJob = new EmptyDirectoryJobb("Test", @"C:\Test");
            
            Assert.AreEqual(expected, deleteJob.TargetDirectory);
        }

        
        
        [TestMethod]
        public void ExecuteTest()
        {
            var expected = JobbReturnCode.Success;
            for (int i = 0; i < 3; i++)
            {
                File.Create(@"C:\Test\" + i.ToString()).Close();
            }
            EmptyDirectoryJobb deleteJob = new EmptyDirectoryJobb("Testjobb", @"C:\Test");
            deleteJob.Execute();

            Assert.AreEqual(expected,deleteJob.ReturnCode);
        }

        [TestMethod]
        public void ExecuteFailsTest()
        {
            var expected = JobbReturnCode.Error;

            if (Directory.Exists(@"C:\asodgjoüajhgüa"))
            {
                Directory.Delete(@"C:\asodgjoüajhgüa", true);
            }
            EmptyDirectoryJobb deleteJob = new EmptyDirectoryJobb("Testjobb", @"C:\asodgjoüajhgüa");
            deleteJob.Execute();
            Assert.AreEqual(expected, deleteJob.ReturnCode);
        }

        [TestMethod]
        public void ExecuteThrowsIoExceptionTest()
        {
            if (Directory.Exists(@"C:\asodgjoüajhgüa"))
            {
                Directory.Delete(@"C:\asodgjoüajhgüa", true);
            }
            EmptyDirectoryJobb deleteJob = new EmptyDirectoryJobb("Testjobb", @"C:\asodgjoüajhgüa");
            Assert.ThrowsException<IOException>(() => deleteJob.Execute());
        }
    }
}