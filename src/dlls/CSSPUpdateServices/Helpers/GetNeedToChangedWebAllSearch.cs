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
        public async Task<bool> GetNeedToChangedWebAllSearch(DateTime LastWriteTimeUtc)
        {
            bool exist = (from c in db.TVItems
                          from cl in db.TVItemLanguages
                          where c.TVItemID == cl.TVItemID
                          && (c.TVType == TVTypeEnum.Country
                          || c.TVType == TVTypeEnum.Province
                          || c.TVType == TVTypeEnum.Area
                          || c.TVType == TVTypeEnum.Sector
                          || c.TVType == TVTypeEnum.Subsector
                          || c.TVType == TVTypeEnum.Municipality)
                          && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                          || cl.LastUpdateDate_UTC >= LastWriteTimeUtc)
                          select c).Any();

            return await Task.FromResult(exist);
        }
    }
}
