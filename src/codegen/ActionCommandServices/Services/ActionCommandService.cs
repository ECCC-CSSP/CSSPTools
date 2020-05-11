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
using ActionCommandServices.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using ActionCommandDBServices.Models;

namespace ActionCommandServices.Services
{
    public class ActionCommandService : ControllerBase, IActionCommandService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; }
        private IActionCommandDBService actionCommandDBService { get; }
        #endregion Properties

        #region Constructors
        public ActionCommandService(IConfiguration configuration, IActionCommandDBService actionCommandDBService)
        {
            this.configuration = configuration;
            this.actionCommandDBService = actionCommandDBService;
        }
        #endregion Constructors

        #region Functions public
        public async Task<ActionResult<ActionCommand>> RunActionCommand(ActionCommand actionCommand)
        {
            try
            {
                actionCommandDBService.ActionCommandID = actionCommand.ActionCommandID;
                actionCommandDBService.Action = actionCommand.Action;
                actionCommandDBService.Command = actionCommand.Command;
                actionCommandDBService.FullFileName = actionCommand.FullFileName;

                //if (!actionCommand.StatusOnly)
                //{
                string exePath = configuration.GetValue<string>("ExecuteDotNetCommandAppPath");
                string args = $" { AppRes.Culture.Name } { actionCommand.Action } { actionCommand.FullFileName }";

                if (string.IsNullOrWhiteSpace(exePath))
                {
                    actionCommandDBService.ErrorText.AppendLine(AppRes.ExePathIsEmpty);
                    actionCommandDBService.PercentCompleted = 0;
                    await actionCommandDBService.Update();
                    return BadRequest(actionCommandDBService.ErrorText.ToString());
                }

                FileInfo fiApp = new FileInfo(exePath);
                if (!fiApp.Exists)
                {
                    actionCommandDBService.ErrorText.AppendLine(string.Format(AppRes.CouldNotFindExePath_, exePath));
                    actionCommandDBService.PercentCompleted = 0;
                    await actionCommandDBService.Update();
                    return BadRequest(actionCommandDBService.ErrorText.ToString());
                }

                Process process = new Process();
                process = Process.Start(exePath, args);

                while (!process.HasExited)
                {
                    // report progress is needed
                }

                actionCommand = await actionCommandDBService.Get();

                if (actionCommand == null)
                {
                    actionCommandDBService.ErrorText.AppendLine(string.Format(AppRes.CouldNotFindCommand_StatusInDB, $"{ actionCommand.Action }:{ actionCommand.FullFileName }"));
                    actionCommandDBService.PercentCompleted = 0;
                    await actionCommandDBService.Update();
                    return BadRequest(actionCommandDBService.ErrorText.ToString());
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(actionCommand.ErrorText))
                    {
                        return Ok(actionCommand);
                    }
                }


                //}
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(AppRes.UnmanagedServerError_, ex.Message));
            }

            return BadRequest(actionCommand.ErrorText);
        }
        public async Task SetCulture(CultureInfo culture)
        {
            await actionCommandDBService.SetCulture(culture);
            AppRes.Culture = culture;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
