using BlitzkriegSoftware.MsTest.Test.Models;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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

#pragma warning disable IDE0063 // A timer in a using should have an explict block
            using(TxTimer tx2 = new(_testContext))
            {
                tx2.Cancel();
            }
#pragma warning restore IDE0063 // Use simple 'using' statement

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
            var model = new Models.TestModel(true);

            // Just Dump it as Json
            _testContext.AsJson(model, "Test Model");
            
            // Json Dump, No title
            _testContext.AsJson(model);

            // Assert that it will Json Serialize
            _testContext.AssertJsonSerialization<Models.TestModel>(model);
        }

        /// <summary>
        /// An alternative to testing serialization or comparing two objects
        /// </summary>
        [TestMethod]
        public void Test_JsonDiff_1()
        {
            var errors = new List<string>();

            // Make a model and fill it with data
            var model = new Models.TestModel(true);
            var json1 = model.AsJsonString<Models.TestModel>();
            var actual = JToken.Parse(json1);

            var model2 = JsonConvert.DeserializeObject<Models.TestModel>(json1);
            var json2 = model2.AsJsonString<Models.TestModel>(); 
            var expected = JToken.Parse(json2);

            _ = actual.FindDiff(expected, ref errors);

            var pass = (errors == null || errors.Count == 0);
            Assert.IsTrue(pass);
        }


        /// <summary>
        /// An alternative to testing serialization or comparing two objects
        /// </summary>
        [TestMethod]
        public void Test_JsonDiff_2()
        {
            var errors = new List<string>();

            // Make a model and fill it with data
            var model = new Models.TestModel(true);
            var json1 = model.AsJsonString<Models.TestModel>();
            var actual = JToken.Parse(json1);

            var model2 = JsonConvert.DeserializeObject<Models.TestModel>(json1);
            model2.BigCounter = 99;
            model2.Science = 3242.33f;
            var json2 = model2.AsJsonString<Models.TestModel>();
            var expected = JToken.Parse(json2);

            _ = actual.FindDiff(expected, ref errors);

            var pass = (errors == null || errors.Count == 0);
            Assert.IsFalse(pass);
        }

        /// <summary>
        /// An alternative to testing serialization or comparing two objects
        /// </summary>
        [TestMethod]
        public void Test_JsonDiff_3()
        {
            var errors = new List<string>();

            // Make a model and fill it with data
            var model = ListHelper.ListMaker();
            var json1 = model.AsJsonString<List<string>>();
            var actual = JToken.Parse(json1);

            var model2 = JsonConvert.DeserializeObject<List<string>>(json1);
            model2.Remove(model2[0]);
            model2.Add(Faker.Lorem.Word());
            model2.Add(Faker.Lorem.Word());
            var json2 = model2.AsJsonString<List<string>>();
            var expected = JToken.Parse(json2);

            _ = actual.FindDiff(expected, ref errors);

            var pass = (errors == null || errors.Count == 0);
            Assert.IsFalse(pass);
        }

    }
}
