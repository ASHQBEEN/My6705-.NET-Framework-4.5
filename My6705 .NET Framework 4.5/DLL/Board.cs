using Advantech.Motion;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace My6705.NET_Framework_4._5
{
    public class Board
    {
        private readonly IntPtr[] axesHandler;
        private readonly int axesCount;

        /// <summary>
        /// Количество осей, используемых платой.
        /// </summary>
        public int AxesCount { get { return axesCount; } }
        private readonly uint deviceNumber;

        private IntPtr deviceHandler = IntPtr.Zero;

        /// <summary>
        /// Обработчик платы.
        /// </summary>
        public IntPtr DeviceHandler { get { return deviceHandler; } }
        /// <summary>
        /// Конструктор для последующей инициализации платы Advantech и её осей
        /// </summary>
        /// <param name="deviceType">Номер устройства в Advantech.Motion.DevTypeID</param>
        /// <param name="boardID">ID платы в утилите Common Motion Utility</param>
        /// <param name="axesCount">Количество осей, инициализируемых платой</param>
        
        public Board(uint deviceType, uint boardID, int axesCount)
        {
            this.axesCount = axesCount;
            deviceNumber = FetchDeviceNumber(deviceType, boardID);
            deviceHandler = InitializeDeviceHandler();
            axesHandler = InitializeAxesHandler();
        }

        private uint FetchDeviceNumber(uint deviceType, uint boardID) 
        {
            uint deviceNumber = new uint();
            BoardActionPerformer.PerformBoardAction(() =>
            {
                return Motion.mAcm_GetDevNum(deviceType, boardID, ref deviceNumber);
            },
            "Open Device");
            return deviceNumber;
        }

        private IntPtr InitializeDeviceHandler()
        {
            IntPtr deviceHandler = IntPtr.Zero;
            BoardActionPerformer.PerformBoardAction(() =>
            {
                return Motion.mAcm_DevOpen(deviceNumber, ref deviceHandler);
            },
            "Open Device");
            return deviceHandler;
        }

        private IntPtr[] InitializeAxesHandler()
        {
            IntPtr[] axesHandler = new IntPtr[axesCount];
            for (int i = 0; i < axesCount; i++)
            {
                BoardActionPerformer.PerformBoardAction(() =>
                {
                    return Motion.mAcm_AxOpen(deviceHandler, (UInt16)i, ref axesHandler[i]);
                },
                "Open Axis");             
                //Set command and actual position of drivers to start (0-point)        
                Motion.mAcm_AxSetCmdPosition(axesHandler[i], 0);
                Motion.mAcm_AxSetActualPosition(axesHandler[i], 0);
            }
            return axesHandler;
        }
        
        /// <summary>
        /// Позволяет получить обработчик определённой оси.
        /// </summary>
        /// <param name="axisIndex">Индекс оси (начиная с 0).</param>
        /// <returns>Обработчик (Handler) выбранной оси.</returns>
        public IntPtr this[int axisIndex] {  get { return axesHandler[axisIndex]; } }
    
        public void LoadConfig(string path)
        {
            BoardActionPerformer.PerformBoardAction(() =>
            {
                return Motion.mAcm_DevLoadConfig(deviceHandler, path);
            },
            "Load Config");
        }

        public void CloseBoard()
        {
            BoardActionPerformer.PerformBoardAction(() =>
            {
                return Motion.mAcm_DevClose(ref deviceHandler);
            },
            "Close Board");
        }
    }
}
