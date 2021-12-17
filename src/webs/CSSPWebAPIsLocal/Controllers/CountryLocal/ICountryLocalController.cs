namespace CSSPWebAPIsLocal.Controllers;

public partial interface ICountryLocalController
{
    Task<ActionResult<TVItemModel>> AddCountryLocalAsync(int ParentTVItemID);
    Task<ActionResult<TVItemModel>> DeleteCountryLocalAsync(int TVItemID);
    Task<ActionResult<TVItemModel>> ModifyTVTextCountryLocalAsync(ttt obj);
}

public class ttt
{
    public int TVItemID { get; set; }
    public string TVTextEN { get; set; }
    public string TVTextFR { get; set; }

}