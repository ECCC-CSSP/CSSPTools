using CSSPCodeGenWebAPI.Models;
using CSSPCodeGenWebAPI.Services.Resources;
using GenerateCodeStatusDB.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPCodeGenWebAPI.Services
{
    public class DotNetService : IDotNetService
    {
        #region Variables
        private readonly IConfiguration configuration;
        private readonly IGenerateCodeStatusDBService generateCodeStatusDBService;
        #endregion Variables

        #region Properties
        private DotNetCommand dotNetCommand { get; set; }
        #endregion Properties

        #region Constructors
        public DotNetService(IConfiguration configuration, IGenerateCodeStatusDBService generateCodeStatusDBService)
        {
            this.configuration = configuration;
            this.generateCodeStatusDBService = generateCodeStatusDBService;
        }
        #endregion Constructors

        #region Functions public
        public async Task DotNet(DotNetCommand dotNetCommand)
        {
            try
            {
                ServicesRes.Culture = generateCodeStatusDBService.Culture;

                string exePath = configuration.GetValue<string>("ExecuteDotNetCommandAppPath");
                string args = $" { dotNetCommand.CultureName } { dotNetCommand.Action } { dotNetCommand.SolutionFileName }";

                if (string.IsNullOrWhiteSpace(exePath))
                {
                    generateCodeStatusDBService.Error.AppendLine(ServicesRes.ExePathIsEmpty);
                    return;
                }

                FileInfo fiApp = new FileInfo(exePath);
                if (!fiApp.Exists)
                {
                    generateCodeStatusDBService.Error.AppendLine(String.Format(ServicesRes.CouldNotFindExePath_, exePath));
                    return;
                }

                Process process = new Process();
                process = Process.Start(exePath, args);

                while (!process.HasExited)
                {
                    // report progress is needed
                }
            }
            catch (Exception ex)
            {
                generateCodeStatusDBService.Error.AppendLine(String.Format(ServicesRes.UnmanagedServerError_, ex.Message));
                return;
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
