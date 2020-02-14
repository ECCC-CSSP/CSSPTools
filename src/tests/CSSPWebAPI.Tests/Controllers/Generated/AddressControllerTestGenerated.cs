using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Xunit;
using CSSPWebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using CSSPWebAPI.Controllers.Resources;

namespace CSSPWebAPI.Tests.Controllers
{
    public partial class AddressControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public AddressControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void Address_Controller_GetAddressList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AddressController addressController = new AddressController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(addressController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, addressController.DatabaseType);

                    Address addressFirst = new Address();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        AddressService addressService = new AddressService(query, db, ContactID);
                        addressFirst = (from c in db.Addresses select c).FirstOrDefault();
                        count = (from c in db.Addresses select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with Address info
                    IActionResult jsonRet = addressController.GetAddressList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(addressFirst.AddressID, ((List<Address>)ret.Value)[0].AddressID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<Address>)ret.Value).Count);

                    List<Address> addressList = new List<Address>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        AddressService addressService = new AddressService(query, db, ContactID);
                        addressList = (from c in db.Addresses select c).OrderBy(c => c.AddressID).Skip(0).Take(2).ToList();
                        count = (from c in db.Addresses select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with Address info
                        jsonRet = addressController.GetAddressList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(addressList[0].AddressID, ((List<Address>)ret.Value)[0].AddressID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<Address>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with Address info
                           IActionResult jsonRet2 = addressController.GetAddressList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(addressList[1].AddressID, ((List<Address>)ret2.Value)[0].AddressID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<Address>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void Address_Controller_GetAddressWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AddressController addressController = new AddressController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(addressController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, addressController.DatabaseType);

                    Address addressFirst = new Address();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        AddressService addressService = new AddressService(new Query(), db, ContactID);
                        addressFirst = (from c in db.Addresses select c).FirstOrDefault();
                    }

                    // ok with Address info
                    IActionResult jsonRet = addressController.GetAddressWithID(addressFirst.AddressID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(addressFirst.AddressID, ((Address)ret.Value).AddressID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = addressController.GetAddressWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult addressRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(addressRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void Address_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AddressController addressController = new AddressController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(addressController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, addressController.DatabaseType);

                    Address addressLast = new Address();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        AddressService addressService = new AddressService(query, db, ContactID);
                        addressLast = (from c in db.Addresses select c).FirstOrDefault();
                    }

                    // ok with Address info
                    IActionResult jsonRet = addressController.GetAddressWithID(addressLast.AddressID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Address addressRet = (Address)ret.Value;
                    Assert.Equal(addressLast.AddressID, addressRet.AddressID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because AddressID exist
                    IActionResult jsonRet2 = addressController.Post(addressRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added Address
                    addressRet.AddressID = 0;
                    IActionResult jsonRet3 = addressController.Post(addressRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = addressController.Delete(addressRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet4);

                    OkObjectResult ret4 = jsonRet4 as OkObjectResult;
                    Assert.NotNull(ret4);

                    BadRequestResult badRequest4 = jsonRet4 as BadRequestResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void Address_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AddressController addressController = new AddressController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(addressController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, addressController.DatabaseType);

                    Address addressLast = new Address();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        AddressService addressService = new AddressService(query, db, ContactID);
                        addressLast = (from c in db.Addresses select c).FirstOrDefault();
                    }

                    // ok with Address info
                    IActionResult jsonRet = addressController.GetAddressWithID(addressLast.AddressID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    Address addressRet = (Address)Ret.Value;
                    Assert.Equal(addressLast.AddressID, addressRet.AddressID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = addressController.Put(addressRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult addressRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(addressRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because AddressID of 0 does not exist
                    addressRet.AddressID = 0;
                    IActionResult jsonRet3 = addressController.Put(addressRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult addressRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(addressRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void Address_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    AddressController addressController = new AddressController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(addressController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, addressController.DatabaseType);

                    Address addressLast = new Address();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        AddressService addressService = new AddressService(query, db, ContactID);
                        addressLast = (from c in db.Addresses select c).FirstOrDefault();
                    }

                    // ok with Address info
                    IActionResult jsonRet = addressController.GetAddressWithID(addressLast.AddressID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    Address addressRet = (Address)Ret.Value;
                    Assert.Equal(addressLast.AddressID, addressRet.AddressID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added Address
                    addressRet.AddressID = 0;
                    IActionResult jsonRet3 = addressController.Post(addressRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    Address address = (Address)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = addressController.Delete(addressRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because AddressID of 0 does not exist
                    addressRet.AddressID = 0;
                    IActionResult jsonRet4 = addressController.Delete(addressRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet4);

                    OkObjectResult ret4 = jsonRet4 as OkObjectResult;
                    Assert.Null(ret4);

                    BadRequestObjectResult badRequest4 = jsonRet4 as BadRequestObjectResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
