using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace My6705.NET_Framework_4._5
{
    public partial class WireTest : Form
    {
        private List<Test> tests = new List<Test>(20);
        private TestHandler testHandler;
        private readonly COMPort port;

        public WireTest(COMPort port)
        {
            this.port = port;
            InitializeComponent();
            testHandler = new TestHandler
                (
                testHandlerTimer,
                port,
                btnStart,
                cbBoundSet,
                nudForceBound,
                tbTestResult,
                rbBreakTest,
                rbStretchTest,
                rbShearTest,
                rtbTestValues,
                tests,
                cmbTests,
                btnMoveToStart,
                btnFixWire,
                btnSetTestPoint
                );
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
            ChangeLabelCoords(Machine.Instance.BreakTestPosition);
            cmbTests.Items.Clear();
            bool noTestsFound = true;
            foreach (var test in tests)
            {
                {
                    if (test is BreakTest)
                    {
                        cmbTests.Items.Add(test);
                        noTestsFound = false;
                    }
                }
                if (noTestsFound) cmbTests.Text = "Выберите номер измерения";
            }
        }

        private void rbShearTest_CheckedChanged(object sender, EventArgs e)
        {
            bool noTestsFound = true;
            ChangeLabelCoords(Machine.Instance.ShearTestPosition);
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
            bool noTestsFound = true;
            ChangeLabelCoords(Machine.Instance.StretchTestPosition);
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

        private void WireTest_Load(object sender, EventArgs e)
        {
            ChangeLabelCoords(Machine.Instance.BreakTestPosition);
        }

        private void btnToStartPosition_Click(object sender, EventArgs e)
        {
            double[] pos = new double[3];
            if (rbBreakTest.Checked)
                pos = Machine.Instance.BreakTestPosition;
            else if (rbStretchTest.Checked)
                pos = Machine.Instance.StretchTestPosition;
            else if (rbShearTest.Checked)
                pos = Machine.Instance.ShearTestPosition;

            AxesController.SetHighVelocity(Machine.board, Machine.Instance.DriverVelocity);

            AxesController.MoveToPoint(Machine.board[0], pos[0]);
            AxesController.MoveToPoint(Machine.board[1], pos[1]);
            AxesController.MoveToPoint(Machine.board[2], pos[2]);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            double[] newCoords = new double[]
{
                AxesController.GetAxisCommandPosition(Machine.board[0]),
                AxesController.GetAxisCommandPosition(Machine.board[1]),
                AxesController.GetAxisCommandPosition(Machine.board[2])
};

            if (rbBreakTest.Checked)
            {
                Machine.Instance.BreakTestPosition = newCoords;
                ChangeLabelCoords(Machine.Instance.BreakTestPosition);
            }
            else if (rbStretchTest.Checked)
            {
                Machine.Instance.StretchTestPosition = newCoords;
                ChangeLabelCoords(Machine.Instance.StretchTestPosition);
            }
            else if (rbShearTest.Checked)
            {
                Machine.Instance.ShearTestPosition = newCoords;
                ChangeLabelCoords(Machine.Instance.ShearTestPosition);
            }

            Machine.SaveMachineParameters();
        }

        private void btnSetupWire_Click(object sender, EventArgs e)
        {

        }

        private void testHandlerTimer_Tick(object sender, EventArgs e)
        {
            testHandler.testValue = port.TestValue;
        }
    }
}
