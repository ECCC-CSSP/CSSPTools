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

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ICSSPUpdateService
    {
        public async Task<bool> GetNeedToChangedWebAllHelpDocs(DateTime LastWriteTimeUtc)
        {

            bool exist = (from c in db.HelpDocs
                     where c.LastUpdateDate_UTC >= LastWriteTimeUtc
                     select c).Any();

            return await Task.FromResult(exist);
        }
    }
}