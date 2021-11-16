﻿using CSSPEnums;
using CSSPGenerateCodeBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsGenerateCodeHelper
{
    public partial class ModelsCodeWriter : GenerateCodeBase
    {
        #region Variables
        #endregion Variables

        #region Properties
        public List<TableFieldEnumException> TableFieldEnumExceptionList { get; set; }
        public List<TableFieldEmail> TableFieldEmailList { get; set; }
        public List<TableFieldIDException> TableFieldIDExceptionList { get; set; }
        #endregion Properties

        #region Constructors
        public ModelsCodeWriter()
        {
            FillPublicList();
        }
        #endregion Constructors

        #region Events
        #endregion Events

        #region Functions public
        #endregion Functions public

        #region Functions private
        private void FillPublicList()
        {
            TableFieldEnumExceptionList = new List<TableFieldEnumException>()
            {
                new TableFieldEnumException() { TableName = "MWQMAnalysisReportParameters", FieldName = "Command", EnumText = "AnalysisReportExportCommandEnum" },
                new TableFieldEnumException() { TableName = "MWQMRunLanguages", FieldName = "TranslationStatusRunComment", EnumText = "TranslationStatusEnum" },
                new TableFieldEnumException() { TableName = "MWQMRunLanguages", FieldName = "TranslationStatusRunWeatherComment", EnumText = "TranslationStatusEnum" },
                new TableFieldEnumException() { TableName = "MWQMRuns", FieldName = "RunSampleType", EnumText = "SampleTypeEnum" },
                new TableFieldEnumException() { TableName = "MWQMRuns", FieldName = "SeaStateAtStart_BeaufortScale", EnumText = "BeaufortScaleEnum" },
                new TableFieldEnumException() { TableName = "MWQMRuns", FieldName = "SeaStateAtEnd_BeaufortScale", EnumText = "BeaufortScaleEnum" },
                new TableFieldEnumException() { TableName = "MWQMRuns", FieldName = "Tide_Start", EnumText = "TideTextEnum" },
                new TableFieldEnumException() { TableName = "MWQMRuns", FieldName = "Tide_End", EnumText = "TideTextEnum" },
                new TableFieldEnumException() { TableName = "MWQMSubsectorLanguages", FieldName = "TranslationStatusSubsectorDesc", EnumText = "TranslationStatusEnum" },
                new TableFieldEnumException() { TableName = "MWQMSubsectorLanguages", FieldName = "TranslationStatusLogBook", EnumText = "TranslationStatusEnum" },
                new TableFieldEnumException() { TableName = "MWQMSamples", FieldName = "SampleType_old", EnumText = "SampleTypeEnum" },
                new TableFieldEnumException() { TableName = "PolSourceSites", FieldName = "InactiveReason", EnumText = "PolSourceInactiveReasonEnum" },
                new TableFieldEnumException() { TableName = "ReportTypeLanguages", FieldName = "TranslationStatusName", EnumText = "TranslationStatusEnum" },
                new TableFieldEnumException() { TableName = "ReportTypeLanguages", FieldName = "TranslationStatusDescription", EnumText = "TranslationStatusEnum" },
                new TableFieldEnumException() { TableName = "ReportTypeLanguages", FieldName = "TranslationStatusStartOfFileName", EnumText = "TranslationStatusEnum" },
                new TableFieldEnumException() { TableName = "ReportSectionLanguages", FieldName = "TranslationStatusReportSectionName", EnumText = "TranslationStatusEnum" },
                new TableFieldEnumException() { TableName = "ReportSectionLanguages", FieldName = "TranslationStatusReportSectionText", EnumText = "TranslationStatusEnum" },
                new TableFieldEnumException() { TableName = "SamplingPlans", FieldName = "AnalyzeMethodDefault", EnumText = "AnalyzeMethodEnum" },
                new TableFieldEnumException() { TableName = "SamplingPlans", FieldName = "SampleMatrixDefault", EnumText = "SampleMatrixEnum" },
                new TableFieldEnumException() { TableName = "SamplingPlans", FieldName = "LaboratoryDefault", EnumText = "LaboratoryEnum" },
                new TableFieldEnumException() { TableName = "TideDataValues", FieldName = "TideStart", EnumText = "TideTextEnum" },
                new TableFieldEnumException() { TableName = "TideDataValues", FieldName = "TideEnd", EnumText = "TideTextEnum" },
                new TableFieldEnumException() { TableName = "TVFiles", FieldName = "TemplateTVType", EnumText = "TVTypeEnum" },
                new TableFieldEnumException() { TableName = "TVItemLinks", FieldName = "FromTVType", EnumText = "TVTypeEnum" },
                new TableFieldEnumException() { TableName = "TVItemLinks", FieldName = "ToTVType", EnumText = "TVTypeEnum" },
                new TableFieldEnumException() { TableName = "VPScenarios", FieldName = "VPScenarioStatus", EnumText = "ScenarioStatusEnum" },
            };

            TableFieldEmailList = new List<TableFieldEmail>()
            {
                new TableFieldEmail() { TableName = "ContactLogins", FieldName = "LoginEmail" },
                new TableFieldEmail() { TableName = "Contacts", FieldName = "LoginEmail" },
                new TableFieldEmail() { TableName = "EmailDistributionListContacts", FieldName = "Email" },
                new TableFieldEmail() { TableName = "Emails", FieldName = "EmailAddress" },
            };

            TableFieldIDExceptionList = new List<TableFieldIDException>()
            {
                new TableFieldIDException() { TableName = "ClimateSites", FieldName = "ECDBID" },
                new TableFieldIDException() { TableName = "ClimateSites", FieldName = "WMOID" },
                new TableFieldIDException() { TableName = "Infrastructures", FieldName = "PrismID" },
                new TableFieldIDException() { TableName = "Infrastructures", FieldName = "TPID" },
                new TableFieldIDException() { TableName = "Infrastructures", FieldName = "LSID" },
                new TableFieldIDException() { TableName = "Infrastructures", FieldName = "SiteID" },
                new TableFieldIDException() { TableName = "LabSheets", FieldName = "OtherServerLabSheetID" },
                new TableFieldIDException() { TableName = "Logs", FieldName = "ID" },
                new TableFieldIDException() { TableName = "PolSourceSites", FieldName = "SiteID" },
            };
        }
        #endregion Functions private
    }

}
