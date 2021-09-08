using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Diagnostics;

namespace CreateGzFileServices.Tests
{
    public partial class CreateGzFileServiceTests
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
}
