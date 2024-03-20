using System;

namespace My6705.NET_Framework_4._5
{
    public partial class WireTest
    {
        private void cmbTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbTestValues.Clear();
            foreach (var value in tests[cmbTests.SelectedIndex].Values)
                rtbTestValues.AppendText(value.ToString() + '\n');

            tbTestResult.Text = tests[cmbTests.SelectedIndex].TestResult.ToString();
        }


        private void ChangeLabelCoords(double[] coords)
        {
            label1.Text = coords[0].ToString();
            label2.Text = coords[1].ToString();
            label3.Text = coords[2].ToString();
        }

        private void rbBreakTest_CheckedChanged(object sender, EventArgs e)
        {
            if (nudTestSpeed.Maximum > (decimal)breakTestSpeed)
                nudTestSpeed.Value = (decimal)breakTestSpeed;
            else
                nudTestSpeed.Value = nudTestSpeed.Maximum;
            ChangeLabelCoords(BreakTest.TestPoint);
            cmbTests.Items.Clear();
            bool noTestsFound = true;
            foreach (var test in tests)
            {
                if (test is BreakTest)
                {
                    cmbTests.Items.Add(test);
                    noTestsFound = false;
                }

                if (noTestsFound) cmbTests.Text = "Выберите номер измерения";
            }
        }

        private void rbShearTest_CheckedChanged(object sender, EventArgs e)
        {
            if (nudTestSpeed.Maximum > (decimal)shearTestSpeed)
                nudTestSpeed.Value = (decimal)shearTestSpeed;
            else
                nudTestSpeed.Value = nudTestSpeed.Maximum;
            bool noTestsFound = true;
            ChangeLabelCoords(ShearTest.TestPoint);
            cmbTests.Items.Clear();
            foreach (var test in tests)
            {
                {
                    if (test is ShearTest)
                        cmbTests.Items.Add(test);
                    noTestsFound = false;
                }
            }
            if (noTestsFound) cmbTests.Text = "Выберите номер измерения";
        }
        private void rbStretchTest_CheckedChanged(object sender, EventArgs e)
        {
            if (nudTestSpeed.Maximum > (decimal)stretchTestSpeed)
                nudTestSpeed.Value = (decimal)stretchTestSpeed;
            else
                nudTestSpeed.Value = nudTestSpeed.Maximum;
            bool noTestsFound = true;
            ChangeLabelCoords(StretchTest.TestPoint);
            cmbTests.Items.Clear();
            foreach (var test in tests)
            {
                if (test is StretchTest)
                {
                    cmbTests.Items.Add(test);
                    noTestsFound = false;
                }
            }
            if (noTestsFound) cmbTests.Text = "Выберите номер измерения";
        }
    }
}
