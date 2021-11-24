namespace CSSPDBLocalServices.Tests;

public partial class TVItemLocalServiceTest : CSSPDBLocalServiceTest
{
    private async Task<TVItemModel> CheckDeleteTVItemLocal(TVItem tvItemParent, TVItemModel tvItemModelExist)
    {
        var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocalAsync(tvItemParent, tvItemModelExist);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        return await Task.FromResult(tvItemModel);
    }
}

