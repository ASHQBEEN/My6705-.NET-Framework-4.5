using Advantech.Motion;
using My6705.NET_Framework_4._5.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace My6705.NET_Framework_4._5
{
    public partial class DriverTest : Form
    {
        private readonly CheckBox[] cbAddedAxes;
        private readonly RadioButton[] rbDriveSpeed;
        private readonly NumericUpDown[] nudPosition1;
        private readonly NumericUpDown[] nudPosition2;

        Action testTimerTick;
        bool firstStepDone = false;
        int tickerState = 0;
        int testStartTime = 0;

        public DriverTest()
        {
            InitializeComponent();
            nudPosition1 = new NumericUpDown[] { nudPosition1X, nudPosition1Y, nudPosition1Z, nudPosition1Phi };
            nudPosition2 = new NumericUpDown[] { nudPosition2X, nudPosition2Y, nudPosition2Z, nudPosition2Phi };
            rbDriveSpeed = new RadioButton[] { rbDriveX, rbDriveY, rbDriveZ, rbDrivePhi };
            cbAddedAxes = new CheckBox[] { cbAddAxisX, cbAddAxisY, cbAddAxisZ, cbAddAxisPhi };
            SetMaxCoord();
        }

        //static bool stepDone = false;

        private Dictionary<CheckBox, RadioButton> checkboxesToRadioButtons = new Dictionary<CheckBox, RadioButton>();

        GroupState interpolationGroupState;

        private void driverTestTimer_Tick(object sender, EventArgs e)
        {
            if (tickerState == 0)
            {
                if (rbStep.Checked) 
                {
                    rbBackAndForth.Enabled = true;
                    btnStartInterpolatedMovement.Enabled = true;
                }
                driverTestTimer.Stop();
                speedometer.Stop();
            }

            testTimerTick();

        }
        private int GetPTPIndex()
        {
            for (int i = 0; i < cbAddedAxes.Length; i++)
            {
                if (cbAddedAxes[i].Checked)
                {
                    return i;
                }
            }
            throw new Exception();
        }
        private void SetPTPStepTicker(int ptpAxisIndex, PairOfCoordinates coords)
        {
            testTimerTick = () =>
            {
                switch (tickerState)
                {
                    case 1:
                        if (firstStepDone)
                        {
                            tickerState = 4;
                            break;
                        }
                        AxesController.MoveToPoint(Machine.board[ptpAxisIndex], coords.first);
                        tickerState++;
                        break;
                    case 2:
                        if (AxesController.GetAxisState(Machine.board[ptpAxisIndex]) == (ushort)AxisState.STA_AX_PTP_MOT) break;
                        tickerState++;
                        break;
                    case 3:
                        firstStepDone = true;
                        tickerState = 0;
                        break;
                    case 4:
                        AxesController.MoveToPoint(Machine.board[ptpAxisIndex], coords.second);
                        tickerState++;
                        break;
                    case 5:
                        if (AxesController.GetAxisState(Machine.board[ptpAxisIndex]) == (ushort)AxisState.STA_AX_PTP_MOT) break;
                        tickerState++;
                        break;
                    case 6:
                        firstStepDone = false;
                        tickerState = 0;
                        break;
                }
            };
        }
        private void SetPTPAutoTicker(int ptpAxisIndex, PairOfCoordinates coords, int delay)
        {
            testTimerTick = () =>
            {
                switch (tickerState)
                {
                    case 1:
                        AxesController.MoveToPoint(Machine.board[ptpAxisIndex], coords.first);
                        tickerState++;
                        break;
                    case 2:
                        if (AxesController.GetAxisState(Machine.board[ptpAxisIndex]) == (ushort)AxisState.STA_AX_PTP_MOT) break;
                        testStartTime = Environment.TickCount;
                        tickerState++;
                        break;
                    case 3:
                        if (Environment.TickCount - testStartTime < delay) break;
                        tickerState++;
                        break;
                    case 4:
                        AxesController.MoveToPoint(Machine.board[ptpAxisIndex], coords.second);
                        tickerState++;
                        break;
                    case 5:
                        if (AxesController.GetAxisState(Machine.board[ptpAxisIndex]) == (ushort)AxisState.STA_AX_PTP_MOT) break;
                        testStartTime = Environment.TickCount;
                        tickerState++;
                        break;
                    case 6:
                        if (Environment.TickCount - testStartTime < delay) break;
                        tickerState++;
                        break;
                    case 7:
                        tickerState = 1;
                        break;
                }
            };
        }
        struct PairOfCoordinates
        {
            public double first;
            public double second;

            public PairOfCoordinates(double first, double second)
            {
                this.first = first;
                this.second = second;
            }
        }
        private PairOfCoordinates GetPTPCoordinates()
        {
            for (int i = 0; i < cbAddedAxes.Length; i++)
            {
                if (cbAddedAxes[i].Checked)
                {
                    return new PairOfCoordinates(Convert.ToDouble(nudPosition1[i].Value), Convert.ToDouble(nudPosition2[i].Value));
                }
            }
            throw new Exception();
        }
        private void GetInterpolationCoordsArray(out double[] pos1, out double[] pos2)
        {
            List<double> listPosition1 = new List<double>();
            List<double> listPosition2 = new List<double>();
            int interpolationCounter = 0;
            for (int i = 0; i < cbAddedAxes.Length; i++)
            {
                if (cbAddedAxes[i].Checked)
                {
                    if (interpolationCounter < 3)
                    {
                        interpolationCounter++;
                        InterpolationController.AddAxisToInterpolationGroup(Machine.board[i]);
                        listPosition1.Add(Convert.ToDouble(nudPosition1[i].Value));
                        listPosition2.Add(Convert.ToDouble(nudPosition2[i].Value));
                    }
                }
            }
            pos1 = listPosition1.ToArray();
            pos2 = listPosition2.ToArray();
        }
        private void SetInterpolationStepTicker(double[] pos1, double[] pos2)
        {
            testTimerTick = () =>
            {
                switch (tickerState)
                {
                    case 1:
                        if (firstStepDone)
                        {
                            tickerState = 4;
                            break;
                        }
                        InterpolationController.MoveInterpolationGroupAbsolute(pos1);
                        tickerState++;
                        break;
                    case 2:
                        if (InterpolationController.GetInterpolationGroupState() == (ushort)GroupState.STA_Gp_Motion) break;
                        tickerState++;
                        break;
                    case 3:
                        firstStepDone = true;
                        tickerState = 0;
                        break;
                    case 4:
                        InterpolationController.MoveInterpolationGroupAbsolute(pos2);
                        tickerState++;
                        break;
                    case 5:
                        if (InterpolationController.GetInterpolationGroupState() == (ushort)GroupState.STA_Gp_Motion) break;
                        tickerState++;
                        break;
                    case 6:
                        firstStepDone = false;
                        tickerState = 0;
                        break;
                }
            };
        }
        private void SetInterpolationAutoTicker(double[] pos1, double[] pos2, int delay)
        {
            testTimerTick = () =>
            {
                switch (tickerState)
                {
                    case 1:
                        InterpolationController.MoveInterpolationGroupAbsolute(pos1);
                        tickerState++;
                        break;
                    case 2:
                        if (InterpolationController.GetInterpolationGroupState() == (ushort)GroupState.STA_Gp_Motion) break;
                        tickerState++;
                        break;
                    case 3:
                        testStartTime = Environment.TickCount;
                        tickerState++;
                        break;
                    case 4:
                        if (Environment.TickCount - testStartTime < delay) break;
                        tickerState++;
                        break;
                    case 5:
                        InterpolationController.MoveInterpolationGroupAbsolute(pos2);
                        tickerState++;
                        break;
                    case 6:
                        if (InterpolationController.GetInterpolationGroupState() == (ushort)GroupState.STA_Gp_Motion) break;
                        tickerState++;
                        break;
                    case 7:
                        testStartTime = Environment.TickCount;
                        tickerState++;
                        break;
                    case 8:
                        if (Environment.TickCount - testStartTime < delay) break;
                        tickerState++;
                        break;
                    case 9:
                        tickerState = 1;
                        break;
                }
            };
        }
        private void SetHybridStepTicker(double[] pos1, double[] pos2, double phiPos1, double phiPos2)
        {
            testTimerTick = () =>
            {
                switch (tickerState)
                {
                    case 1:
                        if (firstStepDone)
                        {
                            tickerState = 4;
                            break;
                        }
                        AxesController.MoveToPoint(Machine.board[3], phiPos1);
                        InterpolationController.MoveInterpolationGroupAbsolute(pos1);
                        tickerState++;
                        break;
                    case 2:
                        if (IsHybridInterpolationInProgress()) break;
                        tickerState++;
                        break;
                    case 3:
                        firstStepDone = true;
                        tickerState = 0;
                        break;
                    case 4:
                        AxesController.MoveToPoint(Machine.board[3], phiPos2);
                        InterpolationController.MoveInterpolationGroupAbsolute(pos2);
                        tickerState++;
                        break;
                    case 5:
                        if (IsHybridInterpolationInProgress()) break;
                        tickerState++;
                        break;
                    case 6:
                        firstStepDone = false;
                        tickerState = 0;
                        break;
                };
            };
        }

        private bool IsHybridInterpolationInProgress()
        {
            return AxesController.GetAxisState(Machine.board[3]) == (ushort)AxisState.STA_AX_PTP_MOT ||
                        InterpolationController.GetInterpolationGroupState() == (ushort)GroupState.STA_Gp_Motion;
        }

        private void SetHybridAutoTicker(double[] pos1, double[] pos2, double phiPos1, double phiPos2, int delay)
        {
            testTimerTick = () =>
            {
                switch (tickerState)
                {
                    case 1:
                        AxesController.MoveToPoint(Machine.board[3], phiPos1);
                        InterpolationController.MoveInterpolationGroupAbsolute(pos1);
                        tickerState++;
                        break;
                    case 2:
                        if (IsHybridInterpolationInProgress()) break;
                        tickerState++;
                        break;
                    case 3:
                        testStartTime = Environment.TickCount;
                        tickerState++;
                        break;
                    case 4:
                        if (Environment.TickCount - testStartTime < delay) break;
                        tickerState++;
                        break;
                    case 5:
                        AxesController.MoveToPoint(Machine.board[3], phiPos2);
                        InterpolationController.MoveInterpolationGroupAbsolute(pos2);
                        tickerState++;
                        break;
                    case 6:
                        if (IsHybridInterpolationInProgress()) break;
                        tickerState++;
                        break;
                    case 7:
                        testStartTime = Environment.TickCount;
                        tickerState++;
                        break;
                    case 8:
                        if (Environment.TickCount - testStartTime < delay) break;
                        tickerState++;
                        break;
                    case 9:
                        tickerState = 1;
                        break;
                }
            };
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (tickerState == 0)
            {
                int axesInTest = 0;
                for (int i = 0; i < cbAddedAxes.Length; i++)
                    if (cbAddedAxes[i].Checked)
                        axesInTest++;
                if (axesInTest == 0) return;

                if (!rbStep.Checked) btnStartInterpolatedMovement.Text = "Остановить\nдвижение";
                if (rbStep.Checked)
                {
                    rbBackAndForth.Enabled = false;
                    btnStartInterpolatedMovement.Enabled = false;
                }


                if (axesInTest == 1)
                {
                    int ptpAxisIndex = GetPTPIndex();
                    AxesController.SetAxisHighVelocity(Machine.board[ptpAxisIndex], Machine.Instance.DriverVelocity[ptpAxisIndex]);
                    PairOfCoordinates coords = GetPTPCoordinates();
                    if (rbStep.Checked)
                    {
                        SetPTPStepTicker(ptpAxisIndex, coords);
                        //idea - if manipulator is already in 1st position -> go to second
                        //if (coords.first == AxesController.GetAxisCommandPosition(Machine.board[ptpAxisIndex])) firstStepDone = true;
                    }
                    else
                    {
                        SetPTPAutoTicker(ptpAxisIndex, coords, Convert.ToInt32(nudDelay.Value));
                    }
                }
                else if (axesInTest > 1)
                {
                    InterpolationController.RemoveAllAxesFromInterpolationGroup(Machine.board);
                    GetInterpolationCoordsArray(out double[] pos1, out double[] pos2);

                    if (axesInTest < 4)
                        if (rbStep.Checked)
                            SetInterpolationStepTicker(pos1, pos2);
                        else
                            SetInterpolationAutoTicker(pos1, pos2, Convert.ToInt32(nudDelay.Value));
                    else
                    {
                        AxesController.SetAxisHighVelocity(Machine.board[3], Machine.Instance.DriverVelocity[3]);
                        if (rbStep.Checked)
                            SetHybridStepTicker(pos1,
                                            pos2,
                                            Convert.ToDouble(nudPosition1Phi.Value),
                                            Convert.ToDouble(nudPosition2Phi.Value));
                        else

                            SetHybridAutoTicker(pos1,
                                            pos2,
                                            Convert.ToDouble(nudPosition1Phi.Value),
                                            Convert.ToDouble(nudPosition2Phi.Value),
                                            Convert.ToInt32(nudDelay.Value));
                    }
                }
                //start test
                if (axesInTest > 1)
                    for(int i = 0; i < rbDriveSpeed.Length; i++)
                    {
                        if (rbDriveSpeed[i].Checked)
                        {
                            InterpolationController.SetDriveAxis(i);
                            break;
                        } 
                    }
                tickerState = 1;
                driverTestTimer.Start();
                speedometer.Start();
            }
            else
            {
                //if test in progress - press of button stops it
                tickerState = 0;
                InterpolationController.StopInterpolationGroupMovement();
                AxesController.StopMovementForAllAxes(Machine.board);
                btnStartInterpolatedMovement.Text = "Начать\nдвижение";
            }
        }

        void SetMaxCoord()
        {
            NumericUpDown[] nudPosition1 = { nudPosition1X, nudPosition1Y, nudPosition1Z, nudPosition1Phi };
            NumericUpDown[] nudPosition2 = { nudPosition2X, nudPosition2Y, nudPosition2Z, nudPosition2Phi };

            for (int i = 0; i < 4; i++)
            {
                if (Machine.Instance.MaxCoordinate[i] == 0) continue;
                decimal maxValue = Convert.ToDecimal(Machine.Instance.MaxCoordinate[i]);
                nudPosition2[i].Maximum = maxValue;
                nudPosition1[i].Maximum = maxValue;
            }
        }

        private void tmrInterpolationGroupState_Tick(object sender, EventArgs e)
        {
            interpolationGroupState = (GroupState)InterpolationController.GetInterpolationGroupState();
            tbInterpolationState.Text = interpolationGroupState.ToString();
        }

        private void DriverTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            InterpolationController.StopInterpolationGroupMovement();
            AxesController.StopMovementForAllAxes(Machine.board);
            tickerState = 0;
        }

        private void DriverTest_Load(object sender, EventArgs e)
        {
            checkboxesToRadioButtons.Add(cbAddAxisX, rbDriveX);
            checkboxesToRadioButtons.Add(cbAddAxisY, rbDriveY);
            checkboxesToRadioButtons.Add(cbAddAxisZ, rbDriveZ);
            checkboxesToRadioButtons.Add(cbAddAxisPhi, rbDrivePhi);
        }

        private void ActivateInterfaceByCb(object sender)
        {
            CheckBox checkbox = (CheckBox)sender;
            RadioButton radioButton;
            if (checkboxesToRadioButtons.TryGetValue(checkbox, out radioButton))
            {
                bool cben = false;
                for (int i = 0; i < 4; i++)
                {
                    if (checkboxesToRadioButtons.ElementAt(i).Value.Checked) cben = true;
                }

                if (!radioButton.Checked && !cben)
                {
                    radioButton.Checked = checkbox.Checked;
                }

                if (checkbox.Checked == false && checkboxesToRadioButtons[checkbox].Checked)
                {
                    radioButton.Checked = false;

                    // Находим следующий активный радиобаттон
                    int nextActiveIndex = FindNextActiveRadioButton(cbAddedAxes);

                    // Если такой радиобаттон найден, устанавливаем у него свойство Checked в значение true
                    if (nextActiveIndex < checkboxesToRadioButtons.Count)
                    {
                        checkboxesToRadioButtons.ElementAt(nextActiveIndex).Value.Checked = true;
                    }
                }
            }
        }

        private int FindNextActiveRadioButton(CheckBox[] checkboxes)
        {
            int nextActiveIndex = 0;
            while (nextActiveIndex < checkboxes.Length && !checkboxes[nextActiveIndex].Checked)
            {
                nextActiveIndex++;
            }

            return nextActiveIndex;
        }

        private void cbAddAxisX_CheckedChanged(object sender, EventArgs e)
        {
            ActivateInterfaceByCb(sender);
            nudPosition1X.Enabled = !nudPosition1X.Enabled;
            nudPosition2X.Enabled = !nudPosition2X.Enabled;
            rbDriveX.Enabled = !rbDriveX.Enabled;
        }

        private void cbAddAxisY_CheckedChanged(object sender, EventArgs e)
        {
            ActivateInterfaceByCb(sender);
            nudPosition1Y.Enabled = !nudPosition1Y.Enabled;
            nudPosition2Y.Enabled = !nudPosition2Y.Enabled;
            rbDriveY.Enabled = !rbDriveY.Enabled;
        }

        private void cbAddAxisZ_CheckedChanged(object sender, EventArgs e)
        {
            ActivateInterfaceByCb(sender);
            nudPosition1Z.Enabled = !nudPosition1Z.Enabled;
            nudPosition2Z.Enabled = !nudPosition2Z.Enabled;
            rbDriveZ.Enabled = !rbDriveZ.Enabled;
        }

        private void cbAddAxisPhi_CheckedChanged(object sender, EventArgs e)
        {
            ActivateInterfaceByCb(sender);
            nudPosition1Phi.Enabled = !nudPosition1Phi.Enabled;
            nudPosition2Phi.Enabled = !nudPosition2Phi.Enabled;
            rbDrivePhi.Enabled = !rbDrivePhi.Enabled;
        }

        private void nudPosition1X_ValueChanged(object sender, EventArgs e)
        {
            SetMaxCoord();
        }

        private void nudPosition2Z_ValueChanged(object sender, EventArgs e)
        {
            SetMaxCoord();
        }

        private void nudPosition2Y_ValueChanged(object sender, EventArgs e)
        {
            SetMaxCoord();
        }

        private void nudPosition2X_ValueChanged(object sender, EventArgs e)
        {
            SetMaxCoord();
        }

        private void nudPosition1Phi_ValueChanged(object sender, EventArgs e)
        {
            SetMaxCoord();
        }

        private void nudPosition1Z_ValueChanged(object sender, EventArgs e)
        {
            SetMaxCoord();
        }

        private void nudPosition1Y_ValueChanged(object sender, EventArgs e)
        {
            SetMaxCoord();
        }

        private void nudPosition2Phi_ValueChanged(object sender, EventArgs e)
        {
            SetMaxCoord();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i< rbDriveSpeed.Length; i++)
            {
                if (rbDriveSpeed[i].Checked)
                    InterpolationController.getdrivespeed(i);
            }

        }

        private void speedometer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < rbDriveSpeed.Length; i++)
            {
                    textBox1.Text = InterpolationController.getdrivespeed(i).ToString();
            }

        }
    }
}
