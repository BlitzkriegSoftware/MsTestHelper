using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BlitzkriegSoftware.MsTest.Test.Models
{
    /// <summary>
    /// Fake DTO Class (w. Self Populating Helpers)
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class TestModel
    {

        #region "CTOR"

        /// <summary>
        /// CTOR
        /// </summary>
        public TestModel() { }

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="doPopulate">Call Populate</param>
        public TestModel(bool doPopulate): base()
        {
            if(doPopulate) { Populate(); }
        }

        #endregion

        #region "Privates"
        private readonly Random _dice = new();
        #endregion

        #region "Properties"

        /// <summary>
        /// String
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// DateTime
        /// </summary>
        public DateTime Stamp { get; set; }
        /// <summary>
        /// Double
        /// </summary>
        public Double Science { get; set; }
        /// <summary>
        /// Long
        /// </summary>
        public long BigCounter { get; set; }
        /// <summary>
        /// Decimal
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// Boolean
        /// </summary>
        public bool IsSo { get; set; }
        #endregion

        #region "Helpers"

        /// <summary>
        /// Self Populate w. Random Data
        /// </summary>
        public void Populate()
        {
            this.BigCounter = (long) _dice.Next(1, 1000);
            this.Money = (decimal)(_dice.NextDouble() * 123456.7890d);
            this.Science = (_dice.NextDouble() * 98765.4321d);
            this.Stamp = DateTime.UtcNow;
            this.Text = TextMaker();
            this.IsSo = (_dice.NextDouble() > .5);
        }

        /// <summary>
        /// Makes a small random block of text
        /// </summary>
        /// <returns>Text</returns>
        public string TextMaker()
        {
            const string Alpha = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtWwXxYyZz";
            var len = _dice.Next(8, 18);
            StringBuilder sb = new();
            for(int i=0; i< len; i++)
            {
                var index = _dice.Next(0, Alpha.Length);
                var c = Alpha[index];
                sb.Append(c);
            }
            return sb.ToString();
        }
        #endregion

    }
}
