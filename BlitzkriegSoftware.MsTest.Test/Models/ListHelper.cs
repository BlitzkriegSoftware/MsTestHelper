using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlitzkriegSoftware.MsTest.Test.Models
{
    /// <summary>
    /// Makes a List
    /// </summary>
    public static class ListHelper
    {
        /// <summary>
        /// Make a list
        /// </summary>
        /// <param name="count">How many items</param>
        /// <returns>list</returns>
        public static List<string> ListMaker(int count = 5)
        {
            var list = new List<string>();

            for(int i = 0; i<count; i++)
            {
                list.Add(Faker.Lorem.Word());
            }

            return list;
        }

    }
}
