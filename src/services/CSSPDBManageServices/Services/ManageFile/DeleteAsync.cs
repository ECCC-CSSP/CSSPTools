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
        public async Task<ActionResult<ManageFile>> DeleteAsync(int ManageFileID)
        {
            if (ManageFileID == 0)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "ManageFileID"));
            }

            if (errRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(errRes));

            ManageFile manageFile = (from c in dbManage.ManageFiles
                                        where c.ManageFileID == ManageFileID
                                        select c).FirstOrDefault();

            if (manageFile == null)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ManageFile", "ManageFileID", ManageFileID.ToString()));
            }

            if (errRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(errRes));

            try
            {
                dbManage.ManageFiles.Remove(manageFile);
                dbManage.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                errRes.ErrList.Add(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
            }

            if (errRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(errRes));

            return await Task.FromResult(Ok(manageFile));
        }
    }
}
