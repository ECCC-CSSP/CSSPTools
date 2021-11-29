namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebProvince/{TVItemID:int}")]
    [HttpGet]
    public async Task<ActionResult<WebProvince>> WebProvinceAsync(int TVItemID)
    {
        // TVItemID = ProvinceTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);
    }
}

