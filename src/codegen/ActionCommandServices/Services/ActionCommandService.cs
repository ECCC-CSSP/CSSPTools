using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using CultureServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

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
        //public async Task<ActionResult<ActionCommand>> RunActionCommand(ActionCommand actionCommand)
        //{
        //    try
        //    {
        //        actionCommandDBService.Action = actionCommand.Action;
        //        actionCommandDBService.Command = actionCommand.Command;

        //        string exePath = configuration.GetValue<string>("ExecuteDotNetCommandAppPath");
        //        string args = $" { CultureServicesRes.Culture.Name } { actionCommand.Action } { actionCommand.Command }";

        //        if (string.IsNullOrWhiteSpace(exePath))
        //        {
        //            actionCommandDBService.ErrorText.AppendLine(CultureServicesRes.ExePathIsEmpty);
        //            actionCommandDBService.PercentCompleted = 0;
        //            await actionCommandDBService.Update();
        //            return BadRequest(actionCommandDBService.ErrorText.ToString());
        //        }

        //        FileInfo fiApp = new FileInfo(exePath);
        //        if (!fiApp.Exists)
        //        {
        //            actionCommandDBService.ErrorText.AppendLine(string.Format(CultureServicesRes.CouldNotFindExePath_, exePath));
        //            actionCommandDBService.PercentCompleted = 0;
        //            await actionCommandDBService.Update();
        //            return BadRequest(actionCommandDBService.ErrorText.ToString());
        //        }

        //        Process process = new Process();
        //        process = Process.Start(exePath, args);

        //        while (!process.HasExited)
        //        {
        //            // report progress is needed
        //        }

        //        return await actionCommandDBService.GetOrCreate();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(string.Format(CultureServicesRes.UnmanagedServerError_, ex.Message));
        //    }
        //}
        //public async Task<ActionResult<bool>> ReFillActionCommandList()
        //{
        //    try
        //    {
        //        return await actionCommandDBService.ReFillActionCommandList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(string.Format(CultureServicesRes.UnmanagedServerError_, ex.Message));
        //    }
        //}
        //public async Task<ActionResult<List<ActionCommand>>> GetAllActionCommandList()
        //{
        //    try
        //    {
        //        return await actionCommandDBService.GetAllActionCommandList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(string.Format(CultureServicesRes.UnmanagedServerError_, ex.Message));
        //    }
        //}
        //public async Task SetCulture(CultureInfo culture)
        //{
        //    CultureServicesRes.Culture = culture;
        //    await actionCommandDBService.SetCulture(culture);
        //}
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
