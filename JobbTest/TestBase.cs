using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JobbTest {
    public class TestBase {
        protected string LocalResourceTestDataPath { get; private set; }

        public TestBase() {
            InitPaths();
        }

        private void InitPaths() {
            string executionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string resourcePath = Path.Combine(executionPath, @"resources\testdata");
            if (!Directory.Exists(resourcePath)) {
                Directory.CreateDirectory(resourcePath);
            }
            LocalResourceTestDataPath = resourcePath;
        }

        protected static void CreateFolder(string folderPath) {
            Directory.CreateDirectory(folderPath);
        }

        protected static void CreateFile(string fileName) {
            File.Create(fileName).Dispose();
        }

        [TestCleanup]
        public virtual void AfterTest() {
            if (Directory.Exists(LocalResourceTestDataPath)) {
                Directory.Delete(LocalResourceTestDataPath, true);
            }
        }
    }
}
