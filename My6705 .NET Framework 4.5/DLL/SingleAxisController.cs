using Advantech.Motion;
using System;
using System.Text;
using System.Windows.Forms;

namespace My6705.NET_Framework_4._5
{
    public static partial class AxesController
    {
        /// <summary>
        /// Движение в точку по одной оси
        /// </summary>
        /// <param name="axisHandler">Обработчик (Handler) оси платы</param>
        /// <param name="position">Координата точки</param>
        public static void MoveToPoint(IntPtr axisHandler, double position)
        {
            uint actionResult = Motion.mAcm_AxMoveAbs(axisHandler, position);
            string errorPrefix = "PTP Move";
            CheckAPIError(actionResult, errorPrefix);
        }

        /// <summary>
        /// Получить командную координату по выбранной оси в данный момент времени. 
        /// </summary>
        /// <param name="axisHandler">Обработчик (Handler) оси платы</param>
        /// <returns>Командная координата положения привода в данны ймомент времени</returns>
        public static double GetAxisCommandPosition(IntPtr axisHandler)
        {
            double CurrentComandPosition = new double();
            uint actionResult = Motion.mAcm_AxGetCmdPosition(axisHandler, ref CurrentComandPosition);
            string errorPrefix = "Get Comand Position";
            CheckAPIError(actionResult, errorPrefix);
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
            uint actionResult = Motion.mAcm_SetF64Property(axisHandler, (uint)PropertyID.PAR_AxVelHigh, velHigh);
            string errorPrefix = "Set high velocity";
            CheckAPIError(actionResult, errorPrefix);
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
            uint actionResult;
            string errorPrefix = "Set Acceleration";
            for (int i = 0; i < b.AxesCount; i++)
            {
                actionResult = Motion.mAcm_SetF64Property(b[i], (uint)PropertyID.PAR_AxAcc, acc[i]);
                CheckAPIError(actionResult, errorPrefix);
            }
        }

        public static void StopContinuousMovementEmg(IntPtr axisHandler)
        {
            uint actionResult = Motion.mAcm_AxStopEmg(axisHandler);
            string errorPrefix = "Axis Emg Stop";
            CheckAPIError(actionResult, errorPrefix);
        }

        public static void SetAxisDeceleration(IntPtr axisHandler, double value)
        {
            uint actionResult = Motion.mAcm_SetF64Property(axisHandler, (uint)PropertyID.PAR_AxDec, value);
            string errorPrefix = "Set deceleration";
            CheckAPIError(actionResult, errorPrefix);
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
            uint actionResult = Motion.mAcm_SetF64Property(axisHandler, (uint)PropertyID.PAR_AxJerk, value);
            string errorPrefix = "Set the type of velocity profile";
            CheckAPIError(actionResult, errorPrefix);
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
            uint actionResult = Motion.mAcm_SetF64Property(axisHandler, (uint)PropertyID.PAR_AxVelLow, value);
            string errorPrefix = "Set low velocity";
            CheckAPIError(actionResult, errorPrefix);
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
            uint actionResult = Motion.mAcm_AxSetSvOn(axisHandler, 1);
            string errorPrefix = "Servo On";
            CheckAPIError(actionResult, errorPrefix);
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
            uint actionResult = Motion.mAcm_AxSetSvOn(axisHandler, 0);
            string errorPrefix = "Servo Off";
            CheckAPIError(actionResult, errorPrefix);
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
            uint actionResult = Motion.mAcm_AxHome(axisHandler, homeMode, dirMode);
            string errorPrefix = "AxHome";
            CheckAPIError(actionResult, errorPrefix);
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
            uint actionResult = Motion.mAcm_AxMoveVel(b[axisIndex], direction);
            string errorPrefix = "Continuous Movement";
            CheckAPIError(actionResult, errorPrefix);
        }

        public static ushort GetAxisState(IntPtr axisHandler)
        {
            ushort state = new ushort();
            uint actionResult = Motion.mAcm_AxGetState(axisHandler, ref state);
            string errorPrefix = "Get Axis State";
            CheckAPIError(actionResult, errorPrefix);
            return state;
        }

        public static void StopMovementForAllAxes(Board b)
        {
            for (int i = 0; i < b.AxesCount; i++)
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
            uint actionResult = Motion.mAcm_AxResetError(axisHandler);
            string errorPrefix = "Reset axis's error";
            CheckAPIError(actionResult, errorPrefix);
        }

        public static void AxisRelativeMove(IntPtr axisHandler, double distance)
        {
            uint actionResult = Motion.mAcm_AxMoveRel(axisHandler, distance);
            string errorPrefix = "Ax Move Rel";
            CheckAPIError(actionResult, errorPrefix);
        }

        public static void ResetCmdPosition(IntPtr axisHandler)
        {
            uint actionResult = Motion.mAcm_AxSetActualPosition(axisHandler, 0);
            string errorPrefix = "Reset cmd position";
            CheckAPIError(actionResult, errorPrefix);
        }

        public static bool IfMaximumReached(int axisIndex)
        {
            return Machine.MaxCoordinate[axisIndex] != 0 ? Machine.MaxCoordinate[axisIndex]
                <= GetAxisCommandPosition(Machine.Board[axisIndex]) : false;
        }

        public static double[] GetActPositionsAsArray(Board b)
        {
            int axesCount = b.AxesCount;
            double[] result = new double[axesCount];
            for (int i = 0; i < axesCount; i++)
            {
                result[i] = GetAxisActPosition(b[i]);
            }
            return result;
        }

        public static double GetAxisActPosition(IntPtr axisHandler)
        {
            double currentActPosition = new double();
            uint actionResult = Motion.mAcm_AxGetActualPosition(axisHandler, ref currentActPosition);
            string errorPrefix = "Get Comand Position";
            CheckAPIError(actionResult, errorPrefix);
            return currentActPosition;
        }

        public static void ResetActPosition(IntPtr axisHandler)
        {
            uint actionResult = Motion.mAcm_AxSetActualPosition(axisHandler, 0);
            string errorPrefix = "Reset cmd position";
            CheckAPIError(actionResult, errorPrefix);
        }

        public static double GetAxisHighVelocity(IntPtr axisHandler)
        {
            double vel = new double();
            uint actionResult = Motion.mAcm_GetF64Property(axisHandler, (uint)PropertyID.PAR_AxVelHigh, ref vel);
            string errorPrefix = "get vel high";
            CheckAPIError(actionResult, errorPrefix);
            return vel;

        }

        private static void CheckAPIError(uint errorCode, string errorPrefix)
        {
            string errorMessage = $"{errorPrefix} Failed With Error Code: [0x";
            if (errorCode != (uint)ErrorCode.SUCCESS)
            {
                errorMessage += Convert.ToString(errorCode, 16) + ']';
                StringBuilder ErrorMsg = new StringBuilder("", 100);
                //Get the error message according to error code returned from API
                Boolean res = Motion.mAcm_GetErrorMessage(errorCode, ErrorMsg, 100);
                string ErrorMessage = "";
                if (res) ErrorMessage = ErrorMsg.ToString();
                MessageBox.Show(errorMessage + "\r\nError Message:" + ErrorMessage, "6705 Software", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception();
            }
        }
    }
}
