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
        public async Task<bool> GetNeedToChangedWebAllPolSourceGroupings(DateTime LastWriteTimeUtc)
        {

            bool exist = (from c in db.PolSourceGroupings
                          where c.LastUpdateDate_UTC >= LastWriteTimeUtc
                          select c).Any();

            if (exist)
            {
                return await Task.FromResult(exist);
            }

            exist = (from c in db.PolSourceGroupings
                     from cl in db.PolSourceGroupingLanguages
                     where c.PolSourceGroupingID == cl.PolSourceGroupingID
                     && cl.LastUpdateDate_UTC >= LastWriteTimeUtc
                     select cl).Any();


            return await Task.FromResult(exist);
        }
    }
}
