using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public sealed class WithInitializer
    {
        private string testString;

        [TestInitialize]
        public void Initialize()
        {
            testString = "Testing";
        }

        [TestMethod]
        public void ThisMethod_ShouldWork_WhenInitializerHasRun()
        {
            Assert.AreEqual("Testing", testString);
        }
    }
}
