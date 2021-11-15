/*
 * Manually edited
 *
 */

using CSSPEnums;
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
using Microsoft.Extensions.Configuration;
using CSSPHelperModels;

namespace ManageServices
{
    public partial class ManageFileService : ControllerBase, IManageFileService
    {
        public async Task<ActionResult<ManageFile>> GetWithAzureStorageAndAzureFileNameAsync(string AzureStorage, string AzureFileName)
        {
            ManageFile manageFile = (from c in dbManage.ManageFiles.AsNoTracking()
                                     where c.AzureStorage == AzureStorage
                                     && c.AzureFileName == AzureFileName
                                     select c).FirstOrDefault();

            //if (manageFile == null)
            //{
            //    return await Task.FromResult(Ok(manageFile));
            //    //errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ManageFile", "AzureStorage,AzureFileName", $"{ AzureStorage }, { AzureFileName }"));
            //    //return await Task.FromResult(BadRequest(errRes));
            //}

            return await Task.FromResult(Ok(manageFile));
        }
    }
}
