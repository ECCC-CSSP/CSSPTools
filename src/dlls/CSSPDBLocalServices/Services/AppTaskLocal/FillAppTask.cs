/*
 * Manually edited
 *
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CSSPDBLocalServices
{

    public partial class AppTaskLocalService : ControllerBase, IAppTaskLocalService
    {
        private void FillAppTask(AppTask appTask, AppTask postAppTask)
        {
            appTask.AppTaskCommand = postAppTask.AppTaskCommand;
            appTask.AppTaskStatus = postAppTask.AppTaskStatus;
            appTask.DBCommand = postAppTask.DBCommand;
            appTask.EndDateTime_UTC = postAppTask.EndDateTime_UTC;
            appTask.EstimatedLength_second = postAppTask.EstimatedLength_second;
            appTask.Language = postAppTask.Language;
            appTask.LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
            appTask.LastUpdateDate_UTC = DateTime.UtcNow;
            appTask.Parameters = postAppTask.Parameters;
            appTask.PercentCompleted = postAppTask.PercentCompleted;
            appTask.RemainingTime_second = postAppTask.RemainingTime_second;
            appTask.StartDateTime_UTC = postAppTask.StartDateTime_UTC;
            appTask.TVItemID = postAppTask.TVItemID;
            appTask.TVItemID2 = postAppTask.TVItemID2;
        }
    }
}

