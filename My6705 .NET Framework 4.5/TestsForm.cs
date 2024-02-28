using Advantech.Motion;
using DirectShowLib.DMO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace My6705.NET_Framework_4._5
{
    public partial class TestsForm : Form
    {
        Graph graph;

        private Color pointColor = Color.Blue;
        private SymbolType symbolType = SymbolType.Circle;

        bool coordSet = false;

        // Starting time in milliseconds
        private int tickStart = 0;
        private double countSecond = 0;
        private double tempData = 0.0;

        //GraphPane bufferPane = new GraphPane();

        ComPort comPort;

        TestData td;
        LegacyDriverLogic dr;
        public TestsForm(ComPort comPort, Graph graph, TestData td, LegacyDriverLogic dr)
        {
            this.dr = dr;
            this.td = td;
            InitializeComponent();
            this.comPort = comPort;
            this.graph = graph;
            graph.InitializeGraph(zgc, ref tickStart);
        }

        private void tmrDrawLine_Tick(object sender, EventArgs e)
        {
            countSecond += 0.25;
            graph.DrawLine_port(countSecond, tempData, zgc, ref tickStart, comPort);
            zgc.AxisChange();
            zgc.Invalidate();
        }

        int breakCounter = 0;

        private void tmrComDataGetter_Tick(object sender, EventArgs e)
        {
            tempData = comPort.getPortGraphDataTicker();
            rtbComValues.AppendText(tempData.ToString() + '\n');

            td.AddTestValue(testIndex - 1, tempData);   

            if (rbBreak.Checked) tbTestResult.Text = td.GetBreakValue(testIndex-1).ToString();
            //else if(rbShear.Checked)

            if (td.GetTestRunResult(testIndex-1)[td.GetTestRunResult(testIndex-1).Count - 1] < td.GetBreakValue(testIndex-1))
            {
                breakCounter++;
            }
            if (breakCounter == 20 || Machine.Instance.MaxCoordinate[2] <= AxesController.GetAxisCommandPosition(Machine.board[2])
                || (boundIsSet && Convert.ToDouble(nudForceBound.Value) <= tempData))
            {
                tmrComDataGetter.Stop();
                tmrDrawLine.Stop();
                AxesController.StopContinuousMovementEmg(Machine.board[2]);
                //MessageBox.Show(forceValues.Max().ToString());
                //forceValues.Clear();
                breakCounter = 0;

                countSecond = 0;
                //graph.PointsToCurve(zgc, testIndex,forceValues);

                testIndex++;
                btnStartTest.Enabled = true;
                KeyboardControl.blockControls = false;
                zgc.RestoreScale(zgc.GraphPane);
            }
        }

        int testIndex;
        private void getTestCount()
        {
            testIndex = graph.GetTestsCount().Count() + 1;
        }



        private void btnStartTest_Click(object sender, EventArgs e)
        {
 
            double[] pos = new double[4];
            if (rbBreak.Checked)
                pos = LoadParamVal(breakTestPath, Machine.board);
            if (rbStretch.Checked)
                pos = LoadParamVal(breakTestPath, Machine.board);
            if (rbShear.Checked)
                pos = LoadParamVal(breakTestPath, Machine.board);
            pos = pos.Take(pos.Count() - 1).ToArray();

            double[] curpos = AxesController.GetCommandPositionsAsArray(Machine.board);
            curpos = curpos.Take(curpos.Count() - 1).ToArray();

            if (coordSet && curpos.SequenceEqual(pos) == false)
            {
                MessageBox.Show("Манипулятор не расположен в точке для теста");
                return;
            }
            KeyboardControl.blockControls = true;
            td.AddTestRun();
            rtbComValues.Clear();
            zgc.GraphPane.CurveList.Clear();
            zgc.Refresh();
            graph.AddCurve("Измерение #" + testIndex, zgc);
            tickStart = Environment.TickCount;
            zgc.AxisChange();
            zgc.Invalidate();
            AxesController.SetHighVelocity(Machine.board, Machine.Instance.SlowManipulatorVelocity);
            AxesController.StartContinuousMovementChecked(Machine.board, 2, 0);
                   
            tmrComDataGetter.Start();
            tmrDrawLine.Start();
            cmbTestRun.Items.Add(testIndex);
            btnStartTest.Enabled = false;
        }

        private void TestsForm_Load(object sender, EventArgs e)
        {
            getTestCount();
            int[] ints = graph.GetTestsCount();
            for (int i = 0; i < ints.Length; i++)
            {
                cmbTestRun.Items.Add(ints[i]);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //graph.LoadCurve(zgc, cmbTestRun.SelectedIndex);
            graph.DrawTestResultCurve(zgc,td, cmbTestRun.SelectedIndex);
            //zgc.AxisChange();
            //zgc.Refresh();
            rtbComValues.Clear();
            tbTestResult.Text = td.GetBreakValue(cmbTestRun.SelectedIndex).ToString();

            foreach (var i in td.GetTestRunResult(cmbTestRun.SelectedIndex))
            {
                rtbComValues.AppendText(i.ToString() + '\n');
            }

            //zgc.AxisChange();
            //zgc.Invalidate();
            zgc.RestoreScale(zgc.GraphPane);
        }

        string breakTestPath = "breakTest.txt";
        string stretchTestPath = "stretchTest.txt";
        string shearTestPath = "shearTestPath.txt";

        private double[] breakTestPosition = new double[4];
        private double[] stretchTestPosition = new double[4];
        private double[] shearTestPosition = new double[4];

        private void btnToStartPosition_Click(object sender, EventArgs e)
        {
            double[] pos = new double[4];
            if (rbBreak.Checked)
                pos = LoadParamVal(breakTestPath, Machine.board);
            if (rbStretch.Checked)
                pos = LoadParamVal(breakTestPath, Machine.board);
            if (rbShear.Checked)
                pos = LoadParamVal(breakTestPath, Machine.board);
            pos = pos.Take(pos.Count() - 1).ToArray();
            if (pos[0] == 0 && pos[1] == 0 && pos[2] == 0)
            {
                MessageBox.Show("Координата для теста не обучена");
                return;
            }

            AxesController.MoveToPoint(Machine.board[0], pos[0]);
            AxesController.MoveToPoint(Machine.board[1], pos[1]);
            AxesController.MoveToPoint(Machine.board[2], pos[2]);

            //dr.RemoveAllAxes();

            //GpAddAxis(dr.board);

            //dr.GpMove(pos);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "";
            double[] pos = AxesController.GetCommandPositionsAsArray(Machine.board);
            if (rbBreak.Checked)
            {
                breakTestPosition = pos;
                path = breakTestPath;
                SaveParamVal(breakTestPosition, path, Machine.board);
            }
            if (rbStretch.Checked)
            {
                stretchTestPosition = pos;
                path = stretchTestPath;
                SaveParamVal(stretchTestPosition, path, Machine.board);
            }
            if (rbShear.Checked)
            {
                shearTestPosition = pos;
                path = shearTestPath;
                SaveParamVal(shearTestPosition, path, Machine.board);
            }
            coordSet = true;
        }

        //
        // Load velocity parameter values from Path-file (to parse it with form's text boxes)
        //
        public static double[] LoadParamVal(string path, Board board)
        {
            double[] param = new double[board.AxesCount];
            StreamReader sr = File.OpenText(path);
            for (int i = 0; i < board.AxesCount; i++)
            {
                param[i] = Convert.ToDouble(sr.ReadLine());
            }
            sr.Close();
            return param;
        }
        //
        //Save velocity parameter values to Path-file
        //Methods are splitted by passing parameter
        //
        public static void SaveParamVal(double[] param, string path, Board board)
        {
            File.Create(path).Dispose();
            StreamWriter sw = new StreamWriter(path);
            for (int i = 0; i < board.AxesCount; i++)
            {
                sw.WriteLine(param[i]);
            }
            sw.Close();
        }

        //Tests testType = Tests.Break;

        private void rbBreak_CheckedChanged(object sender, EventArgs e)
        {
            lblMaxCOMValue.Text = "Макс. усилие";
        //    testType = Tests.Break;
        }

        private void rbStretch_CheckedChanged(object sender, EventArgs e)
        {
            lblMaxCOMValue.Text = "Растяжение, %";
            //testType = Tests.Stretch;
        }

        private void rbShear_CheckedChanged(object sender, EventArgs e)
        {
            lblMaxCOMValue.Text = "Макс. усилие";
            //testType = Tests.Shear;
        }

        private void btnSetupWire_Click(object sender, EventArgs e)
        {

        }

        bool boundIsSet = false;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            nudForceBound.Enabled = !nudForceBound.Enabled;
            boundIsSet = !boundIsSet;
        }
    }
}
