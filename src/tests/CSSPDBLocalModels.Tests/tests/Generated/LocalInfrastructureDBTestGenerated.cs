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
    public partial class LocalInfrastructureTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LocalInfrastructure localInfrastructure { get; set; }
        #endregion Properties

        #region Constructors
        public LocalInfrastructureTest()
        {
            localInfrastructure = new LocalInfrastructure();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LocalInfrastructure_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LocalDBCommand", "InfrastructureID", "InfrastructureTVItemID", "PrismID", "TPID", "LSID", "SiteID", "Site", "InfrastructureCategory", "InfrastructureType", "FacilityType", "HasBackupPower", "IsMechanicallyAerated", "NumberOfCells", "NumberOfAeratedCells", "AerationType", "PreliminaryTreatmentType", "PrimaryTreatmentType", "SecondaryTreatmentType", "TertiaryTreatmentType", "TreatmentType", "DisinfectionType", "CollectionSystemType", "AlarmSystemType", "DesignFlow_m3_day", "AverageFlow_m3_day", "PeakFlow_m3_day", "PopServed", "CanOverflow", "ValveType", "PercFlowOfTotal", "TimeOffset_hour", "TempCatchAllRemoveLater", "AverageDepth_m", "NumberOfPorts", "PortDiameter_m", "PortSpacing_m", "PortElevation_m", "VerticalAngle_deg", "HorizontalAngle_deg", "DecayRate_per_day", "NearFieldVelocity_m_s", "FarFieldVelocity_m_s", "ReceivingWaterSalinity_PSU", "ReceivingWaterTemperature_C", "ReceivingWater_MPN_per_100ml", "DistanceFromShore_m", "SeeOtherMunicipalityTVItemID", "CivicAddressTVItemID", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalInfrastructure).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(LocalInfrastructure).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalInfrastructure_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalInfrastructure).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(LocalInfrastructure).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalInfrastructure_Every_Property_Has_Get_Set_Test()
        {
               LocalDBCommandEnum val1 = (LocalDBCommandEnum)3;
               localInfrastructure.LocalDBCommand = val1;
               Assert.Equal(val1, localInfrastructure.LocalDBCommand);
               int val2 = 45;
               localInfrastructure.InfrastructureID = val2;
               Assert.Equal(val2, localInfrastructure.InfrastructureID);
               int val3 = 45;
               localInfrastructure.InfrastructureTVItemID = val3;
               Assert.Equal(val3, localInfrastructure.InfrastructureTVItemID);
               int val4 = 45;
               localInfrastructure.PrismID = val4;
               Assert.Equal(val4, localInfrastructure.PrismID);
               int val5 = 45;
               localInfrastructure.TPID = val5;
               Assert.Equal(val5, localInfrastructure.TPID);
               int val6 = 45;
               localInfrastructure.LSID = val6;
               Assert.Equal(val6, localInfrastructure.LSID);
               int val7 = 45;
               localInfrastructure.SiteID = val7;
               Assert.Equal(val7, localInfrastructure.SiteID);
               int val8 = 45;
               localInfrastructure.Site = val8;
               Assert.Equal(val8, localInfrastructure.Site);
               string val9 = "Some text";
               localInfrastructure.InfrastructureCategory = val9;
               Assert.Equal(val9, localInfrastructure.InfrastructureCategory);
               InfrastructureTypeEnum val10 = (InfrastructureTypeEnum)3;
               localInfrastructure.InfrastructureType = val10;
               Assert.Equal(val10, localInfrastructure.InfrastructureType);
               FacilityTypeEnum val11 = (FacilityTypeEnum)3;
               localInfrastructure.FacilityType = val11;
               Assert.Equal(val11, localInfrastructure.FacilityType);
               bool val12 = true;
               localInfrastructure.HasBackupPower = val12;
               Assert.Equal(val12, localInfrastructure.HasBackupPower);
               bool val13 = true;
               localInfrastructure.IsMechanicallyAerated = val13;
               Assert.Equal(val13, localInfrastructure.IsMechanicallyAerated);
               int val14 = 45;
               localInfrastructure.NumberOfCells = val14;
               Assert.Equal(val14, localInfrastructure.NumberOfCells);
               int val15 = 45;
               localInfrastructure.NumberOfAeratedCells = val15;
               Assert.Equal(val15, localInfrastructure.NumberOfAeratedCells);
               AerationTypeEnum val16 = (AerationTypeEnum)3;
               localInfrastructure.AerationType = val16;
               Assert.Equal(val16, localInfrastructure.AerationType);
               PreliminaryTreatmentTypeEnum val17 = (PreliminaryTreatmentTypeEnum)3;
               localInfrastructure.PreliminaryTreatmentType = val17;
               Assert.Equal(val17, localInfrastructure.PreliminaryTreatmentType);
               PrimaryTreatmentTypeEnum val18 = (PrimaryTreatmentTypeEnum)3;
               localInfrastructure.PrimaryTreatmentType = val18;
               Assert.Equal(val18, localInfrastructure.PrimaryTreatmentType);
               SecondaryTreatmentTypeEnum val19 = (SecondaryTreatmentTypeEnum)3;
               localInfrastructure.SecondaryTreatmentType = val19;
               Assert.Equal(val19, localInfrastructure.SecondaryTreatmentType);
               TertiaryTreatmentTypeEnum val20 = (TertiaryTreatmentTypeEnum)3;
               localInfrastructure.TertiaryTreatmentType = val20;
               Assert.Equal(val20, localInfrastructure.TertiaryTreatmentType);
               TreatmentTypeEnum val21 = (TreatmentTypeEnum)3;
               localInfrastructure.TreatmentType = val21;
               Assert.Equal(val21, localInfrastructure.TreatmentType);
               DisinfectionTypeEnum val22 = (DisinfectionTypeEnum)3;
               localInfrastructure.DisinfectionType = val22;
               Assert.Equal(val22, localInfrastructure.DisinfectionType);
               CollectionSystemTypeEnum val23 = (CollectionSystemTypeEnum)3;
               localInfrastructure.CollectionSystemType = val23;
               Assert.Equal(val23, localInfrastructure.CollectionSystemType);
               AlarmSystemTypeEnum val24 = (AlarmSystemTypeEnum)3;
               localInfrastructure.AlarmSystemType = val24;
               Assert.Equal(val24, localInfrastructure.AlarmSystemType);
               double val25 = 87.9D;
               localInfrastructure.DesignFlow_m3_day = val25;
               Assert.Equal(val25, localInfrastructure.DesignFlow_m3_day);
               double val26 = 87.9D;
               localInfrastructure.AverageFlow_m3_day = val26;
               Assert.Equal(val26, localInfrastructure.AverageFlow_m3_day);
               double val27 = 87.9D;
               localInfrastructure.PeakFlow_m3_day = val27;
               Assert.Equal(val27, localInfrastructure.PeakFlow_m3_day);
               int val28 = 45;
               localInfrastructure.PopServed = val28;
               Assert.Equal(val28, localInfrastructure.PopServed);
               bool val29 = true;
               localInfrastructure.CanOverflow = val29;
               Assert.Equal(val29, localInfrastructure.CanOverflow);
               ValveTypeEnum val30 = (ValveTypeEnum)3;
               localInfrastructure.ValveType = val30;
               Assert.Equal(val30, localInfrastructure.ValveType);
               double val31 = 87.9D;
               localInfrastructure.PercFlowOfTotal = val31;
               Assert.Equal(val31, localInfrastructure.PercFlowOfTotal);
               double val32 = 87.9D;
               localInfrastructure.TimeOffset_hour = val32;
               Assert.Equal(val32, localInfrastructure.TimeOffset_hour);
               string val33 = "Some text";
               localInfrastructure.TempCatchAllRemoveLater = val33;
               Assert.Equal(val33, localInfrastructure.TempCatchAllRemoveLater);
               double val34 = 87.9D;
               localInfrastructure.AverageDepth_m = val34;
               Assert.Equal(val34, localInfrastructure.AverageDepth_m);
               int val35 = 45;
               localInfrastructure.NumberOfPorts = val35;
               Assert.Equal(val35, localInfrastructure.NumberOfPorts);
               double val36 = 87.9D;
               localInfrastructure.PortDiameter_m = val36;
               Assert.Equal(val36, localInfrastructure.PortDiameter_m);
               double val37 = 87.9D;
               localInfrastructure.PortSpacing_m = val37;
               Assert.Equal(val37, localInfrastructure.PortSpacing_m);
               double val38 = 87.9D;
               localInfrastructure.PortElevation_m = val38;
               Assert.Equal(val38, localInfrastructure.PortElevation_m);
               double val39 = 87.9D;
               localInfrastructure.VerticalAngle_deg = val39;
               Assert.Equal(val39, localInfrastructure.VerticalAngle_deg);
               double val40 = 87.9D;
               localInfrastructure.HorizontalAngle_deg = val40;
               Assert.Equal(val40, localInfrastructure.HorizontalAngle_deg);
               double val41 = 87.9D;
               localInfrastructure.DecayRate_per_day = val41;
               Assert.Equal(val41, localInfrastructure.DecayRate_per_day);
               double val42 = 87.9D;
               localInfrastructure.NearFieldVelocity_m_s = val42;
               Assert.Equal(val42, localInfrastructure.NearFieldVelocity_m_s);
               double val43 = 87.9D;
               localInfrastructure.FarFieldVelocity_m_s = val43;
               Assert.Equal(val43, localInfrastructure.FarFieldVelocity_m_s);
               double val44 = 87.9D;
               localInfrastructure.ReceivingWaterSalinity_PSU = val44;
               Assert.Equal(val44, localInfrastructure.ReceivingWaterSalinity_PSU);
               double val45 = 87.9D;
               localInfrastructure.ReceivingWaterTemperature_C = val45;
               Assert.Equal(val45, localInfrastructure.ReceivingWaterTemperature_C);
               int val46 = 45;
               localInfrastructure.ReceivingWater_MPN_per_100ml = val46;
               Assert.Equal(val46, localInfrastructure.ReceivingWater_MPN_per_100ml);
               double val47 = 87.9D;
               localInfrastructure.DistanceFromShore_m = val47;
               Assert.Equal(val47, localInfrastructure.DistanceFromShore_m);
               int val48 = 45;
               localInfrastructure.SeeOtherMunicipalityTVItemID = val48;
               Assert.Equal(val48, localInfrastructure.SeeOtherMunicipalityTVItemID);
               int val49 = 45;
               localInfrastructure.CivicAddressTVItemID = val49;
               Assert.Equal(val49, localInfrastructure.CivicAddressTVItemID);
               DateTime val50 = new DateTime(2010, 3, 4);
               localInfrastructure.LastUpdateDate_UTC = val50;
               Assert.Equal(val50, localInfrastructure.LastUpdateDate_UTC);
               int val51 = 45;
               localInfrastructure.LastUpdateContactTVItemID = val51;
               Assert.Equal(val51, localInfrastructure.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}