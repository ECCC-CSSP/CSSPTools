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
        public async Task<List<int>> GetTVItemIDListAllOfChangedTVItemLink(DateTime LastWriteTimeUtc)
        {
            List<int> TVItemIDList1 = (from t in db.TVItems
                                       from tl in db.TVItemLinks
                                       where t.TVItemID == tl.FromTVItemID
                                       && (tl.FromTVType == TVTypeEnum.Contact
                                       || tl.FromTVType == TVTypeEnum.LiftStation
                                       || tl.FromTVType == TVTypeEnum.Infrastructure)
                                       && tl.LastUpdateDate_UTC >= LastWriteTimeUtc
                                       select (int)t.ParentID).Distinct().ToList();

            TVItemIDList1 = TVItemIDList1.Concat((from tl in db.TVItemLinks
                                                  where tl.FromTVType == TVTypeEnum.Municipality
                                                  && tl.LastUpdateDate_UTC >= LastWriteTimeUtc
                                                  select tl.FromTVItemID).Distinct().ToList()).Distinct().ToList();

            return await Task.FromResult(TVItemIDList1);
        }
    }
}
