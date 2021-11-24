namespace CSSPDBLocalServices.Tests;

public partial class TVItemLocalServiceTest : CSSPDBLocalServiceTest
{
    private async Task CheckDeleteTVItemLocalError(TVItem tvItemParent, TVItemModel tvItemModelExist)
    {
        var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocalAsync(tvItemParent, tvItemModelExist);
        Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
        Assert.NotEmpty(errRes.ErrList);
    }
}

