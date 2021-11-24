namespace CSSPDBLocalServices.Tests;

public partial class TVItemLocalServiceTest : CSSPDBLocalServiceTest
{
    private async Task<TVItemModel> CheckModifyTVItemLocal(TVItem tvItemParent, TVItemModel tvItemModelToModify)
    {
        var actionTVItemModel = await TVItemLocalService.ModifyTVTextLocalAsync(tvItemParent, tvItemModelToModify);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        return await Task.FromResult(tvItemModel);
    }
}

