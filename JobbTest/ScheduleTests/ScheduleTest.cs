using System;
using System.IO;
using System.Threading;
using Jobb.Models.Implementations;
using Jobb.Models.Implementations.Jobbs;
using Jobb.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JobbTest.ScheduleTests {
    [TestClass]
    public class ScheduleTest : TestBase {

        [DataTestMethod]
        [DataRow(Period.Seconds, 60)]
        [DataRow(Period.Minutes, 60)]
        [DataRow(Period.Hours, 24)]
        [DataRow(Period.Days, 32)]
        [DataRow(Period.Weeks, 52)]
        [DataRow(Period.Months, 13)]
        [DataRow(Period.Years, 0)]
        [ExpectedException(typeof(ArgumentException))]
        public void ExecuteEmptyDirectoryJobbWithInvalidSchedulePeriods(Period period, int unit) => new Schedule(period, unit);

        [TestMethod]
        public void ExecuteEmptyDirectoryJobbAfterSetScheduleSuccess() {
            var schedule = new Schedule(Period.Seconds, 1);
            var emptyDirectory = Path.Combine(LocalResourceTestDataPath, "EmptyDirectory");
            CreateFolder(emptyDirectory);
            var deleteJob = new EmptyDirectoryJobb("TestJob", schedule, emptyDirectory);
            Assert.AreEqual(JobbReturnCode.Waiting, deleteJob.ReturnCode);
            Thread.Sleep(2000);
            Assert.AreEqual(JobbReturnCode.Success, deleteJob.ReturnCode);
        }
    }
}
