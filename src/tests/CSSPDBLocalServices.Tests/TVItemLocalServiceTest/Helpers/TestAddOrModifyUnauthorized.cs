/* 
 *  Manually Edited
 *  
 */

using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private async Task TestAddOrModifyUnauthorized(PostTVItemModel postTVItemModel, string errorMessage)
        {
            var actionPostTVItemModelRes = await TVItemLocalService.AddOrModifyLocal(postTVItemModel);
            Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
            var validationResult = ((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.Equal(errorMessage, validationResult);
        }
    }
}
