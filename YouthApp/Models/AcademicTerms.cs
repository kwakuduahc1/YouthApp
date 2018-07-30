using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace YouthApp.Models
{
    public static class AcademicTerms
    {
        private static readonly Dictionary<float, string> Terms = new Dictionary<float, string>
        {
            {1.1F, "Year 1 term 1"},
            {1.2F, "Year 1 term 2"},
            { 1.3F, "Year 1 term 3"},
            { 2.1F, "Year 2 term 1"},
            {2.2F, "Year 2 term 2"},
            { 2.3F, "Year 2 term 3"},
             {3.1F, "Year 3 term 1"},
            {3.2F, "Year 3 term 2"},
            { 3.3F, "Year 3 term 3"}
        };

        public static string GetTerm(float term) => Terms[term];

        public static IEnumerable GetTerms() => Terms.Values;

        public static KeyValuePair<float, string> GetTerm(byte term) => Terms.ToList()[term];
    }
}
