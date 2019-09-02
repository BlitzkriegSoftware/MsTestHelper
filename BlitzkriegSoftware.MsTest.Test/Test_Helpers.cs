using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlitzkriegSoftware.MsTest;
using System;
using System.Threading;

namespace BlitzkriegSoftware.MsTest.Test
{
    /// <summary>
    /// Main Unit Tests
    /// </summary>
    [TestClass]
    public class Test_Helpers
    {
        #region "Boilerplate"

        private static TestContext _testContext;
        private static ILogger _logger;

        /// <summary>
        /// This runs before testing
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize]
        public static void SetupTests(TestContext testContext)
        {
            _testContext = testContext;
            _logger = new MsTestLogger<Test_Helpers>(testContext);
        }

        /// <summary>
        /// Clean up after all tests in the class has run
        /// </summary>
        [TestCleanup]
        public static void CleanUpTests()
        {
            // Do what ever clean up you want
        }


        #endregion

        /// <summary>
        /// Test MS Logging Extensions
        /// </summary>
        [TestMethod]
        [TestCategory("Unit-Test")]
        [Description("Redirect Logging to TestContext Output")]
        public void Test_Logger()
        {
            var ex = new InvalidOperationException();
            _logger.LogCritical(ex, "Critical");
        }

        /// <summary>
        /// Test Timer
        /// </summary>
        [TestMethod]
        [TestCategory("Unit-Test")]
        [Description("Show the Test Timer")]
        public void Test_Timer()
        {
            using(var tx = new TxTimer())
            {
                Thread.Sleep(10);
                _testContext.WriteLine("Elapsed: {0}", TxTimer.DisplayElaspsedTime(tx.ElapsedMilliseconds));
            }
        }

        /// <summary>
        /// Serialization to JSON
        /// </summary>
        [TestMethod]
        [TestCategory("Unit-Test")]
        [Description("Show how to dump objects as JSON to Test Output, and Test to Make sure it JSON Serializes")]
        public void Test_AssertHelper()
        {
            var model = new Models.TestModel();
            model.Populate();
            _testContext.AsJson(model, "Test Model");
            AssertHelpers.AssertSerialization<Models.TestModel>(model, _testContext);
        }

    }
}
