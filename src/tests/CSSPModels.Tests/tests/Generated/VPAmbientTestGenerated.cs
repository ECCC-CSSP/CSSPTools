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
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.ComponentModel.DataAnnotations;

namespace CSSPModels.Tests
{
    public partial class VPAmbientTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private VPAmbient vPAmbient { get; set; }
        #endregion Properties

        #region Constructors
        public VPAmbientTest()
        {
            vPAmbient = new VPAmbient();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void VPAmbient_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "VPAmbientID", "VPScenarioID", "Row", "MeasurementDepth_m", "CurrentSpeed_m_s", "CurrentDirection_deg", "AmbientSalinity_PSU", "AmbientTemperature_C", "BackgroundConcentration_MPN_100ml", "PollutantDecayRate_per_day", "FarFieldCurrentSpeed_m_s", "FarFieldCurrentDirection_deg", "FarFieldDiffusionCoefficient", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(VPAmbient).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(VPAmbient).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void VPAmbient_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(VPAmbient).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(VPAmbient).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void VPAmbient_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               vPAmbient.VPAmbientID = val1;
               Assert.Equal(val1, vPAmbient.VPAmbientID);
               int val2 = 45;
               vPAmbient.VPScenarioID = val2;
               Assert.Equal(val2, vPAmbient.VPScenarioID);
               int val3 = 45;
               vPAmbient.Row = val3;
               Assert.Equal(val3, vPAmbient.Row);
               double val4 = 87.9D;
               vPAmbient.MeasurementDepth_m = val4;
               Assert.Equal(val4, vPAmbient.MeasurementDepth_m);
               double val5 = 87.9D;
               vPAmbient.CurrentSpeed_m_s = val5;
               Assert.Equal(val5, vPAmbient.CurrentSpeed_m_s);
               double val6 = 87.9D;
               vPAmbient.CurrentDirection_deg = val6;
               Assert.Equal(val6, vPAmbient.CurrentDirection_deg);
               double val7 = 87.9D;
               vPAmbient.AmbientSalinity_PSU = val7;
               Assert.Equal(val7, vPAmbient.AmbientSalinity_PSU);
               double val8 = 87.9D;
               vPAmbient.AmbientTemperature_C = val8;
               Assert.Equal(val8, vPAmbient.AmbientTemperature_C);
               int val9 = 45;
               vPAmbient.BackgroundConcentration_MPN_100ml = val9;
               Assert.Equal(val9, vPAmbient.BackgroundConcentration_MPN_100ml);
               double val10 = 87.9D;
               vPAmbient.PollutantDecayRate_per_day = val10;
               Assert.Equal(val10, vPAmbient.PollutantDecayRate_per_day);
               double val11 = 87.9D;
               vPAmbient.FarFieldCurrentSpeed_m_s = val11;
               Assert.Equal(val11, vPAmbient.FarFieldCurrentSpeed_m_s);
               double val12 = 87.9D;
               vPAmbient.FarFieldCurrentDirection_deg = val12;
               Assert.Equal(val12, vPAmbient.FarFieldCurrentDirection_deg);
               double val13 = 87.9D;
               vPAmbient.FarFieldDiffusionCoefficient = val13;
               Assert.Equal(val13, vPAmbient.FarFieldDiffusionCoefficient);
               DateTime val14 = new DateTime(2010, 3, 4);
               vPAmbient.LastUpdateDate_UTC = val14;
               Assert.Equal(val14, vPAmbient.LastUpdateDate_UTC);
               int val15 = 45;
               vPAmbient.LastUpdateContactTVItemID = val15;
               Assert.Equal(val15, vPAmbient.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
