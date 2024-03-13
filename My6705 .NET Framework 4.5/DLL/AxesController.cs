using Advantech.Motion;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace My6705.NET_Framework_4._5
{
    public static class AxesController
    {
        /// <summary>
        /// Движение в точку по одной оси
        /// </summary>
        /// <param name="axisHandler">Обработчик (Handler) оси платы</param>
        /// <param name="position">Координата точки</param>
        public static void MoveToPoint(IntPtr axisHandler, double position)
        {
            BoardActionPerformer.PerformBoardAction(() =>
            {
                return Motion.mAcm_AxMoveAbs(axisHandler, position);
            },
            "PTP Move");
        }

        /// <summary>
        /// Получить командную координату по выбранной оси в данный момент времени. 
        /// </summary>
        /// <param name="axisHandler">Обработчик (Handler) оси платы</param>
        /// <returns>Командная координата положения привода в данны ймомент времени</returns>
        public static double GetAxisCommandPosition(IntPtr axisHandler)
        {
            double CurrentComandPosition = new double();
            BoardActionPerformer.PerformBoardAction(() =>
            {
                return Motion.mAcm_AxGetCmdPosition(axisHandler, ref CurrentComandPosition);
            },
            "Get Comand Position");
            return CurrentComandPosition;
        }

        /// <summary>
        /// Получить командные координаты всех осей, инициализированных платой
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double[] GetCommandPositionsAsArray(Board b)
        {
            int axesCount = b.AxesCount;
            double[] result = new double[axesCount];
            for (int i = 0; i < axesCount; i++)
            {
                result[i] = GetAxisCommandPosition(b[i]);
            }
            return result;
        }

        /// <summary>
        /// Устанавливает значение высокой скорости на выбранной оси
        /// </summary>
        /// <param name="velHigh">Значение скорости</param>
        /// <param name="axisHandler">Обработчик (Handler) оси платы</param>
        public static void SetAxisHighVelocity(IntPtr axisHandler, double velHigh)
        {
            BoardActionPerformer.PerformBoardAction(() =>
            {
                return Motion.mAcm_SetF64Property(axisHandler, (uint)PropertyID.PAR_AxVelHigh, velHigh);
            },
            "Set high velocity");
        }

        /// <summary>
        /// Устанавливает значение скорости для каждой оси
        /// </summary>
        /// <param name="velHigh">Массив значений скоростей</param>
        /// <param name="b">Плата, на которой устанавливаются значения</param>
        public static void SetHighVelocity(Board b, double[] velHigh)
        {
            for (int i = 0; i < b.AxesCount; i++)
            {
                SetAxisHighVelocity(b[i], velHigh[i]);
            }
        }

        /// <summary>
        /// Устанавливает значение ускорения для каждой оси
        /// </summary>
        /// <param name="acc">Массив значений ускорений</param>
        /// <param name="b">Плата, на которой устанавливаются значения</param>
        public static void SetActAcc(Board b, double[] acc)
        {
            for (int i = 0; i < b.AxesCount; i++)
            {
                BoardActionPerformer.PerformBoardAction(() =>
                {
                    return Motion.mAcm_SetF64Property(b[i], (uint)PropertyID.PAR_AxAcc, acc[i]);
                },
                "Set Acceleration");
            }
        }

        public static void StopContinuousMovementEmg(IntPtr axisHandler)
        {
            BoardActionPerformer.PerformBoardAction(() =>
            {
                return Motion.mAcm_AxStopEmg(axisHandler);
            },
            "Axis Emg Stop");
        }
    
        public static void SetAxisDeceleration(IntPtr axisHandler, double value)
        {
            BoardActionPerformer.PerformBoardAction(() =>
            {
                return Motion.mAcm_SetF64Property(axisHandler, (uint)PropertyID.PAR_AxDec, value);
            },
            "Set deceleration");
        }

        public static void SetDeceleration(Board b, double[] decs)
        {
            for (int i = 0; i < b.AxesCount; i++)
            {
                SetAxisDeceleration(b[i], decs[i]);
            }
        }

        public static void SetAxisJerk(IntPtr axisHandler, double value)
        {
            BoardActionPerformer.PerformBoardAction(() =>
            {
                return Motion.mAcm_SetF64Property(axisHandler, (uint)PropertyID.PAR_AxJerk, value);
            },
            "Set the type of velocity profile");
        }

        public static void SetJerk(Board b, double[] decs)
        {
            for (int i = 0; i < b.AxesCount; i++)
            {
                SetAxisJerk(b[i], decs[i]);
            }
        }

        public static void SetAxisLowVelocity(IntPtr axisHandler, double value)
        {
            BoardActionPerformer.PerformBoardAction(() =>
            {
                return Motion.mAcm_SetF64Property(axisHandler, (uint)PropertyID.PAR_AxVelLow, value);
            },
            "Set low velocity");
        }

        public static void SetLowVelocity(Board b, double[] velLow)
        {
            for (int i = 0; i < b.AxesCount; i++)
            {
                SetAxisLowVelocity(b[i], velLow[i]);
            }
        }

        public static void AxisServoOn(IntPtr axisHandler)
        {
            BoardActionPerformer.PerformBoardAction(() =>
            {
                return Motion.mAcm_AxSetSvOn(axisHandler, 1);
            },
            "Servo On");
        }

        public static void AllAxesServoOn(Board b)
        {
            for (int i = 0; i < b.AxesCount; i++)
            {
                AxisServoOn(b[i]);
            }
        }

        public static void AxisServoOff(IntPtr axisHandler)
        {
            BoardActionPerformer.PerformBoardAction(() =>
            {
                return Motion.mAcm_AxSetSvOn(axisHandler, 0);
            },
            "Servo Off");
        }

        public static void AllAxesServoOff(Board b)
        {
            for (int i = 0; i < b.AxesCount; i++)
            {
                AxisServoOff(b[i]);
            }
        }

        public static void AxisMoveHome(IntPtr axisHandler, uint homeMode, uint dirMode)
        {
            BoardActionPerformer.PerformBoardAction(() =>
            {
                return Motion.mAcm_AxHome(axisHandler, homeMode, dirMode);
            },
            "AxHome");
        }

        public static void StartContinuousMovementChecked(Board b, int axisIndex, ushort direction)
        {
            if (GetAxisState(b[axisIndex]) == (ushort)AxisState.STA_AX_READY)
            {
                //если максимальная координата задана и нынешняя координата больше максимальной
                if (IfMaximumReached(axisIndex)
                    && direction == 0)
                {
                    return;
                }
                StartContinuousMovement(b, axisIndex, direction);
            }
        }

        public static void StartContinuousMovement(Board b, int axisIndex, ushort direction)
        {
            BoardActionPerformer.PerformBoardAction(() =>
            {
                return Motion.mAcm_AxMoveVel(b[axisIndex], direction);
            },
            "Continuous Movement");
        }
    
        public static ushort GetAxisState(IntPtr axisHandler)
        {
            ushort state = new ushort();
            BoardActionPerformer.PerformBoardAction(() =>
            {
                return Motion.mAcm_AxGetState(axisHandler, ref state);
            },
            "Get Axis State");
            return state;
        }

        public static void StopMovementForAllAxes(Board b)
        {
            for(int i = 0; i < b.AxesCount; i++)
            {
                StopContinuousMovementEmg(b[i]);
            }
        }

        public static void ResetAllErrors(Board b)
        {
            for (int i = 0; i < 4; i++)
            {
                ResetAxisError(b[i]);
            }
        }

        public static void ResetAxisError(IntPtr axisHandler)
        {
            BoardActionPerformer.PerformBoardAction(() =>
            {
                return Motion.mAcm_AxResetError(axisHandler);
            },
            "Reset axis's error");
        }

        public static void AxisRelativeMove(IntPtr axisHandler, double distance)
        {
            BoardActionPerformer.PerformBoardAction(() =>
            {
                return Motion.mAcm_AxMoveRel(axisHandler, distance);
            },
            "Ax Move Rel");
        }

        public static void ResetCmdPosition(IntPtr axisHandler)
        {
            BoardActionPerformer.PerformBoardAction(() =>
            {
                return Motion.mAcm_AxSetCmdPosition(axisHandler, 0);
            },
            "Reset cmd position");
        }

        public static bool IfMaximumReached(int axisIndex)
        {
            return Machine.MaxCoordinate[axisIndex] != 0 ? Machine.MaxCoordinate[axisIndex] 
                <= GetAxisCommandPosition(Machine.Board[axisIndex]) : false;
        }
    }
}
