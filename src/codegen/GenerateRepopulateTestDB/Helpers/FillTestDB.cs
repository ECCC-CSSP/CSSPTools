//using CSSPEnums;
//using CSSPDBModels;
//using GenerateCodeBaseServices.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Threading.Tasks;

//namespace GenerateRepopulateTestDB
//{
//    public partial class Startup
//    {
//        private async Task<bool> FillTestDB(List<Table> tableTestDBList)
//        {
//            try
//            {

//                #region TVItem Root
//                Console.WriteLine($"doing ... root");
//                // TVItem Root TVItemID = 1
//                TVItem tvItemRoot = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == c.ParentID && c.TVLevel == 0).FirstOrDefault();
//                int RootTVItemID = tvItemRoot.TVItemID;
//                if (!await AddObject("TVItem", tvItemRoot)) return await Task.FromResult(false);

//                // TVItemLanguage EN Root TVItemID = 1
//                TVItemLanguage tvItemLanguageENRoot = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == RootTVItemID && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENRoot.TVItemID = tvItemRoot.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENRoot)) return await Task.FromResult(false);

//                // TVItemLanguage FR Root TVItemID = 1
//                TVItemLanguage tvItemLanguageFRRoot = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == RootTVItemID && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRRoot.TVItemID = tvItemRoot.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRRoot)) return await Task.FromResult(false);
//                #endregion  TVItem Root
//                #region Contact Charles with TVItem
//                Console.WriteLine($"doing ... Contact Charles with TVItem");
//                // TVItem Charles G. LeBlanc TVItemID = 2
//                TVItem tvItemContactCharles = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 2).FirstOrDefault();
//                tvItemContactCharles.ParentID = tvItemRoot.TVItemID;
//                if (!await AddObject("TVItem", tvItemContactCharles)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemContactCharles, tvItemRoot)) return await Task.FromResult(false);

//                // TVItemLanguage EN Charles G. LeBlanc  TVItemID = 2
//                TVItemLanguage tvItemLanguageENContactCharles = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 2 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENContactCharles.TVItemID = tvItemContactCharles.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENContactCharles)) return await Task.FromResult(false);

//                // TVItemLanguage FR Charles G. LeBlanc TVItemID = 2
//                TVItemLanguage tvItemLanguageFRContactCharles = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 2 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRContactCharles.TVItemID = tvItemContactCharles.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRContactCharles)) return await Task.FromResult(false);

//                //Console.WriteLine($"doing ... Contact Charles with TVItem");

//                //ContactService contactService = new ContactService(new Query(), dbTestDB, 2);

//                // Contact Charles G. LeBlanc
//                Contact contactCharles = dbCSSPDB.Contacts.AsNoTracking().Where(c => c.ContactTVItemID == 2).FirstOrDefault();
//                AspNetUser aspNetUserCharles = dbCSSPDB.AspNetUsers.AsNoTracking().Where(c => c.Id == contactCharles.Id).FirstOrDefault();
//                if (!await AddObject("AspNetUser", aspNetUserCharles)) return await Task.FromResult(false);
//                if (!await AddObject("Contact", contactCharles)) return await Task.FromResult(false);
//                #endregion Contact Charles with TVItem
//                #region Contact Test User 1 with TVItem
//                Console.WriteLine($"doing ... TVItem Contact and Contact Login test user 1");
//                // TVItem Test User 1 TVItemID = 3
//                TVItem tvItemContactTestUser1 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 3).FirstOrDefault();
//                tvItemContactTestUser1.ParentID = tvItemRoot.TVItemID;
//                if (!await AddObject("TVItem", tvItemContactTestUser1)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemContactTestUser1, tvItemRoot)) return await Task.FromResult(false);

//                // TVItemLanguage EN Test User 1  TVItemID = 3
//                TVItemLanguage tvItemLanguageENContactTestUser1 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 3 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENContactTestUser1.TVItemID = tvItemContactTestUser1.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENContactTestUser1)) return await Task.FromResult(false);

//                // TVItemLanguage FR Test User 1 TVItemID = 3
//                TVItemLanguage tvItemLanguageFRContactTestUser1 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 3 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRContactTestUser1.TVItemID = tvItemContactTestUser1.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRContactTestUser1)) return await Task.FromResult(false);

//                // Contact Test User 1
//                Contact contactTestUser1 = dbCSSPDB.Contacts.AsNoTracking().Where(c => c.ContactTVItemID == 3).FirstOrDefault();
//                AspNetUser aspNetUserTestUser1 = dbCSSPDB.AspNetUsers.AsNoTracking().Where(c => c.Id == contactTestUser1.Id).FirstOrDefault();
//                if (!await AddObject("AspNetUser", aspNetUserTestUser1)) return await Task.FromResult(false);
//                if (!await AddObject("Contact", contactTestUser1)) return await Task.FromResult(false);
//                #endregion Contact Test User 1 with TVItem
//                #region Contact Test User 2 with TVItem
//                Console.WriteLine($"doing ... TVItem Contact and Contact Login test user 1");

//                // TVItem Test User 2 TVItemID = 4
//                TVItem tvItemContactTestUser2 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 4).FirstOrDefault();
//                tvItemContactTestUser2.ParentID = tvItemRoot.TVItemID;
//                if (!await AddObject("TVItem", tvItemContactTestUser2)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemContactTestUser2, tvItemRoot)) return await Task.FromResult(false);

//                // TVItemLanguage EN Test User 2  TVItemID = 4
//                TVItemLanguage tvItemLanguageENContactTestUser2 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 4 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENContactTestUser2.TVItemID = tvItemContactTestUser2.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENContactTestUser2)) return await Task.FromResult(false);

//                // TVItemLanguage FR Test User 2 TVItemID = 4
//                TVItemLanguage tvItemLanguageFRContactTestUser2 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 4 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRContactTestUser2.TVItemID = tvItemContactTestUser2.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRContactTestUser2)) return await Task.FromResult(false);

//                // Contact Test User 2
//                Contact contactTestUser2 = dbCSSPDB.Contacts.AsNoTracking().Where(c => c.ContactTVItemID == 4).FirstOrDefault();
//                AspNetUser aspNetUserTestUser2 = dbCSSPDB.AspNetUsers.AsNoTracking().Where(c => c.Id == contactTestUser2.Id).FirstOrDefault();
//                if (!await AddObject("AspNetUser", aspNetUserTestUser2)) return await Task.FromResult(false);
//                if (!await AddObject("Contact", contactTestUser2)) return await Task.FromResult(false);
//                #endregion Contact Test User 2 with TVItem
//                #region TVItem Country Canada
//                Console.WriteLine($"doing ... Canada");
//                // TVItem Canada TVItemID = 5
//                TVItem tvItemCanada = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 5).FirstOrDefault();
//                tvItemCanada.ParentID = tvItemRoot.TVItemID;
//                if (!await AddObject("TVItem", tvItemCanada)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemCanada, tvItemRoot)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemCanada, 5, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // TVItemLanguage EN Canada TVItemID = 5
//                TVItemLanguage tvItemLanguageENCanada = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 5 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENCanada.TVItemID = tvItemCanada.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENCanada)) return await Task.FromResult(false);

//                // TVItemLanguage FR Canada TVItemID = 5
//                TVItemLanguage tvItemLanguageFRCanada = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 5 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRCanada.TVItemID = tvItemCanada.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRCanada)) return await Task.FromResult(false);
//                #endregion TVItem Country Canada
//                #region TVItem Province NB
//                Console.WriteLine($"doing ... New Brunswick");
//                // TVItem Province NB TVItemID = 7
//                TVItem tvItemNB = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 7).FirstOrDefault();
//                int NBTVItemID = tvItemNB.TVItemID;
//                tvItemNB.ParentID = tvItemCanada.TVItemID;
//                if (!await AddObject("TVItem", tvItemNB)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemNB, tvItemCanada)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemNB, NBTVItemID, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // TVItemLanguage EN NB TVItemID = 7
//                TVItemLanguage tvItemLanguageENNB = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENNB.TVItemID = tvItemNB.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENNB)) return await Task.FromResult(false);

//                // TVItemLanguage FR NB TVItemID = 7
//                TVItemLanguage tvItemLanguageFRNB = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRNB.TVItemID = tvItemNB.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNB)) return await Task.FromResult(false);
//                #endregion TVItem Province NB
//                #region TVItem ClimateSite Bouctouche CDA
//                Console.WriteLine($"doing ... Climate Site");
//                // TVItem ClimateSite Bouctouche CDA TVItemID = 229528
//                TVItem tvItemNBClimateSiteBouctoucheCDA = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 229528).FirstOrDefault();
//                tvItemNBClimateSiteBouctoucheCDA.ParentID = tvItemNB.TVItemID;
//                if (!await AddObject("TVItem", tvItemNBClimateSiteBouctoucheCDA)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemNBClimateSiteBouctoucheCDA, tvItemNB)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemNBClimateSiteBouctoucheCDA, 229528, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // TVItemLanguage EN Climate Site Bouctouche CDA NB TVItemID = 229528
//                TVItemLanguage tvItemLanguageENNBClimateSiteBouctoucheCDA = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 229528 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENNBClimateSiteBouctoucheCDA.TVItemID = tvItemNBClimateSiteBouctoucheCDA.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENNBClimateSiteBouctoucheCDA)) return await Task.FromResult(false);

//                // TVItemLanguage FR Climate Site Bouctouche CDA NB TVItemID = 229528
//                TVItemLanguage tvItemLanguageFRNBClimateSiteBouctoucheCDA = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 229528 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRNBClimateSiteBouctoucheCDA.TVItemID = tvItemNBClimateSiteBouctoucheCDA.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNBClimateSiteBouctoucheCDA)) return await Task.FromResult(false);
//                #endregion TVItem ClimateSite Bouctouche CDA
//                #region ClimateSite Bouctouche CDA

//                // NB Climate Site Bouctouche CDA where ClimateSiteTVItemID = 229528
//                ClimateSite climateSite = dbCSSPDB.ClimateSites.AsNoTracking().Where(c => c.ClimateSiteTVItemID == 229528).FirstOrDefault();
//                int ClimateSiteID = climateSite.ClimateSiteID;
//                climateSite.ClimateSiteTVItemID = tvItemNBClimateSiteBouctoucheCDA.TVItemID;
//                if (!await AddObject("ClimateSite", climateSite)) return await Task.FromResult(false);

//                // NB Climate Data Value Bouctouche CDA where ClimateSiteTVItemID = 229528
//                List<ClimateDataValue> climateDataValueList = dbCSSPDB.ClimateDataValues.AsNoTracking().Where(c => c.ClimateSiteID == ClimateSiteID && c.TotalPrecip_mm_cm != -999.0f).Take(5).ToList();
//                foreach (ClimateDataValue climateDataValue in climateDataValueList)
//                {
//                    climateDataValue.ClimateSiteID = climateSite.ClimateSiteID;
//                    climateDataValue.HourlyValues = "Some value";
//                    if (!await AddObject("ClimateDataValue", climateDataValue)) return await Task.FromResult(false);
//                }
//                #endregion ClimateSite Bouctouche CDA
//                #region TVItem HydrometricSite Big Tracadie 01BL003 
//                Console.WriteLine($"doing ... Hydrometric Site");
//                // TVItem HydrometricSite Big Tracadie 01BL003 TVItemID = 55401
//                TVItem tvItemNBHydrometricSiteBigTracadie = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 55401).FirstOrDefault();
//                tvItemNBHydrometricSiteBigTracadie.ParentID = tvItemNB.TVItemID;
//                if (!await AddObject("TVItem", tvItemNBHydrometricSiteBigTracadie)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemNBHydrometricSiteBigTracadie, tvItemNB)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemNBHydrometricSiteBigTracadie, 55401, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // TVItemLanguage EN Hydrometric site Big Tracadie NB TVItemID = 55401
//                TVItemLanguage tvItemLanguageENNBHydrometricSiteBigTracadie = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 55401 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENNBHydrometricSiteBigTracadie.TVItemID = tvItemNBHydrometricSiteBigTracadie.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENNBHydrometricSiteBigTracadie)) return await Task.FromResult(false);

//                // TVItemLanguage FR Hydrometric site Big Tracadie NB TVItemID = 55401
//                TVItemLanguage tvItemLanguageFRNBHydrometricSiteBigTracadie = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 55401 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRNBHydrometricSiteBigTracadie.TVItemID = tvItemNBHydrometricSiteBigTracadie.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNBHydrometricSiteBigTracadie)) return await Task.FromResult(false);
//                #endregion TVItem HydrometricSite Big Tracadie 01BL003 
//                #region HydrometricSite Big Tracadie 01BL003 

//                // NB Hydrometric site Big Tracadie where HydrometricSiteTVItemID = 55401
//                HydrometricSite hydrometricSite = dbCSSPDB.HydrometricSites.AsNoTracking().Where(c => c.HydrometricSiteTVItemID == 55401).FirstOrDefault();
//                int HydrometricSiteID = hydrometricSite.HydrometricSiteID;
//                hydrometricSite.HydrometricSiteTVItemID = tvItemNBHydrometricSiteBigTracadie.TVItemID;
//                if (!await AddObject("HydrometricSite", hydrometricSite)) return await Task.FromResult(false);

//                // NB Hydrometric site Big Tracadie where HydrometricSiteTVItemID = 55401
//                HydrometricDataValue hydrometricDataValue = new HydrometricDataValue();
//                hydrometricDataValue.HydrometricSiteID = hydrometricSite.HydrometricSiteID;
//                hydrometricDataValue.DateTime_Local = DateTime.Now;
//                hydrometricDataValue.Keep = true;
//                hydrometricDataValue.StorageDataType = StorageDataTypeEnum.Archived;
//                hydrometricDataValue.Discharge_m3_s = 23.4f;
//                hydrometricDataValue.DischargeEntered_m3_s = null;
//                hydrometricDataValue.Level_m = 3.0f;
//                hydrometricDataValue.HourlyValues = "Some hourly values text";
//                hydrometricDataValue.LastUpdateDate_UTC = DateTime.Now;
//                hydrometricDataValue.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
//                if (!await AddObject("HydrometricDataValue", hydrometricDataValue)) return await Task.FromResult(false);
//                #endregion HydrometricSite Big Tracadie 01BL003 
//                #region RatingCurve Big Tracadie 01BL003 
//                Console.WriteLine($"doing ... Rating Curve");

//                // NB Hydrometric site Big Tracadie where HydrometricSiteTVItemID = 55401
//                RatingCurve ratingCurve = dbCSSPDB.RatingCurves.AsNoTracking().Where(c => c.HydrometricSiteID == HydrometricSiteID).FirstOrDefault();
//                int RatingCurveID = ratingCurve.RatingCurveID;
//                ratingCurve.HydrometricSiteID = hydrometricSite.HydrometricSiteID;
//                if (!await AddObject("RatingCurve", ratingCurve)) return await Task.FromResult(false);
//                #endregion RatingCurve Big Tracadie 01BL003 
//                #region RatingCurveValue Big Tracadie 01BL003 
//                Console.WriteLine($"doing ... Rating Curve");
//                // NB Hydrometric site Big Tracadie where HydrometricSiteTVItemID = 55401
//                List<RatingCurveValue> ratingCurveValueList = dbCSSPDB.RatingCurveValues.AsNoTracking().Where(c => c.RatingCurveID == RatingCurveID).Take(5).ToList();
//                foreach (RatingCurveValue ratingCurveValue in ratingCurveValueList)
//                {
//                    ratingCurveValue.RatingCurveID = ratingCurve.RatingCurveID;
//                    if (!await AddObject("RatingCurveValue", ratingCurveValue)) return await Task.FromResult(false);
//                }
//                #endregion RatingCurve Big Tracadie 01BL003 
//                #region TVItem Area NB-06 
//                Console.WriteLine($"doing ... Area NB-06");
//                // TVItem Area NB-06 TVItemID = 629
//                TVItem tvItemNB_06 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 629).FirstOrDefault();
//                tvItemNB_06.ParentID = tvItemNB.TVItemID;
//                if (!await AddObject("TVItem", tvItemNB_06)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemNB_06, tvItemNB)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemNB_06, 629, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // TVItemLanguage EN NB-06 TVItemID = 629
//                TVItemLanguage tvItemLanguageENNB_06 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 629 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENNB_06.TVItemID = tvItemNB_06.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENNB_06)) return await Task.FromResult(false);

//                // TVItemLanguage FR NB_06 TVItemID = 629
//                TVItemLanguage tvItemLanguageFRNB_06 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 629 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRNB_06.TVItemID = tvItemNB_06.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNB_06)) return await Task.FromResult(false);
//                #endregion TVItem Area NB-06 
//                #region TVItem Sector NB-06-020 
//                Console.WriteLine($"doing ... Sector NB-06-020");
//                // TVItem Sector NB-06_020 TVItemID = 633
//                TVItem tvItemNB_06_020 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 633).FirstOrDefault();
//                tvItemNB_06_020.ParentID = tvItemNB_06.TVItemID;
//                if (!await AddObject("TVItem", tvItemNB_06_020)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemNB_06_020, tvItemNB_06)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemNB_06_020, 633, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // TVItemLanguage EN NB-06_020 TVItemID = 633
//                TVItemLanguage tvItemLanguageENNB_06_020 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 633 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENNB_06_020.TVItemID = tvItemNB_06_020.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENNB_06_020)) return await Task.FromResult(false);

//                // TVItemLanguage FR NB_06_020 TVItemID = 633
//                TVItemLanguage tvItemLanguageFRNB_06_020 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 633 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRNB_06_020.TVItemID = tvItemNB_06_020.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020)) return await Task.FromResult(false);
//                #endregion TVItem Sector NB-06-020 
//                #region TVItem Subsector NB-06_020_001 
//                Console.WriteLine($"doing ... Sector NB-06-020-001");
//                // TVItem Subsector NB-06_020_001 TVItemID = 634
//                TVItem tvItemNB_06_020_001 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 634).FirstOrDefault();
//                tvItemNB_06_020_001.ParentID = tvItemNB_06_020.TVItemID;
//                if (!await AddObject("TVItem", tvItemNB_06_020_001)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemNB_06_020_001, tvItemNB_06_020)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemNB_06_020_001, 634, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // TVItemLanguage EN NB-06_020_001 TVItemID = 634
//                TVItemLanguage tvItemLanguageENNB_06_020_001 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 634 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENNB_06_020_001.TVItemID = tvItemNB_06_020_001.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_001)) return await Task.FromResult(false);

//                // TVItemLanguage FR NB_06_020 TVItemID = 634
//                TVItemLanguage tvItemLanguageFRNB_06_020_001 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 634 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRNB_06_020_001.TVItemID = tvItemNB_06_020_001.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_001)) return await Task.FromResult(false);
//                #endregion TVItem Subsector NB-06_020_001 
//                #region MWQMSubsector NB-06_020_001 and MWQMSubsectorLanguage
//                Console.WriteLine($"doing ... MWQM Subsector NB-06-020-001");
//                // MWQMSubsector NB-06_020_001 TVItemID = 634
//                MWQMSubsector mwqmSubsector001 = dbCSSPDB.MWQMSubsectors.AsNoTracking().Where(c => c.MWQMSubsectorTVItemID == 634).FirstOrDefault();
//                int MWQMSubsector001ID = mwqmSubsector001.MWQMSubsectorID;
//                mwqmSubsector001.MWQMSubsectorTVItemID = tvItemNB_06_020_001.TVItemID;
//                if (!await AddObject("MWQMSubsector", mwqmSubsector001)) return await Task.FromResult(false);

//                // MWQMSubsectorLanguage EN NB-06_020_001 TVItemID = 634
//                MWQMSubsectorLanguage mwqmSubsector001EN = dbCSSPDB.MWQMSubsectorLanguages.AsNoTracking().Where(c => c.MWQMSubsectorID == MWQMSubsector001ID && c.Language == LanguageEnum.en).FirstOrDefault();
//                mwqmSubsector001EN.MWQMSubsectorID = mwqmSubsector001.MWQMSubsectorID;
//                mwqmSubsector001EN.LogBook = "somthing in the logbook";
//                if (!await AddObject("MWQMSubsectorLanguage", mwqmSubsector001EN)) return await Task.FromResult(false);

//                // MWQMSubsectorLanguage FR NB-06_020_001 TVItemID = 634
//                MWQMSubsectorLanguage mwqmSubsector001FR = dbCSSPDB.MWQMSubsectorLanguages.AsNoTracking().Where(c => c.MWQMSubsectorID == MWQMSubsector001ID && c.Language == LanguageEnum.fr).FirstOrDefault();
//                mwqmSubsector001FR.MWQMSubsectorID = mwqmSubsector001.MWQMSubsectorID;
//                mwqmSubsector001FR.LogBook = "somthing in the logbook";
//                if (!await AddObject("MWQMSubsectorLanguage", mwqmSubsector001FR)) return await Task.FromResult(false);
//                #endregion TVItem Subsector NB-06_020_001 
//                #region TVItem Subsector NB-06_020_002 
//                Console.WriteLine($"doing ... Subsector NB-06-020-002");
//                // TVItem Subsector NB-06_020_002 TVItemID = 635
//                TVItem tvItemNB_06_020_002 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 635).FirstOrDefault();
//                tvItemNB_06_020_002.ParentID = tvItemNB_06_020.TVItemID;
//                if (!await AddObject("TVItem", tvItemNB_06_020_002)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemNB_06_020_002, tvItemNB_06_020)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemNB_06_020_002, 635, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // TVItemLanguage EN NB-06_020_001 TVItemID = 635
//                TVItemLanguage tvItemLanguageENNB_06_020_002 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 635 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENNB_06_020_002.TVItemID = tvItemNB_06_020_002.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_002)) return await Task.FromResult(false);

//                // TVItemLanguage FR NB_06_020 TVItemID = 635
//                TVItemLanguage tvItemLanguageFRNB_06_020_002 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 635 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRNB_06_020_002.TVItemID = tvItemNB_06_020_002.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_002)) return await Task.FromResult(false);
//                #endregion TVItem Subsector NB-06_020_001 
//                #region MWQMSubsector NB-06_020_002 and MWQMSubsectorLanguage
//                Console.WriteLine($"doing ... MWQM Subsector NB-06-020-002");
//                // MWQMSubsector NB-06_020_002 TVItemID = 635
//                MWQMSubsector mwqmSubsector002 = dbCSSPDB.MWQMSubsectors.AsNoTracking().Where(c => c.MWQMSubsectorTVItemID == 635).FirstOrDefault();
//                int MWQMSubsector002ID = mwqmSubsector002.MWQMSubsectorID;
//                mwqmSubsector002.MWQMSubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
//                if (!await AddObject("MWQMSubsector", mwqmSubsector002)) return await Task.FromResult(false);

//                // MWQMSubsectorLanguage EN NB-06_020_002 TVItemID = 635
//                MWQMSubsectorLanguage mwqmSubsector002EN = dbCSSPDB.MWQMSubsectorLanguages.AsNoTracking().Where(c => c.MWQMSubsectorID == MWQMSubsector002ID && c.Language == LanguageEnum.en).FirstOrDefault();
//                mwqmSubsector002EN.MWQMSubsectorID = mwqmSubsector002.MWQMSubsectorID;
//                mwqmSubsector002EN.LogBook = "Something in the logbook";
//                if (!await AddObject("MWQMSubsectorLanguage", mwqmSubsector002EN)) return await Task.FromResult(false);

//                // MWQMSubsectorLanguage FR NB-06_020_002 TVItemID = 635
//                MWQMSubsectorLanguage mwqmSubsector002FR = dbCSSPDB.MWQMSubsectorLanguages.AsNoTracking().Where(c => c.MWQMSubsectorID == MWQMSubsector002ID && c.Language == LanguageEnum.fr).FirstOrDefault();
//                mwqmSubsector002FR.MWQMSubsectorID = mwqmSubsector002.MWQMSubsectorID;
//                mwqmSubsector002FR.LogBook = "Something in the logbook";
//                if (!await AddObject("MWQMSubsectorLanguage", mwqmSubsector002FR)) return await Task.FromResult(false);
//                #endregion TVItem Subsector NB-06_020_002 
//                #region TVItem Classification  and Classification
//                Console.WriteLine($"doing ... Classification");
//                // TVItem Classification where parent TVItemID = 635
//                List<TVItem> tvItemClassificationList = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.ParentID == 635 && c.TVType == TVTypeEnum.Classification).ToList();
//                foreach (TVItem tvItem in tvItemClassificationList)
//                {
//                    int oldTVItemID = tvItem.TVItemID;
//                    TVItem tvItemClassNew = tvItem;
//                    tvItemClassNew.ParentID = tvItemNB_06_020_002.TVItemID;
//                    if (!await AddObject("TVItem", tvItemClassNew)) return await Task.FromResult(false);
//                    if (!await CorrectTVPath(tvItemClassNew, tvItemNB_06_020_002)) return await Task.FromResult(false);
//                    if (!await AddMapInfo(tvItemClassNew, oldTVItemID, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                    // TVItemLanguage EN where parent TVItemID = 635
//                    TVItemLanguage tvItemLanguageENNClass = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == oldTVItemID && c.Language == LanguageEnum.en).FirstOrDefault();
//                    tvItemLanguageENNClass.TVItemID = tvItemClassNew.TVItemID;
//                    if (!await AddObject("TVItemLanguage", tvItemLanguageENNClass)) return await Task.FromResult(false);

//                    // TVItemLanguage FR NB_06_020 TVItemID = 635
//                    TVItemLanguage tvItemLanguageFRClass = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == oldTVItemID && c.Language == LanguageEnum.fr).FirstOrDefault();
//                    tvItemLanguageFRClass.TVItemID = tvItemClassNew.TVItemID;
//                    if (!await AddObject("TVItemLanguage", tvItemLanguageFRClass)) return await Task.FromResult(false);


//                    Classification classificaton = dbCSSPDB.Classifications.AsNoTracking().Where(c => c.ClassificationTVItemID == oldTVItemID).FirstOrDefault();
//                    Classification classificationNew = classificaton;
//                    classificationNew.ClassificationTVItemID = tvItemClassNew.TVItemID;
//                    if (!await AddObject("Classification", classificationNew)) return await Task.FromResult(false);
//                }
//                #endregion TVItem Classification and Classification
//                #region TideSites (Cap Pelé)
//                Console.WriteLine($"doing ... Cap Pelé");
//                // TVItem Cap Pelé TVItemID = 369979
//                TVItem tvItemCapPeleTideSite = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 369979).FirstOrDefault();
//                tvItemCapPeleTideSite.ParentID = tvItemNB.TVItemID;
//                if (!await AddObject("TVItem", tvItemCapPeleTideSite)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemCapPeleTideSite, tvItemNB)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemCapPeleTideSite, 369979, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // TVItemLanguage EN Cap Pelé TVItemID = 369979
//                TVItemLanguage tvItemLanguageENCapPele = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 369979 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENCapPele.TVItemID = tvItemCapPeleTideSite.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENCapPele)) return await Task.FromResult(false);

//                // TVItemLanguage FR Cap Pelé TVItemID = 369979
//                TVItemLanguage tvItemLanguageFRCapPele = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 369979 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRCapPele.TVItemID = tvItemCapPeleTideSite.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRCapPele)) return await Task.FromResult(false);

//                Console.WriteLine($"doing ... Tide Site");
//                // TideSite where TideSiteTVItemID = 369979
//                TideSite tideSite = dbCSSPDB.TideSites.AsNoTracking().Where(c => c.TideSiteTVItemID == 369979).FirstOrDefault();
//                tideSite.TideSiteTVItemID = tvItemCapPeleTideSite.TVItemID;
//                if (!await AddObject("TideSite", tideSite)) return await Task.FromResult(false);
//                #endregion TideSites
//                #region TideDataValues
//                // TideDataValue
//                List<TideDataValue> tideDataValueList = dbCSSPDB.TideDataValues.AsNoTracking().ToList();
//                if (tideDataValueList.Count > 0)
//                {
//                    foreach (TideDataValue tideDataValue in tideDataValueList)
//                    {
//                        tideDataValue.TideSiteTVItemID = tideSite.TideSiteTVItemID;
//                        if (!await AddObject("TideDataValue", tideDataValue)) return await Task.FromResult(false);
//                    }
//                }
//                else
//                {
//                    TideDataValue tideDataValue = new TideDataValue()
//                    {
//                        DateTime_Local = DateTime.Now,
//                        Depth_m = 23.2f,
//                        Keep = true,
//                        StorageDataType = StorageDataTypeEnum.Archived,
//                        TideDataType = TideDataTypeEnum.Min15,
//                        TideEnd = TideTextEnum.HighTide,
//                        TideStart = TideTextEnum.HighTide,
//                        TideSiteTVItemID = tideSite.TideSiteTVItemID,
//                        UVelocity_m_s = 0.4f,
//                        VVelocity_m_s = 0.3f,
//                        LastUpdateDate_UTC = DateTime.Now,
//                        LastUpdateContactTVItemID = 2,
//                    };
//                    if (!await AddObject("TideDataValue", tideDataValue)) return await Task.FromResult(false);
//                }
//                #endregion TideDataValues
//                #region TVItem Municipality Bouctouche
//                Console.WriteLine($"doing ... Bouctouche");
//                // TVItem Municipality Bouctouche TVItemID = 27764
//                TVItem tvItemBouctouche = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 27764).FirstOrDefault();
//                tvItemBouctouche.ParentID = tvItemNB.TVItemID;
//                if (!await AddObject("TVItem", tvItemBouctouche)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemBouctouche, tvItemNB)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemBouctouche, 27764, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // TVItemLanguage EN Bouctouche TVItemID = 27764
//                TVItemLanguage tvItemLanguageENBouctouche = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 27764 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENBouctouche.TVItemID = tvItemBouctouche.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENBouctouche)) return await Task.FromResult(false);

//                // TVItemLanguage FR Bouctouche TVItemID = 27764
//                TVItemLanguage tvItemLanguageFRBouctouche = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 27764 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRBouctouche.TVItemID = tvItemBouctouche.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRBouctouche)) return await Task.FromResult(false);
//                #endregion TVItem Municipality Bouctouche
//                #region TVItem Municipality Ste Marie de Kent 
//                Console.WriteLine($"doing ... Ste-Marie-de-Kent");
//                // TVItem Municipality Ste Marie de Kent TVItemID = 44855
//                TVItem tvItemSteMarieDeKent = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 44855).FirstOrDefault();
//                tvItemSteMarieDeKent.ParentID = tvItemNB.TVItemID;
//                if (!await AddObject("TVItem", tvItemSteMarieDeKent)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemSteMarieDeKent, tvItemNB)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemSteMarieDeKent, 44855, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // TVItemLanguage EN Ste Marie de Kent TVItemID = 44855
//                TVItemLanguage tvItemLanguageENSteMarieDeKent = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 44855 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENSteMarieDeKent.TVItemID = tvItemSteMarieDeKent.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENSteMarieDeKent)) return await Task.FromResult(false);

//                // TVItemLanguage FR Ste Marie de Kent TVItemID = 44855
//                TVItemLanguage tvItemLanguageFRSteMarieDeKent = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 44855 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRSteMarieDeKent.TVItemID = tvItemSteMarieDeKent.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRSteMarieDeKent)) return await Task.FromResult(false);
//                #endregion TVItem Municipality Ste Marie de Kent 
//                #region TVItem Municipality Bouctouche WWTP 
//                Console.WriteLine($"doing ... Bouctouche WWTP");
//                // TVItem Municipality Bouctouche WWTP TVItemID = 28689
//                TVItem tvItemBouctoucheWWTP = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 28689).FirstOrDefault();
//                tvItemBouctoucheWWTP.ParentID = tvItemBouctouche.TVItemID;
//                if (!await AddObject("TVItem", tvItemBouctoucheWWTP)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemBouctoucheWWTP, tvItemBouctouche)) return await Task.FromResult(false);
//                tvItemBouctoucheWWTP.TVType = TVTypeEnum.WasteWaterTreatmentPlant;
//                if (!await AddMapInfo(tvItemBouctoucheWWTP, 28689, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);
//                tvItemBouctoucheWWTP.TVType = TVTypeEnum.Infrastructure;

//                // TVItemLanguage EN Bouctouche WWTP TVItemID = 28689
//                TVItemLanguage tvItemLanguageENBouctoucheWWTP = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28689 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENBouctoucheWWTP.TVItemID = tvItemBouctoucheWWTP.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENBouctoucheWWTP)) return await Task.FromResult(false);

//                // TVItemLanguage FR Bouctouche WWTP TVItemID = 28689
//                TVItemLanguage tvItemLanguageFRBouctoucheWWTP = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28689 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRBouctoucheWWTP.TVItemID = tvItemBouctoucheWWTP.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRBouctoucheWWTP)) return await Task.FromResult(false);
//                #endregion TVItem Municipality Bouctouche WWTP 
//                #region ReportType and ReportTypeLanguage
//                Console.WriteLine($"doing ... ReportTypes and ReportTypeLanguages");
//                ReportType reportType = dbCSSPDB.ReportTypes.AsNoTracking().FirstOrDefault();
//                int ReportTypeIDOld = reportType.ReportTypeID;
//                reportType.ReportTypeID = 0;
//                if (!await AddObject("ReportType", reportType)) return await Task.FromResult(false);

//                //// ReportTypeLanguage EN 
//                //ReportTypeLanguage reportTypeLanguageEN = dbCSSPDB.ReportTypeLanguages.AsNoTracking().Where(c => c.ReportTypeID == ReportTypeIDOld && c.Language == LanguageEnum.en).FirstOrDefault();
//                //reportTypeLanguageEN.ReportTypeLanguageID = 0;
//                //reportTypeLanguageEN.ReportTypeID = reportType.ReportTypeID;
//                //if (!await AddObject("ReportTypeLanguage", reportTypeLanguageEN)) return await Task.FromResult(false);

//                //// ReportTypeLanguage FR 
//                //ReportTypeLanguage reportTypeLanguageFR = dbCSSPDB.ReportTypeLanguages.AsNoTracking().Where(c => c.ReportTypeID == ReportTypeIDOld && c.Language == LanguageEnum.fr).FirstOrDefault();
//                //reportTypeLanguageFR.ReportTypeLanguageID = 0;
//                //reportTypeLanguageFR.ReportTypeID = reportType.ReportTypeID;
//                //if (!await AddObject("ReportTypeLanguage", reportTypeLanguageFR)) return await Task.FromResult(false);
//                #endregion ReportType and ReportTypeLanguage
//                #region ReportSection and ReportSectionLanguage
//                Console.WriteLine($"doing ... ReportSections and ReportSectionLanguages");
//                ReportSection reportSection = dbCSSPDB.ReportSections.AsNoTracking().Where(c => c.ReportTypeID == ReportTypeIDOld).FirstOrDefault();
//                int ReportSectionIDOld = reportSection.ReportSectionID;
//                reportSection.ReportSectionID = 0;
//                reportSection.ReportTypeID = reportType.ReportTypeID;
//                if (!await AddObject("ReportSection", reportSection)) return await Task.FromResult(false);

//                //// ReportSectionLanguage EN 
//                //ReportSectionLanguage reportSectionLanguageEN = dbCSSPDB.ReportSectionLanguages.AsNoTracking().Where(c => c.ReportSectionID == ReportSectionIDOld && c.Language == LanguageEnum.en).FirstOrDefault();
//                //reportSectionLanguageEN.ReportSectionLanguageID = 0;
//                //reportSectionLanguageEN.ReportSectionID = reportSection.ReportSectionID;
//                //if (!await AddObject("ReportSectionLanguage", reportSectionLanguageEN)) return await Task.FromResult(false);

//                //// ReportSectionLanguage FR 
//                //ReportSectionLanguage reportSectionLanguageFR = dbCSSPDB.ReportSectionLanguages.AsNoTracking().Where(c => c.ReportSectionID == ReportSectionIDOld && c.Language == LanguageEnum.fr).FirstOrDefault();
//                //reportSectionLanguageFR.ReportSectionLanguageID = 0;
//                //reportSectionLanguageFR.ReportSectionID = reportSection.ReportSectionID;
//                //if (!await AddObject("ReportSectionLanguage", reportSectionLanguageFR)) return await Task.FromResult(false);
//                #endregion ReportSection and ReportSectionLanguage
//                #region TVItem TVFile Bouctouche WWTP 
//                Console.WriteLine($"doing ... Bouctouche WWTP TVFile");
//                // TVItem TVFile Bouctouche WWTP TVItemID = 28689
//                TVItem TempBouctWWTP = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 28689).FirstOrDefault();
//                TVItem tvItemBouctoucheWWTPTVFile = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVPath.StartsWith($"{ TempBouctWWTP.TVPath }p") && c.TVType == TVTypeEnum.File).FirstOrDefault();
//                int TempTVItemID = tvItemBouctoucheWWTPTVFile.TVItemID;
//                tvItemBouctoucheWWTPTVFile.ParentID = tvItemBouctoucheWWTP.TVItemID;
//                if (!await AddObject("TVItem", tvItemBouctoucheWWTPTVFile)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemBouctoucheWWTPTVFile, tvItemBouctoucheWWTP)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemBouctoucheWWTPTVFile, TempTVItemID, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // TVItemLanguage EN TVItem for Image for Bouctouche WWTP TVItemID = 28689
//                TVItemLanguage tvItemBouctoucheWWTPTVFileImageEN = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == TempTVItemID && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemBouctoucheWWTPTVFileImageEN.TVItemID = tvItemBouctoucheWWTPTVFile.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemBouctoucheWWTPTVFileImageEN)) return await Task.FromResult(false);

//                // TVItemLanguage FR TVItem for Image for Bouctouche WWTP TVItemID = 28689
//                TVItemLanguage tvItemBouctoucheWWTPTVFileImageFR = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == TempTVItemID && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemBouctoucheWWTPTVFileImageFR.TVItemID = tvItemBouctoucheWWTPTVFile.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemBouctoucheWWTPTVFileImageFR)) return await Task.FromResult(false);
//                #endregion TVItem TVFile Bouctouche WWTP 
//                #region TVFile Bouctouche WWTP 
//                Console.WriteLine($"doing ... Bouctouche WWTP TVFile");
//                // TVFile Bouctouche WWTP TVItemID = 28689
//                TVFile tvFileBouctoucheWWTP = dbCSSPDB.TVFiles.AsNoTracking().Where(c => c.TVFileTVItemID == TempTVItemID).FirstOrDefault();
//                int TVFileID = tvFileBouctoucheWWTP.TVFileID;
//                tvFileBouctoucheWWTP.TVFileTVItemID = tvItemBouctoucheWWTPTVFile.TVItemID;
//                if (!await AddObject("TVFile", tvFileBouctoucheWWTP)) return await Task.FromResult(false);

//                // TVFileLanguage EN Bouctouche WWTP TVItemID = 28689
//                TVFileLanguage tvFileLanguageENBouctoucheWWTP = dbCSSPDB.TVFileLanguages.AsNoTracking().Where(c => c.TVFileID == TVFileID && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvFileLanguageENBouctoucheWWTP.TVFileID = tvFileBouctoucheWWTP.TVFileID;
//                if (!await AddObject("TVFileLanguage", tvFileLanguageENBouctoucheWWTP)) return await Task.FromResult(false);

//                // TVFileLanguage FR Bouctouche WWTP TVItemID = 28689
//                TVFileLanguage tvFileLanguageFRBouctoucheWWTP = dbCSSPDB.TVFileLanguages.AsNoTracking().Where(c => c.TVFileID == TVFileID && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvFileLanguageFRBouctoucheWWTP.TVFileID = tvFileBouctoucheWWTP.TVFileID;
//                if (!await AddObject("TVFileLanguage", tvFileLanguageFRBouctoucheWWTP)) return await Task.FromResult(false);
//                #endregion TVFile Bouctouche WWTP 
//                #region Infrastructure Bouctouche WWTP
//                Console.WriteLine($"doing ... Bouctouche WWTP Infrastructure");
//                // Infrastructure Bouctouche WWTP TVItemID = 28689
//                Infrastructure infrastructureBouctoucheWWTP = dbCSSPDB.Infrastructures.AsNoTracking().Where(c => c.InfrastructureTVItemID == 28689).FirstOrDefault();
//                int InfrastructureID = infrastructureBouctoucheWWTP.InfrastructureID;
//                infrastructureBouctoucheWWTP.InfrastructureTVItemID = tvItemBouctoucheWWTP.TVItemID;
//                if (!await AddObject("Infrastructure", infrastructureBouctoucheWWTP)) return await Task.FromResult(false);

//                // InfrastructureLanguage EN Bouctouche WWTP TVItemID = 28689
//                InfrastructureLanguage infrastructureLanguageENBouctoucheWWTP = dbCSSPDB.InfrastructureLanguages.AsNoTracking().Where(c => c.InfrastructureID == InfrastructureID && c.Language == LanguageEnum.en).FirstOrDefault();
//                infrastructureLanguageENBouctoucheWWTP.InfrastructureID = infrastructureBouctoucheWWTP.InfrastructureID;
//                if (!await AddObject("InfrastructureLanguage", infrastructureLanguageENBouctoucheWWTP)) return await Task.FromResult(false);

//                // InfrastructureLanguage FR Bouctouche WWTP TVItemID = 28689
//                InfrastructureLanguage infrastructureLanguageFRBouctoucheWWTP = dbCSSPDB.InfrastructureLanguages.AsNoTracking().Where(c => c.InfrastructureID == InfrastructureID && c.Language == LanguageEnum.fr).FirstOrDefault();
//                infrastructureLanguageFRBouctoucheWWTP.InfrastructureID = infrastructureBouctoucheWWTP.InfrastructureID;
//                if (!await AddObject("InfrastructureLanguage", infrastructureLanguageFRBouctoucheWWTP)) return await Task.FromResult(false);
//                #endregion Infrastructure Bouctouche WWTP
//                #region BoxModel Bouctouche WWTP
//                Console.WriteLine($"doing ... Bouctouche WWTP Infrastructure Box Model");
//                // BoxModel Bouctouche WWTP TVItemID = 28689
//                BoxModel boxModel = dbCSSPDB.BoxModels.AsNoTracking().Where(c => c.InfrastructureTVItemID == 28689).FirstOrDefault();
//                int BoxModelID = boxModel.BoxModelID;
//                boxModel.InfrastructureTVItemID = tvItemBouctoucheWWTP.TVItemID;
//                if (!await AddObject("BoxModel", boxModel)) return await Task.FromResult(false);

//                // BoxModelLanguage EN Bouctouche WWTP TVItemID = 28689
//                BoxModelLanguage boxModelLanguageEN = dbCSSPDB.BoxModelLanguages.AsNoTracking().Where(c => c.BoxModelID == BoxModelID && c.Language == LanguageEnum.en).FirstOrDefault();
//                boxModelLanguageEN.BoxModelID = boxModel.BoxModelID;
//                if (!await AddObject("BoxModelLanguage", boxModelLanguageEN)) return await Task.FromResult(false);

//                // BoxModelLanguage FR Bouctouche WWTP TVItemID = 28689
//                BoxModelLanguage boxModelLanguageFR = dbCSSPDB.BoxModelLanguages.AsNoTracking().Where(c => c.BoxModelID == BoxModelID && c.Language == LanguageEnum.fr).FirstOrDefault();
//                boxModelLanguageFR.BoxModelID = boxModel.BoxModelID;
//                if (!await AddObject("BoxModelLanguage", boxModelLanguageFR)) return await Task.FromResult(false);
//                #endregion BoxModel Bouctouche WWTP
//                #region BoxModelResult Bouctouche WWTP
//                Console.WriteLine($"doing ... Bouctouche WWTP Infrastructure Box Model Result");

//                // BoxModelResult Bouctouche WWTP TVItemID = 28689
//                for (int i = 1; i < 6; i++)
//                {
//                    BoxModelResultTypeEnum boxModelResultTypeEnum = (BoxModelResultTypeEnum)i;
//                    BoxModelResult boxModelResult = dbCSSPDB.BoxModelResults.AsNoTracking().Where(c => c.BoxModelID == BoxModelID && c.BoxModelResultType == boxModelResultTypeEnum).FirstOrDefault();
//                    boxModelResult.BoxModelID = boxModel.BoxModelID;
//                    if (!await AddObject("BoxModelResult", boxModelResult)) return await Task.FromResult(false);
//                }
//                #endregion BoxModelResult Bouctouche WWTP
//                #region CoCoRaHSSite and CoCoRaHSValue
//                Console.WriteLine($"doing ... CoCoRaHSSite and CoCoRaHSValue");
//                List<CoCoRaHSSite> coCoRaHSSiteList = dbCSSPDB.CoCoRaHSSites.AsNoTracking().Take(10).ToList();
//                foreach (CoCoRaHSSite coCoRaHSSite in coCoRaHSSiteList)
//                {
//                    int CoCoRaHSSiteID = coCoRaHSSite.CoCoRaHSSiteID;

//                    if (!await AddObject("CoCoRaHSSite", coCoRaHSSite)) return await Task.FromResult(false);

//                    List<CoCoRaHSValue> coCoRaHSValueList = dbCSSPDB.CoCoRaHSValues.Where(c => c.CoCoRaHSSiteID == CoCoRaHSSiteID).AsNoTracking().Take(10).ToList();
//                    foreach (CoCoRaHSValue coCoRaHSValue in coCoRaHSValueList)
//                    {
//                        coCoRaHSValue.CoCoRaHSSiteID = coCoRaHSSite.CoCoRaHSSiteID;

//                        if (!await AddObject("CoCoRaHSValue", coCoRaHSValue)) return await Task.FromResult(false);
//                    }
//                }
//                #endregion CoCoRaHSSite and CoCoRaHSValue
//                #region VPScenario Bouctouche WWTP 
//                Console.WriteLine($"doing ... Bouctouche WWTP Infrastructure VPScenario");

//                // VPScenario Bouctouche WWTP TVItemID = 28689
//                VPScenario VPScenario = dbCSSPDB.VPScenarios.AsNoTracking().Where(c => c.InfrastructureTVItemID == 28689).FirstOrDefault();
//                int VPScenarioID = VPScenario.VPScenarioID;
//                VPScenario.InfrastructureTVItemID = tvItemBouctoucheWWTP.TVItemID;
//                if (!await AddObject("VPScenario", VPScenario)) return await Task.FromResult(false);

//                // VPScenarioLanguage EN Bouctouche WWTP TVItemID = 28689
//                VPScenarioLanguage VPScenarioLanguageEN = dbCSSPDB.VPScenarioLanguages.AsNoTracking().Where(c => c.VPScenarioID == VPScenarioID && c.Language == LanguageEnum.en).FirstOrDefault();
//                VPScenarioLanguageEN.VPScenarioID = VPScenario.VPScenarioID;
//                if (!await AddObject("VPScenarioLanguage", VPScenarioLanguageEN)) return await Task.FromResult(false);

//                // VPScenarioLanguage FR Bouctouche WWTP TVItemID = 28689
//                VPScenarioLanguage VPScenarioLanguageFR = dbCSSPDB.VPScenarioLanguages.AsNoTracking().Where(c => c.VPScenarioID == VPScenarioID && c.Language == LanguageEnum.fr).FirstOrDefault();
//                VPScenarioLanguageFR.VPScenarioID = VPScenario.VPScenarioID;
//                if (!await AddObject("VPScenarioLanguage", VPScenarioLanguageFR)) return await Task.FromResult(false);

//                // VPAmbient Bouctouche WWTP TVItemID = 28689
//                List<VPAmbient> VPAmbientList = dbCSSPDB.VPAmbients.AsNoTracking().Where(c => c.VPScenarioID == VPScenarioID).ToList();
//                foreach (VPAmbient vpAmbient in VPAmbientList)
//                {
//                    vpAmbient.VPScenarioID = VPScenario.VPScenarioID;
//                    if (!await AddObject("VPAmbient", vpAmbient)) return await Task.FromResult(false);
//                }

//                // VPAmbient Bouctouche WWTP TVItemID = 28689
//                List<VPResult> VPResultList = dbCSSPDB.VPResults.AsNoTracking().Where(c => c.VPScenarioID == VPScenarioID).Take(5).ToList();
//                foreach (VPResult vpResult in VPResultList)
//                {
//                    vpResult.VPScenarioID = VPScenario.VPScenarioID;
//                    if (!await AddObject("VPResult", vpResult)) return await Task.FromResult(false);
//                }
//                #endregion VPScenario Bouctouche WWTP 
//                #region TVItem Municipality Bouctouche LS 2 Rue Acadie
//                Console.WriteLine($"doing ... Bouctouche LS 2");

//                // TVItem Municipality Bouctouche LS 2 Rue Acadie TVItemID = 28695
//                TVItem tvItemBouctoucheLS2RueAcadie = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 28695).FirstOrDefault();
//                tvItemBouctoucheLS2RueAcadie.ParentID = tvItemCapPeleTideSite.TVItemID;
//                if (!await AddObject("TVItem", tvItemBouctoucheLS2RueAcadie)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemBouctoucheLS2RueAcadie, tvItemCapPeleTideSite)) return await Task.FromResult(false);
//                tvItemBouctoucheLS2RueAcadie.TVType = TVTypeEnum.LiftStation;
//                if (!await AddMapInfo(tvItemBouctoucheLS2RueAcadie, 28695, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);
//                tvItemBouctoucheLS2RueAcadie.TVType = TVTypeEnum.Infrastructure;

//                // TVItemLanguage EN Bouctouche LS 2 Rue Acadie TVItemID = 28695
//                TVItemLanguage tvItemLanguageENBouctoucheLS2RueAcadie = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28695 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENBouctoucheLS2RueAcadie.TVItemID = tvItemBouctoucheLS2RueAcadie.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENBouctoucheLS2RueAcadie)) return await Task.FromResult(false);

//                // TVItemLanguage FR Bouctouche LS 2 Rue Acadie TVItemID = 28695
//                TVItemLanguage tvItemLanguageFRBouctoucheLS2RueAcadie = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28695 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRBouctoucheLS2RueAcadie.TVItemID = tvItemBouctoucheLS2RueAcadie.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRBouctoucheLS2RueAcadie)) return await Task.FromResult(false);
//                #endregion TVItem Municipality Bouctouche LS 2 Rue Acadie
//                #region TVItem Subsector NB-06_020_002 MWQM Site 0001
//                Console.WriteLine($"doing ... Subsector NB-06-020-002 MWQM site 001");
//                // TVItem Subsector NB-06_020_002 MWQM Site 0001 TVItemID = 7460
//                TVItem tvItemNB_06_020_002Site0001 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 7460).FirstOrDefault();
//                int MWQMSiteID0001 = tvItemNB_06_020_002Site0001.TVItemID;
//                tvItemNB_06_020_002Site0001.ParentID = tvItemNB_06_020_002.TVItemID;
//                if (!await AddObject("TVItem", tvItemNB_06_020_002Site0001)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemNB_06_020_002Site0001, tvItemNB_06_020_002)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemNB_06_020_002Site0001, 7460, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // TVItemLanguage EN NB-06_020_001 TVItemID = 7460
//                TVItemLanguage tvItemLanguageENNB_06_020_002Site0001 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7460 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENNB_06_020_002Site0001.TVItemID = tvItemNB_06_020_002Site0001.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_002Site0001)) return await Task.FromResult(false);

//                // TVItemLanguage FR NB_06_020 TVItemID = 7460
//                TVItemLanguage tvItemLanguageFRNB_06_020_002Site0001 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7460 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRNB_06_020_002Site0001.TVItemID = tvItemNB_06_020_002Site0001.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_002Site0001)) return await Task.FromResult(false);
//                #endregion TVItem Subsector NB-06_020_002 MWQM Site 0001
//                #region TVItem Subsector NB-06_020_002 MWQM Site 0002
//                Console.WriteLine($"doing ... Subsector NB-06-020-002 MWQM site 002");
//                // TVItem Subsector NB-06_020_002 MWQM Site 0001 TVItemID = 7462
//                TVItem tvItemNB_06_020_002Site0002 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 7462).FirstOrDefault();
//                int MWQMSiteID0002 = tvItemNB_06_020_002Site0002.TVItemID;
//                tvItemNB_06_020_002Site0002.ParentID = tvItemNB_06_020_002.TVItemID;
//                if (!await AddObject("TVItem", tvItemNB_06_020_002Site0002)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemNB_06_020_002Site0002, tvItemNB_06_020_002)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemNB_06_020_002Site0002, 7462, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // TVItemLanguage EN NB-06_020_001 TVItemID = 7462
//                TVItemLanguage tvItemLanguageENNB_06_020_002Site0002 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7462 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENNB_06_020_002Site0002.TVItemID = tvItemNB_06_020_002Site0002.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_002Site0002)) return await Task.FromResult(false);

//                // TVItemLanguage FR NB_06_020 TVItemID = 7462
//                TVItemLanguage tvItemLanguageFRNB_06_020_002Site0002 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7462 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRNB_06_020_002Site0002.TVItemID = tvItemNB_06_020_002Site0002.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_002Site0002)) return await Task.FromResult(false);
//                #endregion TVItem Subsector NB-06_020_002 MWQM Site 0002
//                #region TVItem Address and Address
//                Console.WriteLine($"doing ... Address");
//                // TVItem Address 730 Chemin de la Pointe, Richibouctou, NB E4W, Canada TVItemID = 232655
//                TVItem tvItemAddress = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 232655).FirstOrDefault();
//                tvItemAddress.ParentID = tvItemRoot.TVItemID;
//                if (!await AddObject("TVItem", tvItemAddress)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemAddress, tvItemRoot)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemAddress, 232655, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // Address 730 Chemin de la Pointe, Richibouctou, NB E4W, Canada TVItemID = 232655
//                Address address = dbCSSPDB.Addresses.AsNoTracking().Where(c => c.AddressTVItemID == 232655).FirstOrDefault();
//                address.AddressTVItemID = tvItemAddress.TVItemID;
//                address.CountryTVItemID = tvItemCanada.TVItemID;
//                address.ProvinceTVItemID = tvItemNB.TVItemID;
//                address.MunicipalityTVItemID = tvItemBouctouche.TVItemID;
//                if (!await AddObject("Address", address)) return await Task.FromResult(false);

//                //string TVText = "";
//                //using (CSSPDBContext db2 = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
//                //{
//                //    AddressService addressService = new AddressService(new Query(), db2, contactCharles.ContactID);
//                //    TVText = addressService.FillAddressTVText(address);
//                //}

//                // TVItem Address 730 Chemin de la Pointe, Richibouctou, NB E4W, Canada TVItemID = 232655
//                TVItemLanguage tvItemLanguageENAddress = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 232655 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENAddress.TVItemID = tvItemAddress.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENAddress)) return await Task.FromResult(false);

//                // TVItem Address 730 Chemin de la Pointe, Richibouctou, NB E4W, Canada TVItemID = 232655
//                TVItemLanguage tvItemLanguageFRAddress = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 232655 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRAddress.TVItemID = tvItemAddress.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRAddress)) return await Task.FromResult(false);
//                #endregion TVItem Address and Address
//                #region TVItem Subsector NB-06_020_002 Pol Source Site 000023
//                Console.WriteLine($"doing ... Subsector NB-06-020-002 PolSource site 00023");
//                // TVItem Subsector NB-06_020_002 Pol Source Site 000023 TVItemID = 202466
//                TVItem tvItemNB_06_020_002PolSite000023 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 202466).FirstOrDefault();
//                tvItemNB_06_020_002PolSite000023.ParentID = tvItemNB_06_020_002.TVItemID;
//                if (!await AddObject("TVItem", tvItemNB_06_020_002PolSite000023)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemNB_06_020_002PolSite000023, tvItemNB_06_020_002)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemNB_06_020_002PolSite000023, 202466, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // TVItemLanguage EN Subsector NB-06_020_002 Pol Source Site 000023 TVItemID = 202466
//                TVItemLanguage tvItemLanguageENNB_06_020_002PolSite000023 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 202466 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENNB_06_020_002PolSite000023.TVItemID = tvItemNB_06_020_002PolSite000023.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_002PolSite000023)) return await Task.FromResult(false);

//                // TVItemLanguage FR Subsector NB-06_020_002 Pol Source Site 000023 TVItemID = 202466
//                TVItemLanguage tvItemLanguageFRNB_06_020_002PolSite000023 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 202466 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRNB_06_020_002PolSite000023.TVItemID = tvItemNB_06_020_002PolSite000023.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_002PolSite000023)) return await Task.FromResult(false);
//                #endregion TVItem Subsector NB-06_020_002 Pol Source Site 000023
//                #region PolSourceSite, PolSourceObservation, PolSourceObservationIssue Subsector NB-06_020_002 Pol Source Site 000023
//                Console.WriteLine($"doing ... Subsector NB-06-020-002 PolSource site 00023 Observation");
//                // PolSourceSite with PolSourceSiteTVItemID = 202466
//                PolSourceSite polSourceSitePolSite000023 = dbCSSPDB.PolSourceSites.AsNoTracking().Where(c => c.PolSourceSiteTVItemID == 202466).FirstOrDefault();
//                int PolSourceSiteID = polSourceSitePolSite000023.PolSourceSiteID;
//                polSourceSitePolSite000023.PolSourceSiteTVItemID = tvItemNB_06_020_002PolSite000023.TVItemID;
//                if (polSourceSitePolSite000023.CivicAddressTVItemID != null)
//                {
//                    polSourceSitePolSite000023.CivicAddressTVItemID = tvItemAddress.TVItemID;
//                }
//                if (!await AddObject("PolSourceSite", polSourceSitePolSite000023)) return await Task.FromResult(false);

//                // PolSourceObservation with PolSourceSiteTVItemID = 202466
//                PolSourceObservation polSourceSitePolSite000023Obs = dbCSSPDB.PolSourceObservations.AsNoTracking().Where(c => c.PolSourceSiteID == PolSourceSiteID).FirstOrDefault();
//                int PolSourceObservationID = polSourceSitePolSite000023Obs.PolSourceObservationID;
//                polSourceSitePolSite000023Obs.ContactTVItemID = contactCharles.ContactTVItemID;
//                polSourceSitePolSite000023Obs.PolSourceSiteID = polSourceSitePolSite000023.PolSourceSiteID;
//                if (!await AddObject("PolSourceObservation", polSourceSitePolSite000023Obs)) return await Task.FromResult(false);

//                // PolSourceObservationIssue with PolSourceSiteTVItemID = 202466
//                PolSourceObservationIssue polSourceSitePolSite000023ObsIssue = dbCSSPDB.PolSourceObservationIssues.AsNoTracking().Where(c => c.PolSourceObservationID == PolSourceObservationID).FirstOrDefault();
//                int PolSourceObservationIssueID = polSourceSitePolSite000023ObsIssue.PolSourceObservationIssueID;
//                polSourceSitePolSite000023ObsIssue.PolSourceObservationID = polSourceSitePolSite000023Obs.PolSourceSiteID;
//                if (!await AddObject("PolSourceObservationIssue", polSourceSitePolSite000023ObsIssue)) return await Task.FromResult(false);
//                #endregion PolSourceSite, PolSourceObservation, PolSourceObservationIssue Subsector NB-06_020_002 Pol Source Site 000023
//                #region PolSourceSite, PolSourceObservation, PolSourceObservationIssue Subsector NB-06_020_002 Pol Source Site 000024
//                Console.WriteLine($"doing ... Subsector NB-06-020-002 PolSource site 00024");
//                // TVItem Subsector NB-06_020_002 Pol Source Site 000024 TVItemID = 202467
//                TVItem tvItemNB_06_020_002PolSite000024 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 202467).FirstOrDefault();
//                tvItemNB_06_020_002PolSite000024.ParentID = tvItemNB_06_020_002.TVItemID;
//                if (!await AddObject("TVItem", tvItemNB_06_020_002PolSite000024)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemNB_06_020_002PolSite000024, tvItemNB_06_020_002)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemNB_06_020_002PolSite000024, 202467, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // TVItemLanguage EN NB-06_020_001 TVItemID = 202467
//                TVItemLanguage tvItemLanguageENNB_06_020_00PolSite000024 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 202467 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENNB_06_020_00PolSite000024.TVItemID = tvItemNB_06_020_002PolSite000024.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_00PolSite000024)) return await Task.FromResult(false);

//                // TVItemLanguage FR NB_06_020 TVItemID = 202467
//                TVItemLanguage tvItemLanguageFRNB_06_020_002PolSite000024 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 202467 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRNB_06_020_002PolSite000024.TVItemID = tvItemNB_06_020_002PolSite000024.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_002PolSite000024)) return await Task.FromResult(false);
//                #endregion PolSourceSite, PolSourceObservation, PolSourceObservationIssue Subsector NB-06_020_002 Pol Source Site 000024
//                #region DrogueRun, DrogueRunPositon Subsector NB-06_020_002
//                Console.WriteLine($"doing ... Subsector NB-06-020-002 DrogueRun");
//                DrogueRun drogueRun = dbCSSPDB.DrogueRuns.AsNoTracking().FirstOrDefault();
//                int DrogueRunID = drogueRun.DrogueRunID;
//                drogueRun.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
//                if (!await AddObject("DrogueRun", drogueRun)) return await Task.FromResult(false);

//                // DrogueRunPosition
//                List<DrogueRunPosition> drogueRunPositionList = dbCSSPDB.DrogueRunPositions.AsNoTracking().Where(c => c.DrogueRunID == DrogueRunID).ToList();
//                foreach (DrogueRunPosition drogueRunPosition in drogueRunPositionList.Take(10))
//                {
//                    int DrogueRunPositionID = drogueRunPosition.DrogueRunPositionID;
//                    drogueRunPosition.DrogueRunID = drogueRun.DrogueRunID;
//                    if (!await AddObject("DrogueRunPosition", drogueRunPosition)) return await Task.FromResult(false);
//                }
//                #endregion DrogueRun, DrogueRunPositon Subsector NB-06_020_002
//                #region HelpDoc
//                Console.WriteLine($"doing ... HelpDoc");
//                HelpDoc helpDoc = dbCSSPDB.HelpDocs.AsNoTracking().FirstOrDefault();
//                int HelpDocID = helpDoc.HelpDocID;
//                if (!await AddObject("HelpDoc", helpDoc)) return await Task.FromResult(false);
//                #endregion HelpDoc
//                #region TVItem SamplingPlan, SamplingPlanSubsector, SamplingPlanSubsectorSite, SamplingPlanEmail
//                Console.WriteLine($"doing ... Sampling Plan");
//                // NB TVItem Sampling Plan with SamplingPlanID = 78 and TVFileTVItemID = 370708
//                TVItem tvItemNBSamplingPlanFileTVItem = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 370708).FirstOrDefault();
//                tvItemNBSamplingPlanFileTVItem.ParentID = tvItemNB.TVItemID;
//                if (!await AddObject("TVItem", tvItemNBSamplingPlanFileTVItem)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemNBSamplingPlanFileTVItem, tvItemNB)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemNBSamplingPlanFileTVItem, 370708, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // NB EN TVItem Sampling Plan with SamplingPlanID = 78 and TVFileTVItemID = 370708
//                TVItemLanguage tvItemLanguageENNBSamplingPlanFileTVItem = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 370708 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENNBSamplingPlanFileTVItem.TVItemID = tvItemNBSamplingPlanFileTVItem.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENNBSamplingPlanFileTVItem)) return await Task.FromResult(false);

//                // NB FR TVItem Sampling Plan with SamplingPlanID = 78 and TVFileTVItemID = 370708
//                TVItemLanguage tvItemLanguageFRNBSamplingPlanFileTVItem = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 370708 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRNBSamplingPlanFileTVItem.TVItemID = tvItemNBSamplingPlanFileTVItem.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNBSamplingPlanFileTVItem)) return await Task.FromResult(false);

//                // NB TVFile Sampling Plan with SamplingPlanID = 78 and TVFileTVItemID = 370708
//                TVFile tvFile = dbCSSPDB.TVFiles.AsNoTracking().Where(c => c.TVFileTVItemID == 370708).FirstOrDefault();
//                //int TVFileID = tvFile.TVFileID;
//                tvFile.TVFileTVItemID = tvItemNBSamplingPlanFileTVItem.TVItemID;
//                if (!await AddObject("TVFile", tvFile)) return await Task.FromResult(false);

//                // NB Sampling Plan with SamplingPlanID = 78
//                SamplingPlan samplingPlan = dbCSSPDB.SamplingPlans.AsNoTracking().Where(c => c.SamplingPlanID == 78).FirstOrDefault();
//                int SamplingPlanID = samplingPlan.SamplingPlanID;
//                samplingPlan.CreatorTVItemID = tvItemContactCharles.TVItemID;
//                samplingPlan.ProvinceTVItemID = tvItemNB.TVItemID;
//                samplingPlan.SamplingPlanFileTVItemID = tvFile.TVFileTVItemID;
//                samplingPlan.ApprovalCode = "aaabbb";
//                if (!await AddObject("SamplingPlan", samplingPlan)) return await Task.FromResult(false);

//                // NB Sampling Plan with SamplingPlanID = 78 with SubsectorTVItemID = 635 (Bouctouche harbour)
//                SamplingPlanSubsector samplingPlanSubsector = dbCSSPDB.SamplingPlanSubsectors.AsNoTracking().Where(c => c.SamplingPlanID == 78 && c.SubsectorTVItemID == 560).FirstOrDefault();
//                int SamplingPlanSubsectorID = samplingPlanSubsector.SamplingPlanSubsectorID;
//                samplingPlanSubsector.SamplingPlanID = samplingPlan.SamplingPlanID;
//                samplingPlanSubsector.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
//                if (!await AddObject("SamplingPlanSubsector", samplingPlanSubsector)) return await Task.FromResult(false);

//                // NB Sampling Plan with SamplingPlanID = 78 with SubsectorTVItemID = 635 (Bouctouche harbour)
//                SamplingPlanSubsectorSite samplingPlanSubsectorSite0001 = dbCSSPDB.SamplingPlanSubsectorSites.AsNoTracking().Where(c => c.SamplingPlanSubsectorID == SamplingPlanSubsectorID && c.MWQMSiteTVItemID == 7153).FirstOrDefault();
//                samplingPlanSubsectorSite0001.SamplingPlanSubsectorID = samplingPlanSubsector.SamplingPlanSubsectorID;
//                samplingPlanSubsectorSite0001.MWQMSiteTVItemID = tvItemNB_06_020_002Site0001.TVItemID;
//                if (!await AddObject("SamplingPlanSubsectorSite", samplingPlanSubsectorSite0001)) return await Task.FromResult(false);

//                // NB Sampling Plan with SamplingPlanID = 78 with SubsectorTVItemID = 635 (Bouctouche harbour)
//                SamplingPlanSubsectorSite samplingPlanSubsectorSite0002 = dbCSSPDB.SamplingPlanSubsectorSites.AsNoTracking().Where(c => c.SamplingPlanSubsectorID == SamplingPlanSubsectorID && c.MWQMSiteTVItemID == 7156).FirstOrDefault();
//                samplingPlanSubsectorSite0002.SamplingPlanSubsectorID = samplingPlanSubsector.SamplingPlanSubsectorID;
//                samplingPlanSubsectorSite0002.MWQMSiteTVItemID = tvItemNB_06_020_002Site0002.TVItemID;
//                if (!await AddObject("SamplingPlanSubsectorSite", samplingPlanSubsectorSite0002)) return await Task.FromResult(false);

//                // NB Sampling Plan Email with SamplingPlanID = 78
//                SamplingPlanEmail samplingPlanEmail = dbCSSPDB.SamplingPlanEmails.AsNoTracking().Where(c => c.SamplingPlanID == SamplingPlanID).FirstOrDefault();
//                samplingPlanEmail.SamplingPlanID = samplingPlan.SamplingPlanID;
//                if (!await AddObject("SamplingPlanEmail", samplingPlanEmail)) return await Task.FromResult(false);
//                #endregion TVItem SamplingPlan, SamplingPlanSubsector, SamplingPlanSubsectorSite, SamplingPlanEmail
//                #region TVItem MWQMRun with Subsector NB-06_020_002 and MWQMSite 0001
//                Console.WriteLine($"doing ... MWQM Run");
//                // TVItem MWQMRun with Subsector NB-06_020_002 TVItemID = 635 MWQMSite 0001 TVItemID = 7460 MWQMRunTVItemID = 324152
//                TVItem tvItemRun = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 324152).FirstOrDefault();
//                tvItemRun.ParentID = tvItemNB_06_020_002.TVItemID;
//                if (!await AddObject("TVItem", tvItemRun)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemRun, tvItemNB_06_020_002)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemRun, 324152, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // TVItemLanguage EN MWQMRun with MWQMRunTVItemID = 324152
//                TVItemLanguage tvItemLanguageENMWQMRun = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 324152 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENMWQMRun.TVItemID = tvItemRun.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENMWQMRun)) return await Task.FromResult(false);

//                // TVItemLanguage FR NB_06_020 TVItemID = 324152
//                TVItemLanguage tvItemLanguageFRMWQMRun = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 324152 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRMWQMRun.TVItemID = tvItemRun.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRMWQMRun)) return await Task.FromResult(false);

//                // TVItem MWQMRun with Subsector NB-06_020_002 TVItemID = 635 MWQMSite 0001 TVItemID = 7460 MWQMRunTVItemID = 324152
//                MWQMRun mwqmRun = dbCSSPDB.MWQMRuns.AsNoTracking().Where(c => c.MWQMRunTVItemID == 324152).FirstOrDefault();
//                int MWQMRunID = mwqmRun.MWQMRunID;
//                mwqmRun.MWQMRunTVItemID = tvItemRun.TVItemID;
//                mwqmRun.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
//                mwqmRun.LabSampleApprovalContactTVItemID = tvItemContactCharles.TVItemID;
//                if (!await AddObject("MWQMRun", mwqmRun)) return await Task.FromResult(false);

//                // MWQMRunLanguage EN MWQMRun with MWQMRunTVItemID = 324152
//                MWQMRunLanguage MWQMRunLanguageEN = dbCSSPDB.MWQMRunLanguages.AsNoTracking().Where(c => c.MWQMRunID == MWQMRunID && c.Language == LanguageEnum.en).FirstOrDefault();
//                MWQMRunLanguageEN.MWQMRunID = mwqmRun.MWQMRunID;
//                if (!await AddObject("MWQMRunLanguage", MWQMRunLanguageEN)) return await Task.FromResult(false);

//                // MWQMRunLanguage FR MWQMRun with MWQMRunTVItemID = 324152
//                MWQMRunLanguage MWQMRunLanguageFR = dbCSSPDB.MWQMRunLanguages.AsNoTracking().Where(c => c.MWQMRunID == MWQMRunID && c.Language == LanguageEnum.en).FirstOrDefault();
//                MWQMRunLanguageFR.MWQMRunID = mwqmRun.MWQMRunID;
//                if (!await AddObject("MWQMRunLanguage", MWQMRunLanguageFR)) return await Task.FromResult(false);
//                #endregion TVItem MWQMRun with Subsector NB-06_020_002 and MWQMSite 0001
//                #region UseOfSite
//                Console.WriteLine($"doing ... UseOfSite");
//                // NB UseOfSite with SubsectorTVItemID = 635 ClimateSiteTVItemID = 229528
//                UseOfSite useOfSite = dbCSSPDB.UseOfSites.AsNoTracking().Where(c => c.SubsectorTVItemID == 635 && c.SiteTVItemID == 229528).FirstOrDefault();
//                useOfSite.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
//                useOfSite.SiteTVItemID = tvItemNBClimateSiteBouctoucheCDA.TVItemID;
//                if (!await AddObject("UseOfSite", useOfSite)) return await Task.FromResult(false);

//                // NB UseOfSite with SubsectorTVItemID = 635 TideSiteTVItemID = 1553
//                //useOfSite = dbCSSPDB.UseOfSites.AsNoTracking().Where(c => c.SubsectorTVItemID == 635 && c.SiteTVItemID == 1553).FirstOrDefault();
//                //useOfSite.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
//                //useOfSite.SiteTVItemID = tideSite.TideSiteTVItemID;
//                //if (!await AddObject("UseOfSite", useOfSite)) return await Task.FromResult(false);
//                #endregion UseOfSite
//                #region MWQMSamples
//                Console.WriteLine($"doing ... MWQMSamples");
//                // NB MWQMSamples with MWQMSiteTVItemID = 7460 and MWQMRunTVItemID = 324152
//                MWQMSample mwqmSample = dbCSSPDB.MWQMSamples.AsNoTracking().Where(c => c.MWQMSiteTVItemID == 7460 && c.MWQMRunTVItemID == 324152).FirstOrDefault();
//                int MWQMSampleID = mwqmSample.MWQMSampleID;
//                mwqmSample.MWQMSiteTVItemID = tvItemNB_06_020_002Site0001.TVItemID;
//                mwqmSample.MWQMRunTVItemID = tvItemRun.TVItemID;
//                if (!await AddObject("MWQMSample", mwqmSample)) return await Task.FromResult(false);

//                // NB MWQMSampleLanguages EN with MWQMSiteTVItemID = 7460 and MWQMRunTVItemID = 324152
//                MWQMSampleLanguage mwqmSampleLanguageEN = dbCSSPDB.MWQMSampleLanguages.AsNoTracking().Where(c => c.MWQMSampleID == MWQMSampleID && c.Language == LanguageEnum.en).FirstOrDefault();
//                mwqmSampleLanguageEN.MWQMSampleID = mwqmSample.MWQMSampleID;
//                if (!await AddObject("MWQMSampleLanguage", mwqmSampleLanguageEN)) return await Task.FromResult(false);

//                // NB MWQMSampleLanguages FR with MWQMSiteTVItemID = 7460 and MWQMRunTVItemID = 324152
//                MWQMSampleLanguage mwqmSampleLanguageFR = dbCSSPDB.MWQMSampleLanguages.AsNoTracking().Where(c => c.MWQMSampleID == MWQMSampleID && c.Language == LanguageEnum.fr).FirstOrDefault();
//                mwqmSampleLanguageFR.MWQMSampleID = mwqmSample.MWQMSampleID;
//                if (!await AddObject("MWQMSampleLanguage", mwqmSampleLanguageFR)) return await Task.FromResult(false);
//                #endregion MWQMSamples
//                #region MWQMSite, MWQMSiteStartEndDate
//                Console.WriteLine($"doing ... MWQMSite and MWQMSiteStartEndDate");
//                // NB MWQMSite with MWQMSiteTVItemID = 7460
//                MWQMSite mwqmSite0001 = dbCSSPDB.MWQMSites.AsNoTracking().Where(c => c.MWQMSiteTVItemID == 7460).FirstOrDefault();
//                mwqmSite0001.MWQMSiteTVItemID = tvItemNB_06_020_002Site0001.TVItemID;
//                if (!await AddObject("MWQMSite", mwqmSite0001)) return await Task.FromResult(false);

//                // MWQMSiteStartEndDate with MWQMSiteTVItemID = 7460
//                MWQMSiteStartEndDate mwqmSiteStartEndDate0001 = dbCSSPDB.MWQMSiteStartEndDates.AsNoTracking().Where(c => c.MWQMSiteTVItemID == MWQMSiteID0001).FirstOrDefault();
//                mwqmSiteStartEndDate0001.MWQMSiteTVItemID = tvItemNB_06_020_002Site0001.TVItemID;
//                if (!await AddObject("MWQMSiteStartEndDate", mwqmSiteStartEndDate0001)) return await Task.FromResult(false);

//                // NB MWQMSite with MWQMSiteTVItemID = 7462
//                MWQMSite mwqmSite0002 = dbCSSPDB.MWQMSites.AsNoTracking().Where(c => c.MWQMSiteTVItemID == 7462).FirstOrDefault();
//                mwqmSite0002.MWQMSiteTVItemID = tvItemNB_06_020_002Site0002.TVItemID;
//                if (!await AddObject("MWQMSite", mwqmSite0002)) return await Task.FromResult(false);

//                // MWQMSiteStartEndDate with MWQMSiteTVItemID = 7462
//                MWQMSiteStartEndDate mwqmSiteStartEndDate0002 = dbCSSPDB.MWQMSiteStartEndDates.AsNoTracking().Where(c => c.MWQMSiteTVItemID == MWQMSiteID0001).FirstOrDefault();
//                mwqmSiteStartEndDate0002.MWQMSiteTVItemID = tvItemNB_06_020_002Site0002.TVItemID;
//                if (!await AddObject("MWQMSiteStartEndDate", mwqmSiteStartEndDate0002)) return await Task.FromResult(false);
//                #endregion MWQMSite, MWQMSiteStartEndDate
//                #region MikeScenario, MikeScenarioResult, MikeBoundaryCondition, MikeSource, MikeSourceStartEnd
//                Console.WriteLine($"doing ... MikeScenario, MikeBoundaryCondition, MikeSource, MikeSourceStartEnd");
//                // TVItem MikeScenario with MikeScenairoTVItemID = 28475 under Bouctouche
//                TVItem tvItemMikeScenario = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 28475).FirstOrDefault();
//                int MikeScenarioTVItemID = tvItemMikeScenario.TVItemID;
//                tvItemMikeScenario.ParentID = tvItemBouctouche.TVItemID;
//                if (!await AddObject("TVItem", tvItemMikeScenario)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemMikeScenario, tvItemBouctouche)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemMikeScenario, 28475, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // TVItem MikeScenario with MikeScenairoTVItemID = 28475 under Bouctouche
//                TVItemLanguage tvItemLanguageENMikeScenario = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28475 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENMikeScenario.TVItemID = tvItemMikeScenario.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENMikeScenario)) return await Task.FromResult(false);

//                // TVItem MikeScenario with MikeScenairoTVItemID = 28475 under Bouctouche
//                TVItemLanguage tvItemLanguageFRMikeScenario = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28475 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRMikeScenario.TVItemID = tvItemMikeScenario.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRMikeScenario)) return await Task.FromResult(false);

//                // MikeScenario with MikeScenairoTVItemID = 28475 under Bouctouche
//                MikeScenario mikeScenario = dbCSSPDB.MikeScenarios.AsNoTracking().Where(c => c.MikeScenarioTVItemID == 28475).FirstOrDefault();
//                int MikeScenarioID = mikeScenario.MikeScenarioID;
//                mikeScenario.MikeScenarioTVItemID = tvItemMikeScenario.TVItemID;
//                if (!await AddObject("MikeScenario", mikeScenario)) return await Task.FromResult(false);

//                // MikeScenarioResult with MikeScenairoTVItemID = 357139 under Bouctouche
//                MikeScenarioResult mikeScenarioResult = dbCSSPDB.MikeScenarioResults.AsNoTracking().Where(c => c.MikeScenarioTVItemID == 357139).FirstOrDefault();
//                int MikeScenarioResultID = mikeScenarioResult.MikeScenarioResultID;
//                mikeScenarioResult.MikeScenarioTVItemID = tvItemMikeScenario.TVItemID;
//                if (!await AddObject("MikeScenarioResult", mikeScenarioResult)) return await Task.FromResult(false);

//                // TVItem MikeBoundaryCondition with MikeBoundaryConditionTVItemID = 92456 under Bouctouche
//                TVItem tvItemMikeBoundaryCondition = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 92456).FirstOrDefault();
//                tvItemMikeBoundaryCondition.ParentID = tvItemMikeScenario.TVItemID;
//                if (!await AddObject("TVItem", tvItemMikeBoundaryCondition)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemMikeBoundaryCondition, tvItemMikeScenario)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemMikeBoundaryCondition, 92456, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // TVItem MikeBoundaryCondition with MikeBoundaryConditionTVItemID = 92456 under Bouctouche
//                TVItemLanguage tvItemLanguageENMikeBoundaryCondition = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 92456 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENMikeBoundaryCondition.TVItemID = tvItemMikeBoundaryCondition.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENMikeBoundaryCondition)) return await Task.FromResult(false);

//                // TVItem MikeBoundaryCondition with MikeBoundaryConditionTVItemID = 92456 under Bouctouche
//                TVItemLanguage tvItemLanguageFRMikeBoundaryCondition = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 92456 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRMikeBoundaryCondition.TVItemID = tvItemMikeBoundaryCondition.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRMikeBoundaryCondition)) return await Task.FromResult(false);

//                // MikeBoundaryCondition with MikeBoundaryConditionTVItemID = 92456 under Bouctouche
//                MikeBoundaryCondition mikeBoundaryCondition = dbCSSPDB.MikeBoundaryConditions.AsNoTracking().Where(c => c.MikeBoundaryConditionTVItemID == 92456).FirstOrDefault();
//                mikeBoundaryCondition.MikeBoundaryConditionTVItemID = tvItemMikeBoundaryCondition.TVItemID;
//                mikeBoundaryCondition.WebTideDataFromStartToEndDate = "some text";
//                if (!await AddObject("MikeBoundaryCondition", mikeBoundaryCondition)) return await Task.FromResult(false);

//                // TVItem MikeSource with MikeSourceTVItemID = 28476 under Bouctouche WWTP
//                TVItem tvItemMikeSource = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 28476).FirstOrDefault();
//                tvItemMikeSource.ParentID = tvItemMikeScenario.TVItemID;
//                if (!await AddObject("TVItem", tvItemMikeSource)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemMikeSource, tvItemMikeScenario)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemMikeSource, 28476, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // TVItem MikeSource with MikeSourceTVItemID = 28476 under Bouctouche
//                TVItemLanguage tvItemLanguageENMikeSource = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28476 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENMikeSource.TVItemID = tvItemMikeSource.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENMikeSource)) return await Task.FromResult(false);

//                // TVItem MikeSource with MikeSourceTVItemID = 28476 under Bouctouche
//                TVItemLanguage tvItemLanguageFRMikeSource = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28476 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRMikeSource.TVItemID = tvItemMikeSource.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRMikeSource)) return await Task.FromResult(false);

//                // MikeSource with MikeSourceTVItemID = 28476 under Bouctouche
//                MikeSource mikeSource = dbCSSPDB.MikeSources.AsNoTracking().Where(c => c.MikeSourceTVItemID == 28476).FirstOrDefault();
//                int MikeSourceID = mikeSource.MikeSourceID;
//                mikeSource.MikeSourceTVItemID = tvItemMikeSource.TVItemID;
//                if (!await AddObject("MikeSource", mikeSource)) return await Task.FromResult(false);

//                // MikeSourceStartEnd with MikeSourceTVItemID = 28476 under Bouctouche
//                MikeSourceStartEnd mikeSourceStartEnd = dbCSSPDB.MikeSourceStartEnds.AsNoTracking().Where(c => c.MikeSourceID == MikeSourceID).FirstOrDefault();
//                mikeSourceStartEnd.MikeSourceID = mikeSource.MikeSourceID;
//                if (!await AddObject("MikeSourceStartEnd", mikeSourceStartEnd)) return await Task.FromResult(false);
//                #endregion MikeScenario, MikeBoundaryCondition, MikeSource, MikeSourceStartEnd
//                #region LabSheet, LabSheetDetail, LabSheetTubeMPNDetail
//                Console.WriteLine($"doing ... LabSheet, LabSheetDetail, LabSheetTubeMPNDetail");
//                // LabSheet with SubsectorTVItemID = 635 and MWQMRunTVItemID = 324152 under Bouctouche harbour subsector
//                LabSheet labSheet = dbCSSPDB.LabSheets.AsNoTracking().Where(c => c.SubsectorTVItemID == 635 && c.MWQMRunTVItemID == 324152).FirstOrDefault();
//                int LabSheetID = labSheet.LabSheetID;
//                labSheet.MWQMRunTVItemID = tvItemRun.TVItemID;
//                labSheet.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
//                labSheet.AcceptedOrRejectedByContactTVItemID = tvItemContactCharles.TVItemID;
//                labSheet.SamplingPlanID = samplingPlan.SamplingPlanID;
//                if (!await AddObject("LabSheet", labSheet)) return await Task.FromResult(false);

//                // LabSheetDetail with SubsectorTVItemID = 635 and MWQMRunTVItemID = 324152 under Bouctouche harbour subsector
//                LabSheetDetail labSheetDetail = dbCSSPDB.LabSheetDetails.AsNoTracking().Where(c => c.LabSheetID == LabSheetID).FirstOrDefault();
//                int LabSheetDetailID = labSheetDetail.LabSheetDetailID;
//                labSheetDetail.LabSheetID = labSheet.LabSheetID;
//                labSheetDetail.SamplingPlanID = samplingPlan.SamplingPlanID;
//                labSheetDetail.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
//                if (!await AddObject("LabSheetDetail", labSheetDetail)) return await Task.FromResult(false);

//                // LabSheetTubeMPNDetail with SubsectorTVItemID = 635 and MWQMRunTVItemID = 324152 and MWQMSiteTVItemID = 7460 under Bouctouche harbour subsector
//                LabSheetTubeMPNDetail labSheetTubeMPNDetail = dbCSSPDB.LabSheetTubeMPNDetails.AsNoTracking().Where(c => c.LabSheetDetailID == LabSheetDetailID && c.MWQMSiteTVItemID == 7460).FirstOrDefault();
//                labSheetTubeMPNDetail.LabSheetDetailID = labSheetDetail.LabSheetDetailID;
//                labSheetTubeMPNDetail.MWQMSiteTVItemID = tvItemNB_06_020_002Site0001.TVItemID;
//                if (!await AddObject("LabSheetTubeMPNDetail", labSheetTubeMPNDetail)) return await Task.FromResult(false);
//                #endregion LabSheet, LabSheetDetail, LabSheetTubeMPNDetail
//                #region TVItem Email and Email
//                Console.WriteLine($"doing ... Email");

//                // Email Charles.LeBlanc@ec.gc.ca TVItemID = 110249
//                TVItem tvItemEmail = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 110249).FirstOrDefault();
//                tvItemEmail.ParentID = tvItemRoot.TVItemID;
//                if (!await AddObject("TVItem", tvItemEmail)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemEmail, tvItemRoot)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemEmail, 110249, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // Email Charles.LeBlanc@ec.gc.ca TVItemID = 110249
//                TVItemLanguage tvItemLanguageENEmail = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 110249 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENEmail.TVItemID = tvItemEmail.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENEmail)) return await Task.FromResult(false);

//                // Email Charles.LeBlanc@ec.gc.ca TVItemID = 110249
//                TVItemLanguage tvItemLanguageFREmail = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 110249 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFREmail.TVItemID = tvItemEmail.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFREmail)) return await Task.FromResult(false);

//                // Email Charles.LeBlanc@ec.gc.ca TVItemID = 110249
//                Email email = dbCSSPDB.Emails.AsNoTracking().Where(c => c.EmailTVItemID == 110249).FirstOrDefault();
//                email.EmailTVItemID = tvItemEmail.TVItemID;
//                if (!await AddObject("Email", email)) return await Task.FromResult(false);
//                #endregion TVItem Email and Email
//                #region TVItem Tel and Tel
//                Console.WriteLine($"doing ... Tel");
//                // Tel Charles.LeBlanc@ec.gc.ca TVItemID = 108984
//                TVItem tvItemTel = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 108984).FirstOrDefault();
//                tvItemTel.ParentID = tvItemRoot.TVItemID;
//                if (!await AddObject("TVItem", tvItemTel)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemTel, tvItemRoot)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemTel, 108984, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // Tel Charles.LeBlanc@ec.gc.ca TVItemID = 108984
//                TVItemLanguage tvItemLanguageENTel = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 108984 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENTel.TVItemID = tvItemTel.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENTel)) return await Task.FromResult(false);

//                // Tel Charles.LeBlanc@ec.gc.ca TVItemID = 108984
//                TVItemLanguage tvItemLanguageFRTel = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 108984 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRTel.TVItemID = tvItemTel.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRTel)) return await Task.FromResult(false);

//                // Tel Charles.LeBlanc@ec.gc.ca TVItemID = 108984
//                Tel tel = dbCSSPDB.Tels.AsNoTracking().Where(c => c.TelTVItemID == 108984).FirstOrDefault();
//                tel.TelTVItemID = tvItemTel.TVItemID;
//                if (!await AddObject("Tel", tel)) return await Task.FromResult(false);
//                #endregion TVItem Tel and Tel
//                #region TVItemLink
//                Console.WriteLine($"doing ... TVItemLink");
//                TVItemLink tvItemLinkMunicContact = dbCSSPDB.TVItemLinks.AsNoTracking().Where(c => c.FromTVItemID == 27764 && c.ToTVItemID == 305006).FirstOrDefault();
//                tvItemLinkMunicContact.FromTVItemID = tvItemBouctouche.TVItemID;
//                tvItemLinkMunicContact.ToTVItemID = tvItemContactCharles.TVItemID;
//                tvItemLinkMunicContact.TVPath = $"p{ tvItemBouctouche.TVItemID.ToString() }p{ tvItemContactCharles.TVItemID.ToString() }";
//                if (!await AddObject("TVItemLink", tvItemLinkMunicContact)) return await Task.FromResult(false);

//                TVItemLink tvItemLinkContactTel = dbCSSPDB.TVItemLinks.AsNoTracking().Where(c => c.FromTVItemID == 305006 && c.ToTVItemID == 305007).FirstOrDefault();
//                tvItemLinkContactTel.FromTVItemID = tvItemContactCharles.TVItemID;
//                tvItemLinkContactTel.ToTVItemID = tvItemTel.TVItemID;
//                tvItemLinkContactTel.TVPath = $"p{ tvItemContactCharles.TVItemID.ToString() }p{ tvItemTel.TVItemID.ToString() }";
//                if (!await AddObject("TVItemLink", tvItemLinkContactTel)) return await Task.FromResult(false);

//                TVItemLink tvItemLinkContactEmail = dbCSSPDB.TVItemLinks.AsNoTracking().Where(c => c.FromTVItemID == 305006 && c.ToTVItemID == 305007).FirstOrDefault();
//                tvItemLinkContactEmail.FromTVItemID = tvItemContactCharles.TVItemID;
//                tvItemLinkContactEmail.ToTVItemID = tvItemEmail.TVItemID;
//                tvItemLinkContactEmail.TVPath = $"p{ tvItemContactCharles.TVItemID.ToString() }p{ tvItemEmail.TVItemID.ToString() }";
//                if (!await AddObject("TVItemLink", tvItemLinkContactEmail)) return await Task.FromResult(false);
//                #endregion TVItemLink
//                #region PolSourceSiteEffects and PolSourceSiteEffectTerms where PolSourceSiteEffectID = 36
//                Console.WriteLine($"doing ... TVItemLink");
//                PolSourceSiteEffect polSourceSiteEffect36 = dbCSSPDB.PolSourceSiteEffects.AsNoTracking().Where(c => c.PolSourceSiteEffectID == 36).FirstOrDefault();
//                polSourceSiteEffect36.PolSourceSiteOrInfrastructureTVItemID = polSourceSitePolSite000023.PolSourceSiteTVItemID;
//                polSourceSiteEffect36.MWQMSiteTVItemID = mwqmSite0001.MWQMSiteTVItemID;

//                List<int> PolSourceSiteEffectTermIDList = polSourceSiteEffect36.PolSourceSiteEffectTermIDs.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToList();

//                string PolSourceSiteEffectTermIDs2 = "";

//                foreach (int polSourceSiteEffectTermID in PolSourceSiteEffectTermIDList)
//                {
//                    PolSourceSiteEffectTerm polSourceSiteEffectTerm = dbCSSPDB.PolSourceSiteEffectTerms.AsNoTracking().Where(c => c.PolSourceSiteEffectTermID == polSourceSiteEffectTermID).FirstOrDefault();
//                    polSourceSiteEffectTerm.IsGroup = false;
//                    polSourceSiteEffectTerm.UnderGroupID = null;
//                    if (!await AddObject("PolSourceSiteEffectTerm", polSourceSiteEffectTerm)) return await Task.FromResult(false);
//                    PolSourceSiteEffectTermIDs2 = PolSourceSiteEffectTermIDs2 + "," + polSourceSiteEffectTerm.PolSourceSiteEffectTermID.ToString();
//                }

//                polSourceSiteEffect36.PolSourceSiteEffectTermIDs = PolSourceSiteEffectTermIDs2.Substring(1);
//                if (!await AddObject("PolSourceSiteEffect", polSourceSiteEffect36)) return await Task.FromResult(false);
//                #endregion  PolSourceSiteEffects and PolSourceSiteEffectTerms where PolSourceSiteEffectID = 36
//                #region Spill and SpillLanguage
//                Console.WriteLine($"doing ... Spill and SpillLanguage");
//                Spill spill = new Spill();
//                spill.MunicipalityTVItemID = tvItemBouctouche.TVItemID;
//                spill.InfrastructureTVItemID = tvItemBouctoucheWWTP.TVItemID;
//                spill.StartDateTime_Local = DateTime.Now.AddYears(-5);
//                spill.EndDateTime_Local = DateTime.Now.AddYears(-5).AddHours(6);
//                spill.AverageFlow_m3_day = 34.5D;
//                spill.LastUpdateDate_UTC = DateTime.Now;
//                spill.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
//                if (!await AddObject("Spill", spill)) return await Task.FromResult(false);

//                SpillLanguage spillLanguageEN = new SpillLanguage();
//                spillLanguageEN.SpillID = spill.SpillID;
//                spillLanguageEN.Language = LanguageEnum.en;
//                spillLanguageEN.SpillComment = "This is the spill comment";
//                spillLanguageEN.TranslationStatus = TranslationStatusEnum.Translated;
//                spillLanguageEN.LastUpdateDate_UTC = DateTime.Now;
//                spillLanguageEN.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
//                if (!await AddObject("SpillLanguage", spillLanguageEN)) return await Task.FromResult(false);

//                SpillLanguage spillLanguageFR = new SpillLanguage();
//                spillLanguageFR.SpillID = spill.SpillID;
//                spillLanguageFR.Language = LanguageEnum.fr;
//                spillLanguageFR.SpillComment = "This is the spill comment";
//                spillLanguageFR.TranslationStatus = TranslationStatusEnum.NotTranslated;
//                spillLanguageFR.LastUpdateDate_UTC = DateTime.Now;
//                spillLanguageFR.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
//                if (!await AddObject("SpillLanguage", spillLanguageFR)) return await Task.FromResult(false);
//                #endregion Spill and SpillLanguage
//                #region EmailDistributionList and EmailDistributionListContact
//                Console.WriteLine($"doing ... EmailDistributionList and EmailDistributionListContact");
//                EmailDistributionList emailDistributionList = dbCSSPDB.EmailDistributionLists.AsNoTracking().FirstOrDefault();
//                int EmailDistributionListID = emailDistributionList.EmailDistributionListID;
//                emailDistributionList.ParentTVItemID = tvItemCanada.TVItemID;
//                if (!await AddObject("EmailDistributionList", emailDistributionList)) return await Task.FromResult(false);

//                EmailDistributionListLanguage emailDistributionListLanguageEN = dbCSSPDB.EmailDistributionListLanguages.AsNoTracking().Where(c => c.EmailDistributionListID == EmailDistributionListID && c.Language == LanguageEnum.en).FirstOrDefault();
//                emailDistributionListLanguageEN.EmailDistributionListID = emailDistributionList.EmailDistributionListID;
//                if (!await AddObject("EmailDistributionListLanguage", emailDistributionListLanguageEN)) return await Task.FromResult(false);

//                EmailDistributionListLanguage emailDistributionListLanguageFR = dbCSSPDB.EmailDistributionListLanguages.AsNoTracking().Where(c => c.EmailDistributionListID == EmailDistributionListID && c.Language == LanguageEnum.fr).FirstOrDefault();
//                emailDistributionListLanguageFR.EmailDistributionListID = emailDistributionList.EmailDistributionListID;
//                if (!await AddObject("EmailDistributionListLanguage", emailDistributionListLanguageFR)) return await Task.FromResult(false);


//                List<EmailDistributionListContact> emailDistributionListContactList = dbCSSPDB.EmailDistributionListContacts.AsNoTracking().Where(c => c.EmailDistributionListID == EmailDistributionListID).Take(5).ToList();
//                foreach (EmailDistributionListContact emailDistributionListContact in emailDistributionListContactList)
//                {
//                    emailDistributionListContact.EmailDistributionListID = emailDistributionList.EmailDistributionListID;
//                    int EmailDistributionListContactID = emailDistributionListContact.EmailDistributionListContactID;
//                    if (!await AddObject("EmailDistributionListContact", emailDistributionListContact)) return await Task.FromResult(false);

//                    EmailDistributionListContactLanguage emailDistributionListContactLanguageEN = dbCSSPDB.EmailDistributionListContactLanguages.AsNoTracking().Where(c => c.EmailDistributionListContactID == EmailDistributionListContactID && c.Language == LanguageEnum.en).FirstOrDefault();
//                    emailDistributionListContactLanguageEN.EmailDistributionListContactID = emailDistributionListContact.EmailDistributionListContactID;
//                    if (!await AddObject("EmailDistributionListContactLanguage", emailDistributionListContactLanguageEN)) return await Task.FromResult(false);

//                    EmailDistributionListContactLanguage emailDistributionListContactLanguageFR = dbCSSPDB.EmailDistributionListContactLanguages.AsNoTracking().Where(c => c.EmailDistributionListContactID == EmailDistributionListContactID && c.Language == LanguageEnum.fr).FirstOrDefault();
//                    emailDistributionListContactLanguageFR.EmailDistributionListContactID = emailDistributionListContact.EmailDistributionListContactID;
//                    if (!await AddObject("EmailDistributionListContactLanguage", emailDistributionListContactLanguageFR)) return await Task.FromResult(false);

//                }
//                #endregion EmailDistributionList and EmailDistributionListContact
//                #region AppTask and AppTaskLanguage
//                Console.WriteLine($"doing ... AppTask and AppTaskLanguage");
//                AppTask appTask = new AppTask();
//                appTask.TVItemID = tvItemCanada.TVItemID;
//                appTask.TVItemID2 = tvItemCanada.TVItemID;
//                appTask.AppTaskCommand = AppTaskCommandEnum.GenerateWebTide;
//                appTask.AppTaskStatus = AppTaskStatusEnum.Created;
//                appTask.PercentCompleted = 1;
//                appTask.Parameters = "a,a";
//                appTask.Language = LanguageEnum.en;
//                appTask.StartDateTime_UTC = DateTime.Now.AddYears(-5);
//                appTask.EndDateTime_UTC = DateTime.Now.AddYears(-5).AddHours(4);
//                appTask.EstimatedLength_second = 1201;
//                appTask.RemainingTime_second = 234;
//                appTask.LastUpdateDate_UTC = DateTime.Now;
//                appTask.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
//                if (!await AddObject("AppTask", appTask)) return await Task.FromResult(false);

//                AppTaskLanguage appTaskLanguageEN = new AppTaskLanguage();
//                appTaskLanguageEN.AppTaskID = appTask.AppTaskID;
//                appTaskLanguageEN.Language = LanguageEnum.en;
//                appTaskLanguageEN.StatusText = "This is the Status text";
//                appTaskLanguageEN.ErrorText = "This is the CSSPError text";
//                appTaskLanguageEN.TranslationStatus = TranslationStatusEnum.Translated;
//                appTaskLanguageEN.LastUpdateDate_UTC = DateTime.Now;
//                appTaskLanguageEN.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
//                if (!await AddObject("AppTaskLanguage", appTaskLanguageEN)) return await Task.FromResult(false);

//                AppTaskLanguage appTaskLanguageFR = new AppTaskLanguage();
//                appTaskLanguageFR.AppTaskID = appTask.AppTaskID;
//                appTaskLanguageFR.Language = LanguageEnum.fr;
//                appTaskLanguageFR.StatusText = "This is the Status text";
//                appTaskLanguageFR.ErrorText = "This is the CSSPError text";
//                appTaskLanguageFR.TranslationStatus = TranslationStatusEnum.NotTranslated;
//                appTaskLanguageFR.LastUpdateDate_UTC = DateTime.Now;
//                appTaskLanguageFR.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
//                if (!await AddObject("AppTaskLanguage", appTaskLanguageFR)) return await Task.FromResult(false);
//                #endregion AppTask and AppTaskLanguage
//                #region AppErrLog
//                Console.WriteLine($"doing ... AppErrLog");
//                AppErrLog appErrLog = new AppErrLog();
//                appErrLog.Tag = "SomeTag";
//                appErrLog.LineNumber = 234;
//                appErrLog.Source = "Some text for source";
//                appErrLog.Message = "Some text for message";
//                appErrLog.DateTime_UTC = DateTime.Now;
//                appErrLog.LastUpdateDate_UTC = DateTime.Now;
//                appErrLog.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
//                if (!await AddObject("AppErrLog", appErrLog)) return await Task.FromResult(false);
//                #endregion AppErrLog
//                #region ContactPreference
//                Console.WriteLine($"doing ... ContactPreference");
//                ContactPreference contactPreference = new ContactPreference();
//                contactPreference.ContactID = contactCharles.ContactID;
//                contactPreference.TVType = TVTypeEnum.ClimateSite;
//                contactPreference.MarkerSize = 100;
//                contactPreference.LastUpdateDate_UTC = DateTime.Now;
//                contactPreference.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
//                if (!await AddObject("ContactPreference", contactPreference)) return await Task.FromResult(false);
//                #endregion ContactPreference
//                #region ContactShortcut
//                Console.WriteLine($"doing ... ContactShortcut");
//                ContactShortcut contactShortcut = new ContactShortcut();
//                contactShortcut.ContactID = contactCharles.ContactID;
//                contactShortcut.ShortCutText = "Some shortcut text";
//                contactShortcut.ShortCutAddress = "http://www.ibm.com";
//                contactShortcut.LastUpdateDate_UTC = DateTime.Now;
//                contactShortcut.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
//                if (!await AddObject("ContactShortcut", contactShortcut)) return await Task.FromResult(false);
//                #endregion ContactShortcut
//                #region DocTemplate
//                Console.WriteLine($"doing ... DocTemplate");
//                DocTemplate docTemplate = new DocTemplate();
//                docTemplate.Language = LanguageEnum.en;
//                docTemplate.TVType = TVTypeEnum.Subsector;
//                docTemplate.TVFileTVItemID = tvFile.TVFileTVItemID;
//                docTemplate.FileName = tvItemBouctoucheWWTPTVFileImageEN.TVText;
//                docTemplate.LastUpdateDate_UTC = DateTime.Now;
//                docTemplate.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
//                if (!await AddObject("DocTemplate", docTemplate)) return await Task.FromResult(false);
//                #endregion DocTemplate
//                #region Log
//                Console.WriteLine($"doing ... Log");
//                Log log = new Log();
//                log.TableName = "TVItems";
//                log.ID = 20;
//                log.LogCommand = LogCommandEnum.Add;
//                log.Information = "The Information Text";
//                log.LastUpdateDate_UTC = DateTime.Now;
//                log.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
//                if (!await AddObject("Log", log)) return await Task.FromResult(false);
//                #endregion Log
//                #region MWQMLookupMPN
//                Console.WriteLine($"doing ... MWQMLookupMPN");
//                List<MWQMLookupMPN> mwqmLookupMPNList = dbCSSPDB.MWQMLookupMPNs.AsNoTracking().Take(12).ToList();
//                foreach (MWQMLookupMPN mwqmLookupMPN2 in mwqmLookupMPNList)
//                {
//                    MWQMLookupMPN mwqmLookupMPN = new MWQMLookupMPN();
//                    mwqmLookupMPN.Tubes10 = mwqmLookupMPN2.Tubes10;
//                    mwqmLookupMPN.Tubes1 = mwqmLookupMPN2.Tubes1;
//                    mwqmLookupMPN.Tubes01 = mwqmLookupMPN2.Tubes01;
//                    mwqmLookupMPN.MPN_100ml = mwqmLookupMPN2.MPN_100ml;
//                    mwqmLookupMPN.LastUpdateDate_UTC = DateTime.Now;
//                    mwqmLookupMPN.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
//                    if (!await AddObject("MWQMLookupMPN", mwqmLookupMPN)) return await Task.FromResult(false);
//                }
//                #endregion MWQMLookupMPN
//                #region RainExceedance and RainExceedanceClimateSite
//                Console.WriteLine($"doing ... RainExceedance");

//                TVItem tvItemRainExceedance = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 374858).FirstOrDefault();
//                tvItemEmail.ParentID = tvItemCanada.TVItemID;
//                if (!await AddObject("TVItem", tvItemRainExceedance)) return await Task.FromResult(false);
//                if (!await CorrectTVPath(tvItemRainExceedance, tvItemCanada)) return await Task.FromResult(false);
//                if (!await AddMapInfo(tvItemRainExceedance, 374858, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

//                // Email Charles.LeBlanc@ec.gc.ca TVItemID = 374858
//                TVItemLanguage tvItemLanguageENRainExceedance = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 374858 && c.Language == LanguageEnum.en).FirstOrDefault();
//                tvItemLanguageENRainExceedance.TVItemID = tvItemRainExceedance.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageENRainExceedance)) return await Task.FromResult(false);

//                // Email Charles.LeBlanc@ec.gc.ca TVItemID = 374858
//                TVItemLanguage tvItemLanguageFRRainExceedance = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 374858 && c.Language == LanguageEnum.fr).FirstOrDefault();
//                tvItemLanguageFRRainExceedance.TVItemID = tvItemRainExceedance.TVItemID;
//                if (!await AddObject("TVItemLanguage", tvItemLanguageFRRainExceedance)) return await Task.FromResult(false);


//                RainExceedance rainExceedance = new RainExceedance();
//                rainExceedance.StartMonth = 1;
//                rainExceedance.EndMonth = 4;
//                rainExceedance.StartDay = 2;
//                rainExceedance.EndDay = 31;
//                rainExceedance.RainMaximum_mm = 12.5f;
//                rainExceedance.RainExceedanceTVItemID = tvItemRainExceedance.TVItemID;
//                rainExceedance.StakeholdersEmailDistributionListID = null;
//                rainExceedance.OnlyStaffEmailDistributionListID = null;
//                rainExceedance.IsActive = true;
//                rainExceedance.LastUpdateDate_UTC = DateTime.Now;
//                rainExceedance.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
//                if (!await AddObject("RainExceedance", rainExceedance)) return await Task.FromResult(false);

//                // RainExceedanceClimateSite
//                RainExceedanceClimateSite rainExceedanceClimateSite = dbCSSPDB.RainExceedanceClimateSites.AsNoTracking().Where(c => c.RainExceedanceTVItemID == 374858).FirstOrDefault();
//                rainExceedanceClimateSite.RainExceedanceTVItemID = tvItemRainExceedance.TVItemID;
//                rainExceedanceClimateSite.ClimateSiteTVItemID = tvItemNBClimateSiteBouctoucheCDA.TVItemID;
//                if (!await AddObject("RainExceedanceClimateSite", rainExceedanceClimateSite)) return await Task.FromResult(false);
//                #endregion RainExceedance and RainExceedanceClimateSite
//                #region ResetPassword
//                Console.WriteLine($"doing ... ResetPassword");
//                ResetPassword resetPassword = new ResetPassword();
//                resetPassword.Email = contactCharles.LoginEmail;
//                resetPassword.ExpireDate_Local = DateTime.Now;
//                resetPassword.Code = "12345678";
//                resetPassword.LastUpdateDate_UTC = DateTime.Now;
//                resetPassword.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
//                if (!await AddObject("ResetPassword", resetPassword)) return await Task.FromResult(false);
//                #endregion ResetPassword
//                #region TideLocation
//                Console.WriteLine($"doing ... TideLocation");
//                foreach (int TideLocationSID in new List<int>() { 1815, 1812, 1810 })
//                {
//                    TideLocation tideLocation = dbCSSPDB.TideLocations.AsNoTracking().Where(c => c.sid == TideLocationSID).FirstOrDefault();

//                    if (tideLocation != null)
//                    {
//                        tideLocation.TideLocationID = 0;
//                        if (!await AddObject("TideLocation", tideLocation)) return await Task.FromResult(false);
//                    }
//                }
//                #endregion TideLocation
//                #region TVItemStat
//                Console.WriteLine($"doing ... TVItemStat");
//                TVItemStat tvItemStat = dbCSSPDB.TVItemStats.AsNoTracking().Where(c => c.TVItemID == RootTVItemID && c.TVType == TVTypeEnum.Municipality).FirstOrDefault();

//                if (tvItemStat != null)
//                {
//                    tvItemStat.TVItemStatID = 0;
//                    tvItemStat.TVItemID = tvItemRoot.TVItemID;
//                    tvItemStat.ChildCount = 2;
//                    if (!await AddObject("TVItemStat", tvItemStat)) return await Task.FromResult(false);
//                }
//                #endregion TVItemStat
//                #region TVItemUserAuthorization
//                Console.WriteLine($"doing ... TVItemUserAuthorization");
//                TVItemUserAuthorization tvItemUserAuthorization = dbCSSPDB.TVItemUserAuthorizations.AsNoTracking().FirstOrDefault();

//                if (tvItemUserAuthorization != null)
//                {
//                    tvItemUserAuthorization.ContactTVItemID = contactCharles.ContactTVItemID;
//                    tvItemUserAuthorization.TVItemID1 = tvItemBouctouche.TVItemID;
//                    tvItemUserAuthorization.TVAuth = TVAuthEnum.Write;
//                    if (!await AddObject("TVItemUserAuthorization", tvItemUserAuthorization)) return await Task.FromResult(false);
//                }
//                #endregion TVItemUserAuthorization
//                #region TVTypeUserAuthorization
//                Console.WriteLine($"doing ... TVTypeUserAuthorization");
//                TVTypeUserAuthorization tvTypeUserAuthorization = dbCSSPDB.TVTypeUserAuthorizations.AsNoTracking().FirstOrDefault();

//                if (tvTypeUserAuthorization != null)
//                {
//                    tvTypeUserAuthorization.ContactTVItemID = contactCharles.ContactTVItemID;
//                    tvTypeUserAuthorization.TVType = TVTypeEnum.Root;
//                    tvTypeUserAuthorization.TVAuth = TVAuthEnum.Admin;
//                    if (!await AddObject("TVTypeUserAuthorization", tvTypeUserAuthorization)) return await Task.FromResult(false);
//                }
//                #endregion TVTypeUserAuthorization
//                #region MWQMAnalysisReportParameter
//                Console.WriteLine($"doing ... MWQMAnalysisReportParameter");
//                MWQMAnalysisReportParameter mwqmAnalysisReportParameter = new MWQMAnalysisReportParameter();
//                mwqmAnalysisReportParameter.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
//                mwqmAnalysisReportParameter.AnalysisName = "Name of analysis report parameter";
//                mwqmAnalysisReportParameter.AnalysisReportYear = 2016;
//                mwqmAnalysisReportParameter.StartDate = new DateTime(2010, 1, 1);
//                mwqmAnalysisReportParameter.EndDate = new DateTime(2016, 12, 31);
//                mwqmAnalysisReportParameter.AnalysisCalculationType = AnalysisCalculationTypeEnum.All;
//                mwqmAnalysisReportParameter.NumberOfRuns = 30;
//                mwqmAnalysisReportParameter.FullYear = true;
//                mwqmAnalysisReportParameter.SalinityHighlightDeviationFromAverage = 8.0f;
//                mwqmAnalysisReportParameter.ShortRangeNumberOfDays = 3;
//                mwqmAnalysisReportParameter.MidRangeNumberOfDays = 6;
//                mwqmAnalysisReportParameter.DryLimit24h = 4;
//                mwqmAnalysisReportParameter.DryLimit48h = 8;
//                mwqmAnalysisReportParameter.DryLimit72h = 12;
//                mwqmAnalysisReportParameter.DryLimit96h = 16;
//                mwqmAnalysisReportParameter.WetLimit24h = 12;
//                mwqmAnalysisReportParameter.WetLimit48h = 24;
//                mwqmAnalysisReportParameter.WetLimit72h = 36;
//                mwqmAnalysisReportParameter.WetLimit96h = 48;
//                mwqmAnalysisReportParameter.RunsToOmit = ",";
//                mwqmAnalysisReportParameter.ExcelTVFileTVItemID = null;
//                mwqmAnalysisReportParameter.Command = AnalysisReportExportCommandEnum.Report;
//                mwqmAnalysisReportParameter.LastUpdateDate_UTC = DateTime.Now;
//                mwqmAnalysisReportParameter.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
//                if (!await AddObject("MWQMAnalysisReportParameter", mwqmAnalysisReportParameter)) return await Task.FromResult(false);
//                #endregion MWQMAnalysisReportParameter
//                #region PolSourceGrouping and PolSourceGroupingLangauge
//                Console.WriteLine($"doing ... PolSourceGrouping");
//                PolSourceGrouping polSourceGrouping = new PolSourceGrouping();
//                polSourceGrouping.CSSPID = 10003;
//                polSourceGrouping.GroupName = "FirstGroupName";
//                polSourceGrouping.Child = "FirstChild";
//                polSourceGrouping.Hide = "FirstHide";
//                polSourceGrouping.LastUpdateDate_UTC = DateTime.Now;
//                polSourceGrouping.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
//                if (!await AddObject("PolSourceGrouping", polSourceGrouping)) return await Task.FromResult(false);

//                Console.WriteLine($"doing ... PolSourceGrouping");
//                PolSourceGroupingLanguage polSourceGroupingLanguage = new PolSourceGroupingLanguage();
//                polSourceGroupingLanguage.PolSourceGroupingID = polSourceGrouping.PolSourceGroupingID;
//                polSourceGroupingLanguage.Language = LanguageEnum.en;
//                polSourceGroupingLanguage.SourceName = "FirstSourceName";
//                polSourceGroupingLanguage.SourceNameOrder = 1;
//                polSourceGroupingLanguage.TranslationStatusSourceName = TranslationStatusEnum.Translated;
//                polSourceGroupingLanguage.Init = "FirstInit";
//                polSourceGroupingLanguage.TranslationStatusInit = TranslationStatusEnum.Translated;
//                polSourceGroupingLanguage.Description = "FirstDescription";
//                polSourceGroupingLanguage.TranslationStatusDescription = TranslationStatusEnum.Translated;
//                polSourceGroupingLanguage.Report = "FirstReport";
//                polSourceGroupingLanguage.TranslationStatusReport = TranslationStatusEnum.Translated;
//                polSourceGroupingLanguage.Text = "FirstText";
//                polSourceGroupingLanguage.TranslationStatusText = TranslationStatusEnum.Translated;
//                polSourceGroupingLanguage.LastUpdateDate_UTC = DateTime.Now;
//                polSourceGroupingLanguage.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
//                if (!await AddObject("PolSourceGroupingLanguage", polSourceGroupingLanguage)) return await Task.FromResult(false);

//                Console.WriteLine($"doing ... PolSourceGrouping");
//                PolSourceGroupingLanguage polSourceGroupingLanguageFR = new PolSourceGroupingLanguage();
//                polSourceGroupingLanguageFR.PolSourceGroupingID = polSourceGrouping.PolSourceGroupingID;
//                polSourceGroupingLanguageFR.Language = LanguageEnum.fr;
//                polSourceGroupingLanguageFR.SourceName = "FirstSourceNameFR";
//                polSourceGroupingLanguageFR.SourceNameOrder = 1;
//                polSourceGroupingLanguageFR.TranslationStatusSourceName = TranslationStatusEnum.Translated;
//                polSourceGroupingLanguageFR.Init = "FirstInitFR";
//                polSourceGroupingLanguageFR.TranslationStatusInit = TranslationStatusEnum.Translated;
//                polSourceGroupingLanguageFR.Description = "FirstDescriptionFR";
//                polSourceGroupingLanguageFR.TranslationStatusDescription = TranslationStatusEnum.Translated;
//                polSourceGroupingLanguageFR.Report = "FirstReportFR";
//                polSourceGroupingLanguageFR.TranslationStatusReport = TranslationStatusEnum.Translated;
//                polSourceGroupingLanguageFR.Text = "FirstTextFR";
//                polSourceGroupingLanguageFR.TranslationStatusText = TranslationStatusEnum.Translated;
//                polSourceGroupingLanguageFR.LastUpdateDate_UTC = DateTime.Now;
//                polSourceGroupingLanguageFR.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
//                if (!await AddObject("PolSourceGroupingLanguage", polSourceGroupingLanguageFR)) return await Task.FromResult(false);
//                #endregion PolSourceGrouping
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("");
//                Console.WriteLine(ex.Message);
//            }

//            return await Task.FromResult(true);
//        }
//    }
//}

////using CSSPEnums;
////using CSSPDBModels;
////using GenerateCodeBaseServices.Models;
////using Microsoft.EntityFrameworkCore;
////using System;
////using System.Collections.Generic;
////using System.Data;
////using System.Linq;
////using System.Threading.Tasks;

////namespace GenerateRepopulateTestDB
////{
////    public partial class Startup
////    {
////        private async Task<bool> FillTestDB(List<Table> tableTestDBList)
////        {
////            try
////            {

////                #region TVItem Root
////                Console.WriteLine($"doing ... root");
////                // TVItem Root TVItemID = 1
////                TVItem tvItemRoot = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == c.ParentID && c.TVLevel == 0).FirstOrDefault();
////                int RootTVItemID = tvItemRoot.TVItemID;
////                if (!await AddObject("TVItem", tvItemRoot)) return await Task.FromResult(false);

////                // TVItemLanguage EN Root TVItemID = 1
////                TVItemLanguage tvItemLanguageENRoot = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == RootTVItemID && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENRoot.TVItemID = tvItemRoot.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENRoot)) return await Task.FromResult(false);

////                // TVItemLanguage FR Root TVItemID = 1
////                TVItemLanguage tvItemLanguageFRRoot = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == RootTVItemID && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRRoot.TVItemID = tvItemRoot.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRRoot)) return await Task.FromResult(false);
////                #endregion  TVItem Root
////                #region Contact Charles with TVItem
////                Console.WriteLine($"doing ... Contact Charles with TVItem");
////                // TVItem Charles G. LeBlanc TVItemID = 2
////                TVItem tvItemContactCharles = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 2).FirstOrDefault();
////                tvItemContactCharles.ParentID = tvItemRoot.TVItemID;
////                if (!await AddObject("TVItem", tvItemContactCharles)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemContactCharles, tvItemRoot)) return await Task.FromResult(false);

////                // TVItemLanguage EN Charles G. LeBlanc  TVItemID = 2
////                TVItemLanguage tvItemLanguageENContactCharles = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 2 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENContactCharles.TVItemID = tvItemContactCharles.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENContactCharles)) return await Task.FromResult(false);

////                // TVItemLanguage FR Charles G. LeBlanc TVItemID = 2
////                TVItemLanguage tvItemLanguageFRContactCharles = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 2 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRContactCharles.TVItemID = tvItemContactCharles.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRContactCharles)) return await Task.FromResult(false);

////                //Console.WriteLine($"doing ... Contact Charles with TVItem");

////                //ContactService contactService = new ContactService(new Query(), dbTestDB, 2);

////                // Contact Charles G. LeBlanc
////                Contact contactCharles = dbCSSPDB.Contacts.AsNoTracking().Where(c => c.ContactTVItemID == 2).FirstOrDefault();
////                if (!await AddObject("Contact", contactCharles)) return await Task.FromResult(false);
////                #endregion Contact Charles with TVItem
////                #region Contact Test User 1 with TVItem
////                Console.WriteLine($"doing ... TVItem Contact and Contact Login test user 1");
////                // TVItem Test User 1 TVItemID = 3
////                TVItem tvItemContactTestUser1 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 3).FirstOrDefault();
////                tvItemContactTestUser1.ParentID = tvItemRoot.TVItemID;
////                if (!await AddObject("TVItem", tvItemContactTestUser1)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemContactTestUser1, tvItemRoot)) return await Task.FromResult(false);

////                // TVItemLanguage EN Test User 1  TVItemID = 3
////                TVItemLanguage tvItemLanguageENContactTestUser1 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 3 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENContactTestUser1.TVItemID = tvItemContactTestUser1.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENContactTestUser1)) return await Task.FromResult(false);

////                // TVItemLanguage FR Test User 1 TVItemID = 3
////                TVItemLanguage tvItemLanguageFRContactTestUser1 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 3 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRContactTestUser1.TVItemID = tvItemContactTestUser1.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRContactTestUser1)) return await Task.FromResult(false);

////                // Contact Test User 1
////                Contact contactTestUser1 = dbCSSPDB.Contacts.AsNoTracking().Where(c => c.ContactTVItemID == 3).FirstOrDefault();
////                if (!await AddObject("Contact", contactTestUser1)) return await Task.FromResult(false);
////                #endregion Contact Test User 1 with TVItem
////                #region Contact Test User 2 with TVItem
////                Console.WriteLine($"doing ... TVItem Contact and Contact Login test user 1");

////                // TVItem Test User 2 TVItemID = 4
////                TVItem tvItemContactTestUser2 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 4).FirstOrDefault();
////                tvItemContactTestUser2.ParentID = tvItemRoot.TVItemID;
////                if (!await AddObject("TVItem", tvItemContactTestUser2)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemContactTestUser2, tvItemRoot)) return await Task.FromResult(false);

////                // TVItemLanguage EN Test User 2  TVItemID = 4
////                TVItemLanguage tvItemLanguageENContactTestUser2 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 4 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENContactTestUser2.TVItemID = tvItemContactTestUser2.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENContactTestUser2)) return await Task.FromResult(false);

////                // TVItemLanguage FR Test User 2 TVItemID = 4
////                TVItemLanguage tvItemLanguageFRContactTestUser2 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 4 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRContactTestUser2.TVItemID = tvItemContactTestUser2.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRContactTestUser2)) return await Task.FromResult(false);

////                // Contact Test User 2
////                Contact contactTestUser2 = dbCSSPDB.Contacts.AsNoTracking().Where(c => c.ContactTVItemID == 4).FirstOrDefault();
////                if (!await AddObject("Contact", contactTestUser2)) return await Task.FromResult(false);
////                #endregion Contact Test User 2 with TVItem
////                #region TVItem Country Canada
////                Console.WriteLine($"doing ... Canada");
////                // TVItem Canada TVItemID = 5
////                TVItem tvItemCanada = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 5).FirstOrDefault();
////                tvItemCanada.ParentID = tvItemRoot.TVItemID;
////                if (!await AddObject("TVItem", tvItemCanada)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemCanada, tvItemRoot)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemCanada, 5, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // TVItemLanguage EN Canada TVItemID = 5
////                TVItemLanguage tvItemLanguageENCanada = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 5 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENCanada.TVItemID = tvItemCanada.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENCanada)) return await Task.FromResult(false);

////                // TVItemLanguage FR Canada TVItemID = 5
////                TVItemLanguage tvItemLanguageFRCanada = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 5 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRCanada.TVItemID = tvItemCanada.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRCanada)) return await Task.FromResult(false);
////                #endregion TVItem Country Canada
////                #region TVItem Province NB
////                Console.WriteLine($"doing ... New Brunswick");
////                // TVItem Province NB TVItemID = 7
////                TVItem tvItemNB = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 7).FirstOrDefault();
////                int NBTVItemID = tvItemNB.TVItemID;
////                tvItemNB.ParentID = tvItemCanada.TVItemID;
////                if (!await AddObject("TVItem", tvItemNB)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemNB, tvItemCanada)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemNB, NBTVItemID, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // TVItemLanguage EN NB TVItemID = 7
////                TVItemLanguage tvItemLanguageENNB = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENNB.TVItemID = tvItemNB.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENNB)) return await Task.FromResult(false);

////                // TVItemLanguage FR NB TVItemID = 7
////                TVItemLanguage tvItemLanguageFRNB = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRNB.TVItemID = tvItemNB.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNB)) return await Task.FromResult(false);
////                #endregion TVItem Province NB
////                #region TVItem ClimateSite Bouctouche CDA
////                Console.WriteLine($"doing ... Climate Site");
////                // TVItem ClimateSite Bouctouche CDA TVItemID = 229528
////                TVItem tvItemNBClimateSiteBouctoucheCDA = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 229528).FirstOrDefault();
////                tvItemNBClimateSiteBouctoucheCDA.ParentID = tvItemNB.TVItemID;
////                if (!await AddObject("TVItem", tvItemNBClimateSiteBouctoucheCDA)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemNBClimateSiteBouctoucheCDA, tvItemNB)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemNBClimateSiteBouctoucheCDA, 229528, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // TVItemLanguage EN Climate Site Bouctouche CDA NB TVItemID = 229528
////                TVItemLanguage tvItemLanguageENNBClimateSiteBouctoucheCDA = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 229528 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENNBClimateSiteBouctoucheCDA.TVItemID = tvItemNBClimateSiteBouctoucheCDA.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENNBClimateSiteBouctoucheCDA)) return await Task.FromResult(false);

////                // TVItemLanguage FR Climate Site Bouctouche CDA NB TVItemID = 229528
////                TVItemLanguage tvItemLanguageFRNBClimateSiteBouctoucheCDA = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 229528 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRNBClimateSiteBouctoucheCDA.TVItemID = tvItemNBClimateSiteBouctoucheCDA.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNBClimateSiteBouctoucheCDA)) return await Task.FromResult(false);
////                #endregion TVItem ClimateSite Bouctouche CDA
////                #region ClimateSite Bouctouche CDA

////                // NB Climate Site Bouctouche CDA where ClimateSiteTVItemID = 229528
////                ClimateSite climateSite = dbCSSPDB.ClimateSites.AsNoTracking().Where(c => c.ClimateSiteTVItemID == 229528).FirstOrDefault();
////                int ClimateSiteID = climateSite.ClimateSiteID;
////                climateSite.ClimateSiteTVItemID = tvItemNBClimateSiteBouctoucheCDA.TVItemID;
////                if (!await AddObject("ClimateSite", climateSite)) return await Task.FromResult(false);

////                // NB Climate Data Value Bouctouche CDA where ClimateSiteTVItemID = 229528
////                List<ClimateDataValue> climateDataValueList = dbCSSPDB.ClimateDataValues.AsNoTracking().Where(c => c.ClimateSiteID == ClimateSiteID && c.TotalPrecip_mm_cm != -999.0f).Take(5).ToList();
////                foreach (ClimateDataValue climateDataValue in climateDataValueList)
////                {
////                    climateDataValue.ClimateSiteID = climateSite.ClimateSiteID;
////                    climateDataValue.HourlyValues = "Some value";
////                    if (!await AddObject("ClimateDataValue", climateDataValue)) return await Task.FromResult(false);
////                }
////                #endregion ClimateSite Bouctouche CDA
////                #region TVItem HydrometricSite Big Tracadie 01BL003 
////                Console.WriteLine($"doing ... Hydrometric Site");
////                // TVItem HydrometricSite Big Tracadie 01BL003 TVItemID = 55401
////                TVItem tvItemNBHydrometricSiteBigTracadie = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 55401).FirstOrDefault();
////                tvItemNBHydrometricSiteBigTracadie.ParentID = tvItemNB.TVItemID;
////                if (!await AddObject("TVItem", tvItemNBHydrometricSiteBigTracadie)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemNBHydrometricSiteBigTracadie, tvItemNB)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemNBHydrometricSiteBigTracadie, 55401, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // TVItemLanguage EN Hydrometric site Big Tracadie NB TVItemID = 55401
////                TVItemLanguage tvItemLanguageENNBHydrometricSiteBigTracadie = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 55401 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENNBHydrometricSiteBigTracadie.TVItemID = tvItemNBHydrometricSiteBigTracadie.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENNBHydrometricSiteBigTracadie)) return await Task.FromResult(false);

////                // TVItemLanguage FR Hydrometric site Big Tracadie NB TVItemID = 55401
////                TVItemLanguage tvItemLanguageFRNBHydrometricSiteBigTracadie = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 55401 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRNBHydrometricSiteBigTracadie.TVItemID = tvItemNBHydrometricSiteBigTracadie.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNBHydrometricSiteBigTracadie)) return await Task.FromResult(false);
////                #endregion TVItem HydrometricSite Big Tracadie 01BL003 
////                #region HydrometricSite Big Tracadie 01BL003 

////                // NB Hydrometric site Big Tracadie where HydrometricSiteTVItemID = 55401
////                HydrometricSite hydrometricSite = dbCSSPDB.HydrometricSites.AsNoTracking().Where(c => c.HydrometricSiteTVItemID == 55401).FirstOrDefault();
////                int HydrometricSiteID = hydrometricSite.HydrometricSiteID;
////                hydrometricSite.HydrometricSiteTVItemID = tvItemNBHydrometricSiteBigTracadie.TVItemID;
////                if (!await AddObject("HydrometricSite", hydrometricSite)) return await Task.FromResult(false);

////                // NB Hydrometric site Big Tracadie where HydrometricSiteTVItemID = 55401
////                HydrometricDataValue hydrometricDataValue = new HydrometricDataValue();
////                hydrometricDataValue.HydrometricSiteID = hydrometricSite.HydrometricSiteID;
////                hydrometricDataValue.DateTime_Local = DateTime.Now;
////                hydrometricDataValue.Keep = true;
////                hydrometricDataValue.StorageDataType = StorageDataTypeEnum.Archived;
////                hydrometricDataValue.Discharge_m3_s = 23.4f;
////                hydrometricDataValue.DischargeEntered_m3_s = null;
////                hydrometricDataValue.Level_m = 3.0f;
////                hydrometricDataValue.HourlyValues = "Some hourly values text";
////                hydrometricDataValue.LastUpdateDate_UTC = DateTime.Now;
////                hydrometricDataValue.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
////                if (!await AddObject("HydrometricDataValue", hydrometricDataValue)) return await Task.FromResult(false);
////                #endregion HydrometricSite Big Tracadie 01BL003 
////                #region RatingCurve Big Tracadie 01BL003 
////                Console.WriteLine($"doing ... Rating Curve");

////                // NB Hydrometric site Big Tracadie where HydrometricSiteTVItemID = 55401
////                RatingCurve ratingCurve = dbCSSPDB.RatingCurves.AsNoTracking().Where(c => c.HydrometricSiteID == HydrometricSiteID).FirstOrDefault();
////                int RatingCurveID = ratingCurve.RatingCurveID;
////                ratingCurve.HydrometricSiteID = hydrometricSite.HydrometricSiteID;
////                if (!await AddObject("RatingCurve", ratingCurve)) return await Task.FromResult(false);
////                #endregion RatingCurve Big Tracadie 01BL003 
////                #region RatingCurveValue Big Tracadie 01BL003 
////                Console.WriteLine($"doing ... Rating Curve");
////                // NB Hydrometric site Big Tracadie where HydrometricSiteTVItemID = 55401
////                List<RatingCurveValue> ratingCurveValueList = dbCSSPDB.RatingCurveValues.AsNoTracking().Where(c => c.RatingCurveID == RatingCurveID).Take(5).ToList();
////                foreach (RatingCurveValue ratingCurveValue in ratingCurveValueList)
////                {
////                    ratingCurveValue.RatingCurveID = ratingCurve.RatingCurveID;
////                    if (!await AddObject("RatingCurveValue", ratingCurveValue)) return await Task.FromResult(false);
////                }
////                #endregion RatingCurve Big Tracadie 01BL003 
////                #region TVItem Area NB-06 
////                Console.WriteLine($"doing ... Area NB-06");
////                // TVItem Area NB-06 TVItemID = 629
////                TVItem tvItemNB_06 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 629).FirstOrDefault();
////                tvItemNB_06.ParentID = tvItemNB.TVItemID;
////                if (!await AddObject("TVItem", tvItemNB_06)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemNB_06, tvItemNB)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemNB_06, 629, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // TVItemLanguage EN NB-06 TVItemID = 629
////                TVItemLanguage tvItemLanguageENNB_06 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 629 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENNB_06.TVItemID = tvItemNB_06.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENNB_06)) return await Task.FromResult(false);

////                // TVItemLanguage FR NB_06 TVItemID = 629
////                TVItemLanguage tvItemLanguageFRNB_06 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 629 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRNB_06.TVItemID = tvItemNB_06.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNB_06)) return await Task.FromResult(false);
////                #endregion TVItem Area NB-06 
////                #region TVItem Sector NB-06-020 
////                Console.WriteLine($"doing ... Sector NB-06-020");
////                // TVItem Sector NB-06_020 TVItemID = 633
////                TVItem tvItemNB_06_020 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 633).FirstOrDefault();
////                tvItemNB_06_020.ParentID = tvItemNB_06.TVItemID;
////                if (!await AddObject("TVItem", tvItemNB_06_020)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemNB_06_020, tvItemNB_06)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemNB_06_020, 633, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // TVItemLanguage EN NB-06_020 TVItemID = 633
////                TVItemLanguage tvItemLanguageENNB_06_020 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 633 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENNB_06_020.TVItemID = tvItemNB_06_020.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENNB_06_020)) return await Task.FromResult(false);

////                // TVItemLanguage FR NB_06_020 TVItemID = 633
////                TVItemLanguage tvItemLanguageFRNB_06_020 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 633 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRNB_06_020.TVItemID = tvItemNB_06_020.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020)) return await Task.FromResult(false);
////                #endregion TVItem Sector NB-06-020 
////                #region TVItem Subsector NB-06_020_001 
////                Console.WriteLine($"doing ... Sector NB-06-020-001");
////                // TVItem Subsector NB-06_020_001 TVItemID = 634
////                TVItem tvItemNB_06_020_001 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 634).FirstOrDefault();
////                tvItemNB_06_020_001.ParentID = tvItemNB_06_020.TVItemID;
////                if (!await AddObject("TVItem", tvItemNB_06_020_001)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemNB_06_020_001, tvItemNB_06_020)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemNB_06_020_001, 634, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // TVItemLanguage EN NB-06_020_001 TVItemID = 634
////                TVItemLanguage tvItemLanguageENNB_06_020_001 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 634 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENNB_06_020_001.TVItemID = tvItemNB_06_020_001.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_001)) return await Task.FromResult(false);

////                // TVItemLanguage FR NB_06_020 TVItemID = 634
////                TVItemLanguage tvItemLanguageFRNB_06_020_001 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 634 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRNB_06_020_001.TVItemID = tvItemNB_06_020_001.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_001)) return await Task.FromResult(false);
////                #endregion TVItem Subsector NB-06_020_001 
////                #region MWQMSubsector NB-06_020_001 and MWQMSubsectorLanguage
////                Console.WriteLine($"doing ... MWQM Subsector NB-06-020-001");
////                // MWQMSubsector NB-06_020_001 TVItemID = 634
////                MWQMSubsector mwqmSubsector001 = dbCSSPDB.MWQMSubsectors.AsNoTracking().Where(c => c.MWQMSubsectorTVItemID == 634).FirstOrDefault();
////                int MWQMSubsector001ID = mwqmSubsector001.MWQMSubsectorID;
////                mwqmSubsector001.MWQMSubsectorTVItemID = tvItemNB_06_020_001.TVItemID;
////                if (!await AddObject("MWQMSubsector", mwqmSubsector001)) return await Task.FromResult(false);

////                // MWQMSubsectorLanguage EN NB-06_020_001 TVItemID = 634
////                MWQMSubsectorLanguage mwqmSubsector001EN = dbCSSPDB.MWQMSubsectorLanguages.AsNoTracking().Where(c => c.MWQMSubsectorID == MWQMSubsector001ID && c.Language == LanguageEnum.en).FirstOrDefault();
////                mwqmSubsector001EN.MWQMSubsectorID = mwqmSubsector001.MWQMSubsectorID;
////                mwqmSubsector001EN.LogBook = "somthing in the logbook";
////                if (!await AddObject("MWQMSubsectorLanguage", mwqmSubsector001EN)) return await Task.FromResult(false);

////                // MWQMSubsectorLanguage FR NB-06_020_001 TVItemID = 634
////                MWQMSubsectorLanguage mwqmSubsector001FR = dbCSSPDB.MWQMSubsectorLanguages.AsNoTracking().Where(c => c.MWQMSubsectorID == MWQMSubsector001ID && c.Language == LanguageEnum.fr).FirstOrDefault();
////                mwqmSubsector001FR.MWQMSubsectorID = mwqmSubsector001.MWQMSubsectorID;
////                mwqmSubsector001FR.LogBook = "somthing in the logbook";
////                if (!await AddObject("MWQMSubsectorLanguage", mwqmSubsector001FR)) return await Task.FromResult(false);
////                #endregion TVItem Subsector NB-06_020_001 
////                #region TVItem Subsector NB-06_020_002 
////                Console.WriteLine($"doing ... Subsector NB-06-020-002");
////                // TVItem Subsector NB-06_020_002 TVItemID = 635
////                TVItem tvItemNB_06_020_002 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 635).FirstOrDefault();
////                tvItemNB_06_020_002.ParentID = tvItemNB_06_020.TVItemID;
////                if (!await AddObject("TVItem", tvItemNB_06_020_002)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemNB_06_020_002, tvItemNB_06_020)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemNB_06_020_002, 635, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // TVItemLanguage EN NB-06_020_001 TVItemID = 635
////                TVItemLanguage tvItemLanguageENNB_06_020_002 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 635 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENNB_06_020_002.TVItemID = tvItemNB_06_020_002.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_002)) return await Task.FromResult(false);

////                // TVItemLanguage FR NB_06_020 TVItemID = 635
////                TVItemLanguage tvItemLanguageFRNB_06_020_002 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 635 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRNB_06_020_002.TVItemID = tvItemNB_06_020_002.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_002)) return await Task.FromResult(false);
////                #endregion TVItem Subsector NB-06_020_001 
////                #region MWQMSubsector NB-06_020_002 and MWQMSubsectorLanguage
////                Console.WriteLine($"doing ... MWQM Subsector NB-06-020-002");
////                // MWQMSubsector NB-06_020_002 TVItemID = 635
////                MWQMSubsector mwqmSubsector002 = dbCSSPDB.MWQMSubsectors.AsNoTracking().Where(c => c.MWQMSubsectorTVItemID == 635).FirstOrDefault();
////                int MWQMSubsector002ID = mwqmSubsector002.MWQMSubsectorID;
////                mwqmSubsector002.MWQMSubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
////                if (!await AddObject("MWQMSubsector", mwqmSubsector002)) return await Task.FromResult(false);

////                // MWQMSubsectorLanguage EN NB-06_020_002 TVItemID = 635
////                MWQMSubsectorLanguage mwqmSubsector002EN = dbCSSPDB.MWQMSubsectorLanguages.AsNoTracking().Where(c => c.MWQMSubsectorID == MWQMSubsector002ID && c.Language == LanguageEnum.en).FirstOrDefault();
////                mwqmSubsector002EN.MWQMSubsectorID = mwqmSubsector002.MWQMSubsectorID;
////                mwqmSubsector002EN.LogBook = "Something in the logbook";
////                if (!await AddObject("MWQMSubsectorLanguage", mwqmSubsector002EN)) return await Task.FromResult(false);

////                // MWQMSubsectorLanguage FR NB-06_020_002 TVItemID = 635
////                MWQMSubsectorLanguage mwqmSubsector002FR = dbCSSPDB.MWQMSubsectorLanguages.AsNoTracking().Where(c => c.MWQMSubsectorID == MWQMSubsector002ID && c.Language == LanguageEnum.fr).FirstOrDefault();
////                mwqmSubsector002FR.MWQMSubsectorID = mwqmSubsector002.MWQMSubsectorID;
////                mwqmSubsector002FR.LogBook = "Something in the logbook";
////                if (!await AddObject("MWQMSubsectorLanguage", mwqmSubsector002FR)) return await Task.FromResult(false);
////                #endregion TVItem Subsector NB-06_020_002 
////                #region TVItem Classification  and Classification
////                Console.WriteLine($"doing ... Classification");
////                // TVItem Classification where parent TVItemID = 635
////                List<TVItem> tvItemClassificationList = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.ParentID == 635 && c.TVType == TVTypeEnum.Classification).ToList();
////                foreach (TVItem tvItem in tvItemClassificationList)
////                {
////                    int oldTVItemID = tvItem.TVItemID;
////                    TVItem tvItemClassNew = tvItem;
////                    tvItemClassNew.ParentID = tvItemNB_06_020_002.TVItemID;
////                    if (!await AddObject("TVItem", tvItemClassNew)) return await Task.FromResult(false);
////                    if (!await CorrectTVPath(tvItemClassNew, tvItemNB_06_020_002)) return await Task.FromResult(false);
////                    if (!await AddMapInfo(tvItemClassNew, oldTVItemID, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                    // TVItemLanguage EN where parent TVItemID = 635
////                    TVItemLanguage tvItemLanguageENNClass = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == oldTVItemID && c.Language == LanguageEnum.en).FirstOrDefault();
////                    tvItemLanguageENNClass.TVItemID = tvItemClassNew.TVItemID;
////                    if (!await AddObject("TVItemLanguage", tvItemLanguageENNClass)) return await Task.FromResult(false);

////                    // TVItemLanguage FR NB_06_020 TVItemID = 635
////                    TVItemLanguage tvItemLanguageFRClass = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == oldTVItemID && c.Language == LanguageEnum.fr).FirstOrDefault();
////                    tvItemLanguageFRClass.TVItemID = tvItemClassNew.TVItemID;
////                    if (!await AddObject("TVItemLanguage", tvItemLanguageFRClass)) return await Task.FromResult(false);


////                    Classification classificaton = dbCSSPDB.Classifications.AsNoTracking().Where(c => c.ClassificationTVItemID == oldTVItemID).FirstOrDefault();
////                    Classification classificationNew = classificaton;
////                    classificationNew.ClassificationTVItemID = tvItemClassNew.TVItemID;
////                    if (!await AddObject("Classification", classificationNew)) return await Task.FromResult(false);
////                }
////                #endregion TVItem Classification and Classification
////                #region TideSites (Cap Pelé)
////                Console.WriteLine($"doing ... Cap Pelé");
////                // TVItem Cap Pelé TVItemID = 369979
////                TVItem tvItemCapPeleTideSite = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 369979).FirstOrDefault();
////                tvItemCapPeleTideSite.ParentID = tvItemNB.TVItemID;
////                if (!await AddObject("TVItem", tvItemCapPeleTideSite)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemCapPeleTideSite, tvItemNB)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemCapPeleTideSite, 369979, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // TVItemLanguage EN Cap Pelé TVItemID = 369979
////                TVItemLanguage tvItemLanguageENCapPele = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 369979 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENCapPele.TVItemID = tvItemCapPeleTideSite.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENCapPele)) return await Task.FromResult(false);

////                // TVItemLanguage FR Cap Pelé TVItemID = 369979
////                TVItemLanguage tvItemLanguageFRCapPele = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 369979 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRCapPele.TVItemID = tvItemCapPeleTideSite.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRCapPele)) return await Task.FromResult(false);

////                Console.WriteLine($"doing ... Tide Site");
////                // TideSite where TideSiteTVItemID = 369979
////                TideSite tideSite = dbCSSPDB.TideSites.AsNoTracking().Where(c => c.TideSiteTVItemID == 369979).FirstOrDefault();
////                tideSite.TideSiteTVItemID = tvItemCapPeleTideSite.TVItemID;
////                if (!await AddObject("TideSite", tideSite)) return await Task.FromResult(false);
////                #endregion TideSites
////                #region TideDataValues
////                // TideDataValue
////                List<TideDataValue> tideDataValueList = dbCSSPDB.TideDataValues.AsNoTracking().ToList();
////                if (tideDataValueList.Count > 0)
////                {
////                    foreach (TideDataValue tideDataValue in tideDataValueList)
////                    {
////                        tideDataValue.TideSiteTVItemID = tideSite.TideSiteTVItemID;
////                        if (!await AddObject("TideDataValue", tideDataValue)) return await Task.FromResult(false);
////                    }
////                }
////                else
////                {
////                    TideDataValue tideDataValue = new TideDataValue()
////                    {
////                        DateTime_Local = DateTime.Now,
////                        Depth_m = 23.2f,
////                        Keep = true,
////                        StorageDataType = StorageDataTypeEnum.Archived,
////                        TideDataType = TideDataTypeEnum.Min15,
////                        TideEnd = TideTextEnum.HighTide,
////                        TideStart = TideTextEnum.HighTide,
////                        TideSiteTVItemID = tideSite.TideSiteTVItemID,
////                        UVelocity_m_s = 0.4f,
////                        VVelocity_m_s = 0.3f,
////                        LastUpdateDate_UTC = DateTime.Now,
////                        LastUpdateContactTVItemID = 2,
////                    };
////                    if (!await AddObject("TideDataValue", tideDataValue)) return await Task.FromResult(false);
////                }
////                #endregion TideDataValues
////                #region TVItem Municipality Bouctouche
////                Console.WriteLine($"doing ... Bouctouche");
////                // TVItem Municipality Bouctouche TVItemID = 27764
////                TVItem tvItemBouctouche = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 27764).FirstOrDefault();
////                tvItemBouctouche.ParentID = tvItemNB.TVItemID;
////                if (!await AddObject("TVItem", tvItemBouctouche)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemBouctouche, tvItemNB)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemBouctouche, 27764, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // TVItemLanguage EN Bouctouche TVItemID = 27764
////                TVItemLanguage tvItemLanguageENBouctouche = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 27764 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENBouctouche.TVItemID = tvItemBouctouche.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENBouctouche)) return await Task.FromResult(false);

////                // TVItemLanguage FR Bouctouche TVItemID = 27764
////                TVItemLanguage tvItemLanguageFRBouctouche = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 27764 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRBouctouche.TVItemID = tvItemBouctouche.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRBouctouche)) return await Task.FromResult(false);
////                #endregion TVItem Municipality Bouctouche
////                #region TVItem Municipality Ste Marie de Kent 
////                Console.WriteLine($"doing ... Ste-Marie-de-Kent");
////                // TVItem Municipality Ste Marie de Kent TVItemID = 44855
////                TVItem tvItemSteMarieDeKent = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 44855).FirstOrDefault();
////                tvItemSteMarieDeKent.ParentID = tvItemNB.TVItemID;
////                if (!await AddObject("TVItem", tvItemSteMarieDeKent)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemSteMarieDeKent, tvItemNB)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemSteMarieDeKent, 44855, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // TVItemLanguage EN Ste Marie de Kent TVItemID = 44855
////                TVItemLanguage tvItemLanguageENSteMarieDeKent = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 44855 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENSteMarieDeKent.TVItemID = tvItemSteMarieDeKent.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENSteMarieDeKent)) return await Task.FromResult(false);

////                // TVItemLanguage FR Ste Marie de Kent TVItemID = 44855
////                TVItemLanguage tvItemLanguageFRSteMarieDeKent = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 44855 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRSteMarieDeKent.TVItemID = tvItemSteMarieDeKent.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRSteMarieDeKent)) return await Task.FromResult(false);
////                #endregion TVItem Municipality Ste Marie de Kent 
////                #region TVItem Municipality Bouctouche WWTP 
////                Console.WriteLine($"doing ... Bouctouche WWTP");
////                // TVItem Municipality Bouctouche WWTP TVItemID = 28689
////                TVItem tvItemBouctoucheWWTP = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 28689).FirstOrDefault();
////                tvItemBouctoucheWWTP.ParentID = tvItemBouctouche.TVItemID;
////                if (!await AddObject("TVItem", tvItemBouctoucheWWTP)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemBouctoucheWWTP, tvItemBouctouche)) return await Task.FromResult(false);
////                tvItemBouctoucheWWTP.TVType = TVTypeEnum.WasteWaterTreatmentPlant;
////                if (!await AddMapInfo(tvItemBouctoucheWWTP, 28689, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);
////                tvItemBouctoucheWWTP.TVType = TVTypeEnum.Infrastructure;

////                // TVItemLanguage EN Bouctouche WWTP TVItemID = 28689
////                TVItemLanguage tvItemLanguageENBouctoucheWWTP = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28689 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENBouctoucheWWTP.TVItemID = tvItemBouctoucheWWTP.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENBouctoucheWWTP)) return await Task.FromResult(false);

////                // TVItemLanguage FR Bouctouche WWTP TVItemID = 28689
////                TVItemLanguage tvItemLanguageFRBouctoucheWWTP = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28689 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRBouctoucheWWTP.TVItemID = tvItemBouctoucheWWTP.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRBouctoucheWWTP)) return await Task.FromResult(false);
////                #endregion TVItem Municipality Bouctouche WWTP 
////                #region ReportType and ReportTypeLanguage
////                Console.WriteLine($"doing ... ReportTypes and ReportTypeLanguages");
////                ReportType reportType = dbCSSPDB.ReportTypes.AsNoTracking().FirstOrDefault();
////                int ReportTypeIDOld = reportType.ReportTypeID;
////                reportType.ReportTypeID = 0;
////                if (!await AddObject("ReportType", reportType)) return await Task.FromResult(false);

////                //// ReportTypeLanguage EN 
////                //ReportTypeLanguage reportTypeLanguageEN = dbCSSPDB.ReportTypeLanguages.AsNoTracking().Where(c => c.ReportTypeID == ReportTypeIDOld && c.Language == LanguageEnum.en).FirstOrDefault();
////                //reportTypeLanguageEN.ReportTypeLanguageID = 0;
////                //reportTypeLanguageEN.ReportTypeID = reportType.ReportTypeID;
////                //if (!await AddObject("ReportTypeLanguage", reportTypeLanguageEN)) return await Task.FromResult(false);

////                //// ReportTypeLanguage FR 
////                //ReportTypeLanguage reportTypeLanguageFR = dbCSSPDB.ReportTypeLanguages.AsNoTracking().Where(c => c.ReportTypeID == ReportTypeIDOld && c.Language == LanguageEnum.fr).FirstOrDefault();
////                //reportTypeLanguageFR.ReportTypeLanguageID = 0;
////                //reportTypeLanguageFR.ReportTypeID = reportType.ReportTypeID;
////                //if (!await AddObject("ReportTypeLanguage", reportTypeLanguageFR)) return await Task.FromResult(false);
////                #endregion ReportType and ReportTypeLanguage
////                #region ReportSection and ReportSectionLanguage
////                Console.WriteLine($"doing ... ReportSections and ReportSectionLanguages");
////                ReportSection reportSection = dbCSSPDB.ReportSections.AsNoTracking().Where(c => c.ReportTypeID == ReportTypeIDOld).FirstOrDefault();
////                int ReportSectionIDOld = reportSection.ReportSectionID;
////                reportSection.ReportSectionID = 0;
////                reportSection.ReportTypeID = reportType.ReportTypeID;
////                if (!await AddObject("ReportSection", reportSection)) return await Task.FromResult(false);

////                //// ReportSectionLanguage EN 
////                //ReportSectionLanguage reportSectionLanguageEN = dbCSSPDB.ReportSectionLanguages.AsNoTracking().Where(c => c.ReportSectionID == ReportSectionIDOld && c.Language == LanguageEnum.en).FirstOrDefault();
////                //reportSectionLanguageEN.ReportSectionLanguageID = 0;
////                //reportSectionLanguageEN.ReportSectionID = reportSection.ReportSectionID;
////                //if (!await AddObject("ReportSectionLanguage", reportSectionLanguageEN)) return await Task.FromResult(false);

////                //// ReportSectionLanguage FR 
////                //ReportSectionLanguage reportSectionLanguageFR = dbCSSPDB.ReportSectionLanguages.AsNoTracking().Where(c => c.ReportSectionID == ReportSectionIDOld && c.Language == LanguageEnum.fr).FirstOrDefault();
////                //reportSectionLanguageFR.ReportSectionLanguageID = 0;
////                //reportSectionLanguageFR.ReportSectionID = reportSection.ReportSectionID;
////                //if (!await AddObject("ReportSectionLanguage", reportSectionLanguageFR)) return await Task.FromResult(false);
////                #endregion ReportSection and ReportSectionLanguage
////                #region TVItem TVFile Bouctouche WWTP 
////                Console.WriteLine($"doing ... Bouctouche WWTP TVFile");
////                // TVItem TVFile Bouctouche WWTP TVItemID = 28689
////                TVItem TempBouctWWTP = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 28689).FirstOrDefault();
////                TVItem tvItemBouctoucheWWTPTVFile = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVPath.StartsWith($"{ TempBouctWWTP.TVPath }p") && c.TVType == TVTypeEnum.File).FirstOrDefault();
////                int TempTVItemID = tvItemBouctoucheWWTPTVFile.TVItemID;
////                tvItemBouctoucheWWTPTVFile.ParentID = tvItemBouctoucheWWTP.TVItemID;
////                if (!await AddObject("TVItem", tvItemBouctoucheWWTPTVFile)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemBouctoucheWWTPTVFile, tvItemBouctoucheWWTP)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemBouctoucheWWTPTVFile, TempTVItemID, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // TVItemLanguage EN TVItem for Image for Bouctouche WWTP TVItemID = 28689
////                TVItemLanguage tvItemBouctoucheWWTPTVFileImageEN = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == TempTVItemID && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemBouctoucheWWTPTVFileImageEN.TVItemID = tvItemBouctoucheWWTPTVFile.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemBouctoucheWWTPTVFileImageEN)) return await Task.FromResult(false);

////                // TVItemLanguage FR TVItem for Image for Bouctouche WWTP TVItemID = 28689
////                TVItemLanguage tvItemBouctoucheWWTPTVFileImageFR = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == TempTVItemID && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemBouctoucheWWTPTVFileImageFR.TVItemID = tvItemBouctoucheWWTPTVFile.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemBouctoucheWWTPTVFileImageFR)) return await Task.FromResult(false);
////                #endregion TVItem TVFile Bouctouche WWTP 
////                #region TVFile Bouctouche WWTP 
////                Console.WriteLine($"doing ... Bouctouche WWTP TVFile");
////                // TVFile Bouctouche WWTP TVItemID = 28689
////                TVFile tvFileBouctoucheWWTP = dbCSSPDB.TVFiles.AsNoTracking().Where(c => c.TVFileTVItemID == TempTVItemID).FirstOrDefault();
////                int TVFileID = tvFileBouctoucheWWTP.TVFileID;
////                tvFileBouctoucheWWTP.TVFileTVItemID = tvItemBouctoucheWWTPTVFile.TVItemID;
////                if (!await AddObject("TVFile", tvFileBouctoucheWWTP)) return await Task.FromResult(false);

////                // TVFileLanguage EN Bouctouche WWTP TVItemID = 28689
////                TVFileLanguage tvFileLanguageENBouctoucheWWTP = dbCSSPDB.TVFileLanguages.AsNoTracking().Where(c => c.TVFileID == TVFileID && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvFileLanguageENBouctoucheWWTP.TVFileID = tvFileBouctoucheWWTP.TVFileID;
////                if (!await AddObject("TVFileLanguage", tvFileLanguageENBouctoucheWWTP)) return await Task.FromResult(false);

////                // TVFileLanguage FR Bouctouche WWTP TVItemID = 28689
////                TVFileLanguage tvFileLanguageFRBouctoucheWWTP = dbCSSPDB.TVFileLanguages.AsNoTracking().Where(c => c.TVFileID == TVFileID && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvFileLanguageFRBouctoucheWWTP.TVFileID = tvFileBouctoucheWWTP.TVFileID;
////                if (!await AddObject("TVFileLanguage", tvFileLanguageFRBouctoucheWWTP)) return await Task.FromResult(false);
////                #endregion TVFile Bouctouche WWTP 
////                #region Infrastructure Bouctouche WWTP
////                Console.WriteLine($"doing ... Bouctouche WWTP Infrastructure");
////                // Infrastructure Bouctouche WWTP TVItemID = 28689
////                Infrastructure infrastructureBouctoucheWWTP = dbCSSPDB.Infrastructures.AsNoTracking().Where(c => c.InfrastructureTVItemID == 28689).FirstOrDefault();
////                int InfrastructureID = infrastructureBouctoucheWWTP.InfrastructureID;
////                infrastructureBouctoucheWWTP.InfrastructureTVItemID = tvItemBouctoucheWWTP.TVItemID;
////                if (!await AddObject("Infrastructure", infrastructureBouctoucheWWTP)) return await Task.FromResult(false);

////                // InfrastructureLanguage EN Bouctouche WWTP TVItemID = 28689
////                InfrastructureLanguage infrastructureLanguageENBouctoucheWWTP = dbCSSPDB.InfrastructureLanguages.AsNoTracking().Where(c => c.InfrastructureID == InfrastructureID && c.Language == LanguageEnum.en).FirstOrDefault();
////                infrastructureLanguageENBouctoucheWWTP.InfrastructureID = infrastructureBouctoucheWWTP.InfrastructureID;
////                if (!await AddObject("InfrastructureLanguage", infrastructureLanguageENBouctoucheWWTP)) return await Task.FromResult(false);

////                // InfrastructureLanguage FR Bouctouche WWTP TVItemID = 28689
////                InfrastructureLanguage infrastructureLanguageFRBouctoucheWWTP = dbCSSPDB.InfrastructureLanguages.AsNoTracking().Where(c => c.InfrastructureID == InfrastructureID && c.Language == LanguageEnum.fr).FirstOrDefault();
////                infrastructureLanguageFRBouctoucheWWTP.InfrastructureID = infrastructureBouctoucheWWTP.InfrastructureID;
////                if (!await AddObject("InfrastructureLanguage", infrastructureLanguageFRBouctoucheWWTP)) return await Task.FromResult(false);
////                #endregion Infrastructure Bouctouche WWTP
////                #region BoxModel Bouctouche WWTP
////                Console.WriteLine($"doing ... Bouctouche WWTP Infrastructure Box Model");
////                // BoxModel Bouctouche WWTP TVItemID = 28689
////                BoxModel boxModel = dbCSSPDB.BoxModels.AsNoTracking().Where(c => c.InfrastructureTVItemID == 28689).FirstOrDefault();
////                int BoxModelID = boxModel.BoxModelID;
////                boxModel.InfrastructureTVItemID = tvItemBouctoucheWWTP.TVItemID;
////                if (!await AddObject("BoxModel", boxModel)) return await Task.FromResult(false);

////                // BoxModelLanguage EN Bouctouche WWTP TVItemID = 28689
////                BoxModelLanguage boxModelLanguageEN = dbCSSPDB.BoxModelLanguages.AsNoTracking().Where(c => c.BoxModelID == BoxModelID && c.Language == LanguageEnum.en).FirstOrDefault();
////                boxModelLanguageEN.BoxModelID = boxModel.BoxModelID;
////                if (!await AddObject("BoxModelLanguage", boxModelLanguageEN)) return await Task.FromResult(false);

////                // BoxModelLanguage FR Bouctouche WWTP TVItemID = 28689
////                BoxModelLanguage boxModelLanguageFR = dbCSSPDB.BoxModelLanguages.AsNoTracking().Where(c => c.BoxModelID == BoxModelID && c.Language == LanguageEnum.fr).FirstOrDefault();
////                boxModelLanguageFR.BoxModelID = boxModel.BoxModelID;
////                if (!await AddObject("BoxModelLanguage", boxModelLanguageFR)) return await Task.FromResult(false);
////                #endregion BoxModel Bouctouche WWTP
////                #region BoxModelResult Bouctouche WWTP
////                Console.WriteLine($"doing ... Bouctouche WWTP Infrastructure Box Model Result");

////                // BoxModelResult Bouctouche WWTP TVItemID = 28689
////                for (int i = 1; i < 6; i++)
////                {
////                    BoxModelResultTypeEnum boxModelResultTypeEnum = (BoxModelResultTypeEnum)i;
////                    BoxModelResult boxModelResult = dbCSSPDB.BoxModelResults.AsNoTracking().Where(c => c.BoxModelID == BoxModelID && c.BoxModelResultType == boxModelResultTypeEnum).FirstOrDefault();
////                    boxModelResult.BoxModelID = boxModel.BoxModelID;
////                    if (!await AddObject("BoxModelResult", boxModelResult)) return await Task.FromResult(false);
////                }
////                #endregion BoxModelResult Bouctouche WWTP
////                #region CoCoRaHSSite and CoCoRaHSValue
////                Console.WriteLine($"doing ... CoCoRaHSSite and CoCoRaHSValue");
////                // BoxModel Bouctouche WWTP TVItemID = 28689
////                List<CoCoRaHSSite> coCoRaHSSiteList = dbCSSPDB.CoCoRaHSSites.AsNoTracking().Take(10).ToList();
////                foreach (CoCoRaHSSite coCoRaHSSite in coCoRaHSSiteList)
////                {
////                    int CoCoRaHSSiteID = coCoRaHSSite.CoCoRaHSSiteID;

////                    if (!await AddObject("CoCoRaHSSite", coCoRaHSSite)) return await Task.FromResult(false);

////                    List<CoCoRaHSValue> coCoRaHSValueList = dbCSSPDB.CoCoRaHSValues.Where(c => c.CoCoRaHSSiteID == CoCoRaHSSiteID).AsNoTracking().Take(10).ToList();
////                    foreach (CoCoRaHSValue coCoRaHSValue in coCoRaHSValueList)
////                    {
////                        coCoRaHSValue.CoCoRaHSSiteID = coCoRaHSSite.CoCoRaHSSiteID;

////                        if (!await AddObject("CoCoRaHSValue", coCoRaHSValue)) return await Task.FromResult(false);
////                    }
////                }
////                #endregion CoCoRaHSSite and CoCoRaHSValue
////                #region VPScenario Bouctouche WWTP 
////                Console.WriteLine($"doing ... Bouctouche WWTP Infrastructure VPScenario");

////                // VPScenario Bouctouche WWTP TVItemID = 28689
////                VPScenario VPScenario = dbCSSPDB.VPScenarios.AsNoTracking().Where(c => c.InfrastructureTVItemID == 28689).FirstOrDefault();
////                int VPScenarioID = VPScenario.VPScenarioID;
////                VPScenario.InfrastructureTVItemID = tvItemBouctoucheWWTP.TVItemID;
////                if (!await AddObject("VPScenario", VPScenario)) return await Task.FromResult(false);

////                // VPScenarioLanguage EN Bouctouche WWTP TVItemID = 28689
////                VPScenarioLanguage VPScenarioLanguageEN = dbCSSPDB.VPScenarioLanguages.AsNoTracking().Where(c => c.VPScenarioID == VPScenarioID && c.Language == LanguageEnum.en).FirstOrDefault();
////                VPScenarioLanguageEN.VPScenarioID = VPScenario.VPScenarioID;
////                if (!await AddObject("VPScenarioLanguage", VPScenarioLanguageEN)) return await Task.FromResult(false);

////                // VPScenarioLanguage FR Bouctouche WWTP TVItemID = 28689
////                VPScenarioLanguage VPScenarioLanguageFR = dbCSSPDB.VPScenarioLanguages.AsNoTracking().Where(c => c.VPScenarioID == VPScenarioID && c.Language == LanguageEnum.fr).FirstOrDefault();
////                VPScenarioLanguageFR.VPScenarioID = VPScenario.VPScenarioID;
////                if (!await AddObject("VPScenarioLanguage", VPScenarioLanguageFR)) return await Task.FromResult(false);

////                // VPAmbient Bouctouche WWTP TVItemID = 28689
////                List<VPAmbient> VPAmbientList = dbCSSPDB.VPAmbients.AsNoTracking().Where(c => c.VPScenarioID == VPScenarioID).ToList();
////                foreach (VPAmbient vpAmbient in VPAmbientList)
////                {
////                    vpAmbient.VPScenarioID = VPScenario.VPScenarioID;
////                    if (!await AddObject("VPAmbient", vpAmbient)) return await Task.FromResult(false);
////                }

////                // VPAmbient Bouctouche WWTP TVItemID = 28689
////                List<VPResult> VPResultList = dbCSSPDB.VPResults.AsNoTracking().Where(c => c.VPScenarioID == VPScenarioID).Take(5).ToList();
////                foreach (VPResult vpResult in VPResultList)
////                {
////                    vpResult.VPScenarioID = VPScenario.VPScenarioID;
////                    if (!await AddObject("VPResult", vpResult)) return await Task.FromResult(false);
////                }
////                #endregion VPScenario Bouctouche WWTP 
////                #region TVItem Municipality Bouctouche LS 2 Rue Acadie
////                Console.WriteLine($"doing ... Bouctouche LS 2");

////                // TVItem Municipality Bouctouche LS 2 Rue Acadie TVItemID = 28695
////                TVItem tvItemBouctoucheLS2RueAcadie = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 28695).FirstOrDefault();
////                tvItemBouctoucheLS2RueAcadie.ParentID = tvItemCapPeleTideSite.TVItemID;
////                if (!await AddObject("TVItem", tvItemBouctoucheLS2RueAcadie)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemBouctoucheLS2RueAcadie, tvItemCapPeleTideSite)) return await Task.FromResult(false);
////                tvItemBouctoucheLS2RueAcadie.TVType = TVTypeEnum.LiftStation;
////                if (!await AddMapInfo(tvItemBouctoucheLS2RueAcadie, 28695, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);
////                tvItemBouctoucheLS2RueAcadie.TVType = TVTypeEnum.Infrastructure;

////                // TVItemLanguage EN Bouctouche LS 2 Rue Acadie TVItemID = 28695
////                TVItemLanguage tvItemLanguageENBouctoucheLS2RueAcadie = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28695 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENBouctoucheLS2RueAcadie.TVItemID = tvItemBouctoucheLS2RueAcadie.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENBouctoucheLS2RueAcadie)) return await Task.FromResult(false);

////                // TVItemLanguage FR Bouctouche LS 2 Rue Acadie TVItemID = 28695
////                TVItemLanguage tvItemLanguageFRBouctoucheLS2RueAcadie = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28695 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRBouctoucheLS2RueAcadie.TVItemID = tvItemBouctoucheLS2RueAcadie.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRBouctoucheLS2RueAcadie)) return await Task.FromResult(false);
////                #endregion TVItem Municipality Bouctouche LS 2 Rue Acadie
////                #region TVItem Subsector NB-06_020_002 MWQM Site 0001
////                Console.WriteLine($"doing ... Subsector NB-06-020-002 MWQM site 001");
////                // TVItem Subsector NB-06_020_002 MWQM Site 0001 TVItemID = 7460
////                TVItem tvItemNB_06_020_002Site0001 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 7460).FirstOrDefault();
////                int MWQMSiteID0001 = tvItemNB_06_020_002Site0001.TVItemID;
////                tvItemNB_06_020_002Site0001.ParentID = tvItemNB_06_020_002.TVItemID;
////                if (!await AddObject("TVItem", tvItemNB_06_020_002Site0001)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemNB_06_020_002Site0001, tvItemNB_06_020_002)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemNB_06_020_002Site0001, 7460, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // TVItemLanguage EN NB-06_020_001 TVItemID = 7460
////                TVItemLanguage tvItemLanguageENNB_06_020_002Site0001 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7460 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENNB_06_020_002Site0001.TVItemID = tvItemNB_06_020_002Site0001.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_002Site0001)) return await Task.FromResult(false);

////                // TVItemLanguage FR NB_06_020 TVItemID = 7460
////                TVItemLanguage tvItemLanguageFRNB_06_020_002Site0001 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7460 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRNB_06_020_002Site0001.TVItemID = tvItemNB_06_020_002Site0001.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_002Site0001)) return await Task.FromResult(false);
////                #endregion TVItem Subsector NB-06_020_002 MWQM Site 0001
////                #region TVItem Subsector NB-06_020_002 MWQM Site 0002
////                Console.WriteLine($"doing ... Subsector NB-06-020-002 MWQM site 002");
////                // TVItem Subsector NB-06_020_002 MWQM Site 0001 TVItemID = 7462
////                TVItem tvItemNB_06_020_002Site0002 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 7462).FirstOrDefault();
////                int MWQMSiteID0002 = tvItemNB_06_020_002Site0002.TVItemID;
////                tvItemNB_06_020_002Site0002.ParentID = tvItemNB_06_020_002.TVItemID;
////                if (!await AddObject("TVItem", tvItemNB_06_020_002Site0002)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemNB_06_020_002Site0002, tvItemNB_06_020_002)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemNB_06_020_002Site0002, 7462, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // TVItemLanguage EN NB-06_020_001 TVItemID = 7462
////                TVItemLanguage tvItemLanguageENNB_06_020_002Site0002 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7462 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENNB_06_020_002Site0002.TVItemID = tvItemNB_06_020_002Site0002.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_002Site0002)) return await Task.FromResult(false);

////                // TVItemLanguage FR NB_06_020 TVItemID = 7462
////                TVItemLanguage tvItemLanguageFRNB_06_020_002Site0002 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7462 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRNB_06_020_002Site0002.TVItemID = tvItemNB_06_020_002Site0002.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_002Site0002)) return await Task.FromResult(false);
////                #endregion TVItem Subsector NB-06_020_002 MWQM Site 0002
////                #region TVItem Address and Address
////                Console.WriteLine($"doing ... Address");
////                // TVItem Address 730 Chemin de la Pointe, Richibouctou, NB E4W, Canada TVItemID = 232655
////                TVItem tvItemAddress = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 232655).FirstOrDefault();
////                tvItemAddress.ParentID = tvItemRoot.TVItemID;
////                if (!await AddObject("TVItem", tvItemAddress)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemAddress, tvItemRoot)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemAddress, 232655, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // Address 730 Chemin de la Pointe, Richibouctou, NB E4W, Canada TVItemID = 232655
////                Address address = dbCSSPDB.Addresses.AsNoTracking().Where(c => c.AddressTVItemID == 232655).FirstOrDefault();
////                address.AddressTVItemID = tvItemAddress.TVItemID;
////                address.CountryTVItemID = tvItemCanada.TVItemID;
////                address.ProvinceTVItemID = tvItemNB.TVItemID;
////                address.MunicipalityTVItemID = tvItemBouctouche.TVItemID;
////                if (!await AddObject("Address", address)) return await Task.FromResult(false);

////                //string TVText = "";
////                //using (CSSPDBContext db2 = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
////                //{
////                //    AddressService addressService = new AddressService(new Query(), db2, contactCharles.ContactID);
////                //    TVText = addressService.FillAddressTVText(address);
////                //}

////                // TVItem Address 730 Chemin de la Pointe, Richibouctou, NB E4W, Canada TVItemID = 232655
////                TVItemLanguage tvItemLanguageENAddress = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 232655 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENAddress.TVItemID = tvItemAddress.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENAddress)) return await Task.FromResult(false);

////                // TVItem Address 730 Chemin de la Pointe, Richibouctou, NB E4W, Canada TVItemID = 232655
////                TVItemLanguage tvItemLanguageFRAddress = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 232655 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRAddress.TVItemID = tvItemAddress.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRAddress)) return await Task.FromResult(false);
////                #endregion TVItem Address and Address
////                #region TVItem Subsector NB-06_020_002 Pol Source Site 000023
////                Console.WriteLine($"doing ... Subsector NB-06-020-002 PolSource site 00023");
////                // TVItem Subsector NB-06_020_002 Pol Source Site 000023 TVItemID = 202466
////                TVItem tvItemNB_06_020_002PolSite000023 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 202466).FirstOrDefault();
////                tvItemNB_06_020_002PolSite000023.ParentID = tvItemNB_06_020_002.TVItemID;
////                if (!await AddObject("TVItem", tvItemNB_06_020_002PolSite000023)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemNB_06_020_002PolSite000023, tvItemNB_06_020_002)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemNB_06_020_002PolSite000023, 202466, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // TVItemLanguage EN Subsector NB-06_020_002 Pol Source Site 000023 TVItemID = 202466
////                TVItemLanguage tvItemLanguageENNB_06_020_002PolSite000023 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 202466 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENNB_06_020_002PolSite000023.TVItemID = tvItemNB_06_020_002PolSite000023.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_002PolSite000023)) return await Task.FromResult(false);

////                // TVItemLanguage FR Subsector NB-06_020_002 Pol Source Site 000023 TVItemID = 202466
////                TVItemLanguage tvItemLanguageFRNB_06_020_002PolSite000023 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 202466 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRNB_06_020_002PolSite000023.TVItemID = tvItemNB_06_020_002PolSite000023.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_002PolSite000023)) return await Task.FromResult(false);
////                #endregion TVItem Subsector NB-06_020_002 Pol Source Site 000023
////                #region PolSourceSite, PolSourceObservation, PolSourceObservationIssue Subsector NB-06_020_002 Pol Source Site 000023
////                Console.WriteLine($"doing ... Subsector NB-06-020-002 PolSource site 00023 Observation");
////                // PolSourceSite with PolSourceSiteTVItemID = 202466
////                PolSourceSite polSourceSitePolSite000023 = dbCSSPDB.PolSourceSites.AsNoTracking().Where(c => c.PolSourceSiteTVItemID == 202466).FirstOrDefault();
////                int PolSourceSiteID = polSourceSitePolSite000023.PolSourceSiteID;
////                polSourceSitePolSite000023.PolSourceSiteTVItemID = tvItemNB_06_020_002PolSite000023.TVItemID;
////                if (polSourceSitePolSite000023.CivicAddressTVItemID != null)
////                {
////                    polSourceSitePolSite000023.CivicAddressTVItemID = tvItemAddress.TVItemID;
////                }
////                if (!await AddObject("PolSourceSite", polSourceSitePolSite000023)) return await Task.FromResult(false);

////                // PolSourceObservation with PolSourceSiteTVItemID = 202466
////                PolSourceObservation polSourceSitePolSite000023Obs = dbCSSPDB.PolSourceObservations.AsNoTracking().Where(c => c.PolSourceSiteID == PolSourceSiteID).FirstOrDefault();
////                int PolSourceObservationID = polSourceSitePolSite000023Obs.PolSourceObservationID;
////                polSourceSitePolSite000023Obs.ContactTVItemID = contactCharles.ContactTVItemID;
////                polSourceSitePolSite000023Obs.PolSourceSiteID = polSourceSitePolSite000023.PolSourceSiteID;
////                if (!await AddObject("PolSourceObservation", polSourceSitePolSite000023Obs)) return await Task.FromResult(false);

////                // PolSourceObservationIssue with PolSourceSiteTVItemID = 202466
////                PolSourceObservationIssue polSourceSitePolSite000023ObsIssue = dbCSSPDB.PolSourceObservationIssues.AsNoTracking().Where(c => c.PolSourceObservationID == PolSourceObservationID).FirstOrDefault();
////                int PolSourceObservationIssueID = polSourceSitePolSite000023ObsIssue.PolSourceObservationIssueID;
////                polSourceSitePolSite000023ObsIssue.PolSourceObservationID = polSourceSitePolSite000023Obs.PolSourceSiteID;
////                if (!await AddObject("PolSourceObservationIssue", polSourceSitePolSite000023ObsIssue)) return await Task.FromResult(false);
////                #endregion PolSourceSite, PolSourceObservation, PolSourceObservationIssue Subsector NB-06_020_002 Pol Source Site 000023
////                #region PolSourceSite, PolSourceObservation, PolSourceObservationIssue Subsector NB-06_020_002 Pol Source Site 000024
////                Console.WriteLine($"doing ... Subsector NB-06-020-002 PolSource site 00024");
////                // TVItem Subsector NB-06_020_002 Pol Source Site 000024 TVItemID = 202467
////                TVItem tvItemNB_06_020_002PolSite000024 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 202467).FirstOrDefault();
////                tvItemNB_06_020_002PolSite000024.ParentID = tvItemNB_06_020_002.TVItemID;
////                if (!await AddObject("TVItem", tvItemNB_06_020_002PolSite000024)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemNB_06_020_002PolSite000024, tvItemNB_06_020_002)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemNB_06_020_002PolSite000024, 202467, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // TVItemLanguage EN NB-06_020_001 TVItemID = 202467
////                TVItemLanguage tvItemLanguageENNB_06_020_00PolSite000024 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 202467 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENNB_06_020_00PolSite000024.TVItemID = tvItemNB_06_020_002PolSite000024.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_00PolSite000024)) return await Task.FromResult(false);

////                // TVItemLanguage FR NB_06_020 TVItemID = 202467
////                TVItemLanguage tvItemLanguageFRNB_06_020_002PolSite000024 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 202467 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRNB_06_020_002PolSite000024.TVItemID = tvItemNB_06_020_002PolSite000024.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_002PolSite000024)) return await Task.FromResult(false);
////                #endregion PolSourceSite, PolSourceObservation, PolSourceObservationIssue Subsector NB-06_020_002 Pol Source Site 000024
////                #region DrogueRun, DrogueRunPositon Subsector NB-06_020_002
////                Console.WriteLine($"doing ... Subsector NB-06-020-002 DrogueRun");
////                DrogueRun drogueRun = dbCSSPDB.DrogueRuns.AsNoTracking().FirstOrDefault();
////                int DrogueRunID = drogueRun.DrogueRunID;
////                drogueRun.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
////                if (!await AddObject("DrogueRun", drogueRun)) return await Task.FromResult(false);

////                // DrogueRunPosition
////                List<DrogueRunPosition> drogueRunPositionList = dbCSSPDB.DrogueRunPositions.AsNoTracking().Where(c => c.DrogueRunID == DrogueRunID).ToList();
////                foreach (DrogueRunPosition drogueRunPosition in drogueRunPositionList.Take(10))
////                {
////                    int DrogueRunPositionID = drogueRunPosition.DrogueRunPositionID;
////                    drogueRunPosition.DrogueRunID = drogueRun.DrogueRunID;
////                    if (!await AddObject("DrogueRunPosition", drogueRunPosition)) return await Task.FromResult(false);
////                }
////                #endregion DrogueRun, DrogueRunPositon Subsector NB-06_020_002
////                #region HelpDoc
////                Console.WriteLine($"doing ... HelpDoc");
////                HelpDoc helpDoc = dbCSSPDB.HelpDocs.AsNoTracking().FirstOrDefault();
////                int HelpDocID = helpDoc.HelpDocID;
////                if (!await AddObject("HelpDoc", helpDoc)) return await Task.FromResult(false);
////                #endregion HelpDoc
////                #region TVItem SamplingPlan, SamplingPlanSubsector, SamplingPlanSubsectorSite, SamplingPlanEmail
////                Console.WriteLine($"doing ... Sampling Plan");
////                // NB TVItem Sampling Plan with SamplingPlanID = 78 and TVFileTVItemID = 370708
////                TVItem tvItemNBSamplingPlanFileTVItem = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 370708).FirstOrDefault();
////                tvItemNBSamplingPlanFileTVItem.ParentID = tvItemNB.TVItemID;
////                if (!await AddObject("TVItem", tvItemNBSamplingPlanFileTVItem)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemNBSamplingPlanFileTVItem, tvItemNB)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemNBSamplingPlanFileTVItem, 370708, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // NB EN TVItem Sampling Plan with SamplingPlanID = 78 and TVFileTVItemID = 370708
////                TVItemLanguage tvItemLanguageENNBSamplingPlanFileTVItem = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 370708 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENNBSamplingPlanFileTVItem.TVItemID = tvItemNBSamplingPlanFileTVItem.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENNBSamplingPlanFileTVItem)) return await Task.FromResult(false);

////                // NB FR TVItem Sampling Plan with SamplingPlanID = 78 and TVFileTVItemID = 370708
////                TVItemLanguage tvItemLanguageFRNBSamplingPlanFileTVItem = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 370708 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRNBSamplingPlanFileTVItem.TVItemID = tvItemNBSamplingPlanFileTVItem.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRNBSamplingPlanFileTVItem)) return await Task.FromResult(false);

////                // NB TVFile Sampling Plan with SamplingPlanID = 78 and TVFileTVItemID = 370708
////                TVFile tvFile = dbCSSPDB.TVFiles.AsNoTracking().Where(c => c.TVFileTVItemID == 370708).FirstOrDefault();
////                //int TVFileID = tvFile.TVFileID;
////                tvFile.TVFileTVItemID = tvItemNBSamplingPlanFileTVItem.TVItemID;
////                if (!await AddObject("TVFile", tvFile)) return await Task.FromResult(false);

////                // NB Sampling Plan with SamplingPlanID = 78
////                SamplingPlan samplingPlan = dbCSSPDB.SamplingPlans.AsNoTracking().Where(c => c.SamplingPlanID == 78).FirstOrDefault();
////                int SamplingPlanID = samplingPlan.SamplingPlanID;
////                samplingPlan.CreatorTVItemID = tvItemContactCharles.TVItemID;
////                samplingPlan.ProvinceTVItemID = tvItemNB.TVItemID;
////                samplingPlan.SamplingPlanFileTVItemID = tvFile.TVFileTVItemID;
////                samplingPlan.ApprovalCode = "aaabbb";
////                if (!await AddObject("SamplingPlan", samplingPlan)) return await Task.FromResult(false);

////                // NB Sampling Plan with SamplingPlanID = 78 with SubsectorTVItemID = 635 (Bouctouche harbour)
////                SamplingPlanSubsector samplingPlanSubsector = dbCSSPDB.SamplingPlanSubsectors.AsNoTracking().Where(c => c.SamplingPlanID == 78 && c.SubsectorTVItemID == 560).FirstOrDefault();
////                int SamplingPlanSubsectorID = samplingPlanSubsector.SamplingPlanSubsectorID;
////                samplingPlanSubsector.SamplingPlanID = samplingPlan.SamplingPlanID;
////                samplingPlanSubsector.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
////                if (!await AddObject("SamplingPlanSubsector", samplingPlanSubsector)) return await Task.FromResult(false);

////                // NB Sampling Plan with SamplingPlanID = 78 with SubsectorTVItemID = 635 (Bouctouche harbour)
////                SamplingPlanSubsectorSite samplingPlanSubsectorSite0001 = dbCSSPDB.SamplingPlanSubsectorSites.AsNoTracking().Where(c => c.SamplingPlanSubsectorID == SamplingPlanSubsectorID && c.MWQMSiteTVItemID == 7153).FirstOrDefault();
////                samplingPlanSubsectorSite0001.SamplingPlanSubsectorID = samplingPlanSubsector.SamplingPlanSubsectorID;
////                samplingPlanSubsectorSite0001.MWQMSiteTVItemID = tvItemNB_06_020_002Site0001.TVItemID;
////                if (!await AddObject("SamplingPlanSubsectorSite", samplingPlanSubsectorSite0001)) return await Task.FromResult(false);

////                // NB Sampling Plan with SamplingPlanID = 78 with SubsectorTVItemID = 635 (Bouctouche harbour)
////                SamplingPlanSubsectorSite samplingPlanSubsectorSite0002 = dbCSSPDB.SamplingPlanSubsectorSites.AsNoTracking().Where(c => c.SamplingPlanSubsectorID == SamplingPlanSubsectorID && c.MWQMSiteTVItemID == 7156).FirstOrDefault();
////                samplingPlanSubsectorSite0002.SamplingPlanSubsectorID = samplingPlanSubsector.SamplingPlanSubsectorID;
////                samplingPlanSubsectorSite0002.MWQMSiteTVItemID = tvItemNB_06_020_002Site0002.TVItemID;
////                if (!await AddObject("SamplingPlanSubsectorSite", samplingPlanSubsectorSite0002)) return await Task.FromResult(false);

////                // NB Sampling Plan Email with SamplingPlanID = 78
////                SamplingPlanEmail samplingPlanEmail = dbCSSPDB.SamplingPlanEmails.AsNoTracking().Where(c => c.SamplingPlanID == SamplingPlanID).FirstOrDefault();
////                samplingPlanEmail.SamplingPlanID = samplingPlan.SamplingPlanID;
////                if (!await AddObject("SamplingPlanEmail", samplingPlanEmail)) return await Task.FromResult(false);
////                #endregion TVItem SamplingPlan, SamplingPlanSubsector, SamplingPlanSubsectorSite, SamplingPlanEmail
////                #region TVItem MWQMRun with Subsector NB-06_020_002 and MWQMSite 0001
////                Console.WriteLine($"doing ... MWQM Run");
////                // TVItem MWQMRun with Subsector NB-06_020_002 TVItemID = 635 MWQMSite 0001 TVItemID = 7460 MWQMRunTVItemID = 324152
////                TVItem tvItemRun = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 324152).FirstOrDefault();
////                tvItemRun.ParentID = tvItemNB_06_020_002.TVItemID;
////                if (!await AddObject("TVItem", tvItemRun)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemRun, tvItemNB_06_020_002)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemRun, 324152, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // TVItemLanguage EN MWQMRun with MWQMRunTVItemID = 324152
////                TVItemLanguage tvItemLanguageENMWQMRun = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 324152 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENMWQMRun.TVItemID = tvItemRun.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENMWQMRun)) return await Task.FromResult(false);

////                // TVItemLanguage FR NB_06_020 TVItemID = 324152
////                TVItemLanguage tvItemLanguageFRMWQMRun = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 324152 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRMWQMRun.TVItemID = tvItemRun.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRMWQMRun)) return await Task.FromResult(false);

////                // TVItem MWQMRun with Subsector NB-06_020_002 TVItemID = 635 MWQMSite 0001 TVItemID = 7460 MWQMRunTVItemID = 324152
////                MWQMRun mwqmRun = dbCSSPDB.MWQMRuns.AsNoTracking().Where(c => c.MWQMRunTVItemID == 324152).FirstOrDefault();
////                int MWQMRunID = mwqmRun.MWQMRunID;
////                mwqmRun.MWQMRunTVItemID = tvItemRun.TVItemID;
////                mwqmRun.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
////                mwqmRun.LabSampleApprovalContactTVItemID = tvItemContactCharles.TVItemID;
////                if (!await AddObject("MWQMRun", mwqmRun)) return await Task.FromResult(false);

////                // MWQMRunLanguage EN MWQMRun with MWQMRunTVItemID = 324152
////                MWQMRunLanguage MWQMRunLanguageEN = dbCSSPDB.MWQMRunLanguages.AsNoTracking().Where(c => c.MWQMRunID == MWQMRunID && c.Language == LanguageEnum.en).FirstOrDefault();
////                MWQMRunLanguageEN.MWQMRunID = mwqmRun.MWQMRunID;
////                if (!await AddObject("MWQMRunLanguage", MWQMRunLanguageEN)) return await Task.FromResult(false);

////                // MWQMRunLanguage FR MWQMRun with MWQMRunTVItemID = 324152
////                MWQMRunLanguage MWQMRunLanguageFR = dbCSSPDB.MWQMRunLanguages.AsNoTracking().Where(c => c.MWQMRunID == MWQMRunID && c.Language == LanguageEnum.en).FirstOrDefault();
////                MWQMRunLanguageFR.MWQMRunID = mwqmRun.MWQMRunID;
////                if (!await AddObject("MWQMRunLanguage", MWQMRunLanguageFR)) return await Task.FromResult(false);
////                #endregion TVItem MWQMRun with Subsector NB-06_020_002 and MWQMSite 0001
////                #region UseOfSite
////                Console.WriteLine($"doing ... UseOfSite");
////                // NB UseOfSite with SubsectorTVItemID = 635 ClimateSiteTVItemID = 229528
////                UseOfSite useOfSite = dbCSSPDB.UseOfSites.AsNoTracking().Where(c => c.SubsectorTVItemID == 635 && c.SiteTVItemID == 229528).FirstOrDefault();
////                useOfSite.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
////                useOfSite.SiteTVItemID = tvItemNBClimateSiteBouctoucheCDA.TVItemID;
////                if (!await AddObject("UseOfSite", useOfSite)) return await Task.FromResult(false);

////                // NB UseOfSite with SubsectorTVItemID = 635 TideSiteTVItemID = 1553
////                //useOfSite = dbCSSPDB.UseOfSites.AsNoTracking().Where(c => c.SubsectorTVItemID == 635 && c.SiteTVItemID == 1553).FirstOrDefault();
////                //useOfSite.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
////                //useOfSite.SiteTVItemID = tideSite.TideSiteTVItemID;
////                //if (!await AddObject("UseOfSite", useOfSite)) return await Task.FromResult(false);
////                #endregion UseOfSite
////                #region MWQMSamples
////                Console.WriteLine($"doing ... MWQMSamples");
////                // NB MWQMSamples with MWQMSiteTVItemID = 7460 and MWQMRunTVItemID = 324152
////                MWQMSample mwqmSample = dbCSSPDB.MWQMSamples.AsNoTracking().Where(c => c.MWQMSiteTVItemID == 7460 && c.MWQMRunTVItemID == 324152).FirstOrDefault();
////                int MWQMSampleID = mwqmSample.MWQMSampleID;
////                mwqmSample.MWQMSiteTVItemID = tvItemNB_06_020_002Site0001.TVItemID;
////                mwqmSample.MWQMRunTVItemID = tvItemRun.TVItemID;
////                if (!await AddObject("MWQMSample", mwqmSample)) return await Task.FromResult(false);

////                // NB MWQMSampleLanguages EN with MWQMSiteTVItemID = 7460 and MWQMRunTVItemID = 324152
////                MWQMSampleLanguage mwqmSampleLanguageEN = dbCSSPDB.MWQMSampleLanguages.AsNoTracking().Where(c => c.MWQMSampleID == MWQMSampleID && c.Language == LanguageEnum.en).FirstOrDefault();
////                mwqmSampleLanguageEN.MWQMSampleID = mwqmSample.MWQMSampleID;
////                if (!await AddObject("MWQMSampleLanguage", mwqmSampleLanguageEN)) return await Task.FromResult(false);

////                // NB MWQMSampleLanguages FR with MWQMSiteTVItemID = 7460 and MWQMRunTVItemID = 324152
////                MWQMSampleLanguage mwqmSampleLanguageFR = dbCSSPDB.MWQMSampleLanguages.AsNoTracking().Where(c => c.MWQMSampleID == MWQMSampleID && c.Language == LanguageEnum.fr).FirstOrDefault();
////                mwqmSampleLanguageFR.MWQMSampleID = mwqmSample.MWQMSampleID;
////                if (!await AddObject("MWQMSampleLanguage", mwqmSampleLanguageFR)) return await Task.FromResult(false);
////                #endregion MWQMSamples
////                #region MWQMSite, MWQMSiteStartEndDate
////                Console.WriteLine($"doing ... MWQMSite and MWQMSiteStartEndDate");
////                // NB MWQMSite with MWQMSiteTVItemID = 7460
////                MWQMSite mwqmSite0001 = dbCSSPDB.MWQMSites.AsNoTracking().Where(c => c.MWQMSiteTVItemID == 7460).FirstOrDefault();
////                mwqmSite0001.MWQMSiteTVItemID = tvItemNB_06_020_002Site0001.TVItemID;
////                if (!await AddObject("MWQMSite", mwqmSite0001)) return await Task.FromResult(false);

////                // MWQMSiteStartEndDate with MWQMSiteTVItemID = 7460
////                MWQMSiteStartEndDate mwqmSiteStartEndDate0001 = dbCSSPDB.MWQMSiteStartEndDates.AsNoTracking().Where(c => c.MWQMSiteTVItemID == MWQMSiteID0001).FirstOrDefault();
////                mwqmSiteStartEndDate0001.MWQMSiteTVItemID = tvItemNB_06_020_002Site0001.TVItemID;
////                if (!await AddObject("MWQMSiteStartEndDate", mwqmSiteStartEndDate0001)) return await Task.FromResult(false);

////                // NB MWQMSite with MWQMSiteTVItemID = 7462
////                MWQMSite mwqmSite0002 = dbCSSPDB.MWQMSites.AsNoTracking().Where(c => c.MWQMSiteTVItemID == 7462).FirstOrDefault();
////                mwqmSite0002.MWQMSiteTVItemID = tvItemNB_06_020_002Site0002.TVItemID;
////                if (!await AddObject("MWQMSite", mwqmSite0002)) return await Task.FromResult(false);

////                // MWQMSiteStartEndDate with MWQMSiteTVItemID = 7462
////                MWQMSiteStartEndDate mwqmSiteStartEndDate0002 = dbCSSPDB.MWQMSiteStartEndDates.AsNoTracking().Where(c => c.MWQMSiteTVItemID == MWQMSiteID0001).FirstOrDefault();
////                mwqmSiteStartEndDate0002.MWQMSiteTVItemID = tvItemNB_06_020_002Site0002.TVItemID;
////                if (!await AddObject("MWQMSiteStartEndDate", mwqmSiteStartEndDate0002)) return await Task.FromResult(false);
////                #endregion MWQMSite, MWQMSiteStartEndDate
////                #region MikeScenario, MikeScenarioResult, MikeBoundaryCondition, MikeSource, MikeSourceStartEnd
////                Console.WriteLine($"doing ... MikeScenario, MikeBoundaryCondition, MikeSource, MikeSourceStartEnd");
////                // TVItem MikeScenario with MikeScenairoTVItemID = 28475 under Bouctouche
////                TVItem tvItemMikeScenario = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 28475).FirstOrDefault();
////                int MikeScenarioTVItemID = tvItemMikeScenario.TVItemID;
////                tvItemMikeScenario.ParentID = tvItemBouctouche.TVItemID;
////                if (!await AddObject("TVItem", tvItemMikeScenario)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemMikeScenario, tvItemBouctouche)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemMikeScenario, 28475, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // TVItem MikeScenario with MikeScenairoTVItemID = 28475 under Bouctouche
////                TVItemLanguage tvItemLanguageENMikeScenario = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28475 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENMikeScenario.TVItemID = tvItemMikeScenario.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENMikeScenario)) return await Task.FromResult(false);

////                // TVItem MikeScenario with MikeScenairoTVItemID = 28475 under Bouctouche
////                TVItemLanguage tvItemLanguageFRMikeScenario = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28475 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRMikeScenario.TVItemID = tvItemMikeScenario.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRMikeScenario)) return await Task.FromResult(false);

////                // MikeScenario with MikeScenairoTVItemID = 28475 under Bouctouche
////                MikeScenario mikeScenario = dbCSSPDB.MikeScenarios.AsNoTracking().Where(c => c.MikeScenarioTVItemID == 28475).FirstOrDefault();
////                int MikeScenarioID = mikeScenario.MikeScenarioID;
////                mikeScenario.MikeScenarioTVItemID = tvItemMikeScenario.TVItemID;
////                if (!await AddObject("MikeScenario", mikeScenario)) return await Task.FromResult(false);

////                // MikeScenarioResult with MikeScenairoTVItemID = 357139 under Bouctouche
////                MikeScenarioResult mikeScenarioResult = dbCSSPDB.MikeScenarioResults.AsNoTracking().Where(c => c.MikeScenarioTVItemID == 357139).FirstOrDefault();
////                int MikeScenarioResultID = mikeScenarioResult.MikeScenarioResultID;
////                mikeScenarioResult.MikeScenarioTVItemID = tvItemMikeScenario.TVItemID;
////                if (!await AddObject("MikeScenarioResult", mikeScenarioResult)) return await Task.FromResult(false);

////                // TVItem MikeBoundaryCondition with MikeBoundaryConditionTVItemID = 92456 under Bouctouche
////                TVItem tvItemMikeBoundaryCondition = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 92456).FirstOrDefault();
////                tvItemMikeBoundaryCondition.ParentID = tvItemMikeScenario.TVItemID;
////                if (!await AddObject("TVItem", tvItemMikeBoundaryCondition)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemMikeBoundaryCondition, tvItemMikeScenario)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemMikeBoundaryCondition, 92456, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // TVItem MikeBoundaryCondition with MikeBoundaryConditionTVItemID = 92456 under Bouctouche
////                TVItemLanguage tvItemLanguageENMikeBoundaryCondition = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 92456 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENMikeBoundaryCondition.TVItemID = tvItemMikeBoundaryCondition.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENMikeBoundaryCondition)) return await Task.FromResult(false);

////                // TVItem MikeBoundaryCondition with MikeBoundaryConditionTVItemID = 92456 under Bouctouche
////                TVItemLanguage tvItemLanguageFRMikeBoundaryCondition = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 92456 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRMikeBoundaryCondition.TVItemID = tvItemMikeBoundaryCondition.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRMikeBoundaryCondition)) return await Task.FromResult(false);

////                // MikeBoundaryCondition with MikeBoundaryConditionTVItemID = 92456 under Bouctouche
////                MikeBoundaryCondition mikeBoundaryCondition = dbCSSPDB.MikeBoundaryConditions.AsNoTracking().Where(c => c.MikeBoundaryConditionTVItemID == 92456).FirstOrDefault();
////                mikeBoundaryCondition.MikeBoundaryConditionTVItemID = tvItemMikeBoundaryCondition.TVItemID;
////                mikeBoundaryCondition.WebTideDataFromStartToEndDate = "some text";
////                if (!await AddObject("MikeBoundaryCondition", mikeBoundaryCondition)) return await Task.FromResult(false);

////                // TVItem MikeSource with MikeSourceTVItemID = 28476 under Bouctouche WWTP
////                TVItem tvItemMikeSource = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 28476).FirstOrDefault();
////                tvItemMikeSource.ParentID = tvItemMikeScenario.TVItemID;
////                if (!await AddObject("TVItem", tvItemMikeSource)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemMikeSource, tvItemMikeScenario)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemMikeSource, 28476, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // TVItem MikeSource with MikeSourceTVItemID = 28476 under Bouctouche
////                TVItemLanguage tvItemLanguageENMikeSource = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28476 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENMikeSource.TVItemID = tvItemMikeSource.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENMikeSource)) return await Task.FromResult(false);

////                // TVItem MikeSource with MikeSourceTVItemID = 28476 under Bouctouche
////                TVItemLanguage tvItemLanguageFRMikeSource = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28476 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRMikeSource.TVItemID = tvItemMikeSource.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRMikeSource)) return await Task.FromResult(false);

////                // MikeSource with MikeSourceTVItemID = 28476 under Bouctouche
////                MikeSource mikeSource = dbCSSPDB.MikeSources.AsNoTracking().Where(c => c.MikeSourceTVItemID == 28476).FirstOrDefault();
////                int MikeSourceID = mikeSource.MikeSourceID;
////                mikeSource.MikeSourceTVItemID = tvItemMikeSource.TVItemID;
////                if (!await AddObject("MikeSource", mikeSource)) return await Task.FromResult(false);

////                // MikeSourceStartEnd with MikeSourceTVItemID = 28476 under Bouctouche
////                MikeSourceStartEnd mikeSourceStartEnd = dbCSSPDB.MikeSourceStartEnds.AsNoTracking().Where(c => c.MikeSourceID == MikeSourceID).FirstOrDefault();
////                mikeSourceStartEnd.MikeSourceID = mikeSource.MikeSourceID;
////                if (!await AddObject("MikeSourceStartEnd", mikeSourceStartEnd)) return await Task.FromResult(false);
////                #endregion MikeScenario, MikeBoundaryCondition, MikeSource, MikeSourceStartEnd
////                #region LabSheet, LabSheetDetail, LabSheetTubeMPNDetail
////                Console.WriteLine($"doing ... LabSheet, LabSheetDetail, LabSheetTubeMPNDetail");
////                // LabSheet with SubsectorTVItemID = 635 and MWQMRunTVItemID = 324152 under Bouctouche harbour subsector
////                LabSheet labSheet = dbCSSPDB.LabSheets.AsNoTracking().Where(c => c.SubsectorTVItemID == 635 && c.MWQMRunTVItemID == 324152).FirstOrDefault();
////                int LabSheetID = labSheet.LabSheetID;
////                labSheet.MWQMRunTVItemID = tvItemRun.TVItemID;
////                labSheet.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
////                labSheet.AcceptedOrRejectedByContactTVItemID = tvItemContactCharles.TVItemID;
////                labSheet.SamplingPlanID = samplingPlan.SamplingPlanID;
////                if (!await AddObject("LabSheet", labSheet)) return await Task.FromResult(false);

////                // LabSheetDetail with SubsectorTVItemID = 635 and MWQMRunTVItemID = 324152 under Bouctouche harbour subsector
////                LabSheetDetail labSheetDetail = dbCSSPDB.LabSheetDetails.AsNoTracking().Where(c => c.LabSheetID == LabSheetID).FirstOrDefault();
////                int LabSheetDetailID = labSheetDetail.LabSheetDetailID;
////                labSheetDetail.LabSheetID = labSheet.LabSheetID;
////                labSheetDetail.SamplingPlanID = samplingPlan.SamplingPlanID;
////                labSheetDetail.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
////                if (!await AddObject("LabSheetDetail", labSheetDetail)) return await Task.FromResult(false);

////                // LabSheetTubeMPNDetail with SubsectorTVItemID = 635 and MWQMRunTVItemID = 324152 and MWQMSiteTVItemID = 7460 under Bouctouche harbour subsector
////                LabSheetTubeMPNDetail labSheetTubeMPNDetail = dbCSSPDB.LabSheetTubeMPNDetails.AsNoTracking().Where(c => c.LabSheetDetailID == LabSheetDetailID && c.MWQMSiteTVItemID == 7460).FirstOrDefault();
////                labSheetTubeMPNDetail.LabSheetDetailID = labSheetDetail.LabSheetDetailID;
////                labSheetTubeMPNDetail.MWQMSiteTVItemID = tvItemNB_06_020_002Site0001.TVItemID;
////                if (!await AddObject("LabSheetTubeMPNDetail", labSheetTubeMPNDetail)) return await Task.FromResult(false);
////                #endregion LabSheet, LabSheetDetail, LabSheetTubeMPNDetail
////                #region TVItem Email and Email
////                Console.WriteLine($"doing ... Email");

////                // Email Charles.LeBlanc@ec.gc.ca TVItemID = 110249
////                TVItem tvItemEmail = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 110249).FirstOrDefault();
////                tvItemEmail.ParentID = tvItemRoot.TVItemID;
////                if (!await AddObject("TVItem", tvItemEmail)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemEmail, tvItemRoot)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemEmail, 110249, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // Email Charles.LeBlanc@ec.gc.ca TVItemID = 110249
////                TVItemLanguage tvItemLanguageENEmail = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 110249 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENEmail.TVItemID = tvItemEmail.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENEmail)) return await Task.FromResult(false);

////                // Email Charles.LeBlanc@ec.gc.ca TVItemID = 110249
////                TVItemLanguage tvItemLanguageFREmail = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 110249 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFREmail.TVItemID = tvItemEmail.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFREmail)) return await Task.FromResult(false);

////                // Email Charles.LeBlanc@ec.gc.ca TVItemID = 110249
////                Email email = dbCSSPDB.Emails.AsNoTracking().Where(c => c.EmailTVItemID == 110249).FirstOrDefault();
////                email.EmailTVItemID = tvItemEmail.TVItemID;
////                if (!await AddObject("Email", email)) return await Task.FromResult(false);
////                #endregion TVItem Email and Email
////                #region TVItem Tel and Tel
////                Console.WriteLine($"doing ... Tel");
////                // Tel Charles.LeBlanc@ec.gc.ca TVItemID = 108984
////                TVItem tvItemTel = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 108984).FirstOrDefault();
////                tvItemTel.ParentID = tvItemRoot.TVItemID;
////                if (!await AddObject("TVItem", tvItemTel)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemTel, tvItemRoot)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemTel, 108984, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // Tel Charles.LeBlanc@ec.gc.ca TVItemID = 108984
////                TVItemLanguage tvItemLanguageENTel = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 108984 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENTel.TVItemID = tvItemTel.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENTel)) return await Task.FromResult(false);

////                // Tel Charles.LeBlanc@ec.gc.ca TVItemID = 108984
////                TVItemLanguage tvItemLanguageFRTel = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 108984 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRTel.TVItemID = tvItemTel.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRTel)) return await Task.FromResult(false);

////                // Tel Charles.LeBlanc@ec.gc.ca TVItemID = 108984
////                Tel tel = dbCSSPDB.Tels.AsNoTracking().Where(c => c.TelTVItemID == 108984).FirstOrDefault();
////                tel.TelTVItemID = tvItemTel.TVItemID;
////                if (!await AddObject("Tel", tel)) return await Task.FromResult(false);
////                #endregion TVItem Tel and Tel
////                #region TVItemLink
////                Console.WriteLine($"doing ... TVItemLink");
////                TVItemLink tvItemLinkMunicContact = dbCSSPDB.TVItemLinks.AsNoTracking().Where(c => c.FromTVItemID == 27764 && c.ToTVItemID == 305006).FirstOrDefault();
////                tvItemLinkMunicContact.FromTVItemID = tvItemBouctouche.TVItemID;
////                tvItemLinkMunicContact.ToTVItemID = tvItemContactCharles.TVItemID;
////                tvItemLinkMunicContact.TVPath = $"p{ tvItemBouctouche.TVItemID.ToString() }p{ tvItemContactCharles.TVItemID.ToString() }";
////                if (!await AddObject("TVItemLink", tvItemLinkMunicContact)) return await Task.FromResult(false);

////                TVItemLink tvItemLinkContactTel = dbCSSPDB.TVItemLinks.AsNoTracking().Where(c => c.FromTVItemID == 305006 && c.ToTVItemID == 305007).FirstOrDefault();
////                tvItemLinkContactTel.FromTVItemID = tvItemContactCharles.TVItemID;
////                tvItemLinkContactTel.ToTVItemID = tvItemTel.TVItemID;
////                tvItemLinkContactTel.TVPath = $"p{ tvItemContactCharles.TVItemID.ToString() }p{ tvItemTel.TVItemID.ToString() }";
////                if (!await AddObject("TVItemLink", tvItemLinkContactTel)) return await Task.FromResult(false);

////                TVItemLink tvItemLinkContactEmail = dbCSSPDB.TVItemLinks.AsNoTracking().Where(c => c.FromTVItemID == 305006 && c.ToTVItemID == 305007).FirstOrDefault();
////                tvItemLinkContactEmail.FromTVItemID = tvItemContactCharles.TVItemID;
////                tvItemLinkContactEmail.ToTVItemID = tvItemEmail.TVItemID;
////                tvItemLinkContactEmail.TVPath = $"p{ tvItemContactCharles.TVItemID.ToString() }p{ tvItemEmail.TVItemID.ToString() }";
////                if (!await AddObject("TVItemLink", tvItemLinkContactEmail)) return await Task.FromResult(false);
////                #endregion TVItemLink
////                #region PolSourceSiteEffects and PolSourceSiteEffectTerms where PolSourceSiteEffectID = 36
////                Console.WriteLine($"doing ... TVItemLink");
////                PolSourceSiteEffect polSourceSiteEffect36 = dbCSSPDB.PolSourceSiteEffects.AsNoTracking().Where(c => c.PolSourceSiteEffectID == 36).FirstOrDefault();
////                polSourceSiteEffect36.PolSourceSiteOrInfrastructureTVItemID = polSourceSitePolSite000023.PolSourceSiteTVItemID;
////                polSourceSiteEffect36.MWQMSiteTVItemID = mwqmSite0001.MWQMSiteTVItemID;

////                List<int> PolSourceSiteEffectTermIDList = polSourceSiteEffect36.PolSourceSiteEffectTermIDs.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToList();

////                string PolSourceSiteEffectTermIDs2 = "";

////                foreach (int polSourceSiteEffectTermID in PolSourceSiteEffectTermIDList)
////                {
////                    PolSourceSiteEffectTerm polSourceSiteEffectTerm = dbCSSPDB.PolSourceSiteEffectTerms.AsNoTracking().Where(c => c.PolSourceSiteEffectTermID == polSourceSiteEffectTermID).FirstOrDefault();
////                    polSourceSiteEffectTerm.IsGroup = false;
////                    polSourceSiteEffectTerm.UnderGroupID = null;
////                    if (!await AddObject("PolSourceSiteEffectTerm", polSourceSiteEffectTerm)) return await Task.FromResult(false);
////                    PolSourceSiteEffectTermIDs2 = PolSourceSiteEffectTermIDs2 + "," + polSourceSiteEffectTerm.PolSourceSiteEffectTermID.ToString();
////                }

////                polSourceSiteEffect36.PolSourceSiteEffectTermIDs = PolSourceSiteEffectTermIDs2.Substring(1);
////                if (!await AddObject("PolSourceSiteEffect", polSourceSiteEffect36)) return await Task.FromResult(false);
////                #endregion  PolSourceSiteEffects and PolSourceSiteEffectTerms where PolSourceSiteEffectID = 36
////                #region Spill and SpillLanguage
////                Console.WriteLine($"doing ... Spill and SpillLanguage");
////                Spill spill = new Spill();
////                spill.MunicipalityTVItemID = tvItemBouctouche.TVItemID;
////                spill.InfrastructureTVItemID = tvItemBouctoucheWWTP.TVItemID;
////                spill.StartDateTime_Local = DateTime.Now.AddYears(-5);
////                spill.EndDateTime_Local = DateTime.Now.AddYears(-5).AddHours(6);
////                spill.AverageFlow_m3_day = 34.5D;
////                spill.LastUpdateDate_UTC = DateTime.Now;
////                spill.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
////                if (!await AddObject("Spill", spill)) return await Task.FromResult(false);

////                SpillLanguage spillLanguageEN = new SpillLanguage();
////                spillLanguageEN.SpillID = spill.SpillID;
////                spillLanguageEN.Language = LanguageEnum.en;
////                spillLanguageEN.SpillComment = "This is the spill comment";
////                spillLanguageEN.TranslationStatus = TranslationStatusEnum.Translated;
////                spillLanguageEN.LastUpdateDate_UTC = DateTime.Now;
////                spillLanguageEN.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
////                if (!await AddObject("SpillLanguage", spillLanguageEN)) return await Task.FromResult(false);

////                SpillLanguage spillLanguageFR = new SpillLanguage();
////                spillLanguageFR.SpillID = spill.SpillID;
////                spillLanguageFR.Language = LanguageEnum.fr;
////                spillLanguageFR.SpillComment = "This is the spill comment";
////                spillLanguageFR.TranslationStatus = TranslationStatusEnum.NotTranslated;
////                spillLanguageFR.LastUpdateDate_UTC = DateTime.Now;
////                spillLanguageFR.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
////                if (!await AddObject("SpillLanguage", spillLanguageFR)) return await Task.FromResult(false);
////                #endregion Spill and SpillLanguage
////                #region EmailDistributionList and EmailDistributionListContact
////                Console.WriteLine($"doing ... EmailDistributionList and EmailDistributionListContact");
////                EmailDistributionList emailDistributionList = dbCSSPDB.EmailDistributionLists.AsNoTracking().FirstOrDefault();
////                int EmailDistributionListID = emailDistributionList.EmailDistributionListID;
////                emailDistributionList.ParentTVItemID = tvItemCanada.TVItemID;
////                if (!await AddObject("EmailDistributionList", emailDistributionList)) return await Task.FromResult(false);

////                EmailDistributionListLanguage emailDistributionListLanguageEN = dbCSSPDB.EmailDistributionListLanguages.AsNoTracking().Where(c => c.EmailDistributionListID == EmailDistributionListID && c.Language == LanguageEnum.en).FirstOrDefault();
////                emailDistributionListLanguageEN.EmailDistributionListID = emailDistributionList.EmailDistributionListID;
////                if (!await AddObject("EmailDistributionListLanguage", emailDistributionListLanguageEN)) return await Task.FromResult(false);

////                EmailDistributionListLanguage emailDistributionListLanguageFR = dbCSSPDB.EmailDistributionListLanguages.AsNoTracking().Where(c => c.EmailDistributionListID == EmailDistributionListID && c.Language == LanguageEnum.fr).FirstOrDefault();
////                emailDistributionListLanguageFR.EmailDistributionListID = emailDistributionList.EmailDistributionListID;
////                if (!await AddObject("EmailDistributionListLanguage", emailDistributionListLanguageFR)) return await Task.FromResult(false);


////                List<EmailDistributionListContact> emailDistributionListContactList = dbCSSPDB.EmailDistributionListContacts.AsNoTracking().Where(c => c.EmailDistributionListID == EmailDistributionListID).Take(5).ToList();
////                foreach (EmailDistributionListContact emailDistributionListContact in emailDistributionListContactList)
////                {
////                    emailDistributionListContact.EmailDistributionListID = emailDistributionList.EmailDistributionListID;
////                    int EmailDistributionListContactID = emailDistributionListContact.EmailDistributionListContactID;
////                    if (!await AddObject("EmailDistributionListContact", emailDistributionListContact)) return await Task.FromResult(false);

////                    EmailDistributionListContactLanguage emailDistributionListContactLanguageEN = dbCSSPDB.EmailDistributionListContactLanguages.AsNoTracking().Where(c => c.EmailDistributionListContactID == EmailDistributionListContactID && c.Language == LanguageEnum.en).FirstOrDefault();
////                    emailDistributionListContactLanguageEN.EmailDistributionListContactID = emailDistributionListContact.EmailDistributionListContactID;
////                    if (!await AddObject("EmailDistributionListContactLanguage", emailDistributionListContactLanguageEN)) return await Task.FromResult(false);

////                    EmailDistributionListContactLanguage emailDistributionListContactLanguageFR = dbCSSPDB.EmailDistributionListContactLanguages.AsNoTracking().Where(c => c.EmailDistributionListContactID == EmailDistributionListContactID && c.Language == LanguageEnum.fr).FirstOrDefault();
////                    emailDistributionListContactLanguageFR.EmailDistributionListContactID = emailDistributionListContact.EmailDistributionListContactID;
////                    if (!await AddObject("EmailDistributionListContactLanguage", emailDistributionListContactLanguageFR)) return await Task.FromResult(false);

////                }
////                #endregion EmailDistributionList and EmailDistributionListContact
////                #region AppTask and AppTaskLanguage
////                Console.WriteLine($"doing ... AppTask and AppTaskLanguage");
////                AppTask appTask = new AppTask();
////                appTask.TVItemID = tvItemCanada.TVItemID;
////                appTask.TVItemID2 = tvItemCanada.TVItemID;
////                appTask.AppTaskCommand = AppTaskCommandEnum.GenerateWebTide;
////                appTask.AppTaskStatus = AppTaskStatusEnum.Created;
////                appTask.PercentCompleted = 1;
////                appTask.Parameters = "a,a";
////                appTask.Language = LanguageEnum.en;
////                appTask.StartDateTime_UTC = DateTime.Now.AddYears(-5);
////                appTask.EndDateTime_UTC = DateTime.Now.AddYears(-5).AddHours(4);
////                appTask.EstimatedLength_second = 1201;
////                appTask.RemainingTime_second = 234;
////                appTask.LastUpdateDate_UTC = DateTime.Now;
////                appTask.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
////                if (!await AddObject("AppTask", appTask)) return await Task.FromResult(false);

////                AppTaskLanguage appTaskLanguageEN = new AppTaskLanguage();
////                appTaskLanguageEN.AppTaskID = appTask.AppTaskID;
////                appTaskLanguageEN.Language = LanguageEnum.en;
////                appTaskLanguageEN.StatusText = "This is the Status text";
////                appTaskLanguageEN.ErrorText = "This is the CSSPError text";
////                appTaskLanguageEN.TranslationStatus = TranslationStatusEnum.Translated;
////                appTaskLanguageEN.LastUpdateDate_UTC = DateTime.Now;
////                appTaskLanguageEN.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
////                if (!await AddObject("AppTaskLanguage", appTaskLanguageEN)) return await Task.FromResult(false);

////                AppTaskLanguage appTaskLanguageFR = new AppTaskLanguage();
////                appTaskLanguageFR.AppTaskID = appTask.AppTaskID;
////                appTaskLanguageFR.Language = LanguageEnum.fr;
////                appTaskLanguageFR.StatusText = "This is the Status text";
////                appTaskLanguageFR.ErrorText = "This is the CSSPError text";
////                appTaskLanguageFR.TranslationStatus = TranslationStatusEnum.NotTranslated;
////                appTaskLanguageFR.LastUpdateDate_UTC = DateTime.Now;
////                appTaskLanguageFR.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
////                if (!await AddObject("AppTaskLanguage", appTaskLanguageFR)) return await Task.FromResult(false);
////                #endregion AppTask and AppTaskLanguage
////                #region AppErrLog
////                Console.WriteLine($"doing ... AppErrLog");
////                AppErrLog appErrLog = new AppErrLog();
////                appErrLog.Tag = "SomeTag";
////                appErrLog.LineNumber = 234;
////                appErrLog.Source = "Some text for source";
////                appErrLog.Message = "Some text for message";
////                appErrLog.DateTime_UTC = DateTime.Now;
////                appErrLog.LastUpdateDate_UTC = DateTime.Now;
////                appErrLog.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
////                if (!await AddObject("AppErrLog", appErrLog)) return await Task.FromResult(false);
////                #endregion AppErrLog
////                #region ContactPreference
////                Console.WriteLine($"doing ... ContactPreference");
////                ContactPreference contactPreference = new ContactPreference();
////                contactPreference.ContactID = contactCharles.ContactID;
////                contactPreference.TVType = TVTypeEnum.ClimateSite;
////                contactPreference.MarkerSize = 100;
////                contactPreference.LastUpdateDate_UTC = DateTime.Now;
////                contactPreference.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
////                if (!await AddObject("ContactPreference", contactPreference)) return await Task.FromResult(false);
////                #endregion ContactPreference
////                #region ContactShortcut
////                Console.WriteLine($"doing ... ContactShortcut");
////                ContactShortcut contactShortcut = new ContactShortcut();
////                contactShortcut.ContactID = contactCharles.ContactID;
////                contactShortcut.ShortCutText = "Some shortcut text";
////                contactShortcut.ShortCutAddress = "http://www.ibm.com";
////                contactShortcut.LastUpdateDate_UTC = DateTime.Now;
////                contactShortcut.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
////                if (!await AddObject("ContactShortcut", contactShortcut)) return await Task.FromResult(false);
////                #endregion ContactShortcut
////                #region DocTemplate
////                Console.WriteLine($"doing ... DocTemplate");
////                DocTemplate docTemplate = new DocTemplate();
////                docTemplate.Language = LanguageEnum.en;
////                docTemplate.TVType = TVTypeEnum.Subsector;
////                docTemplate.TVFileTVItemID = tvFile.TVFileTVItemID;
////                docTemplate.FileName = tvItemBouctoucheWWTPTVFileImageEN.TVText;
////                docTemplate.LastUpdateDate_UTC = DateTime.Now;
////                docTemplate.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
////                if (!await AddObject("DocTemplate", docTemplate)) return await Task.FromResult(false);
////                #endregion DocTemplate
////                #region Log
////                Console.WriteLine($"doing ... Log");
////                Log log = new Log();
////                log.TableName = "TVItems";
////                log.ID = 20;
////                log.LogCommand = LogCommandEnum.Add;
////                log.Information = "The Information Text";
////                log.LastUpdateDate_UTC = DateTime.Now;
////                log.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
////                if (!await AddObject("Log", log)) return await Task.FromResult(false);
////                #endregion Log
////                #region MWQMLookupMPN
////                Console.WriteLine($"doing ... MWQMLookupMPN");
////                List<MWQMLookupMPN> mwqmLookupMPNList = dbCSSPDB.MWQMLookupMPNs.AsNoTracking().Take(12).ToList();
////                foreach (MWQMLookupMPN mwqmLookupMPN2 in mwqmLookupMPNList)
////                {
////                    MWQMLookupMPN mwqmLookupMPN = new MWQMLookupMPN();
////                    mwqmLookupMPN.Tubes10 = mwqmLookupMPN2.Tubes10;
////                    mwqmLookupMPN.Tubes1 = mwqmLookupMPN2.Tubes1;
////                    mwqmLookupMPN.Tubes01 = mwqmLookupMPN2.Tubes01;
////                    mwqmLookupMPN.MPN_100ml = mwqmLookupMPN2.MPN_100ml;
////                    mwqmLookupMPN.LastUpdateDate_UTC = DateTime.Now;
////                    mwqmLookupMPN.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
////                    if (!await AddObject("MWQMLookupMPN", mwqmLookupMPN)) return await Task.FromResult(false);
////                }
////                #endregion MWQMLookupMPN
////                #region RainExceedance and RainExceedanceClimateSite
////                Console.WriteLine($"doing ... RainExceedance");

////                TVItem tvItemRainExceedance = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 374858).FirstOrDefault();
////                tvItemEmail.ParentID = tvItemCanada.TVItemID;
////                if (!await AddObject("TVItem", tvItemRainExceedance)) return await Task.FromResult(false);
////                if (!await CorrectTVPath(tvItemRainExceedance, tvItemCanada)) return await Task.FromResult(false);
////                if (!await AddMapInfo(tvItemRainExceedance, 374858, tvItemContactCharles.TVItemID)) return await Task.FromResult(false);

////                // Email Charles.LeBlanc@ec.gc.ca TVItemID = 374858
////                TVItemLanguage tvItemLanguageENRainExceedance = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 374858 && c.Language == LanguageEnum.en).FirstOrDefault();
////                tvItemLanguageENRainExceedance.TVItemID = tvItemRainExceedance.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageENRainExceedance)) return await Task.FromResult(false);

////                // Email Charles.LeBlanc@ec.gc.ca TVItemID = 374858
////                TVItemLanguage tvItemLanguageFRRainExceedance = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 374858 && c.Language == LanguageEnum.fr).FirstOrDefault();
////                tvItemLanguageFRRainExceedance.TVItemID = tvItemRainExceedance.TVItemID;
////                if (!await AddObject("TVItemLanguage", tvItemLanguageFRRainExceedance)) return await Task.FromResult(false);


////                RainExceedance rainExceedance = new RainExceedance();
////                rainExceedance.StartMonth = 1;
////                rainExceedance.EndMonth = 4;
////                rainExceedance.StartDay = 2;
////                rainExceedance.EndDay = 31;
////                rainExceedance.RainMaximum_mm = 12.5f;
////                rainExceedance.RainExceedanceTVItemID = tvItemRainExceedance.TVItemID;
////                rainExceedance.StakeholdersEmailDistributionListID = null;
////                rainExceedance.OnlyStaffEmailDistributionListID = null;
////                rainExceedance.IsActive = true;
////                rainExceedance.LastUpdateDate_UTC = DateTime.Now;
////                rainExceedance.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
////                if (!await AddObject("RainExceedance", rainExceedance)) return await Task.FromResult(false);

////                // RainExceedanceClimateSite
////                RainExceedanceClimateSite rainExceedanceClimateSite = dbCSSPDB.RainExceedanceClimateSites.AsNoTracking().Where(c => c.RainExceedanceTVItemID == 374858).FirstOrDefault();
////                rainExceedanceClimateSite.RainExceedanceTVItemID = tvItemRainExceedance.TVItemID;
////                rainExceedanceClimateSite.ClimateSiteTVItemID = tvItemNBClimateSiteBouctoucheCDA.TVItemID;
////                if (!await AddObject("RainExceedanceClimateSite", rainExceedanceClimateSite)) return await Task.FromResult(false);
////                #endregion RainExceedance and RainExceedanceClimateSite
////                #region ResetPassword
////                Console.WriteLine($"doing ... ResetPassword");
////                ResetPassword resetPassword = new ResetPassword();
////                resetPassword.Email = contactCharles.LoginEmail;
////                resetPassword.ExpireDate_Local = DateTime.Now;
////                resetPassword.Code = "12345678";
////                resetPassword.LastUpdateDate_UTC = DateTime.Now;
////                resetPassword.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
////                if (!await AddObject("ResetPassword", resetPassword)) return await Task.FromResult(false);
////                #endregion ResetPassword
////                #region TideLocation
////                Console.WriteLine($"doing ... TideLocation");
////                foreach (int TideLocationSID in new List<int>() { 1815, 1812, 1810 })
////                {
////                    TideLocation tideLocation = dbCSSPDB.TideLocations.AsNoTracking().Where(c => c.sid == TideLocationSID).FirstOrDefault();

////                    if (tideLocation != null)
////                    {
////                        tideLocation.TideLocationID = 0;
////                        if (!await AddObject("TideLocation", tideLocation)) return await Task.FromResult(false);
////                    }
////                }
////                #endregion TideLocation
////                #region TVItemStat
////                Console.WriteLine($"doing ... TVItemStat");
////                TVItemStat tvItemStat = dbCSSPDB.TVItemStats.AsNoTracking().Where(c => c.TVItemID == RootTVItemID && c.TVType == TVTypeEnum.Municipality).FirstOrDefault();

////                if (tvItemStat != null)
////                {
////                    tvItemStat.TVItemStatID = 0;
////                    tvItemStat.TVItemID = tvItemRoot.TVItemID;
////                    tvItemStat.ChildCount = 2;
////                    if (!await AddObject("TVItemStat", tvItemStat)) return await Task.FromResult(false);
////                }
////                #endregion TVItemStat
////                #region TVItemUserAuthorization
////                Console.WriteLine($"doing ... TVItemUserAuthorization");
////                TVItemUserAuthorization tvItemUserAuthorization = dbCSSPDB.TVItemUserAuthorizations.AsNoTracking().FirstOrDefault();

////                if (tvItemUserAuthorization != null)
////                {
////                    tvItemUserAuthorization.ContactTVItemID = contactCharles.ContactTVItemID;
////                    tvItemUserAuthorization.TVItemID1 = tvItemBouctouche.TVItemID;
////                    tvItemUserAuthorization.TVAuth = TVAuthEnum.Write;
////                    if (!await AddObject("TVItemUserAuthorization", tvItemUserAuthorization)) return await Task.FromResult(false);
////                }
////                #endregion TVItemUserAuthorization
////                #region TVTypeUserAuthorization
////                Console.WriteLine($"doing ... TVTypeUserAuthorization");
////                TVTypeUserAuthorization tvTypeUserAuthorization = dbCSSPDB.TVTypeUserAuthorizations.AsNoTracking().FirstOrDefault();

////                if (tvTypeUserAuthorization != null)
////                {
////                    tvTypeUserAuthorization.ContactTVItemID = contactCharles.ContactTVItemID;
////                    tvTypeUserAuthorization.TVType = TVTypeEnum.Root;
////                    tvTypeUserAuthorization.TVAuth = TVAuthEnum.Admin;
////                    if (!await AddObject("TVTypeUserAuthorization", tvTypeUserAuthorization)) return await Task.FromResult(false);
////                }
////                #endregion TVTypeUserAuthorization
////                #region MWQMAnalysisReportParameter
////                Console.WriteLine($"doing ... MWQMAnalysisReportParameter");
////                MWQMAnalysisReportParameter mwqmAnalysisReportParameter = new MWQMAnalysisReportParameter();
////                mwqmAnalysisReportParameter.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
////                mwqmAnalysisReportParameter.AnalysisName = "Name of analysis report parameter";
////                mwqmAnalysisReportParameter.AnalysisReportYear = 2016;
////                mwqmAnalysisReportParameter.StartDate = new DateTime(2010, 1, 1);
////                mwqmAnalysisReportParameter.EndDate = new DateTime(2016, 12, 31);
////                mwqmAnalysisReportParameter.AnalysisCalculationType = AnalysisCalculationTypeEnum.All;
////                mwqmAnalysisReportParameter.NumberOfRuns = 30;
////                mwqmAnalysisReportParameter.FullYear = true;
////                mwqmAnalysisReportParameter.SalinityHighlightDeviationFromAverage = 8.0f;
////                mwqmAnalysisReportParameter.ShortRangeNumberOfDays = 3;
////                mwqmAnalysisReportParameter.MidRangeNumberOfDays = 6;
////                mwqmAnalysisReportParameter.DryLimit24h = 4;
////                mwqmAnalysisReportParameter.DryLimit48h = 8;
////                mwqmAnalysisReportParameter.DryLimit72h = 12;
////                mwqmAnalysisReportParameter.DryLimit96h = 16;
////                mwqmAnalysisReportParameter.WetLimit24h = 12;
////                mwqmAnalysisReportParameter.WetLimit48h = 24;
////                mwqmAnalysisReportParameter.WetLimit72h = 36;
////                mwqmAnalysisReportParameter.WetLimit96h = 48;
////                mwqmAnalysisReportParameter.RunsToOmit = ",";
////                mwqmAnalysisReportParameter.ExcelTVFileTVItemID = null;
////                mwqmAnalysisReportParameter.Command = AnalysisReportExportCommandEnum.Report;
////                mwqmAnalysisReportParameter.LastUpdateDate_UTC = DateTime.Now;
////                mwqmAnalysisReportParameter.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
////                if (!await AddObject("MWQMAnalysisReportParameter", mwqmAnalysisReportParameter)) return await Task.FromResult(false);
////                #endregion MWQMAnalysisReportParameter
////                #region PolSourceGrouping and PolSourceGroupingLangauge
////                Console.WriteLine($"doing ... PolSourceGrouping");
////                PolSourceGrouping polSourceGrouping = new PolSourceGrouping();
////                polSourceGrouping.CSSPID = 10003;
////                polSourceGrouping.GroupName = "FirstGroupName";
////                polSourceGrouping.Child = "FirstChild";
////                polSourceGrouping.Hide = "FirstHide";
////                polSourceGrouping.LastUpdateDate_UTC = DateTime.Now;
////                polSourceGrouping.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
////                if (!await AddObject("PolSourceGrouping", polSourceGrouping)) return await Task.FromResult(false);

////                Console.WriteLine($"doing ... PolSourceGrouping");
////                PolSourceGroupingLanguage polSourceGroupingLanguage = new PolSourceGroupingLanguage();
////                polSourceGroupingLanguage.PolSourceGroupingID = polSourceGrouping.PolSourceGroupingID;
////                polSourceGroupingLanguage.Language = LanguageEnum.en;
////                polSourceGroupingLanguage.SourceName = "FirstSourceName";
////                polSourceGroupingLanguage.SourceNameOrder = 1;
////                polSourceGroupingLanguage.TranslationStatusSourceName = TranslationStatusEnum.Translated;
////                polSourceGroupingLanguage.Init = "FirstInit";
////                polSourceGroupingLanguage.TranslationStatusInit = TranslationStatusEnum.Translated;
////                polSourceGroupingLanguage.Description = "FirstDescription";
////                polSourceGroupingLanguage.TranslationStatusDescription = TranslationStatusEnum.Translated;
////                polSourceGroupingLanguage.Report = "FirstReport";
////                polSourceGroupingLanguage.TranslationStatusReport = TranslationStatusEnum.Translated;
////                polSourceGroupingLanguage.Text = "FirstText";
////                polSourceGroupingLanguage.TranslationStatusText = TranslationStatusEnum.Translated;
////                polSourceGroupingLanguage.LastUpdateDate_UTC = DateTime.Now;
////                polSourceGroupingLanguage.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;               
////                if (!await AddObject("PolSourceGroupingLanguage", polSourceGroupingLanguage)) return await Task.FromResult(false);

////                Console.WriteLine($"doing ... PolSourceGrouping");
////                PolSourceGroupingLanguage polSourceGroupingLanguageFR = new PolSourceGroupingLanguage();
////                polSourceGroupingLanguageFR.PolSourceGroupingID = polSourceGrouping.PolSourceGroupingID;
////                polSourceGroupingLanguageFR.Language = LanguageEnum.fr;
////                polSourceGroupingLanguageFR.SourceName = "FirstSourceNameFR";
////                polSourceGroupingLanguageFR.SourceNameOrder = 1;
////                polSourceGroupingLanguageFR.TranslationStatusSourceName = TranslationStatusEnum.Translated;
////                polSourceGroupingLanguageFR.Init = "FirstInitFR";
////                polSourceGroupingLanguageFR.TranslationStatusInit = TranslationStatusEnum.Translated;
////                polSourceGroupingLanguageFR.Description = "FirstDescriptionFR";
////                polSourceGroupingLanguageFR.TranslationStatusDescription = TranslationStatusEnum.Translated;
////                polSourceGroupingLanguageFR.Report = "FirstReportFR";
////                polSourceGroupingLanguageFR.TranslationStatusReport = TranslationStatusEnum.Translated;
////                polSourceGroupingLanguageFR.Text = "FirstTextFR";
////                polSourceGroupingLanguageFR.TranslationStatusText = TranslationStatusEnum.Translated;
////                polSourceGroupingLanguageFR.LastUpdateDate_UTC = DateTime.Now;
////                polSourceGroupingLanguageFR.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
////                if (!await AddObject("PolSourceGroupingLanguage", polSourceGroupingLanguageFR)) return await Task.FromResult(false);
////                #endregion PolSourceGrouping
////            }
////            catch (Exception ex)
////            {
////                Console.WriteLine("");
////                Console.WriteLine(ex.Message);
////            }

////            return await Task.FromResult(true);
////        }
////    }
////}
