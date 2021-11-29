namespace CSSPWebAPIsLocal.Controllers;

public partial interface IVersionController
{
    Task<string> GetVersionAsync();
}
