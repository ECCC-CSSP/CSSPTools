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
        public async Task<ActionResult<int>> GetNextIndexToUseAsync()
        {
            int? LastIndex = (from c in dbManage.ManageFiles
                              orderby c.ManageFileID descending
                              select c.ManageFileID).FirstOrDefault() + 1;

            return await Task.FromResult(Ok(LastIndex));
        }
    }
}
