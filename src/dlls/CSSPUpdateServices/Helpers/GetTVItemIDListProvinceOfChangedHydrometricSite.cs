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
        public async Task<List<int>> GetTVItemIDListProvinceOfChangedHydrometricSite(DateTime LastWriteTimeUtc)
        {
            List<int> TVItemIDList1 = (from t in db.TVItems
                                       from tl in db.TVItemLanguages
                                       where t.TVItemID == tl.TVItemID
                                       && t.TVType == TVTypeEnum.HydrometricSite
                                       && (t.LastUpdateDate_UTC >= LastWriteTimeUtc
                                       || tl.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                       select (int)t.ParentID).Distinct().ToList();

            TVItemIDList1 = TVItemIDList1.Concat((from t in db.TVItems
                                                  from c in db.HydrometricSites
                                                  where t.TVItemID == c.HydrometricSiteTVItemID
                                                  && t.TVType == TVTypeEnum.HydrometricSite
                                                  && c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                                  select (int)t.ParentID).Distinct().ToList()).Distinct().ToList();

            TVItemIDList1 = TVItemIDList1.Concat((from t in db.TVItems
                                                  from c in db.HydrometricSites
                                                  from cd in db.HydrometricDataValues
                                                  where t.TVItemID == c.HydrometricSiteTVItemID
                                                  && c.HydrometricSiteID == cd.HydrometricSiteID
                                                  && t.TVType == TVTypeEnum.HydrometricSite
                                                  && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                                  || cd.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                                  select (int)t.ParentID).Distinct().ToList()).Distinct().ToList();

            TVItemIDList1 = TVItemIDList1.Concat((from t in db.TVItems
                                                  from c in db.HydrometricSites
                                                  from rc in db.RatingCurves
                                                  from rcv in db.RatingCurveValues
                                                  where t.TVItemID == c.HydrometricSiteTVItemID
                                                  && c.HydrometricSiteID == rc.HydrometricSiteID
                                                  && rc.RatingCurveID == rcv.RatingCurveID
                                                  && t.TVType == TVTypeEnum.HydrometricSite
                                                  && (rc.LastUpdateDate_UTC >= LastWriteTimeUtc
                                                  || rcv.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                                  select (int)t.ParentID).Distinct().ToList()).Distinct().ToList();

            return await Task.FromResult(TVItemIDList1);
        }
    }
}
