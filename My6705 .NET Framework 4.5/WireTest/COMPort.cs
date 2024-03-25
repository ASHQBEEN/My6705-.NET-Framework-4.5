using System;
using System.Globalization;
using System.IO.Ports;
using System.Linq;

namespace My6705.NET_Framework_4._5
{
    public class COMPort
    {
        public bool IsOpen { get { return port.IsOpen; } }
        public double TestValue { get; private set; }
        public string PortName { set { port.PortName = value; } }
        private readonly SerialPort port = new SerialPort();
        private string receivedStringValue;

        public COMPort()
        {
            port.BaudRate = 115200;
            port.Parity = Parity.None;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.DataReceived += DataReceivedEvent;
        }

        public void Open() 
        {
            port.Open(); 
        }

        public void Close()
        {
            port.Close();
            //stayTimeStart = Environment.TickCount;
        }

        private void DataReceivedEvent(object sender, SerialDataReceivedEventArgs e)
        {
            // If the com port has been closed, do nothing
            if (!IsOpen) return;

            // Read all the data waiting in the buffer
            receivedStringValue = port.ReadLine();
            TestValue = double.Parse(receivedStringValue, CultureInfo.InvariantCulture);
            TestValue = Math.Round(TestValue, 1);
        }

        public string GetLastPortName()
        {
            int num;
            return SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray().Last();
        }
    }
}
