using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;


namespace My6705.NET_Framework_4._5
{
    public class ComPort
    {
        SerialPort comPort = new SerialPort();
        double doubleData = new double();
        string strData;
        int stayTime = 0;
        int stayTimeStart = 0;
        int accumulatedStayTime = 0;
        public void SetPortName(string name)
        {
            comPort.PortName = name;
        }
        public ComPort() 
        {
            comPort.BaudRate = 115200;
            comPort.Parity = Parity.None;
            comPort.DataBits = 8;
            comPort.StopBits = StopBits.One;
            comPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);

        }
        public bool ComIsOpen()
        {
            return comPort.IsOpen;
        }
        public string ComReadLine()
        {
            return comPort.ReadLine();
        }
        public void ComClose()
        {
            comPort.Close();
            stayTimeStart = Environment.TickCount;
        }
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // If the com port has been closed, do nothing
            if (!comPort.IsOpen) return;

            // Read all the data waiting in the buffer
            strData = comPort.ReadLine();
            doubleData = double.Parse(strData, CultureInfo.InvariantCulture);
            doubleData = Math.Round(doubleData, 1);

            strData = doubleData.ToString("F1");
        }
        public double getPortGraphDataTicker()
        {
            return doubleData;
        }
        public string getPortDataTicker()
        {
            return strData;
        }
        public void ComOpen()
        {
            comPort.Open();
            
            stayTime = Environment.TickCount - stayTimeStart;
            if (stayTimeStart == 0) return;
            accumulatedStayTime += stayTime;
        }

        public void RefreshComPortList(ComboBox cmb)
        {
            // Determain if the list of com port names has changed since last checked
            string selected = RefreshComPortList(cmb.Items.Cast<string>(), cmb.SelectedItem as string, comPort.IsOpen);

            // If there was an update, then update the control showing the user the list of port names
            if (!String.IsNullOrEmpty(selected))
            {
                cmb.Items.Clear();
                cmb.Items.AddRange(OrderedPortNames());
                cmb.SelectedItem = selected;
            }
        }

        private string[] OrderedPortNames()
        {
            // Just a placeholder for a successful parsing of a string to an integer
            int num;
            // Order the serial port names in numberic order (if possible)
            return SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray();
        }

        private string RefreshComPortList(IEnumerable<string> PreviousPortNames, string CurrentSelection, bool PortOpen)
        {
            // Create a new return report to populate
            string selected = null;

            // Retrieve the list of ports currently mounted by the operating system (sorted by name)
            string[] ports = SerialPort.GetPortNames();

            // First determain if there was a change (any additions or removals)
            bool updated = PreviousPortNames.Except(ports).Count() > 0 || ports.Except(PreviousPortNames).Count() > 0;

            // If there was a change, then select an appropriate default port
            if (updated)
            {
                // Use the correctly ordered set of port names
                ports = OrderedPortNames();

                // Find newest port if one or more were added
                string newest = SerialPort.GetPortNames().Except(PreviousPortNames).OrderBy(a => a).LastOrDefault();

                // If the port was already open... (see logic notes and reasoning in Notes.txt)
                if (PortOpen)
                {
                    if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else selected = ports.LastOrDefault();
                }
                else
                {
                    if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else selected = ports.LastOrDefault();
                }
            }

            // If there was a change to the port list, return the recommended default selection
            return selected;
        }

        public int getStayTime()
        {
            return accumulatedStayTime;
        }

        public void openGraph()
        {
            accumulatedStayTime = 0;
            stayTimeStart = 0;
            stayTime = 0;
            ComGraph comGraph = new ComGraph(this);
            comGraph.Show();
        }
    }
}
