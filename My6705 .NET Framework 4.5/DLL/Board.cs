﻿using Advantech.Motion;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace My6705.NET_Framework_4._5
{
    public class Board
    {
        [JsonIgnore] public readonly string jsonPath;
        [JsonProperty] private uint deviceType = 167;
        [JsonProperty] private uint boardID = 1;
        [JsonProperty] private int axesCount = 4;

        /// <summary>
        /// Количество осей, используемых платой.
        /// </summary>
        [JsonIgnore] public int AxesCount { get { return axesCount; } }

        public double[] LowVelocity { get; set; }
        public double[] SlowVelocity { get; set; }
        public double[] FastVelocity { get; set; }
        public double[] DriverVelocity { get; set; }
        public double[] Acceleration { get; set; }
        public double[] Jerk { get; set; }
        public double[] MaxCoordinate { get; set; }

        private uint deviceNumber;
        private IntPtr[] axesHandler;
        private IntPtr deviceHandler = IntPtr.Zero;

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
        /// <summary>
        /// Конструктор для последующей инициализации платы Advantech и её осей
        /// </summary>
        /// <param name="deviceType">Номер устройства в Advantech.Motion.DevTypeID</param>
        /// <param name="boardID">ID платы в утилите Common Motion Utility</param>
        /// <param name="axesCount">Количество осей, инициализируемых платой</param>
        public void OpenBoard()
        {
            deviceNumber = FetchDeviceNumber(deviceType, boardID);
            deviceHandler = InitializeDeviceHandler();
            axesHandler = InitializeAxesHandler();
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
        public IntPtr this[int axisIndex] { get { return axesHandler[axisIndex]; } }

        public string AdvantechConfigPath { get; set; } = string.Empty;
        public void LoadConfig()
        {
            if (File.Exists(AdvantechConfigPath))
                BoardActionPerformer.PerformBoardAction(() =>
                {
                    return Motion.mAcm_DevLoadConfig(deviceHandler, AdvantechConfigPath);
                },
                "Load Config");
            else MessageBox.Show($"Конфигурационный файл для платы {boardName} не был обнаружен."); 
        }

        public void CloseBoard()
        {
            BoardActionPerformer.PerformBoardAction(() =>
            {
                return Motion.mAcm_DevClose(ref deviceHandler);
            },
            "Close Board");
        }

        public void LoadOverridedConfig()
        {
            LoadConfig();
            //Since Acceleration = Deceleration (requirement)
            AxesController.SetDeceleration(this, Acceleration);
            AxesController.SetLowVelocity(this, LowVelocity);
            AxesController.SetActAcc(this, Acceleration);
            AxesController.SetJerk(this, Jerk);
        }

        private string boardName;
        public Board(string boardName)
        {
            this.boardName = boardName;
            jsonPath = $"{this.boardName}Properties.json";
            LowVelocity = new double[4] { 10, 10, 10, 10 };
            SlowVelocity = new double[4] { 500, 500, 500, 500 };
            FastVelocity = new double[4] { 2000, 2000, 2000, 2000 };
            DriverVelocity = new double[4] { 50000, 50000, 50000, 50000 };
            Acceleration = new double[4] { 1000000, 1000000, 1000000, 1000000 };
            Jerk = new double[4] { 0, 0, 0, 0 };
            MaxCoordinate = new double[4] { 0, 0, 64000, 0 };
        }

        public void SaveBoardProperties()
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(this, Formatting.Indented);
                File.WriteAllText(jsonPath, jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving to JSON file: {ex.Message}");
            }
        }

        public void LoadBoardProperties()
        {
            string loadedJsonData;
            if (File.Exists(jsonPath))
            {
                loadedJsonData = File.ReadAllText(jsonPath);
            }
            else
            {
                MessageBox.Show($"Файл {jsonPath} не существует. Будут использованы значения по умолчанию.");
                SaveBoardProperties();
                return;
            }

            var instance = JsonConvert.DeserializeObject<Board>(loadedJsonData);
            deviceType = instance.deviceType;
            boardID = instance.boardID;
            axesCount = instance.axesCount;
            SlowVelocity = instance.SlowVelocity;
            FastVelocity = instance.FastVelocity;
            DriverVelocity = instance.DriverVelocity;
            Acceleration = instance.Acceleration;
            Jerk = instance.Jerk;
            MaxCoordinate = instance.MaxCoordinate;
            AdvantechConfigPath = instance.AdvantechConfigPath;
        }
    }
}
