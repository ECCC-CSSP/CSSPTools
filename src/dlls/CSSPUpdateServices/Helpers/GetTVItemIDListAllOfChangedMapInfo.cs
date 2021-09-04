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
        public async Task<List<int>> GetTVItemIDListAllOfChangedMapInfo(DateTime LastWriteTimeUtc)
        {
            List<int> TVItemIDList = (from c in db.MapInfos
                                      from m in db.MapInfoPoints
                                      where c.MapInfoID == m.MapInfoID
                                      && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                      || m.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                      select c.TVItemID).Distinct().ToList();

            return await Task.FromResult(TVItemIDList);
        }
    }
}
