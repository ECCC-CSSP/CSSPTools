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

    public partial class MWQMRunLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MWQMRunLanguageService mwqmRunLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunLanguageServiceTest() : base()
        {
            //mwqmRunLanguageService = new MWQMRunLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Fact]
        public void MWQMRunLanguage_CRUD_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MWQMRunLanguage mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = mwqmRunLanguageService.GetMWQMRunLanguageList().Count();

                    Assert.Equal(count, (from c in dbTestDB.MWQMRunLanguages select c).Count());

                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    if (mwqmRunLanguage.HasErrors)
                    {
                        Assert.Equal("", mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.True(mwqmRunLanguageService.GetMWQMRunLanguageList().Where(c => c == mwqmRunLanguage).Any());
                    mwqmRunLanguageService.Update(mwqmRunLanguage);
                    if (mwqmRunLanguage.HasErrors)
                    {
                        Assert.Equal("", mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.Equal(count + 1, mwqmRunLanguageService.GetMWQMRunLanguageList().Count());
                    mwqmRunLanguageService.Delete(mwqmRunLanguage);
                    if (mwqmRunLanguage.HasErrors)
                    {
                        Assert.Equal("", mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.Equal(count, mwqmRunLanguageService.GetMWQMRunLanguageList().Count());

                }
            }
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Fact]
        public void MWQMRunLanguage_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    count = mwqmRunLanguageService.GetMWQMRunLanguageList().Count();

                    MWQMRunLanguage mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mwqmRunLanguage.MWQMRunLanguageID   (Int32)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.MWQMRunLanguageID = 0;
                    mwqmRunLanguageService.Update(mwqmRunLanguage);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "MWQMRunLanguageID"), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.MWQMRunLanguageID = 10000000;
                    mwqmRunLanguageService.Update(mwqmRunLanguage);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMRunLanguage", "MWQMRunLanguageID", mwqmRunLanguage.MWQMRunLanguageID.ToString()), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "MWQMRun", ExistPlurial = "s", ExistFieldID = "MWQMRunID", AllowableTVtypeList = )]
                    // mwqmRunLanguage.MWQMRunID   (Int32)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.MWQMRunID = 0;
                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMRun", "MWQMRunID", mwqmRunLanguage.MWQMRunID.ToString()), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mwqmRunLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.Language = (LanguageEnum)1000000;
                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "Language"), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // mwqmRunLanguage.RunComment   (String)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("RunComment");
                    Assert.False(mwqmRunLanguageService.Add(mwqmRunLanguage));
                    Assert.Equal(1, mwqmRunLanguage.ValidationResults.Count());
                    Assert.True(mwqmRunLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "RunComment")).Any());
                    Assert.Null(mwqmRunLanguage.RunComment);
                    Assert.Equal(count, mwqmRunLanguageService.GetMWQMRunLanguageList().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mwqmRunLanguage.TranslationStatusRunComment   (TranslationStatusEnum)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.TranslationStatusRunComment = (TranslationStatusEnum)1000000;
                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "TranslationStatusRunComment"), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // mwqmRunLanguage.RunWeatherComment   (String)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("RunWeatherComment");
                    Assert.False(mwqmRunLanguageService.Add(mwqmRunLanguage));
                    Assert.Equal(1, mwqmRunLanguage.ValidationResults.Count());
                    Assert.True(mwqmRunLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "RunWeatherComment")).Any());
                    Assert.Null(mwqmRunLanguage.RunWeatherComment);
                    Assert.Equal(count, mwqmRunLanguageService.GetMWQMRunLanguageList().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mwqmRunLanguage.TranslationStatusRunWeatherComment   (TranslationStatusEnum)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.TranslationStatusRunWeatherComment = (TranslationStatusEnum)1000000;
                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "TranslationStatusRunWeatherComment"), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmRunLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.LastUpdateDate_UTC = new DateTime();
                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    Assert.Equal(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmRunLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.LastUpdateContactTVItemID = 0;
                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mwqmRunLanguage.LastUpdateContactTVItemID.ToString()), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.LastUpdateContactTVItemID = 1;
                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    Assert.Equal(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmRunLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmRunLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated Properties

        #region Tests Generated for GetMWQMRunLanguageWithMWQMRunLanguageID(mwqmRunLanguage.MWQMRunLanguageID)
        [Fact]
        public void GetMWQMRunLanguageWithMWQMRunLanguageID__mwqmRunLanguage_MWQMRunLanguageID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMRunLanguage mwqmRunLanguage = (from c in dbTestDB.MWQMRunLanguages select c).FirstOrDefault();
                    Assert.NotNull(mwqmRunLanguage);

                }
            }
        }
        #endregion Tests Generated for GetMWQMRunLanguageWithMWQMRunLanguageID(mwqmRunLanguage.MWQMRunLanguageID)

        #region Tests Generated for GetMWQMRunLanguageList()
        [Fact]
        public void GetMWQMRunLanguageList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMRunLanguage mwqmRunLanguage = (from c in dbTestDB.MWQMRunLanguages select c).FirstOrDefault();
                    Assert.NotNull(mwqmRunLanguage);

                    List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                    mwqmRunLanguageDirectQueryList = (from c in dbTestDB.MWQMRunLanguages select c).Take(200).ToList();

                }
            }
        }
        #endregion Tests Generated for GetMWQMRunLanguageList()

        #region Tests Generated for GetMWQMRunLanguageList() Skip Take
        [Fact]
        public void GetMWQMRunLanguageList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "");

                    List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                    mwqmRunLanguageDirectQueryList = (from c in dbTestDB.MWQMRunLanguages select c).Skip(1).Take(1).ToList();

                        List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                        mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                        Assert.Equal(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunLanguageList() Skip Take

        #region Tests Generated for GetMWQMRunLanguageList() Skip Take Asc
        [Fact]
        public void GetMWQMRunLanguageList_Skip_Take_Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "MWQMRunLanguageID", "", "");

                    List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                    mwqmRunLanguageDirectQueryList = (from c in dbTestDB.MWQMRunLanguages select c).OrderBy(c => c.MWQMRunLanguageID).Skip(1).Take(1).ToList();

                        List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                        mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                        Assert.Equal(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunLanguageList() Skip Take Asc

        #region Tests Generated for GetMWQMRunLanguageList() Skip Take 2 Asc
        [Fact]
        public void GetMWQMRunLanguageList_Skip_Take_2Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 1, 1, "MWQMRunLanguageID,MWQMRunID", "", "");

                    List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                    mwqmRunLanguageDirectQueryList = (from c in dbTestDB.MWQMRunLanguages select c).OrderBy(c => c.MWQMRunLanguageID).ThenBy(c => c.MWQMRunID).Skip(1).Take(1).ToList();

                        List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                        mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                        Assert.Equal(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunLanguageList() Skip Take 2 Asc

        #region Tests Generated for GetMWQMRunLanguageList() Skip Take Asc Where
        [Fact]
        public void GetMWQMRunLanguageList_Skip_Take_Asc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 0, 1, "MWQMRunLanguageID", "", "MWQMRunLanguageID,EQ,4");

                    List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                    mwqmRunLanguageDirectQueryList = (from c in dbTestDB.MWQMRunLanguages select c).Where(c => c.MWQMRunLanguageID == 4).OrderBy(c => c.MWQMRunLanguageID).Skip(0).Take(1).ToList();

                        List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                        mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                        Assert.Equal(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunLanguageList() Skip Take Asc Where

        #region Tests Generated for GetMWQMRunLanguageList() Skip Take Asc 2 Where
        [Fact]
        public void GetMWQMRunLanguageList_Skip_Take_Asc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                     MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                     mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 0, 1, "MWQMRunLanguageID", "", "MWQMRunLanguageID,GT,2|MWQMRunLanguageID,LT,5");

                     List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                     mwqmRunLanguageDirectQueryList = (from c in dbTestDB.MWQMRunLanguages select c).Where(c => c.MWQMRunLanguageID > 2 && c.MWQMRunLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.MWQMRunLanguageID).ToList();

                        List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                        mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                        Assert.Equal(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunLanguageList() Skip Take Asc 2 Where

        #region Tests Generated for GetMWQMRunLanguageList() Skip Take Desc
        [Fact]
        public void GetMWQMRunLanguageList_Skip_Take_Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "MWQMRunLanguageID", "");

                    List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                    mwqmRunLanguageDirectQueryList = (from c in dbTestDB.MWQMRunLanguages select c).OrderByDescending(c => c.MWQMRunLanguageID).Skip(1).Take(1).ToList();

                        List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                        mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                        Assert.Equal(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunLanguageList() Skip Take Desc

        #region Tests Generated for GetMWQMRunLanguageList() Skip Take 2 Desc
        [Fact]
        public void GetMWQMRunLanguageList_Skip_Take_2Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "MWQMRunLanguageID,MWQMRunID", "");

                    List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                    mwqmRunLanguageDirectQueryList = (from c in dbTestDB.MWQMRunLanguages select c).OrderByDescending(c => c.MWQMRunLanguageID).ThenByDescending(c => c.MWQMRunID).Skip(1).Take(1).ToList();

                        List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                        mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                        Assert.Equal(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunLanguageList() Skip Take 2 Desc

        #region Tests Generated for GetMWQMRunLanguageList() Skip Take Desc Where
        [Fact]
        public void GetMWQMRunLanguageList_Skip_Take_Desc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 0, 1, "MWQMRunLanguageID", "", "MWQMRunLanguageID,EQ,4");

                    List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                    mwqmRunLanguageDirectQueryList = (from c in dbTestDB.MWQMRunLanguages select c).Where(c => c.MWQMRunLanguageID == 4).OrderByDescending(c => c.MWQMRunLanguageID).Skip(0).Take(1).ToList();

                        List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                        mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                        Assert.Equal(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunLanguageList() Skip Take Desc Where

        #region Tests Generated for GetMWQMRunLanguageList() Skip Take Desc 2 Where
        [Fact]
        public void GetMWQMRunLanguageList_Skip_Take_Desc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 0, 1, "", "MWQMRunLanguageID", "MWQMRunLanguageID,GT,2|MWQMRunLanguageID,LT,5");

                    List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                    mwqmRunLanguageDirectQueryList = (from c in dbTestDB.MWQMRunLanguages select c).Where(c => c.MWQMRunLanguageID > 2 && c.MWQMRunLanguageID < 5).OrderByDescending(c => c.MWQMRunLanguageID).Skip(0).Take(1).ToList();

                        List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                        mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                        Assert.Equal(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunLanguageList() Skip Take Desc 2 Where

        #region Tests Generated for GetMWQMRunLanguageList() 2 Where
        [Fact]
        public void GetMWQMRunLanguageList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "", "MWQMRunLanguageID,GT,2|MWQMRunLanguageID,LT,5");

                    List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                    mwqmRunLanguageDirectQueryList = (from c in dbTestDB.MWQMRunLanguages select c).Where(c => c.MWQMRunLanguageID > 2 && c.MWQMRunLanguageID < 5).ToList();

                        List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                        mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                        Assert.Equal(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunLanguageList() 2 Where

        #region Functions private
        private void CheckMWQMRunLanguageFields(List<MWQMRunLanguage> mwqmRunLanguageList)
        {
            Assert.NotNull(mwqmRunLanguageList[0].MWQMRunLanguageID);
            Assert.NotNull(mwqmRunLanguageList[0].MWQMRunID);
            Assert.NotNull(mwqmRunLanguageList[0].Language);
            Assert.False(string.IsNullOrWhiteSpace(mwqmRunLanguageList[0].RunComment));
            Assert.NotNull(mwqmRunLanguageList[0].TranslationStatusRunComment);
            Assert.False(string.IsNullOrWhiteSpace(mwqmRunLanguageList[0].RunWeatherComment));
            Assert.NotNull(mwqmRunLanguageList[0].TranslationStatusRunWeatherComment);
            Assert.NotNull(mwqmRunLanguageList[0].LastUpdateDate_UTC);
            Assert.NotNull(mwqmRunLanguageList[0].LastUpdateContactTVItemID);
            Assert.NotNull(mwqmRunLanguageList[0].HasErrors);
        }
        private MWQMRunLanguage GetFilledRandomMWQMRunLanguage(string OmitPropName)
        {
            MWQMRunLanguage mwqmRunLanguage = new MWQMRunLanguage();

            if (OmitPropName != "MWQMRunID") mwqmRunLanguage.MWQMRunID = 1;
            if (OmitPropName != "Language") mwqmRunLanguage.Language = LanguageRequest;
            if (OmitPropName != "RunComment") mwqmRunLanguage.RunComment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatusRunComment") mwqmRunLanguage.TranslationStatusRunComment = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "RunWeatherComment") mwqmRunLanguage.RunWeatherComment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatusRunWeatherComment") mwqmRunLanguage.TranslationStatusRunWeatherComment = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mwqmRunLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmRunLanguage.LastUpdateContactTVItemID = 2;

            return mwqmRunLanguage;
        }
        #endregion Functions private
    }
}
