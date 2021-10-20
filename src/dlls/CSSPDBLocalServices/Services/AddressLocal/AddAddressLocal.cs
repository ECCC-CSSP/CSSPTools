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

            TVModel tvModelCountry = (from c in webAllCountries.TVModelList
                                      where c.TVItem.TVItemID == addressLocalModel.Address.CountryTVItemID
                                      select c).FirstOrDefault();

            if (tvModelCountry == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Country", "CountryTVItemID", addressLocalModel.Address.CountryTVItemID.ToString()));
            }

            TVModel tvModelProvince = (from c in webAllProvinces.TVModelList
                                       where c.TVItem.TVItemID == addressLocalModel.Address.ProvinceTVItemID
                                       select c).FirstOrDefault();

            if (tvModelProvince == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Province", "ProvinceTVItemID", addressLocalModel.Address.ProvinceTVItemID.ToString()));
            }

            TVModel tvModelMunicipality = (from c in webAllMunicipalities.TVModelList
                                           where c.TVItem.TVItemID == addressLocalModel.Address.MunicipalityTVItemID
                                           select c).FirstOrDefault();

            if (tvModelMunicipality == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Municipality", "MunicipalityTVItemID", addressLocalModel.Address.MunicipalityTVItemID.ToString()));
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            foreach (TVItemModel tvItemModel in webRoot.TVItemModelParentList.OrderBy(c => c.TVItem.TVLevel))
            {
                if (!(from c in dbLocal.TVItems
                      where c.TVItemID == tvItemModel.TVItem.TVItemID
                      select c).Any())
                {
                    try
                    {
                        dbLocal.TVItems.Add(tvItemModel.TVItem);
                        dbLocal.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Address_TVItem_Parents", ex.Message));
                    }

                    if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

                    foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                    {
                        if (!(from c in dbLocal.TVItemLanguages
                              where c.TVItemID == tvItemModel.TVItem.TVItemID
                              && c.Language == lang
                              select c).Any())
                        {

                            try
                            {
                                dbLocal.TVItemLanguages.Add(tvItemModel.TVItemLanguageList[(int)lang - 1]);
                                dbLocal.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Address_TVItemLanguage_Parents", ex.Message));
                            }

                            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
                        }
                    }
                }
            }

            TVItem tvItemNew = await AddAddressTVItemLocal(webRoot.TVItemModel.TVItem);
            if (tvItemNew == null) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            string TVTextEN = $"{ addressLocalModel.Address.StreetNumber } { addressLocalModel.Address.StreetName } " +
                $"{ enums.GetResValueForTypeAndID(typeof(StreetTypeEnum), (int)addressLocalModel.Address.StreetType) }, " +
                $"{ tvModelMunicipality.TVItemLanguageList[0].TVText } " +
                $"{ tvModelProvince.TVItemLanguageList[0].TVText } { tvModelCountry.TVItemLanguageList[0].TVText }";

            TVItemLanguage tvItemLanguageNewEN = await AddAddressTVItemLanguageLocal(tvItemNew, LanguageEnum.en, TVTextEN);
            if (tvItemLanguageNewEN == null) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            string TVTextFR = $"{ addressLocalModel.Address.StreetNumber } { addressLocalModel.Address.StreetName } " +
                $"{ enums.GetResValueForTypeAndID(typeof(StreetTypeEnum), (int)addressLocalModel.Address.StreetType) }, " +
                $"{ tvModelMunicipality.TVItemLanguageList[1].TVText } " +
                $"{ tvModelProvince.TVItemLanguageList[1].TVText } { tvModelCountry.TVItemLanguageList[1].TVText }";

            TVItemLanguage tvItemLanguageNewFR = await AddAddressTVItemLanguageLocal(tvItemNew, LanguageEnum.fr, TVTextFR);
            if (tvItemLanguageNewFR == null) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));


            int AddressIDNew = (from c in dbLocal.Addresses
                                where c.AddressID < 0
                                orderby c.AddressID descending
                                select c.AddressID).FirstOrDefault() - 1;

            addressLocalModel.Address.DBCommand = DBCommandEnum.Created;
            addressLocalModel.Address.AddressID = AddressIDNew;
            addressLocalModel.Address.AddressTVItemID = tvItemNew.TVItemID;
            addressLocalModel.Address.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
            addressLocalModel.Address.LastUpdateDate_UTC = DateTime.UtcNow;

            dbLocal.Addresses.Add(addressLocalModel.Address);
            try
            {
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