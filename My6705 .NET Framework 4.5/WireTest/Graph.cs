using System;
using System.Drawing;
using ZedGraph;

namespace My6705.NET_Framework_4._5
{
    public partial class WireTest
    {
        private GraphPane graphPane;

        //переменные для точек/прямых на графике
        private readonly float pointWidth = 5f;
        private readonly float lineWidth = 2f;
        private readonly Color pointColor = Color.Blue;
        private readonly SymbolType symbolType = SymbolType.Circle;

        private int tickStart = 0;
        private const float TIME_PERIOD = 0.25f;
        private float countSecond = 0f;

        private void DrawPointTick()
        {
            DrawRecievedPoint();
            countSecond += TIME_PERIOD;
            zgcGraph.AxisChange();
            zgcGraph.Invalidate();
        }

        //ref int tickStart, ComPort comPort
        public void DrawRecievedPoint()
        {
            if (zgcGraph.GraphPane.CurveList.Count <= 0) return;

            LineItem curve = zgcGraph.GraphPane.CurveList[0] as LineItem;

            if (curve == null) return;

            IPointListEdit list = curve.Points as IPointListEdit;

            if (list == null) return;

            list.Add(countSecond, testValue);

            curve.Line.Width = lineWidth;
            curve.Symbol.Fill.Type = FillType.Solid;
            curve.Symbol.Size = pointWidth;
            curve.Color = pointColor;
            curve.Symbol.Type = symbolType;

            //double time = (Environment.TickCount - tickStart - comPort.getStayTime()) / 1000.0;           
            //double time = (Environment.TickCount - tickStart - (Environment.TickCount - timeBetweenTestsStart)) / 1000.0;
            double time = (Environment.TickCount - tickStart) / 1000.0;

            // Keep the X scale at a rolling 30 second interval, with one
            // major step between the max X value an the end of the axis
            Scale scale = zgcGraph.GraphPane.XAxis.Scale;
            if (time > scale.Max - scale.MinorStep)
            {
                scale.Max = time + scale.MinorStep;
                scale.Min = scale.Max - 10.0;
            }
        }

        // ref int tickStart был тут параматером
        public void InitializeGraph()
        {
            graphPane = zgcGraph.GraphPane;
            graphPane.Chart.Fill = new Fill(Color.SeaShell, Color.Honeydew, -45F);
            graphPane.Title.Text = "Тензометр";
            graphPane.XAxis.Title.Text = "Время (секунды)";
            graphPane.YAxis.Title.Text = "Нагрузка (граммы)";
            //деления выходящие за график
            graphPane.XAxis.MajorTic.IsOutside = false;
            graphPane.XAxis.MinorTic.IsOutside = false;
            graphPane.YAxis.MajorTic.IsOutside = false;
            graphPane.YAxis.MinorTic.IsOutside = false;
            //шаг сетки
            graphPane.XAxis.Scale.MajorStep = 1;
            graphPane.XAxis.Scale.MinorStep = 0.1;
            //сетка
            graphPane.XAxis.MajorGrid.IsVisible = true;
            graphPane.YAxis.MajorGrid.IsVisible = true;
            graphPane.XAxis.MajorGrid.Color = Color.LightGray;
            graphPane.YAxis.MajorGrid.Color = Color.LightGray;
            //минмальные и максимальные значения на пустом графике (размер сетки)
            graphPane.XAxis.Scale.Min = -0.5f;
            graphPane.XAxis.Scale.Max = 10;

            //Стартовый пустой график
            UpdateGraph();
        }

        private void UpdateGraph()
        {
            zgcGraph.GraphPane.CurveList.Clear();
            tickStart = Environment.TickCount;
            countSecond = 0;
            AddEmptyCurve();

            if (rbBreakTest.Checked)
                zgcGraph.GraphPane.Title.Text = "Тест на Разрыв";
            else if (rbStretchTest.Checked)
                zgcGraph.GraphPane.Title.Text = "Тест на Растяжение";
            else if (rbShearTest.Checked)
                zgcGraph.GraphPane.Title.Text = "Тест на Сдвиг";

            graphPane.XAxis.Scale.Min = -0.5f;
            graphPane.XAxis.Scale.Max = 10f;
            zgcGraph.IsAutoScrollRange = true;
            //graphPane.YAxis.Scale.Max = 1.2f;

            zgcGraph.Refresh();
            zgcGraph.AxisChange();
            zgcGraph.Invalidate();
        }

        private void AddEmptyCurve()
        {
            RollingPointPairList list = new RollingPointPairList(60000);

            string curveName;
            if(test == null) curveName = "Граммы";
            else curveName = test.ToString();

            LineItem curve = graphPane.AddCurve(curveName, list, pointColor, symbolType);
            curve.Symbol.Fill.Type = FillType.Solid;
            curve.Symbol.Size = pointWidth;
            curve.Line.Width = lineWidth;
            curve.Line.IsSmooth = true;
            curve.Line.SmoothTension = 0.2f;
        }

        public void DrawTestResultCurve()
        {
            zgcGraph.GraphPane.CurveList.Clear();

            Test test = null;

            if (rbBreakTest.Checked)
                test = breakTests[cmbTests.SelectedIndex];
            else if (rbStretchTest.Checked)
                test = stretchTests[cmbTests.SelectedIndex];
            else if (rbShearTest.Checked)
                test = shearTests[cmbTests.SelectedIndex];

            if (test == null) throw new ArgumentNullException();

            RollingPointPairList pairList = new RollingPointPairList(test.Values.Count);

            LineItem curve = graphPane.AddCurve(test.ToString(), pairList, pointColor, symbolType);
            curve.Symbol.Fill.Type = FillType.Solid;
            curve.Symbol.Size = pointWidth;
            curve.Line.Width = lineWidth;
            curve.Line.IsSmooth = true;
            curve.Line.SmoothTension = 0.2f;

            LineItem testResultCurve = zgcGraph.GraphPane.CurveList[0] as LineItem;
            IPointListEdit list = testResultCurve.Points as IPointListEdit;
            double time = 0;
            for (int i = 0; i < test.Values.Count; i++)
            {
                list.Add(time, test.Values[i]);
                time += TIME_PERIOD;
            }
        }
    }
}
