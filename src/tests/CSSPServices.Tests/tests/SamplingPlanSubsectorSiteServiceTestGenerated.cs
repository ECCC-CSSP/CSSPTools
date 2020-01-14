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

    public partial class SamplingPlanSubsectorSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorSiteServiceTest() : base()
        {
            //samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Fact]
        public void SamplingPlanSubsectorSite_CRUD_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    SamplingPlanSubsectorSite samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().Count();

                    Assert.Equal(count, (from c in dbTestDB.SamplingPlanSubsectorSites select c).Count());

                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    if (samplingPlanSubsectorSite.HasErrors)
                    {
                        Assert.Equal("", samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.True(samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().Where(c => c == samplingPlanSubsectorSite).Any());
                    samplingPlanSubsectorSiteService.Update(samplingPlanSubsectorSite);
                    if (samplingPlanSubsectorSite.HasErrors)
                    {
                        Assert.Equal("", samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.Equal(count + 1, samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().Count());
                    samplingPlanSubsectorSiteService.Delete(samplingPlanSubsectorSite);
                    if (samplingPlanSubsectorSite.HasErrors)
                    {
                        Assert.Equal("", samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.Equal(count, samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().Count());

                }
            }
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Fact]
        public void SamplingPlanSubsectorSite_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    count = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().Count();

                    SamplingPlanSubsectorSite samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID   (Int32)
                    // -----------------------------------

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID = 0;
                    samplingPlanSubsectorSiteService.Update(samplingPlanSubsectorSite);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanSubsectorSiteID"), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID = 10000000;
                    samplingPlanSubsectorSiteService.Update(samplingPlanSubsectorSite);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsectorSite", "SamplingPlanSubsectorSiteID", samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID.ToString()), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "SamplingPlanSubsector", ExistPlurial = "s", ExistFieldID = "SamplingPlanSubsectorID", AllowableTVtypeList = )]
                    // samplingPlanSubsectorSite.SamplingPlanSubsectorID   (Int32)
                    // -----------------------------------

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.SamplingPlanSubsectorID = 0;
                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsector", "SamplingPlanSubsectorID", samplingPlanSubsectorSite.SamplingPlanSubsectorID.ToString()), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
                    // samplingPlanSubsectorSite.MWQMSiteTVItemID   (Int32)
                    // -----------------------------------

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.MWQMSiteTVItemID = 0;
                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSiteTVItemID", samplingPlanSubsectorSite.MWQMSiteTVItemID.ToString()), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.MWQMSiteTVItemID = 1;
                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    Assert.Equal(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSiteTVItemID", "MWQMSite"), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // samplingPlanSubsectorSite.IsDuplicate   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // samplingPlanSubsectorSite.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.LastUpdateDate_UTC = new DateTime();
                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    Assert.Equal(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // samplingPlanSubsectorSite.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.LastUpdateContactTVItemID = 0;
                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", samplingPlanSubsectorSite.LastUpdateContactTVItemID.ToString()), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.LastUpdateContactTVItemID = 1;
                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    Assert.Equal(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // samplingPlanSubsectorSite.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // samplingPlanSubsectorSite.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated Properties

        #region Tests Generated for GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteID(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID)
        [Fact]
        public void GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteID__samplingPlanSubsectorSite_SamplingPlanSubsectorSiteID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    SamplingPlanSubsectorSite samplingPlanSubsectorSite = (from c in dbTestDB.SamplingPlanSubsectorSites select c).FirstOrDefault();
                    Assert.NotNull(samplingPlanSubsectorSite);

                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteID(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID)

        #region Tests Generated for GetSamplingPlanSubsectorSiteList()
        [Fact]
        public void GetSamplingPlanSubsectorSiteList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    SamplingPlanSubsectorSite samplingPlanSubsectorSite = (from c in dbTestDB.SamplingPlanSubsectorSites select c).FirstOrDefault();
                    Assert.NotNull(samplingPlanSubsectorSite);

                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                    samplingPlanSubsectorSiteDirectQueryList = (from c in dbTestDB.SamplingPlanSubsectorSites select c).Take(200).ToList();

                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorSiteList()

        #region Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take
        [Fact]
        public void GetSamplingPlanSubsectorSiteList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), culture.TwoLetterISOLanguageName, 1, 1, "", "");

                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                    samplingPlanSubsectorSiteDirectQueryList = (from c in dbTestDB.SamplingPlanSubsectorSites select c).Skip(1).Take(1).ToList();

                        List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                        samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList);
                        Assert.Equal(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take

        #region Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take Asc
        [Fact]
        public void GetSamplingPlanSubsectorSiteList_Skip_Take_Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), culture.TwoLetterISOLanguageName, 1, 1,  "SamplingPlanSubsectorSiteID", "", "");

                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                    samplingPlanSubsectorSiteDirectQueryList = (from c in dbTestDB.SamplingPlanSubsectorSites select c).OrderBy(c => c.SamplingPlanSubsectorSiteID).Skip(1).Take(1).ToList();

                        List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                        samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList);
                        Assert.Equal(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take Asc

        #region Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take 2 Asc
        [Fact]
        public void GetSamplingPlanSubsectorSiteList_Skip_Take_2Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), culture.TwoLetterISOLanguageName, 1, 1, "SamplingPlanSubsectorSiteID,SamplingPlanSubsectorID", "", "");

                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                    samplingPlanSubsectorSiteDirectQueryList = (from c in dbTestDB.SamplingPlanSubsectorSites select c).OrderBy(c => c.SamplingPlanSubsectorSiteID).ThenBy(c => c.SamplingPlanSubsectorID).Skip(1).Take(1).ToList();

                        List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                        samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList);
                        Assert.Equal(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take 2 Asc

        #region Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take Asc Where
        [Fact]
        public void GetSamplingPlanSubsectorSiteList_Skip_Take_Asc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), culture.TwoLetterISOLanguageName, 0, 1, "SamplingPlanSubsectorSiteID", "", "SamplingPlanSubsectorSiteID,EQ,4");

                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                    samplingPlanSubsectorSiteDirectQueryList = (from c in dbTestDB.SamplingPlanSubsectorSites select c).Where(c => c.SamplingPlanSubsectorSiteID == 4).OrderBy(c => c.SamplingPlanSubsectorSiteID).Skip(0).Take(1).ToList();

                        List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                        samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList);
                        Assert.Equal(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take Asc Where

        #region Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take Asc 2 Where
        [Fact]
        public void GetSamplingPlanSubsectorSiteList_Skip_Take_Asc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                     SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                     samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), culture.TwoLetterISOLanguageName, 0, 1, "SamplingPlanSubsectorSiteID", "", "SamplingPlanSubsectorSiteID,GT,2|SamplingPlanSubsectorSiteID,LT,5");

                     List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                     samplingPlanSubsectorSiteDirectQueryList = (from c in dbTestDB.SamplingPlanSubsectorSites select c).Where(c => c.SamplingPlanSubsectorSiteID > 2 && c.SamplingPlanSubsectorSiteID < 5).Skip(0).Take(1).OrderBy(c => c.SamplingPlanSubsectorSiteID).ToList();

                        List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                        samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList);
                        Assert.Equal(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take Asc 2 Where

        #region Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take Desc
        [Fact]
        public void GetSamplingPlanSubsectorSiteList_Skip_Take_Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), culture.TwoLetterISOLanguageName, 1, 1, "", "SamplingPlanSubsectorSiteID", "");

                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                    samplingPlanSubsectorSiteDirectQueryList = (from c in dbTestDB.SamplingPlanSubsectorSites select c).OrderByDescending(c => c.SamplingPlanSubsectorSiteID).Skip(1).Take(1).ToList();

                        List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                        samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList);
                        Assert.Equal(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take Desc

        #region Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take 2 Desc
        [Fact]
        public void GetSamplingPlanSubsectorSiteList_Skip_Take_2Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), culture.TwoLetterISOLanguageName, 1, 1, "", "SamplingPlanSubsectorSiteID,SamplingPlanSubsectorID", "");

                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                    samplingPlanSubsectorSiteDirectQueryList = (from c in dbTestDB.SamplingPlanSubsectorSites select c).OrderByDescending(c => c.SamplingPlanSubsectorSiteID).ThenByDescending(c => c.SamplingPlanSubsectorID).Skip(1).Take(1).ToList();

                        List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                        samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList);
                        Assert.Equal(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take 2 Desc

        #region Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take Desc Where
        [Fact]
        public void GetSamplingPlanSubsectorSiteList_Skip_Take_Desc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), culture.TwoLetterISOLanguageName, 0, 1, "SamplingPlanSubsectorSiteID", "", "SamplingPlanSubsectorSiteID,EQ,4");

                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                    samplingPlanSubsectorSiteDirectQueryList = (from c in dbTestDB.SamplingPlanSubsectorSites select c).Where(c => c.SamplingPlanSubsectorSiteID == 4).OrderByDescending(c => c.SamplingPlanSubsectorSiteID).Skip(0).Take(1).ToList();

                        List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                        samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList);
                        Assert.Equal(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take Desc Where

        #region Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take Desc 2 Where
        [Fact]
        public void GetSamplingPlanSubsectorSiteList_Skip_Take_Desc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), culture.TwoLetterISOLanguageName, 0, 1, "", "SamplingPlanSubsectorSiteID", "SamplingPlanSubsectorSiteID,GT,2|SamplingPlanSubsectorSiteID,LT,5");

                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                    samplingPlanSubsectorSiteDirectQueryList = (from c in dbTestDB.SamplingPlanSubsectorSites select c).Where(c => c.SamplingPlanSubsectorSiteID > 2 && c.SamplingPlanSubsectorSiteID < 5).OrderByDescending(c => c.SamplingPlanSubsectorSiteID).Skip(0).Take(1).ToList();

                        List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                        samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList);
                        Assert.Equal(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take Desc 2 Where

        #region Tests Generated for GetSamplingPlanSubsectorSiteList() 2 Where
        [Fact]
        public void GetSamplingPlanSubsectorSiteList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), culture.TwoLetterISOLanguageName, 0, 10000, "", "", "SamplingPlanSubsectorSiteID,GT,2|SamplingPlanSubsectorSiteID,LT,5");

                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                    samplingPlanSubsectorSiteDirectQueryList = (from c in dbTestDB.SamplingPlanSubsectorSites select c).Where(c => c.SamplingPlanSubsectorSiteID > 2 && c.SamplingPlanSubsectorSiteID < 5).ToList();

                        List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                        samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList);
                        Assert.Equal(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorSiteList() 2 Where

        #region Functions private
        private void CheckSamplingPlanSubsectorSiteFields(List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList)
        {
            Assert.NotNull(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
            Assert.NotNull(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorID);
            Assert.NotNull(samplingPlanSubsectorSiteList[0].MWQMSiteTVItemID);
            Assert.NotNull(samplingPlanSubsectorSiteList[0].IsDuplicate);
            Assert.NotNull(samplingPlanSubsectorSiteList[0].LastUpdateDate_UTC);
            Assert.NotNull(samplingPlanSubsectorSiteList[0].LastUpdateContactTVItemID);
            Assert.NotNull(samplingPlanSubsectorSiteList[0].HasErrors);
        }
        private SamplingPlanSubsectorSite GetFilledRandomSamplingPlanSubsectorSite(string OmitPropName)
        {
            SamplingPlanSubsectorSite samplingPlanSubsectorSite = new SamplingPlanSubsectorSite();

            if (OmitPropName != "SamplingPlanSubsectorID") samplingPlanSubsectorSite.SamplingPlanSubsectorID = 1;
            if (OmitPropName != "MWQMSiteTVItemID") samplingPlanSubsectorSite.MWQMSiteTVItemID = 44;
            if (OmitPropName != "IsDuplicate") samplingPlanSubsectorSite.IsDuplicate = true;
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlanSubsectorSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlanSubsectorSite.LastUpdateContactTVItemID = 2;

            return samplingPlanSubsectorSite;
        }
        #endregion Functions private
    }
}
