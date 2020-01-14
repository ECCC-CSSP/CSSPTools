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

    public partial class AppTaskLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private AppTaskLanguageService appTaskLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskLanguageServiceTest() : base()
        {
            //appTaskLanguageService = new AppTaskLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Fact]
        public void AppTaskLanguage_CRUD_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    AppTaskLanguage appTaskLanguage = GetFilledRandomAppTaskLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = appTaskLanguageService.GetAppTaskLanguageList().Count();

                    Assert.Equal(count, (from c in dbTestDB.AppTaskLanguages select c).Count());

                    appTaskLanguageService.Add(appTaskLanguage);
                    if (appTaskLanguage.HasErrors)
                    {
                        Assert.Equal("", appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.True(appTaskLanguageService.GetAppTaskLanguageList().Where(c => c == appTaskLanguage).Any());
                    appTaskLanguageService.Update(appTaskLanguage);
                    if (appTaskLanguage.HasErrors)
                    {
                        Assert.Equal("", appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.Equal(count + 1, appTaskLanguageService.GetAppTaskLanguageList().Count());
                    appTaskLanguageService.Delete(appTaskLanguage);
                    if (appTaskLanguage.HasErrors)
                    {
                        Assert.Equal("", appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.Equal(count, appTaskLanguageService.GetAppTaskLanguageList().Count());

                }
            }
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Fact]
        public void AppTaskLanguage_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    count = appTaskLanguageService.GetAppTaskLanguageList().Count();

                    AppTaskLanguage appTaskLanguage = GetFilledRandomAppTaskLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // appTaskLanguage.AppTaskLanguageID   (Int32)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.AppTaskLanguageID = 0;
                    appTaskLanguageService.Update(appTaskLanguage);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "AppTaskLanguageID"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.AppTaskLanguageID = 10000000;
                    appTaskLanguageService.Update(appTaskLanguage);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "AppTaskLanguageID", appTaskLanguage.AppTaskLanguageID.ToString()), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "AppTask", ExistPlurial = "s", ExistFieldID = "AppTaskID", AllowableTVtypeList = )]
                    // appTaskLanguage.AppTaskID   (Int32)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.AppTaskID = 0;
                    appTaskLanguageService.Add(appTaskLanguage);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTaskLanguage.AppTaskID.ToString()), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // appTaskLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.Language = (LanguageEnum)1000000;
                    appTaskLanguageService.Add(appTaskLanguage);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "Language"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(250))]
                    // appTaskLanguage.StatusText   (String)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.StatusText = GetRandomString("", 251);
                    Assert.False(appTaskLanguageService.Add(appTaskLanguage));
                    Assert.Equal(string.Format(CSSPServicesRes._MaxLengthIs_, "StatusText", "250"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(count, appTaskLanguageService.GetAppTaskLanguageList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(250))]
                    // appTaskLanguage.ErrorText   (String)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.ErrorText = GetRandomString("", 251);
                    Assert.False(appTaskLanguageService.Add(appTaskLanguage));
                    Assert.Equal(string.Format(CSSPServicesRes._MaxLengthIs_, "ErrorText", "250"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(count, appTaskLanguageService.GetAppTaskLanguageList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // appTaskLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    appTaskLanguageService.Add(appTaskLanguage);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "TranslationStatus"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // appTaskLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.LastUpdateDate_UTC = new DateTime();
                    appTaskLanguageService.Add(appTaskLanguage);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    appTaskLanguageService.Add(appTaskLanguage);
                    Assert.Equal(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // appTaskLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.LastUpdateContactTVItemID = 0;
                    appTaskLanguageService.Add(appTaskLanguage);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", appTaskLanguage.LastUpdateContactTVItemID.ToString()), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.LastUpdateContactTVItemID = 1;
                    appTaskLanguageService.Add(appTaskLanguage);
                    Assert.Equal(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // appTaskLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // appTaskLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated Properties

        #region Tests Generated for GetAppTaskLanguageWithAppTaskLanguageID(appTaskLanguage.AppTaskLanguageID)
        [Fact]
        public void GetAppTaskLanguageWithAppTaskLanguageID__appTaskLanguage_AppTaskLanguageID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    AppTaskLanguage appTaskLanguage = (from c in dbTestDB.AppTaskLanguages select c).FirstOrDefault();
                    Assert.NotNull(appTaskLanguage);

                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageWithAppTaskLanguageID(appTaskLanguage.AppTaskLanguageID)

        #region Tests Generated for GetAppTaskLanguageList()
        [Fact]
        public void GetAppTaskLanguageList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    AppTaskLanguage appTaskLanguage = (from c in dbTestDB.AppTaskLanguages select c).FirstOrDefault();
                    Assert.NotNull(appTaskLanguage);

                    List<AppTaskLanguage> appTaskLanguageDirectQueryList = new List<AppTaskLanguage>();
                    appTaskLanguageDirectQueryList = (from c in dbTestDB.AppTaskLanguages select c).Take(200).ToList();

                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageList()

        #region Tests Generated for GetAppTaskLanguageList() Skip Take
        [Fact]
        public void GetAppTaskLanguageList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "");

                    List<AppTaskLanguage> appTaskLanguageDirectQueryList = new List<AppTaskLanguage>();
                    appTaskLanguageDirectQueryList = (from c in dbTestDB.AppTaskLanguages select c).Skip(1).Take(1).ToList();

                        List<AppTaskLanguage> appTaskLanguageList = new List<AppTaskLanguage>();
                        appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                        CheckAppTaskLanguageFields(appTaskLanguageList);
                        Assert.Equal(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageList[0].AppTaskLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageList() Skip Take

        #region Tests Generated for GetAppTaskLanguageList() Skip Take Asc
        [Fact]
        public void GetAppTaskLanguageList_Skip_Take_Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "AppTaskLanguageID", "", "");

                    List<AppTaskLanguage> appTaskLanguageDirectQueryList = new List<AppTaskLanguage>();
                    appTaskLanguageDirectQueryList = (from c in dbTestDB.AppTaskLanguages select c).OrderBy(c => c.AppTaskLanguageID).Skip(1).Take(1).ToList();

                        List<AppTaskLanguage> appTaskLanguageList = new List<AppTaskLanguage>();
                        appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                        CheckAppTaskLanguageFields(appTaskLanguageList);
                        Assert.Equal(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageList[0].AppTaskLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageList() Skip Take Asc

        #region Tests Generated for GetAppTaskLanguageList() Skip Take 2 Asc
        [Fact]
        public void GetAppTaskLanguageList_Skip_Take_2Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguage), culture.TwoLetterISOLanguageName, 1, 1, "AppTaskLanguageID,AppTaskID", "", "");

                    List<AppTaskLanguage> appTaskLanguageDirectQueryList = new List<AppTaskLanguage>();
                    appTaskLanguageDirectQueryList = (from c in dbTestDB.AppTaskLanguages select c).OrderBy(c => c.AppTaskLanguageID).ThenBy(c => c.AppTaskID).Skip(1).Take(1).ToList();

                        List<AppTaskLanguage> appTaskLanguageList = new List<AppTaskLanguage>();
                        appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                        CheckAppTaskLanguageFields(appTaskLanguageList);
                        Assert.Equal(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageList[0].AppTaskLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageList() Skip Take 2 Asc

        #region Tests Generated for GetAppTaskLanguageList() Skip Take Asc Where
        [Fact]
        public void GetAppTaskLanguageList_Skip_Take_Asc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguage), culture.TwoLetterISOLanguageName, 0, 1, "AppTaskLanguageID", "", "AppTaskLanguageID,EQ,4");

                    List<AppTaskLanguage> appTaskLanguageDirectQueryList = new List<AppTaskLanguage>();
                    appTaskLanguageDirectQueryList = (from c in dbTestDB.AppTaskLanguages select c).Where(c => c.AppTaskLanguageID == 4).OrderBy(c => c.AppTaskLanguageID).Skip(0).Take(1).ToList();

                        List<AppTaskLanguage> appTaskLanguageList = new List<AppTaskLanguage>();
                        appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                        CheckAppTaskLanguageFields(appTaskLanguageList);
                        Assert.Equal(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageList[0].AppTaskLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageList() Skip Take Asc Where

        #region Tests Generated for GetAppTaskLanguageList() Skip Take Asc 2 Where
        [Fact]
        public void GetAppTaskLanguageList_Skip_Take_Asc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                     AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                     appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguage), culture.TwoLetterISOLanguageName, 0, 1, "AppTaskLanguageID", "", "AppTaskLanguageID,GT,2|AppTaskLanguageID,LT,5");

                     List<AppTaskLanguage> appTaskLanguageDirectQueryList = new List<AppTaskLanguage>();
                     appTaskLanguageDirectQueryList = (from c in dbTestDB.AppTaskLanguages select c).Where(c => c.AppTaskLanguageID > 2 && c.AppTaskLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.AppTaskLanguageID).ToList();

                        List<AppTaskLanguage> appTaskLanguageList = new List<AppTaskLanguage>();
                        appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                        CheckAppTaskLanguageFields(appTaskLanguageList);
                        Assert.Equal(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageList[0].AppTaskLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageList() Skip Take Asc 2 Where

        #region Tests Generated for GetAppTaskLanguageList() Skip Take Desc
        [Fact]
        public void GetAppTaskLanguageList_Skip_Take_Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "AppTaskLanguageID", "");

                    List<AppTaskLanguage> appTaskLanguageDirectQueryList = new List<AppTaskLanguage>();
                    appTaskLanguageDirectQueryList = (from c in dbTestDB.AppTaskLanguages select c).OrderByDescending(c => c.AppTaskLanguageID).Skip(1).Take(1).ToList();

                        List<AppTaskLanguage> appTaskLanguageList = new List<AppTaskLanguage>();
                        appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                        CheckAppTaskLanguageFields(appTaskLanguageList);
                        Assert.Equal(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageList[0].AppTaskLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageList() Skip Take Desc

        #region Tests Generated for GetAppTaskLanguageList() Skip Take 2 Desc
        [Fact]
        public void GetAppTaskLanguageList_Skip_Take_2Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "AppTaskLanguageID,AppTaskID", "");

                    List<AppTaskLanguage> appTaskLanguageDirectQueryList = new List<AppTaskLanguage>();
                    appTaskLanguageDirectQueryList = (from c in dbTestDB.AppTaskLanguages select c).OrderByDescending(c => c.AppTaskLanguageID).ThenByDescending(c => c.AppTaskID).Skip(1).Take(1).ToList();

                        List<AppTaskLanguage> appTaskLanguageList = new List<AppTaskLanguage>();
                        appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                        CheckAppTaskLanguageFields(appTaskLanguageList);
                        Assert.Equal(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageList[0].AppTaskLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageList() Skip Take 2 Desc

        #region Tests Generated for GetAppTaskLanguageList() Skip Take Desc Where
        [Fact]
        public void GetAppTaskLanguageList_Skip_Take_Desc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguage), culture.TwoLetterISOLanguageName, 0, 1, "AppTaskLanguageID", "", "AppTaskLanguageID,EQ,4");

                    List<AppTaskLanguage> appTaskLanguageDirectQueryList = new List<AppTaskLanguage>();
                    appTaskLanguageDirectQueryList = (from c in dbTestDB.AppTaskLanguages select c).Where(c => c.AppTaskLanguageID == 4).OrderByDescending(c => c.AppTaskLanguageID).Skip(0).Take(1).ToList();

                        List<AppTaskLanguage> appTaskLanguageList = new List<AppTaskLanguage>();
                        appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                        CheckAppTaskLanguageFields(appTaskLanguageList);
                        Assert.Equal(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageList[0].AppTaskLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageList() Skip Take Desc Where

        #region Tests Generated for GetAppTaskLanguageList() Skip Take Desc 2 Where
        [Fact]
        public void GetAppTaskLanguageList_Skip_Take_Desc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguage), culture.TwoLetterISOLanguageName, 0, 1, "", "AppTaskLanguageID", "AppTaskLanguageID,GT,2|AppTaskLanguageID,LT,5");

                    List<AppTaskLanguage> appTaskLanguageDirectQueryList = new List<AppTaskLanguage>();
                    appTaskLanguageDirectQueryList = (from c in dbTestDB.AppTaskLanguages select c).Where(c => c.AppTaskLanguageID > 2 && c.AppTaskLanguageID < 5).OrderByDescending(c => c.AppTaskLanguageID).Skip(0).Take(1).ToList();

                        List<AppTaskLanguage> appTaskLanguageList = new List<AppTaskLanguage>();
                        appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                        CheckAppTaskLanguageFields(appTaskLanguageList);
                        Assert.Equal(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageList[0].AppTaskLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageList() Skip Take Desc 2 Where

        #region Tests Generated for GetAppTaskLanguageList() 2 Where
        [Fact]
        public void GetAppTaskLanguageList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "", "AppTaskLanguageID,GT,2|AppTaskLanguageID,LT,5");

                    List<AppTaskLanguage> appTaskLanguageDirectQueryList = new List<AppTaskLanguage>();
                    appTaskLanguageDirectQueryList = (from c in dbTestDB.AppTaskLanguages select c).Where(c => c.AppTaskLanguageID > 2 && c.AppTaskLanguageID < 5).ToList();

                        List<AppTaskLanguage> appTaskLanguageList = new List<AppTaskLanguage>();
                        appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                        CheckAppTaskLanguageFields(appTaskLanguageList);
                        Assert.Equal(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageList[0].AppTaskLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageList() 2 Where

        #region Functions private
        private void CheckAppTaskLanguageFields(List<AppTaskLanguage> appTaskLanguageList)
        {
            Assert.NotNull(appTaskLanguageList[0].AppTaskLanguageID);
            Assert.NotNull(appTaskLanguageList[0].AppTaskID);
            Assert.NotNull(appTaskLanguageList[0].Language);
            if (!string.IsNullOrWhiteSpace(appTaskLanguageList[0].StatusText))
            {
                Assert.False(string.IsNullOrWhiteSpace(appTaskLanguageList[0].StatusText));
            }
            if (!string.IsNullOrWhiteSpace(appTaskLanguageList[0].ErrorText))
            {
                Assert.False(string.IsNullOrWhiteSpace(appTaskLanguageList[0].ErrorText));
            }
            Assert.NotNull(appTaskLanguageList[0].TranslationStatus);
            Assert.NotNull(appTaskLanguageList[0].LastUpdateDate_UTC);
            Assert.NotNull(appTaskLanguageList[0].LastUpdateContactTVItemID);
            Assert.NotNull(appTaskLanguageList[0].HasErrors);
        }
        private AppTaskLanguage GetFilledRandomAppTaskLanguage(string OmitPropName)
        {
            AppTaskLanguage appTaskLanguage = new AppTaskLanguage();

            if (OmitPropName != "AppTaskID") appTaskLanguage.AppTaskID = 1;
            if (OmitPropName != "Language") appTaskLanguage.Language = LanguageRequest;
            if (OmitPropName != "StatusText") appTaskLanguage.StatusText = GetRandomString("", 5);
            if (OmitPropName != "ErrorText") appTaskLanguage.ErrorText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") appTaskLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") appTaskLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") appTaskLanguage.LastUpdateContactTVItemID = 2;

            return appTaskLanguage;
        }
        #endregion Functions private
    }
}
