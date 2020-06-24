/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels;
using CSSPWebModels;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPWebServices
{
    public partial class WebService : ControllerBase, IWebService
    {
        #region Functions public 
        public async Task<ActionResult<WebMunicipality>> GetWebMunicipality(int TVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            WebMunicipality webMunicipality = new WebMunicipality();

            try
            {
                TVItem tvItem = (from c in db.TVItems
                                 where c.TVItemID == TVItemID
                                 select c).FirstOrDefault();

                webMunicipality.TVItemMunicipality = tvItem;

                webMunicipality.TVItemInfrastructureList = (from c in db.TVItems
                                                            where c.TVPath.Contains(tvItem.TVPath + "p")
                                                            && c.ParentID == tvItem.TVItemID
                                                            && c.TVType == TVTypeEnum.Infrastructure
                                                            select c).AsNoTracking().ToList();

                webMunicipality.InfrastructureList = (from c in db.TVItems
                                                      from ci in db.Infrastructures
                                                      where c.TVItemID == ci.InfrastructureTVItemID
                                                      && c.TVPath.Contains(tvItem.TVPath + "p")
                                                      && c.ParentID == tvItem.TVItemID
                                                      && c.TVType == TVTypeEnum.Infrastructure
                                                      select ci).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webMunicipality));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
