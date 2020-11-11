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
        private async Task<Preference> DoGetPreferenceWithVariableName(string VariableName)
        {
            var actionPreference = await PreferenceService.GetPreferenceWithVariableName(VariableName);
            if (await DoStatusActionPreference(actionPreference, VariableName))
            {
                Preference preference = (Preference)((OkObjectResult)actionPreference.Result).Value;
                return await Task.FromResult(new Preference() { PreferenceID = preference.PreferenceID, VariableName = preference.VariableName, VariableValue = preference.VariableValue });
            }

            return null;
        }
    }
}
