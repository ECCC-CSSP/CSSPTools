using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
//using System.Windows.Forms;
using CSSPModels;
using CSSPEnums;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using CSSPServices;
using CSSPGenerateCodeBase;
using Microsoft.Extensions.Configuration;

namespace CSSPServicesGenerateCodeHelper
{
    public partial class ServicesCodeWriter
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // constructor was done in the ServicesGenerateCodeHelper.cs file
        #endregion Constructors

        #region Events
        #endregion Events

        #region Functions public
        /// <summary>
        ///     Check all tables in TestDB has at least 10 items
        /// </summary>
        /// <param name="tableTestDBList">List of TestDB related table information</param>
        /// <param name="TestDBConnectionString">TestDB connection string</param>
        /// <returns>True if everything went ok</returns>
        public void CheckAllTablesInTestDBHasAtLeast10Items()
        {
            ClearPermanentEvent(new StatusEventArgs(""));
            StatusTempEvent(new StatusEventArgs(""));

        
            string TestDBConnectionString = Configuration.GetConnectionString("TestDB");

            List<Table> tableTestDBList = new List<Table>();

            StatusPermanentEvent(new StatusEventArgs("Loading TestDB table information..."));
            if (!LoadDBInfo(tableTestDBList, TestDBConnectionString))
            {
                return;
            }

            try
            {
                using (SqlConnection cnn = new SqlConnection(TestDBConnectionString))
                {
                    if (!cnn.ConnectionString.Contains("TestDB"))
                    {
                        CSSPErrorEvent(new CSSPErrorEventArgs("Only use this command for the TestDB"));
                        return;
                    }

                    cnn.Open();

                    foreach (Table table in tableTestDBList.OrderBy(c => c.TableName))
                    {
                        StatusTempEvent(new StatusEventArgs($"Checking Table  [{ table.TableName }] has at least 10 items"));

                        if (table.TableName.StartsWith("Asp"))
                        {
                            continue;
                        }

                        string queryString = $"SELECT COUNT(*) FROM { table.TableName }";

                        using (SqlCommand cmd = new SqlCommand(queryString, cnn))
                        {
                            int count = (int)cmd.ExecuteScalar();

                            if (count < 10)
                            {
                                CSSPErrorEvent(new CSSPErrorEventArgs($"{ table.TableName } does not have at least 10 items"));
                                return;
                            }
                            else
                            {
                                StatusTempEvent(new StatusEventArgs($"{ table.TableName } count = { count }"));
                            }
                        }
                    }

                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                string InnerExceptiion = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerExceptiion }"));
                return;
            }

            StatusTempEvent(new StatusEventArgs($"done..."));
            StatusPermanentEvent(new StatusEventArgs("All Tables contains 10 or more items..."));

        }
        /// <summary>
        ///     Fills the TestDB database which is an empty copy of the CSSPDB
        ///     
        ///     Note: In order to create an empty TestDB you can use the Microsoft SQL Server Management Studio
        ///     - Right click on CSSPDB
        ///     - select Tasks
        ///     - select Generate Scripts
        ///     - then use whatever method to create a blank TestDB with only the structure of the CSSPDB
        /// 
        /// </summary>
        public void RepopulateTestDB()
        {
            ClearPermanentEvent(new StatusEventArgs(""));
            StatusTempEvent(new StatusEventArgs(""));

            string CSSPDBConnectionString = Configuration.GetConnectionString("CSSPDB");
            string TestDBConnectionString = Configuration.GetConnectionString("TestDB");

            List<Table> tableCSSPDBList = new List<Table>();
            List<Table> tableTestDBList = new List<Table>();

            StatusPermanentEvent(new StatusEventArgs("Loading CSSPWeb table information..."));
            if (!LoadDBInfo(tableCSSPDBList, CSSPDBConnectionString))
            {
                return;
            }

            StatusPermanentEvent(new StatusEventArgs("Loading TestDB table information..."));
            if (!LoadDBInfo(tableTestDBList, TestDBConnectionString))
            {
                return;
            }

            StatusPermanentEvent(new StatusEventArgs("Comparing tables ..."));
            if (!CompareDBs(tableCSSPDBList, tableTestDBList)) return;
            StatusPermanentEvent(new StatusEventArgs("Done comparing ... everything ok"));

            StatusPermanentEvent(new StatusEventArgs("Cleaning TestDB ..."));
            if (!CleanTestDB(tableTestDBList, TestDBConnectionString)) return;
            StatusPermanentEvent(new StatusEventArgs("Done Cleaning TestDB ... everything ok"));

            StatusPermanentEvent(new StatusEventArgs("Filling TestDB ..."));
            if (!FillTestDB(tableTestDBList)) return;
            StatusPermanentEvent(new StatusEventArgs("Done Filling TestDB ... everything ok"));

            StatusPermanentEvent(new StatusEventArgs("Making sure every table within TestDB has at least 10 items ..."));
            if (!MakingSureEveryTableHasEnoughItemsInTestDB()) return;
            StatusPermanentEvent(new StatusEventArgs("Done Making sure every table within TestDB has at least 10 items"));

            StatusTempEvent(new StatusEventArgs("Done ..."));
            StatusPermanentEvent(new StatusEventArgs(""));
            StatusPermanentEvent(new StatusEventArgs("Done ..."));
            StatusPermanentEvent(new StatusEventArgs(""));

        }
        #endregion Functions public

        #region Functions private
        /// <summary>
        ///     Cleans the TestDB by deleting all the information for each tables
        /// </summary>
        /// <param name="tableTestDBList">List of TestDB related table information</param>
        /// <param name="TestDBConnectionString">TestDB connection string</param>
        /// <returns>True if everything went ok</returns>
        private bool CleanTestDB(List<Table> tableTestDBList, string TestDBConnectionString)
        {
            if (!SetTestDBDeleteOrderedList(tableTestDBList)) return false;

            try
            {
                using (SqlConnection cnn = new SqlConnection(TestDBConnectionString))
                {
                    if (!cnn.ConnectionString.Contains("TestDB"))
                    {
                        CSSPErrorEvent(new CSSPErrorEventArgs("Only use this command for the TestDB as it remove all the information from the DB and Reseed all tables"));
                        return false;
                    }

                    cnn.Open();

                    foreach (Table table in tableTestDBList.OrderBy(c => c.ordinalToDelete))
                    {
                        StatusTempEvent(new StatusEventArgs($"Deleting Table  [{ table.TableName }]"));
                        //Application.DoEvents();
                        string queryString = "";

                        if (table.TableName == "TVItems")
                        {
                            for (int i = 10; i >= 0; i--)
                            {
                                queryString = $"DELETE FROM { table.TableName } WHERE TVLevel = { i }";

                                using (SqlCommand cmd = new SqlCommand(queryString, cnn))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            queryString = $"DELETE FROM { table.TableName }";

                            using (SqlCommand cmd = new SqlCommand(queryString, cnn))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }

                        if (table.TableName == "AspNetRoles" || table.TableName == "AspNetUserLogins" || table.TableName == "AspNetUserRoles" || table.TableName == "AspNetUsers")
                        {
                            continue;
                        }

                        queryString = $"DBCC CHECKIDENT('{ table.TableName }', RESEED, 0)";

                        using (SqlCommand cmd = new SqlCommand(queryString, cnn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                string InnerExceptiion = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerExceptiion }"));
                return false;
            }

            return true;
        }
        /// <summary>
        ///     Compares the TestDB and CSSPDB (every tables and fields)
        /// </summary>
        /// <param name="tableCSSPDBList">List of CSSPDB related table information</param>
        /// <param name="tableTestDBList">List of TestDB related table information</param>
        /// <returns>True if everything went ok</returns>
        private bool CompareDBs(List<Table> tableCSSPDBList, List<Table> tableTestDBList)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Table tableCSSP in tableCSSPDBList)
            {
                StatusTempEvent(new StatusEventArgs(tableCSSP.TableName));
                //Application.DoEvents();

                if (tableCSSP.TableName == "sysdiagrams") continue;

                Table tableTest = (from c in tableTestDBList
                                   where c.TableName == tableCSSP.TableName
                                   select c).FirstOrDefault();

                if (tableTest == null)
                {
                    sb.AppendLine($"{ tableCSSP.TableName } does not exist in TestDB");
                    continue;
                }

                foreach (Col col in tableCSSP.colList)
                {
                    StatusTempEvent(new StatusEventArgs($"{ tableCSSP.TableName }    { col.FieldName }"));
                    //Application.DoEvents();

                    Col colTest = (from c in tableTest.colList
                                   where c.FieldName == col.FieldName
                                   select c).FirstOrDefault();

                    if (colTest == null)
                    {
                        sb.AppendLine($"{ tableCSSP.TableName }\t{ col.FieldName } does not exist in TestDB");
                    }

                    if (col.AllowNull != colTest.AllowNull)
                    {
                        sb.AppendLine($"{ tableCSSP.TableName }\t{ col.FieldName } Allow Null does not match in TestDB");
                    }

                    if (col.DataType != colTest.DataType)
                    {
                        sb.AppendLine($"{ tableCSSP.TableName }\t{ col.FieldName } Data Type does not match in TestDB");
                    }

                    if (col.StringLength != colTest.StringLength)
                    {
                        sb.AppendLine($"{ tableCSSP.TableName }\t{ col.FieldName } String Length does not match in TestDB");
                    }
                }
            }

            if (sb.ToString().Length > 0)
            {

                StatusPermanentEvent(new StatusEventArgs(sb.ToString()));
                return false;
            }

            return true;
        }
        /// <summary>
        ///     Fills the TestDB with a few items per tables (each table will have at least 10 rows)
        /// </summary>
        /// <param name="tableTestDBList">List of TestDB related table information</param>
        /// <returns>True if everything went ok</returns>
        private bool FillTestDB(List<Table> tableTestDBList)
        {
            #region TVItem Root
            StatusTempEvent(new StatusEventArgs("doing ... root"));
            // TVItem Root TVItemID = 1
            TVItem tvItemRoot = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == c.ParentID && c.TVLevel == 0).FirstOrDefault();
            int RootTVItemID = tvItemRoot.TVItemID;
            if (!AddObject("TVItem", tvItemRoot)) return false;

            // TVItemLanguage EN Root TVItemID = 1
            TVItemLanguage tvItemLanguageENRoot = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == RootTVItemID && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENRoot.TVItemID = tvItemRoot.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENRoot)) return false;

            // TVItemLanguage FR Root TVItemID = 1
            TVItemLanguage tvItemLanguageFRRoot = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == RootTVItemID && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRRoot.TVItemID = tvItemRoot.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRRoot)) return false;
            #endregion  TVItem Root
            #region Contact Charles with TVItem
            StatusTempEvent(new StatusEventArgs("doing ... Contact Charles with TVItem"));
            // TVItem Charles G. LeBlanc TVItemID = 2
            TVItem tvItemContactCharles = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 2).FirstOrDefault();
            tvItemContactCharles.ParentID = tvItemRoot.TVItemID;
            if (!AddObject("TVItem", tvItemContactCharles)) return false;
            if (!CorrectTVPath(tvItemContactCharles, tvItemRoot)) return false;

            // TVItemLanguage EN Charles G. LeBlanc  TVItemID = 2
            TVItemLanguage tvItemLanguageENContactCharles = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 2 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENContactCharles.TVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENContactCharles)) return false;

            // TVItemLanguage FR Charles G. LeBlanc TVItemID = 2
            TVItemLanguage tvItemLanguageFRContactCharles = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 2 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRContactCharles.TVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRContactCharles)) return false;

            StatusTempEvent(new StatusEventArgs("doing ... Contact Charles with TVItem"));

            ContactService contactService = new ContactService(new Query(), dbTestDB, 2);

            // Contact Charles G. LeBlanc
            Contact contactCharles = dbCSSPDB.Contacts.AsNoTracking().Where(c => c.ContactTVItemID == 2).FirstOrDefault();
            AspNetUser aspNetUserCharles = dbCSSPDB.AspNetUsers.AsNoTracking().Where(c => c.Id == contactCharles.Id).FirstOrDefault();
            if (!AddObject("AspNetUser", aspNetUserCharles)) return false;
            if (!AddObject("Contact", contactCharles)) return false;
            #endregion Contact Charles with TVItem
            #region Contact Test User 1 with TVItem
            StatusTempEvent(new StatusEventArgs("doing ... TVItem Contact and Contact Login test user 1"));
            // TVItem Test User 1 TVItemID = 3
            TVItem tvItemContactTestUser1 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 3).FirstOrDefault();
            tvItemContactTestUser1.ParentID = tvItemRoot.TVItemID;
            if (!AddObject("TVItem", tvItemContactTestUser1)) return false;
            if (!CorrectTVPath(tvItemContactTestUser1, tvItemRoot)) return false;

            // TVItemLanguage EN Test User 1  TVItemID = 3
            TVItemLanguage tvItemLanguageENContactTestUser1 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 3 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENContactTestUser1.TVItemID = tvItemContactTestUser1.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENContactTestUser1)) return false;

            // TVItemLanguage FR Test User 1 TVItemID = 3
            TVItemLanguage tvItemLanguageFRContactTestUser1 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 3 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRContactTestUser1.TVItemID = tvItemContactTestUser1.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRContactTestUser1)) return false;

            // Contact Test User 1
            Contact contactTestUser1 = dbCSSPDB.Contacts.AsNoTracking().Where(c => c.ContactTVItemID == 3).FirstOrDefault();
            AspNetUser aspNetUserTestUser1 = dbCSSPDB.AspNetUsers.AsNoTracking().Where(c => c.Id == contactTestUser1.Id).FirstOrDefault();
            if (!AddObject("AspNetUser", aspNetUserTestUser1)) return false;
            if (!AddObject("Contact", contactTestUser1)) return false;
            #endregion Contact Test User 1 with TVItem
            #region Contact Test User 2 with TVItem
            StatusTempEvent(new StatusEventArgs("doing ... TVItem Contact and Contact Login test user 1"));

            // TVItem Test User 2 TVItemID = 4
            TVItem tvItemContactTestUser2 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 4).FirstOrDefault();
            tvItemContactTestUser2.ParentID = tvItemRoot.TVItemID;
            if (!AddObject("TVItem", tvItemContactTestUser2)) return false;
            if (!CorrectTVPath(tvItemContactTestUser2, tvItemRoot)) return false;

            // TVItemLanguage EN Test User 2  TVItemID = 4
            TVItemLanguage tvItemLanguageENContactTestUser2 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 4 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENContactTestUser2.TVItemID = tvItemContactTestUser2.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENContactTestUser2)) return false;

            // TVItemLanguage FR Test User 2 TVItemID = 4
            TVItemLanguage tvItemLanguageFRContactTestUser2 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 4 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRContactTestUser2.TVItemID = tvItemContactTestUser2.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRContactTestUser2)) return false;

            // Contact Test User 2
            Contact contactTestUser2 = dbCSSPDB.Contacts.AsNoTracking().Where(c => c.ContactTVItemID == 4).FirstOrDefault();
            AspNetUser aspNetUserTestUser2 = dbCSSPDB.AspNetUsers.AsNoTracking().Where(c => c.Id == contactTestUser2.Id).FirstOrDefault();
            if (!AddObject("AspNetUser", aspNetUserTestUser2)) return false;
            if (!AddObject("Contact", contactTestUser2)) return false;
            #endregion Contact Test User 2 with TVItem
            #region TVItem Country Canada
            StatusTempEvent(new StatusEventArgs("doing ... Canada"));
            // TVItem Canada TVItemID = 5
            TVItem tvItemCanada = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 5).FirstOrDefault();
            tvItemCanada.ParentID = tvItemRoot.TVItemID;
            if (!AddObject("TVItem", tvItemCanada)) return false;
            if (!CorrectTVPath(tvItemCanada, tvItemRoot)) return false;
            if (!AddMapInfo(tvItemCanada, 5, tvItemContactCharles.TVItemID)) return false;

            // TVItemLanguage EN Canada TVItemID = 5
            TVItemLanguage tvItemLanguageENCanada = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 5 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENCanada.TVItemID = tvItemCanada.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENCanada)) return false;

            // TVItemLanguage FR Canada TVItemID = 5
            TVItemLanguage tvItemLanguageFRCanada = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 5 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRCanada.TVItemID = tvItemCanada.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRCanada)) return false;
            #endregion TVItem Country Canada
            #region TVItem Province NB
            StatusTempEvent(new StatusEventArgs("doing ... New Brunswick"));
            // TVItem Province NB TVItemID = 7
            TVItem tvItemNB = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 7).FirstOrDefault();
            int NBTVItemID = tvItemNB.TVItemID;
            tvItemNB.ParentID = tvItemCanada.TVItemID;
            if (!AddObject("TVItem", tvItemNB)) return false;
            if (!CorrectTVPath(tvItemNB, tvItemCanada)) return false;
            if (!AddMapInfo(tvItemNB, NBTVItemID, tvItemContactCharles.TVItemID)) return false;

            // TVItemLanguage EN NB TVItemID = 7
            TVItemLanguage tvItemLanguageENNB = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNB.TVItemID = tvItemNB.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNB)) return false;

            // TVItemLanguage FR NB TVItemID = 7
            TVItemLanguage tvItemLanguageFRNB = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNB.TVItemID = tvItemNB.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNB)) return false;
            #endregion TVItem Province NB
            #region TVItem ClimateSite Bouctouche CDA
            StatusTempEvent(new StatusEventArgs("doing ... Climate Site"));
            // TVItem ClimateSite Bouctouche CDA TVItemID = 229528
            TVItem tvItemNBClimateSiteBouctoucheCDA = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 229528).FirstOrDefault();
            tvItemNBClimateSiteBouctoucheCDA.ParentID = tvItemNB.TVItemID;
            if (!AddObject("TVItem", tvItemNBClimateSiteBouctoucheCDA)) return false;
            if (!CorrectTVPath(tvItemNBClimateSiteBouctoucheCDA, tvItemNB)) return false;
            if (!AddMapInfo(tvItemNBClimateSiteBouctoucheCDA, 229528, tvItemContactCharles.TVItemID)) return false;

            // TVItemLanguage EN Climate Site Bouctouche CDA NB TVItemID = 229528
            TVItemLanguage tvItemLanguageENNBClimateSiteBouctoucheCDA = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 229528 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNBClimateSiteBouctoucheCDA.TVItemID = tvItemNBClimateSiteBouctoucheCDA.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNBClimateSiteBouctoucheCDA)) return false;

            // TVItemLanguage FR Climate Site Bouctouche CDA NB TVItemID = 229528
            TVItemLanguage tvItemLanguageFRNBClimateSiteBouctoucheCDA = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 229528 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNBClimateSiteBouctoucheCDA.TVItemID = tvItemNBClimateSiteBouctoucheCDA.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNBClimateSiteBouctoucheCDA)) return false;
            #endregion TVItem ClimateSite Bouctouche CDA
            #region ClimateSite Bouctouche CDA

            // NB Climate Site Bouctouche CDA where ClimateSiteTVItemID = 229528
            ClimateSite climateSite = dbCSSPDB.ClimateSites.AsNoTracking().Where(c => c.ClimateSiteTVItemID == 229528).FirstOrDefault();
            int ClimateSiteID = climateSite.ClimateSiteID;
            climateSite.ClimateSiteTVItemID = tvItemNBClimateSiteBouctoucheCDA.TVItemID;
            if (!AddObject("ClimateSite", climateSite)) return false;

            // NB Climate Data Value Bouctouche CDA where ClimateSiteTVItemID = 229528
            List<ClimateDataValue> climateDataValueList = dbCSSPDB.ClimateDataValues.AsNoTracking().Where(c => c.ClimateSiteID == ClimateSiteID && c.TotalPrecip_mm_cm != -999.0f).Take(5).ToList();
            foreach (ClimateDataValue climateDataValue in climateDataValueList)
            {
                climateDataValue.ClimateSiteID = climateSite.ClimateSiteID;
                climateDataValue.HourlyValues = "Some value";
                if (!AddObject("ClimateDataValue", climateDataValue)) return false;
            }
            #endregion ClimateSite Bouctouche CDA
            #region TVItem HydrometricSite Big Tracadie 01BL003 
            StatusTempEvent(new StatusEventArgs("doing ... Hydrometric Site"));
            // TVItem HydrometricSite Big Tracadie 01BL003 TVItemID = 55401
            TVItem tvItemNBHydrometricSiteBigTracadie = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 55401).FirstOrDefault();
            tvItemNBHydrometricSiteBigTracadie.ParentID = tvItemNB.TVItemID;
            if (!AddObject("TVItem", tvItemNBHydrometricSiteBigTracadie)) return false;
            if (!CorrectTVPath(tvItemNBHydrometricSiteBigTracadie, tvItemNB)) return false;
            if (!AddMapInfo(tvItemNBHydrometricSiteBigTracadie, 55401, tvItemContactCharles.TVItemID)) return false;

            // TVItemLanguage EN Hydrometric site Big Tracadie NB TVItemID = 55401
            TVItemLanguage tvItemLanguageENNBHydrometricSiteBigTracadie = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 55401 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNBHydrometricSiteBigTracadie.TVItemID = tvItemNBHydrometricSiteBigTracadie.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNBHydrometricSiteBigTracadie)) return false;

            // TVItemLanguage FR Hydrometric site Big Tracadie NB TVItemID = 55401
            TVItemLanguage tvItemLanguageFRNBHydrometricSiteBigTracadie = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 55401 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNBHydrometricSiteBigTracadie.TVItemID = tvItemNBHydrometricSiteBigTracadie.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNBHydrometricSiteBigTracadie)) return false;
            #endregion TVItem HydrometricSite Big Tracadie 01BL003 
            #region HydrometricSite Big Tracadie 01BL003 

            // NB Hydrometric site Big Tracadie where HydrometricSiteTVItemID = 55401
            HydrometricSite hydrometricSite = dbCSSPDB.HydrometricSites.AsNoTracking().Where(c => c.HydrometricSiteTVItemID == 55401).FirstOrDefault();
            int HydrometricSiteID = hydrometricSite.HydrometricSiteID;
            hydrometricSite.HydrometricSiteTVItemID = tvItemNBHydrometricSiteBigTracadie.TVItemID;
            if (!AddObject("HydrometricSite", hydrometricSite)) return false;

            // NB Hydrometric site Big Tracadie where HydrometricSiteTVItemID = 55401
            HydrometricDataValue hydrometricDataValue = new HydrometricDataValue();
            hydrometricDataValue.HydrometricSiteID = hydrometricSite.HydrometricSiteID;
            hydrometricDataValue.DateTime_Local = DateTime.Now;
            hydrometricDataValue.Keep = true;
            hydrometricDataValue.StorageDataType = StorageDataTypeEnum.Archived;
            hydrometricDataValue.Discharge_m3_s = 23.4f;
            hydrometricDataValue.DischargeEntered_m3_s = null;
            hydrometricDataValue.Level_m = 3.0f;
            hydrometricDataValue.HourlyValues = "Some hourly values text";
            hydrometricDataValue.LastUpdateDate_UTC = DateTime.Now;
            hydrometricDataValue.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("HydrometricDataValue", hydrometricDataValue)) return false;
            #endregion HydrometricSite Big Tracadie 01BL003 
            #region RatingCurve Big Tracadie 01BL003 
            StatusTempEvent(new StatusEventArgs("doing ... Rating Curve"));

            // NB Hydrometric site Big Tracadie where HydrometricSiteTVItemID = 55401
            RatingCurve ratingCurve = dbCSSPDB.RatingCurves.AsNoTracking().Where(c => c.HydrometricSiteID == HydrometricSiteID).FirstOrDefault();
            int RatingCurveID = ratingCurve.RatingCurveID;
            ratingCurve.HydrometricSiteID = hydrometricSite.HydrometricSiteID;
            if (!AddObject("RatingCurve", ratingCurve)) return false;
            #endregion RatingCurve Big Tracadie 01BL003 
            #region RatingCurveValue Big Tracadie 01BL003 
            StatusTempEvent(new StatusEventArgs("doing ... Rating Curve Value"));
            // NB Hydrometric site Big Tracadie where HydrometricSiteTVItemID = 55401
            List<RatingCurveValue> ratingCurveValueList = dbCSSPDB.RatingCurveValues.AsNoTracking().Where(c => c.RatingCurveID == RatingCurveID).Take(5).ToList();
            foreach (RatingCurveValue ratingCurveValue in ratingCurveValueList)
            {
                ratingCurveValue.RatingCurveID = ratingCurve.RatingCurveID;
                if (!AddObject("RatingCurveValue", ratingCurveValue)) return false;
            }
            #endregion RatingCurve Big Tracadie 01BL003 
            #region TVItem Area NB-06 
            StatusTempEvent(new StatusEventArgs("doing ... Area NB-06"));
            // TVItem Area NB-06 TVItemID = 629
            TVItem tvItemNB_06 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 629).FirstOrDefault();
            tvItemNB_06.ParentID = tvItemNB.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06)) return false;
            if (!CorrectTVPath(tvItemNB_06, tvItemNB)) return false;
            if (!AddMapInfo(tvItemNB_06, 629, tvItemContactCharles.TVItemID)) return false;

            // TVItemLanguage EN NB-06 TVItemID = 629
            TVItemLanguage tvItemLanguageENNB_06 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 629 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNB_06.TVItemID = tvItemNB_06.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNB_06)) return false;

            // TVItemLanguage FR NB_06 TVItemID = 629
            TVItemLanguage tvItemLanguageFRNB_06 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 629 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNB_06.TVItemID = tvItemNB_06.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNB_06)) return false;
            #endregion TVItem Area NB-06 
            #region TVItem Sector NB-06-020 
            StatusTempEvent(new StatusEventArgs("doing ... Sector NB-06-020"));
            // TVItem Sector NB-06_020 TVItemID = 633
            TVItem tvItemNB_06_020 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 633).FirstOrDefault();
            tvItemNB_06_020.ParentID = tvItemNB_06.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06_020)) return false;
            if (!CorrectTVPath(tvItemNB_06_020, tvItemNB_06)) return false;
            if (!AddMapInfo(tvItemNB_06_020, 633, tvItemContactCharles.TVItemID)) return false;

            // TVItemLanguage EN NB-06_020 TVItemID = 633
            TVItemLanguage tvItemLanguageENNB_06_020 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 633 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNB_06_020.TVItemID = tvItemNB_06_020.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNB_06_020)) return false;

            // TVItemLanguage FR NB_06_020 TVItemID = 633
            TVItemLanguage tvItemLanguageFRNB_06_020 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 633 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNB_06_020.TVItemID = tvItemNB_06_020.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020)) return false;
            #endregion TVItem Sector NB-06-020 
            #region TVItem Subsector NB-06_020_001 
            StatusTempEvent(new StatusEventArgs("doing ... Subsector NB-06-020-001"));
            // TVItem Subsector NB-06_020_001 TVItemID = 634
            TVItem tvItemNB_06_020_001 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 634).FirstOrDefault();
            tvItemNB_06_020_001.ParentID = tvItemNB_06_020.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06_020_001)) return false;
            if (!CorrectTVPath(tvItemNB_06_020_001, tvItemNB_06_020)) return false;
            if (!AddMapInfo(tvItemNB_06_020_001, 634, tvItemContactCharles.TVItemID)) return false;

            // TVItemLanguage EN NB-06_020_001 TVItemID = 634
            TVItemLanguage tvItemLanguageENNB_06_020_001 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 634 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNB_06_020_001.TVItemID = tvItemNB_06_020_001.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_001)) return false;

            // TVItemLanguage FR NB_06_020 TVItemID = 634
            TVItemLanguage tvItemLanguageFRNB_06_020_001 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 634 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNB_06_020_001.TVItemID = tvItemNB_06_020_001.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_001)) return false;
            #endregion TVItem Subsector NB-06_020_001 
            #region MWQMSubsector NB-06_020_001 and MWQMSubsectorLanguage
            StatusTempEvent(new StatusEventArgs("doing ... MWQM Subsector NB-06-020-001"));
            // MWQMSubsector NB-06_020_001 TVItemID = 634
            MWQMSubsector mwqmSubsector001 = dbCSSPDB.MWQMSubsectors.AsNoTracking().Where(c => c.MWQMSubsectorTVItemID == 634).FirstOrDefault();
            int MWQMSubsector001ID = mwqmSubsector001.MWQMSubsectorID;
            mwqmSubsector001.MWQMSubsectorTVItemID = tvItemNB_06_020_001.TVItemID;
            if (!AddObject("MWQMSubsector", mwqmSubsector001)) return false;

            // MWQMSubsectorLanguage EN NB-06_020_001 TVItemID = 634
            MWQMSubsectorLanguage mwqmSubsector001EN = dbCSSPDB.MWQMSubsectorLanguages.AsNoTracking().Where(c => c.MWQMSubsectorID == MWQMSubsector001ID && c.Language == LanguageEnum.en).FirstOrDefault();
            mwqmSubsector001EN.MWQMSubsectorID = mwqmSubsector001.MWQMSubsectorID;
            mwqmSubsector001EN.LogBook = "somthing in the logbook";
            if (!AddObject("MWQMSubsectorLanguage", mwqmSubsector001EN)) return false;

            // MWQMSubsectorLanguage FR NB-06_020_001 TVItemID = 634
            MWQMSubsectorLanguage mwqmSubsector001FR = dbCSSPDB.MWQMSubsectorLanguages.AsNoTracking().Where(c => c.MWQMSubsectorID == MWQMSubsector001ID && c.Language == LanguageEnum.fr).FirstOrDefault();
            mwqmSubsector001FR.MWQMSubsectorID = mwqmSubsector001.MWQMSubsectorID;
            mwqmSubsector001FR.LogBook = "somthing in the logbook";
            if (!AddObject("MWQMSubsectorLanguage", mwqmSubsector001FR)) return false;
            #endregion TVItem Subsector NB-06_020_001 
            #region TVItem Subsector NB-06_020_002 
            StatusTempEvent(new StatusEventArgs("doing ... Subsector NB-06-020-002"));
            // TVItem Subsector NB-06_020_002 TVItemID = 635
            TVItem tvItemNB_06_020_002 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 635).FirstOrDefault();
            tvItemNB_06_020_002.ParentID = tvItemNB_06_020.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06_020_002)) return false;
            if (!CorrectTVPath(tvItemNB_06_020_002, tvItemNB_06_020)) return false;
            if (!AddMapInfo(tvItemNB_06_020_002, 635, tvItemContactCharles.TVItemID)) return false;

            // TVItemLanguage EN NB-06_020_001 TVItemID = 635
            TVItemLanguage tvItemLanguageENNB_06_020_002 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 635 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNB_06_020_002.TVItemID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_002)) return false;

            // TVItemLanguage FR NB_06_020 TVItemID = 635
            TVItemLanguage tvItemLanguageFRNB_06_020_002 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 635 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNB_06_020_002.TVItemID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_002)) return false;
            #endregion TVItem Subsector NB-06_020_001 
            #region MWQMSubsector NB-06_020_002 and MWQMSubsectorLanguage
            StatusTempEvent(new StatusEventArgs("doing ... MWQM Subsector NB-06-020-002"));
            // MWQMSubsector NB-06_020_002 TVItemID = 635
            MWQMSubsector mwqmSubsector002 = dbCSSPDB.MWQMSubsectors.AsNoTracking().Where(c => c.MWQMSubsectorTVItemID == 635).FirstOrDefault();
            int MWQMSubsector002ID = mwqmSubsector002.MWQMSubsectorID;
            mwqmSubsector002.MWQMSubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("MWQMSubsector", mwqmSubsector002)) return false;

            // MWQMSubsectorLanguage EN NB-06_020_002 TVItemID = 635
            MWQMSubsectorLanguage mwqmSubsector002EN = dbCSSPDB.MWQMSubsectorLanguages.AsNoTracking().Where(c => c.MWQMSubsectorID == MWQMSubsector002ID && c.Language == LanguageEnum.en).FirstOrDefault();
            mwqmSubsector002EN.MWQMSubsectorID = mwqmSubsector002.MWQMSubsectorID;
            mwqmSubsector002EN.LogBook = "Something in the logbook";
            if (!AddObject("MWQMSubsectorLanguage", mwqmSubsector002EN)) return false;

            // MWQMSubsectorLanguage FR NB-06_020_002 TVItemID = 635
            MWQMSubsectorLanguage mwqmSubsector002FR = dbCSSPDB.MWQMSubsectorLanguages.AsNoTracking().Where(c => c.MWQMSubsectorID == MWQMSubsector002ID && c.Language == LanguageEnum.fr).FirstOrDefault();
            mwqmSubsector002FR.MWQMSubsectorID = mwqmSubsector002.MWQMSubsectorID;
            mwqmSubsector002FR.LogBook = "Something in the logbook";
            if (!AddObject("MWQMSubsectorLanguage", mwqmSubsector002FR)) return false;
            #endregion TVItem Subsector NB-06_020_002 
            #region TVItem Classification  and Classification
            StatusTempEvent(new StatusEventArgs("doing ... Classification"));
            // TVItem Classification where parent TVItemID = 635
            List<TVItem> tvItemClassificationList = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.ParentID == 635 && c.TVType == TVTypeEnum.Classification).ToList();
            foreach (TVItem tvItem in tvItemClassificationList)
            {
                int oldTVItemID = tvItem.TVItemID;
                TVItem tvItemClassNew = tvItem;
                tvItemClassNew.ParentID = tvItemNB_06_020_002.TVItemID;
                if (!AddObject("TVItem", tvItemClassNew)) return false;
                if (!CorrectTVPath(tvItemClassNew, tvItemNB_06_020_002)) return false;
                if (!AddMapInfo(tvItemClassNew, oldTVItemID, tvItemContactCharles.TVItemID)) return false;

                // TVItemLanguage EN where parent TVItemID = 635
                TVItemLanguage tvItemLanguageENNClass = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == oldTVItemID && c.Language == LanguageEnum.en).FirstOrDefault();
                tvItemLanguageENNClass.TVItemID = tvItemClassNew.TVItemID;
                if (!AddObject("TVItemLanguage", tvItemLanguageENNClass)) return false;

                // TVItemLanguage FR NB_06_020 TVItemID = 635
                TVItemLanguage tvItemLanguageFRClass = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == oldTVItemID && c.Language == LanguageEnum.fr).FirstOrDefault();
                tvItemLanguageFRClass.TVItemID = tvItemClassNew.TVItemID;
                if (!AddObject("TVItemLanguage", tvItemLanguageFRClass)) return false;


                Classification classificaton = dbCSSPDB.Classifications.AsNoTracking().Where(c => c.ClassificationTVItemID == oldTVItemID).FirstOrDefault();
                Classification classificationNew = classificaton;
                classificationNew.ClassificationTVItemID = tvItemClassNew.TVItemID;
                if (!AddObject("Classification", classificationNew)) return false;
            }
            #endregion TVItem Classification and Classification
            #region TideSites (Cap Pelé)
            StatusTempEvent(new StatusEventArgs("doing ... Cap Pelé"));
            // TVItem Cap Pelé TVItemID = 369979
            TVItem tvItemCapPeleTideSite = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 369979).FirstOrDefault();
            tvItemCapPeleTideSite.ParentID = tvItemNB.TVItemID;
            if (!AddObject("TVItem", tvItemCapPeleTideSite)) return false;
            if (!CorrectTVPath(tvItemCapPeleTideSite, tvItemNB)) return false;
            if (!AddMapInfo(tvItemCapPeleTideSite, 369979, tvItemContactCharles.TVItemID)) return false;

            // TVItemLanguage EN Cap Pelé TVItemID = 369979
            TVItemLanguage tvItemLanguageENCapPele = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 369979 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENCapPele.TVItemID = tvItemCapPeleTideSite.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENCapPele)) return false;

            // TVItemLanguage FR Cap Pelé TVItemID = 369979
            TVItemLanguage tvItemLanguageFRCapPele = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 369979 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRCapPele.TVItemID = tvItemCapPeleTideSite.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRCapPele)) return false;

            StatusTempEvent(new StatusEventArgs("doing ... Tide Site"));
            // TideSite where TideSiteTVItemID = 369979
            TideSite tideSite = dbCSSPDB.TideSites.AsNoTracking().Where(c => c.TideSiteTVItemID == 369979).FirstOrDefault();
            tideSite.TideSiteTVItemID = tvItemCapPeleTideSite.TVItemID;
            if (!AddObject("TideSite", tideSite)) return false;
            #endregion TideSites
            #region TideDataValues
            // TideDataValue
            List<TideDataValue> tideDataValueList = dbCSSPDB.TideDataValues.AsNoTracking().ToList();
            if (tideDataValueList.Count > 0)
            {
                foreach (TideDataValue tideDataValue in tideDataValueList)
                {
                    tideDataValue.TideSiteTVItemID = tideSite.TideSiteTVItemID;
                    if (!AddObject("TideDataValue", tideDataValue)) return false;
                }
            }
            else
            {
                TideDataValue tideDataValue = new TideDataValue()
                {
                    DateTime_Local = DateTime.Now,
                    Depth_m = 23.2f,
                    Keep = true,
                    StorageDataType = StorageDataTypeEnum.Archived,
                    TideDataType = TideDataTypeEnum.Min15,
                    TideEnd = TideTextEnum.HighTide,
                    TideStart = TideTextEnum.HighTide,
                    TideSiteTVItemID = tideSite.TideSiteTVItemID,
                    UVelocity_m_s = 0.4f,
                    VVelocity_m_s = 0.3f,
                    LastUpdateDate_UTC = DateTime.Now,
                    LastUpdateContactTVItemID = 2,
                };
                if (!AddObject("TideDataValue", tideDataValue)) return false;
            }
            #endregion TideDataValues
            #region TVItem Municipality Bouctouche
            StatusTempEvent(new StatusEventArgs("doing ... Bouctouche"));
            // TVItem Municipality Bouctouche TVItemID = 27764
            TVItem tvItemBouctouche = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 27764).FirstOrDefault();
            tvItemBouctouche.ParentID = tvItemNB.TVItemID;
            if (!AddObject("TVItem", tvItemBouctouche)) return false;
            if (!CorrectTVPath(tvItemBouctouche, tvItemNB)) return false;
            if (!AddMapInfo(tvItemBouctouche, 27764, tvItemContactCharles.TVItemID)) return false;

            // TVItemLanguage EN Bouctouche TVItemID = 27764
            TVItemLanguage tvItemLanguageENBouctouche = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 27764 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENBouctouche.TVItemID = tvItemBouctouche.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENBouctouche)) return false;

            // TVItemLanguage FR Bouctouche TVItemID = 27764
            TVItemLanguage tvItemLanguageFRBouctouche = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 27764 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRBouctouche.TVItemID = tvItemBouctouche.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRBouctouche)) return false;
            #endregion TVItem Municipality Bouctouche
            #region TVItem Municipality Ste Marie de Kent 
            StatusTempEvent(new StatusEventArgs("doing ... Ste-Marie-de-Kent"));
            // TVItem Municipality Ste Marie de Kent TVItemID = 44855
            TVItem tvItemSteMarieDeKent = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 44855).FirstOrDefault();
            tvItemSteMarieDeKent.ParentID = tvItemNB.TVItemID;
            if (!AddObject("TVItem", tvItemSteMarieDeKent)) return false;
            if (!CorrectTVPath(tvItemSteMarieDeKent, tvItemNB)) return false;
            if (!AddMapInfo(tvItemSteMarieDeKent, 44855, tvItemContactCharles.TVItemID)) return false;

            // TVItemLanguage EN Ste Marie de Kent TVItemID = 44855
            TVItemLanguage tvItemLanguageENSteMarieDeKent = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 44855 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENSteMarieDeKent.TVItemID = tvItemSteMarieDeKent.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENSteMarieDeKent)) return false;

            // TVItemLanguage FR Ste Marie de Kent TVItemID = 44855
            TVItemLanguage tvItemLanguageFRSteMarieDeKent = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 44855 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRSteMarieDeKent.TVItemID = tvItemSteMarieDeKent.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRSteMarieDeKent)) return false;
            #endregion TVItem Municipality Ste Marie de Kent 
            #region TVItem Municipality Bouctouche WWTP 
            StatusTempEvent(new StatusEventArgs("doing ... Bouctouche WWTP"));
            // TVItem Municipality Bouctouche WWTP TVItemID = 28689
            TVItem tvItemBouctoucheWWTP = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 28689).FirstOrDefault();
            tvItemBouctoucheWWTP.ParentID = tvItemBouctouche.TVItemID;
            if (!AddObject("TVItem", tvItemBouctoucheWWTP)) return false;
            if (!CorrectTVPath(tvItemBouctoucheWWTP, tvItemBouctouche)) return false;
            tvItemBouctoucheWWTP.TVType = TVTypeEnum.WasteWaterTreatmentPlant;
            if (!AddMapInfo(tvItemBouctoucheWWTP, 28689, tvItemContactCharles.TVItemID)) return false;
            tvItemBouctoucheWWTP.TVType = TVTypeEnum.Infrastructure;

            // TVItemLanguage EN Bouctouche WWTP TVItemID = 28689
            TVItemLanguage tvItemLanguageENBouctoucheWWTP = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28689 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENBouctoucheWWTP.TVItemID = tvItemBouctoucheWWTP.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENBouctoucheWWTP)) return false;

            // TVItemLanguage FR Bouctouche WWTP TVItemID = 28689
            TVItemLanguage tvItemLanguageFRBouctoucheWWTP = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28689 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRBouctoucheWWTP.TVItemID = tvItemBouctoucheWWTP.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRBouctoucheWWTP)) return false;
            #endregion TVItem Municipality Bouctouche WWTP 
            #region ReportType
            StatusTempEvent(new StatusEventArgs("doing ... ReportTypes and ReportTypeLanguages"));
            ReportType reportType = dbCSSPDB.ReportTypes.AsNoTracking().FirstOrDefault();
            int ReportTypeIDOld = reportType.ReportTypeID;
            reportType.ReportTypeID = 0;
            if (!AddObject("ReportType", reportType)) return false;
            #endregion ReportType
            #region ReportSection
            StatusTempEvent(new StatusEventArgs("doing ... ReportSections"));
            ReportSection reportSection = dbCSSPDB.ReportSections.AsNoTracking().Where(c => c.ReportTypeID == ReportTypeIDOld).FirstOrDefault();
            int ReportSectionIDOld = reportSection.ReportSectionID;
            reportSection.ReportSectionID = 0;
            reportSection.ReportTypeID = reportType.ReportTypeID;
            if (!AddObject("ReportSection", reportSection)) return false;
            #endregion ReportSection
            #region TVItem TVFile Bouctouche WWTP 
            StatusTempEvent(new StatusEventArgs("doing ... Bouctouche WWTP TVFile"));
            // TVItem TVFile Bouctouche WWTP TVItemID = 28689
            TVItem TempBouctWWTP = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 28689).FirstOrDefault();
            TVItem tvItemBouctoucheWWTPTVFile = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVPath.StartsWith($"{ TempBouctWWTP.TVPath }p") && c.TVType == TVTypeEnum.File).FirstOrDefault();
            int TempTVItemID = tvItemBouctoucheWWTPTVFile.TVItemID;
            tvItemBouctoucheWWTPTVFile.ParentID = tvItemBouctoucheWWTP.TVItemID;
            if (!AddObject("TVItem", tvItemBouctoucheWWTPTVFile)) return false;
            if (!CorrectTVPath(tvItemBouctoucheWWTPTVFile, tvItemBouctoucheWWTP)) return false;
            if (!AddMapInfo(tvItemBouctoucheWWTPTVFile, TempTVItemID, tvItemContactCharles.TVItemID)) return false;

            // TVItemLanguage EN TVItem for Image for Bouctouche WWTP TVItemID = 28689
            TVItemLanguage tvItemBouctoucheWWTPTVFileImageEN = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == TempTVItemID && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemBouctoucheWWTPTVFileImageEN.TVItemID = tvItemBouctoucheWWTPTVFile.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemBouctoucheWWTPTVFileImageEN)) return false;

            // TVItemLanguage FR TVItem for Image for Bouctouche WWTP TVItemID = 28689
            TVItemLanguage tvItemBouctoucheWWTPTVFileImageFR = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == TempTVItemID && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemBouctoucheWWTPTVFileImageFR.TVItemID = tvItemBouctoucheWWTPTVFile.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemBouctoucheWWTPTVFileImageFR)) return false;
            #endregion TVItem TVFile Bouctouche WWTP 
            #region TVFile Bouctouche WWTP 
            StatusTempEvent(new StatusEventArgs("doing ... Bouctouche WWTP TVFile"));
            // TVFile Bouctouche WWTP TVItemID = 28689
            TVFile tvFileBouctoucheWWTP = dbCSSPDB.TVFiles.AsNoTracking().Where(c => c.TVFileTVItemID == TempTVItemID).FirstOrDefault();
            int TVFileID = tvFileBouctoucheWWTP.TVFileID;
            tvFileBouctoucheWWTP.TVFileTVItemID = tvItemBouctoucheWWTPTVFile.TVItemID;
            if (!AddObject("TVFile", tvFileBouctoucheWWTP)) return false;

            // TVFileLanguage EN Bouctouche WWTP TVItemID = 28689
            TVFileLanguage tvFileLanguageENBouctoucheWWTP = dbCSSPDB.TVFileLanguages.AsNoTracking().Where(c => c.TVFileID == TVFileID && c.Language == LanguageEnum.en).FirstOrDefault();
            tvFileLanguageENBouctoucheWWTP.TVFileID = tvFileBouctoucheWWTP.TVFileID;
            if (!AddObject("TVFileLanguage", tvFileLanguageENBouctoucheWWTP)) return false;

            // TVFileLanguage FR Bouctouche WWTP TVItemID = 28689
            TVFileLanguage tvFileLanguageFRBouctoucheWWTP = dbCSSPDB.TVFileLanguages.AsNoTracking().Where(c => c.TVFileID == TVFileID && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvFileLanguageFRBouctoucheWWTP.TVFileID = tvFileBouctoucheWWTP.TVFileID;
            if (!AddObject("TVFileLanguage", tvFileLanguageFRBouctoucheWWTP)) return false;
            #endregion TVFile Bouctouche WWTP 
            #region Infrastructure Bouctouche WWTP
            StatusTempEvent(new StatusEventArgs("doing ... Bouctouche WWTP Infrastructure"));
            // Infrastructure Bouctouche WWTP TVItemID = 28689
            Infrastructure infrastructureBouctoucheWWTP = dbCSSPDB.Infrastructures.AsNoTracking().Where(c => c.InfrastructureTVItemID == 28689).FirstOrDefault();
            int InfrastructureID = infrastructureBouctoucheWWTP.InfrastructureID;
            infrastructureBouctoucheWWTP.InfrastructureTVItemID = tvItemBouctoucheWWTP.TVItemID;
            if (!AddObject("Infrastructure", infrastructureBouctoucheWWTP)) return false;

            // InfrastructureLanguage EN Bouctouche WWTP TVItemID = 28689
            InfrastructureLanguage infrastructureLanguageENBouctoucheWWTP = dbCSSPDB.InfrastructureLanguages.AsNoTracking().Where(c => c.InfrastructureID == InfrastructureID && c.Language == LanguageEnum.en).FirstOrDefault();
            infrastructureLanguageENBouctoucheWWTP.InfrastructureID = infrastructureBouctoucheWWTP.InfrastructureID;
            if (!AddObject("InfrastructureLanguage", infrastructureLanguageENBouctoucheWWTP)) return false;

            // InfrastructureLanguage FR Bouctouche WWTP TVItemID = 28689
            InfrastructureLanguage infrastructureLanguageFRBouctoucheWWTP = dbCSSPDB.InfrastructureLanguages.AsNoTracking().Where(c => c.InfrastructureID == InfrastructureID && c.Language == LanguageEnum.fr).FirstOrDefault();
            infrastructureLanguageFRBouctoucheWWTP.InfrastructureID = infrastructureBouctoucheWWTP.InfrastructureID;
            if (!AddObject("InfrastructureLanguage", infrastructureLanguageFRBouctoucheWWTP)) return false;
            #endregion Infrastructure Bouctouche WWTP
            #region BoxModel Bouctouche WWTP
            StatusTempEvent(new StatusEventArgs("doing ... Bouctouche WWTP Infrastructure Box Model"));
            // BoxModel Bouctouche WWTP TVItemID = 28689
            BoxModel boxModel = dbCSSPDB.BoxModels.AsNoTracking().Where(c => c.InfrastructureTVItemID == 28689).FirstOrDefault();
            int BoxModelID = boxModel.BoxModelID;
            boxModel.InfrastructureTVItemID = tvItemBouctoucheWWTP.TVItemID;
            if (!AddObject("BoxModel", boxModel)) return false;

            // BoxModelLanguage EN Bouctouche WWTP TVItemID = 28689
            BoxModelLanguage boxModelLanguageEN = dbCSSPDB.BoxModelLanguages.AsNoTracking().Where(c => c.BoxModelID == BoxModelID && c.Language == LanguageEnum.en).FirstOrDefault();
            boxModelLanguageEN.BoxModelID = boxModel.BoxModelID;
            if (!AddObject("BoxModelLanguage", boxModelLanguageEN)) return false;

            // BoxModelLanguage FR Bouctouche WWTP TVItemID = 28689
            BoxModelLanguage boxModelLanguageFR = dbCSSPDB.BoxModelLanguages.AsNoTracking().Where(c => c.BoxModelID == BoxModelID && c.Language == LanguageEnum.fr).FirstOrDefault();
            boxModelLanguageFR.BoxModelID = boxModel.BoxModelID;
            if (!AddObject("BoxModelLanguage", boxModelLanguageFR)) return false;
            #endregion BoxModel Bouctouche WWTP
            #region BoxModelResult Bouctouche WWTP
            StatusTempEvent(new StatusEventArgs("doing ... Bouctouche WWTP Infrastructure Box Model Result"));

            // BoxModelResult Bouctouche WWTP TVItemID = 28689
            for (int i = 1; i < 6; i++)
            {
                BoxModelResultTypeEnum boxModelResultTypeEnum = (BoxModelResultTypeEnum)i;
                BoxModelResult boxModelResult = dbCSSPDB.BoxModelResults.AsNoTracking().Where(c => c.BoxModelID == BoxModelID && c.BoxModelResultType == boxModelResultTypeEnum).FirstOrDefault();
                boxModelResult.BoxModelID = boxModel.BoxModelID;
                if (!AddObject("BoxModelResult", boxModelResult)) return false;
            }
            #endregion BoxModelResult Bouctouche WWTP
            #region VPScenario Bouctouche WWTP 
            StatusTempEvent(new StatusEventArgs("doing ... Bouctouche WWTP Infrastructure VPScenario"));

            // VPScenario Bouctouche WWTP TVItemID = 28689
            VPScenario VPScenario = dbCSSPDB.VPScenarios.AsNoTracking().Where(c => c.InfrastructureTVItemID == 28689).FirstOrDefault();
            int VPScenarioID = VPScenario.VPScenarioID;
            VPScenario.InfrastructureTVItemID = tvItemBouctoucheWWTP.TVItemID;
            if (!AddObject("VPScenario", VPScenario)) return false;

            // VPScenarioLanguage EN Bouctouche WWTP TVItemID = 28689
            VPScenarioLanguage VPScenarioLanguageEN = dbCSSPDB.VPScenarioLanguages.AsNoTracking().Where(c => c.VPScenarioID == VPScenarioID && c.Language == LanguageEnum.en).FirstOrDefault();
            VPScenarioLanguageEN.VPScenarioID = VPScenario.VPScenarioID;
            if (!AddObject("VPScenarioLanguage", VPScenarioLanguageEN)) return false;

            // VPScenarioLanguage FR Bouctouche WWTP TVItemID = 28689
            VPScenarioLanguage VPScenarioLanguageFR = dbCSSPDB.VPScenarioLanguages.AsNoTracking().Where(c => c.VPScenarioID == VPScenarioID && c.Language == LanguageEnum.fr).FirstOrDefault();
            VPScenarioLanguageFR.VPScenarioID = VPScenario.VPScenarioID;
            if (!AddObject("VPScenarioLanguage", VPScenarioLanguageFR)) return false;

            // VPAmbient Bouctouche WWTP TVItemID = 28689
            List<VPAmbient> VPAmbientList = dbCSSPDB.VPAmbients.AsNoTracking().Where(c => c.VPScenarioID == VPScenarioID).ToList();
            foreach (VPAmbient vpAmbient in VPAmbientList)
            {
                vpAmbient.VPScenarioID = VPScenario.VPScenarioID;
                if (!AddObject("VPAmbient", vpAmbient)) return false;
            }

            // VPAmbient Bouctouche WWTP TVItemID = 28689
            List<VPResult> VPResultList = dbCSSPDB.VPResults.AsNoTracking().Where(c => c.VPScenarioID == VPScenarioID).Take(5).ToList();
            foreach (VPResult vpResult in VPResultList)
            {
                vpResult.VPScenarioID = VPScenario.VPScenarioID;
                if (!AddObject("VPResult", vpResult)) return false;
            }
            #endregion VPScenario Bouctouche WWTP 
            #region TVItem Municipality Bouctouche LS 2 Rue Acadie
            StatusTempEvent(new StatusEventArgs("doing ... Bouctouche LS 2"));

            // TVItem Municipality Bouctouche LS 2 Rue Acadie TVItemID = 28695
            TVItem tvItemBouctoucheLS2RueAcadie = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 28695).FirstOrDefault();
            tvItemBouctoucheLS2RueAcadie.ParentID = tvItemCapPeleTideSite.TVItemID;
            if (!AddObject("TVItem", tvItemBouctoucheLS2RueAcadie)) return false;
            if (!CorrectTVPath(tvItemBouctoucheLS2RueAcadie, tvItemCapPeleTideSite)) return false;
            tvItemBouctoucheLS2RueAcadie.TVType = TVTypeEnum.LiftStation;
            if (!AddMapInfo(tvItemBouctoucheLS2RueAcadie, 28695, tvItemContactCharles.TVItemID)) return false;
            tvItemBouctoucheLS2RueAcadie.TVType = TVTypeEnum.Infrastructure;

            // TVItemLanguage EN Bouctouche LS 2 Rue Acadie TVItemID = 28695
            TVItemLanguage tvItemLanguageENBouctoucheLS2RueAcadie = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28695 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENBouctoucheLS2RueAcadie.TVItemID = tvItemBouctoucheLS2RueAcadie.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENBouctoucheLS2RueAcadie)) return false;

            // TVItemLanguage FR Bouctouche LS 2 Rue Acadie TVItemID = 28695
            TVItemLanguage tvItemLanguageFRBouctoucheLS2RueAcadie = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28695 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRBouctoucheLS2RueAcadie.TVItemID = tvItemBouctoucheLS2RueAcadie.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRBouctoucheLS2RueAcadie)) return false;
            #endregion TVItem Municipality Bouctouche LS 2 Rue Acadie
            #region TVItem Subsector NB-06_020_002 MWQM Site 0001
            StatusTempEvent(new StatusEventArgs("doing ... Subsector NB-06-020-002 MWQM site 001"));
            // TVItem Subsector NB-06_020_002 MWQM Site 0001 TVItemID = 7460
            TVItem tvItemNB_06_020_002Site0001 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 7460).FirstOrDefault();
            int MWQMSiteID0001 = tvItemNB_06_020_002Site0001.TVItemID;
            tvItemNB_06_020_002Site0001.ParentID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06_020_002Site0001)) return false;
            if (!CorrectTVPath(tvItemNB_06_020_002Site0001, tvItemNB_06_020_002)) return false;
            if (!AddMapInfo(tvItemNB_06_020_002Site0001, 7460, tvItemContactCharles.TVItemID)) return false;

            // TVItemLanguage EN NB-06_020_001 TVItemID = 7460
            TVItemLanguage tvItemLanguageENNB_06_020_002Site0001 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7460 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNB_06_020_002Site0001.TVItemID = tvItemNB_06_020_002Site0001.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_002Site0001)) return false;

            // TVItemLanguage FR NB_06_020 TVItemID = 7460
            TVItemLanguage tvItemLanguageFRNB_06_020_002Site0001 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7460 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNB_06_020_002Site0001.TVItemID = tvItemNB_06_020_002Site0001.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_002Site0001)) return false;
            #endregion TVItem Subsector NB-06_020_002 MWQM Site 0001
            #region TVItem Subsector NB-06_020_002 MWQM Site 0002
            StatusTempEvent(new StatusEventArgs("doing ... Subsector NB-06-020-002 MWQM site 002"));
            // TVItem Subsector NB-06_020_002 MWQM Site 0001 TVItemID = 7462
            TVItem tvItemNB_06_020_002Site0002 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 7462).FirstOrDefault();
            int MWQMSiteID0002 = tvItemNB_06_020_002Site0002.TVItemID;
            tvItemNB_06_020_002Site0002.ParentID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06_020_002Site0002)) return false;
            if (!CorrectTVPath(tvItemNB_06_020_002Site0002, tvItemNB_06_020_002)) return false;
            if (!AddMapInfo(tvItemNB_06_020_002Site0002, 7462, tvItemContactCharles.TVItemID)) return false;

            // TVItemLanguage EN NB-06_020_001 TVItemID = 7462
            TVItemLanguage tvItemLanguageENNB_06_020_002Site0002 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7462 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNB_06_020_002Site0002.TVItemID = tvItemNB_06_020_002Site0002.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_002Site0002)) return false;

            // TVItemLanguage FR NB_06_020 TVItemID = 7462
            TVItemLanguage tvItemLanguageFRNB_06_020_002Site0002 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7462 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNB_06_020_002Site0002.TVItemID = tvItemNB_06_020_002Site0002.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_002Site0002)) return false;
            #endregion TVItem Subsector NB-06_020_002 MWQM Site 0002
            #region TVItem Address and Address
            StatusTempEvent(new StatusEventArgs("doing ... Address"));
            // TVItem Address 730 Chemin de la Pointe, Richibouctou, NB E4W, Canada TVItemID = 232655
            TVItem tvItemAddress = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 232655).FirstOrDefault();
            tvItemAddress.ParentID = tvItemRoot.TVItemID;
            if (!AddObject("TVItem", tvItemAddress)) return false;
            if (!CorrectTVPath(tvItemAddress, tvItemRoot)) return false;
            if (!AddMapInfo(tvItemAddress, 232655, tvItemContactCharles.TVItemID)) return false;

            // Address 730 Chemin de la Pointe, Richibouctou, NB E4W, Canada TVItemID = 232655
            Address address = dbCSSPDB.Addresses.AsNoTracking().Where(c => c.AddressTVItemID == 232655).FirstOrDefault();
            address.AddressTVItemID = tvItemAddress.TVItemID;
            address.CountryTVItemID = tvItemCanada.TVItemID;
            address.ProvinceTVItemID = tvItemNB.TVItemID;
            address.MunicipalityTVItemID = tvItemBouctouche.TVItemID;
            if (!AddObject("Address", address)) return false;

            //string TVText = "";
            //using (CSSPDBContext db2 = new CSSPDBContext())
            //{
            //    AddressService addressService = new AddressService(new Query(), db2, contactCharles.ContactID);
            //    TVText = addressService.FillAddressTVText(address);
            //}

            // TVItem Address 730 Chemin de la Pointe, Richibouctou, NB E4W, Canada TVItemID = 232655
            TVItemLanguage tvItemLanguageENAddress = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 232655 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENAddress.TVItemID = tvItemAddress.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENAddress)) return false;

            // TVItem Address 730 Chemin de la Pointe, Richibouctou, NB E4W, Canada TVItemID = 232655
            TVItemLanguage tvItemLanguageFRAddress = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 232655 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRAddress.TVItemID = tvItemAddress.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRAddress)) return false;
            #endregion TVItem Address and Address
            #region TVItem Subsector NB-06_020_002 Pol Source Site 000023
            StatusTempEvent(new StatusEventArgs("doing ... Subsector NB-06-020-002 PolSource site 00023"));
            // TVItem Subsector NB-06_020_002 Pol Source Site 000023 TVItemID = 202466
            TVItem tvItemNB_06_020_002PolSite000023 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 202466).FirstOrDefault();
            tvItemNB_06_020_002PolSite000023.ParentID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06_020_002PolSite000023)) return false;
            if (!CorrectTVPath(tvItemNB_06_020_002PolSite000023, tvItemNB_06_020_002)) return false;
            if (!AddMapInfo(tvItemNB_06_020_002PolSite000023, 202466, tvItemContactCharles.TVItemID)) return false;

            // TVItemLanguage EN Subsector NB-06_020_002 Pol Source Site 000023 TVItemID = 202466
            TVItemLanguage tvItemLanguageENNB_06_020_002PolSite000023 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 202466 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNB_06_020_002PolSite000023.TVItemID = tvItemNB_06_020_002PolSite000023.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_002PolSite000023)) return false;

            // TVItemLanguage FR Subsector NB-06_020_002 Pol Source Site 000023 TVItemID = 202466
            TVItemLanguage tvItemLanguageFRNB_06_020_002PolSite000023 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 202466 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNB_06_020_002PolSite000023.TVItemID = tvItemNB_06_020_002PolSite000023.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_002PolSite000023)) return false;
            #endregion TVItem Subsector NB-06_020_002 Pol Source Site 000023
            #region PolSourceSite, PolSourceObservation, PolSourceObservationIssue Subsector NB-06_020_002 Pol Source Site 000023
            StatusTempEvent(new StatusEventArgs("doing ... Subsector NB-06-020-002 PolSource site 00023 Observation"));
            // PolSourceSite with PolSourceSiteTVItemID = 202466
            PolSourceSite polSourceSitePolSite000023 = dbCSSPDB.PolSourceSites.AsNoTracking().Where(c => c.PolSourceSiteTVItemID == 202466).FirstOrDefault();
            int PolSourceSiteID = polSourceSitePolSite000023.PolSourceSiteID;
            polSourceSitePolSite000023.PolSourceSiteTVItemID = tvItemNB_06_020_002PolSite000023.TVItemID;
            if (polSourceSitePolSite000023.CivicAddressTVItemID != null)
            {
                polSourceSitePolSite000023.CivicAddressTVItemID = tvItemAddress.TVItemID;
            }
            if (!AddObject("PolSourceSite", polSourceSitePolSite000023)) return false;

            // PolSourceObservation with PolSourceSiteTVItemID = 202466
            PolSourceObservation polSourceSitePolSite000023Obs = dbCSSPDB.PolSourceObservations.AsNoTracking().Where(c => c.PolSourceSiteID == PolSourceSiteID).FirstOrDefault();
            int PolSourceObservationID = polSourceSitePolSite000023Obs.PolSourceObservationID;
            polSourceSitePolSite000023Obs.ContactTVItemID = contactCharles.ContactTVItemID;
            polSourceSitePolSite000023Obs.PolSourceSiteID = polSourceSitePolSite000023.PolSourceSiteID;
            if (!AddObject("PolSourceObservation", polSourceSitePolSite000023Obs)) return false;

            // PolSourceObservationIssue with PolSourceSiteTVItemID = 202466
            PolSourceObservationIssue polSourceSitePolSite000023ObsIssue = dbCSSPDB.PolSourceObservationIssues.AsNoTracking().Where(c => c.PolSourceObservationID == PolSourceObservationID).FirstOrDefault();
            int PolSourceObservationIssueID = polSourceSitePolSite000023ObsIssue.PolSourceObservationIssueID;
            polSourceSitePolSite000023ObsIssue.PolSourceObservationID = polSourceSitePolSite000023Obs.PolSourceSiteID;
            if (!AddObject("PolSourceObservationIssue", polSourceSitePolSite000023ObsIssue)) return false;
            #endregion PolSourceSite, PolSourceObservation, PolSourceObservationIssue Subsector NB-06_020_002 Pol Source Site 000023
            #region PolSourceSite, PolSourceObservation, PolSourceObservationIssue Subsector NB-06_020_002 Pol Source Site 000024
            StatusTempEvent(new StatusEventArgs("doing ... Subsector NB-06-020-002 PolSource site 00024"));
            // TVItem Subsector NB-06_020_002 Pol Source Site 000024 TVItemID = 202467
            TVItem tvItemNB_06_020_002PolSite000024 = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 202467).FirstOrDefault();
            tvItemNB_06_020_002PolSite000024.ParentID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06_020_002PolSite000024)) return false;
            if (!CorrectTVPath(tvItemNB_06_020_002PolSite000024, tvItemNB_06_020_002)) return false;
            if (!AddMapInfo(tvItemNB_06_020_002PolSite000024, 202467, tvItemContactCharles.TVItemID)) return false;

            // TVItemLanguage EN NB-06_020_001 TVItemID = 202467
            TVItemLanguage tvItemLanguageENNB_06_020_00PolSite000024 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 202467 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNB_06_020_00PolSite000024.TVItemID = tvItemNB_06_020_002PolSite000024.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_00PolSite000024)) return false;

            // TVItemLanguage FR NB_06_020 TVItemID = 202467
            TVItemLanguage tvItemLanguageFRNB_06_020_002PolSite000024 = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 202467 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNB_06_020_002PolSite000024.TVItemID = tvItemNB_06_020_002PolSite000024.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_002PolSite000024)) return false;
            #endregion PolSourceSite, PolSourceObservation, PolSourceObservationIssue Subsector NB-06_020_002 Pol Source Site 000024
            #region DrogueRun, DrogueRunPositon Subsector NB-06_020_002
            StatusTempEvent(new StatusEventArgs("doing ... Subsector NB-06-020-002 DrogueRun"));
            DrogueRun drogueRun = dbCSSPDB.DrogueRuns.AsNoTracking().FirstOrDefault();
            int DrogueRunID = drogueRun.DrogueRunID;
            drogueRun.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("DrogueRun", drogueRun)) return false;

            // DrogueRunPosition
            List<DrogueRunPosition> drogueRunPositionList = dbCSSPDB.DrogueRunPositions.AsNoTracking().Where(c => c.DrogueRunID == DrogueRunID).ToList();
            foreach (DrogueRunPosition drogueRunPosition in drogueRunPositionList.Take(10))
            {
                int DrogueRunPositionID = drogueRunPosition.DrogueRunPositionID;
                drogueRunPosition.DrogueRunID = drogueRun.DrogueRunID;
                if (!AddObject("DrogueRunPosition", drogueRunPosition)) return false;
            }
            #endregion DrogueRun, DrogueRunPositon Subsector NB-06_020_002
            #region HelpDoc
            StatusTempEvent(new StatusEventArgs("doing ... HelpDoc"));
            HelpDoc helpDoc = dbCSSPDB.HelpDocs.AsNoTracking().FirstOrDefault();
            int HelpDocID = helpDoc.HelpDocID;
            if (!AddObject("HelpDoc", helpDoc)) return false;
            #endregion HelpDoc
            #region TVItem SamplingPlan, SamplingPlanSubsector, SamplingPlanSubsectorSite, SamplingPlanEmail
            StatusTempEvent(new StatusEventArgs("doing ... Sampling Plan"));
            // NB TVItem Sampling Plan with SamplingPlanID = 78 and TVFileTVItemID = 370708
            TVItem tvItemNBSamplingPlanFileTVItem = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 370708).FirstOrDefault();
            tvItemNBSamplingPlanFileTVItem.ParentID = tvItemNB.TVItemID;
            if (!AddObject("TVItem", tvItemNBSamplingPlanFileTVItem)) return false;
            if (!CorrectTVPath(tvItemNBSamplingPlanFileTVItem, tvItemNB)) return false;
            if (!AddMapInfo(tvItemNBSamplingPlanFileTVItem, 370708, tvItemContactCharles.TVItemID)) return false;

            // NB EN TVItem Sampling Plan with SamplingPlanID = 78 and TVFileTVItemID = 370708
            TVItemLanguage tvItemLanguageENNBSamplingPlanFileTVItem = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 370708 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNBSamplingPlanFileTVItem.TVItemID = tvItemNBSamplingPlanFileTVItem.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNBSamplingPlanFileTVItem)) return false;

            // NB FR TVItem Sampling Plan with SamplingPlanID = 78 and TVFileTVItemID = 370708
            TVItemLanguage tvItemLanguageFRNBSamplingPlanFileTVItem = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 370708 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNBSamplingPlanFileTVItem.TVItemID = tvItemNBSamplingPlanFileTVItem.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNBSamplingPlanFileTVItem)) return false;

            // NB TVFile Sampling Plan with SamplingPlanID = 78 and TVFileTVItemID = 370708
            TVFile tvFile = dbCSSPDB.TVFiles.AsNoTracking().Where(c => c.TVFileTVItemID == 370708).FirstOrDefault();
            //int TVFileID = tvFile.TVFileID;
            tvFile.TVFileTVItemID = tvItemNBSamplingPlanFileTVItem.TVItemID;
            if (!AddObject("TVFile", tvFile)) return false;

            // NB Sampling Plan with SamplingPlanID = 78
            SamplingPlan samplingPlan = dbCSSPDB.SamplingPlans.AsNoTracking().Where(c => c.SamplingPlanID == 78).FirstOrDefault();
            int SamplingPlanID = samplingPlan.SamplingPlanID;
            samplingPlan.CreatorTVItemID = tvItemContactCharles.TVItemID;
            samplingPlan.ProvinceTVItemID = tvItemNB.TVItemID;
            samplingPlan.SamplingPlanFileTVItemID = tvFile.TVFileTVItemID;
            samplingPlan.ApprovalCode = "aaabbb";
            if (!AddObject("SamplingPlan", samplingPlan)) return false;

            // NB Sampling Plan with SamplingPlanID = 78 with SubsectorTVItemID = 635 (Bouctouche harbour)
            SamplingPlanSubsector samplingPlanSubsector = dbCSSPDB.SamplingPlanSubsectors.AsNoTracking().Where(c => c.SamplingPlanID == 78 && c.SubsectorTVItemID == 560).FirstOrDefault();
            int SamplingPlanSubsectorID = samplingPlanSubsector.SamplingPlanSubsectorID;
            samplingPlanSubsector.SamplingPlanID = samplingPlan.SamplingPlanID;
            samplingPlanSubsector.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("SamplingPlanSubsector", samplingPlanSubsector)) return false;

            // NB Sampling Plan with SamplingPlanID = 78 with SubsectorTVItemID = 635 (Bouctouche harbour)
            SamplingPlanSubsectorSite samplingPlanSubsectorSite0001 = dbCSSPDB.SamplingPlanSubsectorSites.AsNoTracking().Where(c => c.SamplingPlanSubsectorID == SamplingPlanSubsectorID && c.MWQMSiteTVItemID == 7153).FirstOrDefault();
            samplingPlanSubsectorSite0001.SamplingPlanSubsectorID = samplingPlanSubsector.SamplingPlanSubsectorID;
            samplingPlanSubsectorSite0001.MWQMSiteTVItemID = tvItemNB_06_020_002Site0001.TVItemID;
            if (!AddObject("SamplingPlanSubsectorSite", samplingPlanSubsectorSite0001)) return false;

            // NB Sampling Plan with SamplingPlanID = 78 with SubsectorTVItemID = 635 (Bouctouche harbour)
            SamplingPlanSubsectorSite samplingPlanSubsectorSite0002 = dbCSSPDB.SamplingPlanSubsectorSites.AsNoTracking().Where(c => c.SamplingPlanSubsectorID == SamplingPlanSubsectorID && c.MWQMSiteTVItemID == 7156).FirstOrDefault();
            samplingPlanSubsectorSite0002.SamplingPlanSubsectorID = samplingPlanSubsector.SamplingPlanSubsectorID;
            samplingPlanSubsectorSite0002.MWQMSiteTVItemID = tvItemNB_06_020_002Site0002.TVItemID;
            if (!AddObject("SamplingPlanSubsectorSite", samplingPlanSubsectorSite0002)) return false;

            // NB Sampling Plan Email with SamplingPlanID = 78
            SamplingPlanEmail samplingPlanEmail = dbCSSPDB.SamplingPlanEmails.AsNoTracking().Where(c => c.SamplingPlanID == SamplingPlanID).FirstOrDefault();
            samplingPlanEmail.SamplingPlanID = samplingPlan.SamplingPlanID;
            if (!AddObject("SamplingPlanEmail", samplingPlanEmail)) return false;
            #endregion TVItem SamplingPlan, SamplingPlanSubsector, SamplingPlanSubsectorSite, SamplingPlanEmail
            #region TVItem MWQMRun with Subsector NB-06_020_002 and MWQMSite 0001
            StatusTempEvent(new StatusEventArgs("doing ... MWQM Run"));
            // TVItem MWQMRun with Subsector NB-06_020_002 TVItemID = 635 MWQMSite 0001 TVItemID = 7460 MWQMRunTVItemID = 324152
            TVItem tvItemRun = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 324152).FirstOrDefault();
            tvItemRun.ParentID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItem", tvItemRun)) return false;
            if (!CorrectTVPath(tvItemRun, tvItemNB_06_020_002)) return false;
            if (!AddMapInfo(tvItemRun, 324152, tvItemContactCharles.TVItemID)) return false;

            // TVItemLanguage EN MWQMRun with MWQMRunTVItemID = 324152
            TVItemLanguage tvItemLanguageENMWQMRun = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 324152 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENMWQMRun.TVItemID = tvItemRun.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENMWQMRun)) return false;

            // TVItemLanguage FR NB_06_020 TVItemID = 324152
            TVItemLanguage tvItemLanguageFRMWQMRun = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 324152 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRMWQMRun.TVItemID = tvItemRun.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRMWQMRun)) return false;

            // TVItem MWQMRun with Subsector NB-06_020_002 TVItemID = 635 MWQMSite 0001 TVItemID = 7460 MWQMRunTVItemID = 324152
            MWQMRun mwqmRun = dbCSSPDB.MWQMRuns.AsNoTracking().Where(c => c.MWQMRunTVItemID == 324152).FirstOrDefault();
            int MWQMRunID = mwqmRun.MWQMRunID;
            mwqmRun.MWQMRunTVItemID = tvItemRun.TVItemID;
            mwqmRun.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
            mwqmRun.LabSampleApprovalContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("MWQMRun", mwqmRun)) return false;

            // MWQMRunLanguage EN MWQMRun with MWQMRunTVItemID = 324152
            MWQMRunLanguage MWQMRunLanguageEN = dbCSSPDB.MWQMRunLanguages.AsNoTracking().Where(c => c.MWQMRunID == MWQMRunID && c.Language == LanguageEnum.en).FirstOrDefault();
            MWQMRunLanguageEN.MWQMRunID = mwqmRun.MWQMRunID;
            if (!AddObject("MWQMRunLanguage", MWQMRunLanguageEN)) return false;

            // MWQMRunLanguage FR MWQMRun with MWQMRunTVItemID = 324152
            MWQMRunLanguage MWQMRunLanguageFR = dbCSSPDB.MWQMRunLanguages.AsNoTracking().Where(c => c.MWQMRunID == MWQMRunID && c.Language == LanguageEnum.en).FirstOrDefault();
            MWQMRunLanguageFR.MWQMRunID = mwqmRun.MWQMRunID;
            if (!AddObject("MWQMRunLanguage", MWQMRunLanguageFR)) return false;
            #endregion TVItem MWQMRun with Subsector NB-06_020_002 and MWQMSite 0001
            #region UseOfSite
            StatusTempEvent(new StatusEventArgs("doing ... UseOfSite"));
            // NB UseOfSite with SubsectorTVItemID = 635 ClimateSiteTVItemID = 229528
            UseOfSite useOfSite = dbCSSPDB.UseOfSites.AsNoTracking().Where(c => c.SubsectorTVItemID == 635 && c.SiteTVItemID == 229528).FirstOrDefault();
            useOfSite.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
            useOfSite.SiteTVItemID = tvItemNBClimateSiteBouctoucheCDA.TVItemID;
            if (!AddObject("UseOfSite", useOfSite)) return false;

            // NB UseOfSite with SubsectorTVItemID = 635 TideSiteTVItemID = 1553
            //useOfSite = dbCSSPDB.UseOfSites.AsNoTracking().Where(c => c.SubsectorTVItemID == 635 && c.SiteTVItemID == 1553).FirstOrDefault();
            //useOfSite.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
            //useOfSite.SiteTVItemID = tideSite.TideSiteTVItemID;
            //if (!AddObject("UseOfSite", useOfSite)) return false;
            #endregion UseOfSite
            #region MWQMSamples
            StatusTempEvent(new StatusEventArgs("doing ... MWQMSamples"));
            // NB MWQMSamples with MWQMSiteTVItemID = 7460 and MWQMRunTVItemID = 324152
            MWQMSample mwqmSample = dbCSSPDB.MWQMSamples.AsNoTracking().Where(c => c.MWQMSiteTVItemID == 7460 && c.MWQMRunTVItemID == 324152).FirstOrDefault();
            int MWQMSampleID = mwqmSample.MWQMSampleID;
            mwqmSample.MWQMSiteTVItemID = tvItemNB_06_020_002Site0001.TVItemID;
            mwqmSample.MWQMRunTVItemID = tvItemRun.TVItemID;
            if (!AddObject("MWQMSample", mwqmSample)) return false;

            // NB MWQMSampleLanguages EN with MWQMSiteTVItemID = 7460 and MWQMRunTVItemID = 324152
            MWQMSampleLanguage mwqmSampleLanguageEN = dbCSSPDB.MWQMSampleLanguages.AsNoTracking().Where(c => c.MWQMSampleID == MWQMSampleID && c.Language == LanguageEnum.en).FirstOrDefault();
            mwqmSampleLanguageEN.MWQMSampleID = mwqmSample.MWQMSampleID;
            if (!AddObject("MWQMSampleLanguage", mwqmSampleLanguageEN)) return false;

            // NB MWQMSampleLanguages FR with MWQMSiteTVItemID = 7460 and MWQMRunTVItemID = 324152
            MWQMSampleLanguage mwqmSampleLanguageFR = dbCSSPDB.MWQMSampleLanguages.AsNoTracking().Where(c => c.MWQMSampleID == MWQMSampleID && c.Language == LanguageEnum.fr).FirstOrDefault();
            mwqmSampleLanguageFR.MWQMSampleID = mwqmSample.MWQMSampleID;
            if (!AddObject("MWQMSampleLanguage", mwqmSampleLanguageFR)) return false;
            #endregion MWQMSamples
            #region MWQMSite, MWQMSiteStartEndDate
            StatusTempEvent(new StatusEventArgs("doing ... MWQMSite and MWQMSiteStartEndDate"));
            // NB MWQMSite with MWQMSiteTVItemID = 7460
            MWQMSite mwqmSite0001 = dbCSSPDB.MWQMSites.AsNoTracking().Where(c => c.MWQMSiteTVItemID == 7460).FirstOrDefault();
            mwqmSite0001.MWQMSiteTVItemID = tvItemNB_06_020_002Site0001.TVItemID;
            if (!AddObject("MWQMSite", mwqmSite0001)) return false;

            // MWQMSiteStartEndDate with MWQMSiteTVItemID = 7460
            MWQMSiteStartEndDate mwqmSiteStartEndDate0001 = dbCSSPDB.MWQMSiteStartEndDates.AsNoTracking().Where(c => c.MWQMSiteTVItemID == MWQMSiteID0001).FirstOrDefault();
            mwqmSiteStartEndDate0001.MWQMSiteTVItemID = tvItemNB_06_020_002Site0001.TVItemID;
            if (!AddObject("MWQMSiteStartEndDate", mwqmSiteStartEndDate0001)) return false;

            // NB MWQMSite with MWQMSiteTVItemID = 7462
            MWQMSite mwqmSite0002 = dbCSSPDB.MWQMSites.AsNoTracking().Where(c => c.MWQMSiteTVItemID == 7462).FirstOrDefault();
            mwqmSite0002.MWQMSiteTVItemID = tvItemNB_06_020_002Site0002.TVItemID;
            if (!AddObject("MWQMSite", mwqmSite0002)) return false;

            // MWQMSiteStartEndDate with MWQMSiteTVItemID = 7462
            MWQMSiteStartEndDate mwqmSiteStartEndDate0002 = dbCSSPDB.MWQMSiteStartEndDates.AsNoTracking().Where(c => c.MWQMSiteTVItemID == MWQMSiteID0001).FirstOrDefault();
            mwqmSiteStartEndDate0002.MWQMSiteTVItemID = tvItemNB_06_020_002Site0002.TVItemID;
            if (!AddObject("MWQMSiteStartEndDate", mwqmSiteStartEndDate0002)) return false;
            #endregion MWQMSite, MWQMSiteStartEndDate
            #region MikeScenario, MikeScenarioResult, MikeBoundaryCondition, MikeSource, MikeSourceStartEnd
            StatusTempEvent(new StatusEventArgs("doing ... MikeScenario, MikeBoundaryCondition, MikeSource, MikeSourceStartEnd"));
            // TVItem MikeScenario with MikeScenairoTVItemID = 28475 under Bouctouche
            TVItem tvItemMikeScenario = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 28475).FirstOrDefault();
            int MikeScenarioTVItemID = tvItemMikeScenario.TVItemID;
            tvItemMikeScenario.ParentID = tvItemBouctouche.TVItemID;
            if (!AddObject("TVItem", tvItemMikeScenario)) return false;
            if (!CorrectTVPath(tvItemMikeScenario, tvItemBouctouche)) return false;
            if (!AddMapInfo(tvItemMikeScenario, 28475, tvItemContactCharles.TVItemID)) return false;

            // TVItem MikeScenario with MikeScenairoTVItemID = 28475 under Bouctouche
            TVItemLanguage tvItemLanguageENMikeScenario = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28475 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENMikeScenario.TVItemID = tvItemMikeScenario.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENMikeScenario)) return false;

            // TVItem MikeScenario with MikeScenairoTVItemID = 28475 under Bouctouche
            TVItemLanguage tvItemLanguageFRMikeScenario = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28475 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRMikeScenario.TVItemID = tvItemMikeScenario.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRMikeScenario)) return false;

            // MikeScenario with MikeScenairoTVItemID = 28475 under Bouctouche
            MikeScenario mikeScenario = dbCSSPDB.MikeScenarios.AsNoTracking().Where(c => c.MikeScenarioTVItemID == 28475).FirstOrDefault();
            int MikeScenarioID = mikeScenario.MikeScenarioID;
            mikeScenario.MikeScenarioTVItemID = tvItemMikeScenario.TVItemID;
            if (!AddObject("MikeScenario", mikeScenario)) return false;

            // MikeScenarioResult with MikeScenairoTVItemID = 357139 under Bouctouche
            MikeScenarioResult mikeScenarioResult = dbCSSPDB.MikeScenarioResults.AsNoTracking().Where(c => c.MikeScenarioTVItemID == 357139).FirstOrDefault();
            int MikeScenarioResultID = mikeScenarioResult.MikeScenarioResultID;
            mikeScenarioResult.MikeScenarioTVItemID = tvItemMikeScenario.TVItemID;
            if (!AddObject("MikeScenarioResult", mikeScenarioResult)) return false;

            // TVItem MikeBoundaryCondition with MikeBoundaryConditionTVItemID = 92456 under Bouctouche
            TVItem tvItemMikeBoundaryCondition = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 92456).FirstOrDefault();
            tvItemMikeBoundaryCondition.ParentID = tvItemMikeScenario.TVItemID;
            if (!AddObject("TVItem", tvItemMikeBoundaryCondition)) return false;
            if (!CorrectTVPath(tvItemMikeBoundaryCondition, tvItemMikeScenario)) return false;
            if (!AddMapInfo(tvItemMikeBoundaryCondition, 92456, tvItemContactCharles.TVItemID)) return false;

            // TVItem MikeBoundaryCondition with MikeBoundaryConditionTVItemID = 92456 under Bouctouche
            TVItemLanguage tvItemLanguageENMikeBoundaryCondition = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 92456 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENMikeBoundaryCondition.TVItemID = tvItemMikeBoundaryCondition.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENMikeBoundaryCondition)) return false;

            // TVItem MikeBoundaryCondition with MikeBoundaryConditionTVItemID = 92456 under Bouctouche
            TVItemLanguage tvItemLanguageFRMikeBoundaryCondition = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 92456 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRMikeBoundaryCondition.TVItemID = tvItemMikeBoundaryCondition.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRMikeBoundaryCondition)) return false;

            // MikeBoundaryCondition with MikeBoundaryConditionTVItemID = 92456 under Bouctouche
            MikeBoundaryCondition mikeBoundaryCondition = dbCSSPDB.MikeBoundaryConditions.AsNoTracking().Where(c => c.MikeBoundaryConditionTVItemID == 92456).FirstOrDefault();
            mikeBoundaryCondition.MikeBoundaryConditionTVItemID = tvItemMikeBoundaryCondition.TVItemID;
            mikeBoundaryCondition.WebTideDataFromStartToEndDate = "some text";
            if (!AddObject("MikeBoundaryCondition", mikeBoundaryCondition)) return false;

            // TVItem MikeSource with MikeSourceTVItemID = 28476 under Bouctouche WWTP
            TVItem tvItemMikeSource = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 28476).FirstOrDefault();
            tvItemMikeSource.ParentID = tvItemMikeScenario.TVItemID;
            if (!AddObject("TVItem", tvItemMikeSource)) return false;
            if (!CorrectTVPath(tvItemMikeSource, tvItemMikeScenario)) return false;
            if (!AddMapInfo(tvItemMikeSource, 28476, tvItemContactCharles.TVItemID)) return false;

            // TVItem MikeSource with MikeSourceTVItemID = 28476 under Bouctouche
            TVItemLanguage tvItemLanguageENMikeSource = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28476 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENMikeSource.TVItemID = tvItemMikeSource.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENMikeSource)) return false;

            // TVItem MikeSource with MikeSourceTVItemID = 28476 under Bouctouche
            TVItemLanguage tvItemLanguageFRMikeSource = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28476 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRMikeSource.TVItemID = tvItemMikeSource.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRMikeSource)) return false;

            // MikeSource with MikeSourceTVItemID = 28476 under Bouctouche
            MikeSource mikeSource = dbCSSPDB.MikeSources.AsNoTracking().Where(c => c.MikeSourceTVItemID == 28476).FirstOrDefault();
            int MikeSourceID = mikeSource.MikeSourceID;
            mikeSource.MikeSourceTVItemID = tvItemMikeSource.TVItemID;
            if (!AddObject("MikeSource", mikeSource)) return false;

            // MikeSourceStartEnd with MikeSourceTVItemID = 28476 under Bouctouche
            MikeSourceStartEnd mikeSourceStartEnd = dbCSSPDB.MikeSourceStartEnds.AsNoTracking().Where(c => c.MikeSourceID == MikeSourceID).FirstOrDefault();
            mikeSourceStartEnd.MikeSourceID = mikeSource.MikeSourceID;
            if (!AddObject("MikeSourceStartEnd", mikeSourceStartEnd)) return false;
            #endregion MikeScenario, MikeBoundaryCondition, MikeSource, MikeSourceStartEnd
            #region LabSheet, LabSheetDetail, LabSheetTubeMPNDetail
            StatusTempEvent(new StatusEventArgs("doing ... LabSheet, LabSheetDetail, LabSheetTubeMPNDetail"));
            // LabSheet with SubsectorTVItemID = 635 and MWQMRunTVItemID = 324152 under Bouctouche harbour subsector
            LabSheet labSheet = dbCSSPDB.LabSheets.AsNoTracking().Where(c => c.SubsectorTVItemID == 635 && c.MWQMRunTVItemID == 324152).FirstOrDefault();
            int LabSheetID = labSheet.LabSheetID;
            labSheet.MWQMRunTVItemID = tvItemRun.TVItemID;
            labSheet.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
            labSheet.AcceptedOrRejectedByContactTVItemID = tvItemContactCharles.TVItemID;
            labSheet.SamplingPlanID = samplingPlan.SamplingPlanID;
            if (!AddObject("LabSheet", labSheet)) return false;

            // LabSheetDetail with SubsectorTVItemID = 635 and MWQMRunTVItemID = 324152 under Bouctouche harbour subsector
            LabSheetDetail labSheetDetail = dbCSSPDB.LabSheetDetails.AsNoTracking().Where(c => c.LabSheetID == LabSheetID).FirstOrDefault();
            int LabSheetDetailID = labSheetDetail.LabSheetDetailID;
            labSheetDetail.LabSheetID = labSheet.LabSheetID;
            labSheetDetail.SamplingPlanID = samplingPlan.SamplingPlanID;
            labSheetDetail.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("LabSheetDetail", labSheetDetail)) return false;

            // LabSheetTubeMPNDetail with SubsectorTVItemID = 635 and MWQMRunTVItemID = 324152 and MWQMSiteTVItemID = 7460 under Bouctouche harbour subsector
            LabSheetTubeMPNDetail labSheetTubeMPNDetail = dbCSSPDB.LabSheetTubeMPNDetails.AsNoTracking().Where(c => c.LabSheetDetailID == LabSheetDetailID && c.MWQMSiteTVItemID == 7460).FirstOrDefault();
            labSheetTubeMPNDetail.LabSheetDetailID = labSheetDetail.LabSheetDetailID;
            labSheetTubeMPNDetail.MWQMSiteTVItemID = tvItemNB_06_020_002Site0001.TVItemID;
            if (!AddObject("LabSheetTubeMPNDetail", labSheetTubeMPNDetail)) return false;
            #endregion LabSheet, LabSheetDetail, LabSheetTubeMPNDetail
            #region TVItem Email and Email
            StatusTempEvent(new StatusEventArgs("doing ... Email"));

            // Email Charles.LeBlanc@ec.gc.ca TVItemID = 110249
            TVItem tvItemEmail = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 110249).FirstOrDefault();
            tvItemEmail.ParentID = tvItemRoot.TVItemID;
            if (!AddObject("TVItem", tvItemEmail)) return false;
            if (!CorrectTVPath(tvItemEmail, tvItemRoot)) return false;
            if (!AddMapInfo(tvItemEmail, 110249, tvItemContactCharles.TVItemID)) return false;

            // Email Charles.LeBlanc@ec.gc.ca TVItemID = 110249
            TVItemLanguage tvItemLanguageENEmail = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 110249 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENEmail.TVItemID = tvItemEmail.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENEmail)) return false;

            // Email Charles.LeBlanc@ec.gc.ca TVItemID = 110249
            TVItemLanguage tvItemLanguageFREmail = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 110249 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFREmail.TVItemID = tvItemEmail.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFREmail)) return false;

            // Email Charles.LeBlanc@ec.gc.ca TVItemID = 110249
            Email email = dbCSSPDB.Emails.AsNoTracking().Where(c => c.EmailTVItemID == 110249).FirstOrDefault();
            email.EmailTVItemID = tvItemEmail.TVItemID;
            if (!AddObject("Email", email)) return false;
            #endregion TVItem Email and Email
            #region TVItem Tel and Tel
            StatusTempEvent(new StatusEventArgs("doing ... Tel"));
            // Tel Charles.LeBlanc@ec.gc.ca TVItemID = 108984
            TVItem tvItemTel = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 108984).FirstOrDefault();
            tvItemTel.ParentID = tvItemRoot.TVItemID;
            if (!AddObject("TVItem", tvItemTel)) return false;
            if (!CorrectTVPath(tvItemTel, tvItemRoot)) return false;
            if (!AddMapInfo(tvItemTel, 108984, tvItemContactCharles.TVItemID)) return false;

            // Tel Charles.LeBlanc@ec.gc.ca TVItemID = 108984
            TVItemLanguage tvItemLanguageENTel = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 108984 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENTel.TVItemID = tvItemTel.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENTel)) return false;

            // Tel Charles.LeBlanc@ec.gc.ca TVItemID = 108984
            TVItemLanguage tvItemLanguageFRTel = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 108984 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRTel.TVItemID = tvItemTel.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRTel)) return false;

            // Tel Charles.LeBlanc@ec.gc.ca TVItemID = 108984
            Tel tel = dbCSSPDB.Tels.AsNoTracking().Where(c => c.TelTVItemID == 108984).FirstOrDefault();
            tel.TelTVItemID = tvItemTel.TVItemID;
            if (!AddObject("Tel", tel)) return false;
            #endregion TVItem Tel and Tel
            #region TVItemLink
            StatusTempEvent(new StatusEventArgs("doing ... TVItemLink"));
            TVItemLink tvItemLinkMunicContact = dbCSSPDB.TVItemLinks.AsNoTracking().Where(c => c.FromTVItemID == 27764 && c.ToTVItemID == 305006).FirstOrDefault();
            tvItemLinkMunicContact.FromTVItemID = tvItemBouctouche.TVItemID;
            tvItemLinkMunicContact.ToTVItemID = tvItemContactCharles.TVItemID;
            tvItemLinkMunicContact.TVPath = $"p{ tvItemBouctouche.TVItemID.ToString() }p{ tvItemContactCharles.TVItemID.ToString() }";
            if (!AddObject("TVItemLink", tvItemLinkMunicContact)) return false;

            TVItemLink tvItemLinkContactTel = dbCSSPDB.TVItemLinks.AsNoTracking().Where(c => c.FromTVItemID == 305006 && c.ToTVItemID == 305007).FirstOrDefault();
            tvItemLinkContactTel.FromTVItemID = tvItemContactCharles.TVItemID;
            tvItemLinkContactTel.ToTVItemID = tvItemTel.TVItemID;
            tvItemLinkContactTel.TVPath = $"p{ tvItemContactCharles.TVItemID.ToString() }p{ tvItemTel.TVItemID.ToString() }";
            if (!AddObject("TVItemLink", tvItemLinkContactTel)) return false;

            TVItemLink tvItemLinkContactEmail = dbCSSPDB.TVItemLinks.AsNoTracking().Where(c => c.FromTVItemID == 305006 && c.ToTVItemID == 305007).FirstOrDefault();
            tvItemLinkContactEmail.FromTVItemID = tvItemContactCharles.TVItemID;
            tvItemLinkContactEmail.ToTVItemID = tvItemEmail.TVItemID;
            tvItemLinkContactEmail.TVPath = $"p{ tvItemContactCharles.TVItemID.ToString() }p{ tvItemEmail.TVItemID.ToString() }";
            if (!AddObject("TVItemLink", tvItemLinkContactEmail)) return false;
            #endregion TVItemLink
            #region Spill and SpillLanguage
            StatusTempEvent(new StatusEventArgs("doing ... Spill and SpillLanguage"));
            Spill spill = new Spill();
            spill.MunicipalityTVItemID = tvItemBouctouche.TVItemID;
            spill.InfrastructureTVItemID = tvItemBouctoucheWWTP.TVItemID;
            spill.StartDateTime_Local = DateTime.Now.AddYears(-5);
            spill.EndDateTime_Local = DateTime.Now.AddYears(-5).AddHours(6);
            spill.AverageFlow_m3_day = 34.5D;
            spill.LastUpdateDate_UTC = DateTime.Now;
            spill.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("Spill", spill)) return false;

            SpillLanguage spillLanguageEN = new SpillLanguage();
            spillLanguageEN.SpillID = spill.SpillID;
            spillLanguageEN.Language = LanguageEnum.en;
            spillLanguageEN.SpillComment = "This is the spill comment";
            spillLanguageEN.TranslationStatus = TranslationStatusEnum.Translated;
            spillLanguageEN.LastUpdateDate_UTC = DateTime.Now;
            spillLanguageEN.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("SpillLanguage", spillLanguageEN)) return false;

            SpillLanguage spillLanguageFR = new SpillLanguage();
            spillLanguageFR.SpillID = spill.SpillID;
            spillLanguageFR.Language = LanguageEnum.fr;
            spillLanguageFR.SpillComment = "This is the spill comment";
            spillLanguageFR.TranslationStatus = TranslationStatusEnum.NotTranslated;
            spillLanguageFR.LastUpdateDate_UTC = DateTime.Now;
            spillLanguageFR.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("SpillLanguage", spillLanguageFR)) return false;
            #endregion Spill and SpillLanguage
            #region EmailDistributionList and EmailDistributionListContact
            StatusTempEvent(new StatusEventArgs("doing ... EmailDistributionList and EmailDistributionListContact"));
            EmailDistributionList emailDistributionList = dbCSSPDB.EmailDistributionLists.AsNoTracking().FirstOrDefault();
            int EmailDistributionListID = emailDistributionList.EmailDistributionListID;
            emailDistributionList.ParentTVItemID = tvItemCanada.TVItemID;
            if (!AddObject("EmailDistributionList", emailDistributionList)) return false;

            EmailDistributionListLanguage emailDistributionListLanguageEN = dbCSSPDB.EmailDistributionListLanguages.AsNoTracking().Where(c => c.EmailDistributionListID == EmailDistributionListID && c.Language == LanguageEnum.en).FirstOrDefault();
            emailDistributionListLanguageEN.EmailDistributionListID = emailDistributionList.EmailDistributionListID;
            if (!AddObject("EmailDistributionListLanguage", emailDistributionListLanguageEN)) return false;

            EmailDistributionListLanguage emailDistributionListLanguageFR = dbCSSPDB.EmailDistributionListLanguages.AsNoTracking().Where(c => c.EmailDistributionListID == EmailDistributionListID && c.Language == LanguageEnum.fr).FirstOrDefault();
            emailDistributionListLanguageFR.EmailDistributionListID = emailDistributionList.EmailDistributionListID;
            if (!AddObject("EmailDistributionListLanguage", emailDistributionListLanguageFR)) return false;


            List<EmailDistributionListContact> emailDistributionListContactList = dbCSSPDB.EmailDistributionListContacts.AsNoTracking().Where(c => c.EmailDistributionListID == EmailDistributionListID).Take(5).ToList();
            foreach (EmailDistributionListContact emailDistributionListContact in emailDistributionListContactList)
            {
                emailDistributionListContact.EmailDistributionListID = emailDistributionList.EmailDistributionListID;
                int EmailDistributionListContactID = emailDistributionListContact.EmailDistributionListContactID;
                if (!AddObject("EmailDistributionListContact", emailDistributionListContact)) return false;

                EmailDistributionListContactLanguage emailDistributionListContactLanguageEN = dbCSSPDB.EmailDistributionListContactLanguages.AsNoTracking().Where(c => c.EmailDistributionListContactID == EmailDistributionListContactID && c.Language == LanguageEnum.en).FirstOrDefault();
                emailDistributionListContactLanguageEN.EmailDistributionListContactID = emailDistributionListContact.EmailDistributionListContactID;
                if (!AddObject("EmailDistributionListContactLanguage", emailDistributionListContactLanguageEN)) return false;

                EmailDistributionListContactLanguage emailDistributionListContactLanguageFR = dbCSSPDB.EmailDistributionListContactLanguages.AsNoTracking().Where(c => c.EmailDistributionListContactID == EmailDistributionListContactID && c.Language == LanguageEnum.fr).FirstOrDefault();
                emailDistributionListContactLanguageFR.EmailDistributionListContactID = emailDistributionListContact.EmailDistributionListContactID;
                if (!AddObject("EmailDistributionListContactLanguage", emailDistributionListContactLanguageFR)) return false;

            }
            #endregion EmailDistributionList and EmailDistributionListContact
            #region AppTask and AppTaskLanguage
            StatusTempEvent(new StatusEventArgs("doing ... AppTask and AppTaskLanguage"));
            AppTask appTask = new AppTask();
            appTask.TVItemID = tvItemCanada.TVItemID;
            appTask.TVItemID2 = tvItemCanada.TVItemID;
            appTask.AppTaskCommand = AppTaskCommandEnum.GenerateWebTide;
            appTask.AppTaskStatus = AppTaskStatusEnum.Created;
            appTask.PercentCompleted = 1;
            appTask.Parameters = "a,a";
            appTask.Language = LanguageEnum.en;
            appTask.StartDateTime_UTC = DateTime.Now.AddYears(-5);
            appTask.EndDateTime_UTC = DateTime.Now.AddYears(-5).AddHours(4);
            appTask.EstimatedLength_second = 1201;
            appTask.RemainingTime_second = 234;
            appTask.LastUpdateDate_UTC = DateTime.Now;
            appTask.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("AppTask", appTask)) return false;

            AppTaskLanguage appTaskLanguageEN = new AppTaskLanguage();
            appTaskLanguageEN.AppTaskID = appTask.AppTaskID;
            appTaskLanguageEN.Language = LanguageEnum.en;
            appTaskLanguageEN.StatusText = "This is the Status text";
            appTaskLanguageEN.ErrorText = "This is the CSSPError text";
            appTaskLanguageEN.TranslationStatus = TranslationStatusEnum.Translated;
            appTaskLanguageEN.LastUpdateDate_UTC = DateTime.Now;
            appTaskLanguageEN.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("AppTaskLanguage", appTaskLanguageEN)) return false;

            AppTaskLanguage appTaskLanguageFR = new AppTaskLanguage();
            appTaskLanguageFR.AppTaskID = appTask.AppTaskID;
            appTaskLanguageFR.Language = LanguageEnum.fr;
            appTaskLanguageFR.StatusText = "This is the Status text";
            appTaskLanguageFR.ErrorText = "This is the CSSPError text";
            appTaskLanguageFR.TranslationStatus = TranslationStatusEnum.NotTranslated;
            appTaskLanguageFR.LastUpdateDate_UTC = DateTime.Now;
            appTaskLanguageFR.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("AppTaskLanguage", appTaskLanguageFR)) return false;
            #endregion AppTask and AppTaskLanguage
            #region AppErrLog
            StatusTempEvent(new StatusEventArgs("doing ... AppErrLog"));
            AppErrLog appErrLog = new AppErrLog();
            appErrLog.Tag = "SomeTag";
            appErrLog.LineNumber = 234;
            appErrLog.Source = "Some text for source";
            appErrLog.Message = "Some text for message";
            appErrLog.DateTime_UTC = DateTime.Now;
            appErrLog.LastUpdateDate_UTC = DateTime.Now;
            appErrLog.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("AppErrLog", appErrLog)) return false;
            #endregion AppErrLog
            #region ContactPreference
            StatusTempEvent(new StatusEventArgs("doing ... ContactPreference"));
            ContactPreference contactPreference = new ContactPreference();
            contactPreference.ContactID = contactCharles.ContactID;
            contactPreference.TVType = TVTypeEnum.ClimateSite;
            contactPreference.MarkerSize = 100;
            contactPreference.LastUpdateDate_UTC = DateTime.Now;
            contactPreference.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("ContactPreference", contactPreference)) return false;
            #endregion ContactPreference
            #region ContactShortcut
            StatusTempEvent(new StatusEventArgs("doing ... ContactShortcut"));
            ContactShortcut contactShortcut = new ContactShortcut();
            contactShortcut.ContactID = contactCharles.ContactID;
            contactShortcut.ShortCutText = "Some shortcut text";
            contactShortcut.ShortCutAddress = "http://www.ibm.com";
            contactShortcut.LastUpdateDate_UTC = DateTime.Now;
            contactShortcut.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("ContactShortcut", contactShortcut)) return false;
            #endregion ContactShortcut
            #region DocTemplate
            StatusTempEvent(new StatusEventArgs("doing ... DocTemplate"));
            DocTemplate docTemplate = new DocTemplate();
            docTemplate.Language = LanguageEnum.en;
            docTemplate.TVType = TVTypeEnum.Subsector;
            docTemplate.TVFileTVItemID = tvFile.TVFileTVItemID;
            docTemplate.FileName = tvItemBouctoucheWWTPTVFileImageEN.TVText;
            docTemplate.LastUpdateDate_UTC = DateTime.Now;
            docTemplate.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("DocTemplate", docTemplate)) return false;
            #endregion DocTemplate
            #region Log
            StatusTempEvent(new StatusEventArgs("doing ... Log"));
            Log log = new Log();
            log.TableName = "TVItems";
            log.ID = 20;
            log.LogCommand = LogCommandEnum.Add;
            log.Information = "The Information Text";
            log.LastUpdateDate_UTC = DateTime.Now;
            log.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("Log", log)) return false;
            #endregion Log
            #region MWQMLookupMPN
            StatusTempEvent(new StatusEventArgs("doing ... MWQMLookupMPN"));
            List<MWQMLookupMPN> mwqmLookupMPNList = dbCSSPDB.MWQMLookupMPNs.AsNoTracking().Take(12).ToList();
            foreach (MWQMLookupMPN mwqmLookupMPN2 in mwqmLookupMPNList)
            {
                MWQMLookupMPN mwqmLookupMPN = new MWQMLookupMPN();
                mwqmLookupMPN.Tubes10 = mwqmLookupMPN2.Tubes10;
                mwqmLookupMPN.Tubes1 = mwqmLookupMPN2.Tubes1;
                mwqmLookupMPN.Tubes01 = mwqmLookupMPN2.Tubes01;
                mwqmLookupMPN.MPN_100ml = mwqmLookupMPN2.MPN_100ml;
                mwqmLookupMPN.LastUpdateDate_UTC = DateTime.Now;
                mwqmLookupMPN.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
                if (!AddObject("MWQMLookupMPN", mwqmLookupMPN)) return false;
            }
            #endregion MWQMLookupMPN
            #region TVItem Rain Exceedance
            StatusTempEvent(new StatusEventArgs("doing ... Canada"));
            // TVItem Rain Exceedance TVItemID = 374858
            TVItem tvItemExceedance = dbCSSPDB.TVItems.AsNoTracking().Where(c => c.TVItemID == 374858).FirstOrDefault();
            tvItemExceedance.ParentID = tvItemCanada.TVItemID;
            if (!AddObject("TVItem", tvItemExceedance)) return false;
            if (!CorrectTVPath(tvItemExceedance, tvItemCanada)) return false;
            if (!AddMapInfo(tvItemExceedance, 374858, tvItemContactCharles.TVItemID)) return false;

            // TVItemLanguage EN Rain Exceedance TVItemID = 374858
            TVItemLanguage tvItemLanguageENRainExceedance = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 374858 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENRainExceedance.TVItemID = tvItemExceedance.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENRainExceedance)) return false;

            // TVItemLanguage FR Rain Exceedance TVItemID = 374858
            TVItemLanguage tvItemLanguageFRRainExceedance = dbCSSPDB.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 374858 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRRainExceedance.TVItemID = tvItemExceedance.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRRainExceedance)) return false;
            #endregion TVItem Rain Exceedance
            #region RainExceedance
            StatusTempEvent(new StatusEventArgs("doing ... RainExceedance"));
            RainExceedance rainExceedance = dbCSSPDB.RainExceedances.AsNoTracking().Where(c => c.RainExceedanceTVItemID == 374858).FirstOrDefault();
            rainExceedance.RainExceedanceTVItemID = tvItemExceedance.TVItemID;
            rainExceedance.StartMonth = rainExceedance.StartMonth;
            rainExceedance.StartDay = rainExceedance.StartDay;
            rainExceedance.EndMonth = rainExceedance.EndMonth;
            rainExceedance.EndDay = rainExceedance.EndDay;
            rainExceedance.RainMaximum_mm = rainExceedance.RainMaximum_mm;
            rainExceedance.StakeholdersEmailDistributionListID = emailDistributionList.EmailDistributionListID;
            rainExceedance.OnlyStaffEmailDistributionListID = emailDistributionList.EmailDistributionListID;
            rainExceedance.IsActive = rainExceedance.IsActive;
            rainExceedance.LastUpdateDate_UTC = DateTime.Now;
            rainExceedance.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("RainExceedance", rainExceedance)) return false;
            #endregion RainExceedance
            #region RainExceedanceClimateSite
            StatusTempEvent(new StatusEventArgs("doing ... RainExceedanceClimateSite"));
            RainExceedanceClimateSite rainExceedanceClimateSite = dbCSSPDB.RainExceedanceClimateSites.AsNoTracking().Where(c => c.RainExceedanceTVItemID == 374858).FirstOrDefault();
            rainExceedanceClimateSite.RainExceedanceTVItemID = tvItemExceedance.TVItemID;
            rainExceedanceClimateSite.ClimateSiteTVItemID = climateSite.ClimateSiteTVItemID;
            rainExceedanceClimateSite.LastUpdateDate_UTC = DateTime.Now;
            rainExceedanceClimateSite.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("RainExceedanceClimateSite", rainExceedanceClimateSite)) return false;
            #endregion RainExceedanceClimateSite
            #region ResetPassword
            StatusTempEvent(new StatusEventArgs("doing ... ResetPassword"));
            ResetPassword resetPassword = new ResetPassword();
            resetPassword.Email = contactCharles.LoginEmail;
            resetPassword.ExpireDate_Local = DateTime.Now;
            resetPassword.Code = "12345678";
            resetPassword.LastUpdateDate_UTC = DateTime.Now;
            resetPassword.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("ResetPassword", resetPassword)) return false;
            #endregion ResetPassword
            #region TideLocation
            StatusTempEvent(new StatusEventArgs("doing ... TideLocation"));
            foreach (int TideLocationSID in new List<int>() { 1815, 1812, 1810 })
            {
                TideLocation tideLocation = dbCSSPDB.TideLocations.AsNoTracking().Where(c => c.sid == TideLocationSID).FirstOrDefault();

                if (tideLocation != null)
                {
                    tideLocation.TideLocationID = 0;
                    if (!AddObject("TideLocation", tideLocation)) return false;
                }
            }
            #endregion TideLocation
            #region TVItemStat
            StatusTempEvent(new StatusEventArgs("doing ... TVItemStat"));
            TVItemStat tvItemStat = dbCSSPDB.TVItemStats.AsNoTracking().Where(c => c.TVItemID == RootTVItemID && c.TVType == TVTypeEnum.Municipality).FirstOrDefault();

            if (tvItemStat != null)
            {
                tvItemStat.TVItemStatID = 0;
                tvItemStat.TVItemID = tvItemRoot.TVItemID;
                tvItemStat.ChildCount = 2;
                if (!AddObject("TVItemStat", tvItemStat)) return false;
            }
            #endregion TVItemStat
            #region TVItemUserAuthorization
            StatusTempEvent(new StatusEventArgs("doing ... TVItemUserAuthorization"));
            TVItemUserAuthorization tvItemUserAuthorization = dbCSSPDB.TVItemUserAuthorizations.AsNoTracking().FirstOrDefault();

            if (tvItemUserAuthorization != null)
            {
                tvItemUserAuthorization.ContactTVItemID = contactCharles.ContactTVItemID;
                tvItemUserAuthorization.TVItemID1 = tvItemBouctouche.TVItemID;
                tvItemUserAuthorization.TVAuth = TVAuthEnum.Write;
                if (!AddObject("TVItemUserAuthorization", tvItemUserAuthorization)) return false;
            }
            #endregion TVItemUserAuthorization
            #region TVTypeUserAuthorization
            StatusTempEvent(new StatusEventArgs("doing ... TVTypeUserAuthorization"));
            TVTypeUserAuthorization tvTypeUserAuthorization = dbCSSPDB.TVTypeUserAuthorizations.AsNoTracking().FirstOrDefault();

            if (tvTypeUserAuthorization != null)
            {
                tvTypeUserAuthorization.ContactTVItemID = contactCharles.ContactTVItemID;
                tvTypeUserAuthorization.TVType = TVTypeEnum.Root;
                tvTypeUserAuthorization.TVAuth = TVAuthEnum.Admin;
                if (!AddObject("TVTypeUserAuthorization", tvTypeUserAuthorization)) return false;
            }
            #endregion TVTypeUserAuthorization
            #region MWQMAnalysisReportParameter
            StatusTempEvent(new StatusEventArgs("doing ... MWQMAnalysisReportParameter"));
            MWQMAnalysisReportParameter mwqmAnalysisReportParameter = new MWQMAnalysisReportParameter();
            mwqmAnalysisReportParameter.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
            mwqmAnalysisReportParameter.AnalysisName = "Name of analysis report parameter";
            mwqmAnalysisReportParameter.AnalysisReportYear = 2016;
            mwqmAnalysisReportParameter.StartDate = new DateTime(2010, 1, 1);
            mwqmAnalysisReportParameter.EndDate = new DateTime(2016, 12, 31);
            mwqmAnalysisReportParameter.AnalysisCalculationType = AnalysisCalculationTypeEnum.AllAllAll;
            mwqmAnalysisReportParameter.NumberOfRuns = 30;
            mwqmAnalysisReportParameter.FullYear = true;
            mwqmAnalysisReportParameter.SalinityHighlightDeviationFromAverage = 8.0f;
            mwqmAnalysisReportParameter.ShortRangeNumberOfDays = 3;
            mwqmAnalysisReportParameter.MidRangeNumberOfDays = 6;
            mwqmAnalysisReportParameter.DryLimit24h = 4;
            mwqmAnalysisReportParameter.DryLimit48h = 8;
            mwqmAnalysisReportParameter.DryLimit72h = 12;
            mwqmAnalysisReportParameter.DryLimit96h = 16;
            mwqmAnalysisReportParameter.WetLimit24h = 12;
            mwqmAnalysisReportParameter.WetLimit48h = 24;
            mwqmAnalysisReportParameter.WetLimit72h = 36;
            mwqmAnalysisReportParameter.WetLimit96h = 48;
            mwqmAnalysisReportParameter.RunsToOmit = ",";
            mwqmAnalysisReportParameter.ExcelTVFileTVItemID = null;
            mwqmAnalysisReportParameter.Command = AnalysisReportExportCommandEnum.Report;
            mwqmAnalysisReportParameter.LastUpdateDate_UTC = DateTime.Now;
            mwqmAnalysisReportParameter.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("MWQMAnalysisReportParameter", mwqmAnalysisReportParameter)) return false;
            #endregion MWQMAnalysisReportParameter
            #region PolSourceSiteEffect, PolSourceSiteEffectTerm
            StatusTempEvent(new StatusEventArgs("doing ... PolSourceSiteEffect, PolSourceSiteEffectTerm"));
            // PolSourceSiteEffect 
            PolSourceSiteEffect polSourceSiteEffect = dbCSSPDB.PolSourceSiteEffects.AsNoTracking().Where(c => c.PolSourceSiteEffectTermIDs != null).FirstOrDefault();
            string PolSourceSiteEffectTermIDs = polSourceSiteEffect.PolSourceSiteEffectTermIDs;
            polSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID = polSourceSitePolSite000023.PolSourceSiteTVItemID;
            polSourceSiteEffect.MWQMSiteTVItemID = mwqmSite0001.MWQMSiteTVItemID;
            polSourceSiteEffect.AnalysisDocumentTVItemID = tvFileBouctoucheWWTP.TVFileTVItemID;

            List<int> ListEffectTermID = PolSourceSiteEffectTermIDs.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToList();

            string PolSourceSiteEffectTermIDsNew = "";
            foreach (int effectTermID in ListEffectTermID)
            {
                // PolSourceSiteEffectTerm
                PolSourceSiteEffectTerm polSourceSiteEffectTerm = dbCSSPDB.PolSourceSiteEffectTerms.AsNoTracking().FirstOrDefault();
                if (!AddObject("PolSourceSiteEffectTerm", polSourceSiteEffectTerm)) return false;

                PolSourceSiteEffectTermIDsNew = polSourceSiteEffectTerm.PolSourceSiteEffectTermID.ToString() + ",";
            }

            polSourceSiteEffect.PolSourceSiteEffectTermIDs = PolSourceSiteEffectTermIDsNew;
            if (!AddObject("PolSourceSiteEffect", polSourceSiteEffect)) return false;

            #endregion PolSourceSiteEffect, PolSourceSiteEffectTerm

            return true;
        }
        /// <summary>
        ///     Add MapInfo related information in the TestDB and table MapInfos and MapInfoPoints
        /// </summary>
        /// <param name="NewTVItem">TVItem for which to create a MapInfo row</param>
        /// <param name="OldTVItemID">The old TVItemID coming from the CSSPDB</param>
        /// <param name="ContactTVItemID">The ContactTVItemID who has writing permission to the TestDB</param>
        /// <returns>True if everything went ok</returns>
        private bool AddMapInfo(TVItem NewTVItem, int OldTVItemID, int ContactTVItemID)
        {
            List<MapInfo> mapInfoList = (from c in dbCSSPDB.MapInfos.AsNoTracking()
                                         where c.TVItemID == OldTVItemID
                                         select c).ToList();
            int MapInfoID = 0;
            foreach (MapInfo mapInfo in mapInfoList)
            {
                MapInfoID = mapInfo.MapInfoID;

                mapInfo.TVItemID = NewTVItem.TVItemID;
                mapInfo.LastUpdateContactTVItemID = ContactTVItemID;

                mapInfo.MapInfoID = 0;
                MapInfoService mapInfoService = new MapInfoService(new Query(), dbTestDB, 2);
                mapInfoService.Add(mapInfo);
                if (mapInfo.ValidationResults.Count() > 0)
                {
                    CSSPErrorEvent(new CSSPErrorEventArgs(mapInfo.ValidationResults.First().ErrorMessage));
                    return false;
                }

                List<MapInfoPoint> mapInfoPointList = (from c in dbCSSPDB.MapInfoPoints.AsNoTracking()
                                                       where c.MapInfoID == MapInfoID
                                                       select c).ToList();

                MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query(), dbTestDB, 2);
                foreach (MapInfoPoint mapInfoPoint in mapInfoPointList)
                {
                    mapInfoPoint.MapInfoPointID = 0;
                    mapInfoPoint.MapInfoID = mapInfo.MapInfoID;
                    mapInfoPoint.LastUpdateContactTVItemID = ContactTVItemID;

                    mapInfoPointService.Add(mapInfoPoint);
                    if (mapInfoPoint.ValidationResults.Count() > 0)
                    {
                        CSSPErrorEvent(new CSSPErrorEventArgs(mapInfoPoint.ValidationResults.First().ErrorMessage));
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        ///     Adds a row of information in TestDB depending on the type name
        /// </summary>
        /// <param name="TypeName">Model type name which also relates to table name within TestDB</param>
        /// <param name="objTarget">The object to add as a row in the proper table in TestDB</param>
        /// <returns>True if everything went ok</returns>
        private bool AddObject(string TypeName, object objTarget)
        {
            switch (TypeName)
            {
                case "Address":
                    {
                        ((Address)objTarget).AddressID = 0;
                        ((Address)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.Addresses.Add((Address)objTarget);
                    }
                    break;
                case "AppErrLog":
                    {
                        ((AppErrLog)objTarget).AppErrLogID = 0;
                        ((AppErrLog)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.AppErrLogs.Add((AppErrLog)objTarget);
                    }
                    break;
                case "AppTask":
                    {
                        ((AppTask)objTarget).AppTaskID = 0;
                        ((AppTask)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.AppTasks.Add((AppTask)objTarget);
                    }
                    break;
                case "AppTaskLanguage":
                    {
                        ((AppTaskLanguage)objTarget).AppTaskLanguageID = 0;
                        ((AppTaskLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.AppTaskLanguages.Add((AppTaskLanguage)objTarget);
                    }
                    break;
                case "AspNetUser":
                    {
                        dbTestDB.AspNetUsers.Add((AspNetUser)objTarget);
                    }
                    break;
                case "BoxModel":
                    {
                        ((BoxModel)objTarget).BoxModelID = 0;
                        ((BoxModel)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.BoxModels.Add((BoxModel)objTarget);
                    }
                    break;
                case "BoxModelLanguage":
                    {
                        ((BoxModelLanguage)objTarget).BoxModelLanguageID = 0;
                        ((BoxModelLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.BoxModelLanguages.Add((BoxModelLanguage)objTarget);
                    }
                    break;
                case "BoxModelResult":
                    {
                        ((BoxModelResult)objTarget).BoxModelResultID = 0;
                        ((BoxModelResult)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.BoxModelResults.Add((BoxModelResult)objTarget);
                    }
                    break;
                case "Classification":
                    {
                        ((Classification)objTarget).ClassificationID = 0;
                        ((Classification)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.Classifications.Add((Classification)objTarget);
                    }
                    break;
                case "ClimateDataValue":
                    {
                        ((ClimateDataValue)objTarget).ClimateDataValueID = 0;
                        ((ClimateDataValue)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.ClimateDataValues.Add((ClimateDataValue)objTarget);
                    }
                    break;
                case "ClimateSite":
                    {
                        ((ClimateSite)objTarget).ClimateSiteID = 0;
                        ((ClimateSite)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.ClimateSites.Add((ClimateSite)objTarget);
                    }
                    break;
                case "Contact":
                    {
                        ((Contact)objTarget).ContactID = 0;
                        ((Contact)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.Contacts.Add((Contact)objTarget);
                    }
                    break;
                case "ContactPreference":
                    {
                        ((ContactPreference)objTarget).ContactPreferenceID = 0;
                        ((ContactPreference)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.ContactPreferences.Add((ContactPreference)objTarget);
                    }
                    break;
                case "ContactShortcut":
                    {
                        ((ContactShortcut)objTarget).ContactShortcutID = 0;
                        ((ContactShortcut)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.ContactShortcuts.Add((ContactShortcut)objTarget);
                    }
                    break;
                case "DocTemplate":
                    {
                        ((DocTemplate)objTarget).DocTemplateID = 0;
                        ((DocTemplate)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.DocTemplates.Add((DocTemplate)objTarget);
                    }
                    break;
                case "DrogueRun":
                    {
                        ((DrogueRun)objTarget).DrogueRunID = 0;
                        ((DrogueRun)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.DrogueRuns.Add((DrogueRun)objTarget);
                    }
                    break;
                case "DrogueRunPosition":
                    {
                        ((DrogueRunPosition)objTarget).DrogueRunPositionID = 0;
                        ((DrogueRunPosition)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.DrogueRunPositions.Add((DrogueRunPosition)objTarget);
                    }
                    break;
                case "Email":
                    {
                        ((Email)objTarget).EmailID = 0;
                        ((Email)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.Emails.Add((Email)objTarget);
                    }
                    break;
                case "EmailDistributionList":
                    {
                        ((EmailDistributionList)objTarget).EmailDistributionListID = 0;
                        ((EmailDistributionList)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.EmailDistributionLists.Add((EmailDistributionList)objTarget);
                    }
                    break;
                case "EmailDistributionListContact":
                    {
                        ((EmailDistributionListContact)objTarget).EmailDistributionListContactID = 0;
                        ((EmailDistributionListContact)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.EmailDistributionListContacts.Add((EmailDistributionListContact)objTarget);
                    }
                    break;
                case "EmailDistributionListContactLanguage":
                    {
                        ((EmailDistributionListContactLanguage)objTarget).EmailDistributionListContactLanguageID = 0;
                        ((EmailDistributionListContactLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.EmailDistributionListContactLanguages.Add((EmailDistributionListContactLanguage)objTarget);
                    }
                    break;
                case "EmailDistributionListLanguage":
                    {
                        ((EmailDistributionListLanguage)objTarget).EmailDistributionListLanguageID = 0;
                        ((EmailDistributionListLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.EmailDistributionListLanguages.Add((EmailDistributionListLanguage)objTarget);
                    }
                    break;
                case "HelpDoc":
                    {
                        ((HelpDoc)objTarget).HelpDocID = 0;
                        ((HelpDoc)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.HelpDocs.Add((HelpDoc)objTarget);
                    }
                    break;
                case "HydrometricDataValue":
                    {
                        ((HydrometricDataValue)objTarget).HydrometricDataValueID = 0;
                        ((HydrometricDataValue)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.HydrometricDataValues.Add((HydrometricDataValue)objTarget);
                    }
                    break;
                case "HydrometricSite":
                    {
                        ((HydrometricSite)objTarget).HydrometricSiteID = 0;
                        ((HydrometricSite)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.HydrometricSites.Add((HydrometricSite)objTarget);
                    }
                    break;
                case "Infrastructure":
                    {
                        ((Infrastructure)objTarget).InfrastructureID = 0;
                        ((Infrastructure)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.Infrastructures.Add((Infrastructure)objTarget);
                    }
                    break;
                case "InfrastructureLanguage":
                    {
                        ((InfrastructureLanguage)objTarget).InfrastructureLanguageID = 0;
                        ((InfrastructureLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.InfrastructureLanguages.Add((InfrastructureLanguage)objTarget);
                    }
                    break;
                case "LabSheet":
                    {
                        ((LabSheet)objTarget).LabSheetID = 0;
                        ((LabSheet)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.LabSheets.Add((LabSheet)objTarget);
                    }
                    break;
                case "LabSheetDetail":
                    {
                        ((LabSheetDetail)objTarget).LabSheetDetailID = 0;
                        ((LabSheetDetail)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.LabSheetDetails.Add((LabSheetDetail)objTarget);
                    }
                    break;
                case "LabSheetTubeMPNDetail":
                    {
                        ((LabSheetTubeMPNDetail)objTarget).LabSheetTubeMPNDetailID = 0;
                        ((LabSheetTubeMPNDetail)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.LabSheetTubeMPNDetails.Add((LabSheetTubeMPNDetail)objTarget);
                    }
                    break;
                case "Log":
                    {
                        ((Log)objTarget).LogID = 0;
                        ((Log)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.Logs.Add((Log)objTarget);
                    }
                    break;
                case "MikeBoundaryCondition":
                    {
                        ((MikeBoundaryCondition)objTarget).MikeBoundaryConditionID = 0;
                        ((MikeBoundaryCondition)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.MikeBoundaryConditions.Add((MikeBoundaryCondition)objTarget);
                    }
                    break;
                case "MikeScenario":
                    {
                        ((MikeScenario)objTarget).MikeScenarioID = 0;
                        ((MikeScenario)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.MikeScenarios.Add((MikeScenario)objTarget);
                    }
                    break;
                case "MikeScenarioResult":
                    {
                        ((MikeScenarioResult)objTarget).MikeScenarioResultID = 0;
                        ((MikeScenarioResult)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.MikeScenarioResults.Add((MikeScenarioResult)objTarget);
                    }
                    break;
                case "MikeSource":
                    {
                        ((MikeSource)objTarget).MikeSourceID = 0;
                        ((MikeSource)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.MikeSources.Add((MikeSource)objTarget);
                    }
                    break;
                case "MikeSourceStartEnd":
                    {
                        ((MikeSourceStartEnd)objTarget).MikeSourceStartEndID = 0;
                        ((MikeSourceStartEnd)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.MikeSourceStartEnds.Add((MikeSourceStartEnd)objTarget);
                    }
                    break;
                case "MWQMAnalysisReportParameter":
                    {
                        ((MWQMAnalysisReportParameter)objTarget).MWQMAnalysisReportParameterID = 0;
                        ((MWQMAnalysisReportParameter)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.MWQMAnalysisReportParameters.Add((MWQMAnalysisReportParameter)objTarget);
                    }
                    break;
                case "MWQMLookupMPN":
                    {
                        ((MWQMLookupMPN)objTarget).MWQMLookupMPNID = 0;
                        ((MWQMLookupMPN)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.MWQMLookupMPNs.Add((MWQMLookupMPN)objTarget);
                    }
                    break;
                case "MWQMRun":
                    {
                        ((MWQMRun)objTarget).MWQMRunID = 0;
                        ((MWQMRun)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.MWQMRuns.Add((MWQMRun)objTarget);
                    }
                    break;
                case "MWQMRunLanguage":
                    {
                        ((MWQMRunLanguage)objTarget).MWQMRunLanguageID = 0;
                        ((MWQMRunLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.MWQMRunLanguages.Add((MWQMRunLanguage)objTarget);
                    }
                    break;
                case "MWQMSample":
                    {
                        ((MWQMSample)objTarget).MWQMSampleID = 0;
                        ((MWQMSample)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.MWQMSamples.Add((MWQMSample)objTarget);
                    }
                    break;
                case "MWQMSampleLanguage":
                    {
                        ((MWQMSampleLanguage)objTarget).MWQMSampleLanguageID = 0;
                        ((MWQMSampleLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.MWQMSampleLanguages.Add((MWQMSampleLanguage)objTarget);
                    }
                    break;
                case "MWQMSite":
                    {
                        ((MWQMSite)objTarget).MWQMSiteID = 0;
                        ((MWQMSite)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.MWQMSites.Add((MWQMSite)objTarget);
                    }
                    break;
                case "MWQMSiteStartEndDate":
                    {
                        ((MWQMSiteStartEndDate)objTarget).MWQMSiteStartEndDateID = 0;
                        ((MWQMSiteStartEndDate)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.MWQMSiteStartEndDates.Add((MWQMSiteStartEndDate)objTarget);
                    }
                    break;
                case "MWQMSubsector":
                    {
                        ((MWQMSubsector)objTarget).MWQMSubsectorID = 0;
                        ((MWQMSubsector)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.MWQMSubsectors.Add((MWQMSubsector)objTarget);
                    }
                    break;
                case "MWQMSubsectorLanguage":
                    {
                        ((MWQMSubsectorLanguage)objTarget).MWQMSubsectorLanguageID = 0;
                        ((MWQMSubsectorLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.MWQMSubsectorLanguages.Add((MWQMSubsectorLanguage)objTarget);
                    }
                    break;
                case "PolSourceSite":
                    {
                        ((PolSourceSite)objTarget).PolSourceSiteID = 0;
                        ((PolSourceSite)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.PolSourceSites.Add((PolSourceSite)objTarget);
                    }
                    break;
                case "PolSourceSiteEffect":
                    {
                        ((PolSourceSiteEffect)objTarget).PolSourceSiteEffectID = 0;
                        ((PolSourceSiteEffect)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.PolSourceSiteEffects.Add((PolSourceSiteEffect)objTarget);
                    }
                    break;
                case "PolSourceSiteEffectTerm":
                    {
                        ((PolSourceSiteEffectTerm)objTarget).PolSourceSiteEffectTermID = 0;
                        ((PolSourceSiteEffectTerm)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.PolSourceSiteEffectTerms.Add((PolSourceSiteEffectTerm)objTarget);
                    }
                    break;
                case "PolSourceObservation":
                    {
                        ((PolSourceObservation)objTarget).PolSourceObservationID = 0;
                        ((PolSourceObservation)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.PolSourceObservations.Add((PolSourceObservation)objTarget);
                    }
                    break;
                case "PolSourceObservationIssue":
                    {
                        ((PolSourceObservationIssue)objTarget).PolSourceObservationIssueID = 0;
                        ((PolSourceObservationIssue)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.PolSourceObservationIssues.Add((PolSourceObservationIssue)objTarget);
                    }
                    break;
                case "RainExceedance":
                    {
                        ((RainExceedance)objTarget).RainExceedanceID = 0;
                        ((RainExceedance)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.RainExceedances.Add((RainExceedance)objTarget);
                    }
                    break;
                case "RainExceedanceClimateSite":
                    {
                        ((RainExceedanceClimateSite)objTarget).RainExceedanceClimateSiteID = 0;
                        ((RainExceedanceClimateSite)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.RainExceedanceClimateSites.Add((RainExceedanceClimateSite)objTarget);
                    }
                    break;
                case "RatingCurveValue":
                    {
                        ((RatingCurveValue)objTarget).RatingCurveValueID = 0;
                        ((RatingCurveValue)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.RatingCurveValues.Add((RatingCurveValue)objTarget);
                    }
                    break;
                case "RatingCurve":
                    {
                        ((RatingCurve)objTarget).RatingCurveID = 0;
                        ((RatingCurve)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.RatingCurves.Add((RatingCurve)objTarget);
                    }
                    break;
                case "ReportSection":
                    {
                        ((ReportSection)objTarget).ReportSectionID = 0;
                        ((ReportSection)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.ReportSections.Add((ReportSection)objTarget);
                    }
                    break;
                case "ReportType":
                    {
                        ((ReportType)objTarget).ReportTypeID = 0;
                        ((ReportType)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.ReportTypes.Add((ReportType)objTarget);
                    }
                    break;
                case "ResetPassword":
                    {
                        ((ResetPassword)objTarget).ResetPasswordID = 0;
                        ((ResetPassword)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.ResetPasswords.Add((ResetPassword)objTarget);
                    }
                    break;
                case "SamplingPlan":
                    {
                        ((SamplingPlan)objTarget).SamplingPlanID = 0;
                        ((SamplingPlan)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.SamplingPlans.Add((SamplingPlan)objTarget);
                    }
                    break;
                case "SamplingPlanEmail":
                    {
                        ((SamplingPlanEmail)objTarget).SamplingPlanEmailID = 0;
                        ((SamplingPlanEmail)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.SamplingPlanEmails.Add((SamplingPlanEmail)objTarget);
                    }
                    break;
                case "SamplingPlanSubsector":
                    {
                        ((SamplingPlanSubsector)objTarget).SamplingPlanSubsectorID = 0;
                        ((SamplingPlanSubsector)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.SamplingPlanSubsectors.Add((SamplingPlanSubsector)objTarget);
                    }
                    break;
                case "SamplingPlanSubsectorSite":
                    {
                        ((SamplingPlanSubsectorSite)objTarget).SamplingPlanSubsectorSiteID = 0;
                        ((SamplingPlanSubsectorSite)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.SamplingPlanSubsectorSites.Add((SamplingPlanSubsectorSite)objTarget);
                    }
                    break;
                case "Spill":
                    {
                        ((Spill)objTarget).SpillID = 0;
                        ((Spill)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.Spills.Add((Spill)objTarget);
                    }
                    break;
                case "SpillLanguage":
                    {
                        ((SpillLanguage)objTarget).SpillLanguageID = 0;
                        ((SpillLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.SpillLanguages.Add((SpillLanguage)objTarget);
                    }
                    break;
                case "Tel":
                    {
                        ((Tel)objTarget).TelID = 0;
                        ((Tel)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.Tels.Add((Tel)objTarget);
                    }
                    break;
                case "TideSite":
                    {
                        ((TideSite)objTarget).TideSiteID = 0;
                        ((TideSite)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.TideSites.Add((TideSite)objTarget);
                    }
                    break;
                case "TideDataValue":
                    {
                        ((TideDataValue)objTarget).TideDataValueID = 0;
                        ((TideDataValue)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.TideDataValues.Add((TideDataValue)objTarget);
                    }
                    break;
                case "TideLocation":
                    {
                        ((TideLocation)objTarget).TideLocationID = 0;
                        //((TideLocation)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.TideLocations.Add((TideLocation)objTarget);
                    }
                    break;
                case "TVFile":
                    {
                        ((TVFile)objTarget).TVFileID = 0;
                        ((TVFile)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.TVFiles.Add((TVFile)objTarget);
                    }
                    break;
                case "TVFileLanguage":
                    {
                        ((TVFileLanguage)objTarget).TVFileLanguageID = 0;
                        ((TVFileLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.TVFileLanguages.Add((TVFileLanguage)objTarget);
                    }
                    break;
                case "TVItem":
                    {
                        ((TVItem)objTarget).TVItemID = 0;
                        ((TVItem)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.TVItems.Add((TVItem)objTarget);
                    }
                    break;
                case "TVItemLanguage":
                    {
                        ((TVItemLanguage)objTarget).TVItemLanguageID = 0;
                        ((TVItemLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.TVItemLanguages.Add((TVItemLanguage)objTarget);
                    }
                    break;
                case "TVItemLink":
                    {
                        ((TVItemLink)objTarget).TVItemLinkID = 0;
                        ((TVItemLink)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.TVItemLinks.Add((TVItemLink)objTarget);
                    }
                    break;
                case "TVItemStat":
                    {
                        ((TVItemStat)objTarget).TVItemStatID = 0;
                        ((TVItemStat)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.TVItemStats.Add((TVItemStat)objTarget);
                    }
                    break;
                case "TVItemUserAuthorization":
                    {
                        ((TVItemUserAuthorization)objTarget).TVItemUserAuthorizationID = 0;
                        ((TVItemUserAuthorization)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.TVItemUserAuthorizations.Add((TVItemUserAuthorization)objTarget);
                    }
                    break;
                case "TVTypeUserAuthorization":
                    {
                        ((TVTypeUserAuthorization)objTarget).TVTypeUserAuthorizationID = 0;
                        ((TVTypeUserAuthorization)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.TVTypeUserAuthorizations.Add((TVTypeUserAuthorization)objTarget);
                    }
                    break;
                case "UseOfSite":
                    {
                        ((UseOfSite)objTarget).UseOfSiteID = 0;
                        ((UseOfSite)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.UseOfSites.Add((UseOfSite)objTarget);
                    }
                    break;
                case "VPAmbient":
                    {
                        ((VPAmbient)objTarget).VPAmbientID = 0;
                        ((VPAmbient)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.VPAmbients.Add((VPAmbient)objTarget);
                    }
                    break;
                case "VPResult":
                    {
                        ((VPResult)objTarget).VPResultID = 0;
                        ((VPResult)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.VPResults.Add((VPResult)objTarget);
                    }
                    break;
                case "VPScenario":
                    {
                        ((VPScenario)objTarget).VPScenarioID = 0;
                        ((VPScenario)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.VPScenarios.Add((VPScenario)objTarget);
                    }
                    break;
                case "VPScenarioLanguage":
                    {
                        ((VPScenarioLanguage)objTarget).VPScenarioLanguageID = 0;
                        ((VPScenarioLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDB.VPScenarioLanguages.Add((VPScenarioLanguage)objTarget);
                    }
                    break;
                default:
                    {
                        CSSPErrorEvent(new CSSPErrorEventArgs($"Type [{ TypeName }] not implemented"));
                        return false;
                    }
            }

            try
            {
                dbTestDB.SaveChanges();
            }
            catch (Exception ex)
            {
                string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                return false;
            }

            return true;
        }
        /// <summary>
        ///     Corrects the TVPath of TVItems in TestDB to properly reflect the new TVItemID
        /// </summary>
        /// <param name="tvItem">Current TVItem of TestDB</param>
        /// <param name="tvItemParent">Parent TVItem of TestEB</param>
        /// <returns></returns>
        private bool CorrectTVPath(TVItem tvItem, TVItem tvItemParent)
        {
            tvItem.TVPath = $"{ tvItemParent.TVPath }p{ tvItem.TVItemID.ToString() }";

            try
            {
                dbTestDB.SaveChanges();
            }
            catch (Exception ex)
            {
                string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                return false;
            }

            return true;
        }
        /// <summary>
        ///     Loads DB information and store each Table related information in tableList
        /// </summary>
        /// <param name="tableList">List of Table related information of the ConnectionString DB</param>
        /// <param name="ConnectionString">Database connection string</param>
        /// <returns></returns>
        private bool LoadDBInfo(List<Table> tableList, string ConnectionString)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    cnn.Open();
                    DataTable tblList = cnn.GetSchema("Tables");
                    DataTable clmList = cnn.GetSchema("Columns");

                    foreach (DataRow tbl in tblList.Rows)
                    {
                        Table table = new Table();
                        table.TableName = tbl.ItemArray[2].ToString();
                        tableList.Add(table);

                        foreach (DataRow dr in clmList.Rows)
                        {
                            if (dr[2].ToString() == table.TableName)
                            {
                                Col col = new Col();
                                col.FieldName = dr[3].ToString();
                                col.AllowNull = (dr[6].ToString() == "NO" ? false : true);
                                col.DataType = dr[7].ToString();
                                col.StringLength = (string.IsNullOrWhiteSpace(dr[8].ToString()) ? 0 : int.Parse(dr[8].ToString()));

                                table.colList.Add(col);
                            }
                        }
                    }

                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                return false;
            }

            return true;
        }
        /// <summary>
        ///     Add other rows for tables within TestDB that has less then 10 rows
        /// </summary>
        /// <returns></returns>
        private bool MakingSureEveryTableHasEnoughItemsInTestDB()
        {
            int count = 0;

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in Addresses"));

            #region Addresses
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.Addresses select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        Address address = (from c in db.Addresses select c).OrderByDescending(c => c.AddressID).FirstOrDefault();
                        try
                        {
                            address.AddressID = 0;
                            address.StreetName = $"{ address.StreetName }a";
                            if (!AddObject("Address", address)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion Addresses

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in AppErrLogs"));

            #region AppErrLogs
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.AppErrLogs select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        AppErrLog AppErrLog = (from c in db.AppErrLogs select c).OrderByDescending(c => c.AppErrLogID).FirstOrDefault();
                        try
                        {
                            AppErrLog.AppErrLogID = 0;
                            AppErrLog.Source = $"{ AppErrLog.Source }a";
                            if (!AddObject("AppErrLog", AppErrLog)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException}"));
                            return false;
                        }
                    }
                }
            }
            #endregion AppErrLogs

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in AppTasks"));

            #region AppTasks
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.AppTasks select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        AppTask AppTask = (from c in db.AppTasks select c).OrderByDescending(c => c.AppTaskID).FirstOrDefault();
                        AppTaskLanguage AppTaskLanguageEN = (from c in db.AppTaskLanguages where c.AppTaskID == AppTask.AppTaskID && c.Language == LanguageEnum.en select c).FirstOrDefault();
                        AppTaskLanguage AppTaskLanguageFR = (from c in db.AppTaskLanguages where c.AppTaskID == AppTask.AppTaskID && c.Language == LanguageEnum.fr select c).FirstOrDefault();
                        try
                        {
                            AppTask.AppTaskID = 0;
                            AppTask.Parameters = $"{ AppTask.Parameters }a";
                            if (!AddObject("AppTask", AppTask)) return false;

                            AppTaskLanguageEN.AppTaskLanguageID = 0;
                            AppTaskLanguageEN.AppTaskID = AppTask.AppTaskID;
                            AppTaskLanguageEN.StatusText = $"{ AppTaskLanguageEN.StatusText }a";
                            if (!AddObject("AppTaskLanguage", AppTaskLanguageEN)) return false;

                            AppTaskLanguageFR.AppTaskLanguageID = 0;
                            AppTaskLanguageFR.AppTaskID = AppTask.AppTaskID;
                            AppTaskLanguageFR.StatusText = $"{ AppTaskLanguageFR.StatusText }a";
                            if (!AddObject("AppTaskLanguage", AppTaskLanguageFR)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion AppTasks

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in BoxModels"));

            #region BoxModels
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.BoxModels select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        BoxModel BoxModel = (from c in db.BoxModels select c).OrderByDescending(c => c.BoxModelID).FirstOrDefault();
                        BoxModelLanguage BoxModelLanguageEN = (from c in db.BoxModelLanguages where c.BoxModelID == BoxModel.BoxModelID && c.Language == LanguageEnum.en select c).FirstOrDefault();
                        BoxModelLanguage BoxModelLanguageFR = (from c in db.BoxModelLanguages where c.BoxModelID == BoxModel.BoxModelID && c.Language == LanguageEnum.fr select c).FirstOrDefault();
                        List<BoxModelResult> BoxModelResultList = (from c in db.BoxModelResults where c.BoxModelID == BoxModel.BoxModelID select c).ToList();
                        try
                        {
                            BoxModel.BoxModelID = 0;
                            BoxModel.DecayRate_per_day = BoxModel.DecayRate_per_day + 0.1f;
                            if (!AddObject("BoxModel", BoxModel)) return false;

                            BoxModelLanguageEN.BoxModelLanguageID = 0;
                            BoxModelLanguageEN.BoxModelID = BoxModel.BoxModelID;
                            BoxModelLanguageEN.ScenarioName = $"{ BoxModelLanguageEN.ScenarioName }a";
                            if (!AddObject("BoxModelLanguage", BoxModelLanguageEN)) return false;

                            BoxModelLanguageFR.BoxModelLanguageID = 0;
                            BoxModelLanguageFR.BoxModelID = BoxModel.BoxModelID;
                            BoxModelLanguageFR.ScenarioName = $"{ BoxModelLanguageFR.ScenarioName }a";
                            if (!AddObject("BoxModelLanguage", BoxModelLanguageFR)) return false;

                            foreach (BoxModelResult boxModelResult in BoxModelResultList)
                            {
                                boxModelResult.BoxModelResultID = 0;
                                boxModelResult.BoxModelID = BoxModel.BoxModelID;
                                boxModelResult.Radius_m = boxModelResult.Radius_m + 1.0f;
                                if (!AddObject("BoxModelResult", boxModelResult)) return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion BoxModels

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in ClimateSites"));

            #region ClimateSites
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.ClimateSites select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        ClimateSite ClimateSite = (from c in db.ClimateSites select c).OrderByDescending(c => c.ClimateSiteID).FirstOrDefault();
                        List<ClimateDataValue> ClimateDataValueList = (from c in db.ClimateDataValues where c.ClimateSiteID == ClimateSite.ClimateSiteID select c).ToList();
                        try
                        {
                            ClimateSite.ClimateSiteID = 0;
                            ClimateSite.ClimateSiteName = $"{ ClimateSite.ClimateSiteName }a";
                            if (!AddObject("ClimateSite", ClimateSite)) return false;

                            foreach (ClimateDataValue climateDataValue in ClimateDataValueList)
                            {
                                climateDataValue.ClimateDataValueID = 0;
                                climateDataValue.ClimateSiteID = ClimateSite.ClimateSiteID;
                                climateDataValue.TotalPrecip_mm_cm = climateDataValue.TotalPrecip_mm_cm + 1.0f;
                                if (!AddObject("ClimateDataValue", climateDataValue)) return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion ClimateSites

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in ContactPreferences"));

            #region ContactPreferences
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.ContactPreferences select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        ContactPreference ContactPreference = (from c in db.ContactPreferences select c).OrderByDescending(c => c.ContactPreferenceID).FirstOrDefault();
                        try
                        {
                            ContactPreference.ContactPreferenceID = 0;
                            ContactPreference.MarkerSize = ContactPreference.MarkerSize + 1;
                            if (!AddObject("ContactPreference", ContactPreference)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion ContactPreferences

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in Contacts"));

            #region Contacts
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.Contacts select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        Contact Contact = (from c in db.Contacts select c).OrderByDescending(c => c.ContactID).FirstOrDefault();
                        try
                        {
                            Contact.ContactID = 0;
                            Contact.FirstName = $"{ Contact.FirstName }a";
                            if (!AddObject("Contact", Contact)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion Contacts

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in ContactShortcuts"));

            #region ContactShortcuts
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.ContactShortcuts select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        ContactShortcut ContactShortcut = (from c in db.ContactShortcuts select c).OrderByDescending(c => c.ContactShortcutID).FirstOrDefault();
                        try
                        {
                            ContactShortcut.ContactShortcutID = 0;
                            ContactShortcut.ShortCutText = $"{ ContactShortcut.ShortCutText }a";
                            if (!AddObject("ContactShortcut", ContactShortcut)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion ContactShortcuts

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in DocTemplates"));

            #region DocTemplates
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.DocTemplates select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        DocTemplate DocTemplate = (from c in db.DocTemplates select c).OrderByDescending(c => c.DocTemplateID).FirstOrDefault();
                        try
                        {
                            DocTemplate.DocTemplateID = 0;
                            DocTemplate.FileName = $"{ DocTemplate.FileName }a";
                            if (!AddObject("DocTemplate", DocTemplate)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion DocTemplates

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in DrogueRuns"));

            #region DrogueRuns
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.DrogueRuns select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        DrogueRun drogueRun = (from c in db.DrogueRuns select c).OrderByDescending(c => c.DrogueRunID).FirstOrDefault();
                        List<DrogueRunPosition> drogueRunPositionList = (from c in db.DrogueRunPositions select c).OrderByDescending(c => c.DrogueRunID).Take(3).ToList();
                        try
                        {
                            drogueRun.DrogueRunID = 0;
                            drogueRun.DrogueNumber = drogueRun.DrogueNumber + 1;
                            if (!AddObject("DrogueRun", drogueRun)) return false;

                            foreach (DrogueRunPosition drogueRunPosition in drogueRunPositionList)
                            {
                                drogueRunPosition.DrogueRunPositionID = 0;
                                drogueRunPosition.DrogueRunID = drogueRun.DrogueRunID;
                                if (!AddObject("DrogueRunPosition", drogueRunPosition)) return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion DrogueRuns

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in EmailDistributionListContactLanguages"));

            #region EmailDistributionListContactLanguages
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.EmailDistributionLists select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        EmailDistributionList EmailDistributionList = (from c in db.EmailDistributionLists select c).OrderByDescending(c => c.EmailDistributionListID).FirstOrDefault();
                        List<EmailDistributionListLanguage> EmailDistributionListLanguageList = (from c in db.EmailDistributionListLanguages where c.EmailDistributionListID == EmailDistributionList.EmailDistributionListID select c).ToList();
                        List<EmailDistributionListContact> EmailDistributionListContactList = (from c in db.EmailDistributionListContacts where c.EmailDistributionListID == EmailDistributionList.EmailDistributionListID select c).ToList();
                        try
                        {
                            EmailDistributionList.EmailDistributionListID = 0;
                            //EmailDistributionList.Agency = $"{ EmailDistributionList.Agency }a";
                            if (!AddObject("EmailDistributionList", EmailDistributionList)) return false;

                            foreach (EmailDistributionListLanguage emailDistributionListLanguage in EmailDistributionListLanguageList)
                            {
                                emailDistributionListLanguage.EmailDistributionListLanguageID = 0;
                                emailDistributionListLanguage.EmailDistributionListID = EmailDistributionList.EmailDistributionListID;
                                emailDistributionListLanguage.EmailListName = $"{ emailDistributionListLanguage.EmailListName }a";
                                if (!AddObject("EmailDistributionListLanguage", emailDistributionListLanguage)) return false;
                            }

                            foreach (EmailDistributionListContact emailDistributionListContact in EmailDistributionListContactList)
                            {
                                emailDistributionListContact.EmailDistributionListContactID = 0;
                                emailDistributionListContact.EmailDistributionListID = EmailDistributionList.EmailDistributionListID;
                                emailDistributionListContact.Name = $"{ emailDistributionListContact.Name }a";
                                if (!AddObject("EmailDistributionListContact", emailDistributionListContact)) return false;

                                List<EmailDistributionListContactLanguage> EmailDistributionListContactLanguageList = (from c in db.EmailDistributionListContactLanguages select c).OrderByDescending(c => c.EmailDistributionListContactLanguageID).Take(2).ToList();

                                foreach (EmailDistributionListContactLanguage emailDistributionListContactLanguage in EmailDistributionListContactLanguageList)
                                {
                                    emailDistributionListContactLanguage.EmailDistributionListContactLanguageID = 0;
                                    emailDistributionListContactLanguage.EmailDistributionListContactID = emailDistributionListContact.EmailDistributionListContactID;
                                    emailDistributionListContactLanguage.Agency = $"{ emailDistributionListContactLanguage.Agency }a";
                                    if (!AddObject("EmailDistributionListContactLanguage", emailDistributionListContactLanguage)) return false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion EmailDistributionLists

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in Emails"));

            #region Emails
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.Emails select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        Email Email = (from c in db.Emails select c).OrderByDescending(c => c.EmailID).FirstOrDefault();
                        try
                        {
                            Email.EmailID = 0;
                            Email.EmailAddress = $"a{ Email.EmailAddress}";
                            if (!AddObject("Email", Email)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion Emails

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in HelpDoc"));

            #region HelpDocs
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.HelpDocs select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        HelpDoc HelpDoc = (from c in db.HelpDocs select c).OrderByDescending(c => c.HelpDocID).FirstOrDefault();
                        try
                        {
                            HelpDoc.HelpDocID = 0;
                            if (!AddObject("HelpDoc", HelpDoc)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion HelpDocs

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in HydrometricSites"));

            #region HydrometricSites
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.HydrometricSites select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        HydrometricSite HydrometricSite = (from c in db.HydrometricSites select c).OrderByDescending(c => c.HydrometricSiteID).FirstOrDefault();
                        List<HydrometricDataValue> HydrometricDataValueList = (from c in db.HydrometricDataValues where c.HydrometricSiteID == HydrometricSite.HydrometricSiteID select c).ToList();
                        try
                        {
                            HydrometricSite.HydrometricSiteID = 0;
                            HydrometricSite.HydrometricSiteName = $"{ HydrometricSite.HydrometricSiteName }a";
                            if (!AddObject("HydrometricSite", HydrometricSite)) return false;

                            foreach (HydrometricDataValue hydrometricDataValue in HydrometricDataValueList)
                            {
                                hydrometricDataValue.HydrometricDataValueID = 0;
                                hydrometricDataValue.HydrometricSiteID = HydrometricSite.HydrometricSiteID;
                                hydrometricDataValue.HourlyValues = $"{ hydrometricDataValue.HourlyValues }a";
                                if (!AddObject("HydrometricDataValue", hydrometricDataValue)) return false;
                            }

                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion HydrometricSites

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in Infrastructures"));

            #region Infrastructures
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.Infrastructures select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        Infrastructure Infrastructure = (from c in db.Infrastructures select c).OrderByDescending(c => c.InfrastructureID).FirstOrDefault();
                        InfrastructureLanguage InfrastructureLanguageEN = (from c in db.InfrastructureLanguages where c.InfrastructureID == Infrastructure.InfrastructureID && c.Language == LanguageEnum.en select c).FirstOrDefault();
                        InfrastructureLanguage InfrastructureLanguageFR = (from c in db.InfrastructureLanguages where c.InfrastructureID == Infrastructure.InfrastructureID && c.Language == LanguageEnum.fr select c).FirstOrDefault();
                        try
                        {
                            Infrastructure.InfrastructureID = 0;
                            Infrastructure.PortElevation_m = Infrastructure.PortElevation_m + 0.1f;
                            if (!AddObject("Infrastructure", Infrastructure)) return false;

                            InfrastructureLanguageEN.InfrastructureLanguageID = 0;
                            InfrastructureLanguageEN.InfrastructureID = Infrastructure.InfrastructureID;
                            InfrastructureLanguageEN.Comment = $"{ InfrastructureLanguageEN.Comment }a";
                            if (!AddObject("InfrastructureLanguage", InfrastructureLanguageEN)) return false;

                            InfrastructureLanguageFR.InfrastructureLanguageID = 0;
                            InfrastructureLanguageFR.InfrastructureID = Infrastructure.InfrastructureID;
                            InfrastructureLanguageFR.Comment = $"{ InfrastructureLanguageFR.Comment }a";
                            if (!AddObject("InfrastructureLanguage", InfrastructureLanguageFR)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion Infrastructures

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in LabSheets"));

            #region LabSheets
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.LabSheets select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        LabSheet LabSheet = (from c in db.LabSheets select c).OrderByDescending(c => c.LabSheetID).FirstOrDefault();
                        LabSheetDetail LabSheetDetail = (from c in db.LabSheetDetails select c).OrderByDescending(c => c.LabSheetDetailID).FirstOrDefault();
                        try
                        {
                            LabSheet.LabSheetID = 0;
                            LabSheet.SamplingPlanName = $"{ LabSheet.SamplingPlanName }a";
                            if (!AddObject("LabSheet", LabSheet)) return false;

                            LabSheetDetail.LabSheetDetailID = 0;
                            LabSheetDetail.RunComment = $"{ LabSheetDetail.RunComment }a";
                            if (!AddObject("LabSheetDetail", LabSheetDetail)) return false;

                            LabSheetTubeMPNDetail LabSheetTubeMPNDetail = (from c in db.LabSheetTubeMPNDetails select c).OrderByDescending(c => c.LabSheetTubeMPNDetailID).FirstOrDefault();

                            LabSheetTubeMPNDetail.LabSheetTubeMPNDetailID = 0;
                            LabSheetTubeMPNDetail.LabSheetDetailID = LabSheetDetail.LabSheetDetailID;
                            LabSheetTubeMPNDetail.SiteComment = $"{ LabSheetTubeMPNDetail.SiteComment }a";
                            if (!AddObject("LabSheetTubeMPNDetail", LabSheetTubeMPNDetail)) return false;

                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion LabSheets

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in Logs"));

            #region Logs
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.Logs select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        Log Log = (from c in db.Logs select c).OrderByDescending(c => c.LogID).FirstOrDefault();
                        try
                        {
                            Log.LogID = 0;
                            Log.Information = $"{ Log.Information }a";
                            if (!AddObject("Log", Log)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion Logs

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in MikeBoundaryConditions"));

            #region MikeBoundaryConditions
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.MikeBoundaryConditions select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        MikeBoundaryCondition MikeBoundaryCondition = (from c in db.MikeBoundaryConditions select c).OrderByDescending(c => c.MikeBoundaryConditionID).FirstOrDefault();
                        try
                        {
                            MikeBoundaryCondition.MikeBoundaryConditionID = 0;
                            MikeBoundaryCondition.MikeBoundaryConditionCode = $"{ MikeBoundaryCondition.MikeBoundaryConditionCode }a";
                            if (!AddObject("MikeBoundaryCondition", MikeBoundaryCondition)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion MikeBoundaryConditions

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in MikeScenarios"));

            #region MikeScenarios
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.MikeScenarios select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        MikeScenario MikeScenario = (from c in db.MikeScenarios select c).OrderByDescending(c => c.MikeScenarioID).FirstOrDefault();
                        try
                        {
                            MikeScenario.MikeScenarioID = 0;
                            MikeScenario.ManningNumber = MikeScenario.ManningNumber + 0.1f;
                            if (!AddObject("MikeScenario", MikeScenario)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion MikeScenarios

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in MikeScenarioResults"));

            #region MikeScenarioResults
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.MikeScenarioResults select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        MikeScenarioResult MikeScenarioResult = (from c in db.MikeScenarioResults select c).OrderByDescending(c => c.MikeScenarioResultID).FirstOrDefault();
                        try
                        {
                            MikeScenarioResult.MikeScenarioResultID = 0;
                            if (!AddObject("MikeScenarioResult", MikeScenarioResult)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion MikeScenarioResults

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in MikeSources"));

            #region MikeSources
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.MikeSources select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        MikeSource MikeSource = (from c in db.MikeSources select c).OrderByDescending(c => c.MikeSourceID).FirstOrDefault();
                        MikeSourceStartEnd MikeSourceStartEnd = (from c in db.MikeSourceStartEnds select c).OrderByDescending(c => c.MikeSourceStartEndID).FirstOrDefault();
                        try
                        {
                            MikeSource.MikeSourceID = 0;
                            MikeSource.SourceNumberString = $"{ MikeSource.SourceNumberString }a";
                            if (!AddObject("MikeSource", MikeSource)) return false;

                            MikeSourceStartEnd.MikeSourceStartEndID = 0;
                            MikeSourceStartEnd.SourcePollutionStart_MPN_100ml = MikeSourceStartEnd.SourcePollutionStart_MPN_100ml + 1;
                            MikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = MikeSourceStartEnd.SourcePollutionEnd_MPN_100ml + 1;
                            if (!AddObject("MikeSourceStartEnd", MikeSourceStartEnd)) return false;

                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion MikeSources

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in MWQMAnalysisReportParameters"));

            #region MWQMAnalysisReportParameters
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.MWQMAnalysisReportParameters select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        MWQMAnalysisReportParameter MWQMAnalysisReportParameter = (from c in db.MWQMAnalysisReportParameters select c).OrderByDescending(c => c.MWQMAnalysisReportParameterID).FirstOrDefault();
                        try
                        {
                            MWQMAnalysisReportParameter.MWQMAnalysisReportParameterID = 0;
                            MWQMAnalysisReportParameter.AnalysisName = $"{ MWQMAnalysisReportParameter.AnalysisName }a";
                            if (!AddObject("MWQMAnalysisReportParameter", MWQMAnalysisReportParameter)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion MWQMAnalysisReportParameters            

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in MWQMRuns"));

            #region MWQMRuns
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.MWQMRuns select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        MWQMRun MWQMRun = (from c in db.MWQMRuns select c).OrderByDescending(c => c.MWQMRunID).FirstOrDefault();
                        List<MWQMRunLanguage> MWQMRunLanguageList = (from c in db.MWQMRunLanguages select c).OrderByDescending(c => c.MWQMRunLanguageID).Take(2).ToList();
                        try
                        {
                            MWQMRun.MWQMRunID = 0;
                            MWQMRun.TemperatureControl1_C = MWQMRun.TemperatureControl1_C + 1.1f;
                            if (!AddObject("MWQMRun", MWQMRun)) return false;

                            foreach (MWQMRunLanguage MWQMRunLanguage in MWQMRunLanguageList)
                            {
                                MWQMRunLanguage.MWQMRunLanguageID = 0;
                                MWQMRunLanguage.RunComment = $"{ MWQMRunLanguage.RunComment }a";
                                if (!AddObject("MWQMRunLanguage", MWQMRunLanguage)) return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion MWQMRuns

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in MWQMSamples"));

            #region MWQMSamples
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.MWQMSamples select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        MWQMSample MWQMSample = (from c in db.MWQMSamples select c).OrderByDescending(c => c.MWQMSampleID).FirstOrDefault();
                        List<MWQMSampleLanguage> MWQMSampleLanguageList = (from c in db.MWQMSampleLanguages select c).OrderByDescending(c => c.MWQMSampleLanguageID).Take(2).ToList();
                        try
                        {
                            MWQMSample.MWQMSampleID = 0;
                            MWQMSample.PH = MWQMSample.PH + 1.1f;
                            if (!AddObject("MWQMSample", MWQMSample)) return false;

                            foreach (MWQMSampleLanguage MWQMSampleLanguage in MWQMSampleLanguageList)
                            {
                                MWQMSampleLanguage.MWQMSampleLanguageID = 0;
                                MWQMSampleLanguage.MWQMSampleNote = $"{ MWQMSampleLanguage.MWQMSampleNote }a";
                                if (!AddObject("MWQMSampleLanguage", MWQMSampleLanguage)) return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion MWQMSamples

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in MWQMSites"));

            #region MWQMSites
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.MWQMSites select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        MWQMSite MWQMSite = (from c in db.MWQMSites select c).OrderByDescending(c => c.MWQMSiteID).FirstOrDefault();
                        MWQMSiteStartEndDate MWQMSiteStartEndDate = (from c in db.MWQMSiteStartEndDates select c).OrderByDescending(c => c.MWQMSiteStartEndDateID).FirstOrDefault();
                        try
                        {
                            MWQMSite.MWQMSiteID = 0;
                            MWQMSite.MWQMSiteDescription = $"{ MWQMSite.MWQMSiteDescription }a";
                            if (!AddObject("MWQMSite", MWQMSite)) return false;

                            MWQMSiteStartEndDate.MWQMSiteStartEndDateID = 0;
                            MWQMSiteStartEndDate.StartDate = MWQMSiteStartEndDate.StartDate.AddHours(1);
                            MWQMSiteStartEndDate.EndDate = MWQMSiteStartEndDate.EndDate.Value.AddHours(1);
                            if (!AddObject("MWQMSiteStartEndDate", MWQMSiteStartEndDate)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion MWQMSites

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in MWQMSubsectors"));

            #region MWQMSubsectors
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.MWQMSubsectors select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        MWQMSubsector MWQMSubsector = (from c in db.MWQMSubsectors select c).OrderByDescending(c => c.MWQMSubsectorID).FirstOrDefault();
                        List<MWQMSubsectorLanguage> MWQMSubsectorLanguageList = (from c in db.MWQMSubsectorLanguages select c).OrderByDescending(c => c.MWQMSubsectorLanguageID).Take(2).ToList();
                        try
                        {
                            MWQMSubsector.MWQMSubsectorID = 0;
                            MWQMSubsector.SubsectorHistoricKey = (MWQMSubsector.SubsectorHistoricKey.Length > 19 ? "bbb" : $"{ MWQMSubsector.SubsectorHistoricKey }a");
                            if (!AddObject("MWQMSubsector", MWQMSubsector)) return false;

                            foreach (MWQMSubsectorLanguage MWQMSubsectorLanguage in MWQMSubsectorLanguageList)
                            {
                                MWQMSubsectorLanguage.MWQMSubsectorLanguageID = 0;
                                MWQMSubsectorLanguage.SubsectorDesc = $"{ MWQMSubsectorLanguage.SubsectorDesc }a";
                                if (!AddObject("MWQMSubsectorLanguage", MWQMSubsectorLanguage)) return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion MWQMSubsectors

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in PolSourceSites"));

            #region PolSourceSites
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.PolSourceSites select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        PolSourceSite PolSourceSite = (from c in db.PolSourceSites select c).OrderByDescending(c => c.PolSourceSiteID).FirstOrDefault();
                        PolSourceObservation PolSourceObservation = (from c in db.PolSourceObservations select c).OrderByDescending(c => c.PolSourceObservationID).FirstOrDefault();
                        PolSourceObservationIssue PolSourceObservationIssue = (from c in db.PolSourceObservationIssues select c).OrderByDescending(c => c.PolSourceObservationIssueID).FirstOrDefault();
                        try
                        {
                            PolSourceSite.PolSourceSiteID = 0;
                            PolSourceSite.Temp_Locator_CanDelete = $"{ PolSourceSite.Temp_Locator_CanDelete }a";
                            if (!AddObject("PolSourceSite", PolSourceSite)) return false;

                            PolSourceObservation.PolSourceObservationID = 0;
                            PolSourceObservation.PolSourceSiteID = PolSourceSite.PolSourceSiteID;
                            PolSourceObservation.Observation_ToBeDeleted = $"{ PolSourceObservation.Observation_ToBeDeleted }a";
                            if (!AddObject("PolSourceObservation", PolSourceObservation)) return false;

                            PolSourceObservationIssue.PolSourceObservationIssueID = 0;
                            PolSourceObservationIssue.PolSourceObservationID = PolSourceObservation.PolSourceObservationID;
                            PolSourceObservationIssue.ExtraComment = $"{ PolSourceObservationIssue.ExtraComment }a";
                            if (!AddObject("PolSourceObservationIssue", PolSourceObservationIssue)) return false;

                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion PolSourceSites

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in RainExceedances"));

            #region RainExceedances
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.RainExceedances select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        RainExceedance RainExceedance = (from c in db.RainExceedances select c).OrderByDescending(c => c.RainExceedanceID).FirstOrDefault();
                        try
                        {
                            RainExceedance.RainExceedanceID = 0;
                            RainExceedance.StartDay = RainExceedance.StartDay + 1;
                            if (!AddObject("RainExceedance", RainExceedance)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion RainExceedances

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in RainExceedanceClimateSites"));

            #region RainExceedanceClimateSites
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.RainExceedanceClimateSites select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        RainExceedanceClimateSite rainExceedanceClimateSite = (from c in db.RainExceedanceClimateSites select c).OrderByDescending(c => c.RainExceedanceClimateSiteID).FirstOrDefault();
                        try
                        {
                            rainExceedanceClimateSite.RainExceedanceClimateSiteID = 0;
                            if (!AddObject("RainExceedanceClimateSite", rainExceedanceClimateSite)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion RainExceedanceClimates

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in RetingCurves"));

            #region RatingCurves
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.RatingCurves select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        RatingCurve RatingCurve = (from c in db.RatingCurves select c).OrderByDescending(c => c.RatingCurveID).FirstOrDefault();
                        RatingCurveValue RatingCurveValue = (from c in db.RatingCurveValues select c).OrderByDescending(c => c.RatingCurveValueID).FirstOrDefault();
                        try
                        {
                            RatingCurve.RatingCurveID = 0;
                            RatingCurve.RatingCurveNumber = RatingCurve.RatingCurveNumber + 1;
                            if (!AddObject("RatingCurve", RatingCurve)) return false;

                            RatingCurveValue.RatingCurveValueID = 0;
                            RatingCurveValue.RatingCurveID = RatingCurve.RatingCurveID;
                            RatingCurveValue.StageValue_m = RatingCurveValue.StageValue_m + 1;
                            if (!AddObject("RatingCurveValue", RatingCurveValue)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion RatingCurves

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in ReportSections"));

            #region ReportSections
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.ReportSections select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        ReportSection ReportSection = (from c in db.ReportSections select c).OrderByDescending(c => c.ReportSectionID).FirstOrDefault();
                        try
                        {
                            ReportSection.ReportSectionID = 0;
                            ReportSection.Year = ReportSection.Year + 1;
                            if (!AddObject("ReportSection", ReportSection)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion ReportSections

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in ReportTypes"));

            #region ReportTypes
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.ReportTypes select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        ReportType ReportType = (from c in db.ReportTypes select c).OrderByDescending(c => c.ReportTypeID).FirstOrDefault();
                        try
                        {
                            ReportType.ReportTypeID = 0;
                            ReportType.UniqueCode = $"{ ReportType.UniqueCode }a";
                            if (!AddObject("ReportType", ReportType)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion ReportTypes

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in ResetPasswords"));

            #region ResetPasswords
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.ResetPasswords select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        ResetPassword ResetPassword = (from c in db.ResetPasswords select c).OrderByDescending(c => c.ResetPasswordID).FirstOrDefault();
                        try
                        {
                            ResetPassword.ResetPasswordID = 0;
                            ResetPassword.Email = $"{ ResetPassword.Email }a";
                            if (!AddObject("ResetPassword", ResetPassword)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion ResetPasswords

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in SamplingPlans"));

            #region SamplingPlans
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.SamplingPlans select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        SamplingPlan SamplingPlan = (from c in db.SamplingPlans select c).OrderByDescending(c => c.SamplingPlanID).FirstOrDefault();
                        SamplingPlanEmail SamplingPlanEmail = (from c in db.SamplingPlanEmails select c).OrderByDescending(c => c.SamplingPlanEmailID).FirstOrDefault();
                        SamplingPlanSubsector SamplingPlanSubsector = (from c in db.SamplingPlanSubsectors select c).OrderByDescending(c => c.SamplingPlanSubsectorID).FirstOrDefault();
                        SamplingPlanSubsectorSite SamplingPlanSubsectorSite = (from c in db.SamplingPlanSubsectorSites select c).OrderByDescending(c => c.SamplingPlanSubsectorSiteID).FirstOrDefault();
                        try
                        {
                            SamplingPlan.SamplingPlanID = 0;
                            SamplingPlan.ForGroupName = $"{ SamplingPlan.ForGroupName }a";
                            SamplingPlan.SamplingPlanName = $"{ SamplingPlan.SamplingPlanName }a";
                            if (!AddObject("SamplingPlan", SamplingPlan)) return false;

                            SamplingPlanEmail.SamplingPlanEmailID = 0;
                            SamplingPlanEmail.Email = $"a{ SamplingPlanEmail.Email }";
                            if (!AddObject("SamplingPlanEmail", SamplingPlanEmail)) return false;

                            SamplingPlanSubsector.SamplingPlanSubsectorID = 0;
                            SamplingPlanSubsector.SamplingPlanID = SamplingPlan.SamplingPlanID;
                            if (!AddObject("SamplingPlanSubsector", SamplingPlanSubsector)) return false;

                            SamplingPlanSubsectorSite.SamplingPlanSubsectorSiteID = 0;
                            SamplingPlanSubsectorSite.SamplingPlanSubsectorID = SamplingPlanSubsectorSite.SamplingPlanSubsectorID;
                            if (!AddObject("SamplingPlanSubsectorSite", SamplingPlanSubsectorSite)) return false;

                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion SamplingPlans

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in Spills"));

            #region Spills
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.Spills select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        Spill Spill = (from c in db.Spills select c).OrderByDescending(c => c.SpillID).FirstOrDefault();
                        List<SpillLanguage> SpillLanguageList = (from c in db.SpillLanguages select c).OrderByDescending(c => c.SpillLanguageID).Take(2).ToList();
                        try
                        {
                            Spill.SpillID = 0;
                            Spill.AverageFlow_m3_day = Spill.AverageFlow_m3_day + 1;
                            if (!AddObject("Spill", Spill)) return false;

                            foreach (SpillLanguage SpillLanguage in SpillLanguageList)
                            {
                                SpillLanguage.SpillLanguageID = 0;
                                SpillLanguage.SpillComment = $"{ SpillLanguage.SpillComment }a";
                                if (!AddObject("SpillLanguage", SpillLanguage)) return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion Spills

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in Tels"));

            #region Tels
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.Tels select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        Tel Tel = (from c in db.Tels select c).OrderByDescending(c => c.TelID).FirstOrDefault();
                        try
                        {
                            Tel.TelID = 0;
                            Tel.TelNumber = Tel.TelNumber.Substring(Tel.TelNumber.Length - 2) + count * 2;
                            if (!AddObject("Tel", Tel)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion Tels

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in TideDataValues"));

            #region TideDataValues
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.TideDataValues select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        TideDataValue TideDataValue = (from c in db.TideDataValues select c).OrderByDescending(c => c.TideDataValueID).FirstOrDefault();
                        try
                        {
                            TideDataValue.TideDataValueID = 0;
                            TideDataValue.Depth_m = TideDataValue.Depth_m + 1;
                            if (!AddObject("TideDataValue", TideDataValue)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion TideDataValues

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in TideLocations"));

            #region TideLocations
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.TideLocations select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        TideLocation TideLocation = (from c in db.TideLocations select c).OrderByDescending(c => c.TideLocationID).FirstOrDefault();
                        try
                        {
                            TideLocation.TideLocationID = 0;
                            TideLocation.Name = $"{ TideLocation.Name }a";
                            if (!AddObject("TideLocation", TideLocation)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion TideLocations

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in TideSites"));

            #region TideSites
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.TideSites select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        TideSite TideSite = (from c in db.TideSites select c).OrderByDescending(c => c.TideSiteID).FirstOrDefault();
                        try
                        {
                            TideSite.TideSiteID = 0;
                            TideSite.TideSiteName = $"{ TideSite.TideSiteName }a";
                            if (!AddObject("TideSite", TideSite)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion TideSites

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in TVFiles"));

            #region TVFiles
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.TVFiles select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        TVFile TVFile = (from c in db.TVFiles select c).OrderByDescending(c => c.TVFileID).FirstOrDefault();
                        List<TVFileLanguage> TVFileLanguageList = (from c in db.TVFileLanguages select c).OrderByDescending(c => c.TVFileLanguageID).Take(2).ToList();
                        try
                        {
                            TVFile.TVFileID = 0;
                            TVFile.Parameters = $"{ TVFile.Parameters }a";
                            if (!AddObject("TVFile", TVFile)) return false;

                            foreach (TVFileLanguage TVFileLanguage in TVFileLanguageList)
                            {
                                TVFileLanguage.TVFileLanguageID = 0;
                                TVFileLanguage.FileDescription = $"{ TVFileLanguage.FileDescription }a";
                                if (!AddObject("TVFileLanguage", TVFileLanguage)) return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion TVFiles

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in TVItemLinks"));

            #region TVItemLinks
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.TVItemLinks select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        TVItemLink TVItemLink = (from c in db.TVItemLinks select c).OrderByDescending(c => c.TVItemLinkID).FirstOrDefault();
                        try
                        {
                            TVItemLink.TVItemLinkID = 0;
                            //TVItemLink.Email = $"{ TVItemLink.Email }a";
                            if (!AddObject("TVItemLink", TVItemLink)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion TVItemLinks

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in TVItemStats"));

            #region TVItemStats
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.TVItemStats select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        TVItemStat TVItemStat = (from c in db.TVItemStats select c).OrderByDescending(c => c.TVItemStatID).FirstOrDefault();
                        try
                        {
                            TVItemStat.TVItemStatID = 0;
                            TVItemStat.ChildCount = TVItemStat.ChildCount + 1;
                            if (!AddObject("TVItemStat", TVItemStat)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion TVItemStats

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in TVItemUserAuthorizations"));

            #region TVItemUserAuthorizations
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.TVItemUserAuthorizations select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        TVItemUserAuthorization TVItemUserAuthorization = (from c in db.TVItemUserAuthorizations select c).OrderByDescending(c => c.TVItemUserAuthorizationID).FirstOrDefault();
                        try
                        {
                            TVItemUserAuthorization.TVItemUserAuthorizationID = 0;
                            if (!AddObject("TVItemUserAuthorization", TVItemUserAuthorization)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion TVItemUserAuthorizations

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in TVTypeUserAuthorizations"));

            #region TVTypeUserAuthorizations
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.TVTypeUserAuthorizations select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        TVTypeUserAuthorization TVTypeUserAuthorization = (from c in db.TVTypeUserAuthorizations select c).OrderByDescending(c => c.TVTypeUserAuthorizationID).FirstOrDefault();
                        try
                        {
                            TVTypeUserAuthorization.TVTypeUserAuthorizationID = 0;
                            if (!AddObject("TVTypeUserAuthorization", TVTypeUserAuthorization)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion TVTypeUserAuthorizations

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in UseOfSites"));

            #region UseOfSites
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.UseOfSites select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        UseOfSite UseOfSite = (from c in db.UseOfSites select c).OrderByDescending(c => c.UseOfSiteID).FirstOrDefault();
                        try
                        {
                            UseOfSite.UseOfSiteID = 0;
                            UseOfSite.Weight_perc = UseOfSite.Weight_perc + 1;
                            if (!AddObject("UseOfSite", UseOfSite)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion UseOfSites

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in VPScenarios"));

            #region VPScenarios
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.VPScenarios select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        VPScenario VPScenario = (from c in db.VPScenarios select c).OrderByDescending(c => c.VPScenarioID).FirstOrDefault();
                        VPResult VPResult = (from c in db.VPResults select c).OrderByDescending(c => c.VPResultID).FirstOrDefault();
                        VPAmbient VPAmbient = (from c in db.VPAmbients select c).OrderByDescending(c => c.VPAmbientID).FirstOrDefault();
                        List<VPScenarioLanguage> VPScenarioLanguageList = (from c in db.VPScenarioLanguages select c).OrderByDescending(c => c.VPScenarioLanguageID).Take(2).ToList();
                        try
                        {
                            VPScenario.VPScenarioID = 0;
                            VPScenario.PortDiameter_m = VPScenario.PortDiameter_m + 0.1f;
                            if (!AddObject("VPScenario", VPScenario)) return false;

                            VPResult.VPResultID = 0;
                            VPResult.VPScenarioID = VPScenario.VPScenarioID;
                            VPResult.TravelTime_hour = VPResult.TravelTime_hour + 1;
                            if (!AddObject("VPResult", VPResult)) return false;

                            VPAmbient.VPAmbientID = 0;
                            VPAmbient.VPScenarioID = VPAmbient.VPScenarioID;
                            VPAmbient.MeasurementDepth_m = VPAmbient.MeasurementDepth_m + 0.02f;
                            if (!AddObject("VPAmbient", VPAmbient)) return false;

                            foreach (VPScenarioLanguage VPScenarioLanguage in VPScenarioLanguageList)
                            {
                                VPScenarioLanguage.VPScenarioLanguageID = 0;
                                VPScenarioLanguage.VPScenarioID = VPScenario.VPScenarioID;
                                VPScenarioLanguage.VPScenarioName = $"{ VPScenarioLanguage.VPScenarioName }a";
                                if (!AddObject("VPScenarioLanguage", VPScenarioLanguage)) return false;
                            }

                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion VPScenarios

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in PolSourceSiteEffects"));

            #region PolSourceSiteEffects
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.PolSourceSiteEffects select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        PolSourceSiteEffect polSourceSiteEffect = (from c in db.PolSourceSiteEffects select c).OrderByDescending(c => c.PolSourceSiteEffectID).FirstOrDefault();
                        try
                        {
                            polSourceSiteEffect.PolSourceSiteEffectID = 0;
                            polSourceSiteEffect.Comments = $"{ polSourceSiteEffect.Comments }a";
                            if (!AddObject("PolSourceSiteEffect", polSourceSiteEffect)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion PolSourceSiteEffects

            StatusTempEvent(new StatusEventArgs("doing ... Adding up to 10 items in PolSourceSiteEffectTerms"));

            #region PolSourceSiteEffectTerms
            using (CSSPDBContext db = new CSSPDBContext())
            {
                count = (from c in db.PolSourceSiteEffectTerms select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        PolSourceSiteEffectTerm polSourceSiteEffectTerm = (from c in db.PolSourceSiteEffectTerms select c).OrderByDescending(c => c.PolSourceSiteEffectTermID).FirstOrDefault();
                        try
                        {
                            polSourceSiteEffectTerm.PolSourceSiteEffectTermID = 0;
                            polSourceSiteEffectTerm.EffectTermEN = $"{ polSourceSiteEffectTerm.EffectTermEN }a";
                            polSourceSiteEffectTerm.EffectTermFR = $"{ polSourceSiteEffectTerm.EffectTermFR }a";
                            if (!AddObject("PolSourceSiteEffectTerm", polSourceSiteEffectTerm)) return false;
                        }
                        catch (Exception ex)
                        {
                            string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                            CSSPErrorEvent(new CSSPErrorEventArgs($"{ ex.Message }{ InnerException }"));
                            return false;
                        }
                    }
                }
            }
            #endregion PolSourceSiteEffectTerms

            return true;
        }
        /// <summary>
        ///     Collects all tables names in TestDB in the proper order so it can be used to delete all information in TestDB
        /// </summary>
        /// <param name="tableTestDBList">Table related information of TestDB</param>
        /// <returns></returns>
        private bool SetTestDBDeleteOrderedList(List<Table> tableTestDBList)
        {
            List<string> ListTableToDelete = new List<string>()
            {
                "Logs",
                "RainExceedanceClimateSites",
                "RainExceedances",
                "EmailDistributionListContactLanguages",
                "EmailDistributionListContacts",
                "EmailDistributionListLanguages",
                "EmailDistributionLists",
                "AppErrLogs",
                "AppTaskLanguages",
                "AppTasks",
                "AspNetRoles",
                "AspNetUserClaims",
                "AspNetUserLogins",
                "AspNetUserRoles",
                "BoxModelLanguages",
                "BoxModelResults",
                "BoxModels",
                "UseOfSites",
                "Classifications",
                "ClimateDataValues",
                "ClimateSites",
                "DocTemplates",
                "Addresses",
                "DrogueRuns",
                "DrogueRunPositions",
                "Emails",
                "HelpDocs",
                "Tels",
                "RatingCurves",
                "RatingCurveValues",
                "HydrometricDataValues",
                "HydrometricSites",
                "InfrastructureLanguages",
                "Infrastructures",
                "LabSheetTubeMPNDetails",
                "LabSheetDetails",
                "LabSheets",
                "MapInfoPoints",
                "MapInfos",
                "MikeBoundaryConditions",
                "MikeSources",
                "MikeSourceStartEnds",
                "MWQMAnalysisReportParameters",
                "MWQMLookupMPNs",
                "SamplingPlanEmails",
                "SamplingPlans",
                "SamplingPlanSubsectors",
                "SamplingPlanSubsectorSites",
                "MWQMRunLanguages",
                "MWQMRuns",
                "MWQMSampleLanguages",
                "MWQMSamples",
                "MWQMSiteStartEndDates",
                "PolSourceSiteEffects",
                "PolSourceSiteEffectTerms",
                "MWQMSites",
                "MWQMSubsectorLanguages",
                "MWQMSubsectors",
                "PolSourceObservationIssues",
                "PolSourceObservations",
                "PolSourceSites",
                "ResetPasswords",
                "SpillLanguages",
                "Spills",
                "TideDataValues",
                "TideLocations",
                "TideSites",
                "TVFileLanguages",
                "TVFiles",
                "ReportSectionLanguages",
                "ReportSections",
                "ReportTypeLanguages",
                "ReportTypes",
                "TVItemLanguages",
                "TVItemLinks",
                "TVItemUserAuthorizations",
                "TVTypeUserAuthorizations",
                "VPAmbients",
                "VPResults",
                "VPScenarioLanguages",
                "VPScenarios",
                "MikeScenarioResults",
                "MikeScenarios",
                "ContactPreferences",
                "ContactShortcuts",
                "Contacts",
                "AspNetUsers",
                "TVItemStats",
                "TVItems",
            };

            // checking if all table exist in the table to delete ordered list
            foreach (Table table in tableTestDBList)
            {
                if (!ListTableToDelete.Where(c => c == table.TableName).Any())
                {
                    CSSPErrorEvent(new CSSPErrorEventArgs($"{ table.TableName } is missing in the list of table to delete"));
                    return false;
                }
            }

            int OrdinalToDelete = 0;
            foreach (string s in ListTableToDelete)
            {
                OrdinalToDelete += 1;

                Table table = (from c in tableTestDBList
                               where c.TableName == s
                               select c).FirstOrDefault();

                if (table == null)
                {
                    CSSPErrorEvent(new CSSPErrorEventArgs($"{ s } is missing in the list of table"));
                    return false;
                }

                table.ordinalToDelete = OrdinalToDelete;
            }

            return true;
        }
        #endregion Functions private
    }
}
