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
    public partial class InfrastructureTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private Infrastructure infrastructure { get; set; }
        #endregion Properties

        #region Constructors
        public InfrastructureTest()
        {
            infrastructure = new Infrastructure();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void Infrastructure_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "InfrastructureID", "InfrastructureTVItemID", "PrismID", "TPID", "LSID", "SiteID", "Site", "InfrastructureCategory", "InfrastructureType", "FacilityType", "HasBackupPower", "IsMechanicallyAerated", "NumberOfCells", "NumberOfAeratedCells", "AerationType", "PreliminaryTreatmentType", "PrimaryTreatmentType", "SecondaryTreatmentType", "TertiaryTreatmentType", "TreatmentType", "DisinfectionType", "CollectionSystemType", "AlarmSystemType", "DesignFlow_m3_day", "AverageFlow_m3_day", "PeakFlow_m3_day", "PopServed", "CanOverflow", "ValveType", "PercFlowOfTotal", "TimeOffset_hour", "TempCatchAllRemoveLater", "AverageDepth_m", "NumberOfPorts", "PortDiameter_m", "PortSpacing_m", "PortElevation_m", "VerticalAngle_deg", "HorizontalAngle_deg", "DecayRate_per_day", "NearFieldVelocity_m_s", "FarFieldVelocity_m_s", "ReceivingWaterSalinity_PSU", "ReceivingWaterTemperature_C", "ReceivingWater_MPN_per_100ml", "DistanceFromShore_m", "SeeOtherMunicipalityTVItemID", "CivicAddressTVItemID", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(Infrastructure).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(Infrastructure).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void Infrastructure_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(Infrastructure).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(Infrastructure).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void Infrastructure_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               infrastructure.InfrastructureID = val1;
               Assert.Equal(val1, infrastructure.InfrastructureID);
               int val2 = 45;
               infrastructure.InfrastructureTVItemID = val2;
               Assert.Equal(val2, infrastructure.InfrastructureTVItemID);
               int val3 = 45;
               infrastructure.PrismID = val3;
               Assert.Equal(val3, infrastructure.PrismID);
               int val4 = 45;
               infrastructure.TPID = val4;
               Assert.Equal(val4, infrastructure.TPID);
               int val5 = 45;
               infrastructure.LSID = val5;
               Assert.Equal(val5, infrastructure.LSID);
               int val6 = 45;
               infrastructure.SiteID = val6;
               Assert.Equal(val6, infrastructure.SiteID);
               int val7 = 45;
               infrastructure.Site = val7;
               Assert.Equal(val7, infrastructure.Site);
               string val8 = "Some text";
               infrastructure.InfrastructureCategory = val8;
               Assert.Equal(val8, infrastructure.InfrastructureCategory);
               InfrastructureTypeEnum val9 = (InfrastructureTypeEnum)3;
               infrastructure.InfrastructureType = val9;
               Assert.Equal(val9, infrastructure.InfrastructureType);
               FacilityTypeEnum val10 = (FacilityTypeEnum)3;
               infrastructure.FacilityType = val10;
               Assert.Equal(val10, infrastructure.FacilityType);
               bool val11 = true;
               infrastructure.HasBackupPower = val11;
               Assert.Equal(val11, infrastructure.HasBackupPower);
               bool val12 = true;
               infrastructure.IsMechanicallyAerated = val12;
               Assert.Equal(val12, infrastructure.IsMechanicallyAerated);
               int val13 = 45;
               infrastructure.NumberOfCells = val13;
               Assert.Equal(val13, infrastructure.NumberOfCells);
               int val14 = 45;
               infrastructure.NumberOfAeratedCells = val14;
               Assert.Equal(val14, infrastructure.NumberOfAeratedCells);
               AerationTypeEnum val15 = (AerationTypeEnum)3;
               infrastructure.AerationType = val15;
               Assert.Equal(val15, infrastructure.AerationType);
               PreliminaryTreatmentTypeEnum val16 = (PreliminaryTreatmentTypeEnum)3;
               infrastructure.PreliminaryTreatmentType = val16;
               Assert.Equal(val16, infrastructure.PreliminaryTreatmentType);
               PrimaryTreatmentTypeEnum val17 = (PrimaryTreatmentTypeEnum)3;
               infrastructure.PrimaryTreatmentType = val17;
               Assert.Equal(val17, infrastructure.PrimaryTreatmentType);
               SecondaryTreatmentTypeEnum val18 = (SecondaryTreatmentTypeEnum)3;
               infrastructure.SecondaryTreatmentType = val18;
               Assert.Equal(val18, infrastructure.SecondaryTreatmentType);
               TertiaryTreatmentTypeEnum val19 = (TertiaryTreatmentTypeEnum)3;
               infrastructure.TertiaryTreatmentType = val19;
               Assert.Equal(val19, infrastructure.TertiaryTreatmentType);
               TreatmentTypeEnum val20 = (TreatmentTypeEnum)3;
               infrastructure.TreatmentType = val20;
               Assert.Equal(val20, infrastructure.TreatmentType);
               DisinfectionTypeEnum val21 = (DisinfectionTypeEnum)3;
               infrastructure.DisinfectionType = val21;
               Assert.Equal(val21, infrastructure.DisinfectionType);
               CollectionSystemTypeEnum val22 = (CollectionSystemTypeEnum)3;
               infrastructure.CollectionSystemType = val22;
               Assert.Equal(val22, infrastructure.CollectionSystemType);
               AlarmSystemTypeEnum val23 = (AlarmSystemTypeEnum)3;
               infrastructure.AlarmSystemType = val23;
               Assert.Equal(val23, infrastructure.AlarmSystemType);
               double val24 = 87.9D;
               infrastructure.DesignFlow_m3_day = val24;
               Assert.Equal(val24, infrastructure.DesignFlow_m3_day);
               double val25 = 87.9D;
               infrastructure.AverageFlow_m3_day = val25;
               Assert.Equal(val25, infrastructure.AverageFlow_m3_day);
               double val26 = 87.9D;
               infrastructure.PeakFlow_m3_day = val26;
               Assert.Equal(val26, infrastructure.PeakFlow_m3_day);
               int val27 = 45;
               infrastructure.PopServed = val27;
               Assert.Equal(val27, infrastructure.PopServed);
               bool val28 = true;
               infrastructure.CanOverflow = val28;
               Assert.Equal(val28, infrastructure.CanOverflow);
               ValveTypeEnum val29 = (ValveTypeEnum)3;
               infrastructure.ValveType = val29;
               Assert.Equal(val29, infrastructure.ValveType);
               double val30 = 87.9D;
               infrastructure.PercFlowOfTotal = val30;
               Assert.Equal(val30, infrastructure.PercFlowOfTotal);
               double val31 = 87.9D;
               infrastructure.TimeOffset_hour = val31;
               Assert.Equal(val31, infrastructure.TimeOffset_hour);
               string val32 = "Some text";
               infrastructure.TempCatchAllRemoveLater = val32;
               Assert.Equal(val32, infrastructure.TempCatchAllRemoveLater);
               double val33 = 87.9D;
               infrastructure.AverageDepth_m = val33;
               Assert.Equal(val33, infrastructure.AverageDepth_m);
               int val34 = 45;
               infrastructure.NumberOfPorts = val34;
               Assert.Equal(val34, infrastructure.NumberOfPorts);
               double val35 = 87.9D;
               infrastructure.PortDiameter_m = val35;
               Assert.Equal(val35, infrastructure.PortDiameter_m);
               double val36 = 87.9D;
               infrastructure.PortSpacing_m = val36;
               Assert.Equal(val36, infrastructure.PortSpacing_m);
               double val37 = 87.9D;
               infrastructure.PortElevation_m = val37;
               Assert.Equal(val37, infrastructure.PortElevation_m);
               double val38 = 87.9D;
               infrastructure.VerticalAngle_deg = val38;
               Assert.Equal(val38, infrastructure.VerticalAngle_deg);
               double val39 = 87.9D;
               infrastructure.HorizontalAngle_deg = val39;
               Assert.Equal(val39, infrastructure.HorizontalAngle_deg);
               double val40 = 87.9D;
               infrastructure.DecayRate_per_day = val40;
               Assert.Equal(val40, infrastructure.DecayRate_per_day);
               double val41 = 87.9D;
               infrastructure.NearFieldVelocity_m_s = val41;
               Assert.Equal(val41, infrastructure.NearFieldVelocity_m_s);
               double val42 = 87.9D;
               infrastructure.FarFieldVelocity_m_s = val42;
               Assert.Equal(val42, infrastructure.FarFieldVelocity_m_s);
               double val43 = 87.9D;
               infrastructure.ReceivingWaterSalinity_PSU = val43;
               Assert.Equal(val43, infrastructure.ReceivingWaterSalinity_PSU);
               double val44 = 87.9D;
               infrastructure.ReceivingWaterTemperature_C = val44;
               Assert.Equal(val44, infrastructure.ReceivingWaterTemperature_C);
               int val45 = 45;
               infrastructure.ReceivingWater_MPN_per_100ml = val45;
               Assert.Equal(val45, infrastructure.ReceivingWater_MPN_per_100ml);
               double val46 = 87.9D;
               infrastructure.DistanceFromShore_m = val46;
               Assert.Equal(val46, infrastructure.DistanceFromShore_m);
               int val47 = 45;
               infrastructure.SeeOtherMunicipalityTVItemID = val47;
               Assert.Equal(val47, infrastructure.SeeOtherMunicipalityTVItemID);
               int val48 = 45;
               infrastructure.CivicAddressTVItemID = val48;
               Assert.Equal(val48, infrastructure.CivicAddressTVItemID);
               DateTime val49 = new DateTime(2010, 3, 4);
               infrastructure.LastUpdateDate_UTC = val49;
               Assert.Equal(val49, infrastructure.LastUpdateDate_UTC);
               int val50 = 45;
               infrastructure.LastUpdateContactTVItemID = val50;
               Assert.Equal(val50, infrastructure.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
