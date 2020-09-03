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
   public partial interface IAddressDBService
    {
       Task<ActionResult<bool>> Delete(int AddressID);
       Task<ActionResult<List<Address>>> GetAddressList(int skip = 0, int take = 100);
       Task<ActionResult<Address>> GetAddressWithAddressID(int AddressID);
       Task<ActionResult<Address>> Post(Address address);
       Task<ActionResult<Address>> Put(Address address);
    }
    public partial class AddressDBService : ControllerBase, IAddressDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public AddressDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, 
           ILoggedInService LoggedInService, 
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<Address>> GetAddressWithAddressID(int AddressID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            Address address = (from c in db.Addresses.AsNoTracking()
                    where c.AddressID == AddressID
                    select c).FirstOrDefault();

            if (address == null)
            {
               return await Task.FromResult(NotFound(""));
            }

            return await Task.FromResult(Ok(address));
        }
        public async Task<ActionResult<List<Address>>> GetAddressList(int skip = 0, int take = 100)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            List<Address> addressList = (from c in db.Addresses.AsNoTracking() orderby c.AddressID select c).Skip(skip).Take(take).ToList();

            return await Task.FromResult(Ok(addressList));
        }
        public async Task<ActionResult<bool>> Delete(int AddressID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            Address address = (from c in db.Addresses
                               where c.AddressID == AddressID
                                   select c).FirstOrDefault();
            
            if (address == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Address", "AddressID", AddressID.ToString())));
            }

            try
            {
               db.Addresses.Remove(address);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<Address>> Post(Address address)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(address), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.Addresses.Add(address);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(address));
        }
        public async Task<ActionResult<Address>> Put(Address address)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(address), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            try
            {
               db.Addresses.Update(address);
               db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(address));
        }
        #endregion Functions public

        #region Functions private
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Address address = validationContext.ObjectInstance as Address;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (address.AddressID == 0)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AddressID"), new[] { nameof(address.AddressID) });
                }

                if (!(from c in db.Addresses select c).Where(c => c.AddressID == address.AddressID).Any())
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Address", "AddressID", address.AddressID.ToString()), new[] { nameof(address.AddressID) });
                }
            }

            TVItem TVItemAddressTVItemID = null;
            TVItemAddressTVItemID = (from c in db.TVItems where c.TVItemID == address.AddressTVItemID select c).FirstOrDefault();

            if (TVItemAddressTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "AddressTVItemID", address.AddressTVItemID.ToString()), new[] { nameof(address.AddressTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Address,
                };
                if (!AllowableTVTypes.Contains(TVItemAddressTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "AddressTVItemID", "Address"), new[] { nameof(address.AddressTVItemID) });
                }
            }

            retStr = enums.EnumTypeOK(typeof(AddressTypeEnum), (int?)address.AddressType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AddressType"), new[] { nameof(address.AddressType) });
            }

            TVItem TVItemCountryTVItemID = null;
            TVItemCountryTVItemID = (from c in db.TVItems where c.TVItemID == address.CountryTVItemID select c).FirstOrDefault();

            if (TVItemCountryTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "CountryTVItemID", address.CountryTVItemID.ToString()), new[] { nameof(address.CountryTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Country,
                };
                if (!AllowableTVTypes.Contains(TVItemCountryTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "CountryTVItemID", "Country"), new[] { nameof(address.CountryTVItemID) });
                }
            }

            TVItem TVItemProvinceTVItemID = null;
            TVItemProvinceTVItemID = (from c in db.TVItems where c.TVItemID == address.ProvinceTVItemID select c).FirstOrDefault();

            if (TVItemProvinceTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "ProvinceTVItemID", address.ProvinceTVItemID.ToString()), new[] { nameof(address.ProvinceTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Province,
                };
                if (!AllowableTVTypes.Contains(TVItemProvinceTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "ProvinceTVItemID", "Province"), new[] { nameof(address.ProvinceTVItemID) });
                }
            }

            TVItem TVItemMunicipalityTVItemID = null;
            TVItemMunicipalityTVItemID = (from c in db.TVItems where c.TVItemID == address.MunicipalityTVItemID select c).FirstOrDefault();

            if (TVItemMunicipalityTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MunicipalityTVItemID", address.MunicipalityTVItemID.ToString()), new[] { nameof(address.MunicipalityTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Municipality,
                };
                if (!AllowableTVTypes.Contains(TVItemMunicipalityTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "MunicipalityTVItemID", "Municipality"), new[] { nameof(address.MunicipalityTVItemID) });
                }
            }

            if (!string.IsNullOrWhiteSpace(address.StreetName) && address.StreetName.Length > 200)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StreetName", "200"), new[] { nameof(address.StreetName) });
            }

            if (!string.IsNullOrWhiteSpace(address.StreetNumber) && address.StreetNumber.Length > 50)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StreetNumber", "50"), new[] { nameof(address.StreetNumber) });
            }

            if (address.StreetType != null)
            {
                retStr = enums.EnumTypeOK(typeof(StreetTypeEnum), (int?)address.StreetType);
                if (address.StreetType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "StreetType"), new[] { nameof(address.StreetType) });
                }
            }

            if (!string.IsNullOrWhiteSpace(address.PostalCode) && (address.PostalCode.Length < 6 || address.PostalCode.Length > 11))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "PostalCode", "6", "11"), new[] { nameof(address.PostalCode) });
            }

            if (!string.IsNullOrWhiteSpace(address.GoogleAddressText) && (address.GoogleAddressText.Length < 10 || address.GoogleAddressText.Length > 200))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "GoogleAddressText", "10", "200"), new[] { nameof(address.GoogleAddressText) });
            }

            if (address.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { nameof(address.LastUpdateDate_UTC) });
            }
            else
            {
                if (address.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { nameof(address.LastUpdateDate_UTC) });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == address.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", address.LastUpdateContactTVItemID.ToString()), new[] { nameof(address.LastUpdateContactTVItemID) });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { nameof(address.LastUpdateContactTVItemID) });
                }
            }

        }
        #endregion Functions private

    }
}
