using CSSPModels;
using System.Threading.Tasks;

namespace LoggedInServices.Services
{
    public interface ILoggedInService
    {
        Task<bool> SetLoggedInContactInfo(string Id);
        Task<LoggedInContactInfo> GetLoggedInContactInfo();
    }
}
