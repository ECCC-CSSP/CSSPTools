namespace CSSPDBLocalServices.Tests;

public partial class TVItemLocalServiceTest : CSSPDBLocalServiceTest
{
    private async Task CheckPropertyModifyTVTextLocalError(TVItem tvItemParent, TVItemModel tvItemModel, string errMessage)
    {
        var actionTVItemModel = await TVItemLocalService.ModifyTVTextLocalAsync(tvItemParent, tvItemModel);
        Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
        Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
        Assert.Equal(errMessage, CSSPLogService.ErrRes.ErrList[0]);
    }
}

