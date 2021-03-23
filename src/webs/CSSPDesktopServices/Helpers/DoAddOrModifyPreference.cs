/*
 * Manually edited
 *
 */

using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSSPDesktopServices.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using CSSPDBPreferenceModels;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        //private async Task<Preference> DoAddOrModifyPreference(Preference preference)
        //{
        //    var actionPreference = await PreferenceService.AddOrModify(preference);
        //    if (await DoStatusActionPreference(actionPreference, preference.VariableName))
        //    {
        //        Preference preferenceRet = (Preference)((OkObjectResult)actionPreference.Result).Value;
        //        return await Task.FromResult(new Preference() { PreferenceID = preferenceRet.PreferenceID, VariableName = preferenceRet.VariableName, VariableValue = preferenceRet.VariableValue });
        //    }

        //    return null;
        //}
    }
}
