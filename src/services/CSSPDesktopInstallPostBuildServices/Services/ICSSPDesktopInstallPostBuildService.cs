namespace CSSPDesktopInstallPostBuildServices.Services;

public interface ICSSPDesktopInstallPostBuildService
{
    Task<bool> CSSPOtherFilesCompressAndSendToAzureAsync();
    Task<bool> CSSPWebAPIsLocalCompressAndSendToAzureAsync();
    Task<bool> CSSPClientCompressAndSendToAzureAsync();
    Task<Contact> LoginAsync();
    void SetContact(Contact contact);
}
