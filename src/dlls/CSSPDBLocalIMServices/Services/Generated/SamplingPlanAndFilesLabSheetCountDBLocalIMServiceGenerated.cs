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
    public interface ISamplingPlanAndFilesLabSheetCountService
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
    public partial class SamplingPlanAndFilesLabSheetCountService : ISamplingPlanAndFilesLabSheetCountService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public SamplingPlanAndFilesLabSheetCountService(ICSSPCultureService CSSPCultureService, IEnums enums)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            SamplingPlanAndFilesLabSheetCount samplingPlanAndFilesLabSheetCount = validationContext.ObjectInstance as SamplingPlanAndFilesLabSheetCount;

            if (samplingPlanAndFilesLabSheetCount.LabSheetHistoryCount < 0)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "LabSheetHistoryCount", "0"), new[] { nameof(samplingPlanAndFilesLabSheetCount.LabSheetHistoryCount) });
            }

            if (samplingPlanAndFilesLabSheetCount.LabSheetTransferredCount < 0)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "LabSheetTransferredCount", "0"), new[] { nameof(samplingPlanAndFilesLabSheetCount.LabSheetTransferredCount) });
            }

                //CSSPError: Type not implemented [SamplingPlan] of type [SamplingPlan]

                //CSSPError: Type not implemented [SamplingPlan] of type [SamplingPlan]
                //CSSPError: Type not implemented [TVFileSamplingPlanFileTXT] of type [TVFile]

                //CSSPError: Type not implemented [TVFileSamplingPlanFileTXT] of type [TVFile]
            bool a = false;
            if (a)
            {
                yield return new ValidationResult("");
            }
        }
        #endregion Functions public
    }

}
