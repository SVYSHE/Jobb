using Jobb.Models.Implementations;
using Jobb.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JobbTest.UtilityTests
{
    [TestClass]
    public class ScheduleUtilityTest
    {
        [TestMethod]
        public void GetScheduleFromString_Test()
        {
            var expected = new Schedule(Period.Seconds, 1);

            Schedule actual = ScheduleUtility.GetScheduleFromString("secOnds", "1");
            
            Assert.AreEqual(expected.Period, actual.Period);
            Assert.AreEqual(expected.Unit, actual.Unit);
        }
    }
}