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

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ICSSPUpdateService
    {
        public async Task<List<int>> GetTVItemIDListSubsectorOfChangedMWQMAnalysisReportParameter(DateTime LastWriteTimeUtc)
        {
            List<int> subsectorTVItemIDList = (from c in db.MWQMAnalysisReportParameters
                                               where c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                               select c.SubsectorTVItemID).Distinct().ToList();

            return await Task.FromResult(subsectorTVItemIDList);
        }
    }
}
