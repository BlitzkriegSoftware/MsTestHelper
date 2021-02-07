using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace BlitzkriegSoftware.MsTest
{
    /// <summary>
    /// Helpers to do asserts on objects in bulk
    /// </summary>
    public static class AssertHelpers
    {
        #region "Serialization Helper"

        /// <summary>
        /// Tests that a model serializes correctly
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="thing1">Instance of T to test</param>
        /// <param name="output">TestContext</param>
        [Obsolete("Please use extension on TestContext", true)]
        [ExcludeFromCodeCoverage]
        public static void AssertSerialization<T>(T thing1, TestContext output)
        {
            output.AssertJsonSerialization<T>(thing1);
        }

        #endregion

    }
}
