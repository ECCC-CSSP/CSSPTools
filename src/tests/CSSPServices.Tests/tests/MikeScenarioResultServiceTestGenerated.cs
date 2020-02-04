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
    public partial class MikeScenarioResultServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MikeScenarioResultService mikeScenarioResultService { get; set; }
        #endregion Properties

        #region Constructors
        public MikeScenarioResultServiceTest() : base()
        {
            //mikeScenarioResultService = new MikeScenarioResultService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Fact]
        public void MikeScenarioResult_CRUD_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MikeScenarioResult mikeScenarioResult = GetFilledRandomMikeScenarioResult("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = mikeScenarioResultService.GetMikeScenarioResultList().Count();

                    Assert.Equal(count, (from c in dbTestDB.MikeScenarioResults select c).Count());

                    mikeScenarioResultService.Add(mikeScenarioResult);
                    if (mikeScenarioResult.HasErrors)
                    {
                        Assert.Equal("", mikeScenarioResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.True(mikeScenarioResultService.GetMikeScenarioResultList().Where(c => c == mikeScenarioResult).Any());
                    mikeScenarioResultService.Update(mikeScenarioResult);
                    if (mikeScenarioResult.HasErrors)
                    {
                        Assert.Equal("", mikeScenarioResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.Equal(count + 1, mikeScenarioResultService.GetMikeScenarioResultList().Count());
                    mikeScenarioResultService.Delete(mikeScenarioResult);
                    if (mikeScenarioResult.HasErrors)
                    {
                        Assert.Equal("", mikeScenarioResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.Equal(count, mikeScenarioResultService.GetMikeScenarioResultList().Count());

                }
            }
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Fact]
        public void MikeScenarioResult_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    count = mikeScenarioResultService.GetMikeScenarioResultList().Count();

                    MikeScenarioResult mikeScenarioResult = GetFilledRandomMikeScenarioResult("");

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mikeScenarioResult.MikeScenarioResultID   (Int32)
                    // -----------------------------------

                    mikeScenarioResult = null;
                    mikeScenarioResult = GetFilledRandomMikeScenarioResult("");
                    mikeScenarioResult.MikeScenarioResultID = 0;
                    mikeScenarioResultService.Update(mikeScenarioResult);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "MikeScenarioResultID"), mikeScenarioResult.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeScenarioResult = null;
                    mikeScenarioResult = GetFilledRandomMikeScenarioResult("");
                    mikeScenarioResult.MikeScenarioResultID = 10000000;
                    mikeScenarioResultService.Update(mikeScenarioResult);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MikeScenarioResult", "MikeScenarioResultID", mikeScenarioResult.MikeScenarioResultID.ToString()), mikeScenarioResult.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MikeScenario)]
                    // mikeScenarioResult.MikeScenarioTVItemID   (Int32)
                    // -----------------------------------

                    mikeScenarioResult = null;
                    mikeScenarioResult = GetFilledRandomMikeScenarioResult("");
                    mikeScenarioResult.MikeScenarioTVItemID = 0;
                    mikeScenarioResultService.Add(mikeScenarioResult);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeScenarioTVItemID", mikeScenarioResult.MikeScenarioTVItemID.ToString()), mikeScenarioResult.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeScenarioResult = null;
                    mikeScenarioResult = GetFilledRandomMikeScenarioResult("");
                    mikeScenarioResult.MikeScenarioTVItemID = 1;
                    mikeScenarioResultService.Add(mikeScenarioResult);
                    Assert.Equal(string.Format(CSSPServicesRes._IsNotOfType_, "MikeScenarioTVItemID", "MikeScenario"), mikeScenarioResult.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // mikeScenarioResult.MikeResultsJSON   (String)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mikeScenarioResult.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mikeScenarioResult = null;
                    mikeScenarioResult = GetFilledRandomMikeScenarioResult("");
                    mikeScenarioResult.LastUpdateDate_UTC = new DateTime();
                    mikeScenarioResultService.Add(mikeScenarioResult);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), mikeScenarioResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    mikeScenarioResult = null;
                    mikeScenarioResult = GetFilledRandomMikeScenarioResult("");
                    mikeScenarioResult.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mikeScenarioResultService.Add(mikeScenarioResult);
                    Assert.Equal(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), mikeScenarioResult.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mikeScenarioResult.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mikeScenarioResult = null;
                    mikeScenarioResult = GetFilledRandomMikeScenarioResult("");
                    mikeScenarioResult.LastUpdateContactTVItemID = 0;
                    mikeScenarioResultService.Add(mikeScenarioResult);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mikeScenarioResult.LastUpdateContactTVItemID.ToString()), mikeScenarioResult.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeScenarioResult = null;
                    mikeScenarioResult = GetFilledRandomMikeScenarioResult("");
                    mikeScenarioResult.LastUpdateContactTVItemID = 1;
                    mikeScenarioResultService.Add(mikeScenarioResult);
                    Assert.Equal(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), mikeScenarioResult.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mikeScenarioResult.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mikeScenarioResult.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated Properties

        #region Tests Generated for GetMikeScenarioResultWithMikeScenarioResultID(mikeScenarioResult.MikeScenarioResultID)
        [Fact]
        public void GetMikeScenarioResultWithMikeScenarioResultID__mikeScenarioResult_MikeScenarioResultID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MikeScenarioResult mikeScenarioResult = (from c in dbTestDB.MikeScenarioResults select c).FirstOrDefault();
                    Assert.NotNull(mikeScenarioResult);

                }
            }
        }
        #endregion Tests Generated for GetMikeScenarioResultWithMikeScenarioResultID(mikeScenarioResult.MikeScenarioResultID)

        #region Tests Generated for GetMikeScenarioResultList()
        [Fact]
        public void GetMikeScenarioResultList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MikeScenarioResult mikeScenarioResult = (from c in dbTestDB.MikeScenarioResults select c).FirstOrDefault();
                    Assert.NotNull(mikeScenarioResult);

                    List<MikeScenarioResult> mikeScenarioResultDirectQueryList = new List<MikeScenarioResult>();
                    mikeScenarioResultDirectQueryList = (from c in dbTestDB.MikeScenarioResults select c).Take(200).ToList();

                }
            }
        }
        #endregion Tests Generated for GetMikeScenarioResultList()

        #region Tests Generated for GetMikeScenarioResultList() Skip Take
        [Fact]
        public void GetMikeScenarioResultList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    mikeScenarioResultService.Query = mikeScenarioResultService.FillQuery(typeof(MikeScenarioResult), culture.TwoLetterISOLanguageName, 1, 1, "", "");

                    List<MikeScenarioResult> mikeScenarioResultDirectQueryList = new List<MikeScenarioResult>();
                    mikeScenarioResultDirectQueryList = (from c in dbTestDB.MikeScenarioResults select c).Skip(1).Take(1).ToList();

                        List<MikeScenarioResult> mikeScenarioResultList = new List<MikeScenarioResult>();
                        mikeScenarioResultList = mikeScenarioResultService.GetMikeScenarioResultList().ToList();
                        CheckMikeScenarioResultFields(mikeScenarioResultList);
                        Assert.Equal(mikeScenarioResultDirectQueryList[0].MikeScenarioResultID, mikeScenarioResultList[0].MikeScenarioResultID);
                }
            }
        }
        #endregion Tests Generated for GetMikeScenarioResultList() Skip Take

        #region Tests Generated for GetMikeScenarioResultList() Skip Take Asc
        [Fact]
        public void GetMikeScenarioResultList_Skip_Take_Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    mikeScenarioResultService.Query = mikeScenarioResultService.FillQuery(typeof(MikeScenarioResult), culture.TwoLetterISOLanguageName, 1, 1,  "MikeScenarioResultID", "", "");

                    List<MikeScenarioResult> mikeScenarioResultDirectQueryList = new List<MikeScenarioResult>();
                    mikeScenarioResultDirectQueryList = (from c in dbTestDB.MikeScenarioResults select c).OrderBy(c => c.MikeScenarioResultID).Skip(1).Take(1).ToList();

                        List<MikeScenarioResult> mikeScenarioResultList = new List<MikeScenarioResult>();
                        mikeScenarioResultList = mikeScenarioResultService.GetMikeScenarioResultList().ToList();
                        CheckMikeScenarioResultFields(mikeScenarioResultList);
                        Assert.Equal(mikeScenarioResultDirectQueryList[0].MikeScenarioResultID, mikeScenarioResultList[0].MikeScenarioResultID);
                }
            }
        }
        #endregion Tests Generated for GetMikeScenarioResultList() Skip Take Asc

        #region Tests Generated for GetMikeScenarioResultList() Skip Take 2 Asc
        [Fact]
        public void GetMikeScenarioResultList_Skip_Take_2Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    mikeScenarioResultService.Query = mikeScenarioResultService.FillQuery(typeof(MikeScenarioResult), culture.TwoLetterISOLanguageName, 1, 1, "MikeScenarioResultID,MikeScenarioTVItemID", "", "");

                    List<MikeScenarioResult> mikeScenarioResultDirectQueryList = new List<MikeScenarioResult>();
                    mikeScenarioResultDirectQueryList = (from c in dbTestDB.MikeScenarioResults select c).OrderBy(c => c.MikeScenarioResultID).ThenBy(c => c.MikeScenarioTVItemID).Skip(1).Take(1).ToList();

                        List<MikeScenarioResult> mikeScenarioResultList = new List<MikeScenarioResult>();
                        mikeScenarioResultList = mikeScenarioResultService.GetMikeScenarioResultList().ToList();
                        CheckMikeScenarioResultFields(mikeScenarioResultList);
                        Assert.Equal(mikeScenarioResultDirectQueryList[0].MikeScenarioResultID, mikeScenarioResultList[0].MikeScenarioResultID);
                }
            }
        }
        #endregion Tests Generated for GetMikeScenarioResultList() Skip Take 2 Asc

        #region Tests Generated for GetMikeScenarioResultList() Skip Take Asc Where
        [Fact]
        public void GetMikeScenarioResultList_Skip_Take_Asc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    mikeScenarioResultService.Query = mikeScenarioResultService.FillQuery(typeof(MikeScenarioResult), culture.TwoLetterISOLanguageName, 0, 1, "MikeScenarioResultID", "", "MikeScenarioResultID,EQ,4");

                    List<MikeScenarioResult> mikeScenarioResultDirectQueryList = new List<MikeScenarioResult>();
                    mikeScenarioResultDirectQueryList = (from c in dbTestDB.MikeScenarioResults select c).Where(c => c.MikeScenarioResultID == 4).OrderBy(c => c.MikeScenarioResultID).Skip(0).Take(1).ToList();

                        List<MikeScenarioResult> mikeScenarioResultList = new List<MikeScenarioResult>();
                        mikeScenarioResultList = mikeScenarioResultService.GetMikeScenarioResultList().ToList();
                        CheckMikeScenarioResultFields(mikeScenarioResultList);
                        Assert.Equal(mikeScenarioResultDirectQueryList[0].MikeScenarioResultID, mikeScenarioResultList[0].MikeScenarioResultID);
                }
            }
        }
        #endregion Tests Generated for GetMikeScenarioResultList() Skip Take Asc Where

        #region Tests Generated for GetMikeScenarioResultList() Skip Take Asc 2 Where
        [Fact]
        public void GetMikeScenarioResultList_Skip_Take_Asc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                     MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                     mikeScenarioResultService.Query = mikeScenarioResultService.FillQuery(typeof(MikeScenarioResult), culture.TwoLetterISOLanguageName, 0, 1, "MikeScenarioResultID", "", "MikeScenarioResultID,GT,2|MikeScenarioResultID,LT,5");

                     List<MikeScenarioResult> mikeScenarioResultDirectQueryList = new List<MikeScenarioResult>();
                     mikeScenarioResultDirectQueryList = (from c in dbTestDB.MikeScenarioResults select c).Where(c => c.MikeScenarioResultID > 2 && c.MikeScenarioResultID < 5).Skip(0).Take(1).OrderBy(c => c.MikeScenarioResultID).ToList();

                        List<MikeScenarioResult> mikeScenarioResultList = new List<MikeScenarioResult>();
                        mikeScenarioResultList = mikeScenarioResultService.GetMikeScenarioResultList().ToList();
                        CheckMikeScenarioResultFields(mikeScenarioResultList);
                        Assert.Equal(mikeScenarioResultDirectQueryList[0].MikeScenarioResultID, mikeScenarioResultList[0].MikeScenarioResultID);
                }
            }
        }
        #endregion Tests Generated for GetMikeScenarioResultList() Skip Take Asc 2 Where

        #region Tests Generated for GetMikeScenarioResultList() Skip Take Desc
        [Fact]
        public void GetMikeScenarioResultList_Skip_Take_Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    mikeScenarioResultService.Query = mikeScenarioResultService.FillQuery(typeof(MikeScenarioResult), culture.TwoLetterISOLanguageName, 1, 1, "", "MikeScenarioResultID", "");

                    List<MikeScenarioResult> mikeScenarioResultDirectQueryList = new List<MikeScenarioResult>();
                    mikeScenarioResultDirectQueryList = (from c in dbTestDB.MikeScenarioResults select c).OrderByDescending(c => c.MikeScenarioResultID).Skip(1).Take(1).ToList();

                        List<MikeScenarioResult> mikeScenarioResultList = new List<MikeScenarioResult>();
                        mikeScenarioResultList = mikeScenarioResultService.GetMikeScenarioResultList().ToList();
                        CheckMikeScenarioResultFields(mikeScenarioResultList);
                        Assert.Equal(mikeScenarioResultDirectQueryList[0].MikeScenarioResultID, mikeScenarioResultList[0].MikeScenarioResultID);
                }
            }
        }
        #endregion Tests Generated for GetMikeScenarioResultList() Skip Take Desc

        #region Tests Generated for GetMikeScenarioResultList() Skip Take 2 Desc
        [Fact]
        public void GetMikeScenarioResultList_Skip_Take_2Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    mikeScenarioResultService.Query = mikeScenarioResultService.FillQuery(typeof(MikeScenarioResult), culture.TwoLetterISOLanguageName, 1, 1, "", "MikeScenarioResultID,MikeScenarioTVItemID", "");

                    List<MikeScenarioResult> mikeScenarioResultDirectQueryList = new List<MikeScenarioResult>();
                    mikeScenarioResultDirectQueryList = (from c in dbTestDB.MikeScenarioResults select c).OrderByDescending(c => c.MikeScenarioResultID).ThenByDescending(c => c.MikeScenarioTVItemID).Skip(1).Take(1).ToList();

                        List<MikeScenarioResult> mikeScenarioResultList = new List<MikeScenarioResult>();
                        mikeScenarioResultList = mikeScenarioResultService.GetMikeScenarioResultList().ToList();
                        CheckMikeScenarioResultFields(mikeScenarioResultList);
                        Assert.Equal(mikeScenarioResultDirectQueryList[0].MikeScenarioResultID, mikeScenarioResultList[0].MikeScenarioResultID);
                }
            }
        }
        #endregion Tests Generated for GetMikeScenarioResultList() Skip Take 2 Desc

        #region Tests Generated for GetMikeScenarioResultList() Skip Take Desc Where
        [Fact]
        public void GetMikeScenarioResultList_Skip_Take_Desc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    mikeScenarioResultService.Query = mikeScenarioResultService.FillQuery(typeof(MikeScenarioResult), culture.TwoLetterISOLanguageName, 0, 1, "MikeScenarioResultID", "", "MikeScenarioResultID,EQ,4");

                    List<MikeScenarioResult> mikeScenarioResultDirectQueryList = new List<MikeScenarioResult>();
                    mikeScenarioResultDirectQueryList = (from c in dbTestDB.MikeScenarioResults select c).Where(c => c.MikeScenarioResultID == 4).OrderByDescending(c => c.MikeScenarioResultID).Skip(0).Take(1).ToList();

                        List<MikeScenarioResult> mikeScenarioResultList = new List<MikeScenarioResult>();
                        mikeScenarioResultList = mikeScenarioResultService.GetMikeScenarioResultList().ToList();
                        CheckMikeScenarioResultFields(mikeScenarioResultList);
                        Assert.Equal(mikeScenarioResultDirectQueryList[0].MikeScenarioResultID, mikeScenarioResultList[0].MikeScenarioResultID);
                }
            }
        }
        #endregion Tests Generated for GetMikeScenarioResultList() Skip Take Desc Where

        #region Tests Generated for GetMikeScenarioResultList() Skip Take Desc 2 Where
        [Fact]
        public void GetMikeScenarioResultList_Skip_Take_Desc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    mikeScenarioResultService.Query = mikeScenarioResultService.FillQuery(typeof(MikeScenarioResult), culture.TwoLetterISOLanguageName, 0, 1, "", "MikeScenarioResultID", "MikeScenarioResultID,GT,2|MikeScenarioResultID,LT,5");

                    List<MikeScenarioResult> mikeScenarioResultDirectQueryList = new List<MikeScenarioResult>();
                    mikeScenarioResultDirectQueryList = (from c in dbTestDB.MikeScenarioResults select c).Where(c => c.MikeScenarioResultID > 2 && c.MikeScenarioResultID < 5).OrderByDescending(c => c.MikeScenarioResultID).Skip(0).Take(1).ToList();

                        List<MikeScenarioResult> mikeScenarioResultList = new List<MikeScenarioResult>();
                        mikeScenarioResultList = mikeScenarioResultService.GetMikeScenarioResultList().ToList();
                        CheckMikeScenarioResultFields(mikeScenarioResultList);
                        Assert.Equal(mikeScenarioResultDirectQueryList[0].MikeScenarioResultID, mikeScenarioResultList[0].MikeScenarioResultID);
                }
            }
        }
        #endregion Tests Generated for GetMikeScenarioResultList() Skip Take Desc 2 Where

        #region Tests Generated for GetMikeScenarioResultList() 2 Where
        [Fact]
        public void GetMikeScenarioResultList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    mikeScenarioResultService.Query = mikeScenarioResultService.FillQuery(typeof(MikeScenarioResult), culture.TwoLetterISOLanguageName, 0, 10000, "", "", "MikeScenarioResultID,GT,2|MikeScenarioResultID,LT,5");

                    List<MikeScenarioResult> mikeScenarioResultDirectQueryList = new List<MikeScenarioResult>();
                    mikeScenarioResultDirectQueryList = (from c in dbTestDB.MikeScenarioResults select c).Where(c => c.MikeScenarioResultID > 2 && c.MikeScenarioResultID < 5).ToList();

                        List<MikeScenarioResult> mikeScenarioResultList = new List<MikeScenarioResult>();
                        mikeScenarioResultList = mikeScenarioResultService.GetMikeScenarioResultList().ToList();
                        CheckMikeScenarioResultFields(mikeScenarioResultList);
                        Assert.Equal(mikeScenarioResultDirectQueryList[0].MikeScenarioResultID, mikeScenarioResultList[0].MikeScenarioResultID);
                }
            }
        }
        #endregion Tests Generated for GetMikeScenarioResultList() 2 Where

        #region Functions private
        private void CheckMikeScenarioResultFields(List<MikeScenarioResult> mikeScenarioResultList)
        {
            if (!string.IsNullOrWhiteSpace(mikeScenarioResultList[0].MikeResultsJSON))
            {
                Assert.False(string.IsNullOrWhiteSpace(mikeScenarioResultList[0].MikeResultsJSON));
            }
        }
        private MikeScenarioResult GetFilledRandomMikeScenarioResult(string OmitPropName)
        {
            MikeScenarioResult mikeScenarioResult = new MikeScenarioResult();

            if (OmitPropName != "MikeScenarioTVItemID") mikeScenarioResult.MikeScenarioTVItemID = 51;
            if (OmitPropName != "MikeResultsJSON") mikeScenarioResult.MikeResultsJSON = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") mikeScenarioResult.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mikeScenarioResult.LastUpdateContactTVItemID = 2;

            return mikeScenarioResult;
        }
        #endregion Functions private
    }
}
