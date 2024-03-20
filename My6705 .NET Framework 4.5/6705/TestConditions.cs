using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace My6705.NET_Framework_4._5
{
    public class TestConditions
    {
        private static string jsonPath = $"{nameof(TestConditions)}.json";
        public double[] BreakTestPoint { get; set; }
        public double[] StretchTestPoint { get; set; }
        public double[] ShearTestPoint { get; set; }
        
        public double BreakTestSpeed {  get; set; }
        public double StretchTestSpeed { get; set; }
        public double ShearTestSpeed {  get; set; }


        public TestConditions()
        {
            BreakTestPoint = new double[] { 1500, 1500, 1500 };
            StretchTestPoint = new double[] { 1500, 1500, 1500 };
            ShearTestPoint = new double[] { 1500, 1500, 1500 };
            BreakTestSpeed = 500;
            StretchTestSpeed = 500;
            ShearTestSpeed= 500;
        }

        public void Save()
        {
            BreakTestPoint = BreakTest.TestPoint;
            StretchTestPoint = StretchTest.TestPoint;
            ShearTestPoint = ShearTest.TestPoint;
            BreakTestSpeed = BreakTest.TestSpeed;
            StretchTestSpeed = StretchTest.TestSpeed;
            ShearTestSpeed = ShearTest.TestSpeed;
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

        public void Load()
        {
            try
            {
                string loadedJsonData;
                if (File.Exists(jsonPath))
                {
                    loadedJsonData = File.ReadAllText(jsonPath);
                    var instance = JsonConvert.DeserializeObject<TestConditions>(loadedJsonData);
                    BreakTestPoint = instance.BreakTestPoint;
                    StretchTestPoint = instance.StretchTestPoint;
                    ShearTestPoint = instance.ShearTestPoint;
                    BreakTestSpeed= instance.BreakTestSpeed;
                    StretchTestSpeed= instance.StretchTestSpeed;
                    ShearTestSpeed= instance.ShearTestSpeed;

                    BreakTest.TestPoint = BreakTestPoint;
                    ShearTest.TestPoint = ShearTestPoint;
                    StretchTest.TestPoint = StretchTestPoint;
                    BreakTest.TestSpeed = BreakTestSpeed;
                    ShearTest.TestSpeed = ShearTestSpeed;
                    StretchTest.TestSpeed= StretchTestSpeed;
                }
                else
                {
                    MessageBox.Show($"Файл {jsonPath} не существует. Будут использованы значения по умолчанию.");
                    Save();
                    return;
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибки загрузки
                Console.WriteLine($"Ошибка загрузки из файла: {ex.Message}");
            }
        }
    }
}
