namespace Web
{
    public class TimeInfoClientSide
    {
        public TimeInfoClientSide(TimeInfo copyFrom)
        {
            Time = copyFrom.time;
            MillisecondsSinceEpoch = copyFrom.milliseconds_since_epoch;
            Date = copyFrom.date;
        }

        public string Time { get; private set; }

        public ulong MillisecondsSinceEpoch { get; private set; }

        public string Date { get; private set; }
    }
}
