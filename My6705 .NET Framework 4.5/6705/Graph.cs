using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ZedGraph;

namespace My6705.NET_Framework_4._5
{
    public class Graph
    {
        private GraphPane tempPane;
        private float pointWidth = 5f;
        private float lineWidth = 2f;
        private Color pointColor = Color.Blue;
        private SymbolType symbolType = SymbolType.Circle;
        private Color pointColorSetPoint = Color.Blue;

        const double TIMEPERIOD = 0.25;

        public void DrawTestResultCurve(ZedGraphControl zgc,TestData tc, int index)
        {
            List<double> testValues = tc.GetTestRunResult(index);
            //clear the pane from other curves
            zgc.GraphPane.CurveList.Clear();
            //Test Result Curve creation 
            RollingPointPairList pairList = new RollingPointPairList(testValues.Count);
            string name = "Измерение # " + index;
            LineItem reservedCurve = zgc.GraphPane.AddCurve(name, pairList, pointColor, symbolType);

            float pointWidth = 5f;
            float lineWidth = 2f;

            reservedCurve.Symbol.Fill.Type = FillType.Solid;
            reservedCurve.Symbol.Size = pointWidth;
            reservedCurve.Line.Width = lineWidth;
            reservedCurve.Line.IsSmooth = true;
            reservedCurve.Line.SmoothTension = 0.2f;


            LineItem testResultCurve = zgc.GraphPane.CurveList[0] as LineItem;
            IPointListEdit list = testResultCurve.Points as IPointListEdit;
            double time = 0;
            for (int i = 0; i < testValues.Count; i++)
            {
                list.Add(time, testValues[i]);
                time += TIMEPERIOD;
            }
        }




        int testsRunned = 0;
        List<int> testsToLoad = new List<int>(15);

        public int[] GetTestsCount()
        {
            int[] res = testsToLoad.ToArray();
            return res;
        }

        public void AddCurve(string name, ZedGraphControl zgc)
        {
            testValues.Add(new List<double>(20));
            testsToLoad.Add(testsRunned);
            RollingPointPairList list = new RollingPointPairList(60000);

            LineItem emptyCurve = tempPane.AddCurve(name, list, pointColor, symbolType);

            emptyCurve.Symbol.Fill.Type = FillType.Solid;
            emptyCurve.Symbol.Size = pointWidth;
            emptyCurve.Line.Width = lineWidth;
            emptyCurve.Line.IsSmooth = true;
            emptyCurve.Line.SmoothTension = 0.2f;
        }

        List<List<double>> testValues = new List<List<double>>(15);



        public void InitializeGraph(ZedGraphControl zgc, ref int tickStart)
        {
            tempPane = zgc.GraphPane;
            tempPane.Chart.Fill = new Fill(Color.AntiqueWhite, Color.Honeydew, -45F);
            tempPane.CurveList.Clear();
            tempPane.Title.Text = "Тензометр";
            tempPane.XAxis.Title.Text = "Время (секунды)";
            tempPane.YAxis.Title.Text = "Граммы";
            tempPane.XAxis.MajorTic.IsOutside = false;
            tempPane.XAxis.MinorTic.IsOutside = false;
            tempPane.YAxis.MajorTic.IsOutside = false;
            tempPane.YAxis.MinorTic.IsOutside = false;
            tempPane.XAxis.MajorGrid.IsVisible = true;
            tempPane.YAxis.MajorGrid.IsVisible = true;
            tempPane.XAxis.MajorGrid.Color = Color.LightGray;
            tempPane.YAxis.MajorGrid.Color = Color.LightGray;
            tempPane.XAxis.Scale.Min = 0;
            tempPane.XAxis.Scale.Max = 10;
            tempPane.XAxis.Scale.MinorStep = 1;
            tempPane.XAxis.Scale.MajorStep = 0.1;
            RollingPointPairList list = new RollingPointPairList(60000);

            LineItem curve = tempPane.AddCurve("Граммы", list, pointColor, symbolType);
            curve.Symbol.Fill.Type = FillType.Solid;
            curve.Symbol.Size = pointWidth;
            curve.Line.Width = lineWidth;
            curve.Line.IsSmooth = true;
            curve.Line.SmoothTension = 0.2f;

            // Scale the axes
            zgc.AxisChange();

            // Save the beginning time for reference
            tickStart = Environment.TickCount;
        }
        public void DrawLine_port(double n, double data, ZedGraphControl zgc, ref int tickStart, ComPort comPort)
        {
            double amountTime;
            double.TryParse(n.ToString(), out amountTime);

            if (zgc.GraphPane.CurveList.Count <= 0)
                return;

            LineItem curve = zgc.GraphPane.CurveList[0] as LineItem;

            if (curve == null)
                return;

            IPointListEdit list = curve.Points as IPointListEdit;

            if (list == null)
                return;

            list.Add(amountTime, data);

            curve.Line.Width = lineWidth;
            curve.Symbol.Fill.Type = FillType.Solid;
            curve.Symbol.Size = pointWidth;

            double time = (Environment.TickCount - tickStart - comPort.getStayTime()) / 1000.0;

            // Keep the X scale at a rolling 30 second interval, with one
            // major step between the max X value an the end of the axis
            Scale scale = zgc.GraphPane.XAxis.Scale;
            if (time > scale.Max - scale.MajorStep)
            {
                scale.Max = time + scale.MajorStep;
                scale.Min = scale.Max - 10.0;
            }

            int step = 0;

            if (n < 20)
                step = 1;
            else
                step = (int)(n / 20);
            zgc.AxisChange();
            zgc.Invalidate();
        }
    }
}
