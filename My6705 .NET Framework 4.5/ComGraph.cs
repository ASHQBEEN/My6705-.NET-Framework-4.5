using Advantech.Motion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace My6705.NET_Framework_4._5
{
    public partial class ComGraph : Form
    {
        Graph graph = new Graph();


        // Starting time in milliseconds
        private int tickStart = 0;
        private double countSecond = 0;
        private double tempData = 0.0;

        //private bool plotGraph = false;

        ComPort comPort = new ComPort();
        public ComGraph(ComPort comPort)
        {
            InitializeComponent();
            this.comPort = comPort;
            graph.InitializeGraph(zgc, ref tickStart);
        }

        private void tmrDrawLine_Tick(object sender, EventArgs e)
        {

            if (!comPort.ComIsOpen()) return;

            countSecond += 0.25;
            graph.DrawLine_port(countSecond, tempData, zgc, ref tickStart, comPort);
            //tempPane.IsBoundedRanges = true;
            zgc.AxisChange();
            zgc.Invalidate();

        }

        private void tmrComDataGetter_Tick(object sender, EventArgs e)
        {
            tempData = comPort.getPortGraphDataTicker();
            tbComData.Text = comPort.getPortDataTicker();
        }
    }
}
