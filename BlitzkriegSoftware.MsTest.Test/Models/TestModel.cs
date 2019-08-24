using System;
using System.Collections.Generic;
using System.Text;

namespace BlitzkriegSoftware.MsTest.Test.Models
{
    public class TestModel
    {
        private Random _dice = new Random();

        public string Text { get; set; }
        public DateTime Stamp { get; set; }
        public Double Science { get; set; }
        public long BigCounter { get; set; }
        public decimal Money { get; set; }
        public bool IsSo { get; set; }

        public void Populate()
        {
            this.BigCounter = (long) _dice.Next(1, 1000);
            this.Money = (decimal)(_dice.NextDouble() * 123456.7890d);
            this.Science = (_dice.NextDouble() * 98765.4321d);
            this.Stamp = DateTime.UtcNow;
            this.Text = TextMaker();
            this.IsSo = (_dice.NextDouble() > .5 ? true : false);
        }

        private string TextMaker()
        {
            const string Alpha = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtWwXxYyZz";
            var len = _dice.Next(8, 18);
            StringBuilder sb = new StringBuilder();
            for(int i=0; i< len; i++)
            {
                var index = _dice.Next(0, Alpha.Length);
                var c = Alpha[index];
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
