using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My6705.NET_Framework_4._5
{
    public class ShearTest : Test
    {
        public override double TestResult { get { return Values.Max(); } }
        public override string TestNameString => "Сдвиг";
        private static int nextId = 1;
        public static double TestSpeed { get; set; }
        public static double[] TestPoint { get; set; } = new double[3];

        public ShearTest() : base(nextId++) => testStart = DateTime.Now;
    }
}
