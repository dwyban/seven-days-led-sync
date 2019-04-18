using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Arduino;

namespace SevenDaysLightSync
{
    class LightSync
    {
        // Private Fields
        //---------------
        private SimpleRGBStripController _leds = null;

        private SevenDaysTelnetClient _server = null;
        private bool _syncedWithServer = false;

        private double _gameTimeCurrentMins = 0.0;
        private bool _gameTimeRunning = false;
        private double _gameTimeStartedMins = Double.NaN;
        private DateTime _timeStartedReal;
        private double _gameDayNightLengthMinutes = 60;  // Length of one day in game in real life minutes
        private double _gameDayLightLength = 18;        // Length of daylight hours in in game hours
        private double _gameMinuteLengthInRealSeconds = Double.NaN;

        private LightingTable _lightTable = null;
        private Color _currentColor = Color.Black;

        private System.Timers.Timer _updateTimer;

        // Public Properties
        //------------------
        public Color CurrentColor
        {
            get { return _currentColor; }
        }
        /// <summary>
        /// The length of a single day in game in real minutes.  Default 60
        /// </summary>
        public int GameDayNightLength
        { 
            get { return (int)_gameDayNightLengthMinutes; }
            set
            {
                _gameDayNightLengthMinutes = value;
                _gameMinuteLengthInRealSeconds = 1440 / (_gameDayNightLengthMinutes * 60);
            }
        }
        /// <summary>
        /// The number of hours of daylight per day in game.  Default 18
        /// </summary>
        public int GameDayLightLength
        {
            get { return (int)_gameDayLightLength; }
            set { _gameDayLightLength = value; }
        }

        public double GameTimeMinutes
        {
            get { return _gameTimeCurrentMins; }
            set
            {
                _gameTimeCurrentMins = value;
            }
        }
        /// <summary>
        /// The current day in game
        /// </summary>
        public int GameDay
        {
            get
            {
                return (int)Math.Truncate(_gameTimeCurrentMins / 1440.0); // 1440 minutes per day so divide game time in minutes by 1440
            }
        }
        /// <summary>
        /// The current hour in game
        /// </summary>
        public int GameHour
        {
            get
            {
                double gameDay = _gameTimeCurrentMins / 1440;
                return (int)Math.Truncate( (gameDay - Math.Truncate(gameDay)) * 24);
            }
        }
        /// <summary>
        /// The current minute in game
        /// </summary>
        public int GameMinute
        {
            get
            {
                double gameDay = _gameTimeCurrentMins / 1440;
                return (int)Math.Truncate((((gameDay - Math.Truncate(gameDay)) * 24) - GameHour) * 60);
            }
        }

        public LightingTable LightingTable
        {
            get { return _lightTable; }
        }

        public bool SyncronizedWithServer
        { get { return _syncedWithServer; } }
        

        // Constructors / Destructors
        //---------------------------
        public LightSync(SimpleRGBStripController controller)
        {
            // 60 game minutes per game hour * 24 game hour per game day = 1440 game minute per game day
            // 1440 game minutes per game day / (60 real minutes per game day * 60 real seconds per real minute)
            // 1440 game minutes per game day / 3600 real seconds per game day
            // 1440 gMin/gDay / (_gameDayNightLengthMinutes rMin/gDay * 60 rSec/rMin)
            // 0.4 game minutes per real second at the default 60 real minutes per game day
            _gameMinuteLengthInRealSeconds = 1440 / (_gameDayNightLengthMinutes * 60);

            _updateTimer = new System.Timers.Timer(25);
            _updateTimer.AutoReset = true;
            _updateTimer.Elapsed += _updateTimer_Elapsed;


            // Populate the DaytimeColor lookup table
            _lightTable = LightingTable.GetDefaultLightingTable((int)_gameDayLightLength);


            _leds = controller;

            if (_leds != null)
            {
                _leds.SetColor(Color.White);
                System.Threading.Thread.Sleep(200);
                _leds.SetColor(Color.Black);
                System.Threading.Thread.Sleep(200);
                _leds.SetColor(Color.White);
                System.Threading.Thread.Sleep(200);
                _leds.SetColor(Color.Black);

                // 
                //_leds.SetColor(_lightTable.GetLightingColor(_gameTimeCurrentMins));
            }
        }
        public LightSync() : this(null) { }
        
        ~LightSync()
        {
            if (_syncedWithServer)
                this.StopSync();
        }


        // Public Methods
        //---------------
        /// <summary>
        /// Synchronizes the color displayed on the LED controller with the game time of the server.
        /// </summary>
        /// <param name="server">A valid Seven Days Telnet Client</param>
        public void StartSync(SevenDaysTelnetClient server)
        {
            _updateTimer.Stop();
            _syncedWithServer = true; // Move to end?
            _server = server;

            // Fetch game time parameters fom server. i.e. GameDayLength, GameDayLightLength
            var prefs = _server.GetGamePrefs();
            _gameDayNightLengthMinutes = prefs.DayNightLength;
            _gameDayLightLength = prefs.DayLightLength;

            // Get a new default lighting table based on the server's day light length
            _lightTable = LightingTable.GetDefaultLightingTable(Convert.ToInt32(_gameDayLightLength));

            // Fetch num players from server.
            List<string> playerList = _server.ListPlayers();

            //   If num players > 0 then time is running
            if (playerList.Count > 0)
                _gameTimeRunning = true;

            // Fetch game time from server
            SevenDaysGameTime gt = _server.GetTime();
            _gameTimeCurrentMins = SevenDays.CalcGameTimeMinutes(gt);

            // TODO: Subscribe to player joined event?

            // TODO: Subscribe to player left event?
            

            if (_gameTimeRunning)
            {
                _timeStartedReal = DateTime.Now;
                _gameTimeStartedMins = _gameTimeCurrentMins;
                _updateTimer.Start();
            }
        }

        /// <summary>
        /// Stops synchronizing with the server and goes back to manual control
        /// </summary>
        public void StopSync()
        {
            if (_syncedWithServer)
                throw new ApplicationException("Cannot Stop sync.  Not synced with server.");

            _updateTimer.Stop();
            _server = null;
            _syncedWithServer = false;
        }


        /// <summary>
        /// Starts time running manually.  For use when not synchronized with a server.
        /// </summary>
        public void StartTime()
        {
            if (_syncedWithServer)
                throw new ApplicationException("Cannot Start/Stop time manually while synced with server.");

            _timeStartedReal = DateTime.Now;
            _gameTimeStartedMins = _gameTimeCurrentMins;
            _updateTimer.Start();
            _gameTimeRunning = true; // Manually start the game time
        }

        /// <summary>
        /// Stops time running manually.  For use when not synchronized with a server.
        /// </summary>
        public void StopTime()
        {
            if (_syncedWithServer)
                throw new ApplicationException("Cannot Start/Stop time manually while synced with server.");

            _updateTimer.Stop();
            _gameTimeRunning = false;
        }

        // Public Events
        //--------------
        public event EventHandler<SevenDaysLightSyncEventArgs> LightColorChanged;
        public event EventHandler<EventArgs> TimeUpdated;

        // Private Methods
        //----------------
        private void _updateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_gameTimeRunning) // or if player count > 0
            {
                // Calc how much real-time has passed since start
                TimeSpan tDiffReal = DateTime.Now - _timeStartedReal;

                // Calc in game time diff from real-time diff
                // In game time change in gme minutes = real time change in real seconds * length of game minute per real second
                double tDiffInGameMins = tDiffReal.TotalSeconds * _gameMinuteLengthInRealSeconds;

                // Add the in game time difference since game time start
                _gameTimeCurrentMins = _gameTimeStartedMins + tDiffInGameMins;

                // Update LED color based on time of day
                Color nextColor = _lightTable.GetLightingColor(_gameTimeCurrentMins);
                if (nextColor != _currentColor)
                {
                    //_leds.SetColor(nextColor);
                    _currentColor = nextColor;

                    LightColorChanged?.Invoke(this, new SevenDaysLightSyncEventArgs(nextColor));
                }
                TimeUpdated?.Invoke(this, new EventArgs());
            }
            // Else time is not advancing so do nothing
            // Note: Timer should be stopped so this shouldn't be getting called
        }

    }

    public class SevenDaysLightSyncEventArgs : EventArgs
    {
        public Color LightColor { get; }
        public SevenDaysLightSyncEventArgs(Color color)
        {
            this.LightColor = color;
        }
    }
}
