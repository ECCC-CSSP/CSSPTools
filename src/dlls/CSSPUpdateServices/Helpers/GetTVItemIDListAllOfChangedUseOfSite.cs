﻿using CSSPDBModels;
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
        public async Task<List<int>> GetTVItemIDListAllOfChangedUseOfSite(DateTime LastWriteTimeUtc)
        {
            List<int> TVItemIDList1 = (from t in db.UseOfSites
                                       where t.LastUpdateDate_UTC >= LastWriteTimeUtc
                                       select t.SubsectorTVItemID).Distinct().ToList();

            return await Task.FromResult(TVItemIDList1);
        }
    }
}
