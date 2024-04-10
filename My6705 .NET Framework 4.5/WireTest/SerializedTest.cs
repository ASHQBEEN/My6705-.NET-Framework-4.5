using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace My6705.NET_Framework_4._5
{
    public class SerializedTest
    {
        [Name("№")]
        [Index(0)]
        public int TestID { get; set; }
        [Name("Тип")]
        [Index(1)]
        public static string Type { get; set; }
        [Name("Результат")]
        [Index(2)]
        public double TestResult { get; set; }
        [Name("Дата")]
        [Index(3)]
        public DateTime TestDate { get; set; }
        [Name("Показания")]
        [Index(4)]
        public double[] TestValues { get; set; }

        private static int testIDcounter = 1;
        private static List<SerializedTest> bufferTests = new List<SerializedTest>(20);

        public static void ResetTestIDCounter() => testIDcounter = 1;

        private SerializedTest(Test test)
        {
            TestID = testIDcounter++;
            Type =  test.TestNameString;
            TestValues = test.Values.ToArray();
            TestDate = test.testStart;
            TestResult = test.TestResult;
        }

        public static void Serialize(Test[] tests)
        {
            bufferTests.Clear();
            ResetTestIDCounter();
            foreach (var test in tests)
            {
                bufferTests.Add(new SerializedTest(test));
            }
        }

        public static void Save()
        {
            string filePath = $"{DateTime.Now.ToString("dd-MM-yy HH.mm.ss")} {Type}.csv";
            var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = "; ", // Установите разделитель, если он отличается от запятой
                Encoding = System.Text.Encoding.UTF8 // Установите кодировку UTF-8 для поддержки русских символов
            };
            using (var writer = new System.IO.StreamWriter(filePath, false, System.Text.Encoding.UTF8))
            using (var csv = new CsvWriter(writer, config))
            {
                // Записываем заголовки столбцов
                //csv.WriteHeader<SerializedTest>();
                csv.WriteField("№");
                csv.WriteField("Тип");
                csv.WriteField("Результат");
                csv.WriteField("Дата");
                csv.WriteField("Показания");
                csv.NextRecord();
                string valuesString = string.Empty;
                // Записываем данные экземпляров класса
                foreach (var testData in bufferTests)
                {
                    csv.WriteField(testData.TestID);
                    csv.WriteField(Type);
                    csv.WriteField(testData.TestResult);
                    csv.WriteField(testData.TestDate);
                    valuesString = string.Join(", ", testData.TestValues);
                    csv.WriteField(valuesString);
                    csv.NextRecord();
                }
            }
        }

        public static void Load()
        {
            string filePath = string.Empty;

            OpenFileDialog openFileConfig = new OpenFileDialog();
            if (openFileConfig.ShowDialog() == DialogResult.OK)
                filePath = openFileConfig.FileName;
            else return;

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                bufferTests = csv.GetRecords<SerializedTest>().ToList();
            }
        }
    }
}
