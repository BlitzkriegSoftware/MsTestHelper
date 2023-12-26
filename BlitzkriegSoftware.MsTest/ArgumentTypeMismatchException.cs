using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace BlitzkriegSoftware.MsTest
{
    /// <summary>
    /// Exception: Passed types do not agree
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class ArgumentTypeMismatchException : Exception
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public ArgumentTypeMismatchException() : base() { }

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="message">(sic)</param>
        public ArgumentTypeMismatchException(string message) : base(message) { }

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="message">(sic)</param>
        /// <param name="innerException">(sic)</param>
        public ArgumentTypeMismatchException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// (serialization)
        /// </summary>
        /// <param name="info">(sic)</param>
        /// <param name="context">(sic)</param>
        public ArgumentTypeMismatchException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}

