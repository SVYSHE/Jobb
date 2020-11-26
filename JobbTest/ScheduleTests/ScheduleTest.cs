using System.IO;
using System.Threading;
using Jobb.Exceptions;
using Jobb.Models.Implementations;
using Jobb.Models.Implementations.Jobbs;
using Jobb.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JobbTest.ScheduleTests {
    [TestClass]
    public class ScheduleTest : TestBase {

        [DataTestMethod]
        [DataRow(Period.Seconds, 60)]
        [DataRow(Period.Seconds, 0)]
        [DataRow(Period.Seconds, -1)]
        [DataRow(Period.Minutes, 60)]
        [DataRow(Period.Minutes, 0)]
        [DataRow(Period.Minutes, -1)]
        [DataRow(Period.Hours, 24)]
        [DataRow(Period.Hours, 0)]
        [DataRow(Period.Hours, -1)]
        [DataRow(Period.Days, 32)]
        [DataRow(Period.Days, 0)]
        [DataRow(Period.Days, -1)]
        [DataRow(Period.Weeks, 52)]
        [DataRow(Period.Weeks, 0)]
        [DataRow(Period.Weeks, -1)]
        [DataRow(Period.Months, 12)]
        [DataRow(Period.Months, 0)]
        [DataRow(Period.Months, -1)]
        [DataRow(Period.Years, 0)]
        [ExpectedException(typeof(PeriodValueOutOfBoundsException))]
        public void ExecuteEmptyDirectoryJobbWithInvalidSchedulePeriods(Period period, int unit) => new Schedule(period, unit);

        [DataTestMethod]
        [DataRow(Period.Seconds, 59)]
        [DataRow(Period.Minutes, 59)]
        [DataRow(Period.Hours, 23)]
        [DataRow(Period.Days, 31)]
        [DataRow(Period.Weeks, 51)]
        [DataRow(Period.Months, 11)]
        [DataRow(Period.Years, 1)]
        public void ExecuteEmptyDirectoryJobbWithValidSchedulePeriods(Period period, int unit) => _ = new Schedule(period, unit);

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
