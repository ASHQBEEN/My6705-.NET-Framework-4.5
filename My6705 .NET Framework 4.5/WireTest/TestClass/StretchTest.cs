using System;

namespace My6705.NET_Framework_4._5
{
    public class StretchTest : Test
    {
        public double StartPosition { get; set; }
        public double EndPosition { get; set; }
        private static int nextId = 1;
        public override string TestNameString => "Растяжение";
        public override double TestResult 
        { get { return (coordDifference - TestSpeed*DelayTimeInSeconds)/1000; } }
        public double coordDifference { get => EndPosition - StartPosition; }
        public static double DelayTimeInSeconds { get; set; }

        public static double TestSpeed { get; set; }
        public static double[] TestPoint { get; set; } = new double[3];

        public StretchTest() : base(nextId++) => testStart = DateTime.Now;
    }
}
