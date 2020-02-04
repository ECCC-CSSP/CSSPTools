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
    public partial class PolSourceObservationIssueServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private PolSourceObservationIssueService polSourceObservationIssueService { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationIssueServiceTest() : base()
        {
            //polSourceObservationIssueService = new PolSourceObservationIssueService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Fact]
        public void PolSourceObservationIssue_CRUD_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    PolSourceObservationIssue polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = polSourceObservationIssueService.GetPolSourceObservationIssueList().Count();

                    Assert.Equal(count, (from c in dbTestDB.PolSourceObservationIssues select c).Count());

                    polSourceObservationIssueService.Add(polSourceObservationIssue);
                    if (polSourceObservationIssue.HasErrors)
                    {
                        Assert.Equal("", polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.True(polSourceObservationIssueService.GetPolSourceObservationIssueList().Where(c => c == polSourceObservationIssue).Any());
                    polSourceObservationIssueService.Update(polSourceObservationIssue);
                    if (polSourceObservationIssue.HasErrors)
                    {
                        Assert.Equal("", polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.Equal(count + 1, polSourceObservationIssueService.GetPolSourceObservationIssueList().Count());
                    polSourceObservationIssueService.Delete(polSourceObservationIssue);
                    if (polSourceObservationIssue.HasErrors)
                    {
                        Assert.Equal("", polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.Equal(count, polSourceObservationIssueService.GetPolSourceObservationIssueList().Count());

                }
            }
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Fact]
        public void PolSourceObservationIssue_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    count = polSourceObservationIssueService.GetPolSourceObservationIssueList().Count();

                    PolSourceObservationIssue polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // polSourceObservationIssue.PolSourceObservationIssueID   (Int32)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.PolSourceObservationIssueID = 0;
                    polSourceObservationIssueService.Update(polSourceObservationIssue);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "PolSourceObservationIssueID"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.PolSourceObservationIssueID = 10000000;
                    polSourceObservationIssueService.Update(polSourceObservationIssue);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceObservationIssue", "PolSourceObservationIssueID", polSourceObservationIssue.PolSourceObservationIssueID.ToString()), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "PolSourceObservation", ExistPlurial = "s", ExistFieldID = "PolSourceObservationID", AllowableTVtypeList = )]
                    // polSourceObservationIssue.PolSourceObservationID   (Int32)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.PolSourceObservationID = 0;
                    polSourceObservationIssueService.Add(polSourceObservationIssue);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceObservation", "PolSourceObservationID", polSourceObservationIssue.PolSourceObservationID.ToString()), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250))]
                    // polSourceObservationIssue.ObservationInfo   (String)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("ObservationInfo");
                    Assert.False(polSourceObservationIssueService.Add(polSourceObservationIssue));
                    Assert.Equal(1, (int)polSourceObservationIssue.ValidationResults.Count());
                    Assert.True(polSourceObservationIssue.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "ObservationInfo")).Any());
                    Assert.Null(polSourceObservationIssue.ObservationInfo);
                    Assert.Equal(count, (int)polSourceObservationIssueService.GetPolSourceObservationIssueList().Count());

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.ObservationInfo = GetRandomString("", 251);
                    Assert.False(polSourceObservationIssueService.Add(polSourceObservationIssue));
                    Assert.Equal(string.Format(CSSPServicesRes._MaxLengthIs_, "ObservationInfo", "250"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(count, (int)polSourceObservationIssueService.GetPolSourceObservationIssueList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // polSourceObservationIssue.Ordinal   (Int32)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.Ordinal = -1;
                    Assert.False(polSourceObservationIssueService.Add(polSourceObservationIssue));
                    Assert.Equal(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "1000"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(count, (int)polSourceObservationIssueService.GetPolSourceObservationIssueList().Count());
                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.Ordinal = 1001;
                    Assert.False(polSourceObservationIssueService.Add(polSourceObservationIssue));
                    Assert.Equal(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "1000"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(count, (int)polSourceObservationIssueService.GetPolSourceObservationIssueList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // polSourceObservationIssue.ExtraComment   (String)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // polSourceObservationIssue.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.LastUpdateDate_UTC = new DateTime();
                    polSourceObservationIssueService.Add(polSourceObservationIssue);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    polSourceObservationIssueService.Add(polSourceObservationIssue);
                    Assert.Equal(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // polSourceObservationIssue.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.LastUpdateContactTVItemID = 0;
                    polSourceObservationIssueService.Add(polSourceObservationIssue);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", polSourceObservationIssue.LastUpdateContactTVItemID.ToString()), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.LastUpdateContactTVItemID = 1;
                    polSourceObservationIssueService.Add(polSourceObservationIssue);
                    Assert.Equal(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // polSourceObservationIssue.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // polSourceObservationIssue.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated Properties

        #region Tests Generated for GetPolSourceObservationIssueWithPolSourceObservationIssueID(polSourceObservationIssue.PolSourceObservationIssueID)
        [Fact]
        public void GetPolSourceObservationIssueWithPolSourceObservationIssueID__polSourceObservationIssue_PolSourceObservationIssueID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    PolSourceObservationIssue polSourceObservationIssue = (from c in dbTestDB.PolSourceObservationIssues select c).FirstOrDefault();
                    Assert.NotNull(polSourceObservationIssue);

                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationIssueWithPolSourceObservationIssueID(polSourceObservationIssue.PolSourceObservationIssueID)

        #region Tests Generated for GetPolSourceObservationIssueList()
        [Fact]
        public void GetPolSourceObservationIssueList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    PolSourceObservationIssue polSourceObservationIssue = (from c in dbTestDB.PolSourceObservationIssues select c).FirstOrDefault();
                    Assert.NotNull(polSourceObservationIssue);

                    List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                    polSourceObservationIssueDirectQueryList = (from c in dbTestDB.PolSourceObservationIssues select c).Take(200).ToList();

                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationIssueList()

        #region Tests Generated for GetPolSourceObservationIssueList() Skip Take
        [Fact]
        public void GetPolSourceObservationIssueList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), culture.TwoLetterISOLanguageName, 1, 1, "", "");

                    List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                    polSourceObservationIssueDirectQueryList = (from c in dbTestDB.PolSourceObservationIssues select c).Skip(1).Take(1).ToList();

                        List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                        polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        CheckPolSourceObservationIssueFields(polSourceObservationIssueList);
                        Assert.Equal(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationIssueList() Skip Take

        #region Tests Generated for GetPolSourceObservationIssueList() Skip Take Asc
        [Fact]
        public void GetPolSourceObservationIssueList_Skip_Take_Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), culture.TwoLetterISOLanguageName, 1, 1,  "PolSourceObservationIssueID", "", "");

                    List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                    polSourceObservationIssueDirectQueryList = (from c in dbTestDB.PolSourceObservationIssues select c).OrderBy(c => c.PolSourceObservationIssueID).Skip(1).Take(1).ToList();

                        List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                        polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        CheckPolSourceObservationIssueFields(polSourceObservationIssueList);
                        Assert.Equal(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationIssueList() Skip Take Asc

        #region Tests Generated for GetPolSourceObservationIssueList() Skip Take 2 Asc
        [Fact]
        public void GetPolSourceObservationIssueList_Skip_Take_2Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), culture.TwoLetterISOLanguageName, 1, 1, "PolSourceObservationIssueID,PolSourceObservationID", "", "");

                    List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                    polSourceObservationIssueDirectQueryList = (from c in dbTestDB.PolSourceObservationIssues select c).OrderBy(c => c.PolSourceObservationIssueID).ThenBy(c => c.PolSourceObservationID).Skip(1).Take(1).ToList();

                        List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                        polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        CheckPolSourceObservationIssueFields(polSourceObservationIssueList);
                        Assert.Equal(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationIssueList() Skip Take 2 Asc

        #region Tests Generated for GetPolSourceObservationIssueList() Skip Take Asc Where
        [Fact]
        public void GetPolSourceObservationIssueList_Skip_Take_Asc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceObservationIssueID", "", "PolSourceObservationIssueID,EQ,4");

                    List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                    polSourceObservationIssueDirectQueryList = (from c in dbTestDB.PolSourceObservationIssues select c).Where(c => c.PolSourceObservationIssueID == 4).OrderBy(c => c.PolSourceObservationIssueID).Skip(0).Take(1).ToList();

                        List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                        polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        CheckPolSourceObservationIssueFields(polSourceObservationIssueList);
                        Assert.Equal(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationIssueList() Skip Take Asc Where

        #region Tests Generated for GetPolSourceObservationIssueList() Skip Take Asc 2 Where
        [Fact]
        public void GetPolSourceObservationIssueList_Skip_Take_Asc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                     PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                     polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceObservationIssueID", "", "PolSourceObservationIssueID,GT,2|PolSourceObservationIssueID,LT,5");

                     List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                     polSourceObservationIssueDirectQueryList = (from c in dbTestDB.PolSourceObservationIssues select c).Where(c => c.PolSourceObservationIssueID > 2 && c.PolSourceObservationIssueID < 5).Skip(0).Take(1).OrderBy(c => c.PolSourceObservationIssueID).ToList();

                        List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                        polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        CheckPolSourceObservationIssueFields(polSourceObservationIssueList);
                        Assert.Equal(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationIssueList() Skip Take Asc 2 Where

        #region Tests Generated for GetPolSourceObservationIssueList() Skip Take Desc
        [Fact]
        public void GetPolSourceObservationIssueList_Skip_Take_Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), culture.TwoLetterISOLanguageName, 1, 1, "", "PolSourceObservationIssueID", "");

                    List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                    polSourceObservationIssueDirectQueryList = (from c in dbTestDB.PolSourceObservationIssues select c).OrderByDescending(c => c.PolSourceObservationIssueID).Skip(1).Take(1).ToList();

                        List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                        polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        CheckPolSourceObservationIssueFields(polSourceObservationIssueList);
                        Assert.Equal(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationIssueList() Skip Take Desc

        #region Tests Generated for GetPolSourceObservationIssueList() Skip Take 2 Desc
        [Fact]
        public void GetPolSourceObservationIssueList_Skip_Take_2Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), culture.TwoLetterISOLanguageName, 1, 1, "", "PolSourceObservationIssueID,PolSourceObservationID", "");

                    List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                    polSourceObservationIssueDirectQueryList = (from c in dbTestDB.PolSourceObservationIssues select c).OrderByDescending(c => c.PolSourceObservationIssueID).ThenByDescending(c => c.PolSourceObservationID).Skip(1).Take(1).ToList();

                        List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                        polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        CheckPolSourceObservationIssueFields(polSourceObservationIssueList);
                        Assert.Equal(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationIssueList() Skip Take 2 Desc

        #region Tests Generated for GetPolSourceObservationIssueList() Skip Take Desc Where
        [Fact]
        public void GetPolSourceObservationIssueList_Skip_Take_Desc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceObservationIssueID", "", "PolSourceObservationIssueID,EQ,4");

                    List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                    polSourceObservationIssueDirectQueryList = (from c in dbTestDB.PolSourceObservationIssues select c).Where(c => c.PolSourceObservationIssueID == 4).OrderByDescending(c => c.PolSourceObservationIssueID).Skip(0).Take(1).ToList();

                        List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                        polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        CheckPolSourceObservationIssueFields(polSourceObservationIssueList);
                        Assert.Equal(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationIssueList() Skip Take Desc Where

        #region Tests Generated for GetPolSourceObservationIssueList() Skip Take Desc 2 Where
        [Fact]
        public void GetPolSourceObservationIssueList_Skip_Take_Desc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), culture.TwoLetterISOLanguageName, 0, 1, "", "PolSourceObservationIssueID", "PolSourceObservationIssueID,GT,2|PolSourceObservationIssueID,LT,5");

                    List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                    polSourceObservationIssueDirectQueryList = (from c in dbTestDB.PolSourceObservationIssues select c).Where(c => c.PolSourceObservationIssueID > 2 && c.PolSourceObservationIssueID < 5).OrderByDescending(c => c.PolSourceObservationIssueID).Skip(0).Take(1).ToList();

                        List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                        polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        CheckPolSourceObservationIssueFields(polSourceObservationIssueList);
                        Assert.Equal(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationIssueList() Skip Take Desc 2 Where

        #region Tests Generated for GetPolSourceObservationIssueList() 2 Where
        [Fact]
        public void GetPolSourceObservationIssueList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), culture.TwoLetterISOLanguageName, 0, 10000, "", "", "PolSourceObservationIssueID,GT,2|PolSourceObservationIssueID,LT,5");

                    List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                    polSourceObservationIssueDirectQueryList = (from c in dbTestDB.PolSourceObservationIssues select c).Where(c => c.PolSourceObservationIssueID > 2 && c.PolSourceObservationIssueID < 5).ToList();

                        List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                        polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        CheckPolSourceObservationIssueFields(polSourceObservationIssueList);
                        Assert.Equal(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationIssueList() 2 Where

        #region Functions private
        private void CheckPolSourceObservationIssueFields(List<PolSourceObservationIssue> polSourceObservationIssueList)
        {
            Assert.False(string.IsNullOrWhiteSpace(polSourceObservationIssueList[0].ObservationInfo));
            if (!string.IsNullOrWhiteSpace(polSourceObservationIssueList[0].ExtraComment))
            {
                Assert.False(string.IsNullOrWhiteSpace(polSourceObservationIssueList[0].ExtraComment));
            }
        }
        private PolSourceObservationIssue GetFilledRandomPolSourceObservationIssue(string OmitPropName)
        {
            PolSourceObservationIssue polSourceObservationIssue = new PolSourceObservationIssue();

            if (OmitPropName != "PolSourceObservationID") polSourceObservationIssue.PolSourceObservationID = 1;
            if (OmitPropName != "ObservationInfo") polSourceObservationIssue.ObservationInfo = GetRandomString("", 5);
            if (OmitPropName != "Ordinal") polSourceObservationIssue.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "ExtraComment") polSourceObservationIssue.ExtraComment = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") polSourceObservationIssue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceObservationIssue.LastUpdateContactTVItemID = 2;

            return polSourceObservationIssue;
        }
        #endregion Functions private
    }
}
