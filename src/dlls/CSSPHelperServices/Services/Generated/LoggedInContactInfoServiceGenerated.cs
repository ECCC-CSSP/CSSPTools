/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPHelperServices.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPHelperModels;
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

namespace CSSPHelperServices
{
    public interface ILoggedInContactInfoService
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
    public partial class LoggedInContactInfoService : ILoggedInContactInfoService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LoggedInContactInfoService()
        {
        }
        #endregion Constructors

        #region Functions public
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            LoggedInContactInfo loggedInContactInfo = validationContext.ObjectInstance as LoggedInContactInfo;

                //CSSPError: Type not implemented [LoggedInContact] of type [Contact]

                //CSSPError: Type not implemented [LoggedInContact] of type [Contact]
                //CSSPError: Type not implemented [TVTypeUserAuthorizationList] of type [List`1]

                //CSSPError: Type not implemented [TVTypeUserAuthorizationList] of type [TVTypeUserAuthorization]
                //CSSPError: Type not implemented [TVItemUserAuthorizationList] of type [List`1]

                //CSSPError: Type not implemented [TVItemUserAuthorizationList] of type [TVItemUserAuthorization]

            bool a = false;
            if (a)
            {
                yield return new ValidationResult("");
            }
        }
        #endregion Functions public
    }

}
