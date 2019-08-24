using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BlitzkriegSoftware.MsTest
{
    /// <summary>
    /// ILogger for MsTest
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MsTestLogger<T> : ILogger<T>, IDisposable
    {
        private TestContext _output;

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="output">TestContext</param>
        public MsTestLogger(TestContext output)
        {
            _output = output;
        }

        /// <summary>
        /// Log (Contract method)
        /// </summary>
        /// <typeparam name="TState">TState</typeparam>
        /// <param name="logLevel">LogLevel</param>
        /// <param name="eventId">EventId</param>
        /// <param name="state">TState</param>
        /// <param name="exception">Exception</param>
        /// <param name="formatter">Function Formatter</param>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            _output.WriteLine("{0}: {1}\n{2}", logLevel, state.ToString(), (exception == null) ? string.Empty : exception.ToString());
        }

        /// <summary>
        /// IsEnabled
        /// </summary>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        /// <summary>
        /// Begin Scope
        /// </summary>
        /// <typeparam name="TState"></typeparam>
        /// <param name="state">TState</param>
        /// <returns>this</returns>
        public IDisposable BeginScope<TState>(TState state)
        {
            return this;
        }

        /// <summary>
        /// Dispose (DTOR)
        /// </summary>
        public void Dispose()
        {
        }
    }
}
