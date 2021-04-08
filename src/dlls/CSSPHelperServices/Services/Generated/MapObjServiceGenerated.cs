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
    public interface IMapObjService
    {
        bool Validate(ValidationContext validationContext);
    }
    public partial class MapObjService : IMapObjService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private List<ValidationResult> ValidationResults { get; set; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public MapObjService(IEnums enums)
        {
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public bool Validate(ValidationContext validationContext)
        {
            string retStr = "";
            MapObj mapObj = validationContext.ObjectInstance as MapObj;

            if (mapObj.MapInfoID < 1)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "MapInfoID", "1"), new[] { "MapInfoID" }));
            }

            retStr = enums.EnumTypeOK(typeof(MapInfoDrawTypeEnum), (int?)mapObj.MapInfoDrawType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfoDrawType"), new[] { "MapInfoDrawType" }));
            }

            if (!string.IsNullOrWhiteSpace(mapObj.MapInfoDrawTypeText) && mapObj.MapInfoDrawTypeText.Length > 100)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "MapInfoDrawTypeText", "100"), new[] { "MapInfoDrawTypeText" }));
            }

                //CSSPError: Type not implemented [CoordList] of type [List`1]

                //CSSPError: Type not implemented [CoordList] of type [Coord]
            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions public
    }

}
