using DirectShowLib.DMO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace My6705.NET_Framework_4._5
{
    public partial class WireTest
    {
        private GraphPane graphPane;

        //переменные для точек/прямых на графике
        private float pointWidth = 5f;
        private float lineWidth = 2f;
        private Color pointColor = Color.Blue;
        private SymbolType symbolType = SymbolType.Circle;


        private const float TIME_PERIOD = 0.25f;
        private float countSecond = 0f;

        private void DrawPointTick(object sender, EventArgs e)
        {
            countSecond += TIME_PERIOD;
            DrawRecievedPoint();
            zgcGraph.AxisChange();
            zgcGraph.Invalidate();
        }

        //ref int tickStart, ComPort comPort
        public void DrawRecievedPoint()
        {
            if (zgcGraph.GraphPane.CurveList.Count <= 0)
            { 
                return; 
            }


            LineItem curve = zgcGraph.GraphPane.CurveList[0] as LineItem;

            if (curve == null)
                return;

            IPointListEdit list = curve.Points as IPointListEdit;

            if (list == null)
                return;

            list.Add(countSecond, testValue);

            curve.Line.Width = lineWidth;
            curve.Symbol.Fill.Type = FillType.Solid;
            curve.Symbol.Size = pointWidth;
            curve.Color = pointColor;
            curve.Symbol.Type = symbolType;

            //double time = (Environment.TickCount - tickStart - comPort.getStayTime()) / 1000.0;

            // Keep the X scale at a rolling 30 second interval, with one
            // major step between the max X value an the end of the axis
            Scale scale = zgcGraph.GraphPane.XAxis.Scale;
            //if (time > scale.Max - scale.MajorStep)
            //{
            //    scale.Max = time + scale.MajorStep;
            //    scale.Min = scale.Max - 10.0;
            //}

            //ПОМОЙКА
            //int step = 0;

            //if (n < 20)
            //    step = 1;
            //else
            //    step = (int)(n / 20);
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
            graphPane.XAxis.Scale.MinorStep = 1;
            graphPane.XAxis.Scale.MajorStep = 0.1;
            //сетка
            graphPane.XAxis.MajorGrid.IsVisible = true;
            graphPane.YAxis.MajorGrid.IsVisible = true;
            graphPane.XAxis.MajorGrid.Color = Color.LightGray;
            graphPane.YAxis.MajorGrid.Color = Color.LightGray;
            //минмальные и максимальные значения на пустом графике (размер сетки)
            graphPane.XAxis.Scale.Min = 0;
            graphPane.XAxis.Scale.Max = 10;

            //Стартовый пустой график
            RollingPointPairList list = new RollingPointPairList(60000);

            LineItem curve = graphPane.AddCurve("Граммы", list, pointColor, symbolType);
            curve.Symbol.Fill.Type = FillType.Solid;
            curve.Symbol.Size = pointWidth;
            curve.Line.Width = lineWidth;
            curve.Line.IsSmooth = true;
            curve.Line.SmoothTension = 0.2f;

            //// Scale the axes
            //zgcGraph.AxisChange();

            // Save the beginning time for reference
            //tickStart = Environment.TickCount;
        }

    }
}
