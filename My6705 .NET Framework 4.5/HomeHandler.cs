using Advantech.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace My6705.NET_Framework_4._5
{
    public class HomeHandler
    {
        private readonly double basingDistance = 1000;
        private readonly ushort stateHoming = (ushort)AxisState.STA_AX_HOMING;
        private readonly ushort stateMoving = (ushort)AxisState.STA_AX_PTP_MOT;
        private static readonly int ticksBeforeStop = 10000;
        private readonly double timeBeforeStop = ticksBeforeStop * 1; // Home timer variable to control time spend on reaching the limiter
        private readonly Timer timer;
        private readonly Button homeBtn;
        private readonly Button turnServoBtn;

        int startTime;
        int homeTickerState = 0;

        public HomeHandler(Timer homeTimer, Button homeBtn, Button turnServoBtn)
        {
            timer = homeTimer;
            this.homeBtn = homeBtn;
            this.turnServoBtn = turnServoBtn;
            this.homeBtn.Click += Start;
            timer.Tick += TimerTick;
        }

        private void SensorNotFoundStop(int axisIndex)
        {
            homeTickerState = 0;
            turnServoBtn.Enabled = true;
            homeBtn.Enabled = true;
            AxesController.StopContinuousMovementEmg(Machine.Board[axisIndex]);
            KeyboardControl.blockControls = false;
            MessageBox.Show("Не удалось обнаружить датчик ИП");
        }

        public void Start(object sender, EventArgs e)
        {
            startTime = Environment.TickCount;
            turnServoBtn.Enabled = false;
            KeyboardControl.blockControls = true;
            homeTickerState = 1;
            homeBtn.Enabled = false;
            AxesController.SetHighVelocity(Machine.Board, Machine.DriverVelocity);
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            //Home Timer
            if (homeTickerState == 0)
            {
                timer.Stop();
                homeBtn.Enabled = true;
                turnServoBtn.Enabled = true;
                KeyboardControl.blockControls = false;
                return;
            }
            HomeTick();
        }

        public void HomeTick()
        {
            switch (homeTickerState)
            {
                case 1:
                    AxesController.AxisMoveHome(Machine.Board[Axes.Z], 1, 1);
                    homeTickerState++;
                    break;
                case 2:
                    if (Environment.TickCount - startTime > timeBeforeStop)
                    {
                        SensorNotFoundStop(2);
                        break;
                    }
                    if (AxesController.GetAxisState(Machine.Board[2]) == stateHoming) break;
                    homeTickerState++;
                    break;
                case 3:
                    AxesController.AxisRelativeMove(Machine.Board[2], basingDistance);
                    homeTickerState++;
                    break;
                case 4:
                    if (AxesController.GetAxisState(Machine.Board[2]) == stateMoving) break;
                    AxesController.ResetCmdPosition(Machine.Board[2]);
                    AxesController.ResetActPosition(Machine.Board[2]);
                    homeTickerState++;
                    break;
                case 5:
                    AxesController.AxisMoveHome(Machine.Board[Axes.X], 1, 1);
                    homeTickerState++;
                    break;
                case 6:
                    if (Environment.TickCount - startTime > timeBeforeStop)
                    {
                        SensorNotFoundStop(0);
                        break;
                    }
                    if (AxesController.GetAxisState(Machine.Board[0]) == stateHoming) break;
                    homeTickerState++;
                    break;
                case 7:
                    AxesController.AxisRelativeMove(Machine.Board[0], basingDistance);
                    homeTickerState++;
                    break;
                case 8:
                    if (AxesController.GetAxisState(Machine.Board[0]) == stateMoving) break;
                    homeTickerState++;
                    AxesController.ResetCmdPosition(Machine.Board[0]);
                    AxesController.ResetActPosition(Machine.Board[0]);
                    break;
                case 9:
                    AxesController.AxisMoveHome(Machine.Board[Axes.Y], 1, 1);
                    homeTickerState++;
                    break;
                case 10:
                    if (Environment.TickCount - startTime > timeBeforeStop)
                    {
                        SensorNotFoundStop(1);
                        break;
                    }
                    if (AxesController.GetAxisState(Machine.Board[1]) == stateHoming) break;
                    homeTickerState++; break;
                case 11:
                    AxesController.AxisRelativeMove(Machine.Board[1], basingDistance);
                    homeTickerState++;
                    break;
                case 12:
                    if (AxesController.GetAxisState(Machine.Board[1]) == stateMoving) break;
                    AxesController.ResetCmdPosition(Machine.Board[1]);
                    AxesController.ResetActPosition(Machine.Board[1]);
                    homeTickerState++;
                    break;
                case 13:
                    AxesController.AxisMoveHome(Machine.Board[Axes.Phi], 1, 1);
                    homeTickerState++;
                    break;
                case 14:
                    if (Environment.TickCount - startTime > timeBeforeStop)
                    {
                        SensorNotFoundStop(3);
                        break;
                    }
                    if (AxesController.GetAxisState(Machine.Board[3]) == stateHoming) break;
                    else
                    {
                        homeTickerState = 0;
                    }
                    break;
                case 15:
                    AxesController.AxisRelativeMove(Machine.Board[3], basingDistance);
                    homeTickerState++;
                    break;
                case 16:
                    if (AxesController.GetAxisState(Machine.Board[3]) == stateMoving) break;
                    AxesController.ResetCmdPosition(Machine.Board[3]);         
                    AxesController.ResetActPosition(Machine.Board[3]);
                    homeTickerState = 0;
                    break;
            }
        }
    }
}
