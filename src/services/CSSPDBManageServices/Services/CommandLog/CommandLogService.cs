/*
 * Manually edited
 *
 */

using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPHelperModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageServices
{
    public partial interface ICommandLogService
    {
        Task<ActionResult<CommandLog>> AddAsync(CommandLog CommandLog);
        Task<ActionResult<CommandLog>> DeleteAsync(int CommandLogID);
        Task<ActionResult<List<CommandLog>>> GetTodayListAsync();
        Task<ActionResult<List<CommandLog>>> GetLastWeekListAsync();
        Task<ActionResult<List<CommandLog>>> GetLastMonthListAsync();
        Task<ActionResult<List<CommandLog>>> GetBetweenDatesListAsync(DateTime StartDate, DateTime EndDate);
        Task<ActionResult<CommandLog>> GetWithCommandLogIDAsync(int CommandLogID);
        Task<ActionResult<CommandLog>> ModifyAsync(CommandLog CommandLog);
    }
    public partial class CommandLogService : ControllerBase, ICommandLogService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBManageContext dbManage { get; }
        private ErrRes errRes { get; set; } = new ErrRes();
        #endregion Properties

        #region Constructors
        public CommandLogService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, CSSPDBManageContext dbManage)
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService ") }");
            if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");

            if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CSSPLogService") }");

            this.dbManage = dbManage;
        }
        #endregion Constructors
    }
}
