using DirectShowLib.DMO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZedGraph;

namespace My6705.NET_Framework_4._5
{
    public class GraphHandler
    {
        private readonly ZedGraphControl zgc;
        private readonly Timer timer;
        public double testValue;
        double countSecond = 0;
        private int tickStart = 0;

        public GraphHandler
            (
            ZedGraphControl zgc,
            Timer timer
            )
        {
            this.zgc = zgc;
            this.timer = timer;
        }

        private void DrawLine(object sender, EventArgs e)
        {
            countSecond += 0.25;
            //DrawLine_port(countSecond, testValue, zgc, ref tickStart, comPort);
            zgc.AxisChange();
            zgc.Invalidate();
        }

        private void DrawLine_port()
        {

        }
    }
}
