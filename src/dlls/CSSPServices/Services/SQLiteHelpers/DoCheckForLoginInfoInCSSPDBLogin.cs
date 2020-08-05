using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        private async Task<bool> DoCheckForLoginInfoInCSSPDBLogin()
        {
            Contact contact = (from c in dbLogin.Contacts
                               select c).FirstOrDefault();

            if (contact == null)
            {
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
