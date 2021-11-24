namespace CSSPDBLocalServices;


public partial interface ITelLocalService
{
    Task<ActionResult<Tel>> AddTelLocalAsync(Tel tel);
}
