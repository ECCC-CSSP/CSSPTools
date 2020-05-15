using CSSPEnums;
using CSSPModels;
using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServicesRepopulateTestDBServices.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ValidateAppSettingsServices.Services;
using ValidateAppSettingsServices.Models;

namespace ServicesRepopulateTestDBServices.Services
{
    public partial class ServicesRepopulateTestDBService : IServicesRepopulateTestDBService
    {
        private async Task<bool> CorrectTVPath(TVItem tvItem, TVItem tvItemParent)
        {
            tvItem.TVPath = $"{ tvItemParent.TVPath }p{ tvItem.TVItemID.ToString() }";

            try
            {
                dbTestDB.SaveChanges();
            }
            catch (Exception ex)
            {
                string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                actionCommandDBService.ErrorText.AppendLine($"{ ex.Message }{ InnerException }");
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
