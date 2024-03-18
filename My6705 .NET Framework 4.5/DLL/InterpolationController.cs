using Advantech.Motion;
using Emgu.Util.TypeEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My6705.NET_Framework_4._5.DLL
{
    public static class InterpolationController
    {
        //*На случай рефакторинга
        //На практике интерполяция используется только одной платой,
        //однако передать в функцию можно обработчик оси любой из плат.
        //Обработчик старой платы будет заменён на обработчик новой.
        private static IntPtr interpolationHandler = IntPtr.Zero;

        /// <summary>
        /// Обработчик платы для управления интерполяцией
        /// </summary>
        public static IntPtr InterpolationHandler { get { return interpolationHandler; } }

        /// <summary>
        /// Добавляет выбранную ось в интерполяционной группы
        /// </summary>
        /// <param name="axisHandler">Индекс оси</param>
        public static void AddAxisToInterpolationGroup(IntPtr axisHandler)
        {
            uint actionResult = Motion.mAcm_GpAddAxis(ref interpolationHandler, axisHandler);
            string errorPrefix = "Add Axis To Group";
            APIErrorChecker.Check(actionResult, errorPrefix);
        }

        //*На случай рефакторинга
        //Т.к. интерполяция используется только для одной платы,
        //в mAcm_GpRemAxis передаётся interpolationHandler, а не обработчик группы
        //выбранной платы, который мог бы передаваться параметром ф-ции
        /// <summary>
        /// Убирает выбранную ось из интерполяционной группы
        /// </summary>
        /// <param name="axisHandler">Индекс оси</param>
        public static void RemoveAxisFromInterpolationGroup(IntPtr axisHandler)
        {
            Motion.mAcm_GpRemAxis(InterpolationHandler, axisHandler);
        }

        /// <summary>
        /// Начинает интерполированное движение в заданную позицию
        /// </summary>
        /// <param name="position"></param>
        public static void MoveInterpolationGroupAbsolute(double[] position)
        {
            uint actionResult = Motion.mAcm_GpMoveLinearAbs(InterpolationHandler, position);
            string errorPrefix = "Interpolation Group Move";
            APIErrorChecker.Check(actionResult, errorPrefix);
        }

        /// <summary>
        /// Останавливает интерполированное движение
        /// </summary>
        public static void StopInterpolationGroupMovement()
        {
            Motion.mAcm_GpStopEmg(InterpolationHandler);
        }

        public static void RemoveAllAxesFromInterpolationGroup(Board b)
        {
            for (int i = 0; i < Machine.Board.AxesCount; i++) //3 = максимальное число осей для интерполяции
            {
                RemoveAxisFromInterpolationGroup(b[i]);
            }
        }

        public static void SetDriveAxis(int axisIndex)
        {
            uint actionResult = Motion.mAcm_SetF64Property(interpolationHandler, (uint)PropertyID.PAR_GpVelHigh, Machine.DriverVelocity[axisIndex]);
            string errorPrefix = "Interpolation Group Set Velocity";
            APIErrorChecker.Check(actionResult, errorPrefix);

            actionResult = Motion.mAcm_SetF64Property(interpolationHandler, (uint)PropertyID.PAR_GpVelLow, Machine.DriverVelocity[axisIndex]);
            errorPrefix = "Interpolation Group Set Velocity";
            APIErrorChecker.Check(actionResult, errorPrefix);
        }

        public static ushort GetInterpolationGroupState()
        {
            ushort GpState = new ushort();
            Motion.mAcm_GpGetState(InterpolationHandler, ref GpState);
            return GpState;
        }

        public static double getdrivespeed(int axisIndex)
        {
            double vel = 1;
            //MessageBox.Show(Motion.mAcm_AxGetCmdVelocity(Machine.board[axisIndex], ref vel).ToString());
            Motion.mAcm_GpGetCmdVel(interpolationHandler, ref vel);
            //MessageBox.Show(Machine.Instance.DriverVelocity[axisIndex].ToString() + " " + vel);
            return vel;
        }


    }
}
