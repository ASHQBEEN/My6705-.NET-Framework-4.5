using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Advantech.Motion;
using My6705.NET_Framework_4._5;
using Newtonsoft.Json;

public class Machine
{
    private static Machine instance = new Machine
    {
        SlowManipulatorVelocity = new double[] { 500, 500, 500, 500 },
        FastManipulatorVelocity = new double[] { 2000, 2000, 2000, 2000 },
        DriverVelocity = new double[] { 50000, 50000, 50000, 50000 },
        Acceleration = new double[] { 500000, 500000, 500000, 500000 },
        Jerk = new double[] { 0, 0, 0, 0 },
        MaxCoordinate = new double[] { 0, 0, 64000, 0}
    };

    private Machine() { }

    public static Machine Instance
    {
        get => instance;
        set => instance = value;
    }

    public double[] LowVelocity { get; set; } = { 10, 10, 10, 10 };
    public double[] SlowManipulatorVelocity { get; set; }
    public double[] FastManipulatorVelocity { get; set; }
    public double[] DriverVelocity { get; set; }
    public double[] Acceleration { get; set; }
    public double[] Jerk { get; set; }
    public double[] MaxCoordinate { get; set; }
    public static readonly string ParametersFilePath = $"{nameof(Machine)}.json";
    public static readonly Board b = new Board((uint)DevTypeID.PCI1245, 0, 4);
    //*Для рефакторинга
    //Если придётся делать интерполяцию для нескольких плат
    //сделать потоки нестатичными и присваивать их инстансу
    public static bool InterpolaionIsActive { get; set; } = false;


    public static void SaveMachineParameters()
    {
        try
        {
            string jsonData = JsonConvert.SerializeObject(Instance, Formatting.Indented);
            File.WriteAllText(ParametersFilePath, jsonData);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving to JSON file: {ex.Message}");
        }
    }

    public static void LoadMachineParameters()
    {
        try
        {
            string loadedJsonData = File.ReadAllText(ParametersFilePath);
            Instance = JsonConvert.DeserializeObject<Machine>(loadedJsonData);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading from JSON file: {ex.Message}\n" +
                $"Скорее всего вы ещё не сохраняли параметры установки");
            return;
        }
    }
}
