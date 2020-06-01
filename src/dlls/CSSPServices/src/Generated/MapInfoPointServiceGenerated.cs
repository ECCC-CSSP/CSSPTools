/*
 * Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPServices
{
   public interface IMapInfoPointService
    {
       Task<ActionResult<MapInfoPoint>> GetMapInfoPointWithMapInfoPointID(int MapInfoPointID);
       Task<ActionResult<List<MapInfoPoint>>> GetMapInfoPointList();
       Task<ActionResult<MapInfoPoint>> Add(MapInfoPoint mapinfopoint);
       Task<ActionResult<MapInfoPoint>> Delete(MapInfoPoint mapinfopoint);
       Task<ActionResult<MapInfoPoint>> Update(MapInfoPoint mapinfopoint);
       Task SetCulture(CultureInfo culture);
    }
    public partial class MapInfoPointService : ControllerBase, IMapInfoPointService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public MapInfoPointService(IEnums enums, CSSPDBContext db)
        {
            this.db = db;
            this.enums = enums;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<MapInfoPoint>> GetMapInfoPointWithMapInfoPointID(int MapInfoPointID)
        {
            MapInfoPoint mapinfopoint = (from c in db.MapInfoPoints.AsNoTracking()
                    where c.MapInfoPointID == MapInfoPointID
                    select c).FirstOrDefault();

            if (mapinfopoint == null)
            {
               return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(mapinfopoint));
        }
        public async Task<ActionResult<List<MapInfoPoint>>> GetMapInfoPointList()
        {
            List<MapInfoPoint> mapinfopointList = (from c in db.MapInfoPoints.AsNoTracking() select c).Take(100).ToList();

            return await Task.FromResult(Ok(mapinfopointList));
        }
        public async Task<ActionResult<MapInfoPoint>> Add(MapInfoPoint mapInfoPoint)
        {
            mapInfoPoint.ValidationResults = Validate(new ValidationContext(mapInfoPoint), ActionDBTypeEnum.Create);
            if (mapInfoPoint.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(mapInfoPoint.ValidationResults));
            }

            try
            {
               db.MapInfoPoints.Add(mapInfoPoint);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mapInfoPoint));
        }
        public async Task<ActionResult<MapInfoPoint>> Delete(MapInfoPoint mapInfoPoint)
        {
            mapInfoPoint.ValidationResults = Validate(new ValidationContext(mapInfoPoint), ActionDBTypeEnum.Delete);
            if (mapInfoPoint.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(mapInfoPoint.ValidationResults));
            }

            try
            {
               db.MapInfoPoints.Remove(mapInfoPoint);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mapInfoPoint));
        }
        public async Task<ActionResult<MapInfoPoint>> Update(MapInfoPoint mapInfoPoint)
        {
            mapInfoPoint.ValidationResults = Validate(new ValidationContext(mapInfoPoint), ActionDBTypeEnum.Update);
            if (mapInfoPoint.ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(mapInfoPoint.ValidationResults));
            }

            try
            {
               db.MapInfoPoints.Update(mapInfoPoint);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(mapInfoPoint));
        }
        public async Task SetCulture(CultureInfo culture)
        {
            CSSPServicesRes.Culture = culture;
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            MapInfoPoint mapInfoPoint = validationContext.ObjectInstance as MapInfoPoint;
            mapInfoPoint.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mapInfoPoint.MapInfoPointID == 0)
                {
                    mapInfoPoint.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MapInfoPointID"), new[] { "MapInfoPointID" });
                }

                if (!(from c in db.MapInfoPoints select c).Where(c => c.MapInfoPointID == mapInfoPoint.MapInfoPointID).Any())
                {
                    mapInfoPoint.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MapInfoPoint", "MapInfoPointID", mapInfoPoint.MapInfoPointID.ToString()), new[] { "MapInfoPointID" });
                }
            }

            MapInfo MapInfoMapInfoID = (from c in db.MapInfos where c.MapInfoID == mapInfoPoint.MapInfoID select c).FirstOrDefault();

            if (MapInfoMapInfoID == null)
            {
                mapInfoPoint.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MapInfo", "MapInfoID", mapInfoPoint.MapInfoID.ToString()), new[] { "MapInfoID" });
            }

            if (mapInfoPoint.Ordinal < 0)
            {
                mapInfoPoint.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "Ordinal", "0"), new[] { "Ordinal" });
            }

            if (mapInfoPoint.Lat < -90 || mapInfoPoint.Lat > 90)
            {
                mapInfoPoint.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Lat", "-90", "90"), new[] { "Lat" });
            }

            if (mapInfoPoint.Lng < -180 || mapInfoPoint.Lng > 180)
            {
                mapInfoPoint.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Lng", "-180", "180"), new[] { "Lng" });
            }

            if (mapInfoPoint.LastUpdateDate_UTC.Year == 1)
            {
                mapInfoPoint.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mapInfoPoint.LastUpdateDate_UTC.Year < 1980)
                {
                mapInfoPoint.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mapInfoPoint.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mapInfoPoint.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mapInfoPoint.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mapInfoPoint.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                mapInfoPoint.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Functions private

    }
}
