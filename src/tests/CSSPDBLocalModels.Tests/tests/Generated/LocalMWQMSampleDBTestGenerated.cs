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
    public partial class LocalMWQMSampleTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LocalMWQMSample localMWQMSample { get; set; }
        #endregion Properties

        #region Constructors
        public LocalMWQMSampleTest()
        {
            localMWQMSample = new LocalMWQMSample();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LocalMWQMSample_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LocalDBCommand", "MWQMSampleID", "MWQMSiteTVItemID", "MWQMRunTVItemID", "SampleDateTime_Local", "TimeText", "Depth_m", "FecCol_MPN_100ml", "Salinity_PPT", "WaterTemp_C", "PH", "SampleTypesText", "SampleType_old", "Tube_10", "Tube_1_0", "Tube_0_1", "ProcessedBy", "UseForOpenData", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalMWQMSample).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(LocalMWQMSample).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalMWQMSample_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalMWQMSample).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(LocalMWQMSample).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalMWQMSample_Every_Property_Has_Get_Set_Test()
        {
               LocalDBCommandEnum val1 = (LocalDBCommandEnum)3;
               localMWQMSample.LocalDBCommand = val1;
               Assert.Equal(val1, localMWQMSample.LocalDBCommand);
               int val2 = 45;
               localMWQMSample.MWQMSampleID = val2;
               Assert.Equal(val2, localMWQMSample.MWQMSampleID);
               int val3 = 45;
               localMWQMSample.MWQMSiteTVItemID = val3;
               Assert.Equal(val3, localMWQMSample.MWQMSiteTVItemID);
               int val4 = 45;
               localMWQMSample.MWQMRunTVItemID = val4;
               Assert.Equal(val4, localMWQMSample.MWQMRunTVItemID);
               DateTime val5 = new DateTime(2010, 3, 4);
               localMWQMSample.SampleDateTime_Local = val5;
               Assert.Equal(val5, localMWQMSample.SampleDateTime_Local);
               string val6 = "Some text";
               localMWQMSample.TimeText = val6;
               Assert.Equal(val6, localMWQMSample.TimeText);
               double val7 = 87.9D;
               localMWQMSample.Depth_m = val7;
               Assert.Equal(val7, localMWQMSample.Depth_m);
               int val8 = 45;
               localMWQMSample.FecCol_MPN_100ml = val8;
               Assert.Equal(val8, localMWQMSample.FecCol_MPN_100ml);
               double val9 = 87.9D;
               localMWQMSample.Salinity_PPT = val9;
               Assert.Equal(val9, localMWQMSample.Salinity_PPT);
               double val10 = 87.9D;
               localMWQMSample.WaterTemp_C = val10;
               Assert.Equal(val10, localMWQMSample.WaterTemp_C);
               double val11 = 87.9D;
               localMWQMSample.PH = val11;
               Assert.Equal(val11, localMWQMSample.PH);
               string val12 = "Some text";
               localMWQMSample.SampleTypesText = val12;
               Assert.Equal(val12, localMWQMSample.SampleTypesText);
               SampleTypeEnum val13 = (SampleTypeEnum)3;
               localMWQMSample.SampleType_old = val13;
               Assert.Equal(val13, localMWQMSample.SampleType_old);
               int val14 = 45;
               localMWQMSample.Tube_10 = val14;
               Assert.Equal(val14, localMWQMSample.Tube_10);
               int val15 = 45;
               localMWQMSample.Tube_1_0 = val15;
               Assert.Equal(val15, localMWQMSample.Tube_1_0);
               int val16 = 45;
               localMWQMSample.Tube_0_1 = val16;
               Assert.Equal(val16, localMWQMSample.Tube_0_1);
               string val17 = "Some text";
               localMWQMSample.ProcessedBy = val17;
               Assert.Equal(val17, localMWQMSample.ProcessedBy);
               bool val18 = true;
               localMWQMSample.UseForOpenData = val18;
               Assert.Equal(val18, localMWQMSample.UseForOpenData);
               DateTime val19 = new DateTime(2010, 3, 4);
               localMWQMSample.LastUpdateDate_UTC = val19;
               Assert.Equal(val19, localMWQMSample.LastUpdateDate_UTC);
               int val20 = 45;
               localMWQMSample.LastUpdateContactTVItemID = val20;
               Assert.Equal(val20, localMWQMSample.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}