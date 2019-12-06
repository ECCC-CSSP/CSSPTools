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
    public partial class VPScenarioLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private VPScenarioLanguageService vpScenarioLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public VPScenarioLanguageServiceTest() : base()
        {
            //vpScenarioLanguageService = new VPScenarioLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD
        [TestMethod]
        public void VPScenarioLanguage_CRUD_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    VPScenarioLanguage vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = vpScenarioLanguageService.GetVPScenarioLanguageList().Count();

                    Assert.AreEqual(count, (from c in dbTestDB.VPScenarioLanguages select c).Count());

                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    if (vpScenarioLanguage.HasErrors)
                    {
                        Assert.AreEqual("", vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, vpScenarioLanguageService.GetVPScenarioLanguageList().Where(c => c == vpScenarioLanguage).Any());
                    vpScenarioLanguageService.Update(vpScenarioLanguage);
                    if (vpScenarioLanguage.HasErrors)
                    {
                        Assert.AreEqual("", vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, vpScenarioLanguageService.GetVPScenarioLanguageList().Count());
                    vpScenarioLanguageService.Delete(vpScenarioLanguage);
                    if (vpScenarioLanguage.HasErrors)
                    {
                        Assert.AreEqual("", vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, vpScenarioLanguageService.GetVPScenarioLanguageList().Count());

                }
            }
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [TestMethod]
        public void VPScenarioLanguage_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    count = vpScenarioLanguageService.GetVPScenarioLanguageList().Count();

                    VPScenarioLanguage vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // vpScenarioLanguage.VPScenarioLanguageID   (Int32)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioLanguageID = 0;
                    vpScenarioLanguageService.Update(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "VPScenarioLanguageID"), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioLanguageID = 10000000;
                    vpScenarioLanguageService.Update(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "VPScenarioLanguage", "VPScenarioLanguageID", vpScenarioLanguage.VPScenarioLanguageID.ToString()), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID", AllowableTVtypeList = )]
                    // vpScenarioLanguage.VPScenarioID   (Int32)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioID = 0;
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "VPScenario", "VPScenarioID", vpScenarioLanguage.VPScenarioID.ToString()), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // vpScenarioLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.Language = (LanguageEnum)1000000;
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "Language"), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // vpScenarioLanguage.VPScenarioName   (String)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("VPScenarioName");
                    Assert.AreEqual(false, vpScenarioLanguageService.Add(vpScenarioLanguage));
                    Assert.AreEqual(1, vpScenarioLanguage.ValidationResults.Count());
                    Assert.IsTrue(vpScenarioLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "VPScenarioName")).Any());
                    Assert.AreEqual(null, vpScenarioLanguage.VPScenarioName);
                    Assert.AreEqual(count, vpScenarioLanguageService.GetVPScenarioLanguageList().Count());

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioName = GetRandomString("", 101);
                    Assert.AreEqual(false, vpScenarioLanguageService.Add(vpScenarioLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "VPScenarioName", "100"), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioLanguageService.GetVPScenarioLanguageList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // vpScenarioLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TranslationStatus"), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // vpScenarioLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.LastUpdateDate_UTC = new DateTime();
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // vpScenarioLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.LastUpdateContactTVItemID = 0;
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", vpScenarioLanguage.LastUpdateContactTVItemID.ToString()), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.LastUpdateContactTVItemID = 1;
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // vpScenarioLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // vpScenarioLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated Properties

        #region Tests Generated for GetVPScenarioLanguageWithVPScenarioLanguageID(vpScenarioLanguage.VPScenarioLanguageID)
        [TestMethod]
        public void GetVPScenarioLanguageWithVPScenarioLanguageID__vpScenarioLanguage_VPScenarioLanguageID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    VPScenarioLanguage vpScenarioLanguage = (from c in dbTestDB.VPScenarioLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(vpScenarioLanguage);

                }
            }
        }
        #endregion Tests Generated for GetVPScenarioLanguageWithVPScenarioLanguageID(vpScenarioLanguage.VPScenarioLanguageID)

        #region Tests Generated for GetVPScenarioLanguageList()
        [TestMethod]
        public void GetVPScenarioLanguageList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    VPScenarioLanguage vpScenarioLanguage = (from c in dbTestDB.VPScenarioLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(vpScenarioLanguage);

                    List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                    vpScenarioLanguageDirectQueryList = (from c in dbTestDB.VPScenarioLanguages select c).Take(200).ToList();

                }
            }
        }
        #endregion Tests Generated for GetVPScenarioLanguageList()

        #region Tests Generated for GetVPScenarioLanguageList() Skip Take
        [TestMethod]
        public void GetVPScenarioLanguageList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "");

                    List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                    vpScenarioLanguageDirectQueryList = (from c in dbTestDB.VPScenarioLanguages select c).Skip(1).Take(1).ToList();

                        List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                        vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        CheckVPScenarioLanguageFields(vpScenarioLanguageList);
                        Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageList[0].VPScenarioLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioLanguageList() Skip Take

        #region Tests Generated for GetVPScenarioLanguageList() Skip Take Asc
        [TestMethod]
        public void GetVPScenarioLanguageList_Skip_Take_Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "VPScenarioLanguageID", "", "");

                    List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                    vpScenarioLanguageDirectQueryList = (from c in dbTestDB.VPScenarioLanguages select c).OrderBy(c => c.VPScenarioLanguageID).Skip(1).Take(1).ToList();

                        List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                        vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        CheckVPScenarioLanguageFields(vpScenarioLanguageList);
                        Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageList[0].VPScenarioLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioLanguageList() Skip Take Asc

        #region Tests Generated for GetVPScenarioLanguageList() Skip Take 2 Asc
        [TestMethod]
        public void GetVPScenarioLanguageList_Skip_Take_2Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), culture.TwoLetterISOLanguageName, 1, 1, "VPScenarioLanguageID,VPScenarioID", "", "");

                    List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                    vpScenarioLanguageDirectQueryList = (from c in dbTestDB.VPScenarioLanguages select c).OrderBy(c => c.VPScenarioLanguageID).ThenBy(c => c.VPScenarioID).Skip(1).Take(1).ToList();

                        List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                        vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        CheckVPScenarioLanguageFields(vpScenarioLanguageList);
                        Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageList[0].VPScenarioLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioLanguageList() Skip Take 2 Asc

        #region Tests Generated for GetVPScenarioLanguageList() Skip Take Asc Where
        [TestMethod]
        public void GetVPScenarioLanguageList_Skip_Take_Asc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), culture.TwoLetterISOLanguageName, 0, 1, "VPScenarioLanguageID", "", "VPScenarioLanguageID,EQ,4");

                    List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                    vpScenarioLanguageDirectQueryList = (from c in dbTestDB.VPScenarioLanguages select c).Where(c => c.VPScenarioLanguageID == 4).OrderBy(c => c.VPScenarioLanguageID).Skip(0).Take(1).ToList();

                        List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                        vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        CheckVPScenarioLanguageFields(vpScenarioLanguageList);
                        Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageList[0].VPScenarioLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioLanguageList() Skip Take Asc Where

        #region Tests Generated for GetVPScenarioLanguageList() Skip Take Asc 2 Where
        [TestMethod]
        public void GetVPScenarioLanguageList_Skip_Take_Asc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                     VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                     vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), culture.TwoLetterISOLanguageName, 0, 1, "VPScenarioLanguageID", "", "VPScenarioLanguageID,GT,2|VPScenarioLanguageID,LT,5");

                     List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                     vpScenarioLanguageDirectQueryList = (from c in dbTestDB.VPScenarioLanguages select c).Where(c => c.VPScenarioLanguageID > 2 && c.VPScenarioLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.VPScenarioLanguageID).ToList();

                        List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                        vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        CheckVPScenarioLanguageFields(vpScenarioLanguageList);
                        Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageList[0].VPScenarioLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioLanguageList() Skip Take Asc 2 Where

        #region Tests Generated for GetVPScenarioLanguageList() Skip Take Desc
        [TestMethod]
        public void GetVPScenarioLanguageList_Skip_Take_Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "VPScenarioLanguageID", "");

                    List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                    vpScenarioLanguageDirectQueryList = (from c in dbTestDB.VPScenarioLanguages select c).OrderByDescending(c => c.VPScenarioLanguageID).Skip(1).Take(1).ToList();

                        List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                        vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        CheckVPScenarioLanguageFields(vpScenarioLanguageList);
                        Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageList[0].VPScenarioLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioLanguageList() Skip Take Desc

        #region Tests Generated for GetVPScenarioLanguageList() Skip Take 2 Desc
        [TestMethod]
        public void GetVPScenarioLanguageList_Skip_Take_2Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "VPScenarioLanguageID,VPScenarioID", "");

                    List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                    vpScenarioLanguageDirectQueryList = (from c in dbTestDB.VPScenarioLanguages select c).OrderByDescending(c => c.VPScenarioLanguageID).ThenByDescending(c => c.VPScenarioID).Skip(1).Take(1).ToList();

                        List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                        vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        CheckVPScenarioLanguageFields(vpScenarioLanguageList);
                        Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageList[0].VPScenarioLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioLanguageList() Skip Take 2 Desc

        #region Tests Generated for GetVPScenarioLanguageList() Skip Take Desc Where
        [TestMethod]
        public void GetVPScenarioLanguageList_Skip_Take_Desc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), culture.TwoLetterISOLanguageName, 0, 1, "VPScenarioLanguageID", "", "VPScenarioLanguageID,EQ,4");

                    List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                    vpScenarioLanguageDirectQueryList = (from c in dbTestDB.VPScenarioLanguages select c).Where(c => c.VPScenarioLanguageID == 4).OrderByDescending(c => c.VPScenarioLanguageID).Skip(0).Take(1).ToList();

                        List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                        vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        CheckVPScenarioLanguageFields(vpScenarioLanguageList);
                        Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageList[0].VPScenarioLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioLanguageList() Skip Take Desc Where

        #region Tests Generated for GetVPScenarioLanguageList() Skip Take Desc 2 Where
        [TestMethod]
        public void GetVPScenarioLanguageList_Skip_Take_Desc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), culture.TwoLetterISOLanguageName, 0, 1, "", "VPScenarioLanguageID", "VPScenarioLanguageID,GT,2|VPScenarioLanguageID,LT,5");

                    List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                    vpScenarioLanguageDirectQueryList = (from c in dbTestDB.VPScenarioLanguages select c).Where(c => c.VPScenarioLanguageID > 2 && c.VPScenarioLanguageID < 5).OrderByDescending(c => c.VPScenarioLanguageID).Skip(0).Take(1).ToList();

                        List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                        vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        CheckVPScenarioLanguageFields(vpScenarioLanguageList);
                        Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageList[0].VPScenarioLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioLanguageList() Skip Take Desc 2 Where

        #region Tests Generated for GetVPScenarioLanguageList() 2 Where
        [TestMethod]
        public void GetVPScenarioLanguageList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "", "VPScenarioLanguageID,GT,2|VPScenarioLanguageID,LT,5");

                    List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                    vpScenarioLanguageDirectQueryList = (from c in dbTestDB.VPScenarioLanguages select c).Where(c => c.VPScenarioLanguageID > 2 && c.VPScenarioLanguageID < 5).ToList();

                        List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                        vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        CheckVPScenarioLanguageFields(vpScenarioLanguageList);
                        Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageList[0].VPScenarioLanguageID);
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioLanguageList() 2 Where

        #region Functions private
        private void CheckVPScenarioLanguageFields(List<VPScenarioLanguage> vpScenarioLanguageList)
        {
            Assert.IsNotNull(vpScenarioLanguageList[0].VPScenarioLanguageID);
            Assert.IsNotNull(vpScenarioLanguageList[0].VPScenarioID);
            Assert.IsNotNull(vpScenarioLanguageList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageList[0].VPScenarioName));
            Assert.IsNotNull(vpScenarioLanguageList[0].TranslationStatus);
            Assert.IsNotNull(vpScenarioLanguageList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(vpScenarioLanguageList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(vpScenarioLanguageList[0].HasErrors);
        }
        private VPScenarioLanguage GetFilledRandomVPScenarioLanguage(string OmitPropName)
        {
            VPScenarioLanguage vpScenarioLanguage = new VPScenarioLanguage();

            if (OmitPropName != "VPScenarioID") vpScenarioLanguage.VPScenarioID = 1;
            if (OmitPropName != "Language") vpScenarioLanguage.Language = LanguageRequest;
            if (OmitPropName != "VPScenarioName") vpScenarioLanguage.VPScenarioName = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") vpScenarioLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") vpScenarioLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") vpScenarioLanguage.LastUpdateContactTVItemID = 2;

            return vpScenarioLanguage;
        }
        #endregion Functions private
    }
}
