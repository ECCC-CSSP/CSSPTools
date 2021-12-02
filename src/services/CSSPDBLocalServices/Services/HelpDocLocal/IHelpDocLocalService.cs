namespace CSSPDBLocalServices;

public partial interface IHelpDocLocalService
{
    Task<ActionResult<HelpDoc>> AddHelpDocLocalAsync(HelpDoc helpDoc);
    Task<ActionResult<HelpDoc>> DeleteHelpDocLocalAsync(int HelpDocID);
    Task<ActionResult<HelpDoc>> ModifyDocHTMLTextHelpDocLocalAsync(int HelpDocID, string DocHTMLText);
}
