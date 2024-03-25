using Advantech.Motion;
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

        int tickerState = 0;
        int testStartTime = 0;

        public DriverTest()
        {
            InitializeComponent();
            KeyPreview = true;
            nudPosition1 = new NumericUpDown[] { nudPosition1X, nudPosition1Y, nudPosition1Z, nudPosition1Phi };
            nudPosition2 = new NumericUpDown[] { nudPosition2X, nudPosition2Y, nudPosition2Z, nudPosition2Phi };
            rbDriveSpeed = new RadioButton[] { rbDriveX, rbDriveY, rbDriveZ, rbDrivePhi };
            cbAddedAxes = new CheckBox[] { cbAddAxisX, cbAddAxisY, cbAddAxisZ, cbAddAxisPhi };
            checkboxesToRadioButtons.Add(cbAddAxisX, rbDriveX);
            checkboxesToRadioButtons.Add(cbAddAxisY, rbDriveY);
            checkboxesToRadioButtons.Add(cbAddAxisZ, rbDriveZ);
            checkboxesToRadioButtons.Add(cbAddAxisPhi, rbDrivePhi);
            SetMaxCoord();
        }

        private void driverTestTimer_Tick(object sender, EventArgs e)
        {
            if (tickerState == 0)
            {
                StopTheTest();
            }

            testTimerTick();

        }

        private int GetPTPIndex()
        {
            for (int i = 0; i < rbDriveSpeed.Length; i++)
            {
                if (rbDriveSpeed[i].Checked)
                {
                    return i;
                }
            }
            throw new Exception();
        }

        private void GetPTPCoordinates(out double coord1, out double coord2)
        {
            for (int i = 0; i < cbAddedAxes.Length; i++)
            {
                if (cbAddedAxes[i].Checked)
                {
                    coord1 = (double)nudPosition1[i].Value;
                    coord2 = (double)nudPosition2[i].Value;
                    return;
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
                        AxesController.AddAxisToInterpolationGroup(Machine.Board[i], ref Machine.Board.interpolationHandler);
                        listPosition1.Add((double)nudPosition1[i].Value);
                        listPosition2.Add((double)nudPosition2[i].Value);
                    }
                }
            }
            pos1 = listPosition1.ToArray();
            pos2 = listPosition2.ToArray();
        }

        private void btnStartTestClick(object sender, EventArgs e)
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
                    //
                    //MessageBox.Show(Machine.DriverVelocity[ptpAxisIndex].ToString());
                    AxesController.SetAxisHighVelocity(Machine.Board[ptpAxisIndex], Machine.DriverVelocity[ptpAxisIndex]);
                    //
                    //MessageBox.Show(AxesController.GetAxisHighVelocity(Machine.Board[ptpAxisIndex]).ToString());
                    GetPTPCoordinates(out double coord1, out double coord2);
                    if (rbStep.Checked)
                    {
                        SetPTPStepTicker(ptpAxisIndex, coord1, coord2);
                        //idea - if manipulator is already in 1st position -> go to second
                        //if (coords.first == AxesController.GetAxisCommandPosition(Machine.board[ptpAxisIndex])) firstStepDone = true;
                    }
                    else
                    {
                        SetPTPAutoTicker(ptpAxisIndex, coord1, coord2, (int)nudDelay.Value);
                    }
                }
                else if (axesInTest > 1)
                {
                    AxesController.RemoveAllAxesFromInterpolationGroup(Machine.Board);
                    GetInterpolationCoordsArray(out double[] pos1, out double[] pos2);

                    if (axesInTest < 4)
                        if (rbStep.Checked)
                            SetInterpolationStepTicker(pos1, pos2);
                        else
                            SetInterpolationAutoTicker(pos1, pos2, (int)nudDelay.Value);
                    else
                    {
                        AxesController.SetAxisHighVelocity(Machine.Board[3], Machine.DriverVelocity[3]);
                        if (rbStep.Checked)
                            SetHybridStepTicker(pos1,
                                            pos2,
                                            (double)nudPosition1Phi.Value,
                                            (double)nudPosition2Phi.Value);
                        else

                            SetHybridAutoTicker(pos1,
                                            pos2,
                                            (double)nudPosition1Phi.Value,
                                            (double)nudPosition2Phi.Value,
                                            (int)nudDelay.Value);
                    }
                }
                //start test
                if (axesInTest > 1)
                {
                    tmrInterpolationGroupState.Start();
                    for (int i = 0; i < rbDriveSpeed.Length; i++)
                    {
                        if (rbDriveSpeed[i].Checked)
                        {
                            AxesController.SetDriveAxis(i, Machine.Board.interpolationHandler);
                            break;
                        }
                    }
                }
                tickerState = 1;
                driverTestTimer.Start();
                KeyboardControl.blockControls = true;
                this.Activate();
            }
            else
            {
                //if test in progress - press of button stops it
                StopTheTest();
                KeyboardControl.blockControls = false;
            }
        }

        GroupState interpolationGroupState;

        private void tmrInterpolationGroupState_Tick(object sender, EventArgs e)
        {
            interpolationGroupState = (GroupState)AxesController.GetInterpolationGroupState(Machine.Board.interpolationHandler);
            tbInterpolationState.Text = interpolationGroupState.ToString();
        }

        private void DriverTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopTheTest();
        }

        private void StopTheTest()
        {
            tickerState = 0;
            AxesController.StopInterpolationGroupMovement(Machine.Board.interpolationHandler);
            AxesController.StopMovementForAllAxes(Machine.Board);
            if (rbStep.Checked)
            {
                rbBackAndForth.Enabled = true;
                btnStartInterpolatedMovement.Enabled = true;
            }
            KeyboardControl.blockControls = false;
            driverTestTimer.Stop();
            driverTestTimer.Stop();
            btnStartInterpolatedMovement.Text = "Начать\nдвижение";
        }

        private void StopOnSpaceKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                StopTheTest();
                lblAddAx.Focus();
            }
        }
    }
}
