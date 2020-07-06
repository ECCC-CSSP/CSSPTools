/*
 * Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Resources;
using CultureServices.Services;
using LoggedInServices.Services;
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
   public interface IAddressService
    {
       Task<ActionResult<bool>> Delete(int AddressID);
       Task<ActionResult<List<Address>>> GetAddressList();
       Task<ActionResult<Address>> GetAddressWithAddressID(int AddressID);
       Task<ActionResult<Address>> Post(Address address);
       Task<ActionResult<Address>> Put(Address address);
    }
    public partial class AddressService : ControllerBase, IAddressService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private InMemoryDBContext dbIM { get; }
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public AddressService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
            this.dbLocal = dbLocal;
            this.dbIM = dbIM;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<Address>> GetAddressWithAddressID(int AddressID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                Address address = (from c in dbLocal.Addresses.AsNoTracking()
                        where c.AddressID == AddressID
                        select c).FirstOrDefault();

                if (address == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(address));
            }
            else
            {
                Address address = (from c in db.Addresses.AsNoTracking()
                        where c.AddressID == AddressID
                        select c).FirstOrDefault();

                if (address == null)
                {
                   return await Task.FromResult(NotFound());
                }

                return await Task.FromResult(Ok(address));
            }
        }
        public async Task<ActionResult<List<Address>>> GetAddressList()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                List<Address> addressList = (from c in dbLocal.Addresses.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(addressList));
            }
            else
            {
                List<Address> addressList = (from c in db.Addresses.AsNoTracking() select c).Take(100).ToList();

                return await Task.FromResult(Ok(addressList));
            }
        }
        public async Task<ActionResult<bool>> Delete(int AddressID)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.IsLocal)
            {
                Address address = (from c in dbLocal.Addresses
                                   where c.AddressID == AddressID
                                   select c).FirstOrDefault();
                
                if (address == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Address", "AddressID", AddressID.ToString())));
                }

                try
                {
                   dbLocal.Addresses.Remove(address);
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
                Address address = (from c in db.Addresses
                                   where c.AddressID == AddressID
                                   select c).FirstOrDefault();
                
                if (address == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Address", "AddressID", AddressID.ToString())));
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
        }
        public async Task<ActionResult<Address>> Post(Address address)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(address), ActionDBTypeEnum.Create);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
            {
                try
                {
                   dbLocal.Addresses.Add(address);
                   dbLocal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
                }

                return await Task.FromResult(Ok(address));
            }
            else
            {
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
        }
        public async Task<ActionResult<Address>> Put(Address address)
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            ValidationResults = Validate(new ValidationContext(address), ActionDBTypeEnum.Update);
            if (ValidationResults.Count() > 0)
            {
               return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (LoggedInService.IsLocal)
            {
            try
            {
               dbLocal.Addresses.Update(address);
               dbLocal.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(address));
            }
            else
            {
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
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "AddressID"), new[] { "AddressID" });
                }

                if (LoggedInService.IsLocal)
                {
                    if (!(from c in dbLocal.Addresses select c).Where(c => c.AddressID == address.AddressID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Address", "AddressID", address.AddressID.ToString()), new[] { "AddressID" });
                    }
                }
                else
                {
                    if (!(from c in db.Addresses select c).Where(c => c.AddressID == address.AddressID).Any())
                    {
                        yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "Address", "AddressID", address.AddressID.ToString()), new[] { "AddressID" });
                    }
                }
            }

            TVItem TVItemAddressTVItemID = null;
            if (LoggedInService.IsLocal)
            {
                TVItemAddressTVItemID = (from c in dbLocal.TVItems where c.TVItemID == address.AddressTVItemID select c).FirstOrDefault();
                if (TVItemAddressTVItemID == null)
                {
                    TVItemAddressTVItemID = (from c in dbIM.TVItems where c.TVItemID == address.AddressTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemAddressTVItemID = (from c in db.TVItems where c.TVItemID == address.AddressTVItemID select c).FirstOrDefault();
            }

            if (TVItemAddressTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "AddressTVItemID", address.AddressTVItemID.ToString()), new[] { "AddressTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Address,
                };
                if (!AllowableTVTypes.Contains(TVItemAddressTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "AddressTVItemID", "Address"), new[] { "AddressTVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(AddressTypeEnum), (int?)address.AddressType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "AddressType"), new[] { "AddressType" });
            }

            TVItem TVItemCountryTVItemID = null;
            if (LoggedInService.IsLocal)
            {
                TVItemCountryTVItemID = (from c in dbLocal.TVItems where c.TVItemID == address.CountryTVItemID select c).FirstOrDefault();
                if (TVItemCountryTVItemID == null)
                {
                    TVItemCountryTVItemID = (from c in dbIM.TVItems where c.TVItemID == address.CountryTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemCountryTVItemID = (from c in db.TVItems where c.TVItemID == address.CountryTVItemID select c).FirstOrDefault();
            }

            if (TVItemCountryTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "CountryTVItemID", address.CountryTVItemID.ToString()), new[] { "CountryTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Country,
                };
                if (!AllowableTVTypes.Contains(TVItemCountryTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "CountryTVItemID", "Country"), new[] { "CountryTVItemID" });
                }
            }

            TVItem TVItemProvinceTVItemID = null;
            if (LoggedInService.IsLocal)
            {
                TVItemProvinceTVItemID = (from c in dbLocal.TVItems where c.TVItemID == address.ProvinceTVItemID select c).FirstOrDefault();
                if (TVItemProvinceTVItemID == null)
                {
                    TVItemProvinceTVItemID = (from c in dbIM.TVItems where c.TVItemID == address.ProvinceTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemProvinceTVItemID = (from c in db.TVItems where c.TVItemID == address.ProvinceTVItemID select c).FirstOrDefault();
            }

            if (TVItemProvinceTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "ProvinceTVItemID", address.ProvinceTVItemID.ToString()), new[] { "ProvinceTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Province,
                };
                if (!AllowableTVTypes.Contains(TVItemProvinceTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "ProvinceTVItemID", "Province"), new[] { "ProvinceTVItemID" });
                }
            }

            TVItem TVItemMunicipalityTVItemID = null;
            if (LoggedInService.IsLocal)
            {
                TVItemMunicipalityTVItemID = (from c in dbLocal.TVItems where c.TVItemID == address.MunicipalityTVItemID select c).FirstOrDefault();
                if (TVItemMunicipalityTVItemID == null)
                {
                    TVItemMunicipalityTVItemID = (from c in dbIM.TVItems where c.TVItemID == address.MunicipalityTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemMunicipalityTVItemID = (from c in db.TVItems where c.TVItemID == address.MunicipalityTVItemID select c).FirstOrDefault();
            }

            if (TVItemMunicipalityTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "MunicipalityTVItemID", address.MunicipalityTVItemID.ToString()), new[] { "MunicipalityTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Municipality,
                };
                if (!AllowableTVTypes.Contains(TVItemMunicipalityTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "MunicipalityTVItemID", "Municipality"), new[] { "MunicipalityTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(address.StreetName) && address.StreetName.Length > 200)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "StreetName", "200"), new[] { "StreetName" });
            }

            if (!string.IsNullOrWhiteSpace(address.StreetNumber) && address.StreetNumber.Length > 50)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._MaxLengthIs_, "StreetNumber", "50"), new[] { "StreetNumber" });
            }

            if (address.StreetType != null)
            {
                retStr = enums.EnumTypeOK(typeof(StreetTypeEnum), (int?)address.StreetType);
                if (address.StreetType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "StreetType"), new[] { "StreetType" });
                }
            }

            if (!string.IsNullOrWhiteSpace(address.PostalCode) && (address.PostalCode.Length < 6 || address.PostalCode.Length > 11))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._LengthShouldBeBetween_And_, "PostalCode", "6", "11"), new[] { "PostalCode" });
            }

            if (!string.IsNullOrWhiteSpace(address.GoogleAddressText) && (address.GoogleAddressText.Length < 10 || address.GoogleAddressText.Length > 200))
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._LengthShouldBeBetween_And_, "GoogleAddressText", "10", "200"), new[] { "GoogleAddressText" });
            }

            if (address.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (address.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = null;
            if (LoggedInService.IsLocal)
            {
                TVItemLastUpdateContactTVItemID = (from c in dbLocal.TVItems where c.TVItemID == address.LastUpdateContactTVItemID select c).FirstOrDefault();
                if (TVItemLastUpdateContactTVItemID == null)
                {
                    TVItemLastUpdateContactTVItemID = (from c in dbIM.TVItems where c.TVItemID == address.LastUpdateContactTVItemID select c).FirstOrDefault();
                }
            }
            else
            {
                TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == address.LastUpdateContactTVItemID select c).FirstOrDefault();
            }

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(CultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", address.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(CultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Functions private

    }
}
