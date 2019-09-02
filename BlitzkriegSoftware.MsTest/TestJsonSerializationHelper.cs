using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitzkriegSoftware.MsTest
{
    /// <summary>
    /// An Extension to use the helper from TestContext
    /// </summary>
    public static class TestJsonSerializationHelper
    {
        /// <summary>
        /// Tests that a model serializes correctly, will fail the internal <c>Assert</c> if not.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="thing1">Instance of T to test</param>
        /// <param name="testContext">TestContext</param>
        public static void AssertJsonSerialization<T>(this TestContext testContext, T thing1)
        {
            var json = JsonConvert.SerializeObject(thing1);

            testContext.WriteLine("{0} -> {1}", thing1.GetType().Name, json);

            T thing2 = JsonConvert.DeserializeObject<T>(json);

            Dictionary<String, Object> t1 = thing1.GetType()
                .GetProperties()
                .Where(p => p.CanRead)
                .ToDictionary(p => p.Name, p => p.GetValue(thing1, null));

            Dictionary<String, Object> t2 = thing2.GetType()
                .GetProperties()
                .Where(p => p.CanRead)
                .ToDictionary(p => p.Name, p => p.GetValue(thing2, null));

            foreach (var key in t1.Keys)
            {
                var type = thing1.GetType();
                var mem = type.GetMember(key).First();
                if (!Attribute.IsDefined(mem, typeof(JsonIgnoreAttribute)))
                {
                    if (t1[key] != null)
                    {
                        Assert.AreEqual(t1[key].ToString(), t2[key].ToString());
                    }
                }
            }
        }

    }
}
