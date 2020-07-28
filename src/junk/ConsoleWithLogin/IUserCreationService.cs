using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWithLogin.Model
{
    public interface IUserCreationService
    {
        Task CreateUser();
        Task CheckPassword(string LoginEmail, string Password);
    }
}