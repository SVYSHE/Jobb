using System.Collections.Generic;
using Jobb.Models.Implementations.Jobbs.CopyFile;
using Jobb.Models.Implementations.Jobbs.EmptyDirectory;
using Jobb.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JobbTest.UtilityTests {
    [TestClass]
    public class JobbFactoryTest
    {
        [TestMethod]
        public void GetJobb_CopyFile_Test()
        {
            const string expectedName = "TestJobb";
            const Period expectedPeriod = Period.Seconds;
            const int expectedUnit = 5;
            const string expectedSourceDir = "C:/Test";
            const string expectedTargetDir = "C:/Test2";
            const string expectedFileName = "NewFile.txt";
            
            var jobb = (CopyFileJobb) JobbFactory.GetJobb(JobbType.CopyFile, "TestJobb", "Seconds", "5", "C:/Test", "C:/Test2", "NewFile.txt");
            string actualName = jobb.Parameters.Name;
            var actualPeriod = jobb.Parameters.Schedule.Period;
            int actualUnit = jobb.Parameters.Schedule.Unit;
            string actualSourceDir = jobb.Parameters.SourceDirectory;
            string actualTargetDir = jobb.Parameters.TargetDirectory;
            string actualFileName = jobb.Parameters.FileName;
            
            Assert.AreEqual(expectedName,actualName);
            Assert.AreEqual(expectedPeriod,actualPeriod);
            Assert.AreEqual(expectedUnit, actualUnit);
            Assert.AreEqual(expectedSourceDir, actualSourceDir);
            Assert.AreEqual(expectedTargetDir, actualTargetDir);
            Assert.AreEqual(expectedFileName, actualFileName);
        }
        
        [TestMethod]
        public void GetJobb_EmptyDirectory_Test()
        {
            const string expectedName = "TestJobb";
            const Period expectedPeriod = Period.Seconds;
            const int expectedUnit = 5;
            const string expectedTargetDir = "C:/Test2";
            
            var jobb = (EmptyDirectoryJobb) JobbFactory.GetJobb(JobbType.EmptyDirectory, "TestJobb", "Seconds", "5", "C:/Test2");
            string actualName = jobb.Parameters.Name;
            var actualPeriod = jobb.Parameters.Schedule.Period;
            int actualUnit = jobb.Parameters.Schedule.Unit;
            string actualTargetDir = jobb.Parameters.TargetDirectory;

            Assert.AreEqual(expectedName,actualName);
            Assert.AreEqual(expectedPeriod,actualPeriod);
            Assert.AreEqual(expectedUnit, actualUnit);
            Assert.AreEqual(expectedTargetDir, actualTargetDir);
        }

        [TestMethod]
        public void GetJobbParameter_CopyFile_Test()
        {
            var expected = new List<string>(){"Name", "Period", "Unit", "Source Directory", "Target Directory", "File Name"};

            var actual = JobbFactory.GetJobbParameter(JobbType.CopyFile);
            
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);
            Assert.AreEqual(expected[4], actual[4]);
            Assert.AreEqual(expected[5], actual[5]);
        }

        [TestMethod]
        public void GetJobbParameter_EmptyDirectory_Test()
        {
            var expected = new List<string>(){"Name", "Period", "Unit", "Target Directory"};

            var actual = JobbFactory.GetJobbParameter(JobbType.EmptyDirectory);
            
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);
        }
    }
}