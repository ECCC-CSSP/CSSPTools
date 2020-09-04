using CSSPModels;
using GenerateCodeBaseServices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceTestGeneratedServices.Services
{
    public partial class ServicesClassNameServiceTestGeneratedService : IServicesClassNameServiceTestGeneratedService
    {
        private async Task<bool> CreateGetFilledRandomClass(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb, StringBuilder sbInMemory, string DBType)
        {
            switch (csspProp.PropType)
            {
                case "Int16":
                case "Int32":
                case "Int64":
                case "Single":
                case "Double":
                    {
                        string propTypeTxt = "Int";
                        string numbExt = "";
                        if (csspProp.PropType == "Single")
                        {
                            propTypeTxt = "Float";
                            numbExt = ".0f";
                        }
                        else if (csspProp.PropType == "Double")
                        {
                            propTypeTxt = "Double";
                            numbExt = ".0D";
                        }

                        if (csspProp.IsKey)
                        {
                            //sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { prop.Name };");
                        }
                        else
                        {
                            //if (csspProp.PropName == "LastUpdateContactTVItemID")
                            //{
                            //    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = 2;");
                            //}
                            //else 
                            if (csspProp.HasCSSPExistAttribute)
                            {
                                switch (csspProp.ExistTypeName)
                                {
                                    case "AppTask":
                                        {
                                            AppTask appTask = dbTestDB.AppTasks.AsNoTracking().FirstOrDefault();
                                            if (appTask == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { appTask.AppTaskID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                }
                                                string AppTaskCommand = ((int)appTask.AppTaskCommand).ToString();
                                                string AppTaskStatus = ((int)appTask.AppTaskStatus).ToString();
                                                string Language = ((int)appTask.Language).ToString();
                                                string StartDateTimeStr = $@"new DateTime({ appTask.StartDateTime_UTC.Year }, { appTask.StartDateTime_UTC.Month }, { appTask.StartDateTime_UTC.Day }, { appTask.StartDateTime_UTC.Hour }, { appTask.StartDateTime_UTC.Minute }, { appTask.StartDateTime_UTC.Second })";
                                                string EndDateTimeStr = appTask.EndDateTime_UTC == null ? "null" : $@"new DateTime({ ((DateTime)appTask.EndDateTime_UTC).Year }, { ((DateTime)appTask.EndDateTime_UTC).Month }, { ((DateTime)appTask.EndDateTime_UTC).Day }, { ((DateTime)appTask.EndDateTime_UTC).Hour }, { ((DateTime)appTask.EndDateTime_UTC).Minute }, { ((DateTime)appTask.EndDateTime_UTC).Second })";
                                                string LastUpdateDateStr = $@"new DateTime({ appTask.LastUpdateDate_UTC.Year }, { appTask.LastUpdateDate_UTC.Month }, { appTask.LastUpdateDate_UTC.Day }, { appTask.LastUpdateDate_UTC.Hour }, { appTask.LastUpdateDate_UTC.Minute }, { appTask.LastUpdateDate_UTC.Second })";
                                                string EstimatedLength_secondStr = appTask.EstimatedLength_second == null ? "null" : $"{ (int)appTask.EstimatedLength_second }";
                                                string RemainingTime_secondStr = appTask.RemainingTime_second == null ? "null" : $"{ (int)appTask.RemainingTime_second }";
                                                string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                    $@"AppTaskID = { appTask.AppTaskID }, " +
                                                    $@"TVItemID = { appTask.TVItemID }, " +
                                                    $@"TVItemID2 = { appTask.TVItemID2 }, " +
                                                    $@"AppTaskCommand = (AppTaskCommandEnum){ AppTaskCommand }, " +
                                                    $@"AppTaskStatus = (AppTaskStatusEnum){ AppTaskStatus }, " +
                                                    $@"PercentCompleted = { appTask.PercentCompleted }, " +
                                                    $@"Parameters = ""{ appTask.Parameters }"", " +
                                                    $@"Language = (LanguageEnum){ Language }, " +
                                                    $@"StartDateTime_UTC = { StartDateTimeStr }, " +
                                                    $@"EndDateTime_UTC = { EndDateTimeStr }, " +
                                                    $@"EstimatedLength_second = { appTask.EstimatedLength_second }, " +
                                                    $@"RemainingTime_second = { RemainingTime_secondStr }, " +
                                                    $@"LastUpdateDate_UTC = { LastUpdateDateStr }, " +
                                                    $@"LastUpdateContactTVItemID = { appTask.LastUpdateContactTVItemID } " +
                                                    $@"}});";
                                                if (!sbInMemory.ToString().Contains(TempStr))
                                                {
                                                    sbInMemory.AppendLine($@"            try");
                                                    sbInMemory.AppendLine($@"            {{");
                                                    sbInMemory.AppendLine(TempStr);
                                                    sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                    sbInMemory.AppendLine($@"            }}");
                                                    sbInMemory.AppendLine($@"            catch (Exception)");
                                                    sbInMemory.AppendLine($@"            {{");
                                                    sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                    sbInMemory.AppendLine($@"            }}");
                                                }
                                            }
                                        }
                                        break;
                                    case "BoxModel":
                                        {
                                            BoxModel boxModel = dbTestDB.BoxModels.AsNoTracking().FirstOrDefault();
                                            if (boxModel == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { boxModel.BoxModelID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string LastUpdateDateStr = $@"new DateTime({ boxModel.LastUpdateDate_UTC.Year }, { boxModel.LastUpdateDate_UTC.Month }, { boxModel.LastUpdateDate_UTC.Day }, { boxModel.LastUpdateDate_UTC.Hour }, { boxModel.LastUpdateDate_UTC.Minute }, { boxModel.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"BoxModelID = { boxModel.BoxModelID }, " +
                                                        $@"InfrastructureTVItemID = { boxModel.InfrastructureTVItemID }, " +
                                                        $@"Discharge_m3_day = { boxModel.Discharge_m3_day }, " +
                                                        $@"Depth_m = { boxModel.Depth_m }, " +
                                                        $@"Temperature_C = { boxModel.Temperature_C }, " +
                                                        $@"Dilution = { boxModel.Dilution }, " +
                                                        $@"DecayRate_per_day = { boxModel.DecayRate_per_day }, " +
                                                        $@"FCUntreated_MPN_100ml = { boxModel.FCUntreated_MPN_100ml }, " +
                                                        $@"FCPreDisinfection_MPN_100ml = { boxModel.FCPreDisinfection_MPN_100ml }, " +
                                                        $@"Concentration_MPN_100ml = { boxModel.Concentration_MPN_100ml }, " +
                                                        $@"T90_hour = { boxModel.T90_hour }, " +
                                                        $@"DischargeDuration_hour = { boxModel.DischargeDuration_hour }, " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDateStr }, " +
                                                        $@"LastUpdateContactTVItemID = { boxModel.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "ClimateSite":
                                        {
                                            ClimateSite climateSite = dbTestDB.ClimateSites.AsNoTracking().FirstOrDefault();
                                            if (climateSite == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { climateSite.ClimateSiteID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string ECDBID = climateSite.ECDBID == null ? "null" : climateSite.ECDBID.ToString();
                                                    string Elevation_m = climateSite.Elevation_m == null ? "null" : climateSite.Elevation_m.ToString();
                                                    string ClimateID = climateSite.ClimateID == null ? "null" : climateSite.ClimateID.ToString();
                                                    string WMOID = climateSite.WMOID == null ? "null" : climateSite.WMOID.ToString();
                                                    string TCID = climateSite.TCID == null ? "null" : climateSite.TCID.ToString();
                                                    string IsQuebecSite = climateSite.IsQuebecSite == null ? "null" : climateSite.IsQuebecSite.ToString();
                                                    string IsCoCoRaHS = climateSite.IsCoCoRaHS == null ? "null" : climateSite.IsCoCoRaHS.ToString();
                                                    string TimeOffset_hour = climateSite.TimeOffset_hour == null ? "null" : climateSite.TimeOffset_hour.ToString();
                                                    string File_desc = climateSite.File_desc == null ? "null" : climateSite.File_desc.ToString();
                                                    string HourlyStartDate_Local = climateSite.HourlyStartDate_Local == null ? "null" : $@"new DateTime({ ((DateTime)climateSite.HourlyStartDate_Local).Year }, { ((DateTime)climateSite.HourlyStartDate_Local).Month }, { ((DateTime)climateSite.HourlyStartDate_Local).Day }, { ((DateTime)climateSite.HourlyStartDate_Local).Hour }, { ((DateTime)climateSite.HourlyStartDate_Local).Minute }, { ((DateTime)climateSite.HourlyStartDate_Local).Second })";
                                                    string HourlyEndDate_Local = climateSite.HourlyEndDate_Local == null ? "null" : $@"new DateTime({ ((DateTime)climateSite.HourlyEndDate_Local).Year }, { ((DateTime)climateSite.HourlyEndDate_Local).Month }, { ((DateTime)climateSite.HourlyEndDate_Local).Day }, { ((DateTime)climateSite.HourlyEndDate_Local).Hour }, { ((DateTime)climateSite.HourlyEndDate_Local).Minute }, { ((DateTime)climateSite.HourlyEndDate_Local).Second })";
                                                    string HourlyNow = climateSite.HourlyNow == null ? "null" : climateSite.HourlyNow.ToString().ToLower();
                                                    string DailyStartDate_Local = climateSite.DailyStartDate_Local == null ? "null" : $@"new DateTime({ ((DateTime)climateSite.DailyStartDate_Local).Year }, { ((DateTime)climateSite.DailyStartDate_Local).Month }, { ((DateTime)climateSite.DailyStartDate_Local).Day }, { ((DateTime)climateSite.DailyStartDate_Local).Hour }, { ((DateTime)climateSite.DailyStartDate_Local).Minute }, { ((DateTime)climateSite.DailyStartDate_Local).Second })";
                                                    string DailyEndDate_Local = climateSite.DailyEndDate_Local == null ? "null" : $@"new DateTime({ ((DateTime)climateSite.DailyEndDate_Local).Year }, { ((DateTime)climateSite.DailyEndDate_Local).Month }, { ((DateTime)climateSite.DailyEndDate_Local).Day }, { ((DateTime)climateSite.DailyEndDate_Local).Hour }, { ((DateTime)climateSite.DailyEndDate_Local).Minute }, { ((DateTime)climateSite.DailyEndDate_Local).Second })";
                                                    string DailyNow = climateSite.DailyNow == null ? "null" : climateSite.DailyNow.ToString().ToLower();
                                                    string MonthlyStartDate_Local = climateSite.MonthlyStartDate_Local == null ? "null" : $@"new DateTime({ ((DateTime)climateSite.MonthlyStartDate_Local).Year }, { ((DateTime)climateSite.MonthlyStartDate_Local).Month }, { ((DateTime)climateSite.MonthlyStartDate_Local).Day }, { ((DateTime)climateSite.MonthlyStartDate_Local).Hour }, { ((DateTime)climateSite.MonthlyStartDate_Local).Minute }, { ((DateTime)climateSite.MonthlyStartDate_Local).Second })";
                                                    string MonthlyEndDate_Local = climateSite.MonthlyEndDate_Local == null ? "null" : $@"new DateTime({ ((DateTime)climateSite.MonthlyEndDate_Local).Year }, { ((DateTime)climateSite.MonthlyEndDate_Local).Month }, { ((DateTime)climateSite.MonthlyEndDate_Local).Day }, { ((DateTime)climateSite.MonthlyEndDate_Local).Hour }, { ((DateTime)climateSite.MonthlyEndDate_Local).Minute }, { ((DateTime)climateSite.MonthlyEndDate_Local).Second })";
                                                    string MonthlyNow = climateSite.MonthlyNow == null ? "null" : climateSite.MonthlyNow.ToString().ToLower();
                                                    string LastUpdateDate_UTC = $@"new DateTime({ climateSite.LastUpdateDate_UTC.Year }, { climateSite.LastUpdateDate_UTC.Month }, { climateSite.LastUpdateDate_UTC.Day }, { climateSite.LastUpdateDate_UTC.Hour }, { climateSite.LastUpdateDate_UTC.Minute }, { climateSite.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"ClimateSiteID = { climateSite.ClimateSiteID }, " +
                                                        $@"ClimateSiteTVItemID = { climateSite.ClimateSiteTVItemID }, " +
                                                        $@"ECDBID = { ECDBID }, " +
                                                        $@"ClimateSiteName = ""{ climateSite.ClimateSiteName }"", " +
                                                        $@"Province = ""{ climateSite.Province }"", " +
                                                        $@"Elevation_m = { Elevation_m }, " +
                                                        $@"ClimateID = ""{ ClimateID }"", " +
                                                        $@"WMOID = { WMOID }, " +
                                                        $@"TCID = ""{ TCID }"", " +
                                                        $@"IsQuebecSite = { IsQuebecSite }, " +
                                                        $@"IsCoCoRaHS = { IsCoCoRaHS }, " +
                                                        $@"TimeOffset_hour = { TimeOffset_hour }, " +
                                                        $@"File_desc = { File_desc }, " +
                                                        $@"HourlyStartDate_Local = { HourlyStartDate_Local }, " +
                                                        $@"HourlyEndDate_Local = { HourlyEndDate_Local }, " +
                                                        $@"HourlyNow = { HourlyNow }, " +
                                                        $@"DailyStartDate_Local = { DailyStartDate_Local }, " +
                                                        $@"DailyEndDate_Local = { DailyEndDate_Local }, " +
                                                        $@"DailyNow = { DailyNow }, " +
                                                        $@"MonthlyStartDate_Local = { MonthlyStartDate_Local }, " +
                                                        $@"MonthlyEndDate_Local = { MonthlyEndDate_Local }, " +
                                                        $@"MonthlyNow = { MonthlyNow }, " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { climateSite.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "Contact":
                                        {
                                            Contact contact = dbTestDB.Contacts.AsNoTracking().FirstOrDefault();
                                            if (contact == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { contact.ContactID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string DateStr = $@"new DateTime({ contact.LastUpdateDate_UTC.Year }, { contact.LastUpdateDate_UTC.Month }, { contact.LastUpdateDate_UTC.Day }, { contact.LastUpdateDate_UTC.Hour }, { contact.LastUpdateDate_UTC.Minute }, { contact.LastUpdateDate_UTC.Second })";
                                                    string Id = contact.Id ?? "";
                                                    string LoginEmail = contact.LoginEmail ?? "";
                                                    string FirstName = contact.FirstName ?? "";
                                                    string Initial = contact.Initial ?? "";
                                                    string LastName = contact.LastName ?? "";
                                                    string WebName = contact.WebName ?? "";
                                                    string ProvincesTVItemID = contact.SamplingPlanner_ProvincesTVItemID ?? "";
                                                    string Token = contact.Token ?? "";
                                                    string ContactTitle = contact.ContactTitle == null ? "0" : ((int)contact.ContactTitle).ToString();
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"ContactID = { contact.ContactID }, " +
                                                        $@"Id = ""{ Id }"" ?? """", " +
                                                        $@"ContactTVItemID = { contact.ContactTVItemID }, " +
                                                        $@"LoginEmail = ""{ LoginEmail }"", " +
                                                        $@"FirstName = ""{ FirstName }"", " +
                                                        $@"LastName = ""{ LastName }"", " +
                                                        $@"Initial = ""{ Initial }"", " +
                                                        $@"WebName = ""{ WebName }"", " +
                                                        $@"ContactTitle = (ContactTitleEnum){ ContactTitle }, " +
                                                        $@"IsAdmin = { contact.IsAdmin.ToString().ToLower() }, " +
                                                        $@"EmailValidated = { contact.EmailValidated.ToString().ToLower() }, " +
                                                        $@"Disabled = { contact.Disabled.ToString().ToLower() }, " +
                                                        $@"IsNew = { contact.IsNew.ToString().ToLower() }, " +
                                                        $@"SamplingPlanner_ProvincesTVItemID = ""{ ProvincesTVItemID }"", " +
                                                        $@"Token = ""{ Token }"", " +
                                                        $@"LastUpdateDate_UTC = { DateStr  }, " +
                                                        $@"LastUpdateContactTVItemID = { contact.LastUpdateContactTVItemID }" +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "DrogueRun":
                                        {
                                            DrogueRun drogueRun = dbTestDB.DrogueRuns.AsNoTracking().FirstOrDefault();
                                            if (drogueRun == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { drogueRun.DrogueRunID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string RunStartDateTime = $@"new DateTime({ drogueRun.RunStartDateTime.Year }, { drogueRun.RunStartDateTime.Month }, { drogueRun.RunStartDateTime.Day }, { drogueRun.RunStartDateTime.Hour }, { drogueRun.RunStartDateTime.Minute }, { drogueRun.RunStartDateTime.Second })";
                                                    string LastUpdateDate_UTC = $@"new DateTime({ drogueRun.LastUpdateDate_UTC.Year }, { drogueRun.LastUpdateDate_UTC.Month }, { drogueRun.LastUpdateDate_UTC.Day }, { drogueRun.LastUpdateDate_UTC.Hour }, { drogueRun.LastUpdateDate_UTC.Minute }, { drogueRun.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"DrogueRunID = { drogueRun.DrogueRunID }, " +
                                                        $@"SubsectorTVItemID = { drogueRun.SubsectorTVItemID }, " +
                                                        $@"DrogueNumber = { drogueRun.DrogueNumber }, " +
                                                        $@"DrogueType = (DrogueTypeEnum){ (int)drogueRun.DrogueType }, " +
                                                        $@"RunStartDateTime = { RunStartDateTime }, " +
                                                        $@"IsRisingTide = { drogueRun.IsRisingTide.ToString().ToLower() }, " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { drogueRun.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "EmailDistributionList":
                                        {
                                            EmailDistributionList emailDistributionList = dbTestDB.EmailDistributionLists.AsNoTracking().FirstOrDefault();
                                            if (emailDistributionList == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { emailDistributionList.EmailDistributionListID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string LastUpdateDate_UTC = $@"new DateTime({ emailDistributionList.LastUpdateDate_UTC.Year }, { emailDistributionList.LastUpdateDate_UTC.Month }, { emailDistributionList.LastUpdateDate_UTC.Day }, { emailDistributionList.LastUpdateDate_UTC.Hour }, { emailDistributionList.LastUpdateDate_UTC.Minute }, { emailDistributionList.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"EmailDistributionListID = { emailDistributionList.EmailDistributionListID }, " +
                                                        $@"ParentTVItemID = { emailDistributionList.ParentTVItemID }, " +
                                                        $@"Ordinal = { emailDistributionList.Ordinal }, " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { emailDistributionList.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "EmailDistributionListContact":
                                        {
                                            EmailDistributionListContact emailDistributionListContact = dbTestDB.EmailDistributionListContacts.AsNoTracking().FirstOrDefault();
                                            if (emailDistributionListContact == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { emailDistributionListContact.EmailDistributionListContactID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string LastUpdateDate_UTC = $@"new DateTime({ emailDistributionListContact.LastUpdateDate_UTC.Year }, { emailDistributionListContact.LastUpdateDate_UTC.Month }, { emailDistributionListContact.LastUpdateDate_UTC.Day }, { emailDistributionListContact.LastUpdateDate_UTC.Hour }, { emailDistributionListContact.LastUpdateDate_UTC.Minute }, { emailDistributionListContact.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"EmailDistributionListContactID = { emailDistributionListContact.EmailDistributionListContactID }, " +
                                                        $@"EmailDistributionListID = { emailDistributionListContact.EmailDistributionListID }, " +
                                                        $@"IsCC = { emailDistributionListContact.IsCC.ToString().ToLower() }, " +
                                                        $@"Name = ""{ emailDistributionListContact.Name }"", " +
                                                        $@"Email = ""{ emailDistributionListContact.Email }"", " +
                                                        $@"CMPRainfallSeasonal = { emailDistributionListContact.CMPRainfallSeasonal.ToString().ToLower() }, " +
                                                        $@"CMPWastewater = { emailDistributionListContact.CMPWastewater.ToString().ToLower() }, " +
                                                        $@"EmergencyWeather = { emailDistributionListContact.EmergencyWeather.ToString().ToLower() }, " +
                                                        $@"EmergencyWastewater = { emailDistributionListContact.EmergencyWastewater.ToString().ToLower() }, " +
                                                        $@"ReopeningAllTypes = { emailDistributionListContact.ReopeningAllTypes.ToString().ToLower() }, " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { emailDistributionListContact.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "HydrometricSite":
                                        {
                                            HydrometricSite hydrometricSite = dbTestDB.HydrometricSites.AsNoTracking().FirstOrDefault();
                                            if (hydrometricSite == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { hydrometricSite.HydrometricSiteID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string FedSiteNumber = hydrometricSite.FedSiteNumber == null ? "null" : hydrometricSite.FedSiteNumber.ToString();
                                                    string QuebecSiteNumber = hydrometricSite.QuebecSiteNumber == null ? "null" : hydrometricSite.QuebecSiteNumber.ToString();
                                                    string Description = hydrometricSite.Description == null ? "null" : hydrometricSite.Description.ToString();
                                                    string Elevation_m = hydrometricSite.Elevation_m == null ? "null" : hydrometricSite.Elevation_m.ToString();
                                                    string StartDate_Local = hydrometricSite.StartDate_Local == null ? "null" : $@"new DateTime({ ((DateTime)hydrometricSite.StartDate_Local).Year }, { ((DateTime)hydrometricSite.StartDate_Local).Month }, { ((DateTime)hydrometricSite.StartDate_Local).Day }, { ((DateTime)hydrometricSite.StartDate_Local).Hour }, { ((DateTime)hydrometricSite.StartDate_Local).Minute }, { ((DateTime)hydrometricSite.StartDate_Local).Second })";
                                                    string EndDate_Local = hydrometricSite.EndDate_Local == null ? "null" : $@"new DateTime({ ((DateTime)hydrometricSite.EndDate_Local).Year }, { ((DateTime)hydrometricSite.EndDate_Local).Month }, { ((DateTime)hydrometricSite.EndDate_Local).Day }, { ((DateTime)hydrometricSite.EndDate_Local).Hour }, { ((DateTime)hydrometricSite.EndDate_Local).Minute }, { ((DateTime)hydrometricSite.EndDate_Local).Second })";
                                                    string TimeOffset_hour = hydrometricSite.TimeOffset_hour == null ? "null" : hydrometricSite.TimeOffset_hour.ToString();
                                                    string DrainageArea_km2 = hydrometricSite.DrainageArea_km2 == null ? "null" : hydrometricSite.DrainageArea_km2.ToString();
                                                    string IsNatural = hydrometricSite.IsNatural == null ? "null" : hydrometricSite.IsNatural.ToString().ToLower();
                                                    string IsActive = hydrometricSite.IsActive == null ? "null" : hydrometricSite.IsActive.ToString().ToLower();
                                                    string Sediment = hydrometricSite.Sediment == null ? "null" : hydrometricSite.Sediment.ToString().ToLower();
                                                    string RHBN = hydrometricSite.RHBN == null ? "null" : hydrometricSite.RHBN.ToString().ToLower();
                                                    string RealTime = hydrometricSite.RealTime == null ? "null" : hydrometricSite.RealTime.ToString().ToLower();
                                                    string HasDischarge = hydrometricSite.HasDischarge == null ? "null" : hydrometricSite.HasDischarge.ToString().ToLower();
                                                    string HasLevel = hydrometricSite.HasLevel == null ? "null" : hydrometricSite.HasLevel.ToString().ToLower();
                                                    string HasRatingCurve = hydrometricSite.HasRatingCurve == null ? "null" : hydrometricSite.HasRatingCurve.ToString().ToLower();
                                                    string LastUpdateDate_UTC = $@"new DateTime({ hydrometricSite.LastUpdateDate_UTC.Year }, { hydrometricSite.LastUpdateDate_UTC.Month }, { hydrometricSite.LastUpdateDate_UTC.Day }, { hydrometricSite.LastUpdateDate_UTC.Hour }, { hydrometricSite.LastUpdateDate_UTC.Minute }, { hydrometricSite.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"HydrometricSiteID = { hydrometricSite.HydrometricSiteID }, " +
                                                        $@"HydrometricSiteTVItemID = { hydrometricSite.HydrometricSiteTVItemID }, " +
                                                        $@"FedSiteNumber = ""{ FedSiteNumber }"", " +
                                                        $@"QuebecSiteNumber = ""{ QuebecSiteNumber }"", " +
                                                        $@"HydrometricSiteName = ""{ hydrometricSite.HydrometricSiteName }"", " +
                                                        $@"Description = ""{ Description }"", " +
                                                        $@"Province = ""{ hydrometricSite.Province }"", " +
                                                        $@"Elevation_m = { Elevation_m }, " +
                                                        $@"StartDate_Local = { StartDate_Local }, " +
                                                        $@"EndDate_Local = { EndDate_Local }, " +
                                                        $@"TimeOffset_hour = { TimeOffset_hour }D, " +
                                                        $@"DrainageArea_km2 = { DrainageArea_km2 }, " +
                                                        $@"IsNatural = { IsNatural }, " +
                                                        $@"IsActive = { IsActive }, " +
                                                        $@"Sediment = { Sediment }, " +
                                                        $@"RHBN = { RHBN }, " +
                                                        $@"RealTime = { RealTime }, " +
                                                        $@"HasDischarge = { HasDischarge }, " +
                                                        $@"HasLevel = { HasLevel }, " +
                                                        $@"HasRatingCurve = { HasRatingCurve }, " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { hydrometricSite.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "Infrastructure":
                                        {
                                            Infrastructure infrastructure = dbTestDB.Infrastructures.AsNoTracking().FirstOrDefault();
                                            if (infrastructure == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { infrastructure.InfrastructureID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string PrismID = infrastructure.PrismID == null ? "null" : infrastructure.PrismID.ToString();
                                                    string TPID = infrastructure.TPID == null ? "null" : infrastructure.TPID.ToString();
                                                    string LSID = infrastructure.LSID == null ? "null" : infrastructure.LSID.ToString();
                                                    string SiteID = infrastructure.SiteID == null ? "null" : infrastructure.SiteID.ToString();
                                                    string Site = infrastructure.Site == null ? "null" : infrastructure.Site.ToString();
                                                    string InfrastructureCategory = infrastructure.InfrastructureCategory == null ? "null" : infrastructure.InfrastructureCategory.ToString();
                                                    string InfrastructureType = infrastructure.InfrastructureType == null ? "null" : "(InfrastructureTypeEnum)" + ((int)infrastructure.InfrastructureType).ToString();
                                                    string FacilityType = infrastructure.FacilityType == null ? "null" : "(FacilityTypeEnum)" + ((int)infrastructure.FacilityType).ToString();
                                                    string HasBackupPower = infrastructure.HasBackupPower == null ? "null" : infrastructure.HasBackupPower.ToString().ToLower();
                                                    string IsMechanicallyAerated = infrastructure.IsMechanicallyAerated == null ? "null" : infrastructure.IsMechanicallyAerated.ToString().ToLower();
                                                    string NumberOfCells = infrastructure.NumberOfCells == null ? "null" : infrastructure.NumberOfCells.ToString();
                                                    string NumberOfAeratedCells = infrastructure.NumberOfAeratedCells == null ? "null" : infrastructure.NumberOfAeratedCells.ToString();
                                                    string AerationType = infrastructure.AerationType == null ? "null" : "(AerationTypeEnum)" + ((int)infrastructure.AerationType).ToString();
                                                    string PreliminaryTreatmentType = infrastructure.PreliminaryTreatmentType == null ? "null" : "(PreliminaryTreatmentTypeEnum)" + ((int)infrastructure.PreliminaryTreatmentType).ToString();
                                                    string PrimaryTreatmentType = infrastructure.PrimaryTreatmentType == null ? "null" : "(PrimaryTreatmentTypeEnum)" + ((int)infrastructure.PrimaryTreatmentType).ToString();
                                                    string SecondaryTreatmentType = infrastructure.SecondaryTreatmentType == null ? "null" : "(SecondaryTreatmentTypeEnum)" + ((int)infrastructure.SecondaryTreatmentType).ToString();
                                                    string TertiaryTreatmentType = infrastructure.TertiaryTreatmentType == null ? "null" : "(TertiaryTreatmentTypeEnum)" + ((int)infrastructure.TertiaryTreatmentType).ToString();
                                                    string TreatmentType = infrastructure.TreatmentType == null ? "null" : "(TreatmentTypeEnum)" + ((int)infrastructure.TreatmentType).ToString();
                                                    string DisinfectionType = infrastructure.DisinfectionType == null ? "null" : "(DisinfectionTypeEnum)" + ((int)infrastructure.DisinfectionType).ToString();
                                                    string CollectionSystemType = infrastructure.CollectionSystemType == null ? "null" : "(CollectionSystemTypeEnum)" + ((int)infrastructure.CollectionSystemType).ToString();
                                                    string AlarmSystemType = infrastructure.AlarmSystemType == null ? "null" : "(AlarmSystemTypeEnum)" + ((int)infrastructure.AlarmSystemType).ToString();
                                                    string DesignFlow_m3_day = infrastructure.DesignFlow_m3_day == null ? "null" : infrastructure.DesignFlow_m3_day.ToString();
                                                    string AverageFlow_m3_day = infrastructure.AverageFlow_m3_day == null ? "null" : infrastructure.AverageFlow_m3_day.ToString();
                                                    string PeakFlow_m3_day = infrastructure.PeakFlow_m3_day == null ? "null" : infrastructure.PeakFlow_m3_day.ToString();
                                                    string PopServed = infrastructure.PopServed == null ? "null" : infrastructure.PopServed.ToString();
                                                    string CanOverflow = infrastructure.CanOverflow == null ? "null" : infrastructure.CanOverflow.ToString().ToLower();
                                                    string ValveType = infrastructure.ValveType == null ? "null" : "(ValveTypeEnum)" + ((int)infrastructure.ValveType).ToString();
                                                    string PercFlowOfTotal = infrastructure.PercFlowOfTotal == null ? "null" : infrastructure.PercFlowOfTotal.ToString();
                                                    string TimeOffset_hour = infrastructure.TimeOffset_hour == null ? "null" : infrastructure.TimeOffset_hour.ToString();
                                                    string TempCatchAllRemoveLater = infrastructure.TempCatchAllRemoveLater == null ? "null" : infrastructure.TempCatchAllRemoveLater.ToString();
                                                    string AverageDepth_m = infrastructure.AverageDepth_m == null ? "null" : infrastructure.AverageDepth_m.ToString();
                                                    string NumberOfPorts = infrastructure.NumberOfPorts == null ? "null" : infrastructure.NumberOfPorts.ToString();
                                                    string PortDiameter_m = infrastructure.PortDiameter_m == null ? "null" : infrastructure.PortDiameter_m.ToString();
                                                    string PortSpacing_m = infrastructure.PortSpacing_m == null ? "null" : infrastructure.PortSpacing_m.ToString();
                                                    string PortElevation_m = infrastructure.PortElevation_m == null ? "null" : infrastructure.PortElevation_m.ToString();
                                                    string VerticalAngle_deg = infrastructure.VerticalAngle_deg == null ? "null" : infrastructure.VerticalAngle_deg.ToString();
                                                    string HorizontalAngle_deg = infrastructure.HorizontalAngle_deg == null ? "null" : infrastructure.HorizontalAngle_deg.ToString();
                                                    string DecayRate_per_day = infrastructure.DecayRate_per_day == null ? "null" : infrastructure.DecayRate_per_day.ToString();
                                                    string NearFieldVelocity_m_s = infrastructure.NearFieldVelocity_m_s == null ? "null" : infrastructure.NearFieldVelocity_m_s.ToString();
                                                    string FarFieldVelocity_m_s = infrastructure.FarFieldVelocity_m_s == null ? "null" : infrastructure.FarFieldVelocity_m_s.ToString();
                                                    string ReceivingWaterSalinity_PSU = infrastructure.ReceivingWaterSalinity_PSU == null ? "null" : infrastructure.ReceivingWaterSalinity_PSU.ToString();
                                                    string ReceivingWaterTemperature_C = infrastructure.ReceivingWaterTemperature_C == null ? "null" : infrastructure.ReceivingWaterTemperature_C.ToString();
                                                    string ReceivingWater_MPN_per_100ml = infrastructure.ReceivingWater_MPN_per_100ml == null ? "null" : infrastructure.ReceivingWater_MPN_per_100ml.ToString();
                                                    string DistanceFromShore_m = infrastructure.DistanceFromShore_m == null ? "null" : infrastructure.DistanceFromShore_m.ToString();
                                                    string SeeOtherMunicipalityTVItemID = infrastructure.SeeOtherMunicipalityTVItemID == null ? "null" : infrastructure.SeeOtherMunicipalityTVItemID.ToString();
                                                    string CivicAddressTVItemID = infrastructure.CivicAddressTVItemID == null ? "null" : infrastructure.CivicAddressTVItemID.ToString();
                                                    string LastUpdateDate_UTC = $@"new DateTime({ infrastructure.LastUpdateDate_UTC.Year }, { infrastructure.LastUpdateDate_UTC.Month }, { infrastructure.LastUpdateDate_UTC.Day }, { infrastructure.LastUpdateDate_UTC.Hour }, { infrastructure.LastUpdateDate_UTC.Minute }, { infrastructure.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"InfrastructureID = { infrastructure.InfrastructureID }, " +
                                                        $@"InfrastructureTVItemID = { infrastructure.InfrastructureTVItemID }, " +
                                                        $@"PrismID = { PrismID }, " +
                                                        $@"TPID = { TPID }, " +
                                                        $@"LSID = { LSID }, " +
                                                        $@"SiteID = { SiteID }, " +
                                                        $@"Site = { Site }, " +
                                                        $@"InfrastructureCategory = ""{ InfrastructureCategory }"", " +
                                                        $@"InfrastructureType = { InfrastructureType }, " +
                                                        $@"FacilityType = { FacilityType }, " +
                                                        $@"HasBackupPower = { HasBackupPower }, " +
                                                        $@"IsMechanicallyAerated = { IsMechanicallyAerated }, " +
                                                        $@"NumberOfCells = { NumberOfCells }, " +
                                                        $@"NumberOfAeratedCells = { NumberOfAeratedCells }, " +
                                                        $@"AerationType = { AerationType }, " +
                                                        $@"PreliminaryTreatmentType = { PreliminaryTreatmentType }, " +
                                                        $@"PrimaryTreatmentType = { PrimaryTreatmentType }, " +
                                                        $@"SecondaryTreatmentType = { SecondaryTreatmentType }, " +
                                                        $@"TertiaryTreatmentType = { TertiaryTreatmentType }, " +
                                                        $@"TreatmentType = { TreatmentType }, " +
                                                        $@"DisinfectionType = { DisinfectionType }, " +
                                                        $@"CollectionSystemType = { CollectionSystemType }, " +
                                                        $@"AlarmSystemType = { AlarmSystemType }, " +
                                                        $@"DesignFlow_m3_day = { DesignFlow_m3_day }, " +
                                                        $@"AverageFlow_m3_day = { AverageFlow_m3_day }, " +
                                                        $@"PeakFlow_m3_day = { PeakFlow_m3_day }, " +
                                                        $@"PopServed = { PopServed }, " +
                                                        $@"CanOverflow = { CanOverflow }, " +
                                                        $@"ValveType = { ValveType }, " +
                                                        $@"PercFlowOfTotal = { PercFlowOfTotal }, " +
                                                        $@"TimeOffset_hour = { TimeOffset_hour }, " +
                                                        $@"TempCatchAllRemoveLater = ""{ TempCatchAllRemoveLater.Replace("\r\n", "---") }"", " +
                                                        $@"AverageDepth_m = { AverageDepth_m }, " +
                                                        $@"NumberOfPorts = { NumberOfPorts }, " +
                                                        $@"PortDiameter_m = { PortDiameter_m }, " +
                                                        $@"PortSpacing_m = { PortSpacing_m }, " +
                                                        $@"PortElevation_m = { PortElevation_m }, " +
                                                        $@"VerticalAngle_deg = { VerticalAngle_deg }, " +
                                                        $@"HorizontalAngle_deg = { HorizontalAngle_deg }, " +
                                                        $@"DecayRate_per_day = { DecayRate_per_day }, " +
                                                        $@"NearFieldVelocity_m_s = { NearFieldVelocity_m_s }, " +
                                                        $@"FarFieldVelocity_m_s = { FarFieldVelocity_m_s }, " +
                                                        $@"ReceivingWaterSalinity_PSU = { ReceivingWaterSalinity_PSU }, " +
                                                        $@"ReceivingWaterTemperature_C = { ReceivingWaterTemperature_C }, " +
                                                        $@"ReceivingWater_MPN_per_100ml = { ReceivingWater_MPN_per_100ml }, " +
                                                        $@"DistanceFromShore_m = { DistanceFromShore_m }, " +
                                                        $@"SeeOtherMunicipalityTVItemID = { SeeOtherMunicipalityTVItemID }, " +
                                                        $@"CivicAddressTVItemID = { CivicAddressTVItemID }, " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { infrastructure.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "LabSheet":
                                        {
                                            LabSheet labSheet = dbTestDB.LabSheets.AsNoTracking().FirstOrDefault();
                                            if (labSheet == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { labSheet.LabSheetID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string MWQMRunTVItemID = labSheet.MWQMRunTVItemID == null ? "null" : labSheet.MWQMRunTVItemID.ToString();
                                                    string FileLastModifiedDate_Local = $@"new DateTime({ labSheet.FileLastModifiedDate_Local.Year }, { labSheet.FileLastModifiedDate_Local.Month }, { labSheet.FileLastModifiedDate_Local.Day }, { labSheet.FileLastModifiedDate_Local.Hour }, { labSheet.FileLastModifiedDate_Local.Minute }, { labSheet.FileLastModifiedDate_Local.Second })";
                                                    string AcceptedOrRejectedByContactTVItemID = labSheet.AcceptedOrRejectedByContactTVItemID == null ? "null" : labSheet.AcceptedOrRejectedByContactTVItemID.ToString();
                                                    string AcceptedOrRejectedDateTime = labSheet.AcceptedOrRejectedDateTime == null ? "null" : $@"new DateTime({ ((DateTime)labSheet.AcceptedOrRejectedDateTime).Year }, { ((DateTime)labSheet.AcceptedOrRejectedDateTime).Month }, { ((DateTime)labSheet.AcceptedOrRejectedDateTime).Day }, { ((DateTime)labSheet.AcceptedOrRejectedDateTime).Hour }, { ((DateTime)labSheet.AcceptedOrRejectedDateTime).Minute }, { ((DateTime)labSheet.AcceptedOrRejectedDateTime).Second })";
                                                    string LastUpdateDate_UTC = $@"new DateTime({ labSheet.LastUpdateDate_UTC.Year }, { labSheet.LastUpdateDate_UTC.Month }, { labSheet.LastUpdateDate_UTC.Day }, { labSheet.LastUpdateDate_UTC.Hour }, { labSheet.LastUpdateDate_UTC.Minute }, { labSheet.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"LabSheetID = { labSheet.LabSheetID }, " +
                                                        $@"OtherServerLabSheetID = { labSheet.OtherServerLabSheetID }, " +
                                                        $@"SamplingPlanID = { labSheet.SamplingPlanID }, " +
                                                        $@"SamplingPlanName = @""{ labSheet.SamplingPlanName }"", " +
                                                        $@"Year = { labSheet.Year }, " +
                                                        $@"Month = { labSheet.Month }, " +
                                                        $@"Day = { labSheet.Day }, " +
                                                        $@"RunNumber = { labSheet.RunNumber }, " +
                                                        $@"SubsectorTVItemID = { labSheet.SubsectorTVItemID }, " +
                                                        $@"MWQMRunTVItemID = { MWQMRunTVItemID }, " +
                                                        $@"SamplingPlanType = (SamplingPlanTypeEnum){ (int)labSheet.SamplingPlanType }, " +
                                                        $@"SampleType = (SampleTypeEnum){ (int)labSheet.SampleType }, " +
                                                        $@"LabSheetType = (LabSheetTypeEnum){ (int)labSheet.LabSheetType }, " +
                                                        $@"LabSheetStatus = (LabSheetStatusEnum){ (int)labSheet.LabSheetStatus }, " +
                                                        $@"FileName = @""{ labSheet.FileName }"", " +
                                                        $@"FileLastModifiedDate_Local = { FileLastModifiedDate_Local }, " +
                                                        $@"FileContent = """", " +
                                                        $@"AcceptedOrRejectedByContactTVItemID = { AcceptedOrRejectedByContactTVItemID }, " +
                                                        $@"AcceptedOrRejectedDateTime = { AcceptedOrRejectedDateTime }, " +
                                                        $@"RejectReason = ""{ labSheet.RejectReason }"", " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { labSheet.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "LabSheetDetail":
                                        {
                                            LabSheetDetail labSheetDetail = dbTestDB.LabSheetDetails.AsNoTracking().FirstOrDefault();
                                            if (labSheetDetail == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { labSheetDetail.LabSheetDetailID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string RunDate = labSheetDetail.RunDate == null ? "null" : $@"new DateTime({ ((DateTime)labSheetDetail.RunDate).Year }, { ((DateTime)labSheetDetail.RunDate).Month }, { ((DateTime)labSheetDetail.RunDate).Day }, { ((DateTime)labSheetDetail.RunDate).Hour }, { ((DateTime)labSheetDetail.RunDate).Minute }, { ((DateTime)labSheetDetail.RunDate).Second })";
                                                    string WaterBathCount = labSheetDetail.WaterBathCount == null ? "null" : labSheetDetail.WaterBathCount.ToString();
                                                    string IncubationBath1StartTime = labSheetDetail.IncubationBath1StartTime == null ? "null" : $@"new DateTime({ ((DateTime)labSheetDetail.IncubationBath1StartTime).Year }, { ((DateTime)labSheetDetail.IncubationBath1StartTime).Month }, { ((DateTime)labSheetDetail.IncubationBath1StartTime).Day }, { ((DateTime)labSheetDetail.IncubationBath1StartTime).Hour }, { ((DateTime)labSheetDetail.IncubationBath1StartTime).Minute }, { ((DateTime)labSheetDetail.IncubationBath1StartTime).Second })";
                                                    string IncubationBath2StartTime = labSheetDetail.IncubationBath2StartTime == null ? "null" : $@"new DateTime({ ((DateTime)labSheetDetail.IncubationBath2StartTime).Year }, { ((DateTime)labSheetDetail.IncubationBath2StartTime).Month }, { ((DateTime)labSheetDetail.IncubationBath2StartTime).Day }, { ((DateTime)labSheetDetail.IncubationBath2StartTime).Hour }, { ((DateTime)labSheetDetail.IncubationBath2StartTime).Minute }, { ((DateTime)labSheetDetail.IncubationBath2StartTime).Second })";
                                                    string IncubationBath3StartTime = labSheetDetail.IncubationBath3StartTime == null ? "null" : $@"new DateTime({ ((DateTime)labSheetDetail.IncubationBath3StartTime).Year }, { ((DateTime)labSheetDetail.IncubationBath3StartTime).Month }, { ((DateTime)labSheetDetail.IncubationBath3StartTime).Day }, { ((DateTime)labSheetDetail.IncubationBath3StartTime).Hour }, { ((DateTime)labSheetDetail.IncubationBath3StartTime).Minute }, { ((DateTime)labSheetDetail.IncubationBath3StartTime).Second })";
                                                    string IncubationBath1EndTime = labSheetDetail.IncubationBath1EndTime == null ? "null" : $@"new DateTime({ ((DateTime)labSheetDetail.IncubationBath1EndTime).Year }, { ((DateTime)labSheetDetail.IncubationBath1EndTime).Month }, { ((DateTime)labSheetDetail.IncubationBath1EndTime).Day }, { ((DateTime)labSheetDetail.IncubationBath1EndTime).Hour }, { ((DateTime)labSheetDetail.IncubationBath1EndTime).Minute }, { ((DateTime)labSheetDetail.IncubationBath1EndTime).Second })";
                                                    string IncubationBath2EndTime = labSheetDetail.IncubationBath2EndTime == null ? "null" : $@"new DateTime({ ((DateTime)labSheetDetail.IncubationBath2EndTime).Year }, { ((DateTime)labSheetDetail.IncubationBath2EndTime).Month }, { ((DateTime)labSheetDetail.IncubationBath2EndTime).Day }, { ((DateTime)labSheetDetail.IncubationBath2EndTime).Hour }, { ((DateTime)labSheetDetail.IncubationBath2EndTime).Minute }, { ((DateTime)labSheetDetail.IncubationBath2EndTime).Second })";
                                                    string IncubationBath3EndTime = labSheetDetail.IncubationBath3EndTime == null ? "null" : $@"new DateTime({ ((DateTime)labSheetDetail.IncubationBath3EndTime).Year }, { ((DateTime)labSheetDetail.IncubationBath3EndTime).Month }, { ((DateTime)labSheetDetail.IncubationBath3EndTime).Day }, { ((DateTime)labSheetDetail.IncubationBath3EndTime).Hour }, { ((DateTime)labSheetDetail.IncubationBath3EndTime).Minute }, { ((DateTime)labSheetDetail.IncubationBath3EndTime).Second })";
                                                    string IncubationBath1TimeCalculated_minutes = labSheetDetail.IncubationBath1TimeCalculated_minutes == null ? "null" : labSheetDetail.IncubationBath1TimeCalculated_minutes.ToString();
                                                    string IncubationBath2TimeCalculated_minutes = labSheetDetail.IncubationBath2TimeCalculated_minutes == null ? "null" : labSheetDetail.IncubationBath2TimeCalculated_minutes.ToString();
                                                    string IncubationBath3TimeCalculated_minutes = labSheetDetail.IncubationBath3TimeCalculated_minutes == null ? "null" : labSheetDetail.IncubationBath3TimeCalculated_minutes.ToString();
                                                    string TCField1 = labSheetDetail.TCField1 == null ? "null" : labSheetDetail.TCField1.ToString();
                                                    string TCLab1 = labSheetDetail.TCLab1 == null ? "null" : labSheetDetail.TCLab1.ToString();
                                                    string TCField2 = labSheetDetail.TCField2 == null ? "null" : labSheetDetail.TCField2.ToString();
                                                    string TCLab2 = labSheetDetail.TCLab2 == null ? "null" : labSheetDetail.TCLab2.ToString();
                                                    string TCFirst = labSheetDetail.TCFirst == null ? "null" : labSheetDetail.TCFirst.ToString();
                                                    string TCAverage = labSheetDetail.TCAverage == null ? "null" : labSheetDetail.TCAverage.ToString();
                                                    string ControlLot = labSheetDetail.ControlLot == null ? "null" : labSheetDetail.ControlLot.ToString();
                                                    string Positive35 = labSheetDetail.Positive35 == null ? "null" : labSheetDetail.Positive35.ToString();
                                                    string NonTarget35 = labSheetDetail.NonTarget35 == null ? "null" : labSheetDetail.NonTarget35.ToString();
                                                    string Negative35 = labSheetDetail.Negative35 == null ? "null" : labSheetDetail.Negative35.ToString();
                                                    string Bath1Positive44_5 = labSheetDetail.Bath1Positive44_5 == null ? "null" : labSheetDetail.Bath1Positive44_5.ToString();
                                                    string Bath2Positive44_5 = labSheetDetail.Bath2Positive44_5 == null ? "null" : labSheetDetail.Bath2Positive44_5.ToString();
                                                    string Bath3Positive44_5 = labSheetDetail.Bath3Positive44_5 == null ? "null" : labSheetDetail.Bath3Positive44_5.ToString();
                                                    string Bath1NonTarget44_5 = labSheetDetail.Bath1NonTarget44_5 == null ? "null" : labSheetDetail.Bath1NonTarget44_5.ToString();
                                                    string Bath2NonTarget44_5 = labSheetDetail.Bath2NonTarget44_5 == null ? "null" : labSheetDetail.Bath2NonTarget44_5.ToString();
                                                    string Bath3NonTarget44_5 = labSheetDetail.Bath3NonTarget44_5 == null ? "null" : labSheetDetail.Bath3NonTarget44_5.ToString();
                                                    string Bath1Negative44_5 = labSheetDetail.Bath1Negative44_5 == null ? "null" : labSheetDetail.Bath1Negative44_5.ToString();
                                                    string Bath2Negative44_5 = labSheetDetail.Bath2Negative44_5 == null ? "null" : labSheetDetail.Bath2Negative44_5.ToString();
                                                    string Bath3Negative44_5 = labSheetDetail.Bath3Negative44_5 == null ? "null" : labSheetDetail.Bath3Negative44_5.ToString();
                                                    string Blank35 = labSheetDetail.Blank35 == null ? "null" : labSheetDetail.Blank35.ToString();
                                                    string Bath1Blank44_5 = labSheetDetail.Bath1Blank44_5 == null ? "null" : labSheetDetail.Bath1Blank44_5.ToString();
                                                    string Bath2Blank44_5 = labSheetDetail.Bath2Blank44_5 == null ? "null" : labSheetDetail.Bath2Blank44_5.ToString();
                                                    string Bath3Blank44_5 = labSheetDetail.Bath3Blank44_5 == null ? "null" : labSheetDetail.Bath3Blank44_5.ToString();
                                                    string Lot35 = labSheetDetail.Lot35 == null ? "null" : labSheetDetail.Lot35.ToString();
                                                    string Lot44_5 = labSheetDetail.Lot44_5 == null ? "null" : labSheetDetail.Lot44_5.ToString();
                                                    string Weather = labSheetDetail.Weather == null ? "null" : labSheetDetail.Weather.ToString().Replace("\r\n", "---");
                                                    string RunComment = labSheetDetail.RunComment == null ? "null" : labSheetDetail.RunComment.ToString().Replace("\r\n", "---");
                                                    string RunWeatherComment = labSheetDetail.RunWeatherComment == null ? "null" : labSheetDetail.RunWeatherComment.ToString().Replace("\r\n", "---");
                                                    string SampleBottleLotNumber = labSheetDetail.SampleBottleLotNumber == null ? "null" : labSheetDetail.SampleBottleLotNumber.ToString();
                                                    string SalinitiesReadBy = labSheetDetail.SalinitiesReadBy == null ? "null" : labSheetDetail.SalinitiesReadBy.ToString();
                                                    string SalinitiesReadDate = labSheetDetail.SalinitiesReadDate == null ? "null" : $@"new DateTime({ ((DateTime)labSheetDetail.SalinitiesReadDate).Year }, { ((DateTime)labSheetDetail.SalinitiesReadDate).Month }, { ((DateTime)labSheetDetail.SalinitiesReadDate).Day }, { ((DateTime)labSheetDetail.SalinitiesReadDate).Hour }, { ((DateTime)labSheetDetail.SalinitiesReadDate).Minute }, { ((DateTime)labSheetDetail.SalinitiesReadDate).Second })";
                                                    string ResultsReadBy = labSheetDetail.ResultsReadBy == null ? "null" : labSheetDetail.ResultsReadBy.ToString();
                                                    string ResultsReadDate = labSheetDetail.ResultsReadDate == null ? "null" : $@"new DateTime({ ((DateTime)labSheetDetail.ResultsReadDate).Year }, { ((DateTime)labSheetDetail.ResultsReadDate).Month }, { ((DateTime)labSheetDetail.ResultsReadDate).Day }, { ((DateTime)labSheetDetail.ResultsReadDate).Hour }, { ((DateTime)labSheetDetail.ResultsReadDate).Minute }, { ((DateTime)labSheetDetail.ResultsReadDate).Second })";
                                                    string ResultsRecordedBy = labSheetDetail.ResultsRecordedBy == null ? "null" : labSheetDetail.ResultsRecordedBy.ToString();
                                                    string ResultsRecordedDate = labSheetDetail.ResultsRecordedDate == null ? "null" : $@"new DateTime({ ((DateTime)labSheetDetail.ResultsRecordedDate).Year }, { ((DateTime)labSheetDetail.ResultsRecordedDate).Month }, { ((DateTime)labSheetDetail.ResultsRecordedDate).Day }, { ((DateTime)labSheetDetail.ResultsRecordedDate).Hour }, { ((DateTime)labSheetDetail.ResultsRecordedDate).Minute }, { ((DateTime)labSheetDetail.ResultsRecordedDate).Second })";
                                                    string DailyDuplicateRLog = labSheetDetail.DailyDuplicateRLog == null ? "null" : labSheetDetail.DailyDuplicateRLog.ToString();
                                                    string DailyDuplicatePrecisionCriteria = labSheetDetail.DailyDuplicatePrecisionCriteria == null ? "null" : labSheetDetail.DailyDuplicatePrecisionCriteria.ToString();
                                                    string DailyDuplicateAcceptable = labSheetDetail.DailyDuplicateAcceptable == null ? "null" : labSheetDetail.DailyDuplicateAcceptable.ToString().ToLower();
                                                    string IntertechDuplicateRLog = labSheetDetail.IntertechDuplicateRLog == null ? "null" : labSheetDetail.IntertechDuplicateRLog.ToString();
                                                    string IntertechDuplicatePrecisionCriteria = labSheetDetail.IntertechDuplicatePrecisionCriteria == null ? "null" : labSheetDetail.IntertechDuplicatePrecisionCriteria.ToString();
                                                    string IntertechDuplicateAcceptable = labSheetDetail.IntertechDuplicateAcceptable == null ? "null" : labSheetDetail.IntertechDuplicateAcceptable.ToString().ToLower();
                                                    string IntertechReadAcceptable = labSheetDetail.IntertechReadAcceptable == null ? "null" : labSheetDetail.IntertechReadAcceptable.ToString().ToLower();
                                                    string LastUpdateDate_UTC = $@"new DateTime({ labSheetDetail.LastUpdateDate_UTC.Year }, { labSheetDetail.LastUpdateDate_UTC.Month }, { labSheetDetail.LastUpdateDate_UTC.Day }, { labSheetDetail.LastUpdateDate_UTC.Hour }, { labSheetDetail.LastUpdateDate_UTC.Minute }, { labSheetDetail.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"LabSheetDetailID = { labSheetDetail.LabSheetDetailID }, " +
                                                        $@"LabSheetID = { labSheetDetail.LabSheetID }, " +
                                                        $@"SamplingPlanID = { labSheetDetail.SamplingPlanID }, " +
                                                        $@"SubsectorTVItemID = { labSheetDetail.SubsectorTVItemID }, " +
                                                        $@"Version = { labSheetDetail.Version }, " +
                                                        $@"RunDate = { RunDate }, " +
                                                        $@"Tides = @""{ labSheetDetail.Tides }"", " +
                                                        $@"SampleCrewInitials = ""{ labSheetDetail.SampleCrewInitials }"", " +
                                                        $@"WaterBathCount = { WaterBathCount }, " +
                                                        $@"IncubationBath1StartTime = { IncubationBath1StartTime }, " +
                                                        $@"IncubationBath2StartTime = { IncubationBath2StartTime }, " +
                                                        $@"IncubationBath3StartTime = { IncubationBath3StartTime }, " +
                                                        $@"IncubationBath1EndTime = { IncubationBath1EndTime }, " +
                                                        $@"IncubationBath2EndTime = { IncubationBath2EndTime }, " +
                                                        $@"IncubationBath3EndTime = { IncubationBath3EndTime }, " +
                                                        $@"IncubationBath1TimeCalculated_minutes = { IncubationBath1TimeCalculated_minutes }, " +
                                                        $@"IncubationBath2TimeCalculated_minutes = { IncubationBath2TimeCalculated_minutes }, " +
                                                        $@"IncubationBath3TimeCalculated_minutes = { IncubationBath3TimeCalculated_minutes }, " +
                                                        $@"WaterBath1 = ""{ labSheetDetail.WaterBath1 }"", " +
                                                        $@"WaterBath2 = ""{ labSheetDetail.WaterBath2 }"", " +
                                                        $@"WaterBath3 = ""{ labSheetDetail.WaterBath3 }"", " +
                                                        $@"TCField1 = { TCField1 }, " +
                                                        $@"TCLab1 = { TCLab1 }, " +
                                                        $@"TCField2 = { TCField2 }, " +
                                                        $@"TCLab2 = { TCLab2 }, " +
                                                        $@"TCFirst = { TCFirst }, " +
                                                        $@"TCAverage = { TCAverage }, " +
                                                        $@"ControlLot = ""{ ControlLot }"", " +
                                                        $@"Positive35 = ""{ Positive35 }"", " +
                                                        $@"NonTarget35 = ""{ NonTarget35 }"", " +
                                                        $@"Negative35 = ""{ Negative35 }"", " +
                                                        $@"Bath1Positive44_5 = ""{ Bath1Positive44_5 }"", " +
                                                        $@"Bath2Positive44_5 = ""{ Bath2Positive44_5 }"", " +
                                                        $@"Bath3Positive44_5 = ""{ Bath3Positive44_5 }"", " +
                                                        $@"Bath1NonTarget44_5 = ""{ Bath1NonTarget44_5 }"", " +
                                                        $@"Bath2NonTarget44_5 = ""{ Bath2NonTarget44_5 }"", " +
                                                        $@"Bath3NonTarget44_5 = ""{ Bath3NonTarget44_5 }"", " +
                                                        $@"Bath1Negative44_5 = ""{ Bath1Negative44_5 }"", " +
                                                        $@"Bath2Negative44_5 = ""{ Bath2Negative44_5 }"", " +
                                                        $@"Bath3Negative44_5 = ""{ Bath3Negative44_5 }"", " +
                                                        $@"Blank35 = { Blank35 }, " +
                                                        $@"Bath1Blank44_5 = ""{ Bath1Blank44_5 }"", " +
                                                        $@"Bath2Blank44_5 = ""{ Bath2Blank44_5 }"", " +
                                                        $@"Bath3Blank44_5 = ""{ Bath3Blank44_5 }"", " +
                                                        $@"Lot35 = ""{ Lot35 }"", " +
                                                        $@"Lot44_5 = ""{ Lot44_5 }"", " +
                                                        $@"Weather = ""{ Weather }"", " +
                                                        $@"RunComment = ""{ RunComment.Replace("\r\n", "---") }"", " +
                                                        $@"RunWeatherComment = ""{ RunWeatherComment.Replace("\r\n", "---") }"", " +
                                                        $@"SampleBottleLotNumber = ""{ SampleBottleLotNumber }"", " +
                                                        $@"SalinitiesReadBy = ""{ SalinitiesReadBy }"", " +
                                                        $@"SalinitiesReadDate = { SalinitiesReadDate }, " +
                                                        $@"ResultsReadBy = ""{ ResultsReadBy }"", " +
                                                        $@"ResultsReadDate = { ResultsReadDate }, " +
                                                        $@"ResultsRecordedBy = ""{ ResultsRecordedBy }"", " +
                                                        $@"ResultsRecordedDate = { ResultsRecordedDate }, " +
                                                        $@"DailyDuplicateRLog = { DailyDuplicateRLog }, " +
                                                        $@"DailyDuplicatePrecisionCriteria = { DailyDuplicatePrecisionCriteria }, " +
                                                        $@"DailyDuplicateAcceptable = { DailyDuplicateAcceptable }, " +
                                                        $@"IntertechDuplicateRLog = { IntertechDuplicateRLog }, " +
                                                        $@"IntertechDuplicatePrecisionCriteria = { IntertechDuplicatePrecisionCriteria }, " +
                                                        $@"IntertechDuplicateAcceptable = { IntertechDuplicateAcceptable }, " +
                                                        $@"IntertechReadAcceptable = { IntertechReadAcceptable }, " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { labSheetDetail.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "MapInfo":
                                        {
                                            MapInfo mapInfo = dbTestDB.MapInfos.AsNoTracking().FirstOrDefault();
                                            if (mapInfo == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mapInfo.MapInfoID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string LastUpdateDate_UTC = $@"new DateTime({ mapInfo.LastUpdateDate_UTC.Year }, { mapInfo.LastUpdateDate_UTC.Month }, { mapInfo.LastUpdateDate_UTC.Day }, { mapInfo.LastUpdateDate_UTC.Hour }, { mapInfo.LastUpdateDate_UTC.Minute }, { mapInfo.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"MapInfoID = { mapInfo.MapInfoID }, " +
                                                        $@"TVItemID = { mapInfo.TVItemID }, " +
                                                        $@"TVType = (TVTypeEnum){ (int)mapInfo.TVType }, " +
                                                        $@"LatMin = { mapInfo.LatMin }, " +
                                                        $@"LatMax = { mapInfo.LatMax }, " +
                                                        $@"LngMax = { mapInfo.LngMax }, " +
                                                        $@"MapInfoDrawType = (MapInfoDrawTypeEnum){ (int)mapInfo.MapInfoDrawType }, " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { mapInfo.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "MikeSource":
                                        {
                                            MikeSource mikeSource = dbTestDB.MikeSources.AsNoTracking().FirstOrDefault();
                                            if (mikeSource == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mikeSource.MikeSourceID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string HydrometricTVItemID = mikeSource.HydrometricTVItemID == null ? "null" : ((int)mikeSource.HydrometricTVItemID).ToString();
                                                    string DrainageArea_km2 = mikeSource.DrainageArea_km2 == null ? "null" : ((float)mikeSource.DrainageArea_km2).ToString();
                                                    string Factor = mikeSource.Factor == null ? "null" : ((float)mikeSource.Factor).ToString();
                                                    string LastUpdateDate_UTC = $@"new DateTime({ mikeSource.LastUpdateDate_UTC.Year }, { mikeSource.LastUpdateDate_UTC.Month }, { mikeSource.LastUpdateDate_UTC.Day }, { mikeSource.LastUpdateDate_UTC.Hour }, { mikeSource.LastUpdateDate_UTC.Minute }, { mikeSource.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"MikeSourceID = { mikeSource.MikeSourceID }, " +
                                                        $@"MikeSourceTVItemID = { mikeSource.MikeSourceTVItemID }, " +
                                                        $@"IsContinuous = { mikeSource.IsContinuous.ToString().ToLower() }, " +
                                                        $@"Include = { mikeSource.Include.ToString().ToLower() }, " +
                                                        $@"IsRiver = { mikeSource.IsRiver.ToString().ToLower() }, " +
                                                        $@"UseHydrometric = { mikeSource.UseHydrometric.ToString().ToLower() }, " +
                                                        $@"HydrometricTVItemID = { HydrometricTVItemID }, " +
                                                        $@"DrainageArea_km2 = { DrainageArea_km2 }, " +
                                                        $@"Factor = { Factor }, " +
                                                        $@"SourceNumberString = ""{ mikeSource.SourceNumberString }"", " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { mikeSource.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "MWQMAnalysisReportParameter":
                                        {
                                            MWQMAnalysisReportParameter mwqmAnalysisReportParameter = dbTestDB.MWQMAnalysisReportParameters.AsNoTracking().FirstOrDefault();
                                            if (mwqmAnalysisReportParameter == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string AnalysisReportYear = mwqmAnalysisReportParameter.AnalysisReportYear == null ? "null" : ((int)mwqmAnalysisReportParameter.AnalysisReportYear).ToString();
                                                    string ShowDataTypes = mwqmAnalysisReportParameter.ShowDataTypes == null ? "null" : mwqmAnalysisReportParameter.ShowDataTypes;
                                                    string ExcelTVFileTVItemID = mwqmAnalysisReportParameter.ExcelTVFileTVItemID == null ? "null" : ((int)mwqmAnalysisReportParameter.ExcelTVFileTVItemID).ToString();
                                                    string StartDate = $@"new DateTime({ mwqmAnalysisReportParameter.StartDate.Year }, { mwqmAnalysisReportParameter.StartDate.Month }, { mwqmAnalysisReportParameter.StartDate.Day }, { mwqmAnalysisReportParameter.StartDate.Hour }, { mwqmAnalysisReportParameter.StartDate.Minute }, { mwqmAnalysisReportParameter.StartDate.Second })";
                                                    string EndDate = $@"new DateTime({ mwqmAnalysisReportParameter.EndDate.Year }, { mwqmAnalysisReportParameter.EndDate.Month }, { mwqmAnalysisReportParameter.EndDate.Day }, { mwqmAnalysisReportParameter.EndDate.Hour }, { mwqmAnalysisReportParameter.EndDate.Minute }, { mwqmAnalysisReportParameter.EndDate.Second })";
                                                    string LastUpdateDate_UTC = $@"new DateTime({ mwqmAnalysisReportParameter.LastUpdateDate_UTC.Year }, { mwqmAnalysisReportParameter.LastUpdateDate_UTC.Month }, { mwqmAnalysisReportParameter.LastUpdateDate_UTC.Day }, { mwqmAnalysisReportParameter.LastUpdateDate_UTC.Hour }, { mwqmAnalysisReportParameter.LastUpdateDate_UTC.Minute }, { mwqmAnalysisReportParameter.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"MWQMAnalysisReportParameterID = { mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID }, " +
                                                        $@"SubsectorTVItemID = { mwqmAnalysisReportParameter.SubsectorTVItemID }, " +
                                                        $@"AnalysisName = ""{ mwqmAnalysisReportParameter.AnalysisName }"", " +
                                                        $@"AnalysisReportYear = { AnalysisReportYear }, " +
                                                        $@"StartDate = { StartDate }, " +
                                                        $@"EndDate = { EndDate }, " +
                                                        $@"AnalysisCalculationType = (AnalysisCalculationTypeEnum){ (int)mwqmAnalysisReportParameter.AnalysisCalculationType }, " +
                                                        $@"NumberOfRuns = { mwqmAnalysisReportParameter.NumberOfRuns }, " +
                                                        $@"FullYear = { mwqmAnalysisReportParameter.FullYear.ToString().ToLower() }, " +
                                                        $@"SalinityHighlightDeviationFromAverage = { mwqmAnalysisReportParameter.SalinityHighlightDeviationFromAverage }, " +
                                                        $@"ShortRangeNumberOfDays = { mwqmAnalysisReportParameter.ShortRangeNumberOfDays }, " +
                                                        $@"MidRangeNumberOfDays = { mwqmAnalysisReportParameter.MidRangeNumberOfDays }, " +
                                                        $@"DryLimit24h = { mwqmAnalysisReportParameter.DryLimit24h }, " +
                                                        $@"DryLimit48h = { mwqmAnalysisReportParameter.DryLimit48h }, " +
                                                        $@"DryLimit72h = { mwqmAnalysisReportParameter.DryLimit72h }, " +
                                                        $@"DryLimit96h = { mwqmAnalysisReportParameter.DryLimit96h }, " +
                                                        $@"WetLimit24h = { mwqmAnalysisReportParameter.WetLimit24h }, " +
                                                        $@"WetLimit48h = { mwqmAnalysisReportParameter.WetLimit48h }, " +
                                                        $@"WetLimit72h = { mwqmAnalysisReportParameter.WetLimit72h }, " +
                                                        $@"WetLimit96h = { mwqmAnalysisReportParameter.WetLimit96h }, " +
                                                        $@"RunsToOmit = ""{ mwqmAnalysisReportParameter.RunsToOmit.Replace("\r\n", "---") }"", " +
                                                        $@"ShowDataTypes = ""{ ShowDataTypes }"", " +
                                                        $@"ExcelTVFileTVItemID = { ExcelTVFileTVItemID }, " +
                                                        $@"Command = { mwqmAnalysisReportParameter.Command }, " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { mwqmAnalysisReportParameter.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "MWQMRun":
                                        {
                                            MWQMRun mwqmRun = dbTestDB.MWQMRuns.AsNoTracking().FirstOrDefault();
                                            if (mwqmRun == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mwqmRun.MWQMRunID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string DateTime_Local = $@"new DateTime({ mwqmRun.DateTime_Local.Year }, { mwqmRun.DateTime_Local.Month }, { mwqmRun.DateTime_Local.Day }, { mwqmRun.DateTime_Local.Hour }, { mwqmRun.DateTime_Local.Minute }, { mwqmRun.DateTime_Local.Second })";
                                                    string StartDateTime_Local = mwqmRun.StartDateTime_Local == null ? "null" : $@"new DateTime({ ((DateTime)mwqmRun.StartDateTime_Local).Year }, { ((DateTime)mwqmRun.StartDateTime_Local).Month }, { ((DateTime)mwqmRun.StartDateTime_Local).Day }, { ((DateTime)mwqmRun.StartDateTime_Local).Hour }, { ((DateTime)mwqmRun.StartDateTime_Local).Minute }, { ((DateTime)mwqmRun.StartDateTime_Local).Second })";
                                                    string EndDateTime_Local = mwqmRun.EndDateTime_Local == null ? "null" : $@"new DateTime({ ((DateTime)mwqmRun.EndDateTime_Local).Year }, { ((DateTime)mwqmRun.EndDateTime_Local).Month }, { ((DateTime)mwqmRun.EndDateTime_Local).Day }, { ((DateTime)mwqmRun.EndDateTime_Local).Hour }, { ((DateTime)mwqmRun.EndDateTime_Local).Minute }, { ((DateTime)mwqmRun.EndDateTime_Local).Second })";
                                                    string LabReceivedDateTime_Local = mwqmRun.LabReceivedDateTime_Local == null ? "null" : $@"new DateTime({ ((DateTime)mwqmRun.LabReceivedDateTime_Local).Year }, { ((DateTime)mwqmRun.LabReceivedDateTime_Local).Month }, { ((DateTime)mwqmRun.LabReceivedDateTime_Local).Day }, { ((DateTime)mwqmRun.LabReceivedDateTime_Local).Hour }, { ((DateTime)mwqmRun.LabReceivedDateTime_Local).Minute }, { ((DateTime)mwqmRun.LabReceivedDateTime_Local).Second })";
                                                    string TemperatureControl1_C = mwqmRun.TemperatureControl1_C == null ? "null" : ((float)mwqmRun.TemperatureControl1_C).ToString();
                                                    string TemperatureControl2_C = mwqmRun.TemperatureControl2_C == null ? "null" : ((float)mwqmRun.TemperatureControl2_C).ToString();
                                                    string SeaStateAtStart_BeaufortScale = mwqmRun.SeaStateAtStart_BeaufortScale == null ? "null" : "(BeaufortScaleEnum)" + ((int)mwqmRun.SeaStateAtStart_BeaufortScale).ToString();
                                                    string SeaStateAtEnd_BeaufortScale = mwqmRun.SeaStateAtEnd_BeaufortScale == null ? "null" : "(BeaufortScaleEnum)" + ((int)mwqmRun.SeaStateAtEnd_BeaufortScale).ToString();
                                                    string WaterLevelAtBrook_m = mwqmRun.WaterLevelAtBrook_m == null ? "null" : ((float)mwqmRun.WaterLevelAtBrook_m).ToString();
                                                    string WaveHightAtStart_m = mwqmRun.WaveHightAtStart_m == null ? "null" : ((float)mwqmRun.WaveHightAtStart_m).ToString();
                                                    string WaveHightAtEnd_m = mwqmRun.WaveHightAtEnd_m == null ? "null" : ((float)mwqmRun.WaveHightAtEnd_m).ToString();
                                                    string SampleCrewInitials = mwqmRun.SampleCrewInitials == null ? "null" : mwqmRun.SampleCrewInitials;
                                                    string AnalyzeMethod = mwqmRun.AnalyzeMethod == null ? "null" : "(AnalyzeMethodEnum)" + ((int)mwqmRun.AnalyzeMethod).ToString();
                                                    string SampleMatrix = mwqmRun.SampleMatrix == null ? "null" : "(SampleMatrixEnum)" + ((int)mwqmRun.SampleMatrix).ToString();
                                                    string Laboratory = mwqmRun.Laboratory == null ? "null" : "(LaboratoryEnum)" + ((int)mwqmRun.Laboratory).ToString();
                                                    string SampleStatus = mwqmRun.SampleStatus == null ? "null" : "(SampleStatusEnum)" + ((int)mwqmRun.SampleStatus).ToString();
                                                    string LabSampleApprovalContactTVItemID = mwqmRun.LabSampleApprovalContactTVItemID == null ? "null" : ((int)mwqmRun.LabSampleApprovalContactTVItemID).ToString();
                                                    string LabAnalyzeBath1IncubationStartDateTime_Local = mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local == null ? "null" : $@"new DateTime({ ((DateTime)mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local).Year }, { ((DateTime)mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local).Month }, { ((DateTime)mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local).Day }, { ((DateTime)mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local).Hour }, { ((DateTime)mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local).Minute }, { ((DateTime)mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local).Second })";
                                                    string LabAnalyzeBath2IncubationStartDateTime_Local = mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local == null ? "null" : $@"new DateTime({ ((DateTime)mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local).Year }, { ((DateTime)mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local).Month }, { ((DateTime)mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local).Day }, { ((DateTime)mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local).Hour }, { ((DateTime)mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local).Minute }, { ((DateTime)mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local).Second })";
                                                    string LabAnalyzeBath3IncubationStartDateTime_Local = mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local == null ? "null" : $@"new DateTime({ ((DateTime)mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local).Year }, { ((DateTime)mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local).Month }, { ((DateTime)mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local).Day }, { ((DateTime)mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local).Hour }, { ((DateTime)mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local).Minute }, { ((DateTime)mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local).Second })";
                                                    string LabRunSampleApprovalDateTime_Local = mwqmRun.LabRunSampleApprovalDateTime_Local == null ? "null" : $@"new DateTime({ ((DateTime)mwqmRun.LabRunSampleApprovalDateTime_Local).Year }, { ((DateTime)mwqmRun.LabRunSampleApprovalDateTime_Local).Month }, { ((DateTime)mwqmRun.LabRunSampleApprovalDateTime_Local).Day }, { ((DateTime)mwqmRun.LabRunSampleApprovalDateTime_Local).Hour }, { ((DateTime)mwqmRun.LabRunSampleApprovalDateTime_Local).Minute }, { ((DateTime)mwqmRun.LabRunSampleApprovalDateTime_Local).Second })";
                                                    string Tide_Start = mwqmRun.Tide_Start == null ? "null" : "(TideTextEnum)" + ((int)mwqmRun.Tide_Start).ToString();
                                                    string Tide_End = mwqmRun.Tide_End == null ? "null" : "(TideTextEnum)" + ((int)mwqmRun.Tide_End).ToString();
                                                    string RainDay0_mm = mwqmRun.RainDay0_mm == null ? "null" : ((float)mwqmRun.RainDay0_mm).ToString();
                                                    string RainDay1_mm = mwqmRun.RainDay1_mm == null ? "null" : ((float)mwqmRun.RainDay1_mm).ToString();
                                                    string RainDay2_mm = mwqmRun.RainDay2_mm == null ? "null" : ((float)mwqmRun.RainDay2_mm).ToString();
                                                    string RainDay3_mm = mwqmRun.RainDay3_mm == null ? "null" : ((float)mwqmRun.RainDay3_mm).ToString();
                                                    string RainDay4_mm = mwqmRun.RainDay4_mm == null ? "null" : ((float)mwqmRun.RainDay4_mm).ToString();
                                                    string RainDay5_mm = mwqmRun.RainDay5_mm == null ? "null" : ((float)mwqmRun.RainDay5_mm).ToString();
                                                    string RainDay6_mm = mwqmRun.RainDay6_mm == null ? "null" : ((float)mwqmRun.RainDay6_mm).ToString();
                                                    string RainDay7_mm = mwqmRun.RainDay7_mm == null ? "null" : ((float)mwqmRun.RainDay7_mm).ToString();
                                                    string RainDay8_mm = mwqmRun.RainDay8_mm == null ? "null" : ((float)mwqmRun.RainDay8_mm).ToString();
                                                    string RainDay9_mm = mwqmRun.RainDay9_mm == null ? "null" : ((float)mwqmRun.RainDay9_mm).ToString();
                                                    string RainDay10_mm = mwqmRun.RainDay10_mm == null ? "null" : ((float)mwqmRun.RainDay10_mm).ToString();
                                                    string RemoveFromStat = mwqmRun.RemoveFromStat == null ? "null" : ((bool)mwqmRun.RemoveFromStat).ToString().ToLower();
                                                    string LastUpdateDate_UTC = $@"new DateTime({ mwqmRun.LastUpdateDate_UTC.Year }, { mwqmRun.LastUpdateDate_UTC.Month }, { mwqmRun.LastUpdateDate_UTC.Day }, { mwqmRun.LastUpdateDate_UTC.Hour }, { mwqmRun.LastUpdateDate_UTC.Minute }, { mwqmRun.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"MWQMRunID = { mwqmRun.MWQMRunID }, " +
                                                        $@"SubsectorTVItemID = { mwqmRun.SubsectorTVItemID }, " +
                                                        $@"MWQMRunTVItemID = { mwqmRun.MWQMRunTVItemID }, " +
                                                        $@"RunSampleType = (SampleTypeEnum){ (int)mwqmRun.RunSampleType }, " +
                                                        $@"DateTime_Local = { DateTime_Local }, " +
                                                        $@"RunNumber = { mwqmRun.RunNumber }, " +
                                                        $@"StartDateTime_Local = { StartDateTime_Local }, " +
                                                        $@"EndDateTime_Local = { EndDateTime_Local }, " +
                                                        $@"LabReceivedDateTime_Local = { LabReceivedDateTime_Local }, " +
                                                        $@"TemperatureControl1_C = { TemperatureControl1_C }, " +
                                                        $@"TemperatureControl2_C = { TemperatureControl2_C }, " +
                                                        $@"SeaStateAtStart_BeaufortScale = { SeaStateAtStart_BeaufortScale }, " +
                                                        $@"SeaStateAtEnd_BeaufortScale = { SeaStateAtEnd_BeaufortScale }, " +
                                                        $@"WaterLevelAtBrook_m = { WaterLevelAtBrook_m }, " +
                                                        $@"WaveHightAtStart_m = { WaveHightAtStart_m }, " +
                                                        $@"WaveHightAtEnd_m = { WaveHightAtEnd_m }, " +
                                                        $@"SampleCrewInitials = ""{ SampleCrewInitials }"", " +
                                                        $@"AnalyzeMethod = { AnalyzeMethod }, " +
                                                        $@"SampleMatrix = { SampleMatrix }, " +
                                                        $@"Laboratory = { Laboratory }, " +
                                                        $@"SampleStatus = { SampleStatus }, " +
                                                        $@"LabSampleApprovalContactTVItemID = { LabSampleApprovalContactTVItemID }, " +
                                                        $@"LabAnalyzeBath1IncubationStartDateTime_Local = { LabAnalyzeBath1IncubationStartDateTime_Local }, " +
                                                        $@"LabAnalyzeBath2IncubationStartDateTime_Local = { LabAnalyzeBath2IncubationStartDateTime_Local }, " +
                                                        $@"LabAnalyzeBath3IncubationStartDateTime_Local = { LabAnalyzeBath3IncubationStartDateTime_Local }, " +
                                                        $@"LabRunSampleApprovalDateTime_Local = { LabRunSampleApprovalDateTime_Local }, " +
                                                        $@"Tide_Start = { Tide_Start }, " +
                                                        $@"Tide_End = { Tide_End }, " +
                                                        $@"RainDay0_mm = { RainDay0_mm }, " +
                                                        $@"RainDay1_mm = { RainDay1_mm }, " +
                                                        $@"RainDay2_mm = { RainDay2_mm }, " +
                                                        $@"RainDay3_mm = { RainDay3_mm }, " +
                                                        $@"RainDay4_mm = { RainDay4_mm }, " +
                                                        $@"RainDay5_mm = { RainDay5_mm }, " +
                                                        $@"RainDay6_mm = { RainDay6_mm }, " +
                                                        $@"RainDay7_mm = { RainDay7_mm }, " +
                                                        $@"RainDay8_mm = { RainDay8_mm }, " +
                                                        $@"RainDay9_mm = { RainDay9_mm }, " +
                                                        $@"RainDay10_mm = { RainDay10_mm }, " +
                                                        $@"RemoveFromStat = { RemoveFromStat }, " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { mwqmRun.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "MWQMSample":
                                        {
                                            MWQMSample mwqmSample = dbTestDB.MWQMSamples.AsNoTracking().FirstOrDefault();
                                            if (mwqmSample == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mwqmSample.MWQMSampleID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string SampleDateTime_Local = $@"new DateTime({ mwqmSample.SampleDateTime_Local.Year }, { mwqmSample.SampleDateTime_Local.Month }, { mwqmSample.SampleDateTime_Local.Day }, { mwqmSample.SampleDateTime_Local.Hour }, { mwqmSample.SampleDateTime_Local.Minute }, { mwqmSample.SampleDateTime_Local.Second })";
                                                    string TimeText = mwqmSample.TimeText == null ? "null" : mwqmSample.TimeText.ToString();
                                                    string Depth_m = mwqmSample.Depth_m == null ? "null" : ((float)mwqmSample.Depth_m).ToString();
                                                    string Salinity_PPT = mwqmSample.Salinity_PPT == null ? "null" : ((float)mwqmSample.Salinity_PPT).ToString();
                                                    string WaterTemp_C = mwqmSample.WaterTemp_C == null ? "null" : ((float)mwqmSample.WaterTemp_C).ToString();
                                                    string PH = mwqmSample.PH == null ? "null" : ((float)mwqmSample.PH).ToString();
                                                    string SampleType_old = mwqmSample.SampleType_old == null ? "null" : "(SampleTypeEnum)" + ((int)mwqmSample.SampleType_old).ToString();
                                                    string Tube_10 = mwqmSample.Tube_10 == null ? "null" : ((float)mwqmSample.Tube_10).ToString();
                                                    string Tube_1_0 = mwqmSample.Tube_1_0 == null ? "null" : ((float)mwqmSample.Tube_1_0).ToString();
                                                    string Tube_0_1 = mwqmSample.Tube_0_1 == null ? "null" : ((float)mwqmSample.Tube_0_1).ToString();
                                                    string ProcessedBy = mwqmSample.ProcessedBy == null ? "null" : mwqmSample.ProcessedBy;
                                                    string LastUpdateDate_UTC = $@"new DateTime({ mwqmSample.LastUpdateDate_UTC.Year }, { mwqmSample.LastUpdateDate_UTC.Month }, { mwqmSample.LastUpdateDate_UTC.Day }, { mwqmSample.LastUpdateDate_UTC.Hour }, { mwqmSample.LastUpdateDate_UTC.Minute }, { mwqmSample.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"MWQMSampleID = { mwqmSample.MWQMSampleID }, " +
                                                        $@"MWQMSiteTVItemID = { mwqmSample.MWQMSiteTVItemID }, " +
                                                        $@"MWQMRunTVItemID = { mwqmSample.MWQMRunTVItemID }, " +
                                                        $@"SampleDateTime_Local = { SampleDateTime_Local }, " +
                                                        $@"TimeText = { TimeText }, " +
                                                        $@"Depth_m = { Depth_m }, " +
                                                        $@"FecCol_MPN_100ml = { mwqmSample.FecCol_MPN_100ml }, " +
                                                        $@"Salinity_PPT = { Salinity_PPT }, " +
                                                        $@"WaterTemp_C = { WaterTemp_C }, " +
                                                        $@"PH = { PH }, " +
                                                        $@"SampleTypesText = ""{ mwqmSample.SampleTypesText }"", " +
                                                        $@"SampleType_old = { SampleType_old }, " +
                                                        $@"Tube_10 = { Tube_10 }, " +
                                                        $@"Tube_1_0 = { Tube_1_0 }, " +
                                                        $@"Tube_0_1 = { Tube_0_1 }, " +
                                                        $@"ProcessedBy = { ProcessedBy }, " +
                                                        $@"UseForOpenData = { mwqmSample.UseForOpenData.ToString().ToLower() }, " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { mwqmSample.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "MWQMSubsector":
                                        {
                                            MWQMSubsector mwqmSubsector = dbTestDB.MWQMSubsectors.AsNoTracking().FirstOrDefault();
                                            if (mwqmSubsector == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mwqmSubsector.MWQMSubsectorID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string TideLocationSIDText = mwqmSubsector.TideLocationSIDText == null ? "null" : mwqmSubsector.TideLocationSIDText.ToString();
                                                    string LastUpdateDate_UTC = $@"new DateTime({ mwqmSubsector.LastUpdateDate_UTC.Year }, { mwqmSubsector.LastUpdateDate_UTC.Month }, { mwqmSubsector.LastUpdateDate_UTC.Day }, { mwqmSubsector.LastUpdateDate_UTC.Hour }, { mwqmSubsector.LastUpdateDate_UTC.Minute }, { mwqmSubsector.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"MWQMSubsectorID = { mwqmSubsector.MWQMSubsectorID }, " +
                                                        $@"MWQMSubsectorTVItemID = { mwqmSubsector.MWQMSubsectorTVItemID }, " +
                                                        $@"SubsectorHistoricKey = ""{ mwqmSubsector.SubsectorHistoricKey }"", " +
                                                        $@"TideLocationSIDText = ""{ TideLocationSIDText }"", " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { mwqmSubsector.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "PolSourceGrouping":
                                        {
                                            PolSourceGrouping polSourceGrouping = dbTestDB.PolSourceGroupings.AsNoTracking().FirstOrDefault();
                                            if (polSourceGrouping == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { polSourceGrouping.PolSourceGroupingID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string LastUpdateDate_UTC = $@"new DateTime({ polSourceGrouping.LastUpdateDate_UTC.Year }, { polSourceGrouping.LastUpdateDate_UTC.Month }, { polSourceGrouping.LastUpdateDate_UTC.Day }, { polSourceGrouping.LastUpdateDate_UTC.Hour }, { polSourceGrouping.LastUpdateDate_UTC.Minute }, { polSourceGrouping.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"PolSourceGroupingID = { polSourceGrouping.PolSourceGroupingID }, " +
                                                        $@"CSSPID = { polSourceGrouping.CSSPID }, " +
                                                        $@"GroupName = ""{ polSourceGrouping.GroupName }"", " +
                                                        $@"Child = ""{ polSourceGrouping.Child }"", " +
                                                        $@"Hide = ""{ polSourceGrouping.Hide }"", " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { polSourceGrouping.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "PolSourceObservation":
                                        {
                                            PolSourceObservation polSourceObservation = dbTestDB.PolSourceObservations.AsNoTracking().FirstOrDefault();
                                            if (polSourceObservation == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { polSourceObservation.PolSourceObservationID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string ObservationDate_Local = $@"new DateTime({ polSourceObservation.ObservationDate_Local.Year }, { polSourceObservation.ObservationDate_Local.Month }, { polSourceObservation.ObservationDate_Local.Day }, { polSourceObservation.ObservationDate_Local.Hour }, { polSourceObservation.ObservationDate_Local.Minute }, { polSourceObservation.ObservationDate_Local.Second })";
                                                    string LastUpdateDate_UTC = $@"new DateTime({ polSourceObservation.LastUpdateDate_UTC.Year }, { polSourceObservation.LastUpdateDate_UTC.Month }, { polSourceObservation.LastUpdateDate_UTC.Day }, { polSourceObservation.LastUpdateDate_UTC.Hour }, { polSourceObservation.LastUpdateDate_UTC.Minute }, { polSourceObservation.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"PolSourceObservationID = { polSourceObservation.PolSourceObservationID }, " +
                                                        $@"PolSourceSiteID = { polSourceObservation.PolSourceSiteID }, " +
                                                        $@"ObservationDate_Local = { ObservationDate_Local }, " +
                                                        $@"ContactTVItemID = { polSourceObservation.ContactTVItemID }, " +
                                                        $@"DesktopReviewed = { polSourceObservation.DesktopReviewed.ToString().ToLower() }, " +
                                                        $@"Observation_ToBeDeleted = ""{ polSourceObservation.Observation_ToBeDeleted.Replace("\r\n", "---") }"", " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { polSourceObservation.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "PolSourceSite":
                                        {
                                            PolSourceSite polSourceSite = dbTestDB.PolSourceSites.AsNoTracking().FirstOrDefault();
                                            if (polSourceSite == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { polSourceSite.PolSourceSiteID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string Temp_Locator_CanDelete = polSourceSite.Temp_Locator_CanDelete == null ? null : polSourceSite.Temp_Locator_CanDelete.ToString();
                                                    string Oldsiteid = polSourceSite.Oldsiteid == null ? "null" : polSourceSite.Oldsiteid.ToString();
                                                    string Site = polSourceSite.Site == null ? "null" : polSourceSite.Site.ToString();
                                                    string SiteID = polSourceSite.SiteID == null ? "null" : polSourceSite.SiteID.ToString();
                                                    string InactiveReason = polSourceSite.InactiveReason == null ? "null" : polSourceSite.InactiveReason.ToString();
                                                    string CivicAddressTVItemID = polSourceSite.CivicAddressTVItemID == null ? "null" : polSourceSite.CivicAddressTVItemID.ToString();
                                                    string LastUpdateDate_UTC = $@"new DateTime({ polSourceSite.LastUpdateDate_UTC.Year }, { polSourceSite.LastUpdateDate_UTC.Month }, { polSourceSite.LastUpdateDate_UTC.Day }, { polSourceSite.LastUpdateDate_UTC.Hour }, { polSourceSite.LastUpdateDate_UTC.Minute }, { polSourceSite.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"PolSourceSiteID = { polSourceSite.PolSourceSiteID }, " +
                                                        $@"PolSourceSiteTVItemID = { polSourceSite.PolSourceSiteTVItemID }, " +
                                                        $@"Temp_Locator_CanDelete = ""{ Temp_Locator_CanDelete }"", " +
                                                        $@"Oldsiteid = { Oldsiteid }, " +
                                                        $@"Site = { Site }, " +
                                                        $@"SiteID = { SiteID }, " +
                                                        $@"IsPointSource = { polSourceSite.IsPointSource.ToString().ToLower() }, " +
                                                        $@"InactiveReason = { InactiveReason }, " +
                                                        $@"CivicAddressTVItemID = { CivicAddressTVItemID }, " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { polSourceSite.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "RatingCurve":
                                        {
                                            RatingCurve ratingCurve = dbTestDB.RatingCurves.AsNoTracking().FirstOrDefault();
                                            if (ratingCurve == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { ratingCurve.RatingCurveID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string LastUpdateDate_UTC = $@"new DateTime({ ratingCurve.LastUpdateDate_UTC.Year }, { ratingCurve.LastUpdateDate_UTC.Month }, { ratingCurve.LastUpdateDate_UTC.Day }, { ratingCurve.LastUpdateDate_UTC.Hour }, { ratingCurve.LastUpdateDate_UTC.Minute }, { ratingCurve.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"RatingCurveID = { ratingCurve.RatingCurveID }, " +
                                                        $@"HydrometricSiteID = { ratingCurve.HydrometricSiteID }, " +
                                                        $@"RatingCurveNumber = ""{ ratingCurve.RatingCurveNumber }"", " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { ratingCurve.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "ReportType":
                                        {
                                            ReportType reportType = dbTestDB.ReportTypes.AsNoTracking().FirstOrDefault();
                                            if (reportType == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { reportType.ReportTypeID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string Language = reportType.Language == null ? "null" : "(LanguageEnum)" + ((int)reportType.Language).ToString();
                                                    string Name = reportType.Name == null ? "null" : reportType.Name;
                                                    string Description = reportType.Description == null ? "null" : reportType.Description;
                                                    string StartOfFileName = reportType.StartOfFileName == null ? "null" : reportType.StartOfFileName;
                                                    string LastUpdateDate_UTC = $@"new DateTime({ reportType.LastUpdateDate_UTC.Year }, { reportType.LastUpdateDate_UTC.Month }, { reportType.LastUpdateDate_UTC.Day }, { reportType.LastUpdateDate_UTC.Hour }, { reportType.LastUpdateDate_UTC.Minute }, { reportType.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"ReportTypeID = { reportType.ReportTypeID }, " +
                                                        $@"TVType = (TVTypeEnum){ (int)reportType.TVType }, " +
                                                        $@"FileType = (FileTypeEnum){ (int)reportType.FileType }, " +
                                                        $@"UniqueCode = ""{ reportType.UniqueCode }"", " +
                                                        $@"Language = { Language }, " +
                                                        $@"Name = ""{ Name }"", " +
                                                        $@"Description = ""{ Description }"", " +
                                                        $@"StartOfFileName = ""{ StartOfFileName }"", " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { reportType.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "SamplingPlanSubsector":
                                        {
                                            SamplingPlanSubsector samplingPlanSubsector = dbTestDB.SamplingPlanSubsectors.AsNoTracking().FirstOrDefault();
                                            if (samplingPlanSubsector == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { samplingPlanSubsector.SamplingPlanSubsectorID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string LastUpdateDate_UTC = $@"new DateTime({ samplingPlanSubsector.LastUpdateDate_UTC.Year }, { samplingPlanSubsector.LastUpdateDate_UTC.Month }, { samplingPlanSubsector.LastUpdateDate_UTC.Day }, { samplingPlanSubsector.LastUpdateDate_UTC.Hour }, { samplingPlanSubsector.LastUpdateDate_UTC.Minute }, { samplingPlanSubsector.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"SamplingPlanSubsectorID = { samplingPlanSubsector.SamplingPlanSubsectorID }, " +
                                                        $@"SamplingPlanID = { samplingPlanSubsector.SamplingPlanID }, " +
                                                        $@"SubsectorTVItemID = { samplingPlanSubsector.SubsectorTVItemID }, " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { samplingPlanSubsector.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "SamplingPlan":
                                        {
                                            SamplingPlan samplingPlan = dbTestDB.SamplingPlans.AsNoTracking().FirstOrDefault();
                                            if (samplingPlan == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { samplingPlan.SamplingPlanID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string SamplingPlanFileTVItemID = samplingPlan.SamplingPlanFileTVItemID == null ? "null" : samplingPlan.SamplingPlanFileTVItemID.ToString();
                                                    string AnalyzeMethodDefault = samplingPlan.AnalyzeMethodDefault == null ? "null" : "(AnalyzeMethodEnum)" + ((int)samplingPlan.AnalyzeMethodDefault).ToString();
                                                    string SampleMatrixDefault = samplingPlan.SampleMatrixDefault == null ? "null" : "(SampleMatrixEnum)" + ((int)samplingPlan.SampleMatrixDefault).ToString();
                                                    string LaboratoryDefault = samplingPlan.LaboratoryDefault == null ? "null" : "(LaboratoryEnum)" + ((int)samplingPlan.LaboratoryDefault).ToString();
                                                    string LastUpdateDate_UTC = $@"new DateTime({ samplingPlan.LastUpdateDate_UTC.Year }, { samplingPlan.LastUpdateDate_UTC.Month }, { samplingPlan.LastUpdateDate_UTC.Day }, { samplingPlan.LastUpdateDate_UTC.Hour }, { samplingPlan.LastUpdateDate_UTC.Minute }, { samplingPlan.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"SamplingPlanID = { samplingPlan.SamplingPlanID }, " +
                                                        $@"IsActive = { samplingPlan.IsActive.ToString().ToLower() }, " +
                                                        $@"SamplingPlanName = @""{ samplingPlan.SamplingPlanName }"", " +
                                                        $@"ForGroupName = ""{ samplingPlan.ForGroupName }"", " +
                                                        $@"SampleType = (SampleTypeEnum){ (int)samplingPlan.SampleType }, " +
                                                        $@"SamplingPlanType = (SamplingPlanTypeEnum){ (int)samplingPlan.SamplingPlanType }, " +
                                                        $@"LabSheetType = (LabSheetTypeEnum){ (int)samplingPlan.LabSheetType }, " +
                                                        $@"ProvinceTVItemID = { samplingPlan.ProvinceTVItemID }, " +
                                                        $@"CreatorTVItemID = { samplingPlan.CreatorTVItemID }, " +
                                                        $@"Year = { samplingPlan.Year }, " +
                                                        $@"AccessCode = ""{ samplingPlan.AccessCode }"", " +
                                                        $@"DailyDuplicatePrecisionCriteria = { samplingPlan.DailyDuplicatePrecisionCriteria }, " +
                                                        $@"IntertechDuplicatePrecisionCriteria = { samplingPlan.IntertechDuplicatePrecisionCriteria }, " +
                                                        $@"IncludeLaboratoryQAQC = { samplingPlan.IncludeLaboratoryQAQC.ToString().ToLower() }, " +
                                                        $@"ApprovalCode = ""{ samplingPlan.ApprovalCode }"", " +
                                                        $@"SamplingPlanFileTVItemID = { SamplingPlanFileTVItemID }, " +
                                                        $@"AnalyzeMethodDefault = { AnalyzeMethodDefault }, " +
                                                        $@"SampleMatrixDefault = { SampleMatrixDefault }, " +
                                                        $@"LaboratoryDefault = { LaboratoryDefault }, " +
                                                        $@"BackupDirectory = @""{ samplingPlan.BackupDirectory }"", " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { samplingPlan.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "Spill":
                                        {
                                            Spill spill = dbTestDB.Spills.AsNoTracking().FirstOrDefault();
                                            if (spill == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { spill.SpillID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string InfrastructureTVItemID = spill.InfrastructureTVItemID == null ? "null" : spill.InfrastructureTVItemID.ToString();
                                                    string StartDateTime_Local = $@"new DateTime({ spill.StartDateTime_Local.Year }, { spill.StartDateTime_Local.Month }, { spill.StartDateTime_Local.Day }, { spill.StartDateTime_Local.Hour }, { spill.StartDateTime_Local.Minute }, { spill.StartDateTime_Local.Second })";
                                                    string EndDateTime_Local = spill.EndDateTime_Local == null ? "null" : $@"new DateTime({ ((DateTime)spill.EndDateTime_Local).Year }, { ((DateTime)spill.EndDateTime_Local).Month }, { ((DateTime)spill.EndDateTime_Local).Day }, { ((DateTime)spill.EndDateTime_Local).Hour }, { ((DateTime)spill.EndDateTime_Local).Minute }, { ((DateTime)spill.EndDateTime_Local).Second })";
                                                    string LastUpdateDate_UTC = $@"new DateTime({ spill.LastUpdateDate_UTC.Year }, { spill.LastUpdateDate_UTC.Month }, { spill.LastUpdateDate_UTC.Day }, { spill.LastUpdateDate_UTC.Hour }, { spill.LastUpdateDate_UTC.Minute }, { spill.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"SpillID = { spill.SpillID }, " +
                                                        $@"MunicipalityTVItemID = { spill.MunicipalityTVItemID }, " +
                                                        $@"InfrastructureTVItemID = { InfrastructureTVItemID }, " +
                                                        $@"StartDateTime_Local = { StartDateTime_Local }, " +
                                                        $@"EndDateTime_Local = { EndDateTime_Local }, " +
                                                        $@"AverageFlow_m3_day = { spill.AverageFlow_m3_day }, " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { spill.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "TVFile":
                                        {
                                            TVFile tvFile = dbTestDB.TVFiles.AsNoTracking().FirstOrDefault();
                                            if (tvFile == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { tvFile.TVFileID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string TemplateTVType = tvFile.TemplateTVType == null ? "null" : "(TVTypeEnum)" + ((int)tvFile.TemplateTVType).ToString();
                                                    string ReportTypeID = tvFile.ReportTypeID == null ? "null" : tvFile.ReportTypeID.ToString();
                                                    string Parameters = tvFile.Parameters == null ? "null" : tvFile.Parameters.ToString();
                                                    string Year = tvFile.Year == null ? "null" : tvFile.Year.ToString();
                                                    string FileInfo = tvFile.FileInfo == null ? "null" : tvFile.FileInfo.ToString();
                                                    string FileCreatedDate_UTC = $@"new DateTime({ tvFile.FileCreatedDate_UTC.Year }, { tvFile.FileCreatedDate_UTC.Month }, { tvFile.FileCreatedDate_UTC.Day }, { tvFile.FileCreatedDate_UTC.Hour }, { tvFile.FileCreatedDate_UTC.Minute }, { tvFile.FileCreatedDate_UTC.Second })";
                                                    string FromWater = tvFile.FromWater == null ? "null" : tvFile.FromWater.ToString().ToLower();
                                                    string ClientFilePath = tvFile.ClientFilePath == null ? "null" : tvFile.ClientFilePath.ToString();
                                                    string LastUpdateDate_UTC = $@"new DateTime({ tvFile.LastUpdateDate_UTC.Year }, { tvFile.LastUpdateDate_UTC.Month }, { tvFile.LastUpdateDate_UTC.Day }, { tvFile.LastUpdateDate_UTC.Hour }, { tvFile.LastUpdateDate_UTC.Minute }, { tvFile.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"TVFileID = { tvFile.TVFileID }, " +
                                                        $@"TVFileTVItemID = { tvFile.TVFileTVItemID }, " +
                                                        $@"TemplateTVType = { TemplateTVType }, " +
                                                        $@"ReportTypeID = { ReportTypeID }, " +
                                                        $@"Parameters = { Parameters }, " +
                                                        $@"Year = { Year }, " +
                                                        $@"Language = (LanguageEnum){ (int)tvFile.Language }, " +
                                                        $@"FilePurpose = (FilePurposeEnum){ (int)tvFile.FilePurpose }, " +
                                                        $@"FileType = (FileTypeEnum){ (int)tvFile.FileType }, " +
                                                        $@"FileSize_kb = { tvFile.FileSize_kb }, " +
                                                        $@"FileInfo = ""{ FileInfo }"", " +
                                                        $@"FileCreatedDate_UTC = { FileCreatedDate_UTC }, " +
                                                        $@"FromWater = { FromWater }, " +
                                                        $@"ClientFilePath = @""{ ClientFilePath }"", " +
                                                        $@"ServerFileName = @""{ tvFile.ServerFileName }"", " +
                                                        $@"ServerFilePath = @""{ tvFile.ServerFilePath }"", " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { tvFile.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "VPScenario":
                                        {
                                            VPScenario vpScenario = dbTestDB.VPScenarios.AsNoTracking().FirstOrDefault();
                                            if (vpScenario == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { vpScenario.VPScenarioID };");
                                                if (DBType == "DB")
                                                {
                                                }
                                                if (DBType == "DBLocal")
                                                {
                                                }
                                                if (DBType == "DBLocalIM")
                                                {
                                                    string EffluentFlow_m3_s = vpScenario.EffluentFlow_m3_s == null ? "null" : vpScenario.EffluentFlow_m3_s.ToString();
                                                    string EffluentConcentration_MPN_100ml = vpScenario.EffluentConcentration_MPN_100ml == null ? "null" : vpScenario.EffluentConcentration_MPN_100ml.ToString();
                                                    string FroudeNumber = vpScenario.FroudeNumber == null ? "null" : vpScenario.FroudeNumber.ToString();
                                                    string PortDiameter_m = vpScenario.PortDiameter_m == null ? "null" : vpScenario.PortDiameter_m.ToString();
                                                    string PortDepth_m = vpScenario.PortDepth_m == null ? "null" : vpScenario.PortDepth_m.ToString();
                                                    string PortElevation_m = vpScenario.PortElevation_m == null ? "null" : vpScenario.PortElevation_m.ToString();
                                                    string VerticalAngle_deg = vpScenario.VerticalAngle_deg == null ? "null" : vpScenario.VerticalAngle_deg.ToString();
                                                    string HorizontalAngle_deg = vpScenario.HorizontalAngle_deg == null ? "null" : vpScenario.HorizontalAngle_deg.ToString();
                                                    string NumberOfPorts = vpScenario.NumberOfPorts == null ? "null" : vpScenario.NumberOfPorts.ToString();
                                                    string PortSpacing_m = vpScenario.PortSpacing_m == null ? "null" : vpScenario.PortSpacing_m.ToString();
                                                    string AcuteMixZone_m = vpScenario.AcuteMixZone_m == null ? "null" : vpScenario.AcuteMixZone_m.ToString();
                                                    string ChronicMixZone_m = vpScenario.ChronicMixZone_m == null ? "null" : vpScenario.ChronicMixZone_m.ToString();
                                                    string EffluentSalinity_PSU = vpScenario.EffluentSalinity_PSU == null ? "null" : vpScenario.EffluentSalinity_PSU.ToString();
                                                    string EffluentTemperature_C = vpScenario.EffluentTemperature_C == null ? "null" : vpScenario.EffluentTemperature_C.ToString();
                                                    string EffluentVelocity_m_s = vpScenario.EffluentVelocity_m_s == null ? "null" : vpScenario.EffluentVelocity_m_s.ToString();
                                                    string RawResults = vpScenario.RawResults == null ? "null" : vpScenario.RawResults.ToString();
                                                    string LastUpdateDate_UTC = $@"new DateTime({ vpScenario.LastUpdateDate_UTC.Year }, { vpScenario.LastUpdateDate_UTC.Month }, { vpScenario.LastUpdateDate_UTC.Day }, { vpScenario.LastUpdateDate_UTC.Hour }, { vpScenario.LastUpdateDate_UTC.Minute }, { vpScenario.LastUpdateDate_UTC.Second })";
                                                    string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                        $@"VPScenarioID = { vpScenario.VPScenarioID }, " +
                                                        $@"InfrastructureTVItemID = { vpScenario.InfrastructureTVItemID }, " +
                                                        $@"VPScenarioStatus = (ScenarioStatusEnum){ (int)vpScenario.VPScenarioStatus }, " +
                                                        $@"UseAsBestEstimate = { vpScenario.UseAsBestEstimate.ToString().ToLower() }, " +
                                                        $@"EffluentFlow_m3_s = { EffluentFlow_m3_s }, " +
                                                        $@"EffluentConcentration_MPN_100ml = { EffluentConcentration_MPN_100ml }, " +
                                                        $@"FroudeNumber = { FroudeNumber }, " +
                                                        $@"PortDiameter_m = { PortDiameter_m }, " +
                                                        $@"PortDepth_m = { PortDepth_m }, " +
                                                        $@"PortElevation_m = { PortElevation_m }, " +
                                                        $@"VerticalAngle_deg = { VerticalAngle_deg }, " +
                                                        $@"HorizontalAngle_deg = { HorizontalAngle_deg }, " +
                                                        $@"NumberOfPorts = { NumberOfPorts }, " +
                                                        $@"PortSpacing_m = { PortSpacing_m }, " +
                                                        $@"AcuteMixZone_m = { AcuteMixZone_m }, " +
                                                        $@"ChronicMixZone_m = { ChronicMixZone_m }, " +
                                                        $@"EffluentSalinity_PSU = { EffluentSalinity_PSU }, " +
                                                        $@"EffluentTemperature_C = { EffluentTemperature_C }, " +
                                                        $@"EffluentVelocity_m_s = { EffluentVelocity_m_s }, " +
                                                        $@"RawResults = ""Raw Results not shown... too long"", " +
                                                        $@"LastUpdateDate_UTC = { LastUpdateDate_UTC }, " +
                                                        $@"LastUpdateContactTVItemID = { vpScenario.LastUpdateContactTVItemID } " +
                                                        $@"}});";
                                                    if (!sbInMemory.ToString().Contains(TempStr))
                                                    {
                                                        sbInMemory.AppendLine($@"            try");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine(TempStr);
                                                        sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                        sbInMemory.AppendLine($@"            }}");
                                                        sbInMemory.AppendLine($@"            catch (Exception)");
                                                        sbInMemory.AppendLine($@"            {{");
                                                        sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                        sbInMemory.AppendLine($@"            }}");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "TVItem":
                                        {
                                            if (TypeName == "MikeScenario" && csspProp.PropName == "ParentMikeScenarioID")
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = null;");
                                            }
                                            else
                                            {
                                                if (csspProp.AllowableTVTypeList.Count == 0)
                                                {
                                                    sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                                }
                                                else
                                                {
                                                    TVItem tvItem = dbTestDB.TVItems.AsNoTracking().Where(c => c.TVType == csspProp.AllowableTVTypeList[0]).FirstOrDefault();
                                                    if (tvItem == null)
                                                    {
                                                        sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { tvItem.TVItemID };");
                                                        if (DBType == "DB")
                                                        {
                                                        }
                                                        if (DBType == "DBLocal")
                                                        {
                                                        }
                                                        if (DBType == "DBLocalIM")
                                                        {
                                                            string DateStr = $@"new DateTime({ tvItem.LastUpdateDate_UTC.Year }, { tvItem.LastUpdateDate_UTC.Month }, { tvItem.LastUpdateDate_UTC.Day }, { tvItem.LastUpdateDate_UTC.Hour }, { tvItem.LastUpdateDate_UTC.Minute }, { tvItem.LastUpdateDate_UTC.Second })";
                                                            string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                                $@"TVItemID = { tvItem.TVItemID }, " +
                                                                $@"TVLevel = { tvItem.TVLevel }, " +
                                                                $@"TVPath = ""{ tvItem.TVPath }"", " +
                                                                $@"TVType = (TVTypeEnum){ (int)tvItem.TVType }, " +
                                                                $@"ParentID = { tvItem.ParentID }, " +
                                                                $@"IsActive = { tvItem.IsActive.ToString().ToLower() }, " +
                                                                $@"LastUpdateDate_UTC = { DateStr }, " +
                                                                $@"LastUpdateContactTVItemID = { tvItem.LastUpdateContactTVItemID }" +
                                                                $@" }});";
                                                            if (!sbInMemory.ToString().Contains(TempStr))
                                                            {
                                                                sbInMemory.AppendLine($@"            try");
                                                                sbInMemory.AppendLine($@"            {{");
                                                                sbInMemory.AppendLine(TempStr);
                                                                sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                                sbInMemory.AppendLine($@"            }}");
                                                                sbInMemory.AppendLine($@"            catch (Exception)");
                                                                sbInMemory.AppendLine($@"            {{");
                                                                sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                                sbInMemory.AppendLine($@"            }}");
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    default:
                                        {
                                            sb.AppendLine($@"            // Need to implement [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                        }
                                        break;
                                }
                            }
                            else if (csspProp.Min != null && csspProp.Max != null)
                            {
                                if (csspProp.Min > csspProp.Max)
                                {
                                    sb.AppendLine($@"            { prop.Name } = MinBiggerMaxPleaseFix,");
                                }
                                else
                                {
                                    if (TypeName == "MWQMLookupMPN" && (prop.Name == "Tubes01" || prop.Name == "Tubes1" || prop.Name == "Tubes10"))
                                    {
                                        sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandom{ propTypeTxt }({ 2 }{ numbExt }, { 5.ToString() }{ numbExt });");
                                    }
                                    else if (TypeName == "MWQMLookupMPN" && prop.Name == "MPN_100ml")
                                    {
                                        sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = 14;");
                                    }
                                    else
                                    {
                                        sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandom{ propTypeTxt }({ csspProp.Min }{ numbExt }, { csspProp.Max.ToString() }{ numbExt });");
                                    }
                                }
                            }
                            else if (csspProp.Min != null)
                            {
                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandom{ propTypeTxt }({ csspProp.Min }{ numbExt }, { (csspProp.Min + 10).ToString() }{ numbExt });");
                            }
                            else if (csspProp.Max != null)
                            {
                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandom{ propTypeTxt }({ (csspProp.Max - 10) }{ numbExt }, { csspProp.Max.ToString() }{ numbExt });");
                            }
                            else
                            {
                                sb.AppendLine($@"            // should implement a Range for the property { prop.Name } and type { TypeName }");
                            }
                        }
                    }
                    break;
                case "DateTime":
                case "DateTimeOffset":
                    {
                        switch ($"{ TypeName }_{ csspProp.PropName }")
                        {
                            case "AppTask_EndDateTime_UTC":
                            case "ClimateSite_HourlyEndDate_Local":
                            case "ClimateSite_DailyEndDate_Local":
                            case "ClimateSite_MonthlyEndDate_Local":
                            case "HydrometricSite_EndDate_Local":
                            case "MikeScenario_MikeScenarioEndDateTime_Local":
                            case "MikeSourceStartEnd_EndDateAndTime_Local":
                            case "MWQMRun_EndDateTime_Local":
                            case "MWQMSiteStartEndDate_EndDate":
                            case "MWQMSubsector_IncludeRainEndDate":
                            case "MWQMSubsector_NoRainEndDate":
                            case "MWQMSubsector_OnlyRainEndDate":
                            case "Spill_EndDateTime_Local":
                            case "TVItemLink_EndDateTime_Local":
                                break;
                            case "AppTask_StartDateTime_UTC":
                            case "ClimateSite_HourlyStartDate_Local":
                            case "ClimateSite_DailyStartDate_Local":
                            case "ClimateSite_MonthlyStartDate_Local":
                            case "HydrometricSite_StartDate_Local":
                            case "MikeScenario_MikeScenarioStartDateTime_Local":
                            case "MikeSourceStartEnd_StartDateAndTime_Local":
                            case "MWQMRun_StartDateTime_Local":
                            case "MWQMSiteStartEndDate_StartDate":
                            case "MWQMSubsector_IncludeRainStartDate":
                            case "MWQMSubsector_NoRainStartDate":
                            case "MWQMSubsector_OnlyRainStartDate":
                            case "Spill_StartDateTime_Local":
                            case "TVItemLink_StartDateTime_Local":
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = new DateTime(2005, 3, 6);");
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name.Replace("Start", "End") }"") { TypeNameLower }.{ prop.Name.Replace("Start", "End") } = new DateTime(2005, 3, 7);");
                                }
                                break;
                            default:
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = new DateTime(2005, 3, 6);");
                                }
                                break;
                        }
                    }
                    break;
                case "Boolean":
                    {
                        sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = true;");
                    }
                    break;
                case "String":
                    {
                        if (csspProp.HasCSSPExistAttribute)
                        {
                            switch (csspProp.ExistTypeName)
                            {
                                case "AspNetUser":
                                    {
                                        AspNetUser appTask = dbTestDB.AspNetUsers.AsNoTracking().FirstOrDefault();
                                        if (appTask == null)
                                        {
                                            sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                        }
                                        else
                                        {
                                            sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = ""{ appTask.Id }"";");
                                            if (DBType == "DB")
                                            {
                                            }
                                            if (DBType == "DBLocal")
                                            {
                                            }
                                            if (DBType == "DBLocalIM")
                                            {
                                                string TempStr = $@"                dbLocalIM.{ csspProp.ExistTypeName }s.Add(new { csspProp.ExistTypeName }() {{ " +
                                                    $@"Id = ""{ appTask.Id }"", " +
                                                    $@"Email = ""{ appTask.Email }"", " +
                                                    $@"UserName = ""{ appTask.UserName }"", " +
                                                    $@"}});";
                                                if (!sbInMemory.ToString().Contains(TempStr))
                                                {
                                                    sbInMemory.AppendLine($@"            try");
                                                    sbInMemory.AppendLine($@"            {{");
                                                    sbInMemory.AppendLine(TempStr);
                                                    sbInMemory.AppendLine($@"                dbLocalIM.SaveChanges();");
                                                    sbInMemory.AppendLine($@"            }}");
                                                    sbInMemory.AppendLine($@"            catch (Exception)");
                                                    sbInMemory.AppendLine($@"            {{");
                                                    sbInMemory.AppendLine($@"                // Assert.True(false, ex.Message);");
                                                    sbInMemory.AppendLine($@"            }}");
                                                }
                                            }
                                        }
                                    }
                                    break;
                                default:
                                    {
                                        sb.AppendLine($@"            // Need to implement [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                    }
                                    break;
                            }
                        }
                        else if (csspProp.HasDataTypeAttribute) // will have to do this better ... works because it's only use when email
                        {
                            sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandomEmail();");
                        }
                        else
                        {
                            if (csspProp.Min != null && csspProp.Max > 0)
                            {
                                if (csspProp.Min > csspProp.Max)
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = MinBiggerMaxLengthPleaseFix;");
                                }
                                else
                                {
                                    double? StrLen = (int)csspProp.Min + 5;
                                    if (StrLen > csspProp.Max)
                                    {
                                        StrLen = csspProp.Max;
                                    }
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandomString("""", { StrLen });");
                                }
                            }
                            else if (csspProp.Min != null)
                            {
                                double StrLen = (int)csspProp.Min + 5;
                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandomString("""", { StrLen });");
                            }
                            else if (csspProp.Max > 0)
                            {
                                double? StrLen = 5;
                                if (StrLen > csspProp.Max)
                                {
                                    StrLen = csspProp.Max;
                                }
                                if (TypeName == "Contact" && csspProp.HasCSSPExistAttribute)
                                {
                                    switch (csspProp.ExistTypeName)
                                    {
                                        case "AspNetUser":
                                            {
                                                AspNetUser AspNetUser = dbTestDB.AspNetUsers.AsNoTracking().FirstOrDefault();

                                                if (AspNetUser == null)
                                                {
                                                    sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                                }
                                                else
                                                {
                                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = ""{ AspNetUser.Id }"";");
                                                }
                                            }
                                            break;
                                        default:
                                            {
                                                sb.AppendLine($@"            // Need to implement [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            break;
                                    }
                                }
                                else
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandomString("""", { StrLen.ToString() });");
                                }
                            }
                            else
                            {
                                if (csspProp.IsList)
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = new List<string>() {{ GetRandomString("""", 20), GetRandomString("""", 20) }};");
                                }
                                else
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandomString("""", 20);");
                                }
                            }
                        }
                    }
                    break;
                case "Byte[]":
                    {
                        if (TypeName == "ContactLogin")
                        {
                            if (csspProp.PropName == "PasswordSalt")
                            {
                                // Don't do anything for this property
                                // everything will be done while at the PasswordHash property
                            }

                            if (csspProp.PropName == "PasswordHash")
                            {
                                sb.AppendLine(@"            ContactService contactService = new ContactService(LanguageRequest, dbTestDB, ContactID);");
                                sb.AppendLine(@"");
                                sb.AppendLine(@"            Register register = new Register();");
                                sb.AppendLine(@"            register.Password = GetRandomPassword(); // the only thing needed for CreatePasswordHashAndSalt");
                                sb.AppendLine(@"");
                                sb.AppendLine(@"            byte[] passwordHash;");
                                sb.AppendLine(@"            byte[] passwordSalt;");
                                sb.AppendLine(@"            contactService.CreatePasswordHashAndSalt(register, out passwordHash, out passwordSalt);");
                                sb.AppendLine(@"");
                                sb.AppendLine(@"            if (OmitPropName != ""PasswordHash"") contactLogin.PasswordHash = passwordHash;");
                                sb.AppendLine(@"            if (OmitPropName != ""PasswordSalt"") contactLogin.PasswordSalt = passwordSalt;");
                            }
                        }
                    }
                    break;
                default:
                    {
                        if (csspProp.PropType.Contains("Enum"))
                        {
                            if (csspProp.PropType.Contains("LanguageEnum"))
                            {
                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == ""fr"" ? LanguageEnum.fr : LanguageEnum.en;");
                            }
                            else
                            {
                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = ({ csspProp.PropType })GetRandomEnumType(typeof({ csspProp.PropType }));");
                            }
                        }
                        else if (csspProp.PropName.EndsWith("Web") || csspProp.PropName.EndsWith("Report"))
                        {
                            // nothing for now
                        }
                        else
                        {
                            sb.AppendLine($@"            //CSSPError: property [{ csspProp.PropName }] and type [{ TypeName }] is  not implemented");
                        }
                    }
                    break;
            }

            return await Task.FromResult(true);
        }
    }
}
