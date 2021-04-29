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
        private void FillAppTaskLanguage(AppTaskLanguage appTaskLanguage, AppTaskLanguage postAppTaskLanguage)
        {
            appTaskLanguage.AppTaskID = postAppTaskLanguage.AppTaskID;
            appTaskLanguage.DBCommand = postAppTaskLanguage.DBCommand;
            appTaskLanguage.ErrorText = postAppTaskLanguage.ErrorText;
            appTaskLanguage.Language = postAppTaskLanguage.Language;
            appTaskLanguage.LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
            appTaskLanguage.LastUpdateDate_UTC = DateTime.UtcNow;
            appTaskLanguage.StatusText = postAppTaskLanguage.StatusText;
            appTaskLanguage.TranslationStatus = postAppTaskLanguage.TranslationStatus;
        }
    }
}

