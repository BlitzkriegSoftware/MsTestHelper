using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace BlitzkriegSoftware.MsTest.Test
{
    /// <summary>
    /// Main Unit Tests <c>BlitzkriegSoftware.MsTest</c>
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
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
        public void CleanUpTests()
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
            bool enabled = _logger.IsEnabled(LogLevel.Critical);
            Assert.IsTrue(enabled, "Critical Should Be Enabled");
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
            using(var tx = new TxTimer(_testContext, "Test"))
            {
                tx.Reset();
                using (var scope = _logger.BeginScope("In Timer"))
                {
                    Thread.Sleep(10);
                }

                _testContext.WriteLine($"{tx.IsRunning}, {tx.ElapsedMilliseconds}, {tx.ElaspsedTicks}");
            }

            using(TxTimer tx2 = new TxTimer(_testContext))
            {
                tx2.Cancel();
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
            // Make a model and fill it with data
            var model = new Models.TestModel();
            model.Populate();

            // Just Dump it as Json
            _testContext.AsJson(model, "Test Model");
            
            // No title
            _testContext.AsJson(model);

            // Assert that it will Json Serialize
            _testContext.AssertJsonSerialization<Models.TestModel>(model);
        }

    }
}
