 /* Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

using System;
using Xunit;
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

    public partial class ContactShortcutServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ContactShortcutService contactShortcutService { get; set; }
        #endregion Properties

        #region Constructors
        public ContactShortcutServiceTest() : base()
        {
            //contactShortcutService = new ContactShortcutService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Fact]
        public void ContactShortcut_CRUD_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    ContactShortcut contactShortcut = GetFilledRandomContactShortcut("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = contactShortcutService.GetContactShortcutList().Count();

                    Assert.Equal(count, (from c in dbTestDB.ContactShortcuts select c).Count());

                    contactShortcutService.Add(contactShortcut);
                    if (contactShortcut.HasErrors)
                    {
                        Assert.Equal("", contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.True(contactShortcutService.GetContactShortcutList().Where(c => c == contactShortcut).Any());
                    contactShortcutService.Update(contactShortcut);
                    if (contactShortcut.HasErrors)
                    {
                        Assert.Equal("", contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.Equal(count + 1, contactShortcutService.GetContactShortcutList().Count());
                    contactShortcutService.Delete(contactShortcut);
                    if (contactShortcut.HasErrors)
                    {
                        Assert.Equal("", contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.Equal(count, contactShortcutService.GetContactShortcutList().Count());

                }
            }
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Fact]
        public void ContactShortcut_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    count = contactShortcutService.GetContactShortcutList().Count();

                    ContactShortcut contactShortcut = GetFilledRandomContactShortcut("");

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // contactShortcut.ContactShortcutID   (Int32)
                    // -----------------------------------

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.ContactShortcutID = 0;
                    contactShortcutService.Update(contactShortcut);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "ContactShortcutID"), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.ContactShortcutID = 10000000;
                    contactShortcutService.Update(contactShortcut);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ContactShortcut", "ContactShortcutID", contactShortcut.ContactShortcutID.ToString()), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "Contact", ExistPlurial = "s", ExistFieldID = "ContactID", AllowableTVtypeList = )]
                    // contactShortcut.ContactID   (Int32)
                    // -----------------------------------

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.ContactID = 0;
                    contactShortcutService.Add(contactShortcut);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Contact", "ContactID", contactShortcut.ContactID.ToString()), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // contactShortcut.ShortCutText   (String)
                    // -----------------------------------

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("ShortCutText");
                    Assert.False(contactShortcutService.Add(contactShortcut));
                    Assert.Equal(1, contactShortcut.ValidationResults.Count());
                    Assert.True(contactShortcut.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "ShortCutText")).Any());
                    Assert.Null(contactShortcut.ShortCutText);
                    Assert.Equal(count, contactShortcutService.GetContactShortcutList().Count());

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.ShortCutText = GetRandomString("", 101);
                    Assert.False(contactShortcutService.Add(contactShortcut));
                    Assert.Equal(string.Format(CSSPServicesRes._MaxLengthIs_, "ShortCutText", "100"), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(count, contactShortcutService.GetContactShortcutList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(200))]
                    // contactShortcut.ShortCutAddress   (String)
                    // -----------------------------------

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("ShortCutAddress");
                    Assert.False(contactShortcutService.Add(contactShortcut));
                    Assert.Equal(1, contactShortcut.ValidationResults.Count());
                    Assert.True(contactShortcut.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "ShortCutAddress")).Any());
                    Assert.Null(contactShortcut.ShortCutAddress);
                    Assert.Equal(count, contactShortcutService.GetContactShortcutList().Count());

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.ShortCutAddress = GetRandomString("", 201);
                    Assert.False(contactShortcutService.Add(contactShortcut));
                    Assert.Equal(string.Format(CSSPServicesRes._MaxLengthIs_, "ShortCutAddress", "200"), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(count, contactShortcutService.GetContactShortcutList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // contactShortcut.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.LastUpdateDate_UTC = new DateTime();
                    contactShortcutService.Add(contactShortcut);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    contactShortcutService.Add(contactShortcut);
                    Assert.Equal(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // contactShortcut.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.LastUpdateContactTVItemID = 0;
                    contactShortcutService.Add(contactShortcut);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", contactShortcut.LastUpdateContactTVItemID.ToString()), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.LastUpdateContactTVItemID = 1;
                    contactShortcutService.Add(contactShortcut);
                    Assert.Equal(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // contactShortcut.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // contactShortcut.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated Properties

        #region Tests Generated for GetContactShortcutWithContactShortcutID(contactShortcut.ContactShortcutID)
        [Fact]
        public void GetContactShortcutWithContactShortcutID__contactShortcut_ContactShortcutID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ContactShortcut contactShortcut = (from c in dbTestDB.ContactShortcuts select c).FirstOrDefault();
                    Assert.NotNull(contactShortcut);

                }
            }
        }
        #endregion Tests Generated for GetContactShortcutWithContactShortcutID(contactShortcut.ContactShortcutID)

        #region Tests Generated for GetContactShortcutList()
        [Fact]
        public void GetContactShortcutList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ContactShortcut contactShortcut = (from c in dbTestDB.ContactShortcuts select c).FirstOrDefault();
                    Assert.NotNull(contactShortcut);

                    List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                    contactShortcutDirectQueryList = (from c in dbTestDB.ContactShortcuts select c).Take(200).ToList();

                }
            }
        }
        #endregion Tests Generated for GetContactShortcutList()

        #region Tests Generated for GetContactShortcutList() Skip Take
        [Fact]
        public void GetContactShortcutList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), culture.TwoLetterISOLanguageName, 1, 1, "", "");

                    List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                    contactShortcutDirectQueryList = (from c in dbTestDB.ContactShortcuts select c).Skip(1).Take(1).ToList();

                        List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                        contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        CheckContactShortcutFields(contactShortcutList);
                        Assert.Equal(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcutList[0].ContactShortcutID);
                }
            }
        }
        #endregion Tests Generated for GetContactShortcutList() Skip Take

        #region Tests Generated for GetContactShortcutList() Skip Take Asc
        [Fact]
        public void GetContactShortcutList_Skip_Take_Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), culture.TwoLetterISOLanguageName, 1, 1,  "ContactShortcutID", "", "");

                    List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                    contactShortcutDirectQueryList = (from c in dbTestDB.ContactShortcuts select c).OrderBy(c => c.ContactShortcutID).Skip(1).Take(1).ToList();

                        List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                        contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        CheckContactShortcutFields(contactShortcutList);
                        Assert.Equal(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcutList[0].ContactShortcutID);
                }
            }
        }
        #endregion Tests Generated for GetContactShortcutList() Skip Take Asc

        #region Tests Generated for GetContactShortcutList() Skip Take 2 Asc
        [Fact]
        public void GetContactShortcutList_Skip_Take_2Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), culture.TwoLetterISOLanguageName, 1, 1, "ContactShortcutID,ContactID", "", "");

                    List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                    contactShortcutDirectQueryList = (from c in dbTestDB.ContactShortcuts select c).OrderBy(c => c.ContactShortcutID).ThenBy(c => c.ContactID).Skip(1).Take(1).ToList();

                        List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                        contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        CheckContactShortcutFields(contactShortcutList);
                        Assert.Equal(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcutList[0].ContactShortcutID);
                }
            }
        }
        #endregion Tests Generated for GetContactShortcutList() Skip Take 2 Asc

        #region Tests Generated for GetContactShortcutList() Skip Take Asc Where
        [Fact]
        public void GetContactShortcutList_Skip_Take_Asc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), culture.TwoLetterISOLanguageName, 0, 1, "ContactShortcutID", "", "ContactShortcutID,EQ,4");

                    List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                    contactShortcutDirectQueryList = (from c in dbTestDB.ContactShortcuts select c).Where(c => c.ContactShortcutID == 4).OrderBy(c => c.ContactShortcutID).Skip(0).Take(1).ToList();

                        List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                        contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        CheckContactShortcutFields(contactShortcutList);
                        Assert.Equal(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcutList[0].ContactShortcutID);
                }
            }
        }
        #endregion Tests Generated for GetContactShortcutList() Skip Take Asc Where

        #region Tests Generated for GetContactShortcutList() Skip Take Asc 2 Where
        [Fact]
        public void GetContactShortcutList_Skip_Take_Asc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                     ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                     contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), culture.TwoLetterISOLanguageName, 0, 1, "ContactShortcutID", "", "ContactShortcutID,GT,2|ContactShortcutID,LT,5");

                     List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                     contactShortcutDirectQueryList = (from c in dbTestDB.ContactShortcuts select c).Where(c => c.ContactShortcutID > 2 && c.ContactShortcutID < 5).Skip(0).Take(1).OrderBy(c => c.ContactShortcutID).ToList();

                        List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                        contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        CheckContactShortcutFields(contactShortcutList);
                        Assert.Equal(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcutList[0].ContactShortcutID);
                }
            }
        }
        #endregion Tests Generated for GetContactShortcutList() Skip Take Asc 2 Where

        #region Tests Generated for GetContactShortcutList() Skip Take Desc
        [Fact]
        public void GetContactShortcutList_Skip_Take_Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), culture.TwoLetterISOLanguageName, 1, 1, "", "ContactShortcutID", "");

                    List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                    contactShortcutDirectQueryList = (from c in dbTestDB.ContactShortcuts select c).OrderByDescending(c => c.ContactShortcutID).Skip(1).Take(1).ToList();

                        List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                        contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        CheckContactShortcutFields(contactShortcutList);
                        Assert.Equal(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcutList[0].ContactShortcutID);
                }
            }
        }
        #endregion Tests Generated for GetContactShortcutList() Skip Take Desc

        #region Tests Generated for GetContactShortcutList() Skip Take 2 Desc
        [Fact]
        public void GetContactShortcutList_Skip_Take_2Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), culture.TwoLetterISOLanguageName, 1, 1, "", "ContactShortcutID,ContactID", "");

                    List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                    contactShortcutDirectQueryList = (from c in dbTestDB.ContactShortcuts select c).OrderByDescending(c => c.ContactShortcutID).ThenByDescending(c => c.ContactID).Skip(1).Take(1).ToList();

                        List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                        contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        CheckContactShortcutFields(contactShortcutList);
                        Assert.Equal(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcutList[0].ContactShortcutID);
                }
            }
        }
        #endregion Tests Generated for GetContactShortcutList() Skip Take 2 Desc

        #region Tests Generated for GetContactShortcutList() Skip Take Desc Where
        [Fact]
        public void GetContactShortcutList_Skip_Take_Desc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), culture.TwoLetterISOLanguageName, 0, 1, "ContactShortcutID", "", "ContactShortcutID,EQ,4");

                    List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                    contactShortcutDirectQueryList = (from c in dbTestDB.ContactShortcuts select c).Where(c => c.ContactShortcutID == 4).OrderByDescending(c => c.ContactShortcutID).Skip(0).Take(1).ToList();

                        List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                        contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        CheckContactShortcutFields(contactShortcutList);
                        Assert.Equal(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcutList[0].ContactShortcutID);
                }
            }
        }
        #endregion Tests Generated for GetContactShortcutList() Skip Take Desc Where

        #region Tests Generated for GetContactShortcutList() Skip Take Desc 2 Where
        [Fact]
        public void GetContactShortcutList_Skip_Take_Desc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), culture.TwoLetterISOLanguageName, 0, 1, "", "ContactShortcutID", "ContactShortcutID,GT,2|ContactShortcutID,LT,5");

                    List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                    contactShortcutDirectQueryList = (from c in dbTestDB.ContactShortcuts select c).Where(c => c.ContactShortcutID > 2 && c.ContactShortcutID < 5).OrderByDescending(c => c.ContactShortcutID).Skip(0).Take(1).ToList();

                        List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                        contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        CheckContactShortcutFields(contactShortcutList);
                        Assert.Equal(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcutList[0].ContactShortcutID);
                }
            }
        }
        #endregion Tests Generated for GetContactShortcutList() Skip Take Desc 2 Where

        #region Tests Generated for GetContactShortcutList() 2 Where
        [Fact]
        public void GetContactShortcutList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), culture.TwoLetterISOLanguageName, 0, 10000, "", "", "ContactShortcutID,GT,2|ContactShortcutID,LT,5");

                    List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                    contactShortcutDirectQueryList = (from c in dbTestDB.ContactShortcuts select c).Where(c => c.ContactShortcutID > 2 && c.ContactShortcutID < 5).ToList();

                        List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                        contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        CheckContactShortcutFields(contactShortcutList);
                        Assert.Equal(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcutList[0].ContactShortcutID);
                }
            }
        }
        #endregion Tests Generated for GetContactShortcutList() 2 Where

        #region Functions private
        private void CheckContactShortcutFields(List<ContactShortcut> contactShortcutList)
        {
            Assert.NotNull(contactShortcutList[0].ContactShortcutID);
            Assert.NotNull(contactShortcutList[0].ContactID);
            Assert.False(string.IsNullOrWhiteSpace(contactShortcutList[0].ShortCutText));
            Assert.False(string.IsNullOrWhiteSpace(contactShortcutList[0].ShortCutAddress));
            Assert.NotNull(contactShortcutList[0].LastUpdateDate_UTC);
            Assert.NotNull(contactShortcutList[0].LastUpdateContactTVItemID);
            Assert.NotNull(contactShortcutList[0].HasErrors);
        }
        private ContactShortcut GetFilledRandomContactShortcut(string OmitPropName)
        {
            ContactShortcut contactShortcut = new ContactShortcut();

            if (OmitPropName != "ContactID") contactShortcut.ContactID = 1;
            if (OmitPropName != "ShortCutText") contactShortcut.ShortCutText = GetRandomString("", 5);
            if (OmitPropName != "ShortCutAddress") contactShortcut.ShortCutAddress = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") contactShortcut.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") contactShortcut.LastUpdateContactTVItemID = 2;

            return contactShortcut;
        }
        #endregion Functions private
    }
}
