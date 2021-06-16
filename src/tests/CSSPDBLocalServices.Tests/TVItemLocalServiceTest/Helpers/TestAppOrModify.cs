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
        private async Task TestAddOrModify(PostTVItemModel postTVItemModel)
        {
            var actionPostTVItemModelRes = await TVItemLocalService.AddOrModifyLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);
        }
    }
}
