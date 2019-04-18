using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Drawing;

namespace Arduino
{
    class SimpleRGBStripController
    {
        private SerialPort _port = null;


        public SimpleRGBStripController(string comPort, int baudRate, Parity parity, int databits, StopBits stopBits)
        {
            _port = new SerialPort(comPort, baudRate, parity, databits, stopBits);

            // Pulse DTR to reset the device and then wait for ready?
            _port.DtrEnable = true;
            _port.Open();
            string response = _port.ReadLine().Trim();

            if (response != "READY")
            {
                closePort();
                throw new Exception("Unexpected response from controller.");
            }
        }
        public SimpleRGBStripController(string comPort) : this(comPort, 115200, Parity.None, 8, StopBits.One) { }
        ~SimpleRGBStripController()
        {
            closePort();
        }

        private void closePort()
        {
            if (_port != null)
            {
                _port.Close();
                _port = null;
            }
        }

        public void SetColor(Color color)
        {
            string strCmd = String.Format("C {0:6X}\n", color.ToArgb());
            byte[] cmd = ASCIIEncoding.ASCII.GetBytes(strCmd);
            _port.Write(cmd, 0, cmd.Length);
        }
    }
}
