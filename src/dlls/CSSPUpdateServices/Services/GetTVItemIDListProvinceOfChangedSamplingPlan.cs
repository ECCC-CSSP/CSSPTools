using CSSPDBModels;
using CSSPDBServices;
using CSSPEnums;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using CSSPWebModels;
using System.Text.Json;
using System.IO;
using CSSPCultureServices.Resources;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
    {
        public async Task<List<int>> GetTVItemIDListProvinceOfChangedSamplingPlan(DateTime LastWriteTimeUtc)
        {
            List<int> TVItemIDList1 = (from sp in db.SamplingPlans
                                       from sps in db.SamplingPlanSubsectors
                                       from spss in db.SamplingPlanSubsectorSites
                                       where sp.SamplingPlanID == sps.SamplingPlanID
                                       && sps.SamplingPlanSubsectorID == spss.SamplingPlanSubsectorID
                                       && (sp.LastUpdateDate_UTC >= LastWriteTimeUtc
                                       || sps.LastUpdateDate_UTC >= LastWriteTimeUtc
                                       || spss.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                       select sp.ProvinceTVItemID).Distinct().ToList();

            TVItemIDList1 = TVItemIDList1.Concat((from sp in db.SamplingPlans
                                                  from spe in db.SamplingPlanEmails
                                                  where sp.SamplingPlanID == spe.SamplingPlanID
                                                  && spe.LastUpdateDate_UTC >= LastWriteTimeUtc
                                                  select sp.ProvinceTVItemID).Distinct().ToList()).Distinct().ToList();

            return await Task.FromResult(TVItemIDList1);
        }
    }
}
