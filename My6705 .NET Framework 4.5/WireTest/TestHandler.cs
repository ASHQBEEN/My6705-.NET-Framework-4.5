using DirectShowLib.DMO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Windows.Forms;

namespace My6705.NET_Framework_4._5
{
    public class TestHandler
    {
        private readonly Timer timer;
        private readonly COMPort port;
        private Test test;
        private readonly RadioButton rbBreakTest;
        private readonly RadioButton rbStretchTest;
        private readonly RadioButton rbShearTest;
        private readonly Button btnStart;
        int stopTimerCounter = 0;
        private readonly CheckBox cbBoundSet;
        private readonly NumericUpDown nudForceBound;
        public double testValue;
        private readonly TextBox tbTestResult;
        int testAxisIndex;
        private readonly RichTextBox rtbTestValues;
        int timerTicksToStop = 12; // 3 sec
        private List<Test> tests;
        private readonly ComboBox cmbTests;
        private readonly Button btnMoveToStart;
        private readonly Button btnFixWire;
        private readonly Button btnSetTestPoint;

        public TestHandler(
            Timer getComDataTimer,
            COMPort port,
            Button btnStart,
            CheckBox cbBoundSet,
            NumericUpDown nudForceBound,
            TextBox tbTestResult,
            RadioButton rbBreakTest,
            RadioButton rbStretchTest,
            RadioButton rbShearTest,
            RichTextBox rtbTestValues,
            List<Test> tests,
            ComboBox cmbTests,
            Button btnMoveToStart,
            Button btnFixWire,
            Button btnSetTestPoint
            )
        {
            this.port = port;
            timer = getComDataTimer;
            timer.Tick += TimerTick;
            this.rbBreakTest = rbBreakTest;
            this.rbStretchTest = rbStretchTest;
            this.rbShearTest = rbShearTest;
            this.btnStart = btnStart;
            btnStart.Click += Start;
            this.cbBoundSet = cbBoundSet;
            this.tbTestResult = tbTestResult;
            this.tests = tests;
            this.rtbTestValues = rtbTestValues;
            this.nudForceBound = nudForceBound;
            this.cmbTests = cmbTests;
            this.btnMoveToStart = btnMoveToStart;
            this.btnFixWire = btnFixWire;
            this.btnSetTestPoint = btnSetTestPoint;
        }

        private void Start(object sender, EventArgs e)
        {
            ChooseTestType();
            if (test == null) return;

            if (test is StretchTest)
            ((StretchTest)test).
                    StartPosition = AxesController.GetAxisCommandPosition(Machine.board[testAxisIndex]);

            StartTestTimer();

            AxesController.StartContinuousMovementChecked(Machine.board, testAxisIndex, 0);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            TestTick();

            if (test.MaxValue > testValue)
            {
                stopTimerCounter++;
            }

            if (
                DidWireBroke() 
                || AxesController.IfMaximumReached(testAxisIndex) 
                || IsForceBoundReached()
                )
                StopTestTimer();
        }

        private bool IsForceBoundReached()
        {
            return (cbBoundSet.Checked && Convert.ToDouble(nudForceBound.Value)
                <= testValue);
        }

        private bool DidWireBroke()
        {
            return stopTimerCounter == timerTicksToStop;
        }

        private void TestTick()
        {
            test.AddTestValue(testValue);

            rtbTestValues.AppendText(testValue.ToString() + '\n');
            tbTestResult.Text = test.TestResult.ToString();

            if (!(test is StretchTest))
                return;
            ((StretchTest)test).
                    EndPosition = AxesController.GetAxisCommandPosition(Machine.board[testAxisIndex]);
        }

        private void StartTestTimer()
        {
            btnMoveToStart.Enabled = false;
            KeyboardControl.blockControls = true;
            btnStart.Enabled = false;
            btnSetTestPoint.Enabled = false;
            btnFixWire.Enabled = false;
            cbBoundSet.Enabled = false;
            nudForceBound.Enabled = false;
            rtbTestValues.Clear();
            AxesController.SetAxisHighVelocity(Machine.board[testAxisIndex], Machine.Instance.SlowManipulatorVelocity[testAxisIndex]);
            timer.Start();
        }

        private void StopTestTimer()
        {
            AxesController.StopMovementForAllAxes(Machine.board);
            timer.Stop();
            stopTimerCounter = 0;
            btnStart.Enabled = true;
            KeyboardControl.blockControls = false;
            tests.Add(test);
            btnMoveToStart.Enabled = true;
            btnFixWire.Enabled = true;
            btnSetTestPoint.Enabled = true;
            cbBoundSet.Enabled= true;
            nudForceBound.Enabled = true;
        }

        private void ChooseTestType()
        {
            if (rbBreakTest.Checked)
            {
                test = new BreakTest();
                testAxisIndex = 2;
                cmbTests.Items.Add(test);
            }
            else if (rbStretchTest.Checked)
            {
                test = new StretchTest();
                ((StretchTest)test).StartPosition = AxesController.GetAxisCommandPosition(Machine.board[testAxisIndex]);
                testAxisIndex = 2;
                cmbTests.Items.Add(test);
            }
            else if (rbShearTest.Checked)
            {
                test = new ShearTest();
                testAxisIndex = 1;
                cmbTests.Items.Add(test);
            }
        }
    }
}
