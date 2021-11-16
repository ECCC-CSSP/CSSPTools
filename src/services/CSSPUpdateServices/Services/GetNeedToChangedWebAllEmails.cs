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
        public async Task<bool> GetNeedToChangedWebAllEmails(DateTime LastWriteTimeUtc)
        {
            bool exist = (from c in db.TVItems
                          where c.TVType == TVTypeEnum.Email
                          && c.LastUpdateDate_UTC >= LastWriteTimeUtc
                          select c).Any();

            if (exist)
            {
                return await Task.FromResult(exist);
            }

            exist = (from c in db.TVItems
                     from cl in db.TVItemLanguages
                     where c.TVItemID == cl.TVItemID
                     && c.TVType == TVTypeEnum.Email
                     && cl.LastUpdateDate_UTC >= LastWriteTimeUtc
                     select cl).Any();

            if (exist)
            {
                return await Task.FromResult(exist);
            }

            exist = (from c in db.Emails
                     where c.LastUpdateDate_UTC >= LastWriteTimeUtc
                     select c).Any();

            return await Task.FromResult(exist);
        }
    }
}
