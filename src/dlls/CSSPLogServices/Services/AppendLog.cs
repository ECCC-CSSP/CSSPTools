/*
 * Manually edited
 * 
 */
using Microsoft.AspNetCore.Mvc;
using System;

namespace CSSPLogServices
{
    public partial class CSSPLogService : ControllerBase, ICSSPLogService
    {
        public void AppendLog(string logText)
        {
            Console.WriteLine($"\r{logText}");
            sbLog.AppendLine($"    {logText}");
        }
    }
}
