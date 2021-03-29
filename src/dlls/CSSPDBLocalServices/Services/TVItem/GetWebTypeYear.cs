/*
 * Manually edited
 *
 */

using CSSPEnums;
using CSSPDBModels;
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
using LoggedInServices;
using Microsoft.Extensions.Configuration;
using ReadGzFileServices;
using CSSPWebModels;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using CreateGzFileLocalServices;

namespace CSSPDBLocalServices
{

    public partial class TVItemService : ControllerBase, ITVItemService
    {
        private WebTypeYearEnum GetWebTypeYear(int year)
        {
            if (year > 2050)
            {
                return WebTypeYearEnum.Year2050;
            }
            else if (year > 2040)
            {
                return WebTypeYearEnum.Year2040;
            }
            else if (year > 2030)
            {
                return WebTypeYearEnum.Year2030;
            }
            else if (year > 2020)
            {
                return WebTypeYearEnum.Year2020;
            }
            else if (year > 2010)
            {
                return WebTypeYearEnum.Year2010;
            }
            else if (year > 2000)
            {
                return WebTypeYearEnum.Year2000;
            }
            else if (year > 1990)
            {
                return WebTypeYearEnum.Year1990;
            }
            else
            {
                return WebTypeYearEnum.Year1980;
            }
        }
    }
}