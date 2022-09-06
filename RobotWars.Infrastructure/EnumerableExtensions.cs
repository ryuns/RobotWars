using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Infrastructure
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<string> ReadLines(this string s)
        {
            string line;
            using var sr = new StringReader(s);
            while ((line = sr.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}
