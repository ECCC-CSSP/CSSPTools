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
        public async Task<List<int>> GetTVItemIDListSubsectorOfChangedClassification(DateTime LastWriteTimeUtc)
        {
            List<int> subsectorTVItemIDList = (from t in db.TVItems
                                               from c in db.Classifications
                                               where t.TVItemID == c.ClassificationTVItemID
                                               && c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                               select (int)t.ParentID).Distinct().ToList();

            return await Task.FromResult(subsectorTVItemIDList);
        }
    }
}
