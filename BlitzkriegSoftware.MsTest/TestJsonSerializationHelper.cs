using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitzkriegSoftware.MsTest
{
    /// <summary>
    /// An Extension to compare if a class serializes to JSON and back correctly.
    /// <para>Two potential Strategies</para>
    /// </summary>
    public static class TestJsonSerializationHelper
    {
        /// <summary>
        /// Tests that a model serializes correctly, will fail the internal <c>Assert</c> if not.
        /// <para>Does not always work with some classes with odd properties</para>
        /// <para>This is our home grown method</para>
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
                        Assert.AreEqual(t1[key].ToString(), t2[key].ToString(), message: key);
                    }
                }
            }
        }

        /// <summary>
        /// Tries a different approach, using JTokens
        /// <para>
        /// Convert JSON to JToken
        /// <code>
        /// JToken token = JToken.Parse(jsonString);
        /// </code>
        /// </para>
        /// <para>From a suggestion from <![CDATA[https://stackoverflow.com/questions/52645603/how-to-compare-two-json-objects-using-c-sharp]]></para>
        /// </summary>
        /// <param name="actual">Actual</param>
        /// <param name="expected">Expected</param>
        /// <param name="changedItems">list of diffs for a log</param>
        /// <returns>JObject containing diff</returns>
        /// <exception cref="ArgumentTypeMismatchException">Passed types do not agree</exception>
        public static JObject FindDiff(this JToken actual, JToken expected, ref List<string> changedItems)
        {
            JObject diff = new();
            string valueToPrint = string.Empty;
            if (JToken.DeepEquals(actual, expected)) return diff;
            else if (actual.Type != expected.Type)
            {
                throw new ArgumentTypeMismatchException("Passed types do not match");
            }

            switch (actual.Type)
            {
                case JTokenType.Object:
                    {
                        var Initial = actual as JObject;
                        var Updated = expected as JObject;
                        var addedKeys = Initial.Properties().Select(c => c.Name).Except(Updated.Properties().Select(c => c.Name));
                        var removedKeys = Updated.Properties().Select(c => c.Name).Except(Initial.Properties().Select(c => c.Name));
                        var unchangedKeys = Initial.Properties().Where(c => JToken.DeepEquals(c.Value, expected[c.Name])).Select(c => c.Name);

                        foreach (var k in addedKeys)
                        {
                            diff[k] = new JObject
                            {
                                ["+"] = actual[k]
                            };
                            changedItems.Add($"+ Item: `{k}`");
                        }

                        foreach (var k in removedKeys)
                        {
                            diff[k] = new JObject
                            {
                                ["-"] = expected[k]
                            };
                            changedItems.Add($"- Item: `{k}`");
                        }

                        var potentiallyModifiedKeys = Initial.Properties().Select(c => c.Name).Except(addedKeys).Except(unchangedKeys);
                        foreach (var k in potentiallyModifiedKeys)
                        {
                            var foundDiff = FindDiff(Initial[k], Updated[k], ref changedItems);

                            if (foundDiff.HasValues && (foundDiff["+"] != null || foundDiff["-"] != null))
                            {
                                //Execute when json element is equatable
                                if (IsValueChanged(foundDiff))
                                {
                                    changedItems.Add($"actual value '{foundDiff["+"]}' is not equal to expected value '{foundDiff["-"]}'");
                                }
                                //Execute when json element is an Array
                                else
                                {
                                    for (int i = 0; i < foundDiff["+"].Count(); i++)
                                    {
                                        var foundDiffOfArray = FindDiff(foundDiff["+"][i], foundDiff["-"][i], ref changedItems);
                                        if (IsValueChanged(foundDiffOfArray))
                                        {
                                            changedItems.Add($"actual value '{foundDiff["+"]}' is not equal to expected value '{foundDiff["-"]}'");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;

                //"+" indicate the Original Value
                //"-" indicate the Updated/Modified Value
                case JTokenType.Array:
                    {
                        var current = actual as JArray;
                        var model = expected as JArray;
                        var plus = new JArray(current.ExceptAll(model, new JTokenEqualityComparer()));
                        var minus = new JArray(model.ExceptAll(current, new JTokenEqualityComparer()));
                        if (plus.HasValues) {
                            diff["+"] = plus;
                            changedItems.Add($"+ {plus}");
                        }

                        if (minus.HasValues) { 
                            diff["-"] = minus;
                            changedItems.Add($"- {minus}");
                        }
                    }
                    break;
                default:
                    diff["+"] = actual;
                    diff["-"] = expected;
                    changedItems.Add($"- {actual} vs. +{expected}");
                    break;
            }

            return diff;
        }

        private static bool IsValueChanged(JObject foundDiff)
        {
            return (foundDiff["-"] != null)
                || (foundDiff["+"] != null);
        }

        private static IEnumerable<TSource> ExceptAll<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            if (first == null) { throw new ArgumentNullException(nameof(first)); }
            if (second == null) { throw new ArgumentNullException(nameof(second)); }

            var secondCounts = new Dictionary<TSource, int>(comparer ?? EqualityComparer<TSource>.Default);
            int count;
            int nullCount = 0;

            // Count the values from second
            foreach (var item in second)
            {
                if (item == null)
                {
                    nullCount++;
                }
                else
                {
                    if (secondCounts.TryGetValue(item, out count))
                    {
                        secondCounts[item] = count + 1;
                    }
                    else
                    {
                        secondCounts.Add(item, 1);
                    }
                }
            }

            // Yield the values from first
            foreach (var item in first)
            {
                if (item == null)
                {
                    nullCount--;
                    if (nullCount < 0)
                    {
                        yield return item;
                    }
                }
                else
                {
                    if (secondCounts.TryGetValue(item, out count))
                    {
                        if (count == 0)
                        {
                            secondCounts.Remove(item);
                            yield return item;
                        }
                        else
                        {
                            secondCounts[item] = count - 1;
                        }
                    }
                    else
                    {
                        yield return item;
                    }
                }
            }
        }

    }
}
