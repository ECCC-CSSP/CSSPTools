using GenerateCodeCompile.Resources;
using GenerateCodeStatusDB.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCodeCompile.Services
{
    public partial class GenerateCodeCompileService : IGenerateCodeCompileService
    {
        #region Variables
        private readonly IConfigurationRoot _configuration;
        private readonly IGenerateCodeStatusDBService _generateCodeStatusDBService;
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public GenerateCodeCompileService(IConfigurationRoot configuration, IGenerateCodeStatusDBService generateCodeStatusDBService)
        {
            _configuration = configuration;
            _generateCodeStatusDBService = generateCodeStatusDBService;
        }
        #endregion Constructors

        #region Events
        #endregion Events

        #region Functions public
        public async Task Compile(string FileNameToCompile)
        {
            string LogFileName = "CompileLog.txt";
            FileInfo fi = new FileInfo(FileNameToCompile);
            string currentDirectory = Directory.GetCurrentDirectory();

            if (!fi.Exists)
            {
                _generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.CouldNotFindSolutionFile_ToCompile, fi.FullName) }");
                return;                 
            }

            DirectoryInfo di = fi.Directory;
            if (!di.Exists)
            {
                _generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.CouldNotFindDirectoryOfSolutionFile_, fi.Directory) }");
                return;
            }

            Directory.SetCurrentDirectory(di.FullName);

            string command = $"dotnet";
            string arg = $" build /flp:v=m; /flp:logfile={ LogFileName }";
            _generateCodeStatusDBService.Status.AppendLine($"{ string.Format(AppRes.RunningCommand_UnderDirectory_, command + arg, di.FullName) }");

            Process process = new Process();
            process = Process.Start($"{ command }", $" { arg }");
            process.WaitForExit();

            FileInfo fiLog = new FileInfo(fi.FullName.Replace(fi.Name, LogFileName));

            if (!fiLog.Exists)
            {
                _generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.CouldNotFindFile_, fiLog.FullName) }");
                return;
            }

            StreamReader sr = fiLog.OpenText();
            string logText = sr.ReadToEnd();
            sr.Close();

            _generateCodeStatusDBService.Status.AppendLine($"");
            _generateCodeStatusDBService.Status.AppendLine($"{ logText }");
            _generateCodeStatusDBService.Status.AppendLine($"");

            try
            {
                fiLog.Delete();
            }
            catch (Exception ex)
            {
                _generateCodeStatusDBService.Error.AppendLine($"{ ex.Message }");
            }

            Directory.SetCurrentDirectory(currentDirectory);

            return;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
