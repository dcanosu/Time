namespace Backend;

public class Time
{
    private int _hour;
    private int _millisecond;
    private int _minute;
    private int _second;

    public Time()
    {
        _hour = 0;
        _millisecond = 0;
        _minute = 0;
        _second = 0;
    }

    public Time(int hour)
    {
        Hour = hour;
    }

    public Time(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
    }

    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
    }

    public Time(int hour, int minute, int second, int millisecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
    }

    public int Hour { get => _hour; set => _hour = ValidHour(value); }
    public int Millisecond { get => _millisecond; set => _millisecond = ValidMillisecond(value); }
    public int Minute { get => _minute; set => _minute = ValidMinute(value); }
    public int Second { get => _second; set => _second = ValidSecond(value); }


    private int ValidHour(int hour)
    {
        if (hour < 0 || hour > 23)
            throw new ArgumentOutOfRangeException(nameof(hour), $"The hour: {hour} is not valid.");
        return hour;
    }

    private int ValidMillisecond(int millisecond)
    {
        if (millisecond < 0 || millisecond > 999)
                throw new System.ArgumentOutOfRangeException(nameof(millisecond), $"The millisecond: {millisecond} is not valid.");
        return millisecond;
    }

    private int ValidMinute(int minute)
    {
        if (minute < 0 || minute > 59)
            throw new System.ArgumentOutOfRangeException(nameof(minute), $"The minute: {minute} is not valid.");
        return minute;
    }

    private int ValidSecond(int second)
    {
        if (second < 0 || second > 59)
            throw new System.ArgumentOutOfRangeException(nameof(second), $"The second: {second} is not valid.");
        return second;
    }

    public int ToMilliseconds()
    {
        return (Hour * 3600000) + (Minute * 60000) + (Second * 1000) + Millisecond;
    }

    public int ToSeconds()
    {
        return (Hour * 3600) + (Minute * 60) + Second;
    }

    public int ToMinutes()
    {
        return (Hour * 60) + Minute;
    }

    public bool IsOtherDay(Time time)
    {
        int totalMilliseconds = ToMilliseconds() + time.ToMilliseconds();
        const int millisecondsPerDay = 24 * 60 * 60 * 1000; //24 horas * 60 min * 60 seg * 1000 ms
        return totalMilliseconds >= millisecondsPerDay;
    }

    public Time Add(Time time)
    {
        int totalMilliseconds = ToMilliseconds() + time.ToMilliseconds();
        const int millisecondsPerDay = 24 * 60 * 60 * 1000;        
        totalMilliseconds %= millisecondsPerDay;

        int hour = totalMilliseconds / 3600000;
        totalMilliseconds %= 3600000;

        int minute = totalMilliseconds / 60000;
        totalMilliseconds %= 60000;

        int second = totalMilliseconds / 1000;
        int millisecond = totalMilliseconds % 1000;  

        return new Time(hour, minute, second, millisecond);
    }

    // public Time Add(Time other)
    // {
    //     int ms = this.Millisecond + other.Millisecond;
    //     int carrySec = ms / 1000;
    //     ms %= 1000;

    //     int sec = this.Second + other.Second + carrySec;
    //     int carryMin = sec / 60;
    //     sec %= 60;

    //     int min = this.Minute + other.Minute + carryMin;
    //     int carryHour = min / 60;
    //     min %= 60;

    //     int hour = this.Hour + other.Hour + carryHour;
    //     hour %= 24;

    //     return new Time(hour, min, sec, ms);
    // }

    public override string ToString()
    {
        int hour12;
        string period;

        if (Hour == 0)
        {
            hour12 = 0;
            period = "AM";
        }
        else if (Hour < 12)
        {
            hour12 = Hour;
            period = "AM";
        }
        else if (Hour == 12)
        {
            hour12 = 12;
            period = "PM";
        }
        else
        {
            hour12 = Hour - 12;
            period = "PM";
        }

        return $"{hour12:00}:{Minute:00}:{Second:00}.{Millisecond:000} {period}";
    }

}
