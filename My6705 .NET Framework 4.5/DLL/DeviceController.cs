using Advantech.Motion;
using System;

namespace My6705.NET_Framework_4._5
{
    public partial class AxesController
    {
        public static uint GetDeviceNumber(uint deviceType, uint boardID)
        {
            uint deviceNumber = new uint();
            uint actionResult = Motion.mAcm_GetDevNum(deviceType, boardID, ref deviceNumber);
            string errorPrefix = "Open Device";
            CheckAPIError(actionResult, errorPrefix);
            return deviceNumber;
        }

        public static IntPtr InitializeDeviceHandler(uint deviceNumber)
        {
            IntPtr deviceHandler = IntPtr.Zero;
            uint actionResult = Motion.mAcm_DevOpen(deviceNumber, ref deviceHandler);
            string errorPrefix = "Open Device";
            CheckAPIError(actionResult, errorPrefix);
            return deviceHandler;
        }

        public static IntPtr[] InitializeAxesHandler(int axesCount, IntPtr deviceHandler)
        {
            IntPtr[] axesHandler = new IntPtr[axesCount];
            for (int i = 0; i < axesCount; i++)
            {
                uint actionResult = Motion.mAcm_AxOpen(deviceHandler, (UInt16)i, ref axesHandler[i]);
                string errorPrefix = "Open Axis";
                CheckAPIError(actionResult, errorPrefix);
                //Set command and actual position of drivers to start (0-point)        
                Motion.mAcm_AxSetCmdPosition(axesHandler[i], 0);
                Motion.mAcm_AxSetActualPosition(axesHandler[i], 0);
            }
            return axesHandler;
        }

        public static void CloseDevice(ref IntPtr deviceHandler)
        {
            uint actionResult = Motion.mAcm_DevClose(ref deviceHandler);
            string errorPrefix = "Close Board";
            CheckAPIError(actionResult, errorPrefix);
        }

        public static void LoadConfig(IntPtr deviceHandler, string advantechConfigPath)
        {
            uint actionResult = Motion.mAcm_DevLoadConfig(deviceHandler, advantechConfigPath);
            string errorPrefix = "Load Config";
            CheckAPIError(actionResult, errorPrefix);
        }
    }
}

