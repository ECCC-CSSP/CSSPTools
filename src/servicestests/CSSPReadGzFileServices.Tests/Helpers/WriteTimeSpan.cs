namespace CSSPReadGzFileServices.Tests;

public partial class CSSPReadGzFileServiceTests
{
    private void WriteTimeSpan(WebTypeEnum webTypeEnum)
    {
        DateTime NewTime = DateTime.Now;

        TimeSpan ts = new TimeSpan(NewTime.Ticks - LastTime.Ticks);

        Process proc = Process.GetCurrentProcess();

        Console.WriteLine($"{ webTypeEnum } --- { ts.TotalSeconds } --- { proc.PrivateMemorySize64 / (1024 * 1024) } MB");
        LastTime = DateTime.Now;

    }
}

