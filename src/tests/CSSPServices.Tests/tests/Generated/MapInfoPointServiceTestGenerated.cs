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
    public partial class MapInfoPointServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MapInfoPointService mapInfoPointService { get; set; }
        #endregion Properties

        #region Constructors
        public MapInfoPointServiceTest() : base()
        {
            //mapInfoPointService = new MapInfoPointService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD
        [TestMethod]
        public void MapInfoPoint_CRUD_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MapInfoPoint mapInfoPoint = GetFilledRandomMapInfoPoint("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = mapInfoPointService.GetMapInfoPointList().Count();

                    Assert.AreEqual(count, (from c in dbTestDB.MapInfoPoints select c).Count());

                    mapInfoPointService.Add(mapInfoPoint);
                    if (mapInfoPoint.HasErrors)
                    {
                        Assert.AreEqual("", mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mapInfoPointService.GetMapInfoPointList().Where(c => c == mapInfoPoint).Any());
                    mapInfoPointService.Update(mapInfoPoint);
                    if (mapInfoPoint.HasErrors)
                    {
                        Assert.AreEqual("", mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mapInfoPointService.GetMapInfoPointList().Count());
                    mapInfoPointService.Delete(mapInfoPoint);
                    if (mapInfoPoint.HasErrors)
                    {
                        Assert.AreEqual("", mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mapInfoPointService.GetMapInfoPointList().Count());

                }
            }
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [TestMethod]
        public void MapInfoPoint_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    count = mapInfoPointService.GetMapInfoPointList().Count();

                    MapInfoPoint mapInfoPoint = GetFilledRandomMapInfoPoint("");

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mapInfoPoint.MapInfoPointID   (Int32)
                    // -----------------------------------

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.MapInfoPointID = 0;
                    mapInfoPointService.Update(mapInfoPoint);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MapInfoPointID"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.MapInfoPointID = 10000000;
                    mapInfoPointService.Update(mapInfoPoint);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MapInfoPoint", "MapInfoPointID", mapInfoPoint.MapInfoPointID.ToString()), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "MapInfo", ExistPlurial = "s", ExistFieldID = "MapInfoID", AllowableTVtypeList = )]
                    // mapInfoPoint.MapInfoID   (Int32)
                    // -----------------------------------

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.MapInfoID = 0;
                    mapInfoPointService.Add(mapInfoPoint);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MapInfo", "MapInfoID", mapInfoPoint.MapInfoID.ToString()), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, -1)]
                    // mapInfoPoint.Ordinal   (Int32)
                    // -----------------------------------

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.Ordinal = -1;
                    Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MinValueIs_, "Ordinal", "0"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoPointService.GetMapInfoPointList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-90, 90)]
                    // mapInfoPoint.Lat   (Double)
                    // -----------------------------------

                    //CSSPError: Type not implemented [Lat]

                    //CSSPError: Type not implemented [Lat]

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.Lat = -91.0D;
                    Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Lat", "-90", "90"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoPointService.GetMapInfoPointList().Count());
                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.Lat = 91.0D;
                    Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Lat", "-90", "90"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoPointService.GetMapInfoPointList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-180, 180)]
                    // mapInfoPoint.Lng   (Double)
                    // -----------------------------------

                    //CSSPError: Type not implemented [Lng]

                    //CSSPError: Type not implemented [Lng]

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.Lng = -181.0D;
                    Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Lng", "-180", "180"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoPointService.GetMapInfoPointList().Count());
                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.Lng = 181.0D;
                    Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Lng", "-180", "180"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoPointService.GetMapInfoPointList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mapInfoPoint.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.LastUpdateDate_UTC = new DateTime();
                    mapInfoPointService.Add(mapInfoPoint);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mapInfoPointService.Add(mapInfoPoint);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mapInfoPoint.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.LastUpdateContactTVItemID = 0;
                    mapInfoPointService.Add(mapInfoPoint);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mapInfoPoint.LastUpdateContactTVItemID.ToString()), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.LastUpdateContactTVItemID = 1;
                    mapInfoPointService.Add(mapInfoPoint);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mapInfoPoint.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mapInfoPoint.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated Properties

        #region Tests Generated for GetMapInfoPointWithMapInfoPointID(mapInfoPoint.MapInfoPointID)
        [TestMethod]
        public void GetMapInfoPointWithMapInfoPointID__mapInfoPoint_MapInfoPointID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MapInfoPoint mapInfoPoint = (from c in dbTestDB.MapInfoPoints select c).FirstOrDefault();
                    Assert.IsNotNull(mapInfoPoint);

                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        mapInfoPointService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            MapInfoPoint mapInfoPointRet = mapInfoPointService.GetMapInfoPointWithMapInfoPointID(mapInfoPoint.MapInfoPointID);
                            CheckMapInfoPointFields(new List<MapInfoPoint>() { mapInfoPointRet });
                            Assert.AreEqual(mapInfoPoint.MapInfoPointID, mapInfoPointRet.MapInfoPointID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoPointWithMapInfoPointID(mapInfoPoint.MapInfoPointID)

        #region Tests Generated for GetMapInfoPointList()
        [TestMethod]
        public void GetMapInfoPointList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MapInfoPoint mapInfoPoint = (from c in dbTestDB.MapInfoPoints select c).FirstOrDefault();
                    Assert.IsNotNull(mapInfoPoint);

                    List<MapInfoPoint> mapInfoPointDirectQueryList = new List<MapInfoPoint>();
                    mapInfoPointDirectQueryList = (from c in dbTestDB.MapInfoPoints select c).Take(200).ToList();

                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        mapInfoPointService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                            CheckMapInfoPointFields(mapInfoPointList);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoPointList()

        #region Tests Generated for GetMapInfoPointList() Skip Take
        [TestMethod]
        public void GetMapInfoPointList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoPointService.Query = mapInfoPointService.FillQuery(typeof(MapInfoPoint), culture.TwoLetterISOLanguageName, 1, 1, "", "", "", extra);

                        List<MapInfoPoint> mapInfoPointDirectQueryList = new List<MapInfoPoint>();
                        mapInfoPointDirectQueryList = (from c in dbTestDB.MapInfoPoints select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                            CheckMapInfoPointFields(mapInfoPointList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointList[0].MapInfoPointID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoPointList() Skip Take

        #region Tests Generated for GetMapInfoPointList() Skip Take Asc
        [TestMethod]
        public void GetMapInfoPointList_Skip_Take_Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoPointService.Query = mapInfoPointService.FillQuery(typeof(MapInfoPoint), culture.TwoLetterISOLanguageName, 1, 1,  "MapInfoPointID", "", "", extra);

                        List<MapInfoPoint> mapInfoPointDirectQueryList = new List<MapInfoPoint>();
                        mapInfoPointDirectQueryList = (from c in dbTestDB.MapInfoPoints select c).OrderBy(c => c.MapInfoPointID).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                            CheckMapInfoPointFields(mapInfoPointList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointList[0].MapInfoPointID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoPointList() Skip Take Asc

        #region Tests Generated for GetMapInfoPointList() Skip Take 2 Asc
        [TestMethod]
        public void GetMapInfoPointList_Skip_Take_2Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoPointService.Query = mapInfoPointService.FillQuery(typeof(MapInfoPoint), culture.TwoLetterISOLanguageName, 1, 1, "MapInfoPointID,MapInfoID", "", "", extra);

                        List<MapInfoPoint> mapInfoPointDirectQueryList = new List<MapInfoPoint>();
                        mapInfoPointDirectQueryList = (from c in dbTestDB.MapInfoPoints select c).OrderBy(c => c.MapInfoPointID).ThenBy(c => c.MapInfoID).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                            CheckMapInfoPointFields(mapInfoPointList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointList[0].MapInfoPointID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoPointList() Skip Take 2 Asc

        #region Tests Generated for GetMapInfoPointList() Skip Take Asc Where
        [TestMethod]
        public void GetMapInfoPointList_Skip_Take_Asc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoPointService.Query = mapInfoPointService.FillQuery(typeof(MapInfoPoint), culture.TwoLetterISOLanguageName, 0, 1, "MapInfoPointID", "", "MapInfoPointID,EQ,4", "");

                        List<MapInfoPoint> mapInfoPointDirectQueryList = new List<MapInfoPoint>();
                        mapInfoPointDirectQueryList = (from c in dbTestDB.MapInfoPoints select c).Where(c => c.MapInfoPointID == 4).OrderBy(c => c.MapInfoPointID).Skip(0).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                            CheckMapInfoPointFields(mapInfoPointList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointList[0].MapInfoPointID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoPointList() Skip Take Asc Where

        #region Tests Generated for GetMapInfoPointList() Skip Take Asc 2 Where
        [TestMethod]
        public void GetMapInfoPointList_Skip_Take_Asc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoPointService.Query = mapInfoPointService.FillQuery(typeof(MapInfoPoint), culture.TwoLetterISOLanguageName, 0, 1, "MapInfoPointID", "", "MapInfoPointID,GT,2|MapInfoPointID,LT,5", "");

                        List<MapInfoPoint> mapInfoPointDirectQueryList = new List<MapInfoPoint>();
                        mapInfoPointDirectQueryList = (from c in dbTestDB.MapInfoPoints select c).Where(c => c.MapInfoPointID > 2 && c.MapInfoPointID < 5).Skip(0).Take(1).OrderBy(c => c.MapInfoPointID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                            CheckMapInfoPointFields(mapInfoPointList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointList[0].MapInfoPointID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoPointList() Skip Take Asc 2 Where

        #region Tests Generated for GetMapInfoPointList() Skip Take Desc
        [TestMethod]
        public void GetMapInfoPointList_Skip_Take_Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoPointService.Query = mapInfoPointService.FillQuery(typeof(MapInfoPoint), culture.TwoLetterISOLanguageName, 1, 1, "", "MapInfoPointID", "", extra);

                        List<MapInfoPoint> mapInfoPointDirectQueryList = new List<MapInfoPoint>();
                        mapInfoPointDirectQueryList = (from c in dbTestDB.MapInfoPoints select c).OrderByDescending(c => c.MapInfoPointID).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                            CheckMapInfoPointFields(mapInfoPointList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointList[0].MapInfoPointID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoPointList() Skip Take Desc

        #region Tests Generated for GetMapInfoPointList() Skip Take 2 Desc
        [TestMethod]
        public void GetMapInfoPointList_Skip_Take_2Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoPointService.Query = mapInfoPointService.FillQuery(typeof(MapInfoPoint), culture.TwoLetterISOLanguageName, 1, 1, "", "MapInfoPointID,MapInfoID", "", extra);

                        List<MapInfoPoint> mapInfoPointDirectQueryList = new List<MapInfoPoint>();
                        mapInfoPointDirectQueryList = (from c in dbTestDB.MapInfoPoints select c).OrderByDescending(c => c.MapInfoPointID).ThenByDescending(c => c.MapInfoID).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                            CheckMapInfoPointFields(mapInfoPointList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointList[0].MapInfoPointID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoPointList() Skip Take 2 Desc

        #region Tests Generated for GetMapInfoPointList() Skip Take Desc Where
        [TestMethod]
        public void GetMapInfoPointList_Skip_Take_Desc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoPointService.Query = mapInfoPointService.FillQuery(typeof(MapInfoPoint), culture.TwoLetterISOLanguageName, 0, 1, "MapInfoPointID", "", "MapInfoPointID,EQ,4", "");

                        List<MapInfoPoint> mapInfoPointDirectQueryList = new List<MapInfoPoint>();
                        mapInfoPointDirectQueryList = (from c in dbTestDB.MapInfoPoints select c).Where(c => c.MapInfoPointID == 4).OrderByDescending(c => c.MapInfoPointID).Skip(0).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                            CheckMapInfoPointFields(mapInfoPointList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointList[0].MapInfoPointID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoPointList() Skip Take Desc Where

        #region Tests Generated for GetMapInfoPointList() Skip Take Desc 2 Where
        [TestMethod]
        public void GetMapInfoPointList_Skip_Take_Desc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoPointService.Query = mapInfoPointService.FillQuery(typeof(MapInfoPoint), culture.TwoLetterISOLanguageName, 0, 1, "", "MapInfoPointID", "MapInfoPointID,GT,2|MapInfoPointID,LT,5", "");

                        List<MapInfoPoint> mapInfoPointDirectQueryList = new List<MapInfoPoint>();
                        mapInfoPointDirectQueryList = (from c in dbTestDB.MapInfoPoints select c).Where(c => c.MapInfoPointID > 2 && c.MapInfoPointID < 5).OrderByDescending(c => c.MapInfoPointID).Skip(0).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                            CheckMapInfoPointFields(mapInfoPointList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointList[0].MapInfoPointID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoPointList() Skip Take Desc 2 Where

        #region Tests Generated for GetMapInfoPointList() 2 Where
        [TestMethod]
        public void GetMapInfoPointList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoPointService.Query = mapInfoPointService.FillQuery(typeof(MapInfoPoint), culture.TwoLetterISOLanguageName, 0, 10000, "", "", "MapInfoPointID,GT,2|MapInfoPointID,LT,5", extra);

                        List<MapInfoPoint> mapInfoPointDirectQueryList = new List<MapInfoPoint>();
                        mapInfoPointDirectQueryList = (from c in dbTestDB.MapInfoPoints select c).Where(c => c.MapInfoPointID > 2 && c.MapInfoPointID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                            CheckMapInfoPointFields(mapInfoPointList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointList[0].MapInfoPointID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoPointList() 2 Where

        #region Functions private
        private void CheckMapInfoPointFields(List<MapInfoPoint> mapInfoPointList)
        {
            Assert.IsNotNull(mapInfoPointList[0].MapInfoPointID);
            Assert.IsNotNull(mapInfoPointList[0].MapInfoID);
            Assert.IsNotNull(mapInfoPointList[0].Ordinal);
            Assert.IsNotNull(mapInfoPointList[0].Lat);
            Assert.IsNotNull(mapInfoPointList[0].Lng);
            Assert.IsNotNull(mapInfoPointList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mapInfoPointList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mapInfoPointList[0].HasErrors);
        }
        private MapInfoPoint GetFilledRandomMapInfoPoint(string OmitPropName)
        {
            MapInfoPoint mapInfoPoint = new MapInfoPoint();

            if (OmitPropName != "MapInfoID") mapInfoPoint.MapInfoID = 1;
            if (OmitPropName != "Ordinal") mapInfoPoint.Ordinal = GetRandomInt(0, 10);
            if (OmitPropName != "Lat") mapInfoPoint.Lat = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "Lng") mapInfoPoint.Lng = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "LastUpdateDate_UTC") mapInfoPoint.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mapInfoPoint.LastUpdateContactTVItemID = 2;

            return mapInfoPoint;
        }
        #endregion Functions private
    }
}
