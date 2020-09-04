/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */

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
using LocalServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBLocalIMServices
{
    public interface ISubsectorMWQMSampleYearService
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
    public partial class SubsectorMWQMSampleYearService : ISubsectorMWQMSampleYearService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public SubsectorMWQMSampleYearService(ICSSPCultureService CSSPCultureService, IEnums enums)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            SubsectorMWQMSampleYear subsectorMWQMSampleYear = validationContext.ObjectInstance as SubsectorMWQMSampleYear;

            if (subsectorMWQMSampleYear.SubsectorTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "SubsectorTVItemID", "1"), new[] { nameof(subsectorMWQMSampleYear.SubsectorTVItemID) });
            }

            //Year has no Range Attribute

            if (subsectorMWQMSampleYear.EarliestDate.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "EarliestDate"), new[] { nameof(subsectorMWQMSampleYear.EarliestDate) });
            }
            else
            {
                if (subsectorMWQMSampleYear.EarliestDate.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EarliestDate", "1980"), new[] { nameof(subsectorMWQMSampleYear.EarliestDate) });
                }
            }

            if (subsectorMWQMSampleYear.LatestDate.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LatestDate"), new[] { nameof(subsectorMWQMSampleYear.LatestDate) });
            }
            else
            {
                if (subsectorMWQMSampleYear.LatestDate.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LatestDate", "1980"), new[] { nameof(subsectorMWQMSampleYear.LatestDate) });
                }
            }

            if (subsectorMWQMSampleYear.EarliestDate > subsectorMWQMSampleYear.LatestDate)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._DateIsBiggerThan_, "LatestDate", "SubsectorMWQMSampleYearEarliestDate"), new[] { nameof(subsectorMWQMSampleYear.LatestDate) });
            }

            bool a = false;
            if (a)
            {
                yield return new ValidationResult("");
            }
        }
        #endregion Functions public
    }

}
