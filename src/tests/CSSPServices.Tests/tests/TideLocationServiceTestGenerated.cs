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

    public partial class TideLocationServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TideLocationService tideLocationService { get; set; }
        #endregion Properties

        #region Constructors
        public TideLocationServiceTest() : base()
        {
            //tideLocationService = new TideLocationService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Fact]
        public void TideLocation_CRUD_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    TideLocation tideLocation = GetFilledRandomTideLocation("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = tideLocationService.GetTideLocationList().Count();

                    Assert.Equal(count, (from c in dbTestDB.TideLocations select c).Count());

                    tideLocationService.Add(tideLocation);
                    if (tideLocation.HasErrors)
                    {
                        Assert.Equal("", tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.True(tideLocationService.GetTideLocationList().Where(c => c == tideLocation).Any());
                    tideLocationService.Update(tideLocation);
                    if (tideLocation.HasErrors)
                    {
                        Assert.Equal("", tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.Equal(count + 1, tideLocationService.GetTideLocationList().Count());
                    tideLocationService.Delete(tideLocation);
                    if (tideLocation.HasErrors)
                    {
                        Assert.Equal("", tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.Equal(count, tideLocationService.GetTideLocationList().Count());

                }
            }
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Fact]
        public void TideLocation_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    count = tideLocationService.GetTideLocationList().Count();

                    TideLocation tideLocation = GetFilledRandomTideLocation("");

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // tideLocation.TideLocationID   (Int32)
                    // -----------------------------------

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.TideLocationID = 0;
                    tideLocationService.Update(tideLocation);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "TideLocationID"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.TideLocationID = 10000000;
                    tideLocationService.Update(tideLocation);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TideLocation", "TideLocationID", tideLocation.TideLocationID.ToString()), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000)]
                    // tideLocation.Zone   (Int32)
                    // -----------------------------------

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.Zone = -1;
                    Assert.False(tideLocationService.Add(tideLocation));
                    Assert.Equal(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Zone", "0", "10000"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(count, tideLocationService.GetTideLocationList().Count());
                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.Zone = 10001;
                    Assert.False(tideLocationService.Add(tideLocation));
                    Assert.Equal(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Zone", "0", "10000"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(count, tideLocationService.GetTideLocationList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // tideLocation.Name   (String)
                    // -----------------------------------

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("Name");
                    Assert.False(tideLocationService.Add(tideLocation));
                    Assert.Equal(1, tideLocation.ValidationResults.Count());
                    Assert.True(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "Name")).Any());
                    Assert.Null(tideLocation.Name);
                    Assert.Equal(count, tideLocationService.GetTideLocationList().Count());

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.Name = GetRandomString("", 101);
                    Assert.False(tideLocationService.Add(tideLocation));
                    Assert.Equal(string.Format(CSSPServicesRes._MaxLengthIs_, "Name", "100"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(count, tideLocationService.GetTideLocationList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // tideLocation.Prov   (String)
                    // -----------------------------------

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("Prov");
                    Assert.False(tideLocationService.Add(tideLocation));
                    Assert.Equal(1, tideLocation.ValidationResults.Count());
                    Assert.True(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "Prov")).Any());
                    Assert.Null(tideLocation.Prov);
                    Assert.Equal(count, tideLocationService.GetTideLocationList().Count());

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.Prov = GetRandomString("", 101);
                    Assert.False(tideLocationService.Add(tideLocation));
                    Assert.Equal(string.Format(CSSPServicesRes._MaxLengthIs_, "Prov", "100"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(count, tideLocationService.GetTideLocationList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100000)]
                    // tideLocation.sid   (Int32)
                    // -----------------------------------

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.sid = -1;
                    Assert.False(tideLocationService.Add(tideLocation));
                    Assert.Equal(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "sid", "0", "100000"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(count, tideLocationService.GetTideLocationList().Count());
                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.sid = 100001;
                    Assert.False(tideLocationService.Add(tideLocation));
                    Assert.Equal(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "sid", "0", "100000"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(count, tideLocationService.GetTideLocationList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-90, 90)]
                    // tideLocation.Lat   (Double)
                    // -----------------------------------

                    //CSSPError: Type not implemented [Lat]

                    //CSSPError: Type not implemented [Lat]

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.Lat = -91.0D;
                    Assert.False(tideLocationService.Add(tideLocation));
                    Assert.Equal(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Lat", "-90", "90"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(count, tideLocationService.GetTideLocationList().Count());
                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.Lat = 91.0D;
                    Assert.False(tideLocationService.Add(tideLocation));
                    Assert.Equal(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Lat", "-90", "90"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(count, tideLocationService.GetTideLocationList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-180, 180)]
                    // tideLocation.Lng   (Double)
                    // -----------------------------------

                    //CSSPError: Type not implemented [Lng]

                    //CSSPError: Type not implemented [Lng]

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.Lng = -181.0D;
                    Assert.False(tideLocationService.Add(tideLocation));
                    Assert.Equal(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Lng", "-180", "180"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(count, tideLocationService.GetTideLocationList().Count());
                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.Lng = 181.0D;
                    Assert.False(tideLocationService.Add(tideLocation));
                    Assert.Equal(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Lng", "-180", "180"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.Equal(count, tideLocationService.GetTideLocationList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tideLocation.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.LastUpdateDate_UTC = new DateTime();
                    tideLocationService.Add(tideLocation);
                    Assert.Equal(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tideLocationService.Add(tideLocation);
                    Assert.Equal(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tideLocation.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.LastUpdateContactTVItemID = 0;
                    tideLocationService.Add(tideLocation);
                    Assert.Equal(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tideLocation.LastUpdateContactTVItemID.ToString()), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.LastUpdateContactTVItemID = 1;
                    tideLocationService.Add(tideLocation);
                    Assert.Equal(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tideLocation.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tideLocation.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated Properties

        #region Tests Generated for GetTideLocationWithTideLocationID(tideLocation.TideLocationID)
        [Fact]
        public void GetTideLocationWithTideLocationID__tideLocation_TideLocationID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TideLocation tideLocation = (from c in dbTestDB.TideLocations select c).FirstOrDefault();
                    Assert.NotNull(tideLocation);

                }
            }
        }
        #endregion Tests Generated for GetTideLocationWithTideLocationID(tideLocation.TideLocationID)

        #region Tests Generated for GetTideLocationList()
        [Fact]
        public void GetTideLocationList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TideLocation tideLocation = (from c in dbTestDB.TideLocations select c).FirstOrDefault();
                    Assert.NotNull(tideLocation);

                    List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                    tideLocationDirectQueryList = (from c in dbTestDB.TideLocations select c).Take(200).ToList();

                }
            }
        }
        #endregion Tests Generated for GetTideLocationList()

        #region Tests Generated for GetTideLocationList() Skip Take
        [Fact]
        public void GetTideLocationList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), culture.TwoLetterISOLanguageName, 1, 1, "", "");

                    List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                    tideLocationDirectQueryList = (from c in dbTestDB.TideLocations select c).Skip(1).Take(1).ToList();

                        List<TideLocation> tideLocationList = new List<TideLocation>();
                        tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        CheckTideLocationFields(tideLocationList);
                        Assert.Equal(tideLocationDirectQueryList[0].TideLocationID, tideLocationList[0].TideLocationID);
                }
            }
        }
        #endregion Tests Generated for GetTideLocationList() Skip Take

        #region Tests Generated for GetTideLocationList() Skip Take Asc
        [Fact]
        public void GetTideLocationList_Skip_Take_Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), culture.TwoLetterISOLanguageName, 1, 1,  "TideLocationID", "", "");

                    List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                    tideLocationDirectQueryList = (from c in dbTestDB.TideLocations select c).OrderBy(c => c.TideLocationID).Skip(1).Take(1).ToList();

                        List<TideLocation> tideLocationList = new List<TideLocation>();
                        tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        CheckTideLocationFields(tideLocationList);
                        Assert.Equal(tideLocationDirectQueryList[0].TideLocationID, tideLocationList[0].TideLocationID);
                }
            }
        }
        #endregion Tests Generated for GetTideLocationList() Skip Take Asc

        #region Tests Generated for GetTideLocationList() Skip Take 2 Asc
        [Fact]
        public void GetTideLocationList_Skip_Take_2Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), culture.TwoLetterISOLanguageName, 1, 1, "TideLocationID,Zone", "", "");

                    List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                    tideLocationDirectQueryList = (from c in dbTestDB.TideLocations select c).OrderBy(c => c.TideLocationID).ThenBy(c => c.Zone).Skip(1).Take(1).ToList();

                        List<TideLocation> tideLocationList = new List<TideLocation>();
                        tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        CheckTideLocationFields(tideLocationList);
                        Assert.Equal(tideLocationDirectQueryList[0].TideLocationID, tideLocationList[0].TideLocationID);
                }
            }
        }
        #endregion Tests Generated for GetTideLocationList() Skip Take 2 Asc

        #region Tests Generated for GetTideLocationList() Skip Take Asc Where
        [Fact]
        public void GetTideLocationList_Skip_Take_Asc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), culture.TwoLetterISOLanguageName, 0, 1, "TideLocationID", "", "TideLocationID,EQ,4");

                    List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                    tideLocationDirectQueryList = (from c in dbTestDB.TideLocations select c).Where(c => c.TideLocationID == 4).OrderBy(c => c.TideLocationID).Skip(0).Take(1).ToList();

                        List<TideLocation> tideLocationList = new List<TideLocation>();
                        tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        CheckTideLocationFields(tideLocationList);
                        Assert.Equal(tideLocationDirectQueryList[0].TideLocationID, tideLocationList[0].TideLocationID);
                }
            }
        }
        #endregion Tests Generated for GetTideLocationList() Skip Take Asc Where

        #region Tests Generated for GetTideLocationList() Skip Take Asc 2 Where
        [Fact]
        public void GetTideLocationList_Skip_Take_Asc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                     TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                     tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), culture.TwoLetterISOLanguageName, 0, 1, "TideLocationID", "", "TideLocationID,GT,2|TideLocationID,LT,5");

                     List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                     tideLocationDirectQueryList = (from c in dbTestDB.TideLocations select c).Where(c => c.TideLocationID > 2 && c.TideLocationID < 5).Skip(0).Take(1).OrderBy(c => c.TideLocationID).ToList();

                        List<TideLocation> tideLocationList = new List<TideLocation>();
                        tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        CheckTideLocationFields(tideLocationList);
                        Assert.Equal(tideLocationDirectQueryList[0].TideLocationID, tideLocationList[0].TideLocationID);
                }
            }
        }
        #endregion Tests Generated for GetTideLocationList() Skip Take Asc 2 Where

        #region Tests Generated for GetTideLocationList() Skip Take Desc
        [Fact]
        public void GetTideLocationList_Skip_Take_Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), culture.TwoLetterISOLanguageName, 1, 1, "", "TideLocationID", "");

                    List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                    tideLocationDirectQueryList = (from c in dbTestDB.TideLocations select c).OrderByDescending(c => c.TideLocationID).Skip(1).Take(1).ToList();

                        List<TideLocation> tideLocationList = new List<TideLocation>();
                        tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        CheckTideLocationFields(tideLocationList);
                        Assert.Equal(tideLocationDirectQueryList[0].TideLocationID, tideLocationList[0].TideLocationID);
                }
            }
        }
        #endregion Tests Generated for GetTideLocationList() Skip Take Desc

        #region Tests Generated for GetTideLocationList() Skip Take 2 Desc
        [Fact]
        public void GetTideLocationList_Skip_Take_2Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), culture.TwoLetterISOLanguageName, 1, 1, "", "TideLocationID,Zone", "");

                    List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                    tideLocationDirectQueryList = (from c in dbTestDB.TideLocations select c).OrderByDescending(c => c.TideLocationID).ThenByDescending(c => c.Zone).Skip(1).Take(1).ToList();

                        List<TideLocation> tideLocationList = new List<TideLocation>();
                        tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        CheckTideLocationFields(tideLocationList);
                        Assert.Equal(tideLocationDirectQueryList[0].TideLocationID, tideLocationList[0].TideLocationID);
                }
            }
        }
        #endregion Tests Generated for GetTideLocationList() Skip Take 2 Desc

        #region Tests Generated for GetTideLocationList() Skip Take Desc Where
        [Fact]
        public void GetTideLocationList_Skip_Take_Desc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), culture.TwoLetterISOLanguageName, 0, 1, "TideLocationID", "", "TideLocationID,EQ,4");

                    List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                    tideLocationDirectQueryList = (from c in dbTestDB.TideLocations select c).Where(c => c.TideLocationID == 4).OrderByDescending(c => c.TideLocationID).Skip(0).Take(1).ToList();

                        List<TideLocation> tideLocationList = new List<TideLocation>();
                        tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        CheckTideLocationFields(tideLocationList);
                        Assert.Equal(tideLocationDirectQueryList[0].TideLocationID, tideLocationList[0].TideLocationID);
                }
            }
        }
        #endregion Tests Generated for GetTideLocationList() Skip Take Desc Where

        #region Tests Generated for GetTideLocationList() Skip Take Desc 2 Where
        [Fact]
        public void GetTideLocationList_Skip_Take_Desc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), culture.TwoLetterISOLanguageName, 0, 1, "", "TideLocationID", "TideLocationID,GT,2|TideLocationID,LT,5");

                    List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                    tideLocationDirectQueryList = (from c in dbTestDB.TideLocations select c).Where(c => c.TideLocationID > 2 && c.TideLocationID < 5).OrderByDescending(c => c.TideLocationID).Skip(0).Take(1).ToList();

                        List<TideLocation> tideLocationList = new List<TideLocation>();
                        tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        CheckTideLocationFields(tideLocationList);
                        Assert.Equal(tideLocationDirectQueryList[0].TideLocationID, tideLocationList[0].TideLocationID);
                }
            }
        }
        #endregion Tests Generated for GetTideLocationList() Skip Take Desc 2 Where

        #region Tests Generated for GetTideLocationList() 2 Where
        [Fact]
        public void GetTideLocationList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), culture.TwoLetterISOLanguageName, 0, 10000, "", "", "TideLocationID,GT,2|TideLocationID,LT,5");

                    List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                    tideLocationDirectQueryList = (from c in dbTestDB.TideLocations select c).Where(c => c.TideLocationID > 2 && c.TideLocationID < 5).ToList();

                        List<TideLocation> tideLocationList = new List<TideLocation>();
                        tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        CheckTideLocationFields(tideLocationList);
                        Assert.Equal(tideLocationDirectQueryList[0].TideLocationID, tideLocationList[0].TideLocationID);
                }
            }
        }
        #endregion Tests Generated for GetTideLocationList() 2 Where

        #region Functions private
        private void CheckTideLocationFields(List<TideLocation> tideLocationList)
        {
            Assert.NotNull(tideLocationList[0].TideLocationID);
            Assert.NotNull(tideLocationList[0].Zone);
            Assert.False(string.IsNullOrWhiteSpace(tideLocationList[0].Name));
            Assert.False(string.IsNullOrWhiteSpace(tideLocationList[0].Prov));
            Assert.NotNull(tideLocationList[0].sid);
            Assert.NotNull(tideLocationList[0].Lat);
            Assert.NotNull(tideLocationList[0].Lng);
            Assert.NotNull(tideLocationList[0].LastUpdateDate_UTC);
            Assert.NotNull(tideLocationList[0].LastUpdateContactTVItemID);
            Assert.NotNull(tideLocationList[0].HasErrors);
        }
        private TideLocation GetFilledRandomTideLocation(string OmitPropName)
        {
            TideLocation tideLocation = new TideLocation();

            if (OmitPropName != "Zone") tideLocation.Zone = GetRandomInt(0, 10000);
            if (OmitPropName != "Name") tideLocation.Name = GetRandomString("", 5);
            if (OmitPropName != "Prov") tideLocation.Prov = GetRandomString("", 5);
            if (OmitPropName != "sid") tideLocation.sid = GetRandomInt(0, 100000);
            if (OmitPropName != "Lat") tideLocation.Lat = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "Lng") tideLocation.Lng = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "LastUpdateDate_UTC") tideLocation.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tideLocation.LastUpdateContactTVItemID = 2;

            return tideLocation;
        }
        #endregion Functions private
    }
}
