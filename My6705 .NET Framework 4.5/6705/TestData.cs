using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace My6705.NET_Framework_4._5
{
    public class TestData
    {
        public int TestsCount { get; private set; } = 0;
        private List<List<double>> testRuns = new List<List<double>>(10);

        public void AddTestRun()
        {
            TestsCount++;
            testRuns.Add(new List<double>(50));
        }

        public void AddTestValue(int testRunIndex, double value)
        {
            testRuns[testRunIndex].Add(value);
        }

        public List<double> GetTestRunResult(int testRunIndex)
        {
            return testRuns[testRunIndex];
        }
        
        public double GetBreakValue(int testRunIndex)
        {
            return testRuns[testRunIndex].Max();
        }
    }
}
