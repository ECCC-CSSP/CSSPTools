using Microsoft.Extensions.Primitives;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandDBServices.Services
{
    public partial class ActionCommandDBService : ControllerBase, IActionCommandDBService
    {
        public async Task ConsoleWriteEnd()
        {
            ExecutionStatusText.AppendLine("");
            ExecutionStatusText.AppendLine($"{ ActionCommandDBServicesRes.Done } ...");
            ExecutionStatusText.AppendLine("");
            PercentCompleted = 100;
            await Update();

            Console.WriteLine(ErrorText.ToString());
            Console.WriteLine(ExecutionStatusText.ToString());
        }
        public async Task ConsoleWriteError(string errMessage)
        {
            ErrorText.AppendLine(errMessage);
            PercentCompleted = 0;
            await Update();
            Console.WriteLine(ErrorText.ToString());
            Console.WriteLine(ExecutionStatusText.ToString());
        }
        public async Task ConsoleWriteStart()
        {
            ExecutionStatusText.AppendLine($"{ ActionCommandDBServicesRes.Running } { ActionCommandDBServicesRes.Application } { AppDomain.CurrentDomain.FriendlyName }");
            ExecutionStatusText.AppendLine("");
            ExecutionStatusText.AppendLine($"{ ActionCommandDBServicesRes.Starting } ...");
            ExecutionStatusText.AppendLine("");
            PercentCompleted = 100;
            Console.WriteLine($"{ ActionCommandDBServicesRes.Running } { ActionCommandDBServicesRes.Application } { AppDomain.CurrentDomain.FriendlyName }");
            Console.WriteLine("");
            Console.WriteLine($"{ ActionCommandDBServicesRes.Starting } ...");
            Console.WriteLine("");
        }
    }
}
