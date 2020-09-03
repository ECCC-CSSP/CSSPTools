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

namespace CSSPServices
{
    public interface IMapObjService
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
    public partial class MapObjService : IMapObjService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public MapObjService(ICSSPCultureService CSSPCultureService, IEnums enums)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            string retStr = "";
            MapObj mapObj = validationContext.ObjectInstance as MapObj;

            if (mapObj.MapInfoID < 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "MapInfoID", "1"), new[] { nameof(mapObj.MapInfoID) });
            }

            retStr = enums.EnumTypeOK(typeof(MapInfoDrawTypeEnum), (int?)mapObj.MapInfoDrawType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "MapInfoDrawType"), new[] { nameof(mapObj.MapInfoDrawType) });
            }

            if (!string.IsNullOrWhiteSpace(mapObj.MapInfoDrawTypeText) && mapObj.MapInfoDrawTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "MapInfoDrawTypeText", "100"), new[] { nameof(mapObj.MapInfoDrawTypeText) });
            }

                //CSSPError: Type not implemented [CoordList] of type [List`1]

                //CSSPError: Type not implemented [CoordList] of type [Coord]
            bool a = false;
            if (a)
            {
                yield return new ValidationResult("");
            }
        }
        #endregion Functions public

    }
}
