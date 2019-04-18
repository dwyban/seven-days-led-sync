using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SevenDaysLightSync
{
    public class LightingTable
    {
        private SortedList<double, LightingValue> _lightingTable;

        /// <summary>
        /// Constructs the object with a pre-defined table size
        /// </summary>
        /// <param name="capacity">Sets the inital capacity of the table</param>
        public LightingTable(int capacity)
        {
            _lightingTable = new SortedList<double, LightingValue>(capacity);
        }
        
        /// <summary>
        /// The default constructor for the object
        /// </summary>
        public LightingTable() : this(2) { }

        public ICollection<KeyValuePair<double, LightingValue>> Entries
        {
            get => this._lightingTable as ICollection<KeyValuePair<double, LightingValue>>;
        }

        /// <summary>
        /// Gets the default lighting table for the day/night cycle
        /// </summary>
        /// <param name="dayLightLength">Sets the length of the day (in hours) before it turns night.</param>
        /// <returns>A SevenDaysLightingTable that is preloaded with the default lighting colors</returns>
        public static LightingTable GetDefaultLightingTable(int dayLightLength)
        {
            // NOTE: Rumor is that the dayLightLength does not actually effect when it starts getting bright,
            // but rather only affects when the zombies top running so this parameter may not be necessary for a default lighting table

            // Create the default table that matches in game lighting most closely
            // TODO: Keep tweaking this until we get a good table
            LightingTable table = new LightingTable(7);
            table.AddEntry(SevenDays.CalcGameTimeMinutes(0, 1, 00), Color.DarkBlue, Color.DarkRed);
            table.AddEntry(SevenDays.CalcGameTimeMinutes(0, 3, 50), Color.Blue, Color.Red);
            table.AddEntry(SevenDays.CalcGameTimeMinutes(0, 4, 10), Color.Yellow, Color.Yellow);
            table.AddEntry(SevenDays.CalcGameTimeMinutes(0, 13, 0), Color.LightYellow, Color.LightYellow);
            table.AddEntry(SevenDays.CalcGameTimeMinutes(0, 21, 50), Color.Yellow, Color.Yellow);
            table.AddEntry(SevenDays.CalcGameTimeMinutes(0, 22, 10), Color.OrangeRed, Color.OrangeRed);
            //table.AddEntry(SevenDays.CalcGameTimeMinutes(0, 23, 59), Color.DarkBlue, Color.DarkRed);
            return table;
        }

        /// <summary>
        /// Adds an entry to the lighting table
        /// </summary>
        /// <param name="dayTimeMinutes">The time of day in minutes normalized to day 0</param>
        /// <param name="normalColor">The color of the light at the time of day</param>
        /// <param name="hordeNightColor">The color of the light at the time of day when the blood moon is out</param>
        public void AddEntry(double dayTimeMinutes, Color normalColor, Color bloodMoonColor)
        {
            if (dayTimeMinutes < 0 || dayTimeMinutes >= 1440)
                throw new ArgumentOutOfRangeException("dayTimeMiutes", "Value must be >= 0 and less than 1440");

            LightingValue temp = new LightingValue(normalColor, bloodMoonColor);
            _lightingTable.Add(dayTimeMinutes, temp);
        }

        public void ClearTable()
        {
            _lightingTable.Clear();
        }

        /// <summary>
        /// Gets the lighting table entry at index
        /// </summary>
        /// <param name="index">The index of the table entry to get</param>
        /// <returns>A lighting table entry</returns>
        public KeyValuePair<double, LightingValue> this[int index]
        {
            get
            {
                return _lightingTable.ElementAt(index);
            }
        }

        /// <summary>
        /// Gets the number of entries in the lighting table
        /// </summary>
        public int EntryCount
        { get { return _lightingTable.Count; } }

        /// <summary>
        /// Calculates the correct color of the light at the given time of day based on the entries in the lighting table
        /// </summary>
        /// <param name="gameTimeMinutes">The current game time in minutes</param>
        /// <returns>The calculated color of light at the current time of day</returns>
        public Color GetLightingColor(double gameTimeMinutes)
        {
            //return Color.Red;
            // When looking up where the current time sits in the time/color table you need to find the
            // entry at t < current time and the entry at t > current time and do the interpolation between them

            if (_lightingTable.Count < 2)
                throw new ApplicationException("Lighting table must contain at least 2 entries");

            // Is it horde night? Every seventh day from 4AM to 4AM the 8th day
            double gameTimeMinutesNormalizedToWeek = gameTimeMinutes - Math.Floor(gameTimeMinutes / SevenDays.MINUTES_PER_WEEK) * SevenDays.MINUTES_PER_WEEK;
            bool isHordeNight = (gameTimeMinutesNormalizedToWeek > SevenDays.BLOOD_MOON_START_TIME_NORMALIZED) &&
                (gameTimeMinutesNormalizedToWeek < SevenDays.BLOOD_MOON_STOP_TIME_NORMALIZED);
            // TODO: Horde night start/stop are fixed currently.  Need to make these variables and calculate based on DayLight Length.

            // Normalize the game time to the time of day
            double gameTimeMinutesNormalizedToDay = gameTimeMinutes - Math.Floor(gameTimeMinutes / SevenDays.MINUTES_PER_DAY) * SevenDays.MINUTES_PER_DAY; // 1440 minutes per day

            // Find the entries in the table that are before and after the normalized to day 0 game time
            KeyValuePair<double, LightingValue> prev = fetchPrevEntryFromTable(gameTimeMinutesNormalizedToDay);
            KeyValuePair<double, LightingValue> next = fetchNextEntryFromTable(gameTimeMinutesNormalizedToDay);

            // If the time of the next entry is before the time of the previous entry then it means
            // it happens the next day need to add a day worth of minutes to it for the fade calc to work properly
            double nextTime = (next.Key < prev.Key) ? next.Key + SevenDays.MINUTES_PER_DAY : next.Key;
            double prevTime = prev.Key;
            double fadeLength = nextTime - prevTime;
            // If the normalized game time is less than the found prev entry then need to add a day to the normalized time to figure out where we are in the fade
            double fadePos = ((gameTimeMinutesNormalizedToDay < prevTime ?
                gameTimeMinutesNormalizedToDay + SevenDays.MINUTES_PER_DAY :
                gameTimeMinutesNormalizedToDay) - prev.Key)
                / fadeLength;

            
            if (isHordeNight) // if horde night then return a horde night color
                return CalcFadeColor(prev.Value.BloodMoon, next.Value.BloodMoon, fadePos);
            else
                return CalcFadeColor(prev.Value.Normal, next.Value.Normal, fadePos);
        }

        /// <summary>
        /// Finds the entry in the table that is immediately before the current time of day
        /// </summary>
        /// <param name="timeOfDayMins">The current time of day in minutes normalized to day 0</param>
        /// <returns>The table entry who's time is immediately before the current time of day</returns>
        private KeyValuePair<double, LightingValue> fetchPrevEntryFromTable(double timeOfDayMins)
        {
            for (int i = 0; i < _lightingTable.Count; i++)
            {
                if (_lightingTable.ElementAt(i).Key > timeOfDayMins)
                {
                    // If the first element in the table is already at time greater than the current time
                    if (i == 0) // Then return the last element in the table as that would be from the day before and is thus the previous entry
                        return _lightingTable.Last();
                    else
                        return _lightingTable.ElementAt(i - 1);
                }
            }
            // If the loop exited then none of the entries in the table have a time after the current time so return the last entry in the table
            return _lightingTable.Last();
        }

        /// <summary>
        /// Finds the first entry in the table that is immediately after the current time of day
        /// </summary>
        /// <param name="timeOfDayMins">The current time of day in minutes normalized to day 0</param>
        /// <returns>The table entry who's time is equal to or immediately after the current time of day</returns>
        private KeyValuePair<double, LightingValue> fetchNextEntryFromTable(double timeOfDayMins)
        {
            for (int i = 0; i < _lightingTable.Count; i++)
            {
                // Return as soon as an entry is found with time >= to current time
                if (_lightingTable.ElementAt(i).Key >= timeOfDayMins)
                {
                    return _lightingTable.ElementAt(i);
                }
            }
            // If the loop exited then none of the entries in the table have a time after the current
            // time so return the first entry in the table as it corresponds to the first entry of next day
            return _lightingTable.First();
        }

        /// <summary>
        /// Calculates the proper color in the color fade given the current position in the fade
        /// </summary>
        /// <param name="startColor">The color at the start of the fade</param>
        /// <param name="endColor">The color at the end of the fade</param>
        /// <param name="fadePosition">The current position in the fade.  Value must be between 0 and 1</param>
        /// <returns>The fade color at the given fade position</returns>
        public static Color CalcFadeColor(Color startColor, Color endColor, double fadePosition)
        {
            int R = Convert.ToInt32((1 - fadePosition) * Convert.ToDouble(startColor.R) + fadePosition * Convert.ToDouble(endColor.R));
            int G = Convert.ToInt32((1 - fadePosition) * Convert.ToDouble(startColor.G) + fadePosition * Convert.ToDouble(endColor.G));
            int B = Convert.ToInt32((1 - fadePosition) * Convert.ToDouble(startColor.B) + fadePosition * Convert.ToDouble(endColor.B));
            return Color.FromArgb(R, G, B);
        }
    }

    public struct LightingValue
    {
        public Color Normal;
        public Color BloodMoon;

        public LightingValue(Color normalColor, Color bloodMoonColor)
        {
            this.Normal = normalColor;
            this.BloodMoon = bloodMoonColor;
        }
    }
}