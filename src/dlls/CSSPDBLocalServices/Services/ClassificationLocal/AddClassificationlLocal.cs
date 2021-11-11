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
using CSSPLocalLoggedInServices;
using Microsoft.Extensions.Configuration;
using CSSPWebModels;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using CSSPHelperModels;
using CSSPLogServices;
using System.Reflection;
using System.Security.Cryptography;
using CSSPReadGzFileServices;
using CSSPCreateGzFileServices;

namespace CSSPDBLocalServices
{
    public partial class ClassificationLocalService : ControllerBase, IClassificationLocalService
    {
        public async Task<ActionResult<ClassificationModel>> AddClassificationLocal(int SubsectorTVItemID, ClassificationTypeEnum classificationType, List<Coord> coordList)
        {
            string parameters = $" --  SubsectorTVItemID = { SubsectorTVItemID } " +
                $"classificationType = { classificationType }";

            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(int SubsectorTVItemID, ClassificationTypeEnum classificationType, List<Coord> coordList) { parameters }";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            #region Check Classification
            if (SubsectorTVItemID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "SubsectorTVItemID"));
            }

            string retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)classificationType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "classificationType"));
            }

            if (coordList == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "coordList"));
            }

            if (coordList.Count == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "coordList"));
            }
            #endregion Check Classification

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, SubsectorTVItemID);

            int LastOrdinal = (from c in webSubsector.ClassificationModelList
                               orderby c.Classification.Ordinal ascending
                               select c.Classification.Ordinal).FirstOrDefault();

            string TVText = "ERROR";
            switch (classificationType)
            {
                case ClassificationTypeEnum.Approved:
                    {
                        TVText = "A " + LastOrdinal;
                    }
                    break;
                case ClassificationTypeEnum.ConditionallyApproved:
                    {
                        TVText = "CA " + LastOrdinal;
                    }
                    break;
                case ClassificationTypeEnum.ConditionallyRestricted:
                    {
                        TVText = "CR " + LastOrdinal;
                    }
                    break;
                case ClassificationTypeEnum.Prohibited:
                    {
                        TVText = "P " + LastOrdinal;
                    }
                    break;
                case ClassificationTypeEnum.Restricted:
                    {
                        TVText = "R " + LastOrdinal;
                    }
                    break;
                default:
                    break;
            }

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(webSubsector.TVItemModel.TVItem, TVTypeEnum.Classification, TVText, TVText);

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            int ClassificationIDNew = (from c in dbLocal.Classifications
                               where c.ClassificationID < 0
                               orderby c.ClassificationID ascending
                               select c.ClassificationID).FirstOrDefault() - 1;

            Classification classification = new Classification()
            {
                ClassificationID = ClassificationIDNew,
                ClassificationTVItemID = tvItemModel.TVItem.TVItemID,
                ClassificationType = classificationType,
                Ordinal = LastOrdinal + 1,
                DBCommand = DBCommandEnum.Created,
                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                LastUpdateDate_UTC = DateTime.UtcNow,
            };

            try
            {
                dbLocal.Classifications.Add(classification);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Classification", ex.Message));
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebSubsector, SubsectorTVItemID);
            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
            {
                ErrRes errRes2 = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                CSSPLogService.ErrRes.ErrList.AddRange(errRes2.ErrList);
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            CSSPLogService.EndFunctionLog(FunctionName);

            ClassificationLocalModel classificationLocalModel = new ClassificationLocalModel()
            {
                TVItemParent = webSubsector.TVItemModel.TVItem,
                TVItemModel = tvItemModel,
                Classification = classification,
            };

            return await Task.FromResult(Ok(classificationLocalModel));
        }
    }
}