/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPEnums;
using LoggedInServices;
using ManageServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CSSPLogServices.Models;
using System.Reflection;

namespace CSSPLogServices
{
    public partial class CSSPLogService : ControllerBase, ICSSPLogService
    {
        public string GetFunctionName(string FullFunctionName)
        {
            string FunctionName = FullFunctionName;
            FunctionName = FunctionName.Substring(FunctionName.IndexOf("<") + 1);
            FunctionName = FunctionName.Substring(0, FunctionName.IndexOf(">"));

            return FunctionName;
        }
    }
}
