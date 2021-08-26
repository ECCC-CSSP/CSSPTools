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
        public async Task<List<int>> GetTVItemIDListCountryOfChangedEmailDistributionList(DateTime LastWriteTimeUtc)
        {
            List<int> TVItemIDList = (from e in db.EmailDistributionLists
                                      from el in db.EmailDistributionListLanguages
                                      where e.EmailDistributionListID == el.EmailDistributionListID
                                      && (e.LastUpdateDate_UTC >= LastWriteTimeUtc
                                      || el.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                      select e.ParentTVItemID).Distinct().ToList();

            TVItemIDList = TVItemIDList.Concat((from e in db.EmailDistributionLists
                                                from ec in db.EmailDistributionListContacts
                                                where e.EmailDistributionListID == ec.EmailDistributionListID
                                                && ec.LastUpdateDate_UTC >= LastWriteTimeUtc
                                                select e.ParentTVItemID).Distinct().ToList()).Distinct().ToList();

            TVItemIDList = TVItemIDList.Concat((from e in db.EmailDistributionLists
                                                from ec in db.EmailDistributionListContacts
                                                from ecl in db.EmailDistributionListContacts
                                                where e.EmailDistributionListID == ecl.EmailDistributionListID
                                                && ec.EmailDistributionListContactID == ecl.EmailDistributionListContactID
                                                && ecl.LastUpdateDate_UTC >= LastWriteTimeUtc
                                                select e.ParentTVItemID).Distinct().ToList()).Distinct().ToList();

            return await Task.FromResult(TVItemIDList);
        }
    }
}
