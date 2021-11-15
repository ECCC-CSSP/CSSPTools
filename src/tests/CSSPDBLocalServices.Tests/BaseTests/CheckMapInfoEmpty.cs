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
    public partial class CSSPDBLocalServiceTest
    {
        protected void CheckMapInfoEmpty(MapInfo mapInfo)
        {
            MapInfo mapInfoDB = (from c in dbLocal.MapInfos
                                 where c.MapInfoID == mapInfo.MapInfoID
                                 select c).FirstOrDefault();
            Assert.Null(mapInfoDB);
        }
    }
}
