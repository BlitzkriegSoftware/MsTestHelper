using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlitzkriegSoftware.MsTest;
using System;
using System.Threading;

namespace BlitzkriegSoftware.MsTest.Test
{
    [TestClass]
    public class Test_Helpers
    {
        #region "Boilerplate"

        private static TestContext _testContext;
        private static ILogger _logger;

        [ClassInitialize]
        public static void SetupTests(TestContext testContext)
        {
            _testContext = testContext;
            _logger = new MsTestLogger<Test_Helpers>(testContext);
        }

        #endregion

        [TestMethod]
        [TestCategory("Unit-Test")]
        public void Test_Logger()
        {
            var ex = new InvalidOperationException();
            _logger.LogCritical(ex, "Critical");
        }

        [TestMethod]
        [TestCategory("Unit-Test")]
        public void Test_Timer()
        {
            using(var tx = new TxTimer())
            {
                Thread.Sleep(10);
                _testContext.WriteLine("Elapsed: {0}", TxTimer.DisplayElaspsedTime(tx.ElapsedMilliseconds));
            }
        }

        [TestMethod]
        [TestCategory("Unit-Test")]
        public void Test_AssertHelper()
        {
            var model = new Models.TestModel();
            model.Populate();
            AssertHelpers.AssertSerialization<Models.TestModel>(model, _testContext);
        }

    }
}
