using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Evaluation
{
    public static  class injectionSQL
    {
        private static string RegexReplace(this string stringValue, string matchPattern, string toReplaceWith)
        {
            return Regex.Replace(stringValue, matchPattern, toReplaceWith);
        }

        private static string RegexReplace(this string stringValue, string matchPattern, string toReplaceWith, RegexOptions regexOptions)
        {
            return Regex.Replace(stringValue, matchPattern, toReplaceWith, regexOptions);
        }
        
        
        
        public static string Sanitize(this string stringValue)
        {
            if (null == stringValue)
                return stringValue;

            return stringValue
                        //.RegexReplace("-{2,}", "-")                 // transforms multiple --- in - use to comment in sql scripts
                        //.RegexReplace(@"[*/]+", string.Empty)      // removes / and * used also to comment in sql scripts
                        .RegexReplace(@"(;|\s)(exec|execute|select|insert|update|delete|create|alter|drop|rename|truncate|backup|restore)\s", string.Empty, RegexOptions.IgnoreCase);
        }

          // Assert.AreEqual("a", "a".Sanitize());
    }
}