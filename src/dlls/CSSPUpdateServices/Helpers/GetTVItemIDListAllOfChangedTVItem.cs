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
        public async Task<List<int>> GetTVItemIDListAllOfChangedTVItem(DateTime LastWriteTimeUtc)
        {
            List<int> TVItemIDList = (from t in db.TVItems
                                      where (t.TVType == TVTypeEnum.Country
                                      || t.TVType == TVTypeEnum.Province
                                      || t.TVType == TVTypeEnum.Area
                                      || t.TVType == TVTypeEnum.Sector
                                      || t.TVType == TVTypeEnum.Subsector
                                      || t.TVType == TVTypeEnum.Municipality)
                                      && t.LastUpdateDate_UTC >= LastWriteTimeUtc
                                      select t.TVItemID).Distinct().ToList();

            TVItemIDList = TVItemIDList.Concat((from t in db.TVItems
                                                from tl in db.TVItemLanguages
                                                where t.TVItemID == tl.TVItemID
                                                && (t.TVType == TVTypeEnum.Country
                                                || t.TVType == TVTypeEnum.Province
                                                || t.TVType == TVTypeEnum.Area
                                                || t.TVType == TVTypeEnum.Sector
                                                || t.TVType == TVTypeEnum.Subsector
                                                || t.TVType == TVTypeEnum.Municipality)
                                                && tl.LastUpdateDate_UTC >= LastWriteTimeUtc
                                                select tl.TVItemID).Distinct().ToList()).Distinct().ToList();

            return await Task.FromResult(TVItemIDList);
        }
    }
}
