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
    public class GenerateModelsService : IGenerateModelsService
    {
        #region Variables
        private readonly IConfiguration _configuration;
        private readonly IGenerateCodeStatusDBService _generateCodeStatusDBService;
        #endregion Variables

        #region Constructors
        public GenerateModelsService(IConfiguration configuration, IGenerateCodeStatusDBService generateCodeStatusDBService)
        {
            _configuration = configuration;
            _generateCodeStatusDBService = generateCodeStatusDBService;
        }
        #endregion Constructors

        #region Functions public
        public async Task GenerateModels()
        {
            try
            {
                ServicesRes.Culture = _generateCodeStatusDBService.Culture;

                string exePath = "";
                string args = "";
                switch (_generateCodeStatusDBService.Command)
                {
                    case "Models_ModelClassName_Test":
                    case "ModelsGenerated_b":
                    case "ModelsTestGenerated_c":
                    case "ModelsGenerate_d":
                        {
                            exePath = _configuration.GetValue<string>($"{ _generateCodeStatusDBService.Command }");
                            args = $" { _generateCodeStatusDBService.Culture.Name }";
                        }
                        break;
                    default:
                        {
                            _generateCodeStatusDBService.Error.AppendLine(String.Format(ServicesRes.Command_IsNotImplemented, _generateCodeStatusDBService.Command));
                            await _generateCodeStatusDBService.Update(0);
                            return;
                        }

                }

                if (string.IsNullOrWhiteSpace(exePath))
                {
                    _generateCodeStatusDBService.Error.AppendLine(ServicesRes.ExePathIsEmpty);
                    await _generateCodeStatusDBService.Update(0);
                    return;
                }

                FileInfo fiApp = new FileInfo(exePath);
                if (!fiApp.Exists)
                {
                    _generateCodeStatusDBService.Error.AppendLine(String.Format(ServicesRes.CouldNotFindExePath_, exePath));
                    await _generateCodeStatusDBService.Update(0);
                    return;
                }

                RunApplication(exePath, args);
            }
            catch (Exception ex)
            {
                _generateCodeStatusDBService.Error.AppendLine(String.Format(ServicesRes.UnmanagedServerError_, ex.Message));
                await _generateCodeStatusDBService.Update(0);
                return;
            }

            return;
        }
        #endregion Functions public

        #region Functions private
        private void RunApplication(string exePath, string args)
        {
            // run exePath application
            Process process = new Process();
            process = Process.Start(exePath, args);

            while (!process.HasExited)
            {
                // report progress is needed
            }
        }
        #endregion Functions private
    }
}
