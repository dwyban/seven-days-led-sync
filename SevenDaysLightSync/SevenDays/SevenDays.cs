using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenDaysLightSync
{
    public static class SevenDays
    {
        public const double MINUTES_PER_HOUR = 60;
        public const double MINUTES_PER_DAY = 1440;
        public const double MINUTES_PER_WEEK = MINUTES_PER_DAY * 7;
        public const double BLOOD_MOON_START_TIME_NORMALIZED = 22 * MINUTES_PER_HOUR;
        public const double BLOOD_MOON_STOP_TIME_NORMALIZED = 1 * MINUTES_PER_DAY + 4 * MINUTES_PER_HOUR;

        public static double CalcGameTimeMinutes(int day, int hours, int minutes)
        {
            return Convert.ToDouble(day) * MINUTES_PER_DAY +
                Convert.ToDouble(hours) * MINUTES_PER_HOUR +
                Convert.ToDouble(minutes);
        }
        public static double CalcGameTimeMinutes(SevenDaysGameTime gameTime)
        {
            return CalcGameTimeMinutes(gameTime.Day, gameTime.Hour, gameTime.Minute);
        }
    }

    // Structs
    //========
    public struct SevenDaysGameTime
    {
        public int Day;
        public int Hour;
        public int Minute;

        public double ToMinutes()
        {
            return Day * SevenDays.MINUTES_PER_DAY + Hour * SevenDays.MINUTES_PER_HOUR + Minute;
        }

        public static SevenDaysGameTime FromGameTimeMinutes(double gameTimeMinutes)
        {
            SevenDaysGameTime gt = new SevenDaysGameTime();
            gt.Day = (int)Math.Truncate(gameTimeMinutes / SevenDays.MINUTES_PER_DAY);
            double gameDay = gameTimeMinutes / SevenDays.MINUTES_PER_DAY;
            gt.Hour = (int)Math.Truncate((gameDay - Math.Truncate(gameDay)) * 24);
            gt.Minute = (int)Math.Truncate((((gameDay - Math.Truncate(gameDay)) * 24) - gt.Hour) * 60);
            return gt;
        }

        public override string ToString()
        {
            return $"Day: {this.Day:d}, {this.Hour:d2}:{this.Minute:d2}";
        }
    }
}
