namespace CSSPWebAPIsLocal.Controllers;

public partial interface ILoggedInContactController
{
    Task<ActionResult<Contact>> GetContactAsync();
}
