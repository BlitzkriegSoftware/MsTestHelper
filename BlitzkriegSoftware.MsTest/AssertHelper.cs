using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlitzkriegSoftware.MsTest
{
    /// <summary>
    /// Helpers to do asserts on objects in bulk
    /// </summary>
    public static class AssertHelpers
    {
        #region "Serialization Helper"

        /// <summary>
        /// XUnit Tests that a model serializes correctly
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="thing1">Instance of T to test</param>
        /// <param name="output">XUnit Test Output</param>
        public static void AssertSerialization<T>(T thing1, TestContext output)
        {
            var json = JsonConvert.SerializeObject(thing1);

            output.WriteLine("{0} -> {1}", thing1.GetType().Name, json);

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

        #endregion

    }

}
