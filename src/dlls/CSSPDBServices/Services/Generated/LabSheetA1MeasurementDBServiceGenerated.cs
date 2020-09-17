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
using LoggedInServices;
using Microsoft.Extensions.Configuration;

namespace CSSPDBServices
{
    public interface ILabSheetA1MeasurementService
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
    public partial class LabSheetA1MeasurementService : ILabSheetA1MeasurementService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public LabSheetA1MeasurementService(ICSSPCultureService CSSPCultureService, IEnums enums)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            string retStr = "";
            LabSheetA1Measurement labSheetA1Measurement = validationContext.ObjectInstance as LabSheetA1Measurement;

            if (string.IsNullOrWhiteSpace(labSheetA1Measurement.Site))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Site"), new[] { nameof(labSheetA1Measurement.Site) });
            }

            //Site has no StringLength Attribute

            if (labSheetA1Measurement.TVItemID < 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "TVItemID", "1"), new[] { nameof(labSheetA1Measurement.TVItemID) });
            }

            //MPN has no Range Attribute

            //Tube10 has no Range Attribute

            //Tube1_0 has no Range Attribute

            //Tube0_1 has no Range Attribute

            //Salinity has no Range Attribute

            //Temperature has no Range Attribute

            //ProcessedBy has no StringLength Attribute

            if (labSheetA1Measurement.SampleType != null)
            {
                retStr = enums.EnumTypeOK(typeof(SampleTypeEnum), (int?)labSheetA1Measurement.SampleType);
                if (labSheetA1Measurement.SampleType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SampleType"), new[] { nameof(labSheetA1Measurement.SampleType) });
                }
            }

            if (string.IsNullOrWhiteSpace(labSheetA1Measurement.SiteComment))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "SiteComment"), new[] { nameof(labSheetA1Measurement.SiteComment) });
            }

            //SiteComment has no StringLength Attribute

            if (!string.IsNullOrWhiteSpace(labSheetA1Measurement.SampleTypeText) && labSheetA1Measurement.SampleTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "SampleTypeText", "100"), new[] { nameof(labSheetA1Measurement.SampleTypeText) });
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