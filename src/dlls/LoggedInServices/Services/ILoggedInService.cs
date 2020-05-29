using CSSPModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggedInServices.Services
{
    public interface ILoggedInService
    {
        Task<string> GetID();
        Task SetID(string value);
        Task<Contact> GetContact();
        Task<List<TVItemUserAuthorization>> GetTVItemUserAuthorizationList();
        Task<List<TVTypeUserAuthorization>> GetTVTypeUserAuthorizationList();
    }
}
