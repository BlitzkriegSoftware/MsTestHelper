using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace BlitzkriegSoftware.MsTest
{
    /// <summary>
    /// Helper to output as JSON
    /// </summary>
    public static class TestOutputHelper
    {

        /// <summary>
        /// Emit an object as json
        /// </summary>
        /// <param name="output">ITestOutputHelper</param>
        /// <param name="o">object</param>
        /// <param name="title">(optional) Title</param>
        public static void AsJson(this TestContext output, object o, string title = null)
        {
            var json = JsonConvert.SerializeObject(o);
            if (string.IsNullOrWhiteSpace(title)) output.WriteLine("{0}", json);
            else output.WriteLine("{0}\n{1}", title, json);
        }
    }
}
