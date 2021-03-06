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
    public interface ITVItemInfrastructureTypeTVItemLinkService
    {
        bool Validate(ValidationContext validationContext);
        List<ValidationResult> ValidationResults { get; set; }
    }
    public partial class TVItemInfrastructureTypeTVItemLinkService : ITVItemInfrastructureTypeTVItemLinkService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public List<ValidationResult> ValidationResults { get; set; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public TVItemInfrastructureTypeTVItemLinkService(IEnums enums)
        {
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public bool Validate(ValidationContext validationContext)
        {
            ValidationResults = new List<ValidationResult>();

            string retStr = "";
            TVItemInfrastructureTypeTVItemLink tvItemInfrastructureTypeTVItemLink = validationContext.ObjectInstance as TVItemInfrastructureTypeTVItemLink;

            retStr = enums.EnumTypeOK(typeof(InfrastructureTypeEnum), (int?)tvItemInfrastructureTypeTVItemLink.InfrastructureType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "InfrastructureType"), new[] { "InfrastructureType" }));
            }

            //SeeOtherMunicipalityTVItemID has no Range Attribute

            if (!string.IsNullOrWhiteSpace(tvItemInfrastructureTypeTVItemLink.InfrastructureTypeText) && tvItemInfrastructureTypeTVItemLink.InfrastructureTypeText.Length > 100)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "InfrastructureTypeText", "100"), new[] { "InfrastructureTypeText" }));
            }

                //CSSPError: Type not implemented [TVItem] of type [TVItem]

                //CSSPError: Type not implemented [TVItem] of type [TVItem]
                //CSSPError: Type not implemented [TVItemLinkList] of type [List`1]

                //CSSPError: Type not implemented [TVItemLinkList] of type [TVItemLink]
                //CSSPError: Type not implemented [FlowTo] of type [TVItemInfrastructureTypeTVItemLink]

                //CSSPError: Type not implemented [FlowTo] of type [TVItemInfrastructureTypeTVItemLink]
            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions public
    }

}
