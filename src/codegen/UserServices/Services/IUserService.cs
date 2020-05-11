using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using UserServices.Models;

namespace UserServices.Services
{
    public interface IUserService
    {
        //Task CreateUser();
        Task<ActionResult<UserModel>> CheckPassword(LoginModel loginModel);
        Task SetCulture(CultureInfo culture);
    }
}