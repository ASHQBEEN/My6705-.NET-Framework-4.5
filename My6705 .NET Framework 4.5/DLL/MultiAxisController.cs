using Advantech.Motion;
using System;

namespace My6705.NET_Framework_4._5
{
    public partial class AxesController
    {
        /// <summary>
        /// Добавляет выбранную ось в интерполяционной группы
        /// </summary>
        /// <param name="axisHandler">Индекс оси</param>
        public static void AddAxisToInterpolationGroup(IntPtr axisHandler, ref IntPtr interpolationHandler)
        {
            uint actionResult = Motion.mAcm_GpAddAxis(ref interpolationHandler, axisHandler);
            string errorPrefix = "Add Axis To Group";
            CheckAPIError(actionResult, errorPrefix);
        }

        /// <summary>
        /// Убирает выбранную ось из интерполяционной группы
        /// </summary>
        /// <param name="axisHandler">Индекс оси</param>
        public static void RemoveAxisFromInterpolationGroup(IntPtr axisHandler, IntPtr interpolationHandler)
        {
            Motion.mAcm_GpRemAxis(interpolationHandler, axisHandler);
        }

        /// <summary>
        /// Начинает интерполированное движение в заданную позицию
        /// </summary>
        /// <param name="position"></param>
        public static void MoveInterpolationGroupAbsolute(double[] position, IntPtr interpolationHandler)
        {
            uint actionResult = Motion.mAcm_GpMoveLinearAbs(interpolationHandler, position);
            string errorPrefix = "Interpolation Group Move";
            CheckAPIError(actionResult, errorPrefix);
        }

        /// <summary>
        /// Останавливает интерполированное движение
        /// </summary>
        public static void StopInterpolationGroupMovement(IntPtr interpolationHandler)
        {
            Motion.mAcm_GpStopEmg(interpolationHandler);
        }

        public static void RemoveAllAxesFromInterpolationGroup(Board b)
        {
            for (int i = 0; i < Machine.Board.AxesCount; i++) //3 = максимальное число осей для интерполяции
            {
                RemoveAxisFromInterpolationGroup(b[i], b.interpolationHandler);
            }
        }

        public static void SetDriveAxis(int axisIndex, IntPtr interpolationHandler)
        {
            uint actionResult = Motion.mAcm_SetF64Property(interpolationHandler, (uint)PropertyID.PAR_GpVelHigh, Machine.DriverVelocity[axisIndex]);
            string errorPrefix = "Interpolation Group Set Velocity";
            CheckAPIError(actionResult, errorPrefix);

            actionResult = Motion.mAcm_SetF64Property(interpolationHandler, (uint)PropertyID.PAR_GpVelLow, Machine.DriverVelocity[axisIndex]);
            errorPrefix = "Interpolation Group Set Velocity";
            CheckAPIError(actionResult, errorPrefix);
        }

        public static ushort GetInterpolationGroupState(IntPtr interpolationHandler)
        {
            ushort GpState = new ushort();
            uint actionResult = Motion.mAcm_GpGetState(interpolationHandler, ref GpState);
            string errorPrefix = "get interpolation state";
            CheckAPIError(actionResult, errorPrefix);
            return GpState;
        }
    }
}
