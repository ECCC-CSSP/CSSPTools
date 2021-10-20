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
        public async Task Constructor_Good_Test(string culture)
        {
            Assert.True(await AddressLocalServiceSetup(culture));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAddressLocal_Good_Test(string culture)
        {
            Assert.True(await AddressLocalServiceSetup(culture));

            AddressLocalModel addressLocalModel = FillAddressLocalModel();

            var actionPostTVItemModelRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            AddressLocalModel appTaskModelRet = (AddressLocalModel)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(appTaskModelRet);

            Assert.Equal(1, (from c in dbLocal.Addresses select c).Count());
            Assert.Equal(2, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(4, (from c in dbLocal.TVItemLanguages select c).Count());

            WebAllAddresses webAllAddresses = await CSSPReadGzFileService.GetUncompressJSON<WebAllAddresses>(WebTypeEnum.WebAllAddresses, 0);

            Assert.True(webAllAddresses.AddressList.Where(c => c.AddressID == -1).Any());

            await CSSPLogService.Save();

            List<CommandLog> commandLogList = (from c in dbManage.CommandLogs
                                               select c).ToList();

            Assert.Single(commandLogList);
            Assert.Contains("AddressLocalService.AddAddressLocal(AddressLocalModel addressLocalModel)", commandLogList[0].Log);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAddressLocal_AddressID_Error_Test(string culture)
        {
            Assert.True(await AddressLocalServiceSetup(culture));

            AddressLocalModel addressLocalModel = FillAddressLocalModel();

            addressLocalModel.Address.AddressID = 10;

            var actionPostTVItemModelRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
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

            AddressLocalModel addressLocalModel = FillAddressLocalModel();

            addressLocalModel.Address.AddressType = (AddressTypeEnum)10000;

            var actionPostTVItemModelRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
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

            AddressLocalModel addressLocalModel = FillAddressLocalModel();

            addressLocalModel.Address.CountryTVItemID = 0;

            var actionPostTVItemModelRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
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

            AddressLocalModel addressLocalModel = FillAddressLocalModel();

            addressLocalModel.Address.ProvinceTVItemID = 0;

            var actionPostTVItemModelRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
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

            AddressLocalModel addressLocalModel = FillAddressLocalModel();

            addressLocalModel.Address.MunicipalityTVItemID = 0;

            var actionPostTVItemModelRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
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

            AddressLocalModel addressLocalModel = FillAddressLocalModel();

            addressLocalModel.Address.StreetName = "";

            var actionPostTVItemModelRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
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

            AddressLocalModel addressLocalModel = FillAddressLocalModel();

            addressLocalModel.Address.StreetNumber = "";

            var actionPostTVItemModelRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
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

            AddressLocalModel addressLocalModel = FillAddressLocalModel();

            addressLocalModel.Address.StreetType = (StreetTypeEnum)1000;

            var actionPostTVItemModelRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
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

            AddressLocalModel addressLocalModel = FillAddressLocalModel();

            addressLocalModel.Address = webAllAddresses.AddressList[7];

            int AddressID = addressLocalModel.Address.AddressID;

            addressLocalModel.Address.AddressID = 0;

            var actionPostTVItemModelRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            AddressLocalModel addressLocalModelRet = (AddressLocalModel)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            addressLocalModel.Address.AddressID = AddressID;
            Assert.Equal(JsonSerializer.Serialize(addressLocalModel), JsonSerializer.Serialize(addressLocalModelRet));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAddressLocal_Country_Not_Found_Error_Test(string culture)
        {
            Assert.True(await AddressLocalServiceSetup(culture));

            AddressLocalModel addressLocalModel = FillAddressLocalModel();

            addressLocalModel.Address.CountryTVItemID = 1;

            var actionPostTVItemModelRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Country", "CountryTVItemID", addressLocalModel.Address.CountryTVItemID.ToString()), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAddressLocal_Province_Not_Found_Error_Test(string culture)
        {
            Assert.True(await AddressLocalServiceSetup(culture));

            AddressLocalModel addressLocalModel = FillAddressLocalModel();

            addressLocalModel.Address.ProvinceTVItemID = 1;

            var actionPostTVItemModelRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Province", "ProvinceTVItemID", addressLocalModel.Address.ProvinceTVItemID.ToString()), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAddressLocal_Municipality_Not_Found_Error_Test(string culture)
        {
            Assert.True(await AddressLocalServiceSetup(culture));

            AddressLocalModel addressLocalModel = FillAddressLocalModel();

            addressLocalModel.Address.MunicipalityTVItemID = 1;

            var actionPostTVItemModelRes = await AddressLocalService.AddAddressLocal(addressLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Municipality", "MunicipalityTVItemID", addressLocalModel.Address.MunicipalityTVItemID.ToString()), errRes.ErrList[0]);
        }
    }
}
