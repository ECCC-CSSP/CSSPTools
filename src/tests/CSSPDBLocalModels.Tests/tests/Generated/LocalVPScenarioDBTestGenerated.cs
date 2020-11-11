/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBLocalModels_TestsGenerated.exe
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
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.ComponentModel.DataAnnotations;

namespace CSSPDBLocalModels.Tests
{
    public partial class LocalVPScenarioTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LocalVPScenario localVPScenario { get; set; }
        #endregion Properties

        #region Constructors
        public LocalVPScenarioTest()
        {
            localVPScenario = new LocalVPScenario();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LocalVPScenario_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LocalDBCommand", "VPScenarioID", "InfrastructureTVItemID", "VPScenarioStatus", "UseAsBestEstimate", "EffluentFlow_m3_s", "EffluentConcentration_MPN_100ml", "FroudeNumber", "PortDiameter_m", "PortDepth_m", "PortElevation_m", "VerticalAngle_deg", "HorizontalAngle_deg", "NumberOfPorts", "PortSpacing_m", "AcuteMixZone_m", "ChronicMixZone_m", "EffluentSalinity_PSU", "EffluentTemperature_C", "EffluentVelocity_m_s", "RawResults", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalVPScenario).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(LocalVPScenario).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                foreach (CustomAttributeData customAttributeData in propertyInfo.CustomAttributes)
                {
                    if (customAttributeData.AttributeType.Name == "NotMappedAttribute")
                    {
                    }
                }
            }


        }
        [Fact]
        public void LocalVPScenario_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalVPScenario).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(LocalVPScenario).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalVPScenario_Every_Property_Has_Get_Set_Test()
        {
               LocalDBCommandEnum val1 = (LocalDBCommandEnum)3;
               localVPScenario.LocalDBCommand = val1;
               Assert.Equal(val1, localVPScenario.LocalDBCommand);
               int val2 = 45;
               localVPScenario.VPScenarioID = val2;
               Assert.Equal(val2, localVPScenario.VPScenarioID);
               int val3 = 45;
               localVPScenario.InfrastructureTVItemID = val3;
               Assert.Equal(val3, localVPScenario.InfrastructureTVItemID);
               ScenarioStatusEnum val4 = (ScenarioStatusEnum)3;
               localVPScenario.VPScenarioStatus = val4;
               Assert.Equal(val4, localVPScenario.VPScenarioStatus);
               bool val5 = true;
               localVPScenario.UseAsBestEstimate = val5;
               Assert.Equal(val5, localVPScenario.UseAsBestEstimate);
               double val6 = 87.9D;
               localVPScenario.EffluentFlow_m3_s = val6;
               Assert.Equal(val6, localVPScenario.EffluentFlow_m3_s);
               int val7 = 45;
               localVPScenario.EffluentConcentration_MPN_100ml = val7;
               Assert.Equal(val7, localVPScenario.EffluentConcentration_MPN_100ml);
               double val8 = 87.9D;
               localVPScenario.FroudeNumber = val8;
               Assert.Equal(val8, localVPScenario.FroudeNumber);
               double val9 = 87.9D;
               localVPScenario.PortDiameter_m = val9;
               Assert.Equal(val9, localVPScenario.PortDiameter_m);
               double val10 = 87.9D;
               localVPScenario.PortDepth_m = val10;
               Assert.Equal(val10, localVPScenario.PortDepth_m);
               double val11 = 87.9D;
               localVPScenario.PortElevation_m = val11;
               Assert.Equal(val11, localVPScenario.PortElevation_m);
               double val12 = 87.9D;
               localVPScenario.VerticalAngle_deg = val12;
               Assert.Equal(val12, localVPScenario.VerticalAngle_deg);
               double val13 = 87.9D;
               localVPScenario.HorizontalAngle_deg = val13;
               Assert.Equal(val13, localVPScenario.HorizontalAngle_deg);
               int val14 = 45;
               localVPScenario.NumberOfPorts = val14;
               Assert.Equal(val14, localVPScenario.NumberOfPorts);
               double val15 = 87.9D;
               localVPScenario.PortSpacing_m = val15;
               Assert.Equal(val15, localVPScenario.PortSpacing_m);
               double val16 = 87.9D;
               localVPScenario.AcuteMixZone_m = val16;
               Assert.Equal(val16, localVPScenario.AcuteMixZone_m);
               double val17 = 87.9D;
               localVPScenario.ChronicMixZone_m = val17;
               Assert.Equal(val17, localVPScenario.ChronicMixZone_m);
               double val18 = 87.9D;
               localVPScenario.EffluentSalinity_PSU = val18;
               Assert.Equal(val18, localVPScenario.EffluentSalinity_PSU);
               double val19 = 87.9D;
               localVPScenario.EffluentTemperature_C = val19;
               Assert.Equal(val19, localVPScenario.EffluentTemperature_C);
               double val20 = 87.9D;
               localVPScenario.EffluentVelocity_m_s = val20;
               Assert.Equal(val20, localVPScenario.EffluentVelocity_m_s);
               string val21 = "Some text";
               localVPScenario.RawResults = val21;
               Assert.Equal(val21, localVPScenario.RawResults);
               DateTime val22 = new DateTime(2010, 3, 4);
               localVPScenario.LastUpdateDate_UTC = val22;
               Assert.Equal(val22, localVPScenario.LastUpdateDate_UTC);
               int val23 = 45;
               localVPScenario.LastUpdateContactTVItemID = val23;
               Assert.Equal(val23, localVPScenario.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
