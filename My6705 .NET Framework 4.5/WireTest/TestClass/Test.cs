using System;
using System.Collections.Generic;
using System.Linq;

namespace My6705.NET_Framework_4._5
{
    public abstract class Test
    {
        public List<double> Values { get; } = new List<double>(50);
        public abstract double TestResult { get; }
        public double MaxValue { get { return Values.Max(); } }
        public double LastValue { get { return Values.Last(); } }
        public readonly int testID;
        public abstract string TestNameString {  get; }
        public DateTime testStart;

        public Test(int testID)
        {
            this.testID = testID;
        }

        public void AddTestValue(double value)
        {
            Values.Add(value);
        }

        public override string ToString()
        {
            return $"{testID}, {TestNameString} {testStart} ";
        }
    }
}