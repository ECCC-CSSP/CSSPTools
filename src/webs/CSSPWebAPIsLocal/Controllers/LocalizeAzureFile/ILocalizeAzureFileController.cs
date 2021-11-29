namespace CSSPWebAPIsLocal.Controllers;

public partial interface ILocalizeAzureFileController
{
    Task<ActionResult<bool>> LocalizeAzureFileAsync(int ParentTVItemID, string FileName);
}
