namespace CSSPDBLocalServices.Tests;

public partial class TVItemLocalServiceTest : CSSPDBLocalServiceTest
{
    private async Task<TVItemModel> CheckAddTVItemLocal(TVItem tvItemParent, TVTypeEnum tvType, string TVTextEN, string TVTextFR)
    {
        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        return await Task.FromResult(tvItemModel);
    }
}

