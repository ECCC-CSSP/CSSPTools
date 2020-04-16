using CSSPCodeGenWebAPI.Controllers;
using CSSPCodeGenWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSSPCodeGenWebAPI.Model
{
    public interface IUserService
    {
        //Task CreateUser();
        Task<UserModel> CheckPassword(LoginModel loginModel);
    }
}