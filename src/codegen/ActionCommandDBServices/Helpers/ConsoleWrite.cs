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

            if (!Console.IsOutputRedirected)
            {
                Console.Clear();
            }
            Console.WriteLine(ExecutionStatusText.ToString());
            Console.WriteLine(ErrorText.ToString());
        }
        public async Task ConsoleWriteError(string errMessage)
        {
            ErrorText.AppendLine(errMessage);
            ErrorText.AppendLine("");
            ErrorText.AppendLine(ActionCommandDBServicesRes.AbnormalCompletion);
            ErrorText.AppendLine("");
            PercentCompleted = 0;
            await Update();

            if (!Console.IsOutputRedirected)
            {
                Console.Clear();
            }           
            Console.WriteLine(ExecutionStatusText.ToString());
            Console.WriteLine(ErrorText.ToString());
        }
        public async Task ConsoleWriteStart()
        {
            ExecutionStatusText.AppendLine($"{ ActionCommandDBServicesRes.Running } { ActionCommandDBServicesRes.Application } { AppDomain.CurrentDomain.FriendlyName }");
            ExecutionStatusText.AppendLine("");
            ExecutionStatusText.AppendLine($"{ ActionCommandDBServicesRes.Starting } ...");
            ExecutionStatusText.AppendLine("");
            PercentCompleted = 100;

            if (!Console.IsOutputRedirected)
            {
                Console.Clear();
            }
            Console.WriteLine($"{ ActionCommandDBServicesRes.Running } { ActionCommandDBServicesRes.Application } { AppDomain.CurrentDomain.FriendlyName }");
            Console.WriteLine("");
            Console.WriteLine($"{ ActionCommandDBServicesRes.Starting } ...");
            Console.WriteLine("");
        }
    }
}
