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
        private void ChangeTVItemLanguageVariableValue(TVItem tvItem, TVItemLanguage tvItemLanguage, string variable)
        {
            switch (variable)
            {
                case "DBCommand":
                    {
                        tvItemLanguage.DBCommand = (DBCommandEnum)10000;
                    }
                    break;
                case "TVItemLanguageID":
                    {
                        tvItem.TVItemID = 1;
                        tvItemLanguage.TVItemLanguageID = 0;
                    }
                    break;
                case "TVItemID":
                    {
                        tvItem.TVItemID = 1;
                        tvItemLanguage.TVItemID = 0;
                    }
                    break;
                case "Language":
                    {
                        tvItemLanguage.Language = (LanguageEnum)10000;
                    }
                    break;
                case "TVText":
                    {
                        tvItemLanguage.TVText = "";
                    }
                    break;
                case "TranslationStatus":
                    {
                        tvItemLanguage.TranslationStatus = (TranslationStatusEnum)10000;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
