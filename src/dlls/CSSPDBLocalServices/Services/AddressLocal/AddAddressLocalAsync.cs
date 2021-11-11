/*
 * Manually edited
 *
 */

using CSSPEnums;
using CSSPDBModels;
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
using CSSPLocalLoggedInServices;
using Microsoft.Extensions.Configuration;
using CSSPWebModels;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using CSSPHelperModels;
using CSSPLogServices;
using System.Reflection;
using System.Security.Cryptography;
using CSSPReadGzFileServices;
using CSSPCreateGzFileServices;

namespace CSSPDBLocalServices
{
    public partial class AddressLocalService : ControllerBase, IAddressLocalService
    {
        public async Task<ActionResult<Address>> AddAddressLocalAsync(Address address)
        {
            string parameters = "";
            if (address != null)
            {
                parameters += $" --  StreetNumber = { address.StreetNumber ?? "--" } " +
                    $"StreetName = { address.StreetName ?? "--" } " +
                    $"StreetType  = { address.StreetType.ToString() ?? "--" } " +
                    $"MunicipalityTVItemID = { address.MunicipalityTVItemID  } " +
                    $"ProvinceTVItemID = { address.ProvinceTVItemID } " +
                    $"CountryTVItemID = { address.CountryTVItemID }";
            }
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(Address address) { parameters }";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            #region Check Address
            if (address == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "address"));
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            if (address.AddressID != 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AddressID", "0"));
            }

            //string retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)AddressModel.DBCommand);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
            //}

            //if (AddressModel.AddressTVItemID == 0)
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AddressTVItemID"));
            //}

            string retStr = enums.EnumTypeOK(typeof(AddressTypeEnum), (int?)address.AddressType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AddressType"));
            }

            if (address.CountryTVItemID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "CountryTVItemID"));
            }

            if (address.ProvinceTVItemID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "ProvinceTVItemID "));
            }

            if (address.MunicipalityTVItemID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "MunicipalityTVItemID"));
            }

            if (string.IsNullOrWhiteSpace(address.StreetName))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "StreetName"));
            }

            if (string.IsNullOrWhiteSpace(address.StreetNumber))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "StreetNumber"));
            }

            retStr = enums.EnumTypeOK(typeof(StreetTypeEnum), (int?)address.StreetType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "StreetType"));
            }

            //if (string.IsNullOrWhiteSpace(AddressModel.PostalCode))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "PostalCode"));
            //}

            //if (string.IsNullOrWhiteSpace(AddressModel.GoogleAddressText))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "GoogleAddressText"));
            //}
            #endregion Check Address

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            WebAllAddresses webAllAddresses = await CSSPReadGzFileService.GetUncompressJSON<WebAllAddresses>(WebTypeEnum.WebAllAddresses, 0);

            Address addressJSON = (from c in webAllAddresses.AddressList
                                   where c.StreetName == address.StreetName
                                   && c.StreetNumber == address.StreetNumber
                                   && c.StreetType == address.StreetType
                                   && c.CountryTVItemID == address.CountryTVItemID
                                   && c.ProvinceTVItemID == address.ProvinceTVItemID
                                   && c.MunicipalityTVItemID == address.MunicipalityTVItemID
                                   select c).FirstOrDefault();

            if (addressJSON != null)
            {
                return await Task.FromResult(Ok(addressJSON));
            }

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);
            WebAllCountries webAllCountries = await CSSPReadGzFileService.GetUncompressJSON<WebAllCountries>(WebTypeEnum.WebAllCountries, 0);
            WebAllProvinces webAllProvinces = await CSSPReadGzFileService.GetUncompressJSON<WebAllProvinces>(WebTypeEnum.WebAllProvinces, 0);
            WebAllMunicipalities webAllMunicipalities = await CSSPReadGzFileService.GetUncompressJSON<WebAllMunicipalities>(WebTypeEnum.WebAllMunicipalities, 0);

            TVItemModel tvItemModelCountry = (from c in webAllCountries.TVItemModelList
                                              where c.TVItem.TVItemID == address.CountryTVItemID
                                              select c).FirstOrDefault();

            if (tvItemModelCountry == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Country", "CountryTVItemID", address.CountryTVItemID.ToString()));
            }

            TVItemModel tvItemModelProvince = (from c in webAllProvinces.TVItemModelList
                                               where c.TVItem.TVItemID == address.ProvinceTVItemID
                                               select c).FirstOrDefault();

            if (tvItemModelProvince == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Province", "ProvinceTVItemID", address.ProvinceTVItemID.ToString()));
            }

            TVItemModel tvItemModelMunicipality = (from c in webAllMunicipalities.TVItemModelList
                                                   where c.TVItem.TVItemID == address.MunicipalityTVItemID
                                                   select c).FirstOrDefault();

            if (tvItemModelMunicipality == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Municipality", "MunicipalityTVItemID", address.MunicipalityTVItemID.ToString()));
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            await TVItemLocalService.AddTVItemParentLocalAsync(webRoot.TVItemModelParentList.OrderBy(c => c.TVItem.TVLevel).ToList());

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            string TVTextEN = $"{ address.StreetNumber } { address.StreetName } " +
                $"{ enums.GetResValueForTypeAndID(typeof(StreetTypeEnum), (int)address.StreetType) }, " +
                $"{ tvItemModelMunicipality.TVItemLanguageList[0].TVText } " +
                $"{ tvItemModelProvince.TVItemLanguageList[0].TVText } { tvItemModelCountry.TVItemLanguageList[0].TVText }";

            string TVTextFR = $"{ address.StreetNumber } { address.StreetName } " +
                $"{ enums.GetResValueForTypeAndID(typeof(StreetTypeEnum), (int)address.StreetType) }, " +
                $"{ tvItemModelMunicipality.TVItemLanguageList[1].TVText } " +
                $"{ tvItemModelProvince.TVItemLanguageList[1].TVText } { tvItemModelCountry.TVItemLanguageList[1].TVText }";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(webRoot.TVItemModel.TVItem, TVTypeEnum.Address, TVTextEN, TVTextFR);

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            int AddressIDNew = (from c in dbLocal.Addresses
                                where c.AddressID < 0
                                orderby c.AddressID ascending
                                select c.AddressID).FirstOrDefault() - 1;


            try
            {
                address.DBCommand = DBCommandEnum.Created;
                address.AddressID = AddressIDNew;
                address.AddressTVItemID = tvItemModel.TVItem.TVItemID;
                address.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                address.LastUpdateDate_UTC = DateTime.UtcNow;

                dbLocal.Addresses.Add(address);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Address", ex.Message));
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            List<ToRecreate> ToRecreateList = new List<ToRecreate>()
            {
                new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
                new ToRecreate() { WebType = WebTypeEnum.WebAllAddresses, TVItemID = 0 },
            };

            foreach(ToRecreate toRecreate in ToRecreateList)
            {
                var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(toRecreate.WebType, toRecreate.TVItemID);
                if (400 == ((ObjectResult)actionRes.Result).StatusCode)
                {
                    ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                    CSSPLogService.ErrRes.ErrList.AddRange(errRes.ErrList);
                }

                if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(Ok(address));
        }
    }
}