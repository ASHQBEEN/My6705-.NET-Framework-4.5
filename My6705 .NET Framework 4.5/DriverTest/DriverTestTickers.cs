using Advantech.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My6705.NET_Framework_4._5
{
    public partial class DriverTest
    {
        private Action testTimerTick;
        private bool firstStepDone = false;
        private const ushort STATE_PTP_MOVING = (ushort)AxisState.STA_AX_PTP_MOT;
        private const ushort STATE_MULTIAXIS_MOVING = (ushort)GroupState.STA_Gp_Motion;

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
                        AxesController.MoveInterpolationGroupAbsolute(pos1, Machine.Board.interpolationHandler);
                        tickerState++;
                        break;
                    case 2:
                        if (AxesController.GetInterpolationGroupState(Machine.Board.interpolationHandler) == STATE_MULTIAXIS_MOVING) break;
                        tickerState++;
                        break;
                    case 3:
                        firstStepDone = true;
                        tickerState = 0;
                        break;
                    case 4:
                        AxesController.MoveInterpolationGroupAbsolute(pos2, Machine.Board.interpolationHandler);
                        tickerState++;
                        break;
                    case 5:
                        if (AxesController.GetInterpolationGroupState(Machine.Board.interpolationHandler) == STATE_MULTIAXIS_MOVING) break;
                        tickerState++;
                        break;
                    case 6:
                        firstStepDone = false;
                        tickerState = 0;
                        break;
                }
            };
        }

        private void SetPTPStepTicker(int ptpAxisIndex, double coord1, double coord2)
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
                        AxesController.MoveToPoint(Machine.Board[ptpAxisIndex], coord1);
                        tickerState++;
                        break;
                    case 2:
                        if (AxesController.GetAxisState(Machine.Board[ptpAxisIndex]) == STATE_PTP_MOVING) break;
                        tickerState++;
                        break;
                    case 3:
                        firstStepDone = true;
                        tickerState = 0;
                        break;
                    case 4:
                        AxesController.MoveToPoint(Machine.Board[ptpAxisIndex], coord2);
                        tickerState++;
                        break;
                    case 5:
                        if (AxesController.GetAxisState(Machine.Board[ptpAxisIndex]) == STATE_PTP_MOVING) break;
                        tickerState++;
                        break;
                    case 6:
                        firstStepDone = false;
                        tickerState = 0;
                        break;
                }
            };
        }

        private void SetPTPAutoTicker(int ptpAxisIndex, double coord1, double coord2, int delay)
        {
            testTimerTick = () =>
            {
                switch (tickerState)
                {
                    case 1:
                        AxesController.MoveToPoint(Machine.Board[ptpAxisIndex], coord1);
                        tickerState++;
                        break;
                    case 2:
                        if (AxesController.GetAxisState(Machine.Board[ptpAxisIndex]) == STATE_PTP_MOVING) break;
                        testStartTime = Environment.TickCount;
                        tickerState++;
                        break;
                    case 3:
                        if (Environment.TickCount - testStartTime < delay) break;
                        tickerState++;
                        break;
                    case 4:
                        AxesController.MoveToPoint(Machine.Board[ptpAxisIndex], coord2);
                        tickerState++;
                        break;
                    case 5:
                        if (AxesController.GetAxisState(Machine.Board[ptpAxisIndex]) == STATE_PTP_MOVING) break;
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

        private void SetInterpolationAutoTicker(double[] pos1, double[] pos2, int delay)
        {
            testTimerTick = () =>
            {
                switch (tickerState)
                {
                    case 1:
                        AxesController.MoveInterpolationGroupAbsolute(pos1, Machine.Board.interpolationHandler);
                        tickerState++;
                        break;
                    case 2:
                        if (AxesController.GetInterpolationGroupState(Machine.Board.interpolationHandler) == STATE_MULTIAXIS_MOVING) break;
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
                        AxesController.MoveInterpolationGroupAbsolute(pos2, Machine.Board.interpolationHandler);
                        tickerState++;
                        break;
                    case 6:
                        if (AxesController.GetInterpolationGroupState(Machine.Board.interpolationHandler) == STATE_MULTIAXIS_MOVING) break;
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
                        AxesController.MoveToPoint(Machine.Board[3], phiPos1);
                        AxesController.MoveInterpolationGroupAbsolute(pos1, Machine.Board.interpolationHandler);
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
                        AxesController.MoveToPoint(Machine.Board[3], phiPos2);
                        AxesController.MoveInterpolationGroupAbsolute(pos2, Machine.Board.interpolationHandler);
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

        private void SetHybridAutoTicker(double[] pos1, double[] pos2, double phiPos1, double phiPos2, int delay)
        {
            testTimerTick = () =>
            {
                switch (tickerState)
                {
                    case 1:
                        AxesController.MoveToPoint(Machine.Board[3], phiPos1);
                        AxesController.MoveInterpolationGroupAbsolute(pos1, Machine.Board.interpolationHandler);
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
                        AxesController.MoveToPoint(Machine.Board[3], phiPos2);
                        AxesController.MoveInterpolationGroupAbsolute(pos2, Machine.Board.interpolationHandler);
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

        private bool IsHybridInterpolationInProgress()
        {
            return AxesController.GetAxisState(Machine.Board[3]) == STATE_PTP_MOVING ||
                        AxesController.GetInterpolationGroupState(Machine.Board.interpolationHandler) == STATE_MULTIAXIS_MOVING;
        }
    }
}
