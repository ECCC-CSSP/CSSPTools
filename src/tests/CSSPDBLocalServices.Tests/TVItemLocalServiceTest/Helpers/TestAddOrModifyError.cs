/* 
 *  Manually Edited
 *  
 */

using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private async Task TestAddOrModifyError(PostTVItemModel postTVItemModel, string errorMessage)
        {
            var actionPostTVItemModelRes = await TVItemLocalService.AddOrModifyLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            List<ValidationResult> vrList = ((List<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(errorMessage)).Any());
        }
    }
}
