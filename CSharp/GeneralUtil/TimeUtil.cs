using System;

namespace GeneralUtil
{
    public static class TimeUtil
    {
        public static bool IsBetweenHours(int beginningHour, int endHour)
        {
            TimeSpan start = new TimeSpan(beginningHour, 0, 0);
            TimeSpan end = new TimeSpan(endHour, 0, 0);
            TimeSpan now = DateTime.Now.TimeOfDay;

            return start <= end ? now >= start && now <= end : now >= start || now <= end;
        }
    }
}
