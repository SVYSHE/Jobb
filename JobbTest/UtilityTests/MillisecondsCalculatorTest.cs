using Jobb.Models.Implementations;
using Jobb.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JobbTest.UtilityTests {
    [TestClass]
    public class MillisecondsCalculatorTest {
        [DataTestMethod]
        [DataRow(Period.Seconds, (ulong)1_000)]
        [DataRow(Period.Minutes, (ulong)60_000)]
        [DataRow(Period.Hours, (ulong)3_600_000)]
        [DataRow(Period.Days, (ulong)86_400_000)]
        [DataRow(Period.Weeks, (ulong)604_800_016)]
        [DataRow(Period.Months, (ulong)2_629_800_000)]
        [DataRow(Period.Years, (ulong)31_557_600_000)]
        public void GetMilliseconds_WithDifferentValues_Valid(Period period, ulong expectedMs) {
            var ms = MillisecondsCalculator.GetMilliseconds(new Schedule(period, 1));
            Assert.AreEqual(expectedMs, ms);
        }
    }
}
