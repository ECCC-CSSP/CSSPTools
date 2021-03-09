/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using CSSPDBPreferenceModels;
using CSSPDBFilesManagementModels;
using LoggedInServices;
using CSSPWebModels;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebSamplingPlan(WebSamplingPlan WebSamplingPlan, WebSamplingPlan WebSamplingPlanLocal)
        {
            // -----------------------------------------------------------
            // doing SamplingPlanEmailList
            // -----------------------------------------------------------
            int count = WebSamplingPlan.SamplingPlanModel.SamplingPlanEmailList.Count;
            for (int i = 0; i < count; i++)
            {
                SamplingPlanEmail SamplingPlanEmailLocal = (from c in WebSamplingPlanLocal.SamplingPlanModel.SamplingPlanEmailList
                                                            where c.SamplingPlanEmailID == WebSamplingPlan.SamplingPlanModel.SamplingPlanEmailList[i].SamplingPlanEmailID
                                                            && c.DBCommand != DBCommandEnum.Original
                                                            select c).FirstOrDefault();

                if (SamplingPlanEmailLocal != null)
                {
                    WebSamplingPlan.SamplingPlanModel.SamplingPlanEmailList[i] = SamplingPlanEmailLocal;
                }
            }

            List<SamplingPlanEmail> SamplingPlanEmailLocalNewList = (from c in WebSamplingPlanLocal.SamplingPlanModel.SamplingPlanEmailList
                                                                     where c.DBCommand == DBCommandEnum.Created
                                                                     select c).ToList();

            foreach (SamplingPlanEmail SamplingPlanEmailNew in SamplingPlanEmailLocalNewList)
            {
                WebSamplingPlan.SamplingPlanModel.SamplingPlanEmailList.Add(SamplingPlanEmailNew);
            }

            // -----------------------------------------------------------
            // doing SamplingPlanSubsectorModelList
            // -----------------------------------------------------------
            count = WebSamplingPlan.SamplingPlanModel.SamplingPlanSubsectorModelList.Count;
            for (int i = 0; i < count; i++)
            {
                SamplingPlanSubsectorModel SamplingPlanSubsectorModelLocal = (from c in WebSamplingPlanLocal.SamplingPlanModel.SamplingPlanSubsectorModelList
                                                                              where c.SamplingPlanSubsector.SamplingPlanSubsectorID == WebSamplingPlan.SamplingPlanModel.SamplingPlanSubsectorModelList[i].SamplingPlanSubsector.SamplingPlanSubsectorID
                                                                              && c.SamplingPlanSubsector.DBCommand != DBCommandEnum.Original
                                                                              select c).FirstOrDefault();

                if (SamplingPlanSubsectorModelLocal != null)
                {
                    WebSamplingPlan.SamplingPlanModel.SamplingPlanSubsectorModelList[i] = SamplingPlanSubsectorModelLocal;
                }
            }

            List<SamplingPlanSubsectorModel> SamplingPlanSubsectorModelLocalNewList = (from c in WebSamplingPlanLocal.SamplingPlanModel.SamplingPlanSubsectorModelList
                                                                                       where c.SamplingPlanSubsector.DBCommand == DBCommandEnum.Created
                                                                                       select c).ToList();

            foreach (SamplingPlanSubsectorModel SamplingPlanSubsectorModelNew in SamplingPlanSubsectorModelLocalNewList)
            {
                int count2 = SamplingPlanSubsectorModelNew.SamplingPlanSubsectorSiteList.Count;
                for (int i = 0; i < count2; i++)
                {
                    SamplingPlanSubsectorSite SamplingPlanSubsectorSiteLocal = (from c in SamplingPlanSubsectorModelNew.SamplingPlanSubsectorSiteList
                                                                                where c.SamplingPlanSubsectorSiteID == SamplingPlanSubsectorModelNew.SamplingPlanSubsectorSiteList[i].SamplingPlanSubsectorSiteID
                                                                                && c.DBCommand != DBCommandEnum.Original
                                                                                select c).FirstOrDefault();

                    if (SamplingPlanSubsectorSiteLocal != null)
                    {
                        SamplingPlanSubsectorModelNew.SamplingPlanSubsectorSiteList[i] = SamplingPlanSubsectorSiteLocal;
                    }
                }

                List<SamplingPlanSubsectorSite> SamplingPlanSubsectorSiteLocalNewList = (from c in SamplingPlanSubsectorModelNew.SamplingPlanSubsectorSiteList
                                                                                         where c.DBCommand == DBCommandEnum.Created
                                                                                         select c).ToList();

                foreach (SamplingPlanSubsectorSite SamplingPlanSubsectorSiteNew in SamplingPlanSubsectorSiteLocalNewList)
                {
                    SamplingPlanSubsectorModelNew.SamplingPlanSubsectorSiteList.Add(SamplingPlanSubsectorSiteNew);
                }

                WebSamplingPlan.SamplingPlanModel.SamplingPlanSubsectorModelList.Add(SamplingPlanSubsectorModelNew);
            }

            return;
        }
    }
}
