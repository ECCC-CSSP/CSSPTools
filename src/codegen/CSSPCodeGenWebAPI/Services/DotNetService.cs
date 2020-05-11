using CSSPCodeGenWebAPI.Models;
using CSSPCodeGenWebAPI.Services.Resources;
using ActionCommandDBServices.Services;
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
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; }
        #endregion Properties

        #region Constructors
        public DotNetService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion Constructors

        #region Functions public
        public async Task<string> RunDotNetCommand(DotNetCommand dotNetCommand)
        {
            try
            {
                if (!dotNetCommand.StatusOnly)
                {
                    ServicesRes.Culture = new CultureInfo(dotNetCommand.CultureName);

                    string exePath = configuration.GetValue<string>("ExecuteDotNetCommandAppPath");
                    string args = $" { dotNetCommand.CultureName } { dotNetCommand.Action } { dotNetCommand.FileName }";

                    if (string.IsNullOrWhiteSpace(exePath))
                    {
                        return ServicesRes.ExePathIsEmpty;
                    }

                    FileInfo fiApp = new FileInfo(exePath);
                    if (!fiApp.Exists)
                    {
                        return String.Format(ServicesRes.CouldNotFindExePath_, exePath);
                    }

                    Process process = new Process();
                    process = Process.Start(exePath, args);

                    while (!process.HasExited)
                    {
                        // report progress is needed
                    }
                }
            }
            catch (Exception ex)
            {
                return String.Format(ServicesRes.UnmanagedServerError_, ex.Message);
            }

            return "";
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
