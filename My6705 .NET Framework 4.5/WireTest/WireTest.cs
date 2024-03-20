﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace My6705.NET_Framework_4._5
{
    public partial class WireTest : Form
    {
        private List<Test> tests = new List<Test>(20);
        private readonly COMPort port = new COMPort();

        double breakTestSpeed;
        double stretchTestSpeed;
        double shearTestSpeed;

        public WireTest()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void WireTest_Load(object sender, EventArgs e)
        {
            testHandlerTimer.Tick += TimerTick;
            OpenComPort();
            ChangeLabelCoords(BreakTest.TestPoint);

            testHandlerTimer.Tick += DrawPointTick;
            InitializeGraph();

            nudTestSpeed.Maximum = (decimal)Machine.FastVelocity[2];
            LoadSpeeds();
        }

        private void OpenComPort()
        {
            // If the port is open, close it.
            if (port.IsOpen)
            {
                port.Close();
            }
            else
            {
                try
                {
                    port.PortName = port.GetLastPortName();
                    port.Open();
                    // Start Graph Timer
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось открыть COM-порт. Скорее всего он уже подключен, недоступен или вовсе отключен.", "Ошибка COM-порта", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private Test test;
        private int testAxisIndex;
        public double testValue;
        int stopTimerCounter = 0;

        private void Start(object sender, EventArgs e)
        {
            ChooseTestType();
            if (test == null) return;

            if (test is StretchTest)
                ((StretchTest)test).
                        StartPosition = AxesController.GetAxisCommandPosition(Machine.Board[testAxisIndex]);

            if (rbShearTest.Checked)
                AxesController.SetAxisHighVelocity(Machine.Board[1], (double)nudTestSpeed.Value);
            else
                AxesController.SetAxisHighVelocity(Machine.Board[2], (double)nudTestSpeed.Value);

            StartTestTimer();

            AxesController.StartContinuousMovementChecked(Machine.Board, testAxisIndex, 0);
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
                StopTest();
        }

        private bool IsForceBoundReached()
        {
            return (cbBoundSet.Checked && (double)nudForceBound.Value
                <= testValue);
        }

        private bool DidWireBroke()
        {
            int timerSecondsToStop = (int)nudWireBreakDelay.Value;
            const int TICKS_PER_SECOND = 4;
            int timerTicksToStop = timerSecondsToStop * TICKS_PER_SECOND;
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
                    EndPosition = AxesController.GetAxisCommandPosition(Machine.Board[testAxisIndex]);
        }

        private void StartTestTimer()
        {
            btnMoveToStart.Enabled = false;
            KeyboardControl.blockControls = true;
            btnStart.Enabled = false;
            btnSetTestPoint.Enabled = false;
            btnLockWire.Enabled = false;
            cbBoundSet.Enabled = false;
            nudForceBound.Enabled = false;
            rtbTestValues.Clear();
            testHandlerTimer.Start();
        }

        private void StopTest()
        {
            AxesController.StopMovementForAllAxes(Machine.Board);
            testHandlerTimer.Stop();
            stopTimerCounter = 0;
            btnStart.Enabled = true;
            KeyboardControl.blockControls = false;
            tests.Add(test);
            btnMoveToStart.Enabled = true;
            btnLockWire.Enabled = true;
            btnSetTestPoint.Enabled = true;
            cbBoundSet.Enabled = true;
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
                ((StretchTest)test).StartPosition = AxesController.GetAxisCommandPosition(Machine.Board[testAxisIndex]);
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

        private void btnToStartPosition_Click(object sender, EventArgs e)
        {
            double[] pos = new double[3];
            if (rbBreakTest.Checked)
                pos = BreakTest.TestPoint;
            else if (rbStretchTest.Checked)
                pos = StretchTest.TestPoint;
            else if (rbShearTest.Checked)
                pos = ShearTest.TestPoint;

            AxesController.SetHighVelocity(Machine.Board, Machine.DriverVelocity);

            AxesController.MoveToPoint(Machine.Board[0], pos[0]);
            AxesController.MoveToPoint(Machine.Board[1], pos[1]);
            AxesController.MoveToPoint(Machine.Board[2], pos[2]);
        }

        private void btnSetTestPoint_Click(object sender, EventArgs e)
        {
            double[] newCoords = new double[]
{
                AxesController.GetAxisCommandPosition(Machine.Board[0]),
                AxesController.GetAxisCommandPosition(Machine.Board[1]),
                AxesController.GetAxisCommandPosition(Machine.Board[2])
};

            if (rbBreakTest.Checked)
            {
                BreakTest.TestPoint = newCoords;
                ChangeLabelCoords(BreakTest.TestPoint);
            }
            else if (rbStretchTest.Checked)
            {
                StretchTest.TestPoint = newCoords;
                ChangeLabelCoords(StretchTest.TestPoint);
            }
            else if (rbShearTest.Checked)
            {
                ShearTest.TestPoint = newCoords;
                ChangeLabelCoords(ShearTest.TestPoint);
            }

            Machine.testConditions.Save();
        }

        private void btnLockWire_Click(object sender, EventArgs e)
        {

        }

        private void testHandlerTimer_Tick(object sender, EventArgs e)
        {
            testValue = port.TestValue;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (rbBreakTest.Checked)
            {
                breakTestSpeed = (double)nudTestSpeed.Value;
                nudTestSpeed.Maximum = (decimal)Machine.FastVelocity[2];
            }
            else if (rbStretchTest.Checked)
            {
                stretchTestSpeed = (double)nudTestSpeed.Value;
                nudTestSpeed.Maximum = (decimal)Machine.FastVelocity[1];
            }
            else if (rbShearTest.Checked)
            {
                shearTestSpeed = (double)nudTestSpeed.Value;
                nudTestSpeed.Maximum = (decimal)Machine.FastVelocity[2];
            }
        }

        private void StopTestBySpaceKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                StopTest();
        }

        private void WireTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopTest();
            port.Close();
        }

        private void LoadSpeeds()
        {
            Machine.testConditions.Load();
            if (nudTestSpeed.Maximum > (decimal)BreakTest.TestSpeed)
                breakTestSpeed = BreakTest.TestSpeed;
            else
                breakTestSpeed = (double)nudTestSpeed.Maximum;

            if (nudTestSpeed.Maximum > (decimal)StretchTest.TestSpeed)
                stretchTestSpeed = StretchTest.TestSpeed;
            else
                stretchTestSpeed = (double)nudTestSpeed.Maximum;

            if (nudTestSpeed.Maximum > (decimal)ShearTest.TestSpeed)
                shearTestSpeed = ShearTest.TestSpeed;
            else
                shearTestSpeed = (double)nudTestSpeed.Maximum;

            if (rbBreakTest.Checked)
                if (nudTestSpeed.Maximum > (decimal)BreakTest.TestSpeed)
                    nudTestSpeed.Value = (decimal)breakTestSpeed;
                else
                    nudTestSpeed.Value = nudTestSpeed.Maximum;
            else if (rbStretchTest.Checked)
                if (nudTestSpeed.Maximum > (decimal)StretchTest.TestSpeed)
                    nudTestSpeed.Value = (decimal)stretchTestSpeed;
                else
                    nudTestSpeed.Value = nudTestSpeed.Maximum;
            else if (rbShearTest.Checked)
                if (nudTestSpeed.Maximum > (decimal)ShearTest.TestSpeed)
                    nudTestSpeed.Value = (decimal)shearTestSpeed;
                else
                    nudTestSpeed.Value = nudTestSpeed.Maximum;
        }


        private void btnLoadTestSpeed_Click(object sender, EventArgs e)
        {
            LoadSpeeds();
        }

        private void btnSaveTestSpeed_Click(object sender, EventArgs e)
        {
            BreakTest.TestSpeed = breakTestSpeed;
            StretchTest.TestSpeed = stretchTestSpeed;
            ShearTest.TestSpeed = shearTestSpeed;
            Machine.testConditions.Save();
        }
    }
}
