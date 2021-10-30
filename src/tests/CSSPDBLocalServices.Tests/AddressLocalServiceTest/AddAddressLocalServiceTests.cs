/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPHelperModels;
using CSSPReadGzFileServices;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json;
using ManageServices;

namespace CSSPDBLocalServices.Tests
{
    public partial class AddressLocalServiceTest : CSSPDBLocalServiceTest
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAddressLocal_Good_Test(string culture)
        {
            Assert.True(await AddressLocalServiceSetup(culture));

            Address address = FillAddress();

            var actionAddressRes = await AddressLocalService.AddAddressLocal(address);
            Assert.Equal(200, ((ObjectResult)actionAddressRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddressRes.Result).Value);
            Address addressRet = (Address)((OkObjectResult)actionAddressRes.Result).Value;
            Assert.NotNull(addressRet);

            Assert.Equal(1, (from c in dbLocal.Addresses select c).Count());
            Assert.Equal(2, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(4, (from c in dbLocal.TVItemLanguages select c).Count());

            Assert.Equal(-1, addressRet.AddressID);
            Assert.Equal(DBCommandEnum.Created, addressRet.DBCommand);
            Assert.Equal(-1, addressRet.AddressTVItemID);
            Assert.Equal(address.AddressType, addressRet.AddressType);
            Assert.Equal(address.CountryTVItemID, addressRet.CountryTVItemID);
            Assert.Equal(address.GoogleAddressText, addressRet.GoogleAddressText);
            Assert.Equal(address.MunicipalityTVItemID, addressRet.MunicipalityTVItemID);
            Assert.Equal(address.PostalCode, addressRet.PostalCode);
            Assert.Equal(address.ProvinceTVItemID, addressRet.ProvinceTVItemID);
            Assert.Equal(address.StreetName, addressRet.StreetName);
            Assert.Equal(address.StreetNumber, addressRet.StreetNumber);
            Assert.Equal(address.StreetType, addressRet.StreetType);
            Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, addressRet.LastUpdateContactTVItemID);
            Assert.True(DateTime.UtcNow.AddSeconds(-1) < addressRet.LastUpdateDate_UTC);
            Assert.True(DateTime.UtcNow.AddSeconds(1) > addressRet.LastUpdateDate_UTC);

            Address addressDB = (from c in dbLocal.Addresses
                               where c.AddressID == -1
                               select c).FirstOrDefault();
            Assert.NotNull(addressDB);

            Assert.Equal(JsonSerializer.Serialize(addressDB), JsonSerializer.Serialize(addressRet));

            WebAllAddresses webAllAddresses = await CSSPReadGzFileService.GetUncompressJSON<WebAllAddresses>(WebTypeEnum.WebAllAddresses, 0);

            Address addressWeb = (from c in webAllAddresses.AddressList
                               where c.AddressID == -1
                               select c).FirstOrDefault();
            Assert.NotNull(addressWeb);

            await CSSPLogService.Save();

            List<CommandLog> commandLogList = (from c in dbManage.CommandLogs
                                               select c).ToList();

            Assert.Single(commandLogList);
            Assert.Contains("AddressLocalService.AddAddressLocal(Address address)", commandLogList[0].Log);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAddressLocal_AddressID_Error_Test(string culture)
        {
            Assert.True(await AddressLocalServiceSetup(culture));

            Address addressLocalModel = FillAddress();

            addressLocalModel.AddressID = 10;

            var actionAddressRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AddressID", "0"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAddressLocal_AddressType_Error_Test(string culture)
        {
            Assert.True(await AddressLocalServiceSetup(culture));

            Address addressLocalModel = FillAddress();

            addressLocalModel.AddressType = (AddressTypeEnum)10000;

            var actionAddressRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "AddressType"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAddressLocal_CountryTVItemID_Error_Test(string culture)
        {
            Assert.True(await AddressLocalServiceSetup(culture));

            Address addressLocalModel = FillAddress();

            addressLocalModel.CountryTVItemID = 0;

            var actionAddressRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "CountryTVItemID"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAddressLocal_ProvinceTVItemID_Error_Test(string culture)
        {
            Assert.True(await AddressLocalServiceSetup(culture));

            Address addressLocalModel = FillAddress();

            addressLocalModel.ProvinceTVItemID = 0;

            var actionAddressRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "ProvinceTVItemID "), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAddressLocal_MunicipalityTVItemID_Error_Test(string culture)
        {
            Assert.True(await AddressLocalServiceSetup(culture));

            Address addressLocalModel = FillAddress();

            addressLocalModel.MunicipalityTVItemID = 0;

            var actionAddressRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "MunicipalityTVItemID"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAddressLocal_StreetName_Error_Test(string culture)
        {
            Assert.True(await AddressLocalServiceSetup(culture));

            Address addressLocalModel = FillAddress();

            addressLocalModel.StreetName = "";

            var actionAddressRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "StreetName"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAddressLocal_StreetNumber_Error_Test(string culture)
        {
            Assert.True(await AddressLocalServiceSetup(culture));

            Address addressLocalModel = FillAddress();

            addressLocalModel.StreetNumber = "";

            var actionAddressRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "StreetNumber"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAddressLocal_StreetType_Error_Test(string culture)
        {
            Assert.True(await AddressLocalServiceSetup(culture));

            Address addressLocalModel = FillAddress();

            addressLocalModel.StreetType = (StreetTypeEnum)1000;

            var actionAddressRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "StreetType"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAddressLocal_Return_Existing_Address_As_It_Already_Exist_Test(string culture)
        {
            Assert.True(await AddressLocalServiceSetup(culture));

            WebAllAddresses webAllAddresses = await CSSPReadGzFileService.GetUncompressJSON<WebAllAddresses>(WebTypeEnum.WebAllAddresses, 0);

            Assert.True(webAllAddresses.AddressList.Count > 10);

            Address address = FillAddress();

            address = webAllAddresses.AddressList[7];

            int AddressID = address.AddressID;

            address.AddressID = 0;

            var actionAddressRes = await AddressLocalService.AddAddressLocal(address);
            Assert.Equal(200, ((ObjectResult)actionAddressRes.Result).StatusCode);
            Address addressRet = (Address)((OkObjectResult)actionAddressRes.Result).Value;
            address.AddressID = AddressID;
            Assert.Equal(JsonSerializer.Serialize(address), JsonSerializer.Serialize(addressRet));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAddressLocal_Country_Not_Found_Error_Test(string culture)
        {
            Assert.True(await AddressLocalServiceSetup(culture));

            Address addressLocalModel = FillAddress();

            addressLocalModel.CountryTVItemID = 1;

            var actionAddressRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Country", "CountryTVItemID", addressLocalModel.CountryTVItemID.ToString()), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAddressLocal_Province_Not_Found_Error_Test(string culture)
        {
            Assert.True(await AddressLocalServiceSetup(culture));

            Address addressLocalModel = FillAddress();

            addressLocalModel.ProvinceTVItemID = 1;

            var actionAddressRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Province", "ProvinceTVItemID", addressLocalModel.ProvinceTVItemID.ToString()), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAddressLocal_Municipality_Not_Found_Error_Test(string culture)
        {
            Assert.True(await AddressLocalServiceSetup(culture));

            Address addressLocalModel = FillAddress();

            addressLocalModel.MunicipalityTVItemID = 1;

            var actionAddressRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Municipality", "MunicipalityTVItemID", addressLocalModel.MunicipalityTVItemID.ToString()), errRes.ErrList[0]);
        }
    }
}
