namespace CSSPDBLocalServices;

public partial interface IEmailLocalService
{
    Task<ActionResult<Email>> AddEmailLocalAsync(Email email);
}
