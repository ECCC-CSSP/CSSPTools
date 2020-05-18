using CultureServices.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ActionCommandDBServices.Services
{
    public partial class ActionCommandDBService : ControllerBase, IActionCommandDBService
    {
        public async Task ConsoleWriteEnd()
        {
            ExecutionStatusText.AppendLine("");
            ExecutionStatusText.AppendLine($"{ CultureServicesRes.Done } ...");
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
            ErrorText.AppendLine(CultureServicesRes.AbnormalCompletion);
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
            ExecutionStatusText.AppendLine($"{ CultureServicesRes.Running } { CultureServicesRes.Application } { AppDomain.CurrentDomain.FriendlyName }");
            ExecutionStatusText.AppendLine("");
            ExecutionStatusText.AppendLine($"{ CultureServicesRes.Starting } ...");
            ExecutionStatusText.AppendLine("");
            PercentCompleted = 0;
            await Update();

            if (!Console.IsOutputRedirected)
            {
                Console.Clear();
            }
            Console.WriteLine($"{ CultureServicesRes.Running } { CultureServicesRes.Application } { AppDomain.CurrentDomain.FriendlyName }");
            Console.WriteLine("");
            Console.WriteLine($"{ CultureServicesRes.Starting } ...");
            Console.WriteLine("");
        }
    }
}
