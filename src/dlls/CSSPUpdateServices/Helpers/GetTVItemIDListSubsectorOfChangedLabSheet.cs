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
        public async Task<List<int>> GetTVItemIDListSubsectorOfChangedLabSheet(DateTime LastWriteTimeUtc)
        {
            List<int> TVItemIDList = (from c in db.LabSheets
                                       from l in db.LabSheetDetails
                                       from ld in db.LabSheetTubeMPNDetails
                                       where c.LabSheetID == l.LabSheetID
                                       && l.LabSheetDetailID == ld.LabSheetDetailID
                                       && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                       || l.LastUpdateDate_UTC >= LastWriteTimeUtc
                                       || ld.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                       select c.SubsectorTVItemID).Distinct().ToList();

            return await Task.FromResult(TVItemIDList);
        }
    }
}
