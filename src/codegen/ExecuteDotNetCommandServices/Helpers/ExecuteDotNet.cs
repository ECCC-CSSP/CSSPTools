using ConfigServices.Services;
using CSSPCultureServices.Resources;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace ExecuteDotNetCommandServices.Services
{
    public partial class ExecuteDotNetCommandService : IExecuteDotNetCommandService
    {
        private async Task<bool> ExecuteDotNet()
        {
            ActionCommandDBService.ExecutionStatusText.AppendLine("ExecuteDotNet Starting...");
            ActionCommandDBService.ExecutionStatusText.AppendLine("");
            ActionCommandDBService.ExecutionStatusText.AppendLine($"args = { dotNetCommand.CultureName }  { dotNetCommand.Action } { dotNetCommand.Command }");
            ActionCommandDBService.ExecutionStatusText.AppendLine("");
            ActionCommandDBService.PercentCompleted = 0;
            await ActionCommandDBService.Update();


            string FileName = Config.GetValue<string>($"{ dotNetCommand.Action }:{ dotNetCommand.Command }");

            string LogFileName = "DotNetCommandLog.txt";
            FileInfo fi = new FileInfo(FileName);
            string currentDirectory = Directory.GetCurrentDirectory();

            if (!fi.Exists)
            {
                ActionCommandDBService.ErrorText.AppendLine($"{ string.Format(CSSPCultureServicesRes.CouldNotFindSolutionFile_ToCompile, fi.FullName) }");
                return await Task.FromResult(false);
            }

            DirectoryInfo di = fi.Directory;
            if (!di.Exists)
            {
                ActionCommandDBService.ErrorText.AppendLine($"{ string.Format(CSSPCultureServicesRes.CouldNotFindDirectoryOfSolutionFile_, fi.Directory) }");
                return await Task.FromResult(false);
            }

            Directory.SetCurrentDirectory(di.FullName);

            string command = $"dotnet";
            string FullPathLogFileName = Directory.GetCurrentDirectory() + "\\" + LogFileName;
            string arg = $" { dotNetCommand.Action } /flp:v=m; /flp:logfile={ LogFileName }";
            if (dotNetCommand.Action == "run")
            {
                command = fi.Name;
                arg = $"{ dotNetCommand.CultureName }";
            }

            Process process = new Process();
            process = Process.Start($"{ command }", $" { arg }");
            process.WaitForExit();

            if (dotNetCommand.Action == "build" || dotNetCommand.Action == "test")
            {
                string dllOrExeFileName = di.FullName.Substring(0, di.FullName.LastIndexOf("\\")) + @"\_package\netcoreapp3.1\" + dotNetCommand.Command + ".dll";
                if (dotNetCommand.Command.EndsWith("Services"))
                {
                    dllOrExeFileName.Replace(".dll", ".exe");
                }
                FileInfo fiExist = new FileInfo(dllOrExeFileName);
                if (fiExist.Exists)
                {
                    string fileLine = "Last Write Time [" + fiExist.LastWriteTime.ToString("yyyy MMMM dd HH:mm:ss") + "] " + fiExist.FullName;
                    ActionCommandDBService.FilesStatusText.AppendLine(fileLine);
                }
                else
                {
                    string fileLine = "Not Created" + fiExist.FullName;
                    ActionCommandDBService.FilesStatusText.AppendLine(fileLine);
                }
            }

            Directory.SetCurrentDirectory(currentDirectory);

            if (process.ExitCode == (int)ExitCode.Error)
            {
                ActionCommandDBService.ErrorText.AppendLine("");
                ActionCommandDBService.ErrorText.AppendLine($"{ string.Format(CSSPCultureServicesRes.ErrorWhileRunningCommand_UnderDirectory_, command + " " + arg, di.FullName) }");
                return await Task.FromResult(false);
            }

            if (dotNetCommand.Action != "run")
            {
                FileInfo fiLog = new FileInfo(FullPathLogFileName);

                if (!fiLog.Exists)
                {
                    ActionCommandDBService.ErrorText.AppendLine($"{ string.Format(CSSPCultureServicesRes.CouldNotFindFile_, fiLog.FullName) }");
                    return await Task.FromResult(false);
                }

                StreamReader sr = fiLog.OpenText();
                string logText = sr.ReadToEnd();
                sr.Close();

                ActionCommandDBService.ExecutionStatusText.AppendLine($"");
                ActionCommandDBService.ExecutionStatusText.AppendLine($"{ logText }");
                ActionCommandDBService.ExecutionStatusText.AppendLine($"");

                try
                {
                    fiLog.Delete();
                }
                catch (Exception ex)
                {
                    ActionCommandDBService.ErrorText.AppendLine($"{ ex.Message }");
                    return await Task.FromResult(false);
                }
            }

            ActionCommandDBService.ExecutionStatusText.AppendLine("ExecuteDotNet Finished...");

            return await Task.FromResult(true);
        }
    }
}
