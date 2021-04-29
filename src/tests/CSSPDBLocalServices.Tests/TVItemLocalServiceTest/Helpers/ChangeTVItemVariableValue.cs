/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPDBPreferenceModels;
using CSSPEnums;
using CSSPHelperModels;
using CSSPScrambleServices;
using CSSPWebModels;
using LoggedInServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private void ChangeTVItemVariableValue(TVItem tvItem, string variable)
        {
            switch (variable)
            {
                case "DBCommand":
                    {
                        tvItem.DBCommand = (DBCommandEnum)10000;
                    }
                    break;
                case "TVType":
                    {
                        tvItem.TVType = (TVTypeEnum)10000;
                    }
                    break;
                case "TVLevel":
                    {
                        tvItem.TVLevel = 0;
                    }
                    break;
                case "TVPath":
                    {
                        tvItem.TVPath = "";
                    }
                    break;
                case "ParentID":
                    {
                        tvItem.ParentID = 0;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
