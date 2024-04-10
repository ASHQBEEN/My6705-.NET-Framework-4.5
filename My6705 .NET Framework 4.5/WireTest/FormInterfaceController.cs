using System;
using System.Collections.Generic;
using ZedGraph;

namespace My6705.NET_Framework_4._5
{
    public partial class WireTest
    {
        private readonly string emptyCmbString = "Выберите номер измерения";

        private void ChangeLabelCoords(double[] coords)
        {
            label1.Text = coords[0].ToString();
            label2.Text = coords[1].ToString();
            label3.Text = coords[2].ToString();
        }

        private void ClearInterface()
        {
            if (rbStretchTest.Checked)
                lblTestResult.Text = labelStretchCaption;
            else
                lblTestResult.Text = labelForceCaption;
            cmbTests.Text = emptyCmbString;
            tbTestResult.Text = string.Empty;
            rtbTestValues.Text = string.Empty;
            UpdateGraph();
        }

        private void rbBreakTest_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTestType(BreakTest.TestPoint, breakTestSpeed, breakTests, test => test is BreakTest);
        }

        private void UpdateTestType<T>(double[] testPoint, double testSpeed, List<T> tests, Func<T, bool> testCheck) where T : Test
        {
            if (nudTestSpeed.Maximum > (decimal)testSpeed)
                nudTestSpeed.Value = (decimal)testSpeed;
            else
                nudTestSpeed.Value = nudTestSpeed.Maximum;

            bool noTestsFound = true;
            ChangeLabelCoords(testPoint);
            cmbTests.Items.Clear();
            foreach (var test in tests)
            {
                if (testCheck(test))
                {
                    cmbTests.Items.Add(test);
                    noTestsFound = false;
                }
            }
            if (noTestsFound) cmbTests.Text = "Выберите номер измерения";
            ClearInterface();
        }

        private void rbShearTest_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTestType(ShearTest.TestPoint, shearTestSpeed, shearTests, test => test is ShearTest);
        }

        private void rbStretchTest_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTestType(StretchTest.TestPoint, stretchTestSpeed, stretchTests, test => test is StretchTest);
        }
    }
}
