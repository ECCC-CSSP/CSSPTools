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
   public partial interface IBoxModelService
    {
       Task<ActionResult<bool>> Delete(int BoxModelID);
       Task<ActionResult<List<BoxModel>>> GetBoxModelList(int skip = 0, int take = 100);
       Task<ActionResult<BoxModel>> GetBoxModelWithBoxModelID(int BoxModelID);
       Task<ActionResult<BoxModel>> Post(BoxModel boxmodel);
       Task<ActionResult<BoxModel>> Put(BoxModel boxmodel);
    }
    public partial class BoxModelService : ControllerBase, IBoxModelService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private InMemoryDBContext dbIM { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
            this.dbLocal = dbLocal;
            this.dbIM = dbIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<BoxModel>> GetBoxModelWithBoxModelID(int BoxModelID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                BoxModel boxModel = (from c in dbIM.BoxModels.AsNoTracking()
                                   where c.BoxModelID == BoxModelID
                                   select c).FirstOrDefault();

                if (boxModel == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(boxModel));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                BoxModel boxModel = (from c in dbLocal.BoxModels.AsNoTracking()
                        where c.BoxModelID == BoxModelID
                        select c).FirstOrDefault();

                if (boxModel == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(boxModel));
            }
            else
            {
                BoxModel boxModel = (from c in db.BoxModels.AsNoTracking()
                        where c.BoxModelID == BoxModelID
                        select c).FirstOrDefault();

                if (boxModel == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(boxModel));
            }
        }
        public async Task<ActionResult<List<BoxModel>>> GetBoxModelList(int skip = 0, int take = 100)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<BoxModel> boxModelList = (from c in dbIM.BoxModels.AsNoTracking() orderby c.BoxModelID select c).Skip(skip).Take(take).ToList();
            
                return await Task.FromResult(Ok(boxModelList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<BoxModel> boxModelList = (from c in dbLocal.BoxModels.AsNoTracking() orderby c.BoxModelID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(boxModelList));
            }
            else
            {
                List<BoxModel> boxModelList = (from c in db.BoxModels.AsNoTracking() orderby c.BoxModelID select c).Skip(skip).Take(take).ToList();

                return await Task.FromResult(Ok(boxModelList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int BoxModelID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                BoxModel boxModel = (from c in dbIM.BoxModels
                                   where c.BoxModelID == BoxModelID
                                   select c).FirstOrDefault();
            
                if (boxModel == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "BoxModel", "BoxModelID", BoxModelID.ToString())));
                }
            
                try
                {
                    dbIM.BoxModels.Remove(boxModel);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }
            
                return await Task.FromResult(Ok(true));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                BoxModel boxModel = (from c in dbLocal.BoxModels
                                   where c.BoxModelID == BoxModelID
                                   select c).FirstOrDefault();
                
                if (boxModel == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "BoxModel", "BoxModelID", BoxModelID.ToString())));
                }

                try
                {
                   dbLocal.BoxModels.Remove(boxModel);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
            else
            {
                BoxModel boxModel = (from c in db.BoxModels
                                   where c.BoxModelID == BoxModelID
                                   select c).FirstOrDefault();
                
                if (boxModel == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "BoxModel", "BoxModelID", BoxModelID.ToString())));
                }

                try
                {
                   db.BoxModels.Remove(boxModel);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(true));
            }
        }
        public async Task<ActionResult<BoxModel>> Post(BoxModel boxModel)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(boxModel), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.BoxModels.Add(boxModel);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(boxModel));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                try
                {
                   dbLocal.BoxModels.Add(boxModel);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(boxModel));
            }
            else
            {
                try
                {
                   db.BoxModels.Add(boxModel);
                   db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(boxModel));
            }
        }
        public async Task<ActionResult<BoxModel>> Put(BoxModel boxModel)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(boxModel), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                try
                {
                    dbIM.BoxModels.Update(boxModel);
                    dbIM.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(boxModel));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
            try
            {
               dbLocal.BoxModels.Update(boxModel);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(boxModel));
            }
            else
            {
            try
            {
               db.BoxModels.Update(boxModel);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(boxModel));
            }
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            BoxModel boxModel = validationContext.ObjectInstance as BoxModel;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (boxModel.BoxModelID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "BoxModelID"), new[] { nameof(boxModel.BoxModelID) });
                }

                if (LoggedInService.DBLocation == DBLocationEnum.Local)
                {
                    if (!(from c in dbLocal.BoxModels select c).Where(c => c.BoxModelID == boxModel.BoxModelID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "BoxModel", "BoxModelID", boxModel.BoxModelID.ToString()), new[] { nameof(boxModel.BoxModelID) });
                    }
                }
                else
                {
                    if (!(from c in db.BoxModels select c).Where(c => c.BoxModelID == boxModel.BoxModelID).Any())
                    {
                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "BoxModel", "BoxModelID", boxModel.BoxModelID.ToString()), new[] { nameof(boxModel.BoxModelID) });
                    }
                }
            }

            TVItem TVItemInfrastructureTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemInfrastructureTVItemID = (from c in dbLocal.TVItems where c.TVItemID == boxModel.InfrastructureTVItemID select c).FirstOrDefault();
                if (TVItemInfrastructureTVItemID == null)
                {
                    TVItemInfrastructureTVItemID = (from c in dbIM.TVItems where c.TVItemID == boxModel.InfrastructureTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemInfrastructureTVItemID = (from c in db.TVItems where c.TVItemID == boxModel.InfrastructureTVItemID select c).FirstOrDefault();
            }

            if (TVItemInfrastructureTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "InfrastructureTVItemID", boxModel.InfrastructureTVItemID.ToString()), new[] { nameof(boxModel.InfrastructureTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Infrastructure,
                };
                if (!AllowableTVTypes.Contains(TVItemInfrastructureTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "InfrastructureTVItemID", "Infrastructure"), new[] { nameof(boxModel.InfrastructureTVItemID) });
                }
            }

            if (boxModel.Discharge_m3_day < 0 || boxModel.Discharge_m3_day > 10000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Discharge_m3_day", "0", "10000"), new[] { nameof(boxModel.Discharge_m3_day) });
            }

            if (boxModel.Depth_m < 0 || boxModel.Depth_m > 1000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Depth_m", "0", "1000"), new[] { nameof(boxModel.Depth_m) });
            }

            if (boxModel.Temperature_C < -15 || boxModel.Temperature_C > 40)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Temperature_C", "-15", "40"), new[] { nameof(boxModel.Temperature_C) });
            }

            if (boxModel.Dilution < 0 || boxModel.Dilution > 10000000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Dilution", "0", "10000000"), new[] { nameof(boxModel.Dilution) });
            }

            if (boxModel.DecayRate_per_day < 0 || boxModel.DecayRate_per_day > 100)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DecayRate_per_day", "0", "100"), new[] { nameof(boxModel.DecayRate_per_day) });
            }

            if (boxModel.FCUntreated_MPN_100ml < 0 || boxModel.FCUntreated_MPN_100ml > 10000000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "FCUntreated_MPN_100ml", "0", "10000000"), new[] { nameof(boxModel.FCUntreated_MPN_100ml) });
            }

            if (boxModel.FCPreDisinfection_MPN_100ml < 0 || boxModel.FCPreDisinfection_MPN_100ml > 10000000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "FCPreDisinfection_MPN_100ml", "0", "10000000"), new[] { nameof(boxModel.FCPreDisinfection_MPN_100ml) });
            }

            if (boxModel.Concentration_MPN_100ml < 0 || boxModel.Concentration_MPN_100ml > 10000000)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Concentration_MPN_100ml", "0", "10000000"), new[] { nameof(boxModel.Concentration_MPN_100ml) });
            }

            if (boxModel.T90_hour < 0)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "T90_hour", "0"), new[] { nameof(boxModel.T90_hour) });
            }

            if (boxModel.DischargeDuration_hour < 0 || boxModel.DischargeDuration_hour > 24)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "DischargeDuration_hour", "0", "24"), new[] { nameof(boxModel.DischargeDuration_hour) });
            }

            if (boxModel.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(boxModel.LastUpdateDate_UTC) });
            }
            else
            {
                if (boxModel.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(boxModel.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == boxModel.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == boxModel.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == boxModel.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", boxModel.LastUpdateContactTVItemID.ToString()), new[] { nameof(boxModel.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(boxModel.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}
