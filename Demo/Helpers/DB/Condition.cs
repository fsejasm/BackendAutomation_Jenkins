using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Helpers.DB
{
    public class Condition
    {
        public static string EQUALS = "{0} = '{1}'";
        public static string GT = "{0} > '{1}'";
        public static string LT = "{0} < '{1}'";
        public static string GTE = "{0} >= '{1}'";
        public static string LTE = "{0} <= '{1}'";
        public static string DISTINCT = "{0} <> '{1}'";
        public static string CONTAINS = "{0} LIKE '%{1}%'";
        public static string STARTSWITH = "{0} LIKE '{1}%'";
        public static string ENDSWITH = "{0} LIKE '%{1}'";
        public string op { get; set; }
        public string field { get; set; }
        public string value { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Condition" /> class.
        /// </summary>
        /// <param name="field">case sensitive field to be used on the filter</param>
        /// <param name="op">SQL Allowed Operator</param>
        /// <param name="value">value to be filtered</param>
        public Condition(string field, string op, string value)
        {
            this.field = field;
            this.value = value;
            //Updating the condition is it becomes as a simple comparator
            if (!op.Contains("{0}"))
            {
                op = string.Format("{0} {1} '{2}'", "{0}", op, "{1}");
            }
            this.op = op;
        }
        /// <summary>
        /// Returns the condition as a SQL condition <field> <operator> <value>
        /// </summary>
        /// <returns>Condition parsed to SQL language</returns>
        override public string ToString()
        {
            return string.Format(op, field, value);
        }
    }
}
