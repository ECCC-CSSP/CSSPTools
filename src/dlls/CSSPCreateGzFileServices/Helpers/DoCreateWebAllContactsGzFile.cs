﻿/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Threading.Tasks;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> DoCreateWebAllContactsGzFile()
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
            CSSPLogService.FunctionLog(FunctionName);

            TVItem TVItemRoot = await GetTVItemRoot();

            if (TVItemRoot == null || TVItemRoot.TVType != TVTypeEnum.Root)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_, "TVItem", "TVType", TVTypeEnum.Root.ToString()));
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            WebAllContacts webAllContacts  = new WebAllContacts();

            try
            {
                if (!await FillContactModelList(webAllContacts.ContactModelList, TVItemRoot)) return await Task.FromResult(false);

                if (dbLocal != null)
                {
                    if (!await DoStoreLocal<WebAllContacts>(webAllContacts, $"{ WebTypeEnum.WebAllContacts }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStore<WebAllContacts>(webAllContacts, $"{ WebTypeEnum.WebAllContacts }.gz")) return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                CSSPLogService.AppendError($"{ ex.Message } { inner }");
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
