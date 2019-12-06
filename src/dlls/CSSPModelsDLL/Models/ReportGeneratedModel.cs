using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class ReportBase
    {
        public ReportBase()
        {
        }

        public string AllowableReportType()
        {
            return "Root, Country, Province, Area, Sector, Subsector, MWQM_Site, MWQM_Site_Sample, MWQM_Site_Start_And_End_Date, MWQM_Site_File, MWQM_Run, MWQM_Run_Sample, MWQM_Run_Lab_Sheet, MWQM_Run_Lab_Sheet_Detail, MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail, MWQM_Run_File, Pol_Source_Site, Pol_Source_Site_Obs, Pol_Source_Site_Obs_Issue, Pol_Source_Site_File, Pol_Source_Site_Address, Municipality, Infrastructure, Box_Model, Box_Model_Result, Visual_Plumes_Scenario, Visual_Plumes_Scenario_Ambient, Visual_Plumes_Scenario_Result, Infrastructure_Address, Infrastructure_File, Mike_Scenario, Mike_Scenario_Special_Result_KML, Mike_Source, Mike_Source_Start_End, Mike_Boundary_Condition, Mike_Scenario_File, Municipality_Contact, Municipality_Contact_Address, Municipality_Contact_Tel, Municipality_Contact_Email, Municipality_File, Subsector_Climate_Site, Subsector_Climate_Site_Data, Subsector_Hydrometric_Site, Subsector_Hydrometric_Site_Data, Subsector_Hydrometric_Site_Rating_Curve, Subsector_Hydrometric_Site_Rating_Curve_Value, Subsector_Special_Table, Subsector_Tide_Site, Subsector_Tide_Site_Data, Subsector_Lab_Sheet, Subsector_Lab_Sheet_Detail, Subsector_Lab_Sheet_Tube_And_MPN_Detail, Subsector_File, Sector_File, Area_File, Sampling_Plan, Sampling_Plan_Lab_Sheet, Sampling_Plan_Lab_Sheet_Detail, Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail, Sampling_Plan_Subsector, Sampling_Plan_Subsector_Site, Climate_Site, Climate_Site_Data, Hydrometric_Site, Hydrometric_Site_Data, Hydrometric_Site_Rating_Curve, Hydrometric_Site_Rating_Curve_Value, Province_File, Country_File, MPN_Lookup, Root_File, ";
        }

        public Type GetReportType(string TypeText)
        {
            switch (TypeText)
            {
                    case "Root":
                        return typeof(ReportRootModel);
                    case "Country":
                        return typeof(ReportCountryModel);
                    case "Province":
                        return typeof(ReportProvinceModel);
                    case "Area":
                        return typeof(ReportAreaModel);
                    case "Sector":
                        return typeof(ReportSectorModel);
                    case "Subsector":
                        return typeof(ReportSubsectorModel);
                    case "MWQM_Site":
                        return typeof(ReportMWQM_SiteModel);
                    case "MWQM_Site_Sample":
                        return typeof(ReportMWQM_Site_SampleModel);
                    case "MWQM_Site_Start_And_End_Date":
                        return typeof(ReportMWQM_Site_Start_And_End_DateModel);
                    case "MWQM_Site_File":
                        return typeof(ReportMWQM_Site_FileModel);
                    case "MWQM_Run":
                        return typeof(ReportMWQM_RunModel);
                    case "MWQM_Run_Sample":
                        return typeof(ReportMWQM_Run_SampleModel);
                    case "MWQM_Run_Lab_Sheet":
                        return typeof(ReportMWQM_Run_Lab_SheetModel);
                    case "MWQM_Run_Lab_Sheet_Detail":
                        return typeof(ReportMWQM_Run_Lab_Sheet_DetailModel);
                    case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail":
                        return typeof(ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel);
                    case "MWQM_Run_File":
                        return typeof(ReportMWQM_Run_FileModel);
                    case "Pol_Source_Site":
                        return typeof(ReportPol_Source_SiteModel);
                    case "Pol_Source_Site_Obs":
                        return typeof(ReportPol_Source_Site_ObsModel);
                    case "Pol_Source_Site_Obs_Issue":
                        return typeof(ReportPol_Source_Site_Obs_IssueModel);
                    case "Pol_Source_Site_File":
                        return typeof(ReportPol_Source_Site_FileModel);
                    case "Pol_Source_Site_Address":
                        return typeof(ReportPol_Source_Site_AddressModel);
                    case "Municipality":
                        return typeof(ReportMunicipalityModel);
                    case "Infrastructure":
                        return typeof(ReportInfrastructureModel);
                    case "Box_Model":
                        return typeof(ReportBox_ModelModel);
                    case "Box_Model_Result":
                        return typeof(ReportBox_Model_ResultModel);
                    case "Visual_Plumes_Scenario":
                        return typeof(ReportVisual_Plumes_ScenarioModel);
                    case "Visual_Plumes_Scenario_Ambient":
                        return typeof(ReportVisual_Plumes_Scenario_AmbientModel);
                    case "Visual_Plumes_Scenario_Result":
                        return typeof(ReportVisual_Plumes_Scenario_ResultModel);
                    case "Infrastructure_Address":
                        return typeof(ReportInfrastructure_AddressModel);
                    case "Infrastructure_File":
                        return typeof(ReportInfrastructure_FileModel);
                    case "Mike_Scenario":
                        return typeof(ReportMike_ScenarioModel);
                    case "Mike_Scenario_Special_Result_KML":
                        return typeof(ReportMike_Scenario_Special_Result_KMLModel);
                    case "Mike_Source":
                        return typeof(ReportMike_SourceModel);
                    case "Mike_Source_Start_End":
                        return typeof(ReportMike_Source_Start_EndModel);
                    case "Mike_Boundary_Condition":
                        return typeof(ReportMike_Boundary_ConditionModel);
                    case "Mike_Scenario_File":
                        return typeof(ReportMike_Scenario_FileModel);
                    case "Municipality_Contact":
                        return typeof(ReportMunicipality_ContactModel);
                    case "Municipality_Contact_Address":
                        return typeof(ReportMunicipality_Contact_AddressModel);
                    case "Municipality_Contact_Tel":
                        return typeof(ReportMunicipality_Contact_TelModel);
                    case "Municipality_Contact_Email":
                        return typeof(ReportMunicipality_Contact_EmailModel);
                    case "Municipality_File":
                        return typeof(ReportMunicipality_FileModel);
                    case "Subsector_Climate_Site":
                        return typeof(ReportSubsector_Climate_SiteModel);
                    case "Subsector_Climate_Site_Data":
                        return typeof(ReportSubsector_Climate_Site_DataModel);
                    case "Subsector_Hydrometric_Site":
                        return typeof(ReportSubsector_Hydrometric_SiteModel);
                    case "Subsector_Hydrometric_Site_Data":
                        return typeof(ReportSubsector_Hydrometric_Site_DataModel);
                    case "Subsector_Hydrometric_Site_Rating_Curve":
                        return typeof(ReportSubsector_Hydrometric_Site_Rating_CurveModel);
                    case "Subsector_Hydrometric_Site_Rating_Curve_Value":
                        return typeof(ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModel);
                    case "Subsector_Special_Table":
                        return typeof(ReportSubsector_Special_TableModel);
                    case "Subsector_Tide_Site":
                        return typeof(ReportSubsector_Tide_SiteModel);
                    case "Subsector_Tide_Site_Data":
                        return typeof(ReportSubsector_Tide_Site_DataModel);
                    case "Subsector_Lab_Sheet":
                        return typeof(ReportSubsector_Lab_SheetModel);
                    case "Subsector_Lab_Sheet_Detail":
                        return typeof(ReportSubsector_Lab_Sheet_DetailModel);
                    case "Subsector_Lab_Sheet_Tube_And_MPN_Detail":
                        return typeof(ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel);
                    case "Subsector_File":
                        return typeof(ReportSubsector_FileModel);
                    case "Sector_File":
                        return typeof(ReportSector_FileModel);
                    case "Area_File":
                        return typeof(ReportArea_FileModel);
                    case "Sampling_Plan":
                        return typeof(ReportSampling_PlanModel);
                    case "Sampling_Plan_Lab_Sheet":
                        return typeof(ReportSampling_Plan_Lab_SheetModel);
                    case "Sampling_Plan_Lab_Sheet_Detail":
                        return typeof(ReportSampling_Plan_Lab_Sheet_DetailModel);
                    case "Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail":
                        return typeof(ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel);
                    case "Sampling_Plan_Subsector":
                        return typeof(ReportSampling_Plan_SubsectorModel);
                    case "Sampling_Plan_Subsector_Site":
                        return typeof(ReportSampling_Plan_Subsector_SiteModel);
                    case "Climate_Site":
                        return typeof(ReportClimate_SiteModel);
                    case "Climate_Site_Data":
                        return typeof(ReportClimate_Site_DataModel);
                    case "Hydrometric_Site":
                        return typeof(ReportHydrometric_SiteModel);
                    case "Hydrometric_Site_Data":
                        return typeof(ReportHydrometric_Site_DataModel);
                    case "Hydrometric_Site_Rating_Curve":
                        return typeof(ReportHydrometric_Site_Rating_CurveModel);
                    case "Hydrometric_Site_Rating_Curve_Value":
                        return typeof(ReportHydrometric_Site_Rating_Curve_ValueModel);
                    case "Province_File":
                        return typeof(ReportProvince_FileModel);
                    case "Country_File":
                        return typeof(ReportCountry_FileModel);
                    case "MPN_Lookup":
                        return typeof(ReportMPN_LookupModel);
                    case "Root_File":
                        return typeof(ReportRoot_FileModel);
                default:
                    return null;
            }
        }
    }
    public class ReportRootModel
    {
        public ReportRootModel()
        {
            Root_Error = "";
        }
    
        public string Root_Error { get; set; }
        public Nullable<int> Root_Counter { get; set; }
        public Nullable<int> Root_ID { get; set; }
        public Nullable<TranslationStatusEnum> Root_Name_Translation_Status { get; set; }
        public string Root_Name { get; set; }
        public Nullable<bool> Root_Is_Active { get; set; }
        public Nullable<DateTime> Root_Last_Update_Date_And_Time_UTC { get; set; }
        public string Root_Last_Update_Contact_Name { get; set; }
        public string Root_Last_Update_Contact_Initial { get; set; }
        public Nullable<float> Root_Lat { get; set; }
        public Nullable<float> Root_Lng { get; set; }
        public Nullable<int> Root_Stat_Country_Count { get; set; }
        public Nullable<int> Root_Stat_Province_Count { get; set; }
        public Nullable<int> Root_Stat_Area_Count { get; set; }
        public Nullable<int> Root_Stat_Sector_Count { get; set; }
        public Nullable<int> Root_Stat_Subsector_Count { get; set; }
        public Nullable<int> Root_Stat_Municipality_Count { get; set; }
        public Nullable<int> Root_Stat_Lift_Station_Count { get; set; }
        public Nullable<int> Root_Stat_WWTP_Count { get; set; }
        public Nullable<int> Root_Stat_MWQM_Sample_Count { get; set; }
        public Nullable<int> Root_Stat_MWQM_Site_Count { get; set; }
        public Nullable<int> Root_Stat_MWQM_Run_Count { get; set; }
        public Nullable<int> Root_Stat_Pol_Source_Site_Count { get; set; }
        public Nullable<int> Root_Stat_Mike_Scenario_Count { get; set; }
        public Nullable<int> Root_Stat_Box_Model_Scenario_Count { get; set; }
        public Nullable<int> Root_Stat_Visual_Plumes_Scenario_Count { get; set; }
    }
    public class ReportCountryModel
    {
        public ReportCountryModel()
        {
            Country_Error = "";
        }
    
        public string Country_Error { get; set; }
        public Nullable<int> Country_Counter { get; set; }
        public Nullable<int> Country_ID { get; set; }
        public Nullable<TranslationStatusEnum> Country_Name_Translation_Status { get; set; }
        public string Country_Name { get; set; }
        public string Country_Initial { get; set; }
        public Nullable<bool> Country_Is_Active { get; set; }
        public Nullable<DateTime> Country_Last_Update_Date_And_Time_UTC { get; set; }
        public string Country_Last_Update_Contact_Name { get; set; }
        public string Country_Last_Update_Contact_Initial { get; set; }
        public Nullable<float> Country_Lat { get; set; }
        public Nullable<float> Country_Lng { get; set; }
        public Nullable<int> Country_Stat_Province_Count { get; set; }
        public Nullable<int> Country_Stat_Area_Count { get; set; }
        public Nullable<int> Country_Stat_Sector_Count { get; set; }
        public Nullable<int> Country_Stat_Subsector_Count { get; set; }
        public Nullable<int> Country_Stat_Municipality_Count { get; set; }
        public Nullable<int> Country_Stat_Lift_Station_Count { get; set; }
        public Nullable<int> Country_Stat_WWTP_Count { get; set; }
        public Nullable<int> Country_Stat_MWQM_Sample_Count { get; set; }
        public Nullable<int> Country_Stat_MWQM_Site_Count { get; set; }
        public Nullable<int> Country_Stat_MWQM_Run_Count { get; set; }
        public Nullable<int> Country_Stat_Pol_Source_Site_Count { get; set; }
        public Nullable<int> Country_Stat_Mike_Scenario_Count { get; set; }
        public Nullable<int> Country_Stat_Box_Model_Scenario_Count { get; set; }
        public Nullable<int> Country_Stat_Visual_Plumes_Scenario_Count { get; set; }
    }
    public class ReportProvinceModel
    {
        public ReportProvinceModel()
        {
            Province_Error = "";
        }
    
        public string Province_Error { get; set; }
        public Nullable<int> Province_Counter { get; set; }
        public Nullable<int> Province_ID { get; set; }
        public Nullable<TranslationStatusEnum> Province_Name_Translation_Status { get; set; }
        public string Province_Name { get; set; }
        public string Province_Initial { get; set; }
        public Nullable<bool> Province_Is_Active { get; set; }
        public Nullable<DateTime> Province_Last_Update_Date_And_Time_UTC { get; set; }
        public string Province_Last_Update_Contact_Name { get; set; }
        public string Province_Last_Update_Contact_Initial { get; set; }
        public Nullable<float> Province_Lat { get; set; }
        public Nullable<float> Province_Lng { get; set; }
        public Nullable<int> Province_Stat_Area_Count { get; set; }
        public Nullable<int> Province_Stat_Sector_Count { get; set; }
        public Nullable<int> Province_Stat_Subsector_Count { get; set; }
        public Nullable<int> Province_Stat_Municipality_Count { get; set; }
        public Nullable<int> Province_Stat_Lift_Station_Count { get; set; }
        public Nullable<int> Province_Stat_WWTP_Count { get; set; }
        public Nullable<int> Province_Stat_MWQM_Sample_Count { get; set; }
        public Nullable<int> Province_Stat_MWQM_Site_Count { get; set; }
        public Nullable<int> Province_Stat_MWQM_Run_Count { get; set; }
        public Nullable<int> Province_Stat_Pol_Source_Site_Count { get; set; }
        public Nullable<int> Province_Stat_Mike_Scenario_Count { get; set; }
        public Nullable<int> Province_Stat_Box_Model_Scenario_Count { get; set; }
        public Nullable<int> Province_Stat_Visual_Plumes_Scenario_Count { get; set; }
    }
    public class ReportAreaModel
    {
        public ReportAreaModel()
        {
            Area_Error = "";
        }
    
        public string Area_Error { get; set; }
        public Nullable<int> Area_Counter { get; set; }
        public Nullable<int> Area_ID { get; set; }
        public Nullable<TranslationStatusEnum> Area_Name_Translation_Status { get; set; }
        public string Area_Name_Short { get; set; }
        public string Area_Name_Long { get; set; }
        public Nullable<bool> Area_Is_Active { get; set; }
        public Nullable<DateTime> Area_Last_Update_Date_And_Time_UTC { get; set; }
        public string Area_Last_Update_Contact_Name { get; set; }
        public string Area_Last_Update_Contact_Initial { get; set; }
        public Nullable<float> Area_Lat { get; set; }
        public Nullable<float> Area_Lng { get; set; }
        public Nullable<int> Area_Stat_Sector_Count { get; set; }
        public Nullable<int> Area_Stat_Subsector_Count { get; set; }
        public Nullable<int> Area_Stat_Municipality_Count { get; set; }
        public Nullable<int> Area_Stat_Lift_Station_Count { get; set; }
        public Nullable<int> Area_Stat_WWTP_Count { get; set; }
        public Nullable<int> Area_Stat_MWQM_Sample_Count { get; set; }
        public Nullable<int> Area_Stat_MWQM_Site_Count { get; set; }
        public Nullable<int> Area_Stat_MWQM_Run_Count { get; set; }
        public Nullable<int> Area_Stat_Pol_Source_Site_Count { get; set; }
        public Nullable<int> Area_Stat_Mike_Scenario_Count { get; set; }
        public Nullable<int> Area_Stat_Box_Model_Scenario_Count { get; set; }
        public Nullable<int> Area_Stat_Visual_Plumes_Scenario_Count { get; set; }
    }
    public class ReportSectorModel
    {
        public ReportSectorModel()
        {
            Sector_Error = "";
        }
    
        public string Sector_Error { get; set; }
        public Nullable<int> Sector_Counter { get; set; }
        public Nullable<int> Sector_ID { get; set; }
        public Nullable<TranslationStatusEnum> Sector_Name_Translation_Status { get; set; }
        public string Sector_Name_Short { get; set; }
        public string Sector_Name_Long { get; set; }
        public Nullable<bool> Sector_Is_Active { get; set; }
        public Nullable<DateTime> Sector_Last_Update_Date_And_Time_UTC { get; set; }
        public string Sector_Last_Update_Contact_Name { get; set; }
        public string Sector_Last_Update_Contact_Initial { get; set; }
        public Nullable<float> Sector_Lat { get; set; }
        public Nullable<float> Sector_Lng { get; set; }
        public Nullable<int> Sector_Stat_Subsector_Count { get; set; }
        public Nullable<int> Sector_Stat_Municipality_Count { get; set; }
        public Nullable<int> Sector_Stat_Lift_Station_Count { get; set; }
        public Nullable<int> Sector_Stat_WWTP_Count { get; set; }
        public Nullable<int> Sector_Stat_MWQM_Sample_Count { get; set; }
        public Nullable<int> Sector_Stat_MWQM_Site_Count { get; set; }
        public Nullable<int> Sector_Stat_MWQM_Run_Count { get; set; }
        public Nullable<int> Sector_Stat_Pol_Source_Site_Count { get; set; }
        public Nullable<int> Sector_Stat_Mike_Scenario_Count { get; set; }
        public Nullable<int> Sector_Stat_Box_Model_Scenario_Count { get; set; }
        public Nullable<int> Sector_Stat_Visual_Plumes_Scenario_Count { get; set; }
    }
    public class ReportSubsectorModel
    {
        public ReportSubsectorModel()
        {
            Subsector_Error = "";
        }
    
        public string Subsector_Error { get; set; }
        public Nullable<int> Subsector_Counter { get; set; }
        public Nullable<int> Subsector_ID { get; set; }
        public Nullable<TranslationStatusEnum> Subsector_Name_Translation_Status { get; set; }
        public string Subsector_Name_Short { get; set; }
        public string Subsector_Name_Long { get; set; }
        public Nullable<bool> Subsector_Is_Active { get; set; }
        public Nullable<DateTime> Subsector_Last_Update_Date_And_Time_UTC { get; set; }
        public string Subsector_Last_Update_Contact_Name { get; set; }
        public string Subsector_Last_Update_Contact_Initial { get; set; }
        public Nullable<float> Subsector_Lat { get; set; }
        public Nullable<float> Subsector_Lng { get; set; }
        public Nullable<int> Subsector_Stat_Municipality_Count { get; set; }
        public Nullable<int> Subsector_Stat_Lift_Station_Count { get; set; }
        public Nullable<int> Subsector_Stat_WWTP_Count { get; set; }
        public Nullable<int> Subsector_Stat_MWQM_Sample_Count { get; set; }
        public Nullable<int> Subsector_Stat_MWQM_Site_Count { get; set; }
        public Nullable<int> Subsector_Stat_MWQM_Run_Count { get; set; }
        public Nullable<int> Subsector_Stat_Pol_Source_Site_Count { get; set; }
        public Nullable<int> Subsector_Stat_Mike_Scenario_Count { get; set; }
        public Nullable<int> Subsector_Stat_Box_Model_Scenario_Count { get; set; }
        public Nullable<int> Subsector_Stat_Visual_Plumes_Scenario_Count { get; set; }
    }
    public class ReportMWQM_SiteModel
    {
        public ReportMWQM_SiteModel()
        {
            MWQM_Site_Error = "";
        }
    
        public string MWQM_Site_Error { get; set; }
        public Nullable<int> MWQM_Site_Counter { get; set; }
        public Nullable<int> MWQM_Site_ID { get; set; }
        public Nullable<TranslationStatusEnum> MWQM_Site_Name_Translation_Status { get; set; }
        public string MWQM_Site_Name { get; set; }
        public Nullable<bool> MWQM_Site_Is_Active { get; set; }
        public string MWQM_Site_Number { get; set; }
        public string MWQM_Site_Description { get; set; }
        public Nullable<MWQMSiteLatestClassificationEnum> MWQM_Site_Latest_Classification { get; set; }
        public Nullable<int> MWQM_Site_Ordinal { get; set; }
        public Nullable<DateTime> MWQM_Site_Last_Update_Date_And_Time_UTC { get; set; }
        public string MWQM_Site_Last_Update_Contact_Name { get; set; }
        public string MWQM_Site_Last_Update_Contact_Initial { get; set; }
        public Nullable<float> MWQM_Site_Lat { get; set; }
        public Nullable<float> MWQM_Site_Lng { get; set; }
        public Nullable<int> MWQM_Site_Stat_MWQM_Run_Count { get; set; }
        public Nullable<int> MWQM_Site_Stat_MWQM_Sample_Count { get; set; }
        public Nullable<int> MWQM_Site_Stat_X_Last_Samples { get; set; }
        public Nullable<float> MWQM_Site_Stat_GM_X_Last_Samples { get; set; }
        public Nullable<float> MWQM_Site_Stat_Median_X_Last_Samples { get; set; }
        public Nullable<float> MWQM_Site_Stat_P90_X_Last_Samples { get; set; }
        public Nullable<float> MWQM_Site_Stat_Perc_Over_43_X_Last_Samples { get; set; }
        public Nullable<float> MWQM_Site_Stat_Perc_Over_260_X_Last_Samples { get; set; }
        public Nullable<int> MWQM_Site_Stat_Min_FC_X_Last_Samples { get; set; }
        public Nullable<int> MWQM_Site_Stat_Max_FC_X_Last_Samples { get; set; }
        public Nullable<int> MWQM_Site_Stat_Min_Year_X_Last_Samples { get; set; }
        public Nullable<int> MWQM_Site_Stat_Max_Year_X_Last_Samples { get; set; }
        public Nullable<int> MWQM_Site_Stat_Sample_Count_X_Last_Samples { get; set; }
    }
    public class ReportMWQM_Site_SampleModel
    {
        public ReportMWQM_Site_SampleModel()
        {
            MWQM_Site_Sample_Error = "";
        }
    
        public string MWQM_Site_Sample_Error { get; set; }
        public Nullable<int> MWQM_Site_Sample_Counter { get; set; }
        public Nullable<int> MWQM_Site_Sample_ID { get; set; }
        public Nullable<DateTime> MWQM_Site_Sample_Date_Time_Local { get; set; }
        public Nullable<float> MWQM_Site_Sample_Depth_m { get; set; }
        public Nullable<int> MWQM_Site_Sample_Fec_Col_MPN_100_ml { get; set; }
        public Nullable<float> MWQM_Site_Sample_Salinity_PPT { get; set; }
        public Nullable<float> MWQM_Site_Sample_Water_Temp_C { get; set; }
        public Nullable<float> MWQM_Site_Sample_PH { get; set; }
        public string MWQM_Site_Sample_Types { get; set; }
        public Nullable<int> MWQM_Site_Sample_Tube_10 { get; set; }
        public Nullable<int> MWQM_Site_Sample_Tube_1_0 { get; set; }
        public Nullable<int> MWQM_Site_Sample_Tube_0_1 { get; set; }
        public string MWQM_Site_Sample_Processed_By { get; set; }
        public Nullable<TranslationStatusEnum> MWQM_Site_Sample_Note_Translation_Status { get; set; }
        public string MWQM_Site_Sample_Note { get; set; }
        public Nullable<DateTime> MWQM_Site_Sample_Last_Update_Date_And_Time_UTC { get; set; }
        public string MWQM_Site_Sample_Last_Update_Contact_Name { get; set; }
        public string MWQM_Site_Sample_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportMWQM_Site_Start_And_End_DateModel
    {
        public ReportMWQM_Site_Start_And_End_DateModel()
        {
            MWQM_Site_Start_And_End_Date_Error = "";
        }
    
        public string MWQM_Site_Start_And_End_Date_Error { get; set; }
        public Nullable<int> MWQM_Site_Start_And_End_Date_Counter { get; set; }
        public Nullable<int> MWQM_Site_Start_And_End_Date_ID { get; set; }
        public Nullable<DateTime> MWQM_Site_Start_And_End_Date_Start_Date { get; set; }
        public Nullable<DateTime> MWQM_Site_Start_And_End_Date_End_Date { get; set; }
        public Nullable<DateTime> MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC { get; set; }
        public string MWQM_Site_Start_And_End_Date_Last_Update_Contact_Name { get; set; }
        public string MWQM_Site_Start_And_End_Date_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportMWQM_Site_FileModel
    {
        public ReportMWQM_Site_FileModel()
        {
            MWQM_Site_File_Error = "";
        }
    
        public string MWQM_Site_File_Error { get; set; }
        public Nullable<int> MWQM_Site_File_Counter { get; set; }
        public Nullable<int> MWQM_Site_File_ID { get; set; }
        public Nullable<LanguageEnum> MWQM_Site_File_Language { get; set; }
        public Nullable<FilePurposeEnum> MWQM_Site_File_Purpose { get; set; }
        public Nullable<FileTypeEnum> MWQM_Site_File_Type { get; set; }
        public string MWQM_Site_File_Description { get; set; }
        public Nullable<int> MWQM_Site_File_Size_kb { get; set; }
        public string MWQM_Site_File_Info { get; set; }
        public Nullable<DateTime> MWQM_Site_File_Created_Date_UTC { get; set; }
        public Nullable<bool> MWQM_Site_File_From_Water { get; set; }
        public string MWQM_Site_File_Server_File_Name { get; set; }
        public string MWQM_Site_File_Server_File_Path { get; set; }
        public Nullable<DateTime> MWQM_Site_File_Last_Update_Date_And_Time_UTC { get; set; }
        public string MWQM_Site_File_Last_Update_Contact_Name { get; set; }
        public string MWQM_Site_File_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportMWQM_RunModel
    {
        public ReportMWQM_RunModel()
        {
            MWQM_Run_Error = "";
        }
    
        public string MWQM_Run_Error { get; set; }
        public Nullable<int> MWQM_Run_Counter { get; set; }
        public Nullable<int> MWQM_Run_ID { get; set; }
        public Nullable<TranslationStatusEnum> MWQM_Run_Name_Translation_Status { get; set; }
        public string MWQM_Run_Name { get; set; }
        public Nullable<bool> MWQM_Run_Is_Active { get; set; }
        public Nullable<DateTime> MWQM_Run_Date_Time_Local { get; set; }
        public Nullable<DateTime> MWQM_Run_Start_Date_Time_Local { get; set; }
        public Nullable<DateTime> MWQM_Run_End_Date_Time_Local { get; set; }
        public Nullable<DateTime> MWQM_Run_Lab_Received_Date_Time_Local { get; set; }
        public Nullable<float> MWQM_Run_Temperature_Control_1_C { get; set; }
        public Nullable<float> MWQM_Run_Temperature_Control_2_C { get; set; }
        public Nullable<BeaufortScaleEnum> MWQM_Run_Sea_State_At_Start_Beaufort_Scale { get; set; }
        public Nullable<BeaufortScaleEnum> MWQM_Run_Sea_State_At_End_Beaufort_Scale { get; set; }
        public Nullable<float> MWQM_Run_Water_Level_At_Brook_m { get; set; }
        public Nullable<float> MWQM_Run_Wave_Hight_At_Start_m { get; set; }
        public Nullable<float> MWQM_Run_Wave_Hight_At_End_m { get; set; }
        public string MWQM_Run_Sample_Crew_Initials { get; set; }
        public Nullable<AnalyzeMethodEnum> MWQM_Run_Analyze_Method { get; set; }
        public Nullable<SampleMatrixEnum> MWQM_Run_Sample_Matrix { get; set; }
        public Nullable<LaboratoryEnum> MWQM_Run_Laboratory { get; set; }
        public Nullable<SampleStatusEnum> MWQM_Run_Sample_Status { get; set; }
        public string MWQM_Run_Lab_Sample_Approval_Contact_Name { get; set; }
        public string MWQM_Run_Lab_Sample_Approval_Contact_Initial { get; set; }
        public Nullable<DateTime> MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local { get; set; }
        public Nullable<DateTime> MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local { get; set; }
        public Nullable<DateTime> MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local { get; set; }
        public Nullable<DateTime> MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local { get; set; }
        public Nullable<float> MWQM_Run_Rain_Day_0_mm { get; set; }
        public Nullable<float> MWQM_Run_Rain_Day_1_mm { get; set; }
        public Nullable<float> MWQM_Run_Rain_Day_2_mm { get; set; }
        public Nullable<float> MWQM_Run_Rain_Day_3_mm { get; set; }
        public Nullable<float> MWQM_Run_Rain_Day_4_mm { get; set; }
        public Nullable<float> MWQM_Run_Rain_Day_5_mm { get; set; }
        public Nullable<float> MWQM_Run_Rain_Day_6_mm { get; set; }
        public Nullable<float> MWQM_Run_Rain_Day_7_mm { get; set; }
        public Nullable<float> MWQM_Run_Rain_Day_8_mm { get; set; }
        public Nullable<float> MWQM_Run_Rain_Day_9_mm { get; set; }
        public Nullable<float> MWQM_Run_Rain_Day_10_mm { get; set; }
        public Nullable<TranslationStatusEnum> MWQM_Run_Comment_Translation_Status { get; set; }
        public string MWQM_Run_Comment { get; set; }
        public Nullable<TranslationStatusEnum> MWQM_Run_Weather_Comment_Translation_Status { get; set; }
        public string MWQM_Run_Weather_Comment { get; set; }
        public Nullable<DateTime> MWQM_Run_Last_Update_Date_And_Time_UTC { get; set; }
        public string MWQM_Run_Last_Update_Contact_Name { get; set; }
        public string MWQM_Run_Last_Update_Contact_Initial { get; set; }
        public Nullable<int> MWQM_Run_Stat_MWQM_Site_Count { get; set; }
        public Nullable<int> MWQM_Run_Stat_Sample_Count { get; set; }
    }
    public class ReportMWQM_Run_SampleModel
    {
        public ReportMWQM_Run_SampleModel()
        {
            MWQM_Run_Sample_Error = "";
        }
    
        public string MWQM_Run_Sample_Error { get; set; }
        public Nullable<int> MWQM_Run_Sample_Counter { get; set; }
        public Nullable<int> MWQM_Run_Sample_ID { get; set; }
        public Nullable<DateTime> MWQM_Run_Sample_Date_Time_Local { get; set; }
        public string MWQM_Run_Sample_MWQM_Site { get; set; }
        public Nullable<float> MWQM_Run_Sample_Depth_m { get; set; }
        public Nullable<int> MWQM_Run_Sample_Fec_Col_MPN_100_ml { get; set; }
        public Nullable<float> MWQM_Run_Sample_Salinity_PPT { get; set; }
        public Nullable<float> MWQM_Run_Sample_Water_Temp_C { get; set; }
        public Nullable<float> MWQM_Run_Sample_PH { get; set; }
        public string MWQM_Run_Sample_Types { get; set; }
        public Nullable<int> MWQM_Run_Sample_Tube_10 { get; set; }
        public Nullable<int> MWQM_Run_Sample_Tube_1_0 { get; set; }
        public Nullable<int> MWQM_Run_Sample_Tube_0_1 { get; set; }
        public string MWQM_Run_Sample_Processed_By { get; set; }
        public Nullable<TranslationStatusEnum> MWQM_Run_Sample_Note_Translation_Status { get; set; }
        public string MWQM_Run_Sample_Note { get; set; }
        public Nullable<DateTime> MWQM_Run_Sample_Last_Update_Date_And_Time_UTC { get; set; }
        public string MWQM_Run_Sample_Last_Update_Contact_Name { get; set; }
        public string MWQM_Run_Sample_Last_Update_Contact_Initial { get; set; }
        public Nullable<float> MWQM_Run_Sample_Rain_Day_0_mm { get; set; }
        public Nullable<float> MWQM_Run_Sample_Rain_Day_1_mm { get; set; }
        public Nullable<float> MWQM_Run_Sample_Rain_Day_2_mm { get; set; }
        public Nullable<float> MWQM_Run_Sample_Rain_Day_3_mm { get; set; }
        public Nullable<float> MWQM_Run_Sample_Rain_Day_4_mm { get; set; }
        public Nullable<float> MWQM_Run_Sample_Rain_Day_5_mm { get; set; }
        public Nullable<float> MWQM_Run_Sample_Rain_Day_6_mm { get; set; }
        public Nullable<float> MWQM_Run_Sample_Rain_Day_7_mm { get; set; }
        public Nullable<float> MWQM_Run_Sample_Rain_Day_8_mm { get; set; }
        public Nullable<float> MWQM_Run_Sample_Rain_Day_9_mm { get; set; }
        public Nullable<float> MWQM_Run_Sample_Rain_Day_10_mm { get; set; }
        public Nullable<TideTextEnum> MWQM_Run_Sample_Tide_Start { get; set; }
        public Nullable<TideTextEnum> MWQM_Run_Sample_Tide_End { get; set; }
    }
    public class ReportMWQM_Run_Lab_SheetModel
    {
        public ReportMWQM_Run_Lab_SheetModel()
        {
            MWQM_Run_Lab_Sheet_Error = "";
        }
    
        public string MWQM_Run_Lab_Sheet_Error { get; set; }
        public Nullable<int> MWQM_Run_Lab_Sheet_Counter { get; set; }
        public Nullable<int> MWQM_Run_Lab_Sheet_ID { get; set; }
        public Nullable<int> MWQM_Run_Lab_Sheet_Other_Server_Lab_Sheet_ID { get; set; }
        public string MWQM_Run_Lab_Sheet_Sampling_Plan_Name { get; set; }
        public string MWQM_Run_Lab_Sheet_Province { get; set; }
        public string MWQM_Run_Lab_Sheet_For_Group_Name { get; set; }
        public Nullable<int> MWQM_Run_Lab_Sheet_Year { get; set; }
        public Nullable<int> MWQM_Run_Lab_Sheet_Month { get; set; }
        public Nullable<int> MWQM_Run_Lab_Sheet_Day { get; set; }
        public string MWQM_Run_Lab_Sheet_Access_Code { get; set; }
        public Nullable<float> MWQM_Run_Lab_Sheet_Daily_Duplicate_Precision_Criteria { get; set; }
        public Nullable<float> MWQM_Run_Lab_Sheet_Intertech_Duplicate_Precision_Criteria { get; set; }
        public string MWQM_Run_Lab_Sheet_Subsector_Name_Short { get; set; }
        public string MWQM_Run_Lab_Sheet_Subsector_Name_Long { get; set; }
        public string MWQM_Run_Lab_Sheet_MWQM_Run_Name { get; set; }
        public Nullable<SamplingPlanTypeEnum> MWQM_Run_Lab_Sheet_Sampling_Plan_Type { get; set; }
        public string MWQM_Run_Lab_Sheet_Sample_Type { get; set; }
        public Nullable<LabSheetTypeEnum> MWQM_Run_Lab_Sheet_Type { get; set; }
        public Nullable<LabSheetStatusEnum> MWQM_Run_Lab_Sheet_Status { get; set; }
        public string MWQM_Run_Lab_Sheet_File_Name { get; set; }
        public Nullable<DateTime> MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local { get; set; }
        public string MWQM_Run_Lab_Sheet_File_Content { get; set; }
        public string MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name { get; set; }
        public string MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial { get; set; }
        public Nullable<DateTime> MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time { get; set; }
        public Nullable<DateTime> MWQM_Run_Lab_Sheet_Last_Update_Date_UTC { get; set; }
        public string MWQM_Run_Lab_Sheet_Last_Update_Contact_Name { get; set; }
        public string MWQM_Run_Lab_Sheet_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportMWQM_Run_Lab_Sheet_DetailModel
    {
        public ReportMWQM_Run_Lab_Sheet_DetailModel()
        {
            MWQM_Run_Lab_Sheet_Detail_Error = "";
        }
    
        public string MWQM_Run_Lab_Sheet_Detail_Error { get; set; }
        public Nullable<int> MWQM_Run_Lab_Sheet_Detail_Counter { get; set; }
        public Nullable<int> MWQM_Run_Lab_Sheet_Detail_ID { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Version { get; set; }
        public Nullable<DateTime> MWQM_Run_Lab_Sheet_Detail_Run_Date { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Tides { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Sample_Crew_Initials { get; set; }
        public Nullable<DateTime> MWQM_Run_Lab_Sheet_Detail_Incubation_Bath1_Start_Time { get; set; }
        public Nullable<DateTime> MWQM_Run_Lab_Sheet_Detail_Incubation_Bath2_Start_Time { get; set; }
        public Nullable<DateTime> MWQM_Run_Lab_Sheet_Detail_Incubation_Bath3_Start_Time { get; set; }
        public Nullable<DateTime> MWQM_Run_Lab_Sheet_Detail_Incubation_Bath1_End_Time { get; set; }
        public Nullable<DateTime> MWQM_Run_Lab_Sheet_Detail_Incubation_Bath2_End_Time { get; set; }
        public Nullable<DateTime> MWQM_Run_Lab_Sheet_Detail_Incubation_Bath3_End_Time { get; set; }
        public Nullable<int> MWQM_Run_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes { get; set; }
        public Nullable<int> MWQM_Run_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes { get; set; }
        public Nullable<int> MWQM_Run_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Water_Bath1 { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Water_Bath2 { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Water_Bath3 { get; set; }
        public Nullable<float> MWQM_Run_Lab_Sheet_Detail_TC_Field_1 { get; set; }
        public Nullable<float> MWQM_Run_Lab_Sheet_Detail_TC_Lab_1 { get; set; }
        public Nullable<float> MWQM_Run_Lab_Sheet_Detail_TC_Field_2 { get; set; }
        public Nullable<float> MWQM_Run_Lab_Sheet_Detail_TC_Lab_2 { get; set; }
        public Nullable<float> MWQM_Run_Lab_Sheet_Detail_TC_First { get; set; }
        public Nullable<float> MWQM_Run_Lab_Sheet_Detail_TC_Average { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Control_Lot { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Positive_35 { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Non_Target_35 { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Negative_35 { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Bath1_Positive_44_5 { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Bath2_Positive_44_5 { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Bath3_Positive_44_5 { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Bath1_Non_Target_44_5 { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Bath2_Non_Target_44_5 { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Bath3_Non_Target_44_5 { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Bath1_Negative_44_5 { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Bath2_Negative_44_5 { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Bath3_Negative_44_5 { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Blank_35 { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Bath1_Blank_44_5 { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Bath2_Blank_44_5 { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Bath3_Blank_44_5 { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Lot_35 { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Lot_44_5 { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Run_Comment { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Run_Weather_Comment { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Sample_Bottle_Lot_Number { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Salinities_Read_By { get; set; }
        public Nullable<DateTime> MWQM_Run_Lab_Sheet_Detail_Salinities_Read_Date { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Results_Read_By { get; set; }
        public Nullable<DateTime> MWQM_Run_Lab_Sheet_Detail_Results_Read_Date { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Results_Recorded_By { get; set; }
        public Nullable<DateTime> MWQM_Run_Lab_Sheet_Detail_Results_Recorded_Date { get; set; }
        public Nullable<float> MWQM_Run_Lab_Sheet_Detail_Daily_Duplicate_R_Log { get; set; }
        public Nullable<float> MWQM_Run_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria { get; set; }
        public Nullable<bool> MWQM_Run_Lab_Sheet_Detail_Daily_Duplicate_Acceptable { get; set; }
        public Nullable<float> MWQM_Run_Lab_Sheet_Detail_Intertech_Duplicate_R_Log { get; set; }
        public Nullable<float> MWQM_Run_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria { get; set; }
        public Nullable<bool> MWQM_Run_Lab_Sheet_Detail_Intertech_Duplicate_Acceptable { get; set; }
        public Nullable<bool> MWQM_Run_Lab_Sheet_Detail_Intertech_Read_Acceptable { get; set; }
        public Nullable<DateTime> MWQM_Run_Lab_Sheet_Detail_Last_Update_Date_UTC { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Last_Update_Contact_Name { get; set; }
        public string MWQM_Run_Lab_Sheet_Detail_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel
    {
        public ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel()
        {
            MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Error = "";
        }
    
        public string MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Error { get; set; }
        public Nullable<int> MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Counter { get; set; }
        public Nullable<int> MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_ID { get; set; }
        public Nullable<int> MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Ordinal { get; set; }
        public string MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site { get; set; }
        public Nullable<DateTime> MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time { get; set; }
        public Nullable<int> MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MPN { get; set; }
        public Nullable<int> MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_10 { get; set; }
        public Nullable<int> MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0 { get; set; }
        public Nullable<int> MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1 { get; set; }
        public Nullable<float> MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Salinity { get; set; }
        public Nullable<float> MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Temperature { get; set; }
        public string MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Processed_By { get; set; }
        public string MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type { get; set; }
        public string MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment { get; set; }
        public Nullable<DateTime> MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC { get; set; }
        public string MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name { get; set; }
        public string MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportMWQM_Run_FileModel
    {
        public ReportMWQM_Run_FileModel()
        {
            MWQM_Run_File_Error = "";
        }
    
        public string MWQM_Run_File_Error { get; set; }
        public Nullable<int> MWQM_Run_File_Counter { get; set; }
        public Nullable<int> MWQM_Run_File_ID { get; set; }
        public Nullable<LanguageEnum> MWQM_Run_File_Language { get; set; }
        public Nullable<FilePurposeEnum> MWQM_Run_File_Purpose { get; set; }
        public Nullable<FileTypeEnum> MWQM_Run_File_Type { get; set; }
        public string MWQM_Run_File_Description { get; set; }
        public Nullable<int> MWQM_Run_File_Size_kb { get; set; }
        public string MWQM_Run_File_Info { get; set; }
        public Nullable<DateTime> MWQM_Run_File_Created_Date_UTC { get; set; }
        public Nullable<bool> MWQM_Run_File_From_Water { get; set; }
        public string MWQM_Run_File_Server_File_Name { get; set; }
        public string MWQM_Run_File_Server_File_Path { get; set; }
        public Nullable<DateTime> MWQM_Run_File_Last_Update_Date_And_Time_UTC { get; set; }
        public string MWQM_Run_File_Last_Update_Contact_Name { get; set; }
        public string MWQM_Run_File_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportPol_Source_SiteModel
    {
        public ReportPol_Source_SiteModel()
        {
            Pol_Source_Site_Error = "";
        }
    
        public string Pol_Source_Site_Error { get; set; }
        public Nullable<int> Pol_Source_Site_Counter { get; set; }
        public Nullable<int> Pol_Source_Site_ID { get; set; }
        public Nullable<TranslationStatusEnum> Pol_Source_Site_Name_Translation_Status { get; set; }
        public string Pol_Source_Site_Name { get; set; }
        public string Pol_Source_Site_Last_Obs_Issue_Item_Text { get; set; }
        public string Pol_Source_Site_Last_Obs_Issue_Item_Text_First_Initial { get; set; }
        public string Pol_Source_Site_Last_Obs_Issue_Item_Text_Second_Initial { get; set; }
        public string Pol_Source_Site_Last_Obs_Issue_Item_Text_Last_Initial { get; set; }
        public Nullable<int> Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level { get; set; }
        public Nullable<int> Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level { get; set; }
        public string Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text { get; set; }
        public string Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text_Initial { get; set; }
        public string Pol_Source_Site_Last_Obs_Issue_Sentence { get; set; }
        public string Pol_Source_Site_Last_Obs_Issue_Filtering { get; set; }
        public Nullable<bool> Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal { get; set; }
        public Nullable<PolSourceIssueRiskEnum> Pol_Source_Site_Last_Obs_Issue_Risk { get; set; }
        public string Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List { get; set; }
        public Nullable<bool> Pol_Source_Site_Is_Active { get; set; }
        public Nullable<DateTime> Pol_Source_Site_Last_Update_Date_And_Time_UTC { get; set; }
        public string Pol_Source_Site_Last_Update_Contact_Name { get; set; }
        public string Pol_Source_Site_Last_Update_Contact_Initial { get; set; }
        public Nullable<float> Pol_Source_Site_Lat { get; set; }
        public Nullable<float> Pol_Source_Site_Lng { get; set; }
        public Nullable<int> Pol_Source_Site_Old_Site_Id { get; set; }
        public Nullable<int> Pol_Source_Site_Site_ID { get; set; }
        public Nullable<int> Pol_Source_Site_Site { get; set; }
        public Nullable<bool> Pol_Source_Site_Is_Point_Source { get; set; }
        public Nullable<PolSourceInactiveReasonEnum> Pol_Source_Site_Inactive_Reason { get; set; }
        public string Pol_Source_Site_Civic_Address { get; set; }
        public string Pol_Source_Site_Google_Address { get; set; }
    }
    public class ReportPol_Source_Site_ObsModel
    {
        public ReportPol_Source_Site_ObsModel()
        {
            Pol_Source_Site_Obs_Error = "";
        }
    
        public string Pol_Source_Site_Obs_Error { get; set; }
        public Nullable<int> Pol_Source_Site_Obs_Counter { get; set; }
        public Nullable<int> Pol_Source_Site_Obs_ID { get; set; }
        public Nullable<DateTime> Pol_Source_Site_Obs_Observation_Date_Local { get; set; }
        public string Pol_Source_Site_Obs_Inspector_Name { get; set; }
        public string Pol_Source_Site_Obs_Inspector_Initial { get; set; }
        public string Pol_Source_Site_Obs_Observation_To_Be_Deleted { get; set; }
        public Nullable<DateTime> Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC { get; set; }
        public string Pol_Source_Site_Obs_Last_Update_Contact_Name { get; set; }
        public string Pol_Source_Site_Obs_Last_Update_Contact_Initial { get; set; }
        public Nullable<bool> Pol_Source_Site_Obs_Only_Last { get; set; }
    }
    public class ReportPol_Source_Site_Obs_IssueModel
    {
        public ReportPol_Source_Site_Obs_IssueModel()
        {
            Pol_Source_Site_Obs_Issue_Error = "";
        }
    
        public string Pol_Source_Site_Obs_Issue_Error { get; set; }
        public Nullable<int> Pol_Source_Site_Obs_Issue_Counter { get; set; }
        public Nullable<int> Pol_Source_Site_Obs_Issue_ID { get; set; }
        public string Pol_Source_Site_Obs_Issue_Items_Text { get; set; }
        public string Pol_Source_Site_Obs_Issue_Items_Text_First_Initial { get; set; }
        public string Pol_Source_Site_Obs_Issue_Items_Text_Second_Initial { get; set; }
        public string Pol_Source_Site_Obs_Issue_Items_Text_Last_Initial { get; set; }
        public Nullable<int> Pol_Source_Site_Obs_Issue_Items_Text_Start_Level { get; set; }
        public Nullable<int> Pol_Source_Site_Obs_Issue_Items_Text_End_Level { get; set; }
        public string Pol_Source_Site_Obs_Issue_Items_Risk_Text { get; set; }
        public string Pol_Source_Site_Obs_Issue_Items_Risk_Text_Initial { get; set; }
        public string Pol_Source_Site_Obs_Issue_Sentence { get; set; }
        public string Pol_Source_Site_Obs_Issue_Filtering { get; set; }
        public Nullable<bool> Pol_Source_Site_Obs_Issue_Filtering_Reverse_Equal { get; set; }
        public Nullable<PolSourceIssueRiskEnum> Pol_Source_Site_Obs_Issue_Risk { get; set; }
        public string Pol_Source_Site_Obs_Issue_Enum_ID_List { get; set; }
        public Nullable<DateTime> Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC { get; set; }
        public string Pol_Source_Site_Obs_Issue_Last_Update_Contact_Name { get; set; }
        public string Pol_Source_Site_Obs_Issue_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportPol_Source_Site_FileModel
    {
        public ReportPol_Source_Site_FileModel()
        {
            Pol_Source_Site_File_Error = "";
        }
    
        public string Pol_Source_Site_File_Error { get; set; }
        public Nullable<int> Pol_Source_Site_File_Counter { get; set; }
        public Nullable<int> Pol_Source_Site_File_ID { get; set; }
        public Nullable<LanguageEnum> Pol_Source_Site_File_Language { get; set; }
        public Nullable<FilePurposeEnum> Pol_Source_Site_File_Purpose { get; set; }
        public Nullable<FileTypeEnum> Pol_Source_Site_File_Type { get; set; }
        public string Pol_Source_Site_File_Description { get; set; }
        public Nullable<int> Pol_Source_Site_File_Size_kb { get; set; }
        public string Pol_Source_Site_File_Info { get; set; }
        public Nullable<DateTime> Pol_Source_Site_File_Created_Date_UTC { get; set; }
        public Nullable<bool> Pol_Source_Site_File_From_Water { get; set; }
        public string Pol_Source_Site_File_Server_File_Name { get; set; }
        public string Pol_Source_Site_File_Server_File_Path { get; set; }
        public Nullable<DateTime> Pol_Source_Site_File_Last_Update_Date_And_Time_UTC { get; set; }
        public string Pol_Source_Site_File_Last_Update_Contact_Name { get; set; }
        public string Pol_Source_Site_File_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportPol_Source_Site_AddressModel
    {
        public ReportPol_Source_Site_AddressModel()
        {
            Pol_Source_Site_Address_Error = "";
        }
    
        public string Pol_Source_Site_Address_Error { get; set; }
        public Nullable<int> Pol_Source_Site_Address_Counter { get; set; }
        public Nullable<int> Pol_Source_Site_Address_ID { get; set; }
        public Nullable<AddressTypeEnum> Pol_Source_Site_Address_Type { get; set; }
        public string Pol_Source_Site_Address_Country { get; set; }
        public string Pol_Source_Site_Address_Province { get; set; }
        public string Pol_Source_Site_Address_Municipality { get; set; }
        public string Pol_Source_Site_Address_Street_Name { get; set; }
        public string Pol_Source_Site_Address_Street_Number { get; set; }
        public Nullable<StreetTypeEnum> Pol_Source_Site_Address_Street_Type { get; set; }
        public string Pol_Source_Site_Address_Postal_Code { get; set; }
        public string Pol_Source_Site_Address_Google_Address_Text { get; set; }
        public Nullable<DateTime> Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC { get; set; }
        public string Pol_Source_Site_Address_Last_Update_Contact_Name { get; set; }
        public string Pol_Source_Site_Address_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportMunicipalityModel
    {
        public ReportMunicipalityModel()
        {
            Municipality_Error = "";
        }
    
        public string Municipality_Error { get; set; }
        public Nullable<int> Municipality_Counter { get; set; }
        public Nullable<int> Municipality_ID { get; set; }
        public Nullable<TranslationStatusEnum> Municipality_Name_Translation_Status { get; set; }
        public string Municipality_Name { get; set; }
        public Nullable<bool> Municipality_Is_Active { get; set; }
        public Nullable<DateTime> Municipality_Last_Update_Date_And_Time_UTC { get; set; }
        public string Municipality_Last_Update_Contact_Name { get; set; }
        public string Municipality_Last_Update_Contact_Initial { get; set; }
        public Nullable<float> Municipality_Lat { get; set; }
        public Nullable<float> Municipality_Lng { get; set; }
        public Nullable<int> Municipality_Stat_Lift_Station_Count { get; set; }
        public Nullable<int> Municipality_Stat_WWTP_Count { get; set; }
        public Nullable<int> Municipality_Stat_Mike_Scenario_Count { get; set; }
        public Nullable<int> Municipality_Stat_Box_Model_Scenario_Count { get; set; }
        public Nullable<int> Municipality_Stat_Visual_Plumes_Scenario_Count { get; set; }
    }
    public class ReportInfrastructureModel
    {
        public ReportInfrastructureModel()
        {
            Infrastructure_Error = "";
        }
    
        public string Infrastructure_Error { get; set; }
        public Nullable<int> Infrastructure_Counter { get; set; }
        public Nullable<int> Infrastructure_ID { get; set; }
        public string Infrastructure_Name { get; set; }
        public Nullable<TranslationStatusEnum> Infrastructure_Name_Translation_Status { get; set; }
        public Nullable<DateTime> Infrastructure_Last_Update_Date_UTC { get; set; }
        public string Infrastructure_Last_Update_Contact_Name { get; set; }
        public string Infrastructure_Last_Update_Contact_Initial { get; set; }
        public Nullable<bool> Infrastructure_Is_Active { get; set; }
        public Nullable<TranslationStatusEnum> Infrastructure_Comment_Translation_Status { get; set; }
        public Nullable<DateTime> Infrastructure_Comment_Last_Update_Date_UTC { get; set; }
        public string Infrastructure_Comment_Last_Update_Contact_Name { get; set; }
        public string Infrastructure_Comment_Last_Update_Contact_Initial { get; set; }
        public string Infrastructure_Comment { get; set; }
        public Nullable<int> Infrastructure_Prism_ID { get; set; }
        public Nullable<int> Infrastructure_TPID { get; set; }
        public Nullable<int> Infrastructure_LSID { get; set; }
        public Nullable<int> Infrastructure_Site_ID { get; set; }
        public Nullable<int> Infrastructure_Site { get; set; }
        public string Infrastructure_Infrastructure_Category { get; set; }
        public Nullable<InfrastructureTypeEnum> Infrastructure_Infrastructure_Type { get; set; }
        public Nullable<FacilityTypeEnum> Infrastructure_Facility_Type { get; set; }
        public Nullable<bool> Infrastructure_Is_Mechanically_Aerated { get; set; }
        public Nullable<int> Infrastructure_Number_Of_Cells { get; set; }
        public Nullable<int> Infrastructure_Number_Of_Aerated_Cells { get; set; }
        public Nullable<AerationTypeEnum> Infrastructure_Aeration_Type { get; set; }
        public Nullable<PreliminaryTreatmentTypeEnum> Infrastructure_Preliminary_Treatment_Type { get; set; }
        public Nullable<PrimaryTreatmentTypeEnum> Infrastructure_Primary_Treatment_Type { get; set; }
        public Nullable<SecondaryTreatmentTypeEnum> Infrastructure_Secondary_Treatment_Type { get; set; }
        public Nullable<TertiaryTreatmentTypeEnum> Infrastructure_Tertiary_Treatment_Type { get; set; }
        public Nullable<TreatmentTypeEnum> Infrastructure_Treatment_Type { get; set; }
        public Nullable<DisinfectionTypeEnum> Infrastructure_Disinfection_Type { get; set; }
        public Nullable<CollectionSystemTypeEnum> Infrastructure_Collection_System_Type { get; set; }
        public Nullable<AlarmSystemTypeEnum> Infrastructure_Alarm_System_Type { get; set; }
        public Nullable<float> Infrastructure_Design_Flow_m3_day { get; set; }
        public Nullable<float> Infrastructure_Average_Flow_m3_day { get; set; }
        public Nullable<float> Infrastructure_Peak_Flow_m3_day { get; set; }
        public Nullable<int> Infrastructure_Pop_Served { get; set; }
        public Nullable<bool> Infrastructure_Can_Overflow { get; set; }
        public Nullable<float> Infrastructure_Perc_Flow_Of_Total { get; set; }
        public Nullable<float> Infrastructure_Time_Offset_hour { get; set; }
        public string Infrastructure_Temp_Catch_All_Remove_Later { get; set; }
        public Nullable<float> Infrastructure_Average_Depth_m { get; set; }
        public Nullable<int> Infrastructure_Number_Of_Ports { get; set; }
        public Nullable<float> Infrastructure_Port_Diameter_m { get; set; }
        public Nullable<float> Infrastructure_Port_Spacing_m { get; set; }
        public Nullable<float> Infrastructure_Port_Elevation_m { get; set; }
        public Nullable<float> Infrastructure_Vertical_Angle_deg { get; set; }
        public Nullable<float> Infrastructure_Horizontal_Angle_deg { get; set; }
        public Nullable<float> Infrastructure_Decay_Rate_per_day { get; set; }
        public Nullable<float> Infrastructure_Near_Field_Velocity_m_s { get; set; }
        public Nullable<float> Infrastructure_Far_Field_Velocity_m_s { get; set; }
        public Nullable<float> Infrastructure_Receiving_Water_Salinity_PSU { get; set; }
        public Nullable<float> Infrastructure_Receiving_Water_Temperature_C { get; set; }
        public Nullable<int> Infrastructure_Receiving_Water_MPN_per_100_ml { get; set; }
        public Nullable<float> Infrastructure_Distance_From_Shore_m { get; set; }
        public Nullable<int> Infrastructure_See_Other_ID { get; set; }
        public Nullable<DateTime> Infrastructure_Last_Update_Date_And_Time_UTC { get; set; }
        public Nullable<float> Infrastructure_Lat { get; set; }
        public Nullable<float> Infrastructure_Lng { get; set; }
        public Nullable<float> Infrastructure_Outfall_Lat { get; set; }
        public Nullable<float> Infrastructure_Outfall_Lng { get; set; }
        public string Infrastructure_Civic_Address { get; set; }
        public string Infrastructure_Google_Address { get; set; }
        public Nullable<int> Infrastructure_Stat_Box_Model_Scenario_Count { get; set; }
        public Nullable<int> Infrastructure_Stat_Visual_Plumes_Scenario_Count { get; set; }
    }
    public class ReportBox_ModelModel
    {
        public ReportBox_ModelModel()
        {
            Box_Model_Error = "";
        }
    
        public string Box_Model_Error { get; set; }
        public Nullable<int> Box_Model_Counter { get; set; }
        public Nullable<int> Box_Model_ID { get; set; }
        public Nullable<TranslationStatusEnum> Box_Model_Scenario_Name_Translation_Status { get; set; }
        public string Box_Model_Scenario_Name { get; set; }
        public Nullable<float> Box_Model_Discharge_m3_day { get; set; }
        public Nullable<float> Box_Model_Depth_m { get; set; }
        public Nullable<float> Box_Model_Temperature_C { get; set; }
        public Nullable<int> Box_Model_Dilution { get; set; }
        public Nullable<float> Box_Model_Decay_Rate_per_day { get; set; }
        public Nullable<int> Box_Model_FC_Untreated_MPN_100ml { get; set; }
        public Nullable<int> Box_Model_FC_Pre_Disinfection_MPN_100_ml { get; set; }
        public Nullable<int> Box_Model_Concentration_MPN_100_ml { get; set; }
        public Nullable<float> Box_Model_T90_hour { get; set; }
        public Nullable<float> Box_Model_Discharge_Duration_hour { get; set; }
        public Nullable<DateTime> Box_Model_Last_Update_Date_UTC { get; set; }
        public string Box_Model_Last_Update_Contact_Name { get; set; }
        public string Box_Model_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportBox_Model_ResultModel
    {
        public ReportBox_Model_ResultModel()
        {
            Box_Model_Result_Error = "";
        }
    
        public string Box_Model_Result_Error { get; set; }
        public Nullable<int> Box_Model_Result_Counter { get; set; }
        public Nullable<int> Box_Model_Result_ID { get; set; }
        public Nullable<BoxModelResultTypeEnum> Box_Model_Result_Result_Type { get; set; }
        public Nullable<float> Box_Model_Result_Volume_m3 { get; set; }
        public Nullable<float> Box_Model_Result_Surface_m2 { get; set; }
        public Nullable<float> Box_Model_Result_Radius_m { get; set; }
        public Nullable<float> Box_Model_Result_Left_Side_Diameter_Line_Angle_deg { get; set; }
        public Nullable<float> Box_Model_Result_Circle_Center_Latitude { get; set; }
        public Nullable<float> Box_Model_Result_Circle_Center_Longitude { get; set; }
        public Nullable<bool> Box_Model_Result_Fix_Length { get; set; }
        public Nullable<bool> Box_Model_Result_Fix_Width { get; set; }
        public Nullable<float> Box_Model_Result_Rect_Length_m { get; set; }
        public Nullable<float> Box_Model_Result_Rect_Width_m { get; set; }
        public Nullable<float> Box_Model_Result_Left_Side_Line_Angle_deg { get; set; }
        public Nullable<float> Box_Model_Result_Left_Side_Line_Start_Latitude { get; set; }
        public Nullable<float> Box_Model_Result_Left_Side_Line_Start_Longitude { get; set; }
        public Nullable<DateTime> Box_Model_Result_Last_Update_Date_UTC { get; set; }
        public string Box_Model_Result_Last_Update_Contact_Name { get; set; }
        public string Box_Model_Result_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportVisual_Plumes_ScenarioModel
    {
        public ReportVisual_Plumes_ScenarioModel()
        {
            Visual_Plumes_Scenario_Error = "";
        }
    
        public string Visual_Plumes_Scenario_Error { get; set; }
        public Nullable<int> Visual_Plumes_Scenario_Counter { get; set; }
        public Nullable<int> Visual_Plumes_Scenario_ID { get; set; }
        public Nullable<TranslationStatusEnum> Visual_Plumes_Scenario_Name_Translation_Status { get; set; }
        public string Visual_Plumes_Scenario_Name { get; set; }
        public Nullable<ScenarioStatusEnum> Visual_Plumes_Scenario_Status { get; set; }
        public Nullable<bool> Visual_Plumes_Scenario_Use_As_Best_Estimate { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Effluent_Flow_m3_s { get; set; }
        public Nullable<int> Visual_Plumes_Scenario_Effluent_Concentration_MPN_100ml { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Froude_Number { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Port_Diameter_m { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Port_Depth_m { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Port_Elevation_m { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Vertical_Angle_deg { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Horizontal_Angle_deg { get; set; }
        public Nullable<int> Visual_Plumes_Scenario_Number_Of_Ports { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Port_Spacing_m { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Acute_Mix_Zone_m { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Chronic_Mix_Zone_m { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Effluent_Salinity_PSU { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Effluent_Temperature_C { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Effluent_Velocity_m_s { get; set; }
        public string Visual_Plumes_Scenario_Raw_Results { get; set; }
        public Nullable<DateTime> Visual_Plumes_Scenario_Last_Update_Date_UTC { get; set; }
        public string Visual_Plumes_Scenario_Last_Update_Contact_Name { get; set; }
        public string Visual_Plumes_Scenario_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportVisual_Plumes_Scenario_AmbientModel
    {
        public ReportVisual_Plumes_Scenario_AmbientModel()
        {
            Visual_Plumes_Scenario_Ambient_Error = "";
        }
    
        public string Visual_Plumes_Scenario_Ambient_Error { get; set; }
        public Nullable<int> Visual_Plumes_Scenario_Ambient_Counter { get; set; }
        public Nullable<int> Visual_Plumes_Scenario_Ambient_ID { get; set; }
        public Nullable<int> Visual_Plumes_Scenario_Ambient_Row { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Ambient_Measurement_Depth_m { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Ambient_Current_Speed_m_s { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Ambient_Current_Direction_deg { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Ambient_Ambient_Salinity_PSU { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Ambient_Ambient_Temperature_C { get; set; }
        public Nullable<int> Visual_Plumes_Scenario_Ambient_Background_Concentration_MPN_100ml { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Ambient_Pollutant_Decay_Rate_per_day { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Ambient_Far_Field_Current_Speed_m_s { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Ambient_Far_Field_Current_Direction_deg { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Ambient_Far_Field_Diffusion_Coefficient { get; set; }
        public Nullable<DateTime> Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC { get; set; }
        public string Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Name { get; set; }
        public string Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportVisual_Plumes_Scenario_ResultModel
    {
        public ReportVisual_Plumes_Scenario_ResultModel()
        {
            Visual_Plumes_Scenario_Result_Error = "";
        }
    
        public string Visual_Plumes_Scenario_Result_Error { get; set; }
        public Nullable<int> Visual_Plumes_Scenario_Result_Counter { get; set; }
        public Nullable<int> Visual_Plumes_Scenario_Result_ID { get; set; }
        public Nullable<int> Visual_Plumes_Scenario_Result_Ordinal { get; set; }
        public Nullable<int> Visual_Plumes_Scenario_Result_Concentration_MPN_100ml { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Result_Dilution { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Result_Far_Field_Width_m { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Result_Dispersion_Distance_m { get; set; }
        public Nullable<float> Visual_Plumes_Scenario_Result_Travel_Time_hour { get; set; }
        public Nullable<DateTime> Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC { get; set; }
        public string Visual_Plumes_Scenario_Result_Last_Update_Contact_Name { get; set; }
        public string Visual_Plumes_Scenario_Result_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportInfrastructure_AddressModel
    {
        public ReportInfrastructure_AddressModel()
        {
            Infrastructure_Address_Error = "";
        }
    
        public string Infrastructure_Address_Error { get; set; }
        public Nullable<int> Infrastructure_Address_Counter { get; set; }
        public Nullable<int> Infrastructure_Address_ID { get; set; }
        public Nullable<AddressTypeEnum> Infrastructure_Address_Type { get; set; }
        public string Infrastructure_Address_Country { get; set; }
        public string Infrastructure_Address_Province { get; set; }
        public string Infrastructure_Address_Municipality { get; set; }
        public string Infrastructure_Address_Street_Name { get; set; }
        public string Infrastructure_Address_Street_Number { get; set; }
        public Nullable<StreetTypeEnum> Infrastructure_Address_Street_Type { get; set; }
        public string Infrastructure_Address_Postal_Code { get; set; }
        public string Infrastructure_Address_Google_Address_Text { get; set; }
        public Nullable<DateTime> Infrastructure_Address_Last_Update_Date_And_Time_UTC { get; set; }
        public string Infrastructure_Address_Last_Update_Contact_Name { get; set; }
        public string Infrastructure_Address_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportInfrastructure_FileModel
    {
        public ReportInfrastructure_FileModel()
        {
            Infrastructure_File_Error = "";
        }
    
        public string Infrastructure_File_Error { get; set; }
        public Nullable<int> Infrastructure_File_Counter { get; set; }
        public Nullable<int> Infrastructure_File_ID { get; set; }
        public Nullable<LanguageEnum> Infrastructure_File_Language { get; set; }
        public Nullable<FilePurposeEnum> Infrastructure_File_Purpose { get; set; }
        public Nullable<FileTypeEnum> Infrastructure_File_Type { get; set; }
        public string Infrastructure_File_Description { get; set; }
        public Nullable<int> Infrastructure_File_Size_kb { get; set; }
        public string Infrastructure_File_Info { get; set; }
        public Nullable<DateTime> Infrastructure_File_Created_Date_UTC { get; set; }
        public Nullable<bool> Infrastructure_File_From_Water { get; set; }
        public string Infrastructure_File_Server_File_Name { get; set; }
        public string Infrastructure_File_Server_File_Path { get; set; }
        public Nullable<DateTime> Infrastructure_File_Last_Update_Date_And_Time_UTC { get; set; }
        public string Infrastructure_File_Last_Update_Contact_Name { get; set; }
        public string Infrastructure_File_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportMike_ScenarioModel
    {
        public ReportMike_ScenarioModel()
        {
            Mike_Scenario_Error = "";
        }
    
        public string Mike_Scenario_ErrorInfo { get; set; }
        public string Mike_Scenario_Error { get; set; }
        public Nullable<int> Mike_Scenario_Counter { get; set; }
        public Nullable<int> Mike_Scenario_ID { get; set; }
        public Nullable<TranslationStatusEnum> Mike_Scenario_Name_Translation_Status { get; set; }
        public string Mike_Scenario_Name { get; set; }
        public Nullable<bool> Mike_Scenario_Is_Active { get; set; }
        public Nullable<ScenarioStatusEnum> Mike_Scenario_Status { get; set; }
        public Nullable<DateTime> Mike_Scenario_Start_Date_Time_Local { get; set; }
        public Nullable<DateTime> Mike_Scenario_End_Date_Time_Local { get; set; }
        public Nullable<DateTime> Mike_Scenario_Start_Execution_Date_Time_Local { get; set; }
        public Nullable<float> Mike_Scenario_Execution_Time_min { get; set; }
        public Nullable<float> Mike_Scenario_Wind_Speed_km_h { get; set; }
        public Nullable<float> Mike_Scenario_Wind_Direction_deg { get; set; }
        public Nullable<float> Mike_Scenario_Decay_Factor_per_day { get; set; }
        public Nullable<bool> Mike_Scenario_Decay_Is_Constant { get; set; }
        public Nullable<float> Mike_Scenario_Decay_Factor_Amplitude { get; set; }
        public Nullable<int> Mike_Scenario_Result_Frequency_min { get; set; }
        public Nullable<float> Mike_Scenario_Ambient_Temperature_C { get; set; }
        public Nullable<float> Mike_Scenario_Ambient_Salinity_PSU { get; set; }
        public Nullable<float> Mike_Scenario_Manning_Number { get; set; }
        public Nullable<int> Mike_Scenario_Number_Of_Elements { get; set; }
        public Nullable<int> Mike_Scenario_Number_Of_Time_Steps { get; set; }
        public Nullable<int> Mike_Scenario_Number_Of_Sigma_Layers { get; set; }
        public Nullable<int> Mike_Scenario_Number_Of_Z_Layers { get; set; }
        public Nullable<int> Mike_Scenario_Number_Of_Hydro_Output_Parameters { get; set; }
        public Nullable<int> Mike_Scenario_Number_Of_Trans_Output_Parameters { get; set; }
        public Nullable<int> Mike_Scenario_Estimated_Hydro_File_Size { get; set; }
        public Nullable<int> Mike_Scenario_Estimated_Trans_File_Size { get; set; }
        public Nullable<DateTime> Mike_Scenario_Last_Update_Date_And_Time_UTC { get; set; }
        public string Mike_Scenario_Last_Update_Contact_Name { get; set; }
        public string Mike_Scenario_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportMike_Scenario_Special_Result_KMLModel
    {
        public ReportMike_Scenario_Special_Result_KMLModel()
        {
            Mike_Scenario_Special_Result_KML_Error = "";
        }
    
        public string Mike_Scenario_Special_Result_KML_Error { get; set; }
        public Nullable<MikeScenarioSpecialResultKMLTypeEnum> Mike_Scenario_Special_Result_KML_Type { get; set; }
        public string Mike_Scenario_Special_Result_KML_Limit_Values { get; set; }
    }
    public class ReportMike_SourceModel
    {
        public ReportMike_SourceModel()
        {
            Mike_Source_Error = "";
        }
    
        public string Mike_Source_Error { get; set; }
        public Nullable<int> Mike_Source_Counter { get; set; }
        public Nullable<int> Mike_Source_ID { get; set; }
        public Nullable<TranslationStatusEnum> Mike_Source_Name_Translation_Status { get; set; }
        public string Mike_Source_Name { get; set; }
        public Nullable<bool> Mike_Source_Is_True { get; set; }
        public Nullable<bool> Mike_Source_Is_Continuous { get; set; }
        public Nullable<bool> Mike_Source_Include { get; set; }
        public Nullable<bool> Mike_Source_Is_River { get; set; }
        public string Mike_Source_Source_Number_String { get; set; }
        public Nullable<DateTime> Mike_Source_Last_Update_Date_And_Time_UTC { get; set; }
        public string Mike_Source_Last_Update_Contact_Name { get; set; }
        public string Mike_Source_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportMike_Source_Start_EndModel
    {
        public ReportMike_Source_Start_EndModel()
        {
            Mike_Source_Start_End_Error = "";
        }
    
        public string Mike_Source_Start_End_Error { get; set; }
        public Nullable<int> Mike_Source_Start_End_Counter { get; set; }
        public Nullable<int> Mike_Source_Start_End_ID { get; set; }
        public Nullable<DateTime> Mike_Source_Start_End_Start_Date_And_Time_Local { get; set; }
        public Nullable<DateTime> Mike_Source_Start_End_End_Date_And_Time_Local { get; set; }
        public Nullable<float> Mike_Source_Start_End_Source_Flow_Start_m3_day { get; set; }
        public Nullable<float> Mike_Source_Start_End_Source_Flow_End_m3_day { get; set; }
        public Nullable<int> Mike_Source_Start_End_Source_Pollution_Start_MPN_100ml { get; set; }
        public Nullable<int> Mike_Source_Start_End_Source_Pollution_End_MPN_100ml { get; set; }
        public Nullable<float> Mike_Source_Start_End_Source_Temperature_Start_C { get; set; }
        public Nullable<float> Mike_Source_Start_End_Source_Temperature_End_C { get; set; }
        public Nullable<float> Mike_Source_Start_End_Source_Salinity_Start_PSU { get; set; }
        public Nullable<float> Mike_Source_Start_End_Source_Salinity_End_PSU { get; set; }
        public Nullable<DateTime> Mike_Source_Start_End_Last_Update_Date_And_Time_UTC { get; set; }
        public string Mike_Source_Start_End_Last_Update_Contact_Name { get; set; }
        public string Mike_Source_Start_End_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportMike_Boundary_ConditionModel
    {
        public ReportMike_Boundary_ConditionModel()
        {
            Mike_Boundary_Condition_Error = "";
        }
    
        public string Mike_Boundary_Condition_Error { get; set; }
        public Nullable<int> Mike_Boundary_Condition_Counter { get; set; }
        public Nullable<int> Mike_Boundary_Condition_ID { get; set; }
        public string Mike_Boundary_Condition_Name { get; set; }
        public string Mike_Boundary_Condition_Mike_Boundary_Condition_Code { get; set; }
        public string Mike_Boundary_Condition_Mike_Boundary_Condition_Name { get; set; }
        public Nullable<float> Mike_Boundary_Condition_Mike_Boundary_Condition_Length_m { get; set; }
        public string Mike_Boundary_Condition_Mike_Boundary_Condition_Format { get; set; }
        public string Mike_Boundary_Condition_Mike_Boundary_Condition_Level_Or_Velocity { get; set; }
        public string Mike_Boundary_Condition_Web_Tide_Data_Set { get; set; }
        public Nullable<int> Mike_Boundary_Condition_Number_Of_Web_Tide_Nodes { get; set; }
        public Nullable<DateTime> Mike_Boundary_Condition_Last_Update_Date_UTC { get; set; }
        public string Mike_Boundary_Condition_Last_Update_Contact_Name { get; set; }
        public string Mike_Boundary_Condition_Last_Update_Contact_Initial { get; set; }
        public Nullable<float> Mike_Boundary_Condition_Lat { get; set; }
        public Nullable<float> Mike_Boundary_Condition_Lng { get; set; }
    }
    public class ReportMike_Scenario_FileModel
    {
        public ReportMike_Scenario_FileModel()
        {
            Mike_Scenario_File_Error = "";
        }
    
        public string Mike_Scenario_File_Error { get; set; }
        public Nullable<int> Mike_Scenario_File_Counter { get; set; }
        public Nullable<int> Mike_Scenario_File_ID { get; set; }
        public Nullable<LanguageEnum> Mike_Scenario_File_Language { get; set; }
        public Nullable<FilePurposeEnum> Mike_Scenario_File_Purpose { get; set; }
        public Nullable<FileTypeEnum> Mike_Scenario_File_Type { get; set; }
        public string Mike_Scenario_File_Description { get; set; }
        public Nullable<int> Mike_Scenario_File_Size_kb { get; set; }
        public string Mike_Scenario_File_Info { get; set; }
        public Nullable<DateTime> Mike_Scenario_File_Created_Date_UTC { get; set; }
        public Nullable<bool> Mike_Scenario_File_From_Water { get; set; }
        public string Mike_Scenario_File_Server_File_Name { get; set; }
        public string Mike_Scenario_File_Server_File_Path { get; set; }
        public Nullable<DateTime> Mike_Scenario_File_Last_Update_Date_And_Time_UTC { get; set; }
        public string Mike_Scenario_File_Last_Update_Contact_Name { get; set; }
        public string Mike_Scenario_File_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportMunicipality_ContactModel
    {
        public ReportMunicipality_ContactModel()
        {
            Municipality_Contact_Error = "";
        }
    
        public string Municipality_Contact_Error { get; set; }
        public Nullable<int> Municipality_Contact_Counter { get; set; }
        public Nullable<int> Municipality_Contact_ID { get; set; }
        public string Municipality_Contact_First_Name { get; set; }
        public string Municipality_Contact_Initial { get; set; }
        public string Municipality_Contact_Last_Name { get; set; }
        public string Municipality_Contact_Full_Name { get; set; }
        public Nullable<ContactTitleEnum> Municipality_Contact_Title { get; set; }
        public string Municipality_Contact_Tels { get; set; }
        public string Municipality_Contact_Emails { get; set; }
        public string Municipality_Contact_Civic_Address { get; set; }
        public string Municipality_Contact_Google_Address { get; set; }
        public Nullable<DateTime> Municipality_Contact_Last_Update_Date_And_Time_UTC { get; set; }
        public string Municipality_Contact_Last_Update_Contact_Name { get; set; }
        public string Municipality_Contact_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportMunicipality_Contact_AddressModel
    {
        public ReportMunicipality_Contact_AddressModel()
        {
            Municipality_Contact_Address_Error = "";
        }
    
        public string Municipality_Contact_Address_Error { get; set; }
        public Nullable<int> Municipality_Contact_Address_Counter { get; set; }
        public Nullable<int> Municipality_Contact_Address_ID { get; set; }
        public Nullable<AddressTypeEnum> Municipality_Contact_Address_Type { get; set; }
        public string Municipality_Contact_Address_Country { get; set; }
        public string Municipality_Contact_Address_Province { get; set; }
        public string Municipality_Contact_Address_Municipality { get; set; }
        public string Municipality_Contact_Address_Street_Name { get; set; }
        public string Municipality_Contact_Address_Street_Number { get; set; }
        public Nullable<StreetTypeEnum> Municipality_Contact_Address_Street_Type { get; set; }
        public string Municipality_Contact_Address_Postal_Code { get; set; }
        public string Municipality_Contact_Address_Google_Address_Text { get; set; }
        public Nullable<DateTime> Municipality_Contact_Address_Last_Update_Date_And_Time_UTC { get; set; }
        public string Municipality_Contact_Address_Last_Update_Contact_Name { get; set; }
        public string Municipality_Contact_Address_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportMunicipality_Contact_TelModel
    {
        public ReportMunicipality_Contact_TelModel()
        {
            Municipality_Contact_Tel_Error = "";
        }
    
        public string Municipality_Contact_Tel_Error { get; set; }
        public Nullable<int> Municipality_Contact_Tel_Counter { get; set; }
        public Nullable<int> Municipality_Contact_Tel_ID { get; set; }
        public Nullable<TelTypeEnum> Municipality_Contact_Tel_Type { get; set; }
        public string Municipality_Contact_Tel_Number { get; set; }
        public Nullable<DateTime> Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC { get; set; }
        public string Municipality_Contact_Tel_Last_Update_Contact_Name { get; set; }
        public string Municipality_Contact_Tel_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportMunicipality_Contact_EmailModel
    {
        public ReportMunicipality_Contact_EmailModel()
        {
            Municipality_Contact_Email_Error = "";
        }
    
        public string Municipality_Contact_Email_Error { get; set; }
        public Nullable<int> Municipality_Contact_Email_Counter { get; set; }
        public Nullable<int> Municipality_Contact_Email_ID { get; set; }
        public Nullable<EmailTypeEnum> Municipality_Contact_Email_Type { get; set; }
        public string Municipality_Contact_Email_Address { get; set; }
        public Nullable<DateTime> Municipality_Contact_Email_Last_Update_Date_And_Time_UTC { get; set; }
        public string Municipality_Contact_Email_Last_Update_Contact_Name { get; set; }
        public string Municipality_Contact_Email_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportMunicipality_FileModel
    {
        public ReportMunicipality_FileModel()
        {
            Municipality_File_Error = "";
        }
    
        public string Municipality_File_Error { get; set; }
        public Nullable<int> Municipality_File_Counter { get; set; }
        public Nullable<int> Municipality_File_ID { get; set; }
        public Nullable<LanguageEnum> Municipality_File_Language { get; set; }
        public Nullable<FilePurposeEnum> Municipality_File_Purpose { get; set; }
        public Nullable<FileTypeEnum> Municipality_File_Type { get; set; }
        public string Municipality_File_Description { get; set; }
        public Nullable<int> Municipality_File_Size_kb { get; set; }
        public string Municipality_File_Info { get; set; }
        public Nullable<DateTime> Municipality_File_Created_Date_UTC { get; set; }
        public Nullable<bool> Municipality_File_From_Water { get; set; }
        public string Municipality_File_Server_File_Name { get; set; }
        public string Municipality_File_Server_File_Path { get; set; }
        public Nullable<DateTime> Municipality_File_Last_Update_Date_And_Time_UTC { get; set; }
        public string Municipality_File_Last_Update_Contact_Name { get; set; }
        public string Municipality_File_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportSubsector_Climate_SiteModel
    {
        public ReportSubsector_Climate_SiteModel()
        {
            Subsector_Climate_Site_Error = "";
        }
    
        public string Subsector_Climate_Site_Error { get; set; }
        public Nullable<int> Subsector_Climate_Site_Counter { get; set; }
        public Nullable<int> Subsector_Climate_Site_ID { get; set; }
        public Nullable<int> Subsector_Climate_Site_ECDBID { get; set; }
        public string Subsector_Climate_Site_Name { get; set; }
        public string Subsector_Climate_Site_Province { get; set; }
        public Nullable<float> Subsector_Climate_Site_Elevation_m { get; set; }
        public string Subsector_Climate_Site_Climate_ID { get; set; }
        public Nullable<int> Subsector_Climate_Site_WMOID { get; set; }
        public string Subsector_Climate_Site_TCID { get; set; }
        public Nullable<bool> Subsector_Climate_Site_Is_Quebec_Site { get; set; }
        public Nullable<float> Subsector_Climate_Site_Time_Offset_hour { get; set; }
        public string Subsector_Climate_Site_File_desc { get; set; }
        public Nullable<DateTime> Subsector_Climate_Site_Hourly_Start_Date_Local { get; set; }
        public Nullable<DateTime> Subsector_Climate_Site_Hourly_End_Date_Local { get; set; }
        public Nullable<bool> Subsector_Climate_Site_Hourly_Now { get; set; }
        public Nullable<DateTime> Subsector_Climate_Site_Daily_Start_Date_Local { get; set; }
        public Nullable<DateTime> Subsector_Climate_Site_Daily_End_Date_Local { get; set; }
        public Nullable<bool> Subsector_Climate_Site_Daily_Now { get; set; }
        public Nullable<DateTime> Subsector_Climate_Site_Monthly_Start_Date_Local { get; set; }
        public Nullable<DateTime> Subsector_Climate_Site_Monthly_End_Date_Local { get; set; }
        public Nullable<bool> Subsector_Climate_Site_Monthly_Now { get; set; }
        public Nullable<DateTime> Subsector_Climate_Site_Last_Update_Date_UTC { get; set; }
        public string Subsector_Climate_Site_Last_Update_Contact_Name { get; set; }
        public string Subsector_Climate_Site_Last_Update_Contact_Initial { get; set; }
        public Nullable<float> Subsector_Climate_Site_Lat { get; set; }
        public Nullable<float> Subsector_Climate_Site_Lng { get; set; }
    }
    public class ReportSubsector_Climate_Site_DataModel
    {
        public ReportSubsector_Climate_Site_DataModel()
        {
            Subsector_Climate_Site_Data_Error = "";
        }
    
        public string Subsector_Climate_Site_Data_Error { get; set; }
        public Nullable<int> Subsector_Climate_Site_Data_Counter { get; set; }
        public Nullable<int> Subsector_Climate_Site_Data_ID { get; set; }
        public Nullable<DateTime> Subsector_Climate_Site_Data_Date_Time_Local { get; set; }
        public Nullable<bool> Subsector_Climate_Site_Data_Keep { get; set; }
        public Nullable<StorageDataTypeEnum> Subsector_Climate_Site_Data_Storage_Data_Type { get; set; }
        public Nullable<float> Subsector_Climate_Site_Data_Snow_cm { get; set; }
        public Nullable<float> Subsector_Climate_Site_Data_Rainfall_mm { get; set; }
        public Nullable<float> Subsector_Climate_Site_Data_Rainfall_Entered_mm { get; set; }
        public Nullable<float> Subsector_Climate_Site_Data_Total_Precip_mm_cm { get; set; }
        public Nullable<float> Subsector_Climate_Site_Data_Max_Temp_C { get; set; }
        public Nullable<float> Subsector_Climate_Site_Data_Min_Temp_C { get; set; }
        public Nullable<float> Subsector_Climate_Site_Data_Heat_Deg_Days_C { get; set; }
        public Nullable<float> Subsector_Climate_Site_Data_Cool_Deg_Days_C { get; set; }
        public Nullable<float> Subsector_Climate_Site_Data_Snow_On_Ground_cm { get; set; }
        public Nullable<float> Subsector_Climate_Site_Data_Dir_Max_Gust_0North { get; set; }
        public Nullable<float> Subsector_Climate_Site_Data_Spd_Max_Gust_kmh { get; set; }
        public string Subsector_Climate_Site_Data_Hourly_Values { get; set; }
        public Nullable<DateTime> Subsector_Climate_Site_Data_Last_Update_Date_UTC { get; set; }
        public string Subsector_Climate_Site_Data_Last_Update_Contact_Name { get; set; }
        public string Subsector_Climate_Site_Data_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportSubsector_Hydrometric_SiteModel
    {
        public ReportSubsector_Hydrometric_SiteModel()
        {
            Subsector_Hydrometric_Site_Error = "";
        }
    
        public string Subsector_Hydrometric_Site_Error { get; set; }
        public Nullable<int> Subsector_Hydrometric_Site_Counter { get; set; }
        public Nullable<int> Subsector_Hydrometric_Site_ID { get; set; }
        public string Subsector_Hydrometric_Site_Fed_Site_Number { get; set; }
        public string Subsector_Hydrometric_Site_Quebec_Site_Number { get; set; }
        public string Subsector_Hydrometric_Site_Name { get; set; }
        public string Subsector_Hydrometric_Site_Description { get; set; }
        public string Subsector_Hydrometric_Site_Province { get; set; }
        public Nullable<float> Subsector_Hydrometric_Site_Elevation_m { get; set; }
        public Nullable<DateTime> Subsector_Hydrometric_Site_Start_Date_Local { get; set; }
        public Nullable<DateTime> Subsector_Hydrometric_Site_End_Date_Local { get; set; }
        public Nullable<float> Subsector_Hydrometric_Site_Time_Offset_hour { get; set; }
        public Nullable<float> Subsector_Hydrometric_Site_Drainage_Area_km2 { get; set; }
        public Nullable<bool> Subsector_Hydrometric_Site_Is_Natural { get; set; }
        public Nullable<bool> Subsector_Hydrometric_Site_Is_Active { get; set; }
        public Nullable<bool> Subsector_Hydrometric_Site_Sediment { get; set; }
        public Nullable<bool> Subsector_Hydrometric_Site_RHBN { get; set; }
        public Nullable<bool> Subsector_Hydrometric_Site_Real_Time { get; set; }
        public Nullable<bool> Subsector_Hydrometric_Site_Has_Rating_Curve { get; set; }
        public Nullable<DateTime> Subsector_Hydrometric_Site_Last_Update_Date_UTC { get; set; }
        public string Subsector_Hydrometric_Site_Last_Update_Contact_Name { get; set; }
        public string Subsector_Hydrometric_Site_Last_Update_Contact_Initial { get; set; }
        public Nullable<float> Subsector_Hydrometric_Site_Lat { get; set; }
        public Nullable<float> Subsector_Hydrometric_Site_Lng { get; set; }
    }
    public class ReportSubsector_Hydrometric_Site_DataModel
    {
        public ReportSubsector_Hydrometric_Site_DataModel()
        {
            Subsector_Hydrometric_Site_Data_Error = "";
        }
    
        public string Subsector_Hydrometric_Site_Data_Error { get; set; }
        public Nullable<int> Subsector_Hydrometric_Site_Data_Counter { get; set; }
        public Nullable<int> Subsector_Hydrometric_Site_Data_ID { get; set; }
        public Nullable<DateTime> Subsector_Hydrometric_Site_Data_Date_Time_Local { get; set; }
        public Nullable<bool> Subsector_Hydrometric_Site_Data_Keep { get; set; }
        public Nullable<StorageDataTypeEnum> Subsector_Hydrometric_Site_Data_Storage_Data_Type { get; set; }
        public Nullable<float> Subsector_Hydrometric_Site_Data_Discharge_m3_s { get; set; }
        public Nullable<float> Subsector_Hydrometric_Site_Data_DischargeEntered_m3_s { get; set; }
        public Nullable<float> Subsector_Hydrometric_Site_Data_Level_m { get; set; }
        public string Subsector_Hydrometric_Site_Data_Hourly_Values { get; set; }
        public Nullable<DateTime> Subsector_Hydrometric_Site_Data_Last_Update_Date_UTC { get; set; }
        public string Subsector_Hydrometric_Site_Data_Last_Update_Contact_Name { get; set; }
        public string Subsector_Hydrometric_Site_Data_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportSubsector_Hydrometric_Site_Rating_CurveModel
    {
        public ReportSubsector_Hydrometric_Site_Rating_CurveModel()
        {
            Subsector_Hydrometric_Site_Rating_Curve_Error = "";
        }
    
        public string Subsector_Hydrometric_Site_Rating_Curve_Error { get; set; }
        public Nullable<int> Subsector_Hydrometric_Site_Rating_Curve_Counter { get; set; }
        public Nullable<int> Subsector_Hydrometric_Site_Rating_Curve_ID { get; set; }
        public string Subsector_Hydrometric_Site_Rating_Curve_Rating_Curve_Number { get; set; }
        public Nullable<DateTime> Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC { get; set; }
        public string Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Name { get; set; }
        public string Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModel
    {
        public ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModel()
        {
            Subsector_Hydrometric_Site_Rating_Curve_Value_Error = "";
        }
    
        public string Subsector_Hydrometric_Site_Rating_Curve_Value_Error { get; set; }
        public Nullable<int> Subsector_Hydrometric_Site_Rating_Curve_Value_Counter { get; set; }
        public Nullable<int> Subsector_Hydrometric_Site_Rating_Curve_Value_ID { get; set; }
        public Nullable<float> Subsector_Hydrometric_Site_Rating_Curve_Value_Stage_Value_m { get; set; }
        public Nullable<float> Subsector_Hydrometric_Site_Rating_Curve_Value_Discharge_Value_m3_s { get; set; }
        public Nullable<DateTime> Subsector_Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC { get; set; }
        public string Subsector_Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Name { get; set; }
        public string Subsector_Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportSubsector_Special_TableModel
    {
        public ReportSubsector_Special_TableModel()
        {
            Subsector_Special_Table_Error = "";
        }
    
        public string Subsector_Special_Table_Error { get; set; }
        public Nullable<int> Subsector_Special_Table_Last_X_Runs { get; set; }
        public Nullable<SpecialTableTypeEnum> Subsector_Special_Table_Type { get; set; }
        public Nullable<bool> Subsector_Special_Table_MWQM_Site_Is_Active { get; set; }
        public Nullable<int> Subsector_Special_Table_Number_Of_Samples_For_Stat_Max { get; set; }
        public Nullable<int> Subsector_Special_Table_Number_Of_Samples_For_Stat_Min { get; set; }
        public Nullable<float> Subsector_Special_Table_Highlight_Above_Min_Number { get; set; }
        public Nullable<float> Subsector_Special_Table_Highlight_Below_Max_Number { get; set; }
        public Nullable<int> Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation { get; set; }
        public Nullable<int> Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part { get; set; }
        public string Subsector_Special_Table_MWQM_Site_Name_List { get; set; }
        public string Subsector_Special_Table_Stat_Letter_List { get; set; }
        public string Subsector_Special_Table_MWQM_Run_Date_List { get; set; }
        public string Subsector_Special_Table_Parameter_Value_List { get; set; }
        public string Subsector_Special_Table_Tide_Value_List { get; set; }
        public string Subsector_Special_Table_Rain_Day_0_Value_List { get; set; }
        public string Subsector_Special_Table_Rain_Day_1_Value_List { get; set; }
        public string Subsector_Special_Table_Rain_Day_2_Value_List { get; set; }
        public string Subsector_Special_Table_Rain_Day_3_Value_List { get; set; }
        public string Subsector_Special_Table_Rain_Day_4_Value_List { get; set; }
        public string Subsector_Special_Table_Rain_Day_5_Value_List { get; set; }
        public string Subsector_Special_Table_Rain_Day_6_Value_List { get; set; }
        public string Subsector_Special_Table_Rain_Day_7_Value_List { get; set; }
        public string Subsector_Special_Table_Rain_Day_8_Value_List { get; set; }
        public string Subsector_Special_Table_Rain_Day_9_Value_List { get; set; }
        public string Subsector_Special_Table_Rain_Day_10_Value_List { get; set; }
    }
    public class ReportSubsector_Tide_SiteModel
    {
        public ReportSubsector_Tide_SiteModel()
        {
            Subsector_Tide_Site_Error = "";
        }
    
        public string Subsector_Tide_Site_Error { get; set; }
        public Nullable<int> Subsector_Tide_Site_Counter { get; set; }
        public Nullable<int> Subsector_Tide_Site_ID { get; set; }
        public Nullable<TranslationStatusEnum> Subsector_Tide_Site_Name_Translation_Status { get; set; }
        public string Subsector_Tide_Site_Name { get; set; }
        public Nullable<bool> Subsector_Tide_Site_Is_Active { get; set; }
        public string Subsector_Tide_Site_Province { get; set; }
        public int Subsector_Tide_Site_sid { get; set; }
        public int Subsector_Tide_Site_Zone { get; set; }
        public Nullable<DateTime> Subsector_Tide_Site_Last_Update_Date_And_Time_UTC { get; set; }
        public string Subsector_Tide_Site_Last_Update_Contact_Name { get; set; }
        public string Subsector_Tide_Site_Last_Update_Contact_Initial { get; set; }
        public Nullable<float> Subsector_Tide_Site_Lat { get; set; }
        public Nullable<float> Subsector_Tide_Site_Lng { get; set; }
    }
    public class ReportSubsector_Tide_Site_DataModel
    {
        public ReportSubsector_Tide_Site_DataModel()
        {
            Subsector_Tide_Site_Data_Error = "";
        }
    
        public string Subsector_Tide_Site_Data_Error { get; set; }
        public Nullable<int> Subsector_Tide_Site_Data_Counter { get; set; }
        public Nullable<int> Subsector_Tide_Site_Data_ID { get; set; }
        public Nullable<DateTime> Subsector_Tide_Site_Data_Date_Time_Local { get; set; }
        public Nullable<bool> Subsector_Tide_Site_Data_Keep { get; set; }
        public Nullable<TideDataTypeEnum> Subsector_Tide_Site_Data_Tide_Data_Type { get; set; }
        public Nullable<StorageDataTypeEnum> Subsector_Tide_Site_Data_Storage_Data_Type { get; set; }
        public Nullable<float> Subsector_Tide_Site_Data_Depth_m { get; set; }
        public Nullable<float> Subsector_Tide_Site_Data_U_Velocity_m_s { get; set; }
        public Nullable<float> Subsector_Tide_Site_Data_V_Velocity_m_s { get; set; }
        public Nullable<TideTextEnum> Subsector_Tide_Site_Data_Tide_Start { get; set; }
        public Nullable<TideTextEnum> Subsector_Tide_Site_Data_Tide_End { get; set; }
        public Nullable<DateTime> Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC { get; set; }
        public string Subsector_Tide_Site_Data_Last_Update_Contact_Name { get; set; }
        public string Subsector_Tide_Site_Data_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportSubsector_Lab_SheetModel
    {
        public ReportSubsector_Lab_SheetModel()
        {
            Subsector_Lab_Sheet_Error = "";
        }
    
        public string Subsector_Lab_Sheet_Error { get; set; }
        public Nullable<int> Subsector_Lab_Sheet_Counter { get; set; }
        public Nullable<int> Subsector_Lab_Sheet_ID { get; set; }
        public Nullable<int> Subsector_Lab_Sheet_Other_Server_Lab_Sheet_ID { get; set; }
        public string Subsector_Lab_Sheet_Sampling_Plan_Name { get; set; }
        public string Subsector_Lab_Sheet_Province { get; set; }
        public string Subsector_Lab_Sheet_For_Group_Name { get; set; }
        public Nullable<int> Subsector_Lab_Sheet_Year { get; set; }
        public Nullable<int> Subsector_Lab_Sheet_Month { get; set; }
        public Nullable<int> Subsector_Lab_Sheet_Day { get; set; }
        public string Subsector_Lab_Sheet_Access_Code { get; set; }
        public float Subsector_Lab_Sheet_Daily_Duplicate_Precision_Criteria { get; set; }
        public float Subsector_Lab_Sheet_Intertech_Duplicate_Precision_Criteria { get; set; }
        public string Subsector_Lab_Sheet_Subsector_Name_Short { get; set; }
        public string Subsector_Lab_Sheet_Subsector_Name_Long { get; set; }
        public Nullable<SamplingPlanTypeEnum> Subsector_Lab_Sheet_Sampling_Plan_Type { get; set; }
        public string Subsector_Lab_Sheet_Sample_Type { get; set; }
        public Nullable<LabSheetTypeEnum> Subsector_Lab_Sheet_Type { get; set; }
        public Nullable<LabSheetStatusEnum> Subsector_Lab_Sheet_Status { get; set; }
        public string Subsector_Lab_Sheet_File_Name { get; set; }
        public Nullable<DateTime> Subsector_Lab_Sheet_File_Last_Modified_Date_Local { get; set; }
        public string Subsector_Lab_Sheet_File_Content { get; set; }
        public string Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name { get; set; }
        public string Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial { get; set; }
        public Nullable<DateTime> Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time { get; set; }
        public Nullable<DateTime> Subsector_Lab_Sheet_Last_Update_Date_UTC { get; set; }
        public string Subsector_Lab_Sheet_Last_Update_Contact_Name { get; set; }
        public string Subsector_Lab_Sheet_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportSubsector_Lab_Sheet_DetailModel
    {
        public ReportSubsector_Lab_Sheet_DetailModel()
        {
            Subsector_Lab_Sheet_Detail_Error = "";
        }
    
        public string Subsector_Lab_Sheet_Detail_Error { get; set; }
        public Nullable<int> Subsector_Lab_Sheet_Detail_Counter { get; set; }
        public Nullable<int> Subsector_Lab_Sheet_Detail_ID { get; set; }
        public string Subsector_Lab_Sheet_Detail_Version { get; set; }
        public Nullable<DateTime> Subsector_Lab_Sheet_Detail_Run_Date { get; set; }
        public string Subsector_Lab_Sheet_Detail_Tides { get; set; }
        public string Subsector_Lab_Sheet_Detail_Sample_Crew_Initials { get; set; }
        public Nullable<DateTime> Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time { get; set; }
        public Nullable<DateTime> Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time { get; set; }
        public Nullable<DateTime> Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time { get; set; }
        public Nullable<DateTime> Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time { get; set; }
        public Nullable<DateTime> Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time { get; set; }
        public Nullable<DateTime> Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time { get; set; }
        public Nullable<int> Subsector_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes { get; set; }
        public Nullable<int> Subsector_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes { get; set; }
        public Nullable<int> Subsector_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes { get; set; }
        public string Subsector_Lab_Sheet_Detail_Water_Bath1 { get; set; }
        public string Subsector_Lab_Sheet_Detail_Water_Bath2 { get; set; }
        public string Subsector_Lab_Sheet_Detail_Water_Bath3 { get; set; }
        public Nullable<float> Subsector_Lab_Sheet_Detail_TC_Field_1 { get; set; }
        public Nullable<float> Subsector_Lab_Sheet_Detail_TC_Lab_1 { get; set; }
        public Nullable<float> Subsector_Lab_Sheet_Detail_TC_Field_2 { get; set; }
        public Nullable<float> Subsector_Lab_Sheet_Detail_TC_Lab_2 { get; set; }
        public Nullable<float> Subsector_Lab_Sheet_Detail_TC_First { get; set; }
        public Nullable<float> Subsector_Lab_Sheet_Detail_TC_Average { get; set; }
        public string Subsector_Lab_Sheet_Detail_Control_Lot { get; set; }
        public string Subsector_Lab_Sheet_Detail_Positive_35 { get; set; }
        public string Subsector_Lab_Sheet_Detail_Non_Target_35 { get; set; }
        public string Subsector_Lab_Sheet_Detail_Negative_35 { get; set; }
        public string Subsector_Lab_Sheet_Detail_Bath1_Positive_44_5 { get; set; }
        public string Subsector_Lab_Sheet_Detail_Bath2_Positive_44_5 { get; set; }
        public string Subsector_Lab_Sheet_Detail_Bath3_Positive_44_5 { get; set; }
        public string Subsector_Lab_Sheet_Detail_Bath1_Non_Target_44_5 { get; set; }
        public string Subsector_Lab_Sheet_Detail_Bath2_Non_Target_44_5 { get; set; }
        public string Subsector_Lab_Sheet_Detail_Bath3_Non_Target_44_5 { get; set; }
        public string Subsector_Lab_Sheet_Detail_Bath1_Negative_44_5 { get; set; }
        public string Subsector_Lab_Sheet_Detail_Bath2_Negative_44_5 { get; set; }
        public string Subsector_Lab_Sheet_Detail_Bath3_Negative_44_5 { get; set; }
        public string Subsector_Lab_Sheet_Detail_Blank_35 { get; set; }
        public string Subsector_Lab_Sheet_Detail_Bath1_Blank_44_5 { get; set; }
        public string Subsector_Lab_Sheet_Detail_Bath2_Blank_44_5 { get; set; }
        public string Subsector_Lab_Sheet_Detail_Bath3_Blank_44_5 { get; set; }
        public string Subsector_Lab_Sheet_Detail_Lot_35 { get; set; }
        public string Subsector_Lab_Sheet_Detail_Lot_44_5 { get; set; }
        public string Subsector_Lab_Sheet_Detail_Run_Comment { get; set; }
        public string Subsector_Lab_Sheet_Detail_Run_Weather_Comment { get; set; }
        public string Subsector_Lab_Sheet_Detail_Sample_Bottle_Lot_Number { get; set; }
        public string Subsector_Lab_Sheet_Detail_Salinities_Read_By { get; set; }
        public Nullable<DateTime> Subsector_Lab_Sheet_Detail_Salinities_Read_Date { get; set; }
        public string Subsector_Lab_Sheet_Detail_Results_Read_By { get; set; }
        public Nullable<DateTime> Subsector_Lab_Sheet_Detail_Results_Read_Date { get; set; }
        public string Subsector_Lab_Sheet_Detail_Results_Recorded_By { get; set; }
        public Nullable<DateTime> Subsector_Lab_Sheet_Detail_Results_Recorded_Date { get; set; }
        public Nullable<float> Subsector_Lab_Sheet_Detail_Daily_Duplicate_R_Log { get; set; }
        public Nullable<float> Subsector_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria { get; set; }
        public Nullable<bool> Subsector_Lab_Sheet_Detail_Daily_Duplicate_Acceptable { get; set; }
        public Nullable<float> Subsector_Lab_Sheet_Detail_Intertech_Duplicate_R_Log { get; set; }
        public Nullable<float> Subsector_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria { get; set; }
        public Nullable<bool> Subsector_Lab_Sheet_Detail_Intertech_Duplicate_Acceptable { get; set; }
        public Nullable<bool> Subsector_Lab_Sheet_Detail_Intertech_Read_Acceptable { get; set; }
        public Nullable<DateTime> Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC { get; set; }
        public string Subsector_Lab_Sheet_Detail_Last_Update_Contact_Name { get; set; }
        public string Subsector_Lab_Sheet_Detail_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel
    {
        public ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel()
        {
            Subsector_Lab_Sheet_Tube_And_MPN_Detail_Error = "";
        }
    
        public string Subsector_Lab_Sheet_Tube_And_MPN_Detail_Error { get; set; }
        public Nullable<int> Subsector_Lab_Sheet_Tube_And_MPN_Detail_Counter { get; set; }
        public Nullable<int> Subsector_Lab_Sheet_Tube_And_MPN_Detail_ID { get; set; }
        public Nullable<int> Subsector_Lab_Sheet_Tube_And_MPN_Detail_Ordinal { get; set; }
        public string Subsector_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site { get; set; }
        public Nullable<DateTime> Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time { get; set; }
        public Nullable<int> Subsector_Lab_Sheet_Tube_And_MPN_Detail_MPN { get; set; }
        public Nullable<int> Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_10 { get; set; }
        public Nullable<int> Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0 { get; set; }
        public Nullable<int> Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1 { get; set; }
        public Nullable<float> Subsector_Lab_Sheet_Tube_And_MPN_Detail_Salinity { get; set; }
        public Nullable<float> Subsector_Lab_Sheet_Tube_And_MPN_Detail_Temperature { get; set; }
        public string Subsector_Lab_Sheet_Tube_And_MPN_Detail_Processed_By { get; set; }
        public string Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type { get; set; }
        public string Subsector_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment { get; set; }
        public Nullable<DateTime> Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC { get; set; }
        public string Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name { get; set; }
        public string Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportSubsector_FileModel
    {
        public ReportSubsector_FileModel()
        {
            Subsector_File_Error = "";
        }
    
        public string Subsector_File_Error { get; set; }
        public Nullable<int> Subsector_File_Counter { get; set; }
        public Nullable<int> Subsector_File_ID { get; set; }
        public Nullable<LanguageEnum> Subsector_File_Language { get; set; }
        public Nullable<FilePurposeEnum> Subsector_File_Purpose { get; set; }
        public Nullable<FileTypeEnum> Subsector_File_Type { get; set; }
        public string Subsector_File_Description { get; set; }
        public Nullable<int> Subsector_File_Size_kb { get; set; }
        public string Subsector_File_Info { get; set; }
        public Nullable<DateTime> Subsector_File_Created_Date_UTC { get; set; }
        public Nullable<bool> Subsector_File_From_Water { get; set; }
        public string Subsector_File_Server_File_Name { get; set; }
        public string Subsector_File_Server_File_Path { get; set; }
        public Nullable<DateTime> Subsector_File_Last_Update_Date_And_Time_UTC { get; set; }
        public string Subsector_File_Last_Update_Contact_Name { get; set; }
        public string Subsector_File_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportSector_FileModel
    {
        public ReportSector_FileModel()
        {
            Sector_File_Error = "";
        }
    
        public string Sector_File_Error { get; set; }
        public Nullable<int> Sector_File_Counter { get; set; }
        public Nullable<int> Sector_File_ID { get; set; }
        public Nullable<LanguageEnum> Sector_File_Language { get; set; }
        public Nullable<FilePurposeEnum> Sector_File_Purpose { get; set; }
        public Nullable<FileTypeEnum> Sector_File_Type { get; set; }
        public string Sector_File_Description { get; set; }
        public Nullable<int> Sector_File_Size_kb { get; set; }
        public string Sector_File_Info { get; set; }
        public Nullable<DateTime> Sector_File_Created_Date_UTC { get; set; }
        public Nullable<bool> Sector_File_From_Water { get; set; }
        public string Sector_File_Server_File_Name { get; set; }
        public string Sector_File_Server_File_Path { get; set; }
        public Nullable<DateTime> Sector_File_Last_Update_Date_And_Time_UTC { get; set; }
        public string Sector_File_Last_Update_Contact_Name { get; set; }
        public string Sector_File_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportArea_FileModel
    {
        public ReportArea_FileModel()
        {
            Area_File_Error = "";
        }
    
        public string Area_File_Error { get; set; }
        public Nullable<int> Area_File_Counter { get; set; }
        public Nullable<int> Area_File_ID { get; set; }
        public Nullable<LanguageEnum> Area_File_Language { get; set; }
        public Nullable<FilePurposeEnum> Area_File_Purpose { get; set; }
        public Nullable<FileTypeEnum> Area_File_Type { get; set; }
        public string Area_File_Description { get; set; }
        public Nullable<int> Area_File_Size_kb { get; set; }
        public string Area_File_Info { get; set; }
        public Nullable<DateTime> Area_File_Created_Date_UTC { get; set; }
        public Nullable<bool> Area_File_From_Water { get; set; }
        public string Area_File_Server_File_Name { get; set; }
        public string Area_File_Server_File_Path { get; set; }
        public Nullable<DateTime> Area_File_Last_Update_Date_And_Time_UTC { get; set; }
        public string Area_File_Last_Update_Contact_Name { get; set; }
        public string Area_File_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportSampling_PlanModel
    {
        public ReportSampling_PlanModel()
        {
            Sampling_Plan_Error = "";
        }
    
        public string Sampling_Plan_Error { get; set; }
        public Nullable<int> Sampling_Plan_Counter { get; set; }
        public Nullable<int> Sampling_Plan_ID { get; set; }
        public string Sampling_Plan_Sampling_Plan_Name { get; set; }
        public string Sampling_Plan_For_Group_Name { get; set; }
        public string Sampling_Plan_Sample_Type { get; set; }
        public Nullable<SamplingPlanTypeEnum> Sampling_Plan_Sampling_Plan_Type { get; set; }
        public Nullable<LabSheetTypeEnum> Sampling_Plan_Lab_Sheet_Type { get; set; }
        public string Sampling_Plan_Province { get; set; }
        public string Sampling_Plan_Creator_Name { get; set; }
        public string Sampling_Plan_Creator_Initial { get; set; }
        public Nullable<int> Sampling_Plan_Year { get; set; }
        public string Sampling_Plan_Access_Code { get; set; }
        public Nullable<float> Sampling_Plan_Daily_Duplicate_Precision_Criteria { get; set; }
        public Nullable<float> Sampling_Plan_Intertech_Duplicate_Precision_Criteria { get; set; }
        public string Sampling_Plan_Sampling_Plan_File { get; set; }
        public Nullable<DateTime> Sampling_Plan_Last_Update_Date_UTC { get; set; }
        public string Sampling_Plan_Last_Update_Contact_Name { get; set; }
        public string Sampling_Plan_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportSampling_Plan_Lab_SheetModel
    {
        public ReportSampling_Plan_Lab_SheetModel()
        {
            Sampling_Plan_Lab_Sheet_Error = "";
        }
    
        public string Sampling_Plan_Lab_Sheet_Error { get; set; }
        public Nullable<int> Sampling_Plan_Lab_Sheet_Counter { get; set; }
        public Nullable<int> Sampling_Plan_Lab_Sheet_ID { get; set; }
        public Nullable<int> Sampling_Plan_Lab_Sheet_Other_Server_Lab_Sheet_ID { get; set; }
        public string Sampling_Plan_Lab_Sheet_Sampling_Plan_Name { get; set; }
        public string Sampling_Plan_Lab_Sheet_Province { get; set; }
        public string Sampling_Plan_Lab_Sheet_For_Group_Name { get; set; }
        public Nullable<int> Sampling_Plan_Lab_Sheet_Year { get; set; }
        public Nullable<int> Sampling_Plan_Lab_Sheet_Month { get; set; }
        public Nullable<int> Sampling_Plan_Lab_Sheet_Day { get; set; }
        public string Sampling_Plan_Lab_Sheet_Access_Code { get; set; }
        public Nullable<float> Sampling_Plan_Lab_Sheet_Daily_Duplicate_Precision_Criteria { get; set; }
        public Nullable<float> Sampling_Plan_Lab_Sheet_Intertech_Duplicate_Precision_Criteria { get; set; }
        public string Sampling_Plan_Lab_Sheet_Subsector_Name_Short { get; set; }
        public string Sampling_Plan_Lab_Sheet_Subsector_Name_Long { get; set; }
        public Nullable<SamplingPlanTypeEnum> Sampling_Plan_Lab_Sheet_Sampling_Plan_Type { get; set; }
        public string Sampling_Plan_Lab_Sheet_Sample_Type { get; set; }
        public Nullable<LabSheetTypeEnum> Sampling_Plan_Lab_Sheet_Lab_Sheet_Type { get; set; }
        public Nullable<LabSheetStatusEnum> Sampling_Plan_Lab_Sheet_Status { get; set; }
        public string Sampling_Plan_Lab_Sheet_File_Name { get; set; }
        public Nullable<DateTime> Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local { get; set; }
        public string Sampling_Plan_Lab_Sheet_File_Content { get; set; }
        public string Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name { get; set; }
        public string Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial { get; set; }
        public Nullable<DateTime> Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time { get; set; }
        public Nullable<DateTime> Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC { get; set; }
        public string Sampling_Plan_Lab_Sheet_Last_Update_Contact_Name { get; set; }
        public string Sampling_Plan_Lab_Sheet_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportSampling_Plan_Lab_Sheet_DetailModel
    {
        public ReportSampling_Plan_Lab_Sheet_DetailModel()
        {
            Sampling_Plan_Lab_Sheet_Detail_Error = "";
        }
    
        public string Sampling_Plan_Lab_Sheet_Detail_Error { get; set; }
        public Nullable<int> Sampling_Plan_Lab_Sheet_Detail_Counter { get; set; }
        public Nullable<int> Sampling_Plan_Lab_Sheet_Detail_ID { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Version { get; set; }
        public Nullable<DateTime> Sampling_Plan_Lab_Sheet_Detail_Run_Date { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Tides { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Sample_Crew_Initials { get; set; }
        public Nullable<DateTime> Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time { get; set; }
        public Nullable<DateTime> Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time { get; set; }
        public Nullable<DateTime> Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time { get; set; }
        public Nullable<DateTime> Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time { get; set; }
        public Nullable<DateTime> Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time { get; set; }
        public Nullable<DateTime> Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time { get; set; }
        public Nullable<int> Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes { get; set; }
        public Nullable<int> Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes { get; set; }
        public Nullable<int> Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Water_Bath1 { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Water_Bath2 { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Water_Bath3 { get; set; }
        public Nullable<float> Sampling_Plan_Lab_Sheet_Detail_TC_Field_1 { get; set; }
        public Nullable<float> Sampling_Plan_Lab_Sheet_Detail_TC_Lab_1 { get; set; }
        public Nullable<float> Sampling_Plan_Lab_Sheet_Detail_TC_Field_2 { get; set; }
        public Nullable<float> Sampling_Plan_Lab_Sheet_Detail_TC_Lab_2 { get; set; }
        public Nullable<float> Sampling_Plan_Lab_Sheet_Detail_TC_First { get; set; }
        public Nullable<float> Sampling_Plan_Lab_Sheet_Detail_TC_Average { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Control_Lot { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Positive_35 { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Non_Target_35 { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Negative_35 { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Bath1_Positive_44_5 { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Bath2_Positive_44_5 { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Bath3_Positive_44_5 { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Bath1_Non_Target_44_5 { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Bath2_Non_Target_44_5 { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Bath3_Non_Target_44_5 { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Bath1_Negative_44_5 { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Bath2_Negative_44_5 { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Bath3_Negative_44_5 { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Blank_35 { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Bath1_Blank_44_5 { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Bath2_Blank_44_5 { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Bath3_Blank_44_5 { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Lot_35 { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Lot_44_5 { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Run_Comment { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Run_Weather_Comment { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Sample_Bottle_Lot_Number { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_By { get; set; }
        public Nullable<DateTime> Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Results_Read_By { get; set; }
        public Nullable<DateTime> Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_By { get; set; }
        public Nullable<DateTime> Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date { get; set; }
        public Nullable<float> Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_R_Log { get; set; }
        public Nullable<float> Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria { get; set; }
        public Nullable<bool> Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_Acceptable { get; set; }
        public Nullable<float> Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_R_Log { get; set; }
        public Nullable<float> Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria { get; set; }
        public Nullable<bool> Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_Acceptable { get; set; }
        public Nullable<bool> Sampling_Plan_Lab_Sheet_Detail_Intertech_Read_Acceptable { get; set; }
        public Nullable<DateTime> Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Name { get; set; }
        public string Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel
    {
        public ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel()
        {
            Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Error = "";
        }
    
        public string Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Error { get; set; }
        public Nullable<int> Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Counter { get; set; }
        public Nullable<int> Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_ID { get; set; }
        public Nullable<int> Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Ordinal { get; set; }
        public string Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site { get; set; }
        public Nullable<DateTime> Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time { get; set; }
        public Nullable<int> Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_MPN { get; set; }
        public Nullable<int> Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Tube_10 { get; set; }
        public Nullable<int> Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0 { get; set; }
        public Nullable<int> Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1 { get; set; }
        public Nullable<float> Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Salinity { get; set; }
        public Nullable<float> Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Temperature { get; set; }
        public string Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Processed_By { get; set; }
        public string Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type { get; set; }
        public string Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment { get; set; }
        public Nullable<DateTime> Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC { get; set; }
        public string Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name { get; set; }
        public string Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportSampling_Plan_SubsectorModel
    {
        public ReportSampling_Plan_SubsectorModel()
        {
            Sampling_Plan_Subsector_Error = "";
        }
    
        public string Sampling_Plan_Subsector_Error { get; set; }
        public Nullable<int> Sampling_Plan_Subsector_Counter { get; set; }
        public Nullable<int> Sampling_Plan_Subsector_ID { get; set; }
        public string Sampling_Plan_Subsector_Name_Short { get; set; }
        public string Sampling_Plan_Subsector_Name_Long { get; set; }
        public Nullable<DateTime> Sampling_Plan_Subsector_Last_Update_Date_UTC { get; set; }
        public string Sampling_Plan_Subsector_Last_Update_Contact_Name { get; set; }
        public string Sampling_Plan_Subsector_Last_Update_Contact_Initial { get; set; }
        public Nullable<float> Sampling_Plan_Subsector_Lat { get; set; }
        public Nullable<float> Sampling_Plan_Subsector_Lng { get; set; }
    }
    public class ReportSampling_Plan_Subsector_SiteModel
    {
        public ReportSampling_Plan_Subsector_SiteModel()
        {
            Sampling_Plan_Subsector_Site_Error = "";
        }
    
        public string Sampling_Plan_Subsector_Site_Error { get; set; }
        public Nullable<int> Sampling_Plan_Subsector_Site_Counter { get; set; }
        public Nullable<int> Sampling_Plan_Subsector_Site_ID { get; set; }
        public string Sampling_Plan_Subsector_Site_MWQM_Site { get; set; }
        public Nullable<bool> Sampling_Plan_Subsector_Site_Is_Duplicate { get; set; }
        public Nullable<DateTime> Sampling_Plan_Subsector_Site_Last_Update_Date_UTC { get; set; }
        public string Sampling_Plan_Subsector_Site_Last_Update_Contact_Name { get; set; }
        public string Sampling_Plan_Subsector_Site_Last_Update_Contact_Initial { get; set; }
        public Nullable<float> Sampling_Plan_Subsector_Site_Lat { get; set; }
        public Nullable<float> Sampling_Plan_Subsector_Site_Lng { get; set; }
    }
    public class ReportClimate_SiteModel
    {
        public ReportClimate_SiteModel()
        {
            Climate_Site_Error = "";
        }
    
        public string Climate_Site_Error { get; set; }
        public Nullable<int> Climate_Site_Counter { get; set; }
        public Nullable<int> Climate_Site_ID { get; set; }
        public Nullable<int> Climate_Site_ECDBID { get; set; }
        public string Climate_Site_Name { get; set; }
        public string Climate_Site_Province { get; set; }
        public Nullable<float> Climate_Site_Elevation_m { get; set; }
        public string Climate_Site_Climate_ID { get; set; }
        public Nullable<int> Climate_Site_WMOID { get; set; }
        public string Climate_Site_TCID { get; set; }
        public Nullable<bool> Climate_Site_Is_Quebec_Site { get; set; }
        public Nullable<float> Climate_Site_Time_Offset_hour { get; set; }
        public string Climate_Site_File_desc { get; set; }
        public Nullable<DateTime> Climate_Site_Hourly_Start_Date_Local { get; set; }
        public Nullable<DateTime> Climate_Site_Hourly_End_Date_Local { get; set; }
        public Nullable<bool> Climate_Site_Hourly_Now { get; set; }
        public Nullable<DateTime> Climate_Site_Daily_Start_Date_Local { get; set; }
        public Nullable<DateTime> Climate_Site_Daily_End_Date_Local { get; set; }
        public Nullable<bool> Climate_Site_Daily_Now { get; set; }
        public Nullable<DateTime> Climate_Site_Monthly_Start_Date_Local { get; set; }
        public Nullable<DateTime> Climate_Site_Monthly_End_Date_Local { get; set; }
        public Nullable<bool> Climate_Site_Monthly_Now { get; set; }
        public Nullable<DateTime> Climate_Site_Last_Update_Date_UTC { get; set; }
        public string Climate_Site_Last_Update_Contact_Name { get; set; }
        public string Climate_Site_Last_Update_Contact_Initial { get; set; }
        public Nullable<float> Climate_Site_Lat { get; set; }
        public Nullable<float> Climate_Site_Lng { get; set; }
    }
    public class ReportClimate_Site_DataModel
    {
        public ReportClimate_Site_DataModel()
        {
            Climate_Site_Data_Error = "";
        }
    
        public string Climate_Site_Data_Error { get; set; }
        public Nullable<int> Climate_Site_Data_Counter { get; set; }
        public Nullable<int> Climate_Site_Data_ID { get; set; }
        public Nullable<DateTime> Climate_Site_Data_Date_Time_Local { get; set; }
        public Nullable<bool> Climate_Site_Data_Keep { get; set; }
        public Nullable<StorageDataTypeEnum> Climate_Site_Data_Storage_Data_Type { get; set; }
        public Nullable<float> Climate_Site_Data_Snow_cm { get; set; }
        public Nullable<float> Climate_Site_Data_Rainfall_mm { get; set; }
        public Nullable<float> Climate_Site_Data_Rainfall_Entered_mm { get; set; }
        public Nullable<float> Climate_Site_Data_Total_Precip_mm_cm { get; set; }
        public Nullable<float> Climate_Site_Data_Max_Temp_C { get; set; }
        public Nullable<float> Climate_Site_Data_Min_Temp_C { get; set; }
        public Nullable<float> Climate_Site_Data_Heat_Deg_Days_C { get; set; }
        public Nullable<float> Climate_Site_Data_Cool_Deg_Days_C { get; set; }
        public Nullable<float> Climate_Site_Data_Snow_On_Ground_cm { get; set; }
        public Nullable<float> Climate_Site_Data_Dir_Max_Gust_0North { get; set; }
        public Nullable<float> Climate_Site_Data_Spd_Max_Gust_kmh { get; set; }
        public string Climate_Site_Data_Hourly_Values { get; set; }
        public Nullable<DateTime> Climate_Site_Data_Last_Update_Date_UTC { get; set; }
        public string Climate_Site_Data_Last_Update_Contact_Name { get; set; }
        public string Climate_Site_Data_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportHydrometric_SiteModel
    {
        public ReportHydrometric_SiteModel()
        {
            Hydrometric_Site_Error = "";
        }
    
        public string Hydrometric_Site_Error { get; set; }
        public Nullable<int> Hydrometric_Site_Counter { get; set; }
        public Nullable<int> Hydrometric_Site_ID { get; set; }
        public string Hydrometric_Site_Fed_Site_Number { get; set; }
        public string Hydrometric_Site_Quebec_Site_Number { get; set; }
        public string Hydrometric_Site_Name { get; set; }
        public string Hydrometric_Site_Description { get; set; }
        public string Hydrometric_Site_Province { get; set; }
        public Nullable<float> Hydrometric_Site_Elevation_m { get; set; }
        public Nullable<DateTime> Hydrometric_Site_Start_Date_Local { get; set; }
        public Nullable<DateTime> Hydrometric_Site_End_Date_Local { get; set; }
        public Nullable<float> Hydrometric_Site_Time_Offset_hour { get; set; }
        public Nullable<float> Hydrometric_Site_Drainage_Area_km2 { get; set; }
        public Nullable<bool> Hydrometric_Site_Is_Natural { get; set; }
        public Nullable<bool> Hydrometric_Site_Is_Active { get; set; }
        public Nullable<bool> Hydrometric_Site_Sediment { get; set; }
        public Nullable<bool> Hydrometric_Site_RHBN { get; set; }
        public Nullable<bool> Hydrometric_Site_Real_Time { get; set; }
        public Nullable<bool> Hydrometric_Site_Has_Rating_Curve { get; set; }
        public Nullable<DateTime> Hydrometric_Site_Last_Update_Date_UTC { get; set; }
        public string Hydrometric_Site_Last_Update_Contact_Name { get; set; }
        public string Hydrometric_Site_Last_Update_Contact_Initial { get; set; }
        public Nullable<float> Hydrometric_Site_Lat { get; set; }
        public Nullable<float> Hydrometric_Site_Lng { get; set; }
    }
    public class ReportHydrometric_Site_DataModel
    {
        public ReportHydrometric_Site_DataModel()
        {
            Hydrometric_Site_Data_Error = "";
        }
    
        public string Hydrometric_Site_Data_Error { get; set; }
        public Nullable<int> Hydrometric_Site_Data_Counter { get; set; }
        public Nullable<int> Hydrometric_Site_Data_ID { get; set; }
        public Nullable<DateTime> Hydrometric_Site_Data_Date_Time_Local { get; set; }
        public Nullable<bool> Hydrometric_Site_Data_Keep { get; set; }
        public Nullable<StorageDataTypeEnum> Hydrometric_Site_Data_Storage_Data_Type { get; set; }
        public Nullable<float> Hydrometric_Site_Data_Discharge_m3_s { get; set; }
        public Nullable<float> Hydrometric_Site_Data_DischargeEntered_m3_s { get; set; }
        public Nullable<float> Hydrometric_Site_Data_Level_m { get; set; }
        public string Hydrometric_Site_Data_Hourly_Values { get; set; }
        public Nullable<DateTime> Hydrometric_Site_Data_Last_Update_Date_UTC { get; set; }
        public string Hydrometric_Site_Data_Last_Update_Contact_Name { get; set; }
        public string Hydrometric_Site_Data_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportHydrometric_Site_Rating_CurveModel
    {
        public ReportHydrometric_Site_Rating_CurveModel()
        {
            Hydrometric_Site_Rating_Curve_Error = "";
        }
    
        public string Hydrometric_Site_Rating_Curve_Error { get; set; }
        public Nullable<int> Hydrometric_Site_Rating_Curve_Counter { get; set; }
        public Nullable<int> Hydrometric_Site_Rating_Curve_ID { get; set; }
        public string Hydrometric_Site_Rating_Curve_Rating_Curve_Number { get; set; }
        public Nullable<DateTime> Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC { get; set; }
        public string Hydrometric_Site_Rating_Curve_Last_Update_Contact_Name { get; set; }
        public string Hydrometric_Site_Rating_Curve_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportHydrometric_Site_Rating_Curve_ValueModel
    {
        public ReportHydrometric_Site_Rating_Curve_ValueModel()
        {
            Hydrometric_Site_Rating_Curve_Value_Error = "";
        }
    
        public string Hydrometric_Site_Rating_Curve_Value_Error { get; set; }
        public Nullable<int> Hydrometric_Site_Rating_Curve_Value_Counter { get; set; }
        public Nullable<int> Hydrometric_Site_Rating_Curve_Value_ID { get; set; }
        public Nullable<float> Hydrometric_Site_Rating_Curve_Value_Stage_Value_m { get; set; }
        public Nullable<float> Hydrometric_Site_Rating_Curve_Value_Discharge_Value_m3_s { get; set; }
        public Nullable<DateTime> Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC { get; set; }
        public string Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Name { get; set; }
        public string Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportProvince_FileModel
    {
        public ReportProvince_FileModel()
        {
            Province_File_Error = "";
        }
    
        public string Province_File_Error { get; set; }
        public Nullable<int> Province_File_Counter { get; set; }
        public Nullable<int> Province_File_ID { get; set; }
        public Nullable<LanguageEnum> Province_File_Language { get; set; }
        public Nullable<FilePurposeEnum> Province_File_Purpose { get; set; }
        public Nullable<FileTypeEnum> Province_File_Type { get; set; }
        public string Province_File_Description { get; set; }
        public Nullable<int> Province_File_Size_kb { get; set; }
        public string Province_File_Info { get; set; }
        public Nullable<DateTime> Province_File_Created_Date_UTC { get; set; }
        public Nullable<bool> Province_File_From_Water { get; set; }
        public string Province_File_Server_File_Name { get; set; }
        public string Province_File_Server_File_Path { get; set; }
        public Nullable<DateTime> Province_File_Last_Update_Date_And_Time_UTC { get; set; }
        public string Province_File_Last_Update_Contact_Name { get; set; }
        public string Province_File_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportCountry_FileModel
    {
        public ReportCountry_FileModel()
        {
            Country_File_Error = "";
        }
    
        public string Country_File_Error { get; set; }
        public Nullable<int> Country_File_Counter { get; set; }
        public Nullable<int> Country_File_ID { get; set; }
        public Nullable<LanguageEnum> Country_File_Language { get; set; }
        public Nullable<FilePurposeEnum> Country_File_Purpose { get; set; }
        public Nullable<FileTypeEnum> Country_File_Type { get; set; }
        public string Country_File_Description { get; set; }
        public Nullable<int> Country_File_Size_kb { get; set; }
        public string Country_File_Info { get; set; }
        public Nullable<DateTime> Country_File_Created_Date_UTC { get; set; }
        public Nullable<bool> Country_File_From_Water { get; set; }
        public string Country_File_Server_File_Name { get; set; }
        public string Country_File_Server_File_Path { get; set; }
        public Nullable<DateTime> Country_File_Last_Update_Date_And_Time_UTC { get; set; }
        public string Country_File_Last_Update_Contact_Name { get; set; }
        public string Country_File_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportMPN_LookupModel
    {
        public ReportMPN_LookupModel()
        {
            MPN_Lookup_Error = "";
        }
    
        public string MPN_Lookup_Error { get; set; }
        public Nullable<int> MPN_Lookup_Counter { get; set; }
        public Nullable<int> MPN_Lookup_ID { get; set; }
        public Nullable<int> MPN_Lookup_Tubes_10 { get; set; }
        public Nullable<int> MPN_Lookup_Tubes_1_0 { get; set; }
        public Nullable<int> MPN_Lookup_Tubes_0_1 { get; set; }
        public Nullable<int> MPN_Lookup_MPN_100_ml { get; set; }
        public Nullable<DateTime> MPN_Lookup_Last_Update_Date_And_Time_UTC { get; set; }
        public string MPN_Lookup_Last_Update_Contact_Name { get; set; }
        public string MPN_Lookup_Last_Update_Contact_Initial { get; set; }
    }
    public class ReportRoot_FileModel
    {
        public ReportRoot_FileModel()
        {
            Root_File_Error = "";
        }
    
        public string Root_File_Error { get; set; }
        public Nullable<int> Root_File_Counter { get; set; }
        public Nullable<int> Root_File_ID { get; set; }
        public Nullable<LanguageEnum> Root_File_Language { get; set; }
        public Nullable<FilePurposeEnum> Root_File_Purpose { get; set; }
        public Nullable<FileTypeEnum> Root_File_Type { get; set; }
        public string Root_File_Description { get; set; }
        public Nullable<int> Root_File_Size_kb { get; set; }
        public string Root_File_Info { get; set; }
        public Nullable<DateTime> Root_File_Created_Date_UTC { get; set; }
        public Nullable<bool> Root_File_From_Water { get; set; }
        public string Root_File_Server_File_Name { get; set; }
        public string Root_File_Server_File_Path { get; set; }
        public Nullable<DateTime> Root_File_Last_Update_Date_And_Time_UTC { get; set; }
        public string Root_File_Last_Update_Contact_Name { get; set; }
        public string Root_File_Last_Update_Contact_Initial { get; set; }
    }
}
