namespace CSSPDBLocalServices;

public partial interface IAddressLocalService
{
    Task<ActionResult<Address>> AddAddressLocalAsync(Address address);
}
