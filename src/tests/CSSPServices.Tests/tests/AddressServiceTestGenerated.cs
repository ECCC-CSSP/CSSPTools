 /* Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using CSSPModels;
using CSSPServices;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.Security.Principal;
using System.Globalization;
using CSSPServices.Resources;
using CSSPModels.Resources;
using CSSPEnums.Resources;

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class AddressServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private AddressService addressService { get; set; }
        #endregion Properties

        #region Constructors
        public AddressServiceTest() : base()
        {
            //addressService = new AddressService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD
        [TestMethod]
        public void Address_CRUD_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    Address address = GetFilledRandomAddress("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = addressService.GetAddressList().Count();

                    Assert.AreEqual(count, (from c in dbTestDB.Addresses select c).Count());

                    addressService.Add(address);
                    if (address.HasErrors)
                    {
                        Assert.AreEqual("", address.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, addressService.GetAddressList().Where(c => c == address).Any());
                    addressService.Update(address);
                    if (address.HasErrors)
                    {
                        Assert.AreEqual("", address.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, addressService.GetAddressList().Count());
                    addressService.Delete(address);
                    if (address.HasErrors)
                    {
                        Assert.AreEqual("", address.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, addressService.GetAddressList().Count());

                }
            }
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [TestMethod]
        public void Address_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    count = addressService.GetAddressList().Count();

                    Address address = GetFilledRandomAddress("");

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // address.AddressID   (Int32)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.AddressID = 0;
                    addressService.Update(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "AddressID"), address.ValidationResults.FirstOrDefault().ErrorMessage);

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.AddressID = 10000000;
                    addressService.Update(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Address", "AddressID", address.AddressID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Address)]
                    // address.AddressTVItemID   (Int32)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.AddressTVItemID = 0;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AddressTVItemID", address.AddressTVItemID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.AddressTVItemID = 1;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "AddressTVItemID", "Address"), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // address.AddressType   (AddressTypeEnum)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.AddressType = (AddressTypeEnum)1000000;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "AddressType"), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Country)]
                    // address.CountryTVItemID   (Int32)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.CountryTVItemID = 0;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "CountryTVItemID", address.CountryTVItemID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.CountryTVItemID = 1;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "CountryTVItemID", "Country"), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Province)]
                    // address.ProvinceTVItemID   (Int32)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.ProvinceTVItemID = 0;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ProvinceTVItemID", address.ProvinceTVItemID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.ProvinceTVItemID = 1;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "ProvinceTVItemID", "Province"), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Municipality)]
                    // address.MunicipalityTVItemID   (Int32)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.MunicipalityTVItemID = 0;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MunicipalityTVItemID", address.MunicipalityTVItemID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.MunicipalityTVItemID = 1;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MunicipalityTVItemID", "Municipality"), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(200))]
                    // address.StreetName   (String)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.StreetName = GetRandomString("", 201);
                    Assert.AreEqual(false, addressService.Add(address));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "StreetName", "200"), address.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, addressService.GetAddressList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(50))]
                    // address.StreetNumber   (String)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.StreetNumber = GetRandomString("", 51);
                    Assert.AreEqual(false, addressService.Add(address));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "StreetNumber", "50"), address.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, addressService.GetAddressList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // address.StreetType   (StreetTypeEnum)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.StreetType = (StreetTypeEnum)1000000;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "StreetType"), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(11, MinimumLength = 6)]
                    // address.PostalCode   (String)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.PostalCode = GetRandomString("", 5);
                    Assert.AreEqual(false, addressService.Add(address));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "PostalCode", "6", "11"), address.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, addressService.GetAddressList().Count());
                    address = null;
                    address = GetFilledRandomAddress("");
                    address.PostalCode = GetRandomString("", 12);
                    Assert.AreEqual(false, addressService.Add(address));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "PostalCode", "6", "11"), address.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, addressService.GetAddressList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(200, MinimumLength = 10)]
                    // address.GoogleAddressText   (String)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.GoogleAddressText = GetRandomString("", 9);
                    Assert.AreEqual(false, addressService.Add(address));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "GoogleAddressText", "10", "200"), address.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, addressService.GetAddressList().Count());
                    address = null;
                    address = GetFilledRandomAddress("");
                    address.GoogleAddressText = GetRandomString("", 201);
                    Assert.AreEqual(false, addressService.Add(address));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "GoogleAddressText", "10", "200"), address.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, addressService.GetAddressList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // address.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.LastUpdateDate_UTC = new DateTime();
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), address.ValidationResults.FirstOrDefault().ErrorMessage);
                    address = null;
                    address = GetFilledRandomAddress("");
                    address.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), address.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // address.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.LastUpdateContactTVItemID = 0;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", address.LastUpdateContactTVItemID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.LastUpdateContactTVItemID = 1;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // address.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // address.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated Properties

        #region Tests Generated for GetAddressWithAddressID(address.AddressID)
        [TestMethod]
        public void GetAddressWithAddressID__address_AddressID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    Address address = (from c in dbTestDB.Addresses select c).FirstOrDefault();
                    Assert.IsNotNull(address);

                }
            }
        }
        #endregion Tests Generated for GetAddressWithAddressID(address.AddressID)

        #region Tests Generated for GetAddressList()
        [TestMethod]
        public void GetAddressList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    Address address = (from c in dbTestDB.Addresses select c).FirstOrDefault();
                    Assert.IsNotNull(address);

                    List<Address> addressDirectQueryList = new List<Address>();
                    addressDirectQueryList = (from c in dbTestDB.Addresses select c).Take(200).ToList();

                }
            }
        }
        #endregion Tests Generated for GetAddressList()

        #region Tests Generated for GetAddressList() Skip Take
        [TestMethod]
        public void GetAddressList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    addressService.Query = addressService.FillQuery(typeof(Address), culture.TwoLetterISOLanguageName, 1, 1, "", "");

                    List<Address> addressDirectQueryList = new List<Address>();
                    addressDirectQueryList = (from c in dbTestDB.Addresses select c).Skip(1).Take(1).ToList();

                        List<Address> addressList = new List<Address>();
                        addressList = addressService.GetAddressList().ToList();
                        CheckAddressFields(addressList);
                        Assert.AreEqual(addressDirectQueryList[0].AddressID, addressList[0].AddressID);
                }
            }
        }
        #endregion Tests Generated for GetAddressList() Skip Take

        #region Tests Generated for GetAddressList() Skip Take Asc
        [TestMethod]
        public void GetAddressList_Skip_Take_Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    addressService.Query = addressService.FillQuery(typeof(Address), culture.TwoLetterISOLanguageName, 1, 1,  "AddressID", "", "");

                    List<Address> addressDirectQueryList = new List<Address>();
                    addressDirectQueryList = (from c in dbTestDB.Addresses select c).OrderBy(c => c.AddressID).Skip(1).Take(1).ToList();

                        List<Address> addressList = new List<Address>();
                        addressList = addressService.GetAddressList().ToList();
                        CheckAddressFields(addressList);
                        Assert.AreEqual(addressDirectQueryList[0].AddressID, addressList[0].AddressID);
                }
            }
        }
        #endregion Tests Generated for GetAddressList() Skip Take Asc

        #region Tests Generated for GetAddressList() Skip Take 2 Asc
        [TestMethod]
        public void GetAddressList_Skip_Take_2Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    addressService.Query = addressService.FillQuery(typeof(Address), culture.TwoLetterISOLanguageName, 1, 1, "AddressID,AddressTVItemID", "", "");

                    List<Address> addressDirectQueryList = new List<Address>();
                    addressDirectQueryList = (from c in dbTestDB.Addresses select c).OrderBy(c => c.AddressID).ThenBy(c => c.AddressTVItemID).Skip(1).Take(1).ToList();

                        List<Address> addressList = new List<Address>();
                        addressList = addressService.GetAddressList().ToList();
                        CheckAddressFields(addressList);
                        Assert.AreEqual(addressDirectQueryList[0].AddressID, addressList[0].AddressID);
                }
            }
        }
        #endregion Tests Generated for GetAddressList() Skip Take 2 Asc

        #region Tests Generated for GetAddressList() Skip Take Asc Where
        [TestMethod]
        public void GetAddressList_Skip_Take_Asc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    addressService.Query = addressService.FillQuery(typeof(Address), culture.TwoLetterISOLanguageName, 0, 1, "AddressID", "", "AddressID,EQ,4");

                    List<Address> addressDirectQueryList = new List<Address>();
                    addressDirectQueryList = (from c in dbTestDB.Addresses select c).Where(c => c.AddressID == 4).OrderBy(c => c.AddressID).Skip(0).Take(1).ToList();

                        List<Address> addressList = new List<Address>();
                        addressList = addressService.GetAddressList().ToList();
                        CheckAddressFields(addressList);
                        Assert.AreEqual(addressDirectQueryList[0].AddressID, addressList[0].AddressID);
                }
            }
        }
        #endregion Tests Generated for GetAddressList() Skip Take Asc Where

        #region Tests Generated for GetAddressList() Skip Take Asc 2 Where
        [TestMethod]
        public void GetAddressList_Skip_Take_Asc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                     AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                     addressService.Query = addressService.FillQuery(typeof(Address), culture.TwoLetterISOLanguageName, 0, 1, "AddressID", "", "AddressID,GT,2|AddressID,LT,5");

                     List<Address> addressDirectQueryList = new List<Address>();
                     addressDirectQueryList = (from c in dbTestDB.Addresses select c).Where(c => c.AddressID > 2 && c.AddressID < 5).Skip(0).Take(1).OrderBy(c => c.AddressID).ToList();

                        List<Address> addressList = new List<Address>();
                        addressList = addressService.GetAddressList().ToList();
                        CheckAddressFields(addressList);
                        Assert.AreEqual(addressDirectQueryList[0].AddressID, addressList[0].AddressID);
                }
            }
        }
        #endregion Tests Generated for GetAddressList() Skip Take Asc 2 Where

        #region Tests Generated for GetAddressList() Skip Take Desc
        [TestMethod]
        public void GetAddressList_Skip_Take_Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    addressService.Query = addressService.FillQuery(typeof(Address), culture.TwoLetterISOLanguageName, 1, 1, "", "AddressID", "");

                    List<Address> addressDirectQueryList = new List<Address>();
                    addressDirectQueryList = (from c in dbTestDB.Addresses select c).OrderByDescending(c => c.AddressID).Skip(1).Take(1).ToList();

                        List<Address> addressList = new List<Address>();
                        addressList = addressService.GetAddressList().ToList();
                        CheckAddressFields(addressList);
                        Assert.AreEqual(addressDirectQueryList[0].AddressID, addressList[0].AddressID);
                }
            }
        }
        #endregion Tests Generated for GetAddressList() Skip Take Desc

        #region Tests Generated for GetAddressList() Skip Take 2 Desc
        [TestMethod]
        public void GetAddressList_Skip_Take_2Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    addressService.Query = addressService.FillQuery(typeof(Address), culture.TwoLetterISOLanguageName, 1, 1, "", "AddressID,AddressTVItemID", "");

                    List<Address> addressDirectQueryList = new List<Address>();
                    addressDirectQueryList = (from c in dbTestDB.Addresses select c).OrderByDescending(c => c.AddressID).ThenByDescending(c => c.AddressTVItemID).Skip(1).Take(1).ToList();

                        List<Address> addressList = new List<Address>();
                        addressList = addressService.GetAddressList().ToList();
                        CheckAddressFields(addressList);
                        Assert.AreEqual(addressDirectQueryList[0].AddressID, addressList[0].AddressID);
                }
            }
        }
        #endregion Tests Generated for GetAddressList() Skip Take 2 Desc

        #region Tests Generated for GetAddressList() Skip Take Desc Where
        [TestMethod]
        public void GetAddressList_Skip_Take_Desc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    addressService.Query = addressService.FillQuery(typeof(Address), culture.TwoLetterISOLanguageName, 0, 1, "AddressID", "", "AddressID,EQ,4");

                    List<Address> addressDirectQueryList = new List<Address>();
                    addressDirectQueryList = (from c in dbTestDB.Addresses select c).Where(c => c.AddressID == 4).OrderByDescending(c => c.AddressID).Skip(0).Take(1).ToList();

                        List<Address> addressList = new List<Address>();
                        addressList = addressService.GetAddressList().ToList();
                        CheckAddressFields(addressList);
                        Assert.AreEqual(addressDirectQueryList[0].AddressID, addressList[0].AddressID);
                }
            }
        }
        #endregion Tests Generated for GetAddressList() Skip Take Desc Where

        #region Tests Generated for GetAddressList() Skip Take Desc 2 Where
        [TestMethod]
        public void GetAddressList_Skip_Take_Desc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    addressService.Query = addressService.FillQuery(typeof(Address), culture.TwoLetterISOLanguageName, 0, 1, "", "AddressID", "AddressID,GT,2|AddressID,LT,5");

                    List<Address> addressDirectQueryList = new List<Address>();
                    addressDirectQueryList = (from c in dbTestDB.Addresses select c).Where(c => c.AddressID > 2 && c.AddressID < 5).OrderByDescending(c => c.AddressID).Skip(0).Take(1).ToList();

                        List<Address> addressList = new List<Address>();
                        addressList = addressService.GetAddressList().ToList();
                        CheckAddressFields(addressList);
                        Assert.AreEqual(addressDirectQueryList[0].AddressID, addressList[0].AddressID);
                }
            }
        }
        #endregion Tests Generated for GetAddressList() Skip Take Desc 2 Where

        #region Tests Generated for GetAddressList() 2 Where
        [TestMethod]
        public void GetAddressList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    addressService.Query = addressService.FillQuery(typeof(Address), culture.TwoLetterISOLanguageName, 0, 10000, "", "", "AddressID,GT,2|AddressID,LT,5");

                    List<Address> addressDirectQueryList = new List<Address>();
                    addressDirectQueryList = (from c in dbTestDB.Addresses select c).Where(c => c.AddressID > 2 && c.AddressID < 5).ToList();

                        List<Address> addressList = new List<Address>();
                        addressList = addressService.GetAddressList().ToList();
                        CheckAddressFields(addressList);
                        Assert.AreEqual(addressDirectQueryList[0].AddressID, addressList[0].AddressID);
                }
            }
        }
        #endregion Tests Generated for GetAddressList() 2 Where

        #region Functions private
        private void CheckAddressFields(List<Address> addressList)
        {
            Assert.IsNotNull(addressList[0].AddressID);
            Assert.IsNotNull(addressList[0].AddressTVItemID);
            Assert.IsNotNull(addressList[0].AddressType);
            Assert.IsNotNull(addressList[0].CountryTVItemID);
            Assert.IsNotNull(addressList[0].ProvinceTVItemID);
            Assert.IsNotNull(addressList[0].MunicipalityTVItemID);
            if (!string.IsNullOrWhiteSpace(addressList[0].StreetName))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(addressList[0].StreetName));
            }
            if (!string.IsNullOrWhiteSpace(addressList[0].StreetNumber))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(addressList[0].StreetNumber));
            }
            if (addressList[0].StreetType != null)
            {
                Assert.IsNotNull(addressList[0].StreetType);
            }
            if (!string.IsNullOrWhiteSpace(addressList[0].PostalCode))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(addressList[0].PostalCode));
            }
            if (!string.IsNullOrWhiteSpace(addressList[0].GoogleAddressText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(addressList[0].GoogleAddressText));
            }
            Assert.IsNotNull(addressList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(addressList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(addressList[0].HasErrors);
        }
        private Address GetFilledRandomAddress(string OmitPropName)
        {
            Address address = new Address();

            if (OmitPropName != "AddressTVItemID") address.AddressTVItemID = 46;
            if (OmitPropName != "AddressType") address.AddressType = (AddressTypeEnum)GetRandomEnumType(typeof(AddressTypeEnum));
            if (OmitPropName != "CountryTVItemID") address.CountryTVItemID = 5;
            if (OmitPropName != "ProvinceTVItemID") address.ProvinceTVItemID = 6;
            if (OmitPropName != "MunicipalityTVItemID") address.MunicipalityTVItemID = 39;
            if (OmitPropName != "StreetName") address.StreetName = GetRandomString("", 5);
            if (OmitPropName != "StreetNumber") address.StreetNumber = GetRandomString("", 5);
            if (OmitPropName != "StreetType") address.StreetType = (StreetTypeEnum)GetRandomEnumType(typeof(StreetTypeEnum));
            if (OmitPropName != "PostalCode") address.PostalCode = GetRandomString("", 11);
            if (OmitPropName != "GoogleAddressText") address.GoogleAddressText = GetRandomString("", 15);
            if (OmitPropName != "LastUpdateDate_UTC") address.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") address.LastUpdateContactTVItemID = 2;

            return address;
        }
        #endregion Functions private
    }
}
