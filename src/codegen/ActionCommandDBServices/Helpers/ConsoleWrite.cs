using CSSPCultureServices.Resources;
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
            ExecutionStatusText.AppendLine($"{ CSSPCultureServicesRes.Done } ...");
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
            ErrorText.AppendLine(CSSPCultureServicesRes.AbnormalCompletion);
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
            ExecutionStatusText.AppendLine($"{ CSSPCultureServicesRes.Running } { CSSPCultureServicesRes.Application } { AppDomain.CurrentDomain.FriendlyName }");
            ExecutionStatusText.AppendLine("");
            ExecutionStatusText.AppendLine($"{ CSSPCultureServicesRes.Starting } ...");
            ExecutionStatusText.AppendLine("");
            PercentCompleted = 0;
            await Update();

            if (!Console.IsOutputRedirected)
            {
                Console.Clear();
            }
            Console.WriteLine($"{ CSSPCultureServicesRes.Running } { CSSPCultureServicesRes.Application } { AppDomain.CurrentDomain.FriendlyName }");
            Console.WriteLine("");
            Console.WriteLine($"{ CSSPCultureServicesRes.Starting } ...");
            Console.WriteLine("");
        }
    }
}
