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
        public async Task<List<int>> GetTVItemIDListSubsectorOfChangedMWQMRun(DateTime LastWriteTimeUtc)
        {
            List<int> TVItemIDList = (from c in db.TVItems
                                      from l in db.TVItemLanguages
                                      where c.TVItemID == l.TVItemID
                                      && c.TVType == TVTypeEnum.MWQMRun
                                      && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                      || l.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                      select (int)c.ParentID).Distinct().ToList();

            TVItemIDList = TVItemIDList.Concat((from c in db.MWQMRuns
                                       from l in db.MWQMRunLanguages
                                       where c.MWQMRunID == l.MWQMRunID
                                       && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                       || l.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                       select c.SubsectorTVItemID).Distinct().ToList()).Distinct().ToList();

            return await Task.FromResult(TVItemIDList);
        }
    }
}
