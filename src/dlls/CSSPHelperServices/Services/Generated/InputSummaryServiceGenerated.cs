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
    public interface IInputSummaryService
    {
        ErrRes errRes { get; set; }

        bool Validate(ValidationContext validationContext);
    }
    public partial class InputSummaryService : IInputSummaryService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public ErrRes errRes { get; set; } = new ErrRes();
        #endregion Properties

        #region Constructors
        public InputSummaryService()
        {
        }
        #endregion Constructors

        #region Functions public
        public bool Validate(ValidationContext validationContext)
        {
            InputSummary inputSummary = validationContext.ObjectInstance as InputSummary;

            if (string.IsNullOrWhiteSpace(inputSummary.Summary))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Summary"));
            }

            if (!string.IsNullOrWhiteSpace(inputSummary.Summary) && inputSummary.Summary.Length > 1000000)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Summary", "1000000"));
            }

            return errRes.ErrList.Count == 0 ? true : false;
        }
        #endregion Functions public
    }

}
