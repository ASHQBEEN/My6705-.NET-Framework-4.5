﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My6705.NET_Framework_4._5
{
    public class BreakTest : Test
    {
        private static int nextId = 1;
        public override double TestResult { get { return Values.Max(); } }
        public override string TestNameString => "Разрыв";
        public static double TestSpeed { get; set; }
        public static double[] TestPoint { get; set; } = new double[3];

        public BreakTest() : base(nextId++) => testStart = DateTime.Now;
    }
}
