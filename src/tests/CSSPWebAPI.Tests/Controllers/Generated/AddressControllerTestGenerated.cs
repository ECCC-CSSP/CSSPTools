using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Xunit;
using CSSPWebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

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
                    Assert.NotNull(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(addressFirst.AddressID, ((Address)ret.Value).AddressID + 1);
                    //Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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

                        ret = jsonRet as OkObjectResult;
                        //Assert.Equal(addressList[0].AddressID, ret.Content[0].AddressID);
                        //Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with Address info
                           IActionResult jsonRet2 = addressController.GetAddressList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                            OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           //Assert.Equal(addressList[1].AddressID, ret2.Content[0].AddressID);
                           //Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

    }
}
