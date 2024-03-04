using System;
using System.Globalization;
using System.IO.Ports;

namespace My6705.NET_Framework_4._5
{
    public class COMPort
    {
        public bool IsOpen { get { return port.IsOpen; } }
        private readonly SerialPort port = new SerialPort();
        private string receivedStringValue;
        public double TestValue { get; private set; }

        public COMPort()
        {
            port.BaudRate = 115200;
            port.Parity = Parity.None;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.DataReceived += DataReceivedEvent;
        }

        public void Open() { port.Open(); }

        public string PortName { set { port.PortName = value; } }

        private void DataReceivedEvent(object sender, SerialDataReceivedEventArgs e)
        {
            // If the com port has been closed, do nothing
            if (!port.IsOpen) return;

            // Read all the data waiting in the buffer
            receivedStringValue = port.ReadLine();
            TestValue = double.Parse(receivedStringValue, CultureInfo.InvariantCulture);
            TestValue = Math.Round(TestValue, 1);
        }

        int stayTime = 0;
        int stayTimeStart = 0;
        int accumulatedStayTime = 0;
    }
}
