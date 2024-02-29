using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My6705.NET_Framework_4._5
{
    public class StretchTest : Test
    {
        public double StartPosition { get; set; }
        public double EndPosition { get; set; }
        private static int nextId = 1;
        public override string TestNameString => "Растяжение";
        public override double TestResult { get { return EndPosition / StartPosition * 100; } }
        
        public StretchTest() : base(nextId++) { }
    }
}
