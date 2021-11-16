/*
 * Manually edited
 *
 */

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageServices
{
    public partial class CommandLogService : ControllerBase, ICommandLogService
    {
        public async Task<ActionResult<List<CommandLog>>> GetLastWeekListAsync()
        {
            DateTime StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 7, 0, 0, 0);
            DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            return await GetBetweenDatesListAsync(StartDate, EndDate);
        }
    }
}
