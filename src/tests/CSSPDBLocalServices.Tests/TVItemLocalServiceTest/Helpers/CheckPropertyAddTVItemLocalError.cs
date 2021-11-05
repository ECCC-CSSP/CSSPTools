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
        private async Task CheckPropertyAddTVItemLocalError(TVItem tvItemParent, TVTypeEnum tvType, string TVTextEN, string TVTextFR, string errMessage)
        {
            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(errRes);
            Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
            Assert.Equal(errMessage, CSSPLogService.ErrRes.ErrList[0]);
        }
    }
}
