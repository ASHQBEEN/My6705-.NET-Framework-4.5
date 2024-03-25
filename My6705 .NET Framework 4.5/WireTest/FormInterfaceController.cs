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
            if(rbStretchTest.Checked)
                lblTestResult.Text = labelStretchCaption;
            else
                lblTestResult.Text = labelForceCaption;
            cmbTests.Text = emptyCmbString;
            tbTestResult.Text = string.Empty;
            tbTestValues.Text = string.Empty;
            UpdateGraph();
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
            foreach (var test in breakTests)
            {
                if (test is BreakTest)
                {
                    cmbTests.Items.Add(test);
                    noTestsFound = false;
                }

                if (noTestsFound) cmbTests.Text = emptyCmbString;

                zgcGraph.GraphPane.Title.Text = "Тест на Разрыв";
                RollingPointPairList list = new RollingPointPairList(255);
                LineItem curve = zgcGraph.GraphPane.AddCurve("Граммы", list, pointColor, symbolType);
                curve.Symbol.Fill.Type = FillType.Solid;
                curve.Symbol.Size = pointWidth;
                curve.Line.Width = lineWidth;
                curve.Line.IsSmooth = true;
                curve.Line.SmoothTension = 0.2f;
                zgcGraph.AxisChange();
            }

            ClearInterface();
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
            foreach (var test in shearTests)
            {
                {
                    if (test is ShearTest)
                        cmbTests.Items.Add(test);
                    noTestsFound = false;
                }
            }
            if (noTestsFound) cmbTests.Text = "Выберите номер измерения";
            ClearInterface();
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
            foreach (var test in stretchTests)
            {
                if (test is StretchTest)
                {
                    cmbTests.Items.Add(test);
                    noTestsFound = false;
                }
            }
            if (noTestsFound) cmbTests.Text = "Выберите номер измерения";
            ClearInterface();
        }
    }
}
