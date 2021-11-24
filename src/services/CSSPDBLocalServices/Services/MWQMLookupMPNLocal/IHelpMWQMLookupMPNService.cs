namespace CSSPDBLocalServices;

public partial interface IMWQMLookupMPNLocalService
{
    Task<ActionResult<MWQMLookupMPN>> ModifyMWQMLookupMPNLocalAsync(MWQMLookupMPN mwqmLookupMPN);
}
