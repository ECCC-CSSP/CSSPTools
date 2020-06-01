/*
 * Auto generated from C:\CSSPTools\src\codegen\ModelsModelClassNameTestGenerated_cs\bin\Debug\netcoreapp3.1\ModelsModelClassNameTestGenerated_cs.exe
 *
 * Do not edit this file.
 *
 */ 
using System;
using System.Text;
using Xunit;
using System.Linq;
using System.Globalization;
using System.Transactions;
using System.Collections.Generic;
using CSSPModels.Resources;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.ComponentModel.DataAnnotations;

namespace CSSPModels.Tests
{
    public partial class MWQMAnalysisReportParameterTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MWQMAnalysisReportParameter mWQMAnalysisReportParameter { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMAnalysisReportParameterTest()
        {
            mWQMAnalysisReportParameter = new MWQMAnalysisReportParameter();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void MWQMAnalysisReportParameter_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "MWQMAnalysisReportParameterID", "SubsectorTVItemID", "AnalysisName", "AnalysisReportYear", "StartDate", "EndDate", "AnalysisCalculationType", "NumberOfRuns", "FullYear", "SalinityHighlightDeviationFromAverage", "ShortRangeNumberOfDays", "MidRangeNumberOfDays", "DryLimit24h", "DryLimit48h", "DryLimit72h", "DryLimit96h", "WetLimit24h", "WetLimit48h", "WetLimit72h", "WetLimit96h", "RunsToOmit", "ShowDataTypes", "ExcelTVFileTVItemID", "Command", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() { "HasErrors",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MWQMAnalysisReportParameter).GetProperties().OrderBy(c => c.Name))
            {
                if (!propertyInfo.GetGetMethod().IsVirtual
                    && propertyInfo.Name != "ValidationResults"
                    && !propertyInfo.CustomAttributes.Where(c => c.AttributeType.Name.Contains("NotMappedAttribute")).Any())
                {
                    Assert.Equal(propNameList[index], propertyInfo.Name);
                    index += 1;
                }
            }

            Assert.Equal(propNameList.Count, index);

            index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MWQMAnalysisReportParameter).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                foreach (CustomAttributeData customAttributeData in propertyInfo.CustomAttributes)
                {
                    if (customAttributeData.AttributeType.Name == "NotMappedAttribute")
                    {
                        Assert.Equal(propertyInfo.Name, propNameNotMappedList[index]);
                        index += 1;
                    }
                }
            }

            Assert.Equal(propNameNotMappedList.Count, index);

        }
        [Fact]
        public void MWQMAnalysisReportParameter_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MWQMAnalysisReportParameter).GetProperties())
            {
                if (propertyInfo.GetGetMethod().IsVirtual && !propertyInfo.GetGetMethod().ReturnType.Name.StartsWith("ICollection"))
                {
                    bool foreignNameExist = foreignNameList.Contains(propertyInfo.Name);
                    Assert.True(foreignNameExist);
                    index += 1;
                }
            }

            Assert.Equal(foreignNameList.Count, index);

            index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MWQMAnalysisReportParameter).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                if (propertyInfo.GetGetMethod().ReturnType.Name.StartsWith("ICollection"))
                {
                    bool foreignNameCollectionExist = foreignNameCollectionList.Contains(propertyInfo.Name);
                    Assert.True(foreignNameCollectionExist);
                    index += 1;
                }
            }

            Assert.Equal(foreignNameCollectionList.Count, index);

        }
        [Fact]
        public void MWQMAnalysisReportParameter_Has_ValidationResults_Test()
        {
             Assert.True(typeof(MWQMAnalysisReportParameter).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void MWQMAnalysisReportParameter_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               mWQMAnalysisReportParameter.MWQMAnalysisReportParameterID = val1;
               Assert.Equal(val1, mWQMAnalysisReportParameter.MWQMAnalysisReportParameterID);
               int val2 = 45;
               mWQMAnalysisReportParameter.SubsectorTVItemID = val2;
               Assert.Equal(val2, mWQMAnalysisReportParameter.SubsectorTVItemID);
               string val3 = "Some text";
               mWQMAnalysisReportParameter.AnalysisName = val3;
               Assert.Equal(val3, mWQMAnalysisReportParameter.AnalysisName);
               int val4 = 45;
               mWQMAnalysisReportParameter.AnalysisReportYear = val4;
               Assert.Equal(val4, mWQMAnalysisReportParameter.AnalysisReportYear);
               DateTime val5 = new DateTime(2010, 3, 4);
               mWQMAnalysisReportParameter.StartDate = val5;
               Assert.Equal(val5, mWQMAnalysisReportParameter.StartDate);
               DateTime val6 = new DateTime(2010, 3, 4);
               mWQMAnalysisReportParameter.EndDate = val6;
               Assert.Equal(val6, mWQMAnalysisReportParameter.EndDate);
               AnalysisCalculationTypeEnum val7 = (AnalysisCalculationTypeEnum)3;
               mWQMAnalysisReportParameter.AnalysisCalculationType = val7;
               Assert.Equal(val7, mWQMAnalysisReportParameter.AnalysisCalculationType);
               int val8 = 45;
               mWQMAnalysisReportParameter.NumberOfRuns = val8;
               Assert.Equal(val8, mWQMAnalysisReportParameter.NumberOfRuns);
               bool val9 = true;
               mWQMAnalysisReportParameter.FullYear = val9;
               Assert.Equal(val9, mWQMAnalysisReportParameter.FullYear);
               double val10 = 87.9D;
               mWQMAnalysisReportParameter.SalinityHighlightDeviationFromAverage = val10;
               Assert.Equal(val10, mWQMAnalysisReportParameter.SalinityHighlightDeviationFromAverage);
               int val11 = 45;
               mWQMAnalysisReportParameter.ShortRangeNumberOfDays = val11;
               Assert.Equal(val11, mWQMAnalysisReportParameter.ShortRangeNumberOfDays);
               int val12 = 45;
               mWQMAnalysisReportParameter.MidRangeNumberOfDays = val12;
               Assert.Equal(val12, mWQMAnalysisReportParameter.MidRangeNumberOfDays);
               int val13 = 45;
               mWQMAnalysisReportParameter.DryLimit24h = val13;
               Assert.Equal(val13, mWQMAnalysisReportParameter.DryLimit24h);
               int val14 = 45;
               mWQMAnalysisReportParameter.DryLimit48h = val14;
               Assert.Equal(val14, mWQMAnalysisReportParameter.DryLimit48h);
               int val15 = 45;
               mWQMAnalysisReportParameter.DryLimit72h = val15;
               Assert.Equal(val15, mWQMAnalysisReportParameter.DryLimit72h);
               int val16 = 45;
               mWQMAnalysisReportParameter.DryLimit96h = val16;
               Assert.Equal(val16, mWQMAnalysisReportParameter.DryLimit96h);
               int val17 = 45;
               mWQMAnalysisReportParameter.WetLimit24h = val17;
               Assert.Equal(val17, mWQMAnalysisReportParameter.WetLimit24h);
               int val18 = 45;
               mWQMAnalysisReportParameter.WetLimit48h = val18;
               Assert.Equal(val18, mWQMAnalysisReportParameter.WetLimit48h);
               int val19 = 45;
               mWQMAnalysisReportParameter.WetLimit72h = val19;
               Assert.Equal(val19, mWQMAnalysisReportParameter.WetLimit72h);
               int val20 = 45;
               mWQMAnalysisReportParameter.WetLimit96h = val20;
               Assert.Equal(val20, mWQMAnalysisReportParameter.WetLimit96h);
               string val21 = "Some text";
               mWQMAnalysisReportParameter.RunsToOmit = val21;
               Assert.Equal(val21, mWQMAnalysisReportParameter.RunsToOmit);
               string val22 = "Some text";
               mWQMAnalysisReportParameter.ShowDataTypes = val22;
               Assert.Equal(val22, mWQMAnalysisReportParameter.ShowDataTypes);
               int val23 = 45;
               mWQMAnalysisReportParameter.ExcelTVFileTVItemID = val23;
               Assert.Equal(val23, mWQMAnalysisReportParameter.ExcelTVFileTVItemID);
               AnalysisReportExportCommandEnum val24 = (AnalysisReportExportCommandEnum)3;
               mWQMAnalysisReportParameter.Command = val24;
               Assert.Equal(val24, mWQMAnalysisReportParameter.Command);
               DateTime val25 = new DateTime(2010, 3, 4);
               mWQMAnalysisReportParameter.LastUpdateDate_UTC = val25;
               Assert.Equal(val25, mWQMAnalysisReportParameter.LastUpdateDate_UTC);
               int val26 = 45;
               mWQMAnalysisReportParameter.LastUpdateContactTVItemID = val26;
               Assert.Equal(val26, mWQMAnalysisReportParameter.LastUpdateContactTVItemID);
               bool val27 = true;
               mWQMAnalysisReportParameter.HasErrors = val27;
               Assert.Equal(val27, mWQMAnalysisReportParameter.HasErrors);
               IEnumerable<ValidationResult> val84 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               mWQMAnalysisReportParameter.ValidationResults = val84;
               Assert.Equal(val84, mWQMAnalysisReportParameter.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
