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
    public partial class PolSourceObservationServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private PolSourceObservationService polSourceObservationService { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationServiceTest() : base()
        {
            //polSourceObservationService = new PolSourceObservationService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD
        [TestMethod]
        public void PolSourceObservation_CRUD_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    PolSourceObservation polSourceObservation = GetFilledRandomPolSourceObservation("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = polSourceObservationService.GetPolSourceObservationList().Count();

                    Assert.AreEqual(count, (from c in dbTestDB.PolSourceObservations select c).Count());

                    polSourceObservationService.Add(polSourceObservation);
                    if (polSourceObservation.HasErrors)
                    {
                        Assert.AreEqual("", polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, polSourceObservationService.GetPolSourceObservationList().Where(c => c == polSourceObservation).Any());
                    polSourceObservationService.Update(polSourceObservation);
                    if (polSourceObservation.HasErrors)
                    {
                        Assert.AreEqual("", polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, polSourceObservationService.GetPolSourceObservationList().Count());
                    polSourceObservationService.Delete(polSourceObservation);
                    if (polSourceObservation.HasErrors)
                    {
                        Assert.AreEqual("", polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, polSourceObservationService.GetPolSourceObservationList().Count());

                }
            }
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [TestMethod]
        public void PolSourceObservation_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    count = polSourceObservationService.GetPolSourceObservationList().Count();

                    PolSourceObservation polSourceObservation = GetFilledRandomPolSourceObservation("");

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // polSourceObservation.PolSourceObservationID   (Int32)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.PolSourceObservationID = 0;
                    polSourceObservationService.Update(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "PolSourceObservationID"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.PolSourceObservationID = 10000000;
                    polSourceObservationService.Update(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceObservation", "PolSourceObservationID", polSourceObservation.PolSourceObservationID.ToString()), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "PolSourceSite", ExistPlurial = "s", ExistFieldID = "PolSourceSiteID", AllowableTVtypeList = )]
                    // polSourceObservation.PolSourceSiteID   (Int32)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.PolSourceSiteID = 0;
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceSite", "PolSourceSiteID", polSourceObservation.PolSourceSiteID.ToString()), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // polSourceObservation.ObservationDate_Local   (DateTime)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.ObservationDate_Local = new DateTime();
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ObservationDate_Local"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.ObservationDate_Local = new DateTime(1979, 1, 1);
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "ObservationDate_Local", "1980"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // polSourceObservation.ContactTVItemID   (Int32)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.ContactTVItemID = 0;
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ContactTVItemID", polSourceObservation.ContactTVItemID.ToString()), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.ContactTVItemID = 1;
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "ContactTVItemID", "Contact"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // polSourceObservation.DesktopReviewed   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // polSourceObservation.Observation_ToBeDeleted   (String)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("Observation_ToBeDeleted");
                    Assert.AreEqual(false, polSourceObservationService.Add(polSourceObservation));
                    Assert.AreEqual(1, polSourceObservation.ValidationResults.Count());
                    Assert.IsTrue(polSourceObservation.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "Observation_ToBeDeleted")).Any());
                    Assert.AreEqual(null, polSourceObservation.Observation_ToBeDeleted);
                    Assert.AreEqual(count, polSourceObservationService.GetPolSourceObservationList().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // polSourceObservation.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.LastUpdateDate_UTC = new DateTime();
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // polSourceObservation.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.LastUpdateContactTVItemID = 0;
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", polSourceObservation.LastUpdateContactTVItemID.ToString()), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.LastUpdateContactTVItemID = 1;
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // polSourceObservation.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // polSourceObservation.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated Properties

        #region Tests Generated for GetPolSourceObservationWithPolSourceObservationID(polSourceObservation.PolSourceObservationID)
        [TestMethod]
        public void GetPolSourceObservationWithPolSourceObservationID__polSourceObservation_PolSourceObservationID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    PolSourceObservation polSourceObservation = (from c in dbTestDB.PolSourceObservations select c).FirstOrDefault();
                    Assert.IsNotNull(polSourceObservation);

                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationWithPolSourceObservationID(polSourceObservation.PolSourceObservationID)

        #region Tests Generated for GetPolSourceObservationList()
        [TestMethod]
        public void GetPolSourceObservationList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    PolSourceObservation polSourceObservation = (from c in dbTestDB.PolSourceObservations select c).FirstOrDefault();
                    Assert.IsNotNull(polSourceObservation);

                    List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                    polSourceObservationDirectQueryList = (from c in dbTestDB.PolSourceObservations select c).Take(200).ToList();

                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationList()

        #region Tests Generated for GetPolSourceObservationList() Skip Take
        [TestMethod]
        public void GetPolSourceObservationList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 1, 1, "", "");

                    List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                    polSourceObservationDirectQueryList = (from c in dbTestDB.PolSourceObservations select c).Skip(1).Take(1).ToList();

                        List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                        polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        CheckPolSourceObservationFields(polSourceObservationList);
                        Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationList() Skip Take

        #region Tests Generated for GetPolSourceObservationList() Skip Take Asc
        [TestMethod]
        public void GetPolSourceObservationList_Skip_Take_Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 1, 1,  "PolSourceObservationID", "", "");

                    List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                    polSourceObservationDirectQueryList = (from c in dbTestDB.PolSourceObservations select c).OrderBy(c => c.PolSourceObservationID).Skip(1).Take(1).ToList();

                        List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                        polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        CheckPolSourceObservationFields(polSourceObservationList);
                        Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationList() Skip Take Asc

        #region Tests Generated for GetPolSourceObservationList() Skip Take 2 Asc
        [TestMethod]
        public void GetPolSourceObservationList_Skip_Take_2Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 1, 1, "PolSourceObservationID,PolSourceSiteID", "", "");

                    List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                    polSourceObservationDirectQueryList = (from c in dbTestDB.PolSourceObservations select c).OrderBy(c => c.PolSourceObservationID).ThenBy(c => c.PolSourceSiteID).Skip(1).Take(1).ToList();

                        List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                        polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        CheckPolSourceObservationFields(polSourceObservationList);
                        Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationList() Skip Take 2 Asc

        #region Tests Generated for GetPolSourceObservationList() Skip Take Asc Where
        [TestMethod]
        public void GetPolSourceObservationList_Skip_Take_Asc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceObservationID", "", "PolSourceObservationID,EQ,4");

                    List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                    polSourceObservationDirectQueryList = (from c in dbTestDB.PolSourceObservations select c).Where(c => c.PolSourceObservationID == 4).OrderBy(c => c.PolSourceObservationID).Skip(0).Take(1).ToList();

                        List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                        polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        CheckPolSourceObservationFields(polSourceObservationList);
                        Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationList() Skip Take Asc Where

        #region Tests Generated for GetPolSourceObservationList() Skip Take Asc 2 Where
        [TestMethod]
        public void GetPolSourceObservationList_Skip_Take_Asc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                     PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                     polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceObservationID", "", "PolSourceObservationID,GT,2|PolSourceObservationID,LT,5");

                     List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                     polSourceObservationDirectQueryList = (from c in dbTestDB.PolSourceObservations select c).Where(c => c.PolSourceObservationID > 2 && c.PolSourceObservationID < 5).Skip(0).Take(1).OrderBy(c => c.PolSourceObservationID).ToList();

                        List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                        polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        CheckPolSourceObservationFields(polSourceObservationList);
                        Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationList() Skip Take Asc 2 Where

        #region Tests Generated for GetPolSourceObservationList() Skip Take Desc
        [TestMethod]
        public void GetPolSourceObservationList_Skip_Take_Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 1, 1, "", "PolSourceObservationID", "");

                    List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                    polSourceObservationDirectQueryList = (from c in dbTestDB.PolSourceObservations select c).OrderByDescending(c => c.PolSourceObservationID).Skip(1).Take(1).ToList();

                        List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                        polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        CheckPolSourceObservationFields(polSourceObservationList);
                        Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationList() Skip Take Desc

        #region Tests Generated for GetPolSourceObservationList() Skip Take 2 Desc
        [TestMethod]
        public void GetPolSourceObservationList_Skip_Take_2Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 1, 1, "", "PolSourceObservationID,PolSourceSiteID", "");

                    List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                    polSourceObservationDirectQueryList = (from c in dbTestDB.PolSourceObservations select c).OrderByDescending(c => c.PolSourceObservationID).ThenByDescending(c => c.PolSourceSiteID).Skip(1).Take(1).ToList();

                        List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                        polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        CheckPolSourceObservationFields(polSourceObservationList);
                        Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationList() Skip Take 2 Desc

        #region Tests Generated for GetPolSourceObservationList() Skip Take Desc Where
        [TestMethod]
        public void GetPolSourceObservationList_Skip_Take_Desc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceObservationID", "", "PolSourceObservationID,EQ,4");

                    List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                    polSourceObservationDirectQueryList = (from c in dbTestDB.PolSourceObservations select c).Where(c => c.PolSourceObservationID == 4).OrderByDescending(c => c.PolSourceObservationID).Skip(0).Take(1).ToList();

                        List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                        polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        CheckPolSourceObservationFields(polSourceObservationList);
                        Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationList() Skip Take Desc Where

        #region Tests Generated for GetPolSourceObservationList() Skip Take Desc 2 Where
        [TestMethod]
        public void GetPolSourceObservationList_Skip_Take_Desc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 0, 1, "", "PolSourceObservationID", "PolSourceObservationID,GT,2|PolSourceObservationID,LT,5");

                    List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                    polSourceObservationDirectQueryList = (from c in dbTestDB.PolSourceObservations select c).Where(c => c.PolSourceObservationID > 2 && c.PolSourceObservationID < 5).OrderByDescending(c => c.PolSourceObservationID).Skip(0).Take(1).ToList();

                        List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                        polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        CheckPolSourceObservationFields(polSourceObservationList);
                        Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationList() Skip Take Desc 2 Where

        #region Tests Generated for GetPolSourceObservationList() 2 Where
        [TestMethod]
        public void GetPolSourceObservationList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 0, 10000, "", "", "PolSourceObservationID,GT,2|PolSourceObservationID,LT,5");

                    List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                    polSourceObservationDirectQueryList = (from c in dbTestDB.PolSourceObservations select c).Where(c => c.PolSourceObservationID > 2 && c.PolSourceObservationID < 5).ToList();

                        List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                        polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        CheckPolSourceObservationFields(polSourceObservationList);
                        Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationList() 2 Where

        #region Functions private
        private void CheckPolSourceObservationFields(List<PolSourceObservation> polSourceObservationList)
        {
            Assert.IsNotNull(polSourceObservationList[0].PolSourceObservationID);
            Assert.IsNotNull(polSourceObservationList[0].PolSourceSiteID);
            Assert.IsNotNull(polSourceObservationList[0].ObservationDate_Local);
            Assert.IsNotNull(polSourceObservationList[0].ContactTVItemID);
            Assert.IsNotNull(polSourceObservationList[0].DesktopReviewed);
            Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationList[0].Observation_ToBeDeleted));
            Assert.IsNotNull(polSourceObservationList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(polSourceObservationList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(polSourceObservationList[0].HasErrors);
        }
        private PolSourceObservation GetFilledRandomPolSourceObservation(string OmitPropName)
        {
            PolSourceObservation polSourceObservation = new PolSourceObservation();

            if (OmitPropName != "PolSourceSiteID") polSourceObservation.PolSourceSiteID = 1;
            if (OmitPropName != "ObservationDate_Local") polSourceObservation.ObservationDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "ContactTVItemID") polSourceObservation.ContactTVItemID = 2;
            if (OmitPropName != "DesktopReviewed") polSourceObservation.DesktopReviewed = true;
            if (OmitPropName != "Observation_ToBeDeleted") polSourceObservation.Observation_ToBeDeleted = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") polSourceObservation.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceObservation.LastUpdateContactTVItemID = 2;

            return polSourceObservation;
        }
        #endregion Functions private
    }
}
