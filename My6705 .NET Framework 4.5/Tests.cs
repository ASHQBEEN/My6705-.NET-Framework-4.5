using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My6705.NET_Framework_4._5
{
    public abstract class Tests
    {
        public List<double> Values { get; set; } = new List<double>(50);
        
        public abstract double GetTestResult();
    }

    public class BreakTest : Tests
    {
        public override double GetTestResult()
        {
            return Values.Max();
        }
    }

    public class StretchTest : Tests
    {
        private double startPosition;
        private double endPosition;
        public override double GetTestResult()
        {
            return endPosition/startPosition*100;
        }
    }

    public class ShearTest : Tests 
    {
        public override double GetTestResult()
        {
            return Values.Max();
        }
    }
}
