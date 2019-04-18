using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;

namespace SevenDaysLightSync
{
    class SevenDaysTelnetClient
    {
        private string _hostname = null;
        private int _port = 8081;
        private string _password = null;
        private TcpClient _telnetClient = null;
        private NetworkStream _telnetStream = null;
        private StreamWriter _cmdWriter = null;
        private StreamReader _cmdReader = null;

        public event EventHandler<EventArgs> PlayerJoined;
        public event EventHandler<EventArgs> PlayerLeft;
        public event EventHandler<SevenDaysTelnetClientEventArgs> DataRecieved;

        public bool Connected
        {
            get
            {
                if (_telnetClient != null)
                    return _telnetClient.Connected;
                else
                    return false;
            }
        }
       
        public SevenDaysTelnetClient(string hostname, int port, string password)
        {
            _hostname = String.Copy(hostname);
            _port = port;
        }
        ~SevenDaysTelnetClient()
        {
            closeConnection();
        }

        public void Connect(string password)
        {
            _password = String.Copy(password);

            _telnetClient = new TcpClient(_hostname, _port);
            _telnetStream = _telnetClient.GetStream();
            _cmdReader = new StreamReader(_telnetStream, Encoding.ASCII);
            _cmdWriter = new StreamWriter(_telnetStream, Encoding.ASCII);

            // Look for password prompt and then respond with password
            string temp;
            int retryAttempsLeft = 3;
            temp = _cmdReader.ReadToEnd();
            System.Diagnostics.Debug.Write(temp);
            if (temp.Contains("Please enter password:")) // Then need to login
            {
                while (!temp.Contains("Logon successful.") && retryAttempsLeft > 0)
                {
                    _cmdWriter.WriteLine(_password);
                    temp = _cmdReader.ReadLine();
                    System.Diagnostics.Debug.Write(temp);
                    retryAttempsLeft--;
                }
                if (retryAttempsLeft == 0)
                {
                    System.Diagnostics.Debug.WriteLine("Logon attempt failed. Aborting Logon");
                    throw new ApplicationException("Failed to logon to server.  Password not accepted.");
                }
            }

            // Read lines until end of welcome message
            while (!temp.Contains("Press 'exit' to end session."))
            {
                temp = _cmdReader.ReadLine();
                System.Diagnostics.Debug.Write(temp);
            }

            // At this point the telnet server should be ready to accept commands and will output console messages from the active server
            // TODO: start listening for messages
            //startListening();
        }
        public void Disconnect()
        {
            //stopListening();
            _cmdWriter.WriteLine("exit");
            closeConnection();
        }

        public string ReadLine()
        {
            return _cmdReader.ReadLine();
        }
        public void WriteLine(string buffer)
        {
            _cmdWriter.WriteLine(buffer);
        }

        public SevenDaysGamePrefs GetGamePrefs()
        {
            SevenDaysGamePrefs gp;

            _cmdWriter.WriteLine("gg");
            string response = _cmdReader.ReadToEnd();

            gp.DayLightLength = (int)Double.Parse(findPrefValueStringFrom_gg_Response(response, "GamePref.DayLightLength"));
            gp.DayNightLength = (int)Double.Parse(findPrefValueStringFrom_gg_Response(response, "GamePref.DayNightLength"));
            gp.GameVersion = findPrefValueStringFrom_gg_Response(response, "GamePref.GameVersion");

            return gp;
        }
        /// <summary>
        /// Gets the current time in game from the server
        /// </summary>
        /// <returns></returns>
        public SevenDaysGameTime GetTime()
        {
            _cmdWriter.WriteLine("gettime");
            string temp = _cmdReader.ReadLine();

            // Parse the time from the response
            return new SevenDaysGameTime();

        }
        /// <summary>
        /// Gets a list of players currently connected to the server
        /// </summary>
        /// <returns></returns>
        public List<string> ListPlayers()
        {
            throw new NotImplementedException();
            _cmdWriter.WriteLine("listplayers");

            // Todo: Go through player list returned by server.
            string temp = this.ReadLine();
            return new List<string>();
        }


        // Private Methods
        //----------------
        private void closeConnection()
        {
            if (_telnetClient != null)
            {
                _telnetClient.Close();
                _telnetClient.Dispose();
                _telnetClient = null;
            }
            if (_telnetStream != null)
            {
                _telnetStream.Close();
                _telnetStream.Dispose();
                _telnetStream = null;
            }
            if (_cmdReader != null)
            {
                _cmdReader.Dispose();
                _cmdReader = null;
            }
            if (_cmdWriter != null)
            {
                _cmdWriter.Dispose();
                _cmdWriter = null;
            }
        }

        private string findPrefValueStringFrom_gg_Response(string ggResponse, string prefName)
        {
            int idxStart, idxEnd;
            idxStart = ggResponse.IndexOf(prefName) + prefName.Length + 4;
            idxEnd = ggResponse.IndexOf('\n', idxStart);
            return ggResponse.Substring(idxStart, idxEnd).Trim(); ;
        }


        // Background listener
        //--------------------
        private System.Threading.Thread listenerThread;
        private void startListening()
        {
            _cancelListening = false;
            listenerThread = new System.Threading.Thread(new System.Threading.ThreadStart(listenerThreadMethod));
        }

        private void stopListening()
        {
            _cancelListening = true;

            if (listenerThread != null)
                listenerThread.Join();
        }

        private bool isListening()
        {
            return listenerThread.IsAlive;
        }
        
        private bool _cancelListening = false;
        /// <summary>
        /// Listens for data sent from the server
        /// </summary>
        private void listenerThreadMethod()
        {
            while (!_cancelListening)
            {
                if(_telnetStream.DataAvailable)
                {
                    string temp = _cmdReader.ReadLine();
                    if (temp == null) // No data read
                        continue;

                    // Process line received and react accordingly
                    // For now just fire received event and pass the data in the event
                    DataRecieved?.Invoke(this, new SevenDaysTelnetClientEventArgs(temp));
                }
                else
                {
                    System.Threading.Thread.Yield();
                    System.Threading.Thread.Sleep(10);
                }
            }
        }
    }

    public class SevenDaysTelnetClientEventArgs : EventArgs
    {
        public string Data { get; }

        public SevenDaysTelnetClientEventArgs(string data)
        {
            Data = data;
        }
    }

    public struct SevenDaysGamePrefs
    {
        public string GameVersion;
        public int DayNightLength;
        public int DayLightLength;
    }

    public struct SevenDaysPlayer
    {
        string Name;
        string ID;
        string Location;
        int Health;
        string IPAddress;
    }

}
