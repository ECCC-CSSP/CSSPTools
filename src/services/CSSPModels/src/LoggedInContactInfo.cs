namespace CSSPModels;

[NotMapped]
public partial class LoggedInContactInfo
{
    public Contact LoggedInContact { get; set; }
    public List<TVTypeUserAuthorization> TVTypeUserAuthorizationList { get; set; }
    public List<TVItemUserAuthorization> TVItemUserAuthorizationList { get; set; }

    public LoggedInContactInfo() : base()
    {
        TVTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
        TVItemUserAuthorizationList = new List<TVItemUserAuthorization>();
    }
}

