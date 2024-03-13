using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace My6705.NET_Framework_4._5
{
    public class TestPosition
    {
        public static string jsonPath = $"{nameof(TestPosition)}.json";
        public double[] Break { get; set; }
        public double[] Stretch { get; set; }
        public double[] Shear { get; set; }

        public TestPosition()
        {
            Break = new double[] { 1500, 1500, 1500 };
            Stretch = new double[] { 1500, 1500, 1500 };
            Shear = new double[] { 1500, 1500, 1500 };
        }

        public void SaveTestPostitions()
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
                SaveTestPostitions();
                return;
            }

            var instance = JsonConvert.DeserializeObject<TestPosition>(loadedJsonData);
            Break = instance.Break;
            Stretch = instance.Stretch;
            Shear = instance.Shear;
        }
    }
}
