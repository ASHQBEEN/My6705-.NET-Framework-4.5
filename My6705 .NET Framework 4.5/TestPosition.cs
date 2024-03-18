using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace My6705.NET_Framework_4._5
{
    public class TestPosition
    {
        private static string jsonPath = $"{nameof(TestPosition)}.json";
        public double[] Break { get; set; }
        public double[] Stretch { get; set; }
        public double[] Shear { get; set; }

        public TestPosition()
        {
            Break = new double[] { 1500, 1500, 1500 };
            Stretch = new double[] { 1500, 1500, 1500 };
            Shear = new double[] { 1500, 1500, 1500 };
        }

        public void Save()
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

        public void Load()
        {
            try
            {
                string loadedJsonData;
                if (File.Exists(jsonPath))
                {
                    loadedJsonData = File.ReadAllText(jsonPath);
                    var instance = JsonConvert.DeserializeObject<TestPosition>(loadedJsonData);
                    Break = instance.Break;
                    Stretch = instance.Stretch;
                    Shear = instance.Shear;
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
