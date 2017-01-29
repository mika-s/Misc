using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileInputAndOutput;

namespace Testing
{
    [TestClass]
    public sealed class BasicTesting
    {
        [TestMethod]
        public void BasicTest_ShouldPass_WhenRun()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ReadFileWithFileStream_ShouldThrowFileNotFoundException_WhenFileDoesntExist()
        {
            ReadOrdinaryFileService file = new ReadOrdinaryFileService("doesntexist");
            file.ReadFileWithFileStream();
        }
    }
}
