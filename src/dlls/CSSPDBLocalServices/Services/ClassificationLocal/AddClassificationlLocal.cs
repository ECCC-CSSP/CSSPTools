///*
// * Manually edited
// *
// */

//using CSSPEnums;
//using CSSPDBModels;
//using CSSPCultureServices.Resources;
//using CSSPCultureServices.Services;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using CSSPLocalLoggedInServices;
//using Microsoft.Extensions.Configuration;
//using CSSPWebModels;
//using System.Text.Json;
//using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
//using CSSPHelperModels;
//using CSSPLogServices;
//using System.Reflection;
//using System.Security.Cryptography;
//using CSSPReadGzFileServices;
//using CSSPCreateGzFileServices;

//namespace CSSPDBLocalServices
//{
//    public partial class ClassificationLocalService : ControllerBase, IClassificationLocalService
//    {
//        public async Task<ActionResult<ClassificationLocalModel>> AddClassificationLocal(ClassificationLocalModel classificationLocalModel)
//        {
//            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(ClassificationLocalModel classificationLocalModel)";
//            CSSPLogService.FunctionLog(FunctionName);

//            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

//            #region Check Classification
//            if (classificationLocalModel.Classification.ClassificationID != 0)
//            {
//                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "ClassificationID", "0"));
//            }

//            //string retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)ClassificationModel.Classification.DBCommand);
//            //if (!string.IsNullOrWhiteSpace(retStr))
//            //{
//            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
//            //}

//            //if (ClassificationModel.Classification.ClassificationTVItemID == 0)
//            //{
//            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "ClassificationTVItemID"));
//            //}

//            if (string.IsNullOrWhiteSpace(classificationLocalModel.Classification.ClassificationAddress))
//            {
//                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "ClassificationAddress"));
//            }

//            string retStr = enums.EnumTypeOK(typeof(ClassificationTypeEnum), (int?)classificationLocalModel.Classification.ClassificationType);
//            if (!string.IsNullOrWhiteSpace(retStr))
//            {
//                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "ClassificationType"));
//            }
//            #endregion Check Classification

//            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

//            WebAllClassifications webAllClassifications = await CSSPReadGzFileService.GetUncompressJSON<WebAllClassifications>(WebTypeEnum.WebAllClassifications, 0);

//            Classification classificationJSON = (from c in webAllClassifications.ClassificationList
//                                   where c.ClassificationAddress == classificationLocalModel.Classification.ClassificationAddress
//                                   select c).FirstOrDefault();

//            if (classificationJSON != null)
//            {
//                return await Task.FromResult(Ok(new ClassificationLocalModel() { Classification = classificationJSON }));
//            }

//            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

//            await TVItemLocalService.AddTVItemParentLocal(webRoot.TVItemModelParentList.OrderBy(c => c.TVItem.TVLevel).ToList());

//            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

//            string TVTextEN = $"{ classificationLocalModel.Classification.ClassificationAddress }";
//            string TVTextFR = $"{ classificationLocalModel.Classification.ClassificationAddress }";

//            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(webRoot.TVItemModel.TVItem, TVTypeEnum.Classification, TVTextEN, TVTextFR);

//            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

//            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;

//            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

//            int ClassificationIDNew = (from c in dbLocal.Classifications
//                                where c.ClassificationID < 0
//                                orderby c.ClassificationID descending
//                                select c.ClassificationID).FirstOrDefault() - 1;

//            try
//            {
//                classificationLocalModel.Classification.DBCommand = DBCommandEnum.Created;
//                classificationLocalModel.Classification.ClassificationID = ClassificationIDNew;
//                classificationLocalModel.Classification.ClassificationTVItemID = tvItemModel.TVItem.TVItemID;
//                classificationLocalModel.Classification.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
//                classificationLocalModel.Classification.LastUpdateDate_UTC = DateTime.UtcNow;

//                dbLocal.Classifications.Add(classificationLocalModel.Classification);
//                dbLocal.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Classification", ex.Message));
//            }

//            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

//            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebAllClassifications, 0);
//            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
//            {
//                ErrRes errRes2 = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
//                CSSPLogService.ErrRes.ErrList.AddRange(errRes2.ErrList);
//            }

//            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

//            CSSPLogService.EndFunctionLog(FunctionName);

//            return await Task.FromResult(Ok(classificationLocalModel));
//        }
//    }
//}