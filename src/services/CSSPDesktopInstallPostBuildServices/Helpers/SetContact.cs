namespace CSSPDesktopInstallPostBuildServices.Services;

public partial class CSSPDesktopInstallPostBuildService : ICSSPDesktopInstallPostBuildService
{
    public void SetContact(Contact contact)
    {
        this.contact = contact;
    }
}

