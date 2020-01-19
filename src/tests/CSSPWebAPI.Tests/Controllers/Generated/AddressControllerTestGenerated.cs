using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Xunit;
using CSSPWebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

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
                    IHttpActionResult jsonRet = addressController.GetAddressList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<Address>> ret = jsonRet as OkNegotiatedContentResult<List<Address>>;
                    Assert.Equal(addressFirst.AddressID, ret.Content[0].AddressID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<Address>>;
                        Assert.Equal(addressList[0].AddressID, ret.Content[0].AddressID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with Address info
                           IHttpActionResult jsonRet2 = addressController.GetAddressList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<Address>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<Address>>;
                           Assert.Equal(addressList[1].AddressID, ret2.Content[0].AddressID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
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
                    IHttpActionResult jsonRet = addressController.GetAddressWithID(addressFirst.AddressID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<Address> Ret = jsonRet as OkNegotiatedContentResult<Address>;
                    Address addressRet = Ret.Content;
                    Assert.Equal(addressFirst.AddressID, addressRet.AddressID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = addressController.GetAddressWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<Address> addressRet2 = jsonRet2 as OkNegotiatedContentResult<Address>;
                    Assert.IsNull(addressRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
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
                    IHttpActionResult jsonRet = addressController.GetAddressWithID(addressLast.AddressID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<Address> Ret = jsonRet as OkNegotiatedContentResult<Address>;
                    Address addressRet = Ret.Content;
                    Assert.Equal(addressLast.AddressID, addressRet.AddressID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because AddressID exist
                    IHttpActionResult jsonRet2 = addressController.Post(addressRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<Address> addressRet2 = jsonRet2 as OkNegotiatedContentResult<Address>;
                    Assert.IsNull(addressRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added Address
                    addressRet.AddressID = 0;
                    addressController.Request = new System.Net.Http.HttpRequestMessage();
                    addressController.Request.RequestUri = new System.Uri("http://localhost:5000/api/address");
                    IHttpActionResult jsonRet3 = addressController.Post(addressRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<Address> addressRet3 = jsonRet3 as CreatedNegotiatedContentResult<Address>;
                    Assert.NotNull(addressRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = addressController.Delete(addressRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<Address> addressRet4 = jsonRet4 as OkNegotiatedContentResult<Address>;
                    Assert.NotNull(addressRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
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
                    IHttpActionResult jsonRet = addressController.GetAddressWithID(addressLast.AddressID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<Address> Ret = jsonRet as OkNegotiatedContentResult<Address>;
                    Address addressRet = Ret.Content;
                    Assert.Equal(addressLast.AddressID, addressRet.AddressID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = addressController.Put(addressRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<Address> addressRet2 = jsonRet2 as OkNegotiatedContentResult<Address>;
                    Assert.NotNull(addressRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because AddressID of 0 does not exist
                    addressRet.AddressID = 0;
                    IHttpActionResult jsonRet3 = addressController.Put(addressRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<Address> addressRet3 = jsonRet3 as OkNegotiatedContentResult<Address>;
                    Assert.IsNull(addressRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
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
                    IHttpActionResult jsonRet = addressController.GetAddressWithID(addressLast.AddressID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<Address> Ret = jsonRet as OkNegotiatedContentResult<Address>;
                    Address addressRet = Ret.Content;
                    Assert.Equal(addressLast.AddressID, addressRet.AddressID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added Address
                    addressRet.AddressID = 0;
                    addressController.Request = new System.Net.Http.HttpRequestMessage();
                    addressController.Request.RequestUri = new System.Uri("http://localhost:5000/api/address");
                    IHttpActionResult jsonRet3 = addressController.Post(addressRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<Address> addressRet3 = jsonRet3 as CreatedNegotiatedContentResult<Address>;
                    Assert.NotNull(addressRet3);
                    Address address = addressRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = addressController.Delete(addressRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<Address> addressRet2 = jsonRet2 as OkNegotiatedContentResult<Address>;
                    Assert.NotNull(addressRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because AddressID of 0 does not exist
                    addressRet.AddressID = 0;
                    IHttpActionResult jsonRet4 = addressController.Delete(addressRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<Address> addressRet4 = jsonRet4 as OkNegotiatedContentResult<Address>;
                    Assert.IsNull(addressRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
