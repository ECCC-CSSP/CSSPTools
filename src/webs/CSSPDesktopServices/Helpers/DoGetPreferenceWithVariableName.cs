/*
 * Manually edited
 *
 */

using CSSPEnums;
using CSSPModels;
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

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<Preference> DoGetPreferenceWithVariableName(string VariableName)
        {
            var actionPreference = await PreferenceService.GetWithVariableName(VariableName);
            if (await DoStatusActionPreference(actionPreference, VariableName))
            {
                Preference preference = (Preference)((OkObjectResult)actionPreference.Result).Value;
                return await Task.FromResult(new Preference() { PreferenceID = preference.PreferenceID, VariableName = preference.VariableName, VariableValue = await LocalService.Descramble(preference.VariableValue) });
            }

            return null;
        }
    }
}
