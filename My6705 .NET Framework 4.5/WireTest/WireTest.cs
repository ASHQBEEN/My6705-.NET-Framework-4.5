using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
namespace My6705.NET_Framework_4._5
{
    public partial class WireTest : Form
    {
        private List<BreakTest> breakTests = new List<BreakTest>(10);
        private List<StretchTest> stretchTests = new List<StretchTest>(10);
        private List<ShearTest> shearTests = new List<ShearTest>(10);
        private readonly COMPort port = new COMPort();

        double breakTestSpeed;
        double stretchTestSpeed;
        double shearTestSpeed;

        private readonly string labelForceCaption = "Макс. усилие, г:";
        private readonly string labelStretchCaption = "Растяжение, %";

        private int calibrationCountdownValue;
        private const int CALIBRATION_COUNTDOWN_VALUE = 12;

        public WireTest()
        {
            InitializeComponent();
            KeyPreview = true;
            cmbTests.Text = emptyCmbString;
        }

        private void cmbTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbTestValues.Clear();

            List<Test> tests = new List<Test>();
            if (rbBreakTest.Checked)
            {
                tests.AddRange(breakTests);
            }
            else if (rbStretchTest.Checked)
            {
                tests.AddRange(stretchTests);
            }
            else if (rbShearTest.Checked)
            {
                tests.AddRange(shearTests);
            }

            foreach (var value in tests[cmbTests.SelectedIndex].Values)
                rtbTestValues.AppendText(value.ToString() + '\n');

            tbTestResult.Text = tests[cmbTests.SelectedIndex].TestResult.ToString();

            DrawTestResultCurve();
            zgcGraph.RestoreScale(zgcGraph.GraphPane);
        }

        private void WireTest_Load(object sender, EventArgs e)
        {
            OpenComPort();
            ChangeLabelCoords(BreakTest.TestPoint);
            InitializeGraph();
            cmbReferenceWeigths.SelectedIndex = 0;

            nudTestSpeed.Maximum = (decimal)Machine.FastVelocity[2];
            LoadSpeeds();
            nudForceBound.Controls[0].Visible = false;
            nudTestSpeed.Controls[0].Visible = false;
            nudWireBreakDelay.Controls[0].Visible = false;
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
        int stopTimerTickCounter = 0;

        private void Start(object sender, EventArgs e)
        {
            cmbTests.Text = emptyCmbString;
            CreateTest();
            if (test == null) return;

            UpdateMaximumSpeed();

            if (rbShearTest.Checked)
            {
                AxesController.SetAxisHighVelocity(Machine.Board[1], (double)nudTestSpeed.Value);
            }
            else if (rbStretchTest.Checked)
            {
                AxesController.SetAxisHighVelocity(Machine.Board[2], (double)nudTestSpeed.Value);
                StretchTest.DelayTimeInSeconds = (int)nudWireBreakDelay.Value;
            }
            else if (rbBreakTest.Checked)
            {
                AxesController.SetAxisHighVelocity(Machine.Board[2], (double)nudTestSpeed.Value);
            }

            UpdateGraph();

            StartTestTimer();
            AxesController.StartContinuousMovementChecked(Machine.Board, testAxisIndex, 0);
        }

        private bool IsForceBoundReached()
        {
            return (cbBoundSet.Checked && (double)nudForceBound.Value
                <= testValue);
        }

        private void TestTick()
        {
            port.Send("w;");
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
            KeyboardControl.blockControls = true;
            TurnInterfaceOFF();
            rtbTestValues.Clear();
            testHandlerTimer.Start();
        }

        private void StopTest()
        {
            //if (stopTimerTickCounter == 0) return;
            testHandlerTimer.Stop();
            AxesController.StopMovementForAllAxes(Machine.Board);

            stopTimerTickCounter = 0;
            KeyboardControl.blockControls = false;

            if (rbBreakTest.Checked)
            {
                breakTests.Add((BreakTest)test);
            }
            else if (rbStretchTest.Checked)
            {
                stretchTests.Add((StretchTest)test);
            }
            else if (rbShearTest.Checked)
            {
                shearTests.Add((ShearTest)test);
            }

            TurnInterfaceON();
            if (test != null)
            tbTestResult.Text = test.TestResult.ToString();
            test = null;
        }

        private void TurnInterfaceOFF()
        {
            btnMoveToStart.Enabled = false;
            btnStart.Enabled = false;
            btnSetTestPoint.Enabled = false;
            btnLockWire.Enabled = false;
            cbBoundSet.Enabled = false;
            nudForceBound.Enabled = false;
            rbShearTest.Enabled = false;
            rbBreakTest.Enabled = false;
            rbStretchTest.Enabled = false;
            nudWireBreakDelay.Enabled = false;
            nudForceBound.Enabled = false;
            btnCalibrate.Enabled = false;
            btnTare.Enabled = false;
        }

        private void TurnInterfaceON()
        {
            btnStart.Enabled = true;
            btnMoveToStart.Enabled = true;
            btnLockWire.Enabled = true;
            btnSetTestPoint.Enabled = true;
            cbBoundSet.Enabled = true;
            nudForceBound.Enabled = true;
            rbBreakTest.Enabled = true;
            rbShearTest.Enabled = true;
            rbStretchTest.Enabled = true;
            nudForceBound.Enabled = true;
            btnTare.Enabled = true;
            btnCalibrate.Enabled = true;
        }

        private void CreateTest()
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
            TestTick();
            DrawPointTick();

            if (test.MaxValue > testValue)
            {
                stopTimerTickCounter++;
            }

            if (
                DidWireBroke()
                || AxesController.IfMaximumReached(testAxisIndex)
                || IsForceBoundReached()
                )
                StopTest();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (rbBreakTest.Checked)
            {
                breakTestSpeed = (double)nudTestSpeed.Value;
            }
            else if (rbStretchTest.Checked)
            {
                stretchTestSpeed = (double)nudTestSpeed.Value;
            }
            else if (rbShearTest.Checked)
            {
                shearTestSpeed = (double)nudTestSpeed.Value;
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
            {
                BreakTest.TestSpeed = (double)nudTestSpeed.Maximum;
                breakTestSpeed = (double)nudTestSpeed.Maximum;
            }
            if (nudTestSpeed.Maximum > (decimal)StretchTest.TestSpeed)
                stretchTestSpeed = StretchTest.TestSpeed;
            else
            {
                StretchTest.TestSpeed = (double)nudTestSpeed.Maximum;
                stretchTestSpeed = (double)nudTestSpeed.Maximum;
            }
            if (nudTestSpeed.Maximum > (decimal)ShearTest.TestSpeed)
                shearTestSpeed = ShearTest.TestSpeed;
            else
            {
                ShearTest.TestSpeed = (double)nudTestSpeed.Maximum;
                shearTestSpeed = (double)nudTestSpeed.Maximum;
            }
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
            UpdateMaximumSpeed();
            LoadSpeeds();
        }

        private void btnSaveTestSpeed_Click(object sender, EventArgs e)
        {
            BreakTest.TestSpeed = breakTestSpeed;
            StretchTest.TestSpeed = stretchTestSpeed;
            ShearTest.TestSpeed = shearTestSpeed;
            Machine.testConditions.Save();
        }

        private void UpdateMaximumSpeed()
        {
            if (rbShearTest.Checked)
                nudTestSpeed.Maximum = (decimal)Machine.FastVelocity[1];
            else if (rbBreakTest.Checked || rbStretchTest.Checked)
                nudTestSpeed.Maximum = (decimal)Machine.FastVelocity[2];
        }

        //Нужен для обновления максимума в случае если мы обновили FastVelocity и начали изменять значение в nud
        private void nudTestSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            UpdateMaximumSpeed();
        }

        private bool DidWireBroke()
        {
            const int SECOND_IN_MILLISECONDS = 1000;
            int TICKS_PER_SECOND = SECOND_IN_MILLISECONDS / testHandlerTimer.Interval;
            int timerTicksToStop = (int)nudWireBreakDelay.Value * TICKS_PER_SECOND;
            return stopTimerTickCounter == timerTicksToStop;
        }

        private void btnSaveTestResults_Click(object sender, EventArgs e)
        {
            Test[] tests = null;
            if (rbBreakTest.Checked)
                tests = breakTests.ToArray();
            else if (rbShearTest.Checked)
                tests = shearTests.ToArray();
            else if (rbStretchTest.Checked)
                tests = stretchTests.ToArray();

            SerializedTest.Serialize(tests);
            SerializedTest.Save();
        }

        private void btnLoadTestResults_Click(object sender, EventArgs e)
        {
            SerializedTest.Load();
        }

        private void SerialTare(object sender, EventArgs e)
        {
            port.Send("t;");
        }

        private void btnCalibrate_Click(object sender, EventArgs e)
        {
            port.Send("c;"); //arduino calibrate
            Thread.Sleep(250);
            int calibrationWeight = Convert.ToInt32(cmbReferenceWeigths.Items[cmbReferenceWeigths.SelectedIndex]);
            port.Send(calibrationWeight.ToString());
            Thread.Sleep(300);
            MessageBox.Show(port.ReadReferenceWeight());
            calibrationCountdownValue = CALIBRATION_COUNTDOWN_VALUE; // Сбрасываем значение обратного отсчета
            btnCalibrate.Text = calibrationCountdownValue.ToString(); // Устанавливаем начальное значение текста кнопки
            tCountDown.Start(); // Запускаем таймер
            TurnInterfaceOFF();
        }

        private void tCountDown_Tick(object sender, EventArgs e)
        {
            if (calibrationCountdownValue > 0)
            {
                calibrationCountdownValue--;
                btnCalibrate.Text = calibrationCountdownValue.ToString();
            }
            else
            {
                tCountDown.Stop();
                btnCalibrate.Text = "Калибровка";
                TurnInterfaceON();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            port.Send("f;");
            Thread.Sleep(300);
            MessageBox.Show(port.ReadReferenceWeight());
        }
    }
}
