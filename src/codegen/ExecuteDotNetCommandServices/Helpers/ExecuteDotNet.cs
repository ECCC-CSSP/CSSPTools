using ExecuteDotNetCommandServices.Models;
using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Services;
using ValidateAppSettingsServices.Models;
using Microsoft.AspNetCore.Mvc;
using CultureServices.Resources;

namespace ExecuteDotNetCommandServices.Services
{
    public partial class ExecuteDotNetCommandService : IExecuteDotNetCommandService
    {
        private async Task<bool> ExecuteDotNet()
        {
            actionCommandDBService.ExecutionStatusText.AppendLine("ExecuteDotNet Starting...");
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            actionCommandDBService.ExecutionStatusText.AppendLine($"args = { dotNetCommand.CultureName }  { dotNetCommand.Action } { dotNetCommand.Command }");
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            actionCommandDBService.PercentCompleted = 0;
            await actionCommandDBService.Update();


            string FileName = configuration.GetValue<string>($"{ dotNetCommand.Action }:{ dotNetCommand.Command }");

            string LogFileName = "DotNetCommandLog.txt";
            FileInfo fi = new FileInfo(FileName);
            string currentDirectory = Directory.GetCurrentDirectory();

            if (!fi.Exists)
            {
                actionCommandDBService.ErrorText.AppendLine($"{ string.Format(CultureServicesRes.CouldNotFindSolutionFile_ToCompile, fi.FullName) }");
                return await Task.FromResult(false);
            }

            DirectoryInfo di = fi.Directory;
            if (!di.Exists)
            {
                actionCommandDBService.ErrorText.AppendLine($"{ string.Format(CultureServicesRes.CouldNotFindDirectoryOfSolutionFile_, fi.Directory) }");
                return await Task.FromResult(false);
            }

            Directory.SetCurrentDirectory(di.FullName);

            string command = $"dotnet";
            string arg = $" { dotNetCommand.Action } /flp:v=m; /flp:logfile={ LogFileName }";
            if (dotNetCommand.Action == "run")
            {
                command = fi.Name;
                arg = $"{ dotNetCommand.CultureName }";
            }

            Process process = new Process();
            process = Process.Start($"{ command }", $" { arg }");
            process.WaitForExit();

            Directory.SetCurrentDirectory(currentDirectory);

            if (process.ExitCode != 0)
            {
                actionCommandDBService.ErrorText.AppendLine("");
                actionCommandDBService.ErrorText.AppendLine($"{ string.Format(CultureServicesRes.ErrorWhileRunningCommand_UnderDirectory_, command + " " + arg, di.FullName) }");
                return await Task.FromResult(false);
            }

            if (dotNetCommand.Action != "run")
            {
                FileInfo fiLog = new FileInfo(fi.FullName.Replace(fi.Name, LogFileName));

                if (!fiLog.Exists)
                {
                    actionCommandDBService.ErrorText.AppendLine($"{ string.Format(CultureServicesRes.CouldNotFindFile_, fiLog.FullName) }");
                    return await Task.FromResult(false);
                }

                StreamReader sr = fiLog.OpenText();
                string logText = sr.ReadToEnd();
                sr.Close();

                actionCommandDBService.ExecutionStatusText.AppendLine($"");
                actionCommandDBService.ExecutionStatusText.AppendLine($"{ logText }");
                actionCommandDBService.ExecutionStatusText.AppendLine($"");

                try
                {
                    fiLog.Delete();
                }
                catch (Exception ex)
                {
                    actionCommandDBService.ErrorText.AppendLine($"{ ex.Message }");
                    return await Task.FromResult(false);
                }
            }

            actionCommandDBService.ExecutionStatusText.AppendLine("ExecuteDotNet Finished...");

            return await Task.FromResult(true);
        }
    }
}
