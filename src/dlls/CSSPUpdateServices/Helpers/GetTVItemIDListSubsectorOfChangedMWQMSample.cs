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
        public async Task<List<int>> GetTVItemIDListSubsectorOfChangedMWQMSample(DateTime LastWriteTimeUtc)
        {
            List<int> TVItemIDList = (from t in db.TVItems
                                      from c in db.MWQMSamples
                                      from l in db.MWQMSampleLanguages
                                      where t.TVItemID == c.MWQMSiteTVItemID
                                      && c.MWQMSampleID == l.MWQMSampleID
                                      && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                      || l.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                      select (int)t.ParentID).Distinct().ToList();

            return await Task.FromResult(TVItemIDList);
        }
    }
}
