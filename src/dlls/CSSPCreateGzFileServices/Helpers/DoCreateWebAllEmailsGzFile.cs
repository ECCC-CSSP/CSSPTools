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
        private async Task<bool> DoCreateWebAllEmailsGzFile()
        {
            string FunctionName = $"{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
            await CSSPLogService.FunctionLog(FunctionName);

            TVItem TVItemRoot = await GetTVItemRoot();

            if (TVItemRoot == null || TVItemRoot.TVType != TVTypeEnum.Root)
            {
                await CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_, "TVItem", "TVType", TVTypeEnum.Root.ToString()), new[] { "" }));
                await CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            WebAllEmails webAllEmails  = new WebAllEmails();

            try
            {
                if (!await FillEmailModelList(webAllEmails.EmailModelList, TVItemRoot)) return await Task.FromResult(false);

                if (dbLocal != null)
                {
                    if (!await DoStoreLocal<WebAllEmails>(webAllEmails, $"{ WebTypeEnum.WebAllEmails }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStore<WebAllEmails>(webAllEmails, $"{ WebTypeEnum.WebAllEmails }.gz")) return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                await CSSPLogService.AppendError(new ValidationResult($"{ ex.Message } { inner }", new[] { "" }));
                await CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            await CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}