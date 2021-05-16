///*
// * Manually edited
// * 
// */
//using Azure;
//using Azure.Storage.Blobs;
//using Azure.Storage.Blobs.Models;
//using CSSPCultureServices.Resources;
//using CSSPEnums;
//using CSSPDBModels;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.IO.Compression;
//using System.Linq;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Text.Json;
//using System.Threading.Tasks;
//using CSSPDBPreferenceModels;
//using CSSPDBFilesManagementModels;
//using LoggedInServices;
//using CSSPWebModels;

//namespace ReadGzFileServices
//{
//    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
//    {
//        private void DoMergeJsonWebAllTVItemLanguages(WebAllTVItemLanguages WebAllTVItemLanguages, WebAllTVItemLanguages WebAllTVItemLanguagesLocal)
//        {
//            List<TVItemLanguage> tvItemLanguageLocalList = (from c in WebAllTVItemLanguagesLocal.TVItemLanguageList
//                                                    where c.DBCommand != DBCommandEnum.Original
//                                                    select c).ToList();

//            foreach (TVItemLanguage tvItemLanguageLocal in tvItemLanguageLocalList)
//            {
//                TVItemLanguage tvItemLanguageOriginal = WebAllTVItemLanguages.TVItemLanguageList.Where(c => c.TVItemLanguageID == tvItemLanguageLocal.TVItemLanguageID).FirstOrDefault();
//                if (tvItemLanguageOriginal == null)
//                {
//                    WebAllTVItemLanguages.TVItemLanguageList.Add(tvItemLanguageLocal);
//                }
//                else
//                {
//                    tvItemLanguageOriginal = tvItemLanguageLocal;
//                }
//            }
//        }
//    }
//}
