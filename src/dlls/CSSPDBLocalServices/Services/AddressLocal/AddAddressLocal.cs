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
        public async Task<ActionResult<AddressLocalModel>> AddAddressLocal(AddressLocalModel addressLocalModel)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(AddressLocalModel addressLocalModel)";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            #region Check Address
            if (addressLocalModel.Address.AddressID != 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AddressID", "0"));
            }

            //string retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)AddressModel.Address.DBCommand);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
            //}

            //if (AddressModel.Address.AddressTVItemID == 0)
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AddressTVItemID"));
            //}

            string retStr = enums.EnumTypeOK(typeof(AddressTypeEnum), (int?)addressLocalModel.Address.AddressType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AddressType"));
            }

            if (addressLocalModel.Address.CountryTVItemID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "CountryTVItemID"));
            }

            if (addressLocalModel.Address.ProvinceTVItemID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "ProvinceTVItemID "));
            }

            if (addressLocalModel.Address.MunicipalityTVItemID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "MunicipalityTVItemID"));
            }

            if (string.IsNullOrWhiteSpace(addressLocalModel.Address.StreetName))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "StreetName"));
            }

            if (string.IsNullOrWhiteSpace(addressLocalModel.Address.StreetNumber))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "StreetNumber"));
            }

            retStr = enums.EnumTypeOK(typeof(StreetTypeEnum), (int?)addressLocalModel.Address.StreetType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "StreetType"));
            }

            //if (string.IsNullOrWhiteSpace(AddressModel.Address.PostalCode))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "PostalCode"));
            //}

            //if (string.IsNullOrWhiteSpace(AddressModel.Address.GoogleAddressText))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "GoogleAddressText"));
            //}
            #endregion Check Address

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            WebAllAddresses webAllAddresses = await CSSPReadGzFileService.GetUncompressJSON<WebAllAddresses>(WebTypeEnum.WebAllAddresses, 0);

            Address addressJSON = (from c in webAllAddresses.AddressList
                                   where c.StreetName == addressLocalModel.Address.StreetName
                                   && c.StreetNumber == addressLocalModel.Address.StreetNumber
                                   && c.StreetType == addressLocalModel.Address.StreetType
                                   && c.CountryTVItemID == addressLocalModel.Address.CountryTVItemID
                                   && c.ProvinceTVItemID == addressLocalModel.Address.ProvinceTVItemID
                                   && c.MunicipalityTVItemID == addressLocalModel.Address.MunicipalityTVItemID
                                   select c).FirstOrDefault();

            if (addressJSON != null)
            {
                return await Task.FromResult(Ok(new AddressLocalModel() { Address = addressJSON }));
            }

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);
            WebAllCountries webAllCountries = await CSSPReadGzFileService.GetUncompressJSON<WebAllCountries>(WebTypeEnum.WebAllCountries, 0);
            WebAllProvinces webAllProvinces = await CSSPReadGzFileService.GetUncompressJSON<WebAllProvinces>(WebTypeEnum.WebAllProvinces, 0);
            WebAllMunicipalities webAllMunicipalities = await CSSPReadGzFileService.GetUncompressJSON<WebAllMunicipalities>(WebTypeEnum.WebAllMunicipalities, 0);

            TVItemModel tvItemModelCountry = (from c in webAllCountries.TVItemModelList
                                              where c.TVItem.TVItemID == addressLocalModel.Address.CountryTVItemID
                                              select c).FirstOrDefault();

            if (tvItemModelCountry == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Country", "CountryTVItemID", addressLocalModel.Address.CountryTVItemID.ToString()));
            }

            TVItemModel tvItemModelProvince = (from c in webAllProvinces.TVItemModelList
                                       where c.TVItem.TVItemID == addressLocalModel.Address.ProvinceTVItemID
                                       select c).FirstOrDefault();

            if (tvItemModelProvince == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Province", "ProvinceTVItemID", addressLocalModel.Address.ProvinceTVItemID.ToString()));
            }

            TVItemModel tvItemModelMunicipality = (from c in webAllMunicipalities.TVItemModelList
                                           where c.TVItem.TVItemID == addressLocalModel.Address.MunicipalityTVItemID
                                           select c).FirstOrDefault();

            if (tvItemModelMunicipality == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Municipality", "MunicipalityTVItemID", addressLocalModel.Address.MunicipalityTVItemID.ToString()));
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            await TVItemLocalService.AddTVItemParentLocal(webRoot.TVItemModelParentList.OrderBy(c => c.TVItem.TVLevel).ToList());

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            string TVTextEN = $"{ addressLocalModel.Address.StreetNumber } { addressLocalModel.Address.StreetName } " +
                $"{ enums.GetResValueForTypeAndID(typeof(StreetTypeEnum), (int)addressLocalModel.Address.StreetType) }, " +
                $"{ tvItemModelMunicipality.TVItemLanguageList[0].TVText } " +
                $"{ tvItemModelProvince.TVItemLanguageList[0].TVText } { tvItemModelCountry.TVItemLanguageList[0].TVText }";

            string TVTextFR = $"{ addressLocalModel.Address.StreetNumber } { addressLocalModel.Address.StreetName } " +
                $"{ enums.GetResValueForTypeAndID(typeof(StreetTypeEnum), (int)addressLocalModel.Address.StreetType) }, " +
                $"{ tvItemModelMunicipality.TVItemLanguageList[1].TVText } " +
                $"{ tvItemModelProvince.TVItemLanguageList[1].TVText } { tvItemModelCountry.TVItemLanguageList[1].TVText }";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(webRoot.TVItemModel.TVItem, TVTypeEnum.Address, TVTextEN, TVTextFR);

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            int AddressIDNew = (from c in dbLocal.Addresses
                                where c.AddressID < 0
                                orderby c.AddressID descending
                                select c.AddressID).FirstOrDefault() - 1;


            try
            {
                addressLocalModel.Address.DBCommand = DBCommandEnum.Created;
                addressLocalModel.Address.AddressID = AddressIDNew;
                addressLocalModel.Address.AddressTVItemID = tvItemModel.TVItem.TVItemID;
                addressLocalModel.Address.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                addressLocalModel.Address.LastUpdateDate_UTC = DateTime.UtcNow;

                dbLocal.Addresses.Add(addressLocalModel.Address);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Address", ex.Message));
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            var actionRes = await CSSPCreateGzFileService.CreateGzFile(WebTypeEnum.WebAllAddresses, 0);
            if (400 == ((ObjectResult)actionRes.Result).StatusCode)
            {
                ErrRes errRes2 = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
                CSSPLogService.ErrRes.ErrList.AddRange(errRes2.ErrList);
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(Ok(addressLocalModel));
        }
    }
}