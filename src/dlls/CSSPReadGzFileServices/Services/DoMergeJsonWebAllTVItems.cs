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
//        private void DoMergeJsonWebAllTVItems(WebAllTVItems WebAllTVItems, WebAllTVItems WebAllTVItemsLocal)
//        {
//            List<TVItem> tvItemLocalList = (from c in WebAllTVItemsLocal.TVItemList
//                                              where c.DBCommand != DBCommandEnum.Original
//                                              select c).ToList();

//            foreach (TVItem tvItemLocal in tvItemLocalList)
//            {
//                TVItem tvItemOriginal = WebAllTVItems.TVItemList.Where(c => c.TVItemID == tvItemLocal.TVItemID).FirstOrDefault();
//                if (tvItemOriginal == null)
//                {
//                    WebAllTVItems.TVItemList.Add(tvItemLocal);
//                }
//                else
//                {
//                    tvItemOriginal = tvItemLocal;
//                }
//            }
//        }
//    }
//}
