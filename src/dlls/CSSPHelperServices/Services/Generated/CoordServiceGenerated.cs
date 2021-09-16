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
    public interface ICoordService
    {
        ErrRes errRes { get; set; }

        bool Validate(ValidationContext validationContext);
    }
    public partial class CoordService : ICoordService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public ErrRes errRes { get; set; } = new ErrRes();
        #endregion Properties

        #region Constructors
        public CoordService()
        {
        }
        #endregion Constructors

        #region Functions public
        public bool Validate(ValidationContext validationContext)
        {
            Coord coord = validationContext.ObjectInstance as Coord;

            if (coord.Lat < -180 || coord.Lat > 180)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Lat", "-180", "180"));
            }

            if (coord.Lng < -90 || coord.Lng > 90)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Lng", "-90", "90"));
            }

            if (coord.Ordinal < 0 || coord.Ordinal > 10000)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "10000"));
            }

            return errRes.ErrList.Count == 0 ? true : false;
        }
        #endregion Functions public
    }

}
