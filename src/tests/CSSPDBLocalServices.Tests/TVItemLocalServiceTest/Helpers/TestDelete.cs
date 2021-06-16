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
        private async Task TestDelete(PostTVItemModel postTVItemModel)
        {
            var actionDeleteTVItemModelRes = await TVItemLocalService.DeleteLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionDeleteTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDeleteTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionDeleteTVItemModelRes.Result).Value;
            Assert.True(boolRet);
        }
    }
}
