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
    public interface ILabSheetA1MeasurementService
    {
        ErrRes errRes { get; set; }

        bool Validate(ValidationContext validationContext);
    }
    public partial class LabSheetA1MeasurementService : ILabSheetA1MeasurementService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public ErrRes errRes { get; set; } = new ErrRes();
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public LabSheetA1MeasurementService(IEnums enums)
        {
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public bool Validate(ValidationContext validationContext)
        {
            string retStr = "";
            LabSheetA1Measurement labSheetA1Measurement = validationContext.ObjectInstance as LabSheetA1Measurement;

            if (string.IsNullOrWhiteSpace(labSheetA1Measurement.Site))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Site"));
            }

            //Site has no StringLength Attribute

            if (labSheetA1Measurement.TVItemID < 1)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MinValueIs_, "TVItemID", "1"));
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
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "SampleType"));
                }
            }

            if (string.IsNullOrWhiteSpace(labSheetA1Measurement.SiteComment))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "SiteComment"));
            }

            if (!string.IsNullOrWhiteSpace(labSheetA1Measurement.SiteComment) && labSheetA1Measurement.SiteComment.Length > 100000)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "SiteComment", "100000"));
            }

            if (!string.IsNullOrWhiteSpace(labSheetA1Measurement.SampleTypeText) && labSheetA1Measurement.SampleTypeText.Length > 100)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "SampleTypeText", "100"));
            }

            return errRes.ErrList.Count == 0 ? true : false;
        }
        #endregion Functions public
    }

}
