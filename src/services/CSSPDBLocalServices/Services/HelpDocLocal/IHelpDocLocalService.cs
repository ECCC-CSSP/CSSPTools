namespace CSSPDBLocalServices;

public partial interface IHelpDocLocalService
{
    Task<ActionResult<HelpDoc>> AddHelpDocLocalAsync(HelpDoc helpDoc);
    Task<ActionResult<HelpDoc>> DeleteHelpDocLocalAsync(HelpDoc helpDoc);
    Task<ActionResult<HelpDoc>> ModifyHelpDocLocalAsync(HelpDoc helpDoc);
}
