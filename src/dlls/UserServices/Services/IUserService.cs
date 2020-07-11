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
        //Task<ActionResult<bool>> RegisterUser(RegisterModel registerModel);
        Task<ActionResult<UserModel>> Login(LoginModel loginModel);
    }
}