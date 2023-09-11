using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Helpers.Utils
{
    internal static class Utils
    {
        /// <summary>
        /// This function returns the string adding the arguments correctly added
        /// </summary>
        /// <param name="text">Base string</param>
        /// <param name="arguments">arguments</param>
        /// <returns>New string: Base string using the arguments list</returns>
        public static string StringFormat(this string text, params string[] arguments)
        {
            text = String.Format(text, arguments);
            return text;
        }
    }
}
