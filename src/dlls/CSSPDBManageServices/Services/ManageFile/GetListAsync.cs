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
        public async Task<ActionResult<List<ManageFile>>> GetListAsync(int skip = 0, int take = 100)
        {
            List<ManageFile> manageFileList = (from c in dbManage.ManageFiles.AsNoTracking()
                                               orderby c.ManageFileID
                                               select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(manageFileList));
        }
    }
}
