/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPHelperModels;
using CSSPReadGzFileServices;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json;
using ManageServices;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest : CSSPDBLocalServiceTest
    {
        private void CheckTVItem(TVItemModel tvItemModel, DBCommandEnum dbCommand)
        {
            TVItem tvItemDB = (from c in dbLocal.TVItems
                               where c.TVItemID == tvItemModel.TVItem.TVItemID
                               select c).FirstOrDefault();
            Assert.NotNull(tvItemDB);

            Assert.Equal(dbCommand, tvItemModel.TVItem.DBCommand);
            Assert.Equal(tvItemDB.DBCommand, tvItemModel.TVItem.DBCommand);
            Assert.Equal(tvItemDB.IsActive, tvItemModel.TVItem.IsActive);
            Assert.Equal(tvItemDB.ParentID, tvItemModel.TVItem.ParentID);
            Assert.Equal(tvItemDB.TVItemID, tvItemModel.TVItem.TVItemID);
            Assert.Equal(tvItemDB.TVLevel, tvItemModel.TVItem.TVLevel);
            Assert.Equal(tvItemDB.TVPath, tvItemModel.TVItem.TVPath);
            Assert.Equal(tvItemDB.TVType, tvItemModel.TVItem.TVType);
            if (dbCommand != DBCommandEnum.Original)
            {
                Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, tvItemModel.TVItem.LastUpdateContactTVItemID);
                Assert.True(DateTime.UtcNow.AddMinutes(-1) < tvItemModel.TVItem.LastUpdateDate_UTC);
                Assert.True(DateTime.UtcNow.AddMinutes(1) > tvItemModel.TVItem.LastUpdateDate_UTC);
            }
        }
    }
}
