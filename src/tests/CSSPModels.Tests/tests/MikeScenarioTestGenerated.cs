/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [[ModelClassName]TestGenerated.cs] button
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
    public partial class MikeScenarioTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MikeScenario mikeScenario { get; set; }
        #endregion Properties

        #region Constructors
        public MikeScenarioTest()
        {
            mikeScenario = new MikeScenario();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void MikeScenario_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "MikeScenarioID", "MikeScenarioTVItemID", "ParentMikeScenarioID", "ScenarioStatus", "ErrorInfo", "MikeScenarioStartDateTime_Local", "MikeScenarioEndDateTime_Local", "MikeScenarioStartExecutionDateTime_Local", "MikeScenarioExecutionTime_min", "WindSpeed_km_h", "WindDirection_deg", "DecayFactor_per_day", "DecayIsConstant", "DecayFactorAmplitude", "ResultFrequency_min", "AmbientTemperature_C", "AmbientSalinity_PSU", "GenerateDecouplingFiles", "UseDecouplingFiles", "UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID", "ForSimulatingMWQMRunTVItemID", "ManningNumber", "NumberOfElements", "NumberOfTimeSteps", "NumberOfSigmaLayers", "NumberOfZLayers", "NumberOfHydroOutputParameters", "NumberOfTransOutputParameters", "EstimatedHydroFileSize", "EstimatedTransFileSize", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() { "HasErrors",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MikeScenario).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(MikeScenario).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void MikeScenario_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MikeScenario).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(MikeScenario).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void MikeScenario_Has_ValidationResults_Test()
        {
             Assert.True(typeof(MikeScenario).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void MikeScenario_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               mikeScenario.MikeScenarioID = val1;
               Assert.Equal(val1, mikeScenario.MikeScenarioID);
               int val2 = 45;
               mikeScenario.MikeScenarioTVItemID = val2;
               Assert.Equal(val2, mikeScenario.MikeScenarioTVItemID);
               int val3 = 45;
               mikeScenario.ParentMikeScenarioID = val3;
               Assert.Equal(val3, mikeScenario.ParentMikeScenarioID);
               ScenarioStatusEnum val4 = (ScenarioStatusEnum)3;
               mikeScenario.ScenarioStatus = val4;
               Assert.Equal(val4, mikeScenario.ScenarioStatus);
               string val5 = "Some text";
               mikeScenario.ErrorInfo = val5;
               Assert.Equal(val5, mikeScenario.ErrorInfo);
               DateTime val6 = new DateTime(2010, 3, 4);
               mikeScenario.MikeScenarioStartDateTime_Local = val6;
               Assert.Equal(val6, mikeScenario.MikeScenarioStartDateTime_Local);
               DateTime val7 = new DateTime(2010, 3, 4);
               mikeScenario.MikeScenarioEndDateTime_Local = val7;
               Assert.Equal(val7, mikeScenario.MikeScenarioEndDateTime_Local);
               DateTime val8 = new DateTime(2010, 3, 4);
               mikeScenario.MikeScenarioStartExecutionDateTime_Local = val8;
               Assert.Equal(val8, mikeScenario.MikeScenarioStartExecutionDateTime_Local);
               double val9 = 87.9D;
               mikeScenario.MikeScenarioExecutionTime_min = val9;
               Assert.Equal(val9, mikeScenario.MikeScenarioExecutionTime_min);
               double val10 = 87.9D;
               mikeScenario.WindSpeed_km_h = val10;
               Assert.Equal(val10, mikeScenario.WindSpeed_km_h);
               double val11 = 87.9D;
               mikeScenario.WindDirection_deg = val11;
               Assert.Equal(val11, mikeScenario.WindDirection_deg);
               double val12 = 87.9D;
               mikeScenario.DecayFactor_per_day = val12;
               Assert.Equal(val12, mikeScenario.DecayFactor_per_day);
               bool val13 = true;
               mikeScenario.DecayIsConstant = val13;
               Assert.Equal(val13, mikeScenario.DecayIsConstant);
               double val14 = 87.9D;
               mikeScenario.DecayFactorAmplitude = val14;
               Assert.Equal(val14, mikeScenario.DecayFactorAmplitude);
               int val15 = 45;
               mikeScenario.ResultFrequency_min = val15;
               Assert.Equal(val15, mikeScenario.ResultFrequency_min);
               double val16 = 87.9D;
               mikeScenario.AmbientTemperature_C = val16;
               Assert.Equal(val16, mikeScenario.AmbientTemperature_C);
               double val17 = 87.9D;
               mikeScenario.AmbientSalinity_PSU = val17;
               Assert.Equal(val17, mikeScenario.AmbientSalinity_PSU);
               bool val18 = true;
               mikeScenario.GenerateDecouplingFiles = val18;
               Assert.Equal(val18, mikeScenario.GenerateDecouplingFiles);
               bool val19 = true;
               mikeScenario.UseDecouplingFiles = val19;
               Assert.Equal(val19, mikeScenario.UseDecouplingFiles);
               int val20 = 45;
               mikeScenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID = val20;
               Assert.Equal(val20, mikeScenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID);
               int val21 = 45;
               mikeScenario.ForSimulatingMWQMRunTVItemID = val21;
               Assert.Equal(val21, mikeScenario.ForSimulatingMWQMRunTVItemID);
               double val22 = 87.9D;
               mikeScenario.ManningNumber = val22;
               Assert.Equal(val22, mikeScenario.ManningNumber);
               int val23 = 45;
               mikeScenario.NumberOfElements = val23;
               Assert.Equal(val23, mikeScenario.NumberOfElements);
               int val24 = 45;
               mikeScenario.NumberOfTimeSteps = val24;
               Assert.Equal(val24, mikeScenario.NumberOfTimeSteps);
               int val25 = 45;
               mikeScenario.NumberOfSigmaLayers = val25;
               Assert.Equal(val25, mikeScenario.NumberOfSigmaLayers);
               int val26 = 45;
               mikeScenario.NumberOfZLayers = val26;
               Assert.Equal(val26, mikeScenario.NumberOfZLayers);
               int val27 = 45;
               mikeScenario.NumberOfHydroOutputParameters = val27;
               Assert.Equal(val27, mikeScenario.NumberOfHydroOutputParameters);
               int val28 = 45;
               mikeScenario.NumberOfTransOutputParameters = val28;
               Assert.Equal(val28, mikeScenario.NumberOfTransOutputParameters);
               int val29 = 45;
               mikeScenario.EstimatedHydroFileSize = val29;
               Assert.Equal(val29, mikeScenario.EstimatedHydroFileSize);
               int val30 = 45;
               mikeScenario.EstimatedTransFileSize = val30;
               Assert.Equal(val30, mikeScenario.EstimatedTransFileSize);
               DateTime val31 = new DateTime(2010, 3, 4);
               mikeScenario.LastUpdateDate_UTC = val31;
               Assert.Equal(val31, mikeScenario.LastUpdateDate_UTC);
               int val32 = 45;
               mikeScenario.LastUpdateContactTVItemID = val32;
               Assert.Equal(val32, mikeScenario.LastUpdateContactTVItemID);
               bool val33 = true;
               mikeScenario.HasErrors = val33;
               Assert.Equal(val33, mikeScenario.HasErrors);
               IEnumerable<ValidationResult> val102 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               mikeScenario.ValidationResults = val102;
               Assert.Equal(val102, mikeScenario.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
