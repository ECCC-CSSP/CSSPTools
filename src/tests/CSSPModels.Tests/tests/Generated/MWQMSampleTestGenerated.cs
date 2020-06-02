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
    public partial class MWQMSampleTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MWQMSample mWQMSample { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSampleTest()
        {
            mWQMSample = new MWQMSample();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void MWQMSample_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "MWQMSampleID", "MWQMSiteTVItemID", "MWQMRunTVItemID", "SampleDateTime_Local", "TimeText", "Depth_m", "FecCol_MPN_100ml", "Salinity_PPT", "WaterTemp_C", "PH", "SampleTypesText", "SampleType_old", "Tube_10", "Tube_1_0", "Tube_0_1", "ProcessedBy", "UseForOpenData", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MWQMSample).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(MWQMSample).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void MWQMSample_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MWQMSample).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(MWQMSample).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void MWQMSample_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               mWQMSample.MWQMSampleID = val1;
               Assert.Equal(val1, mWQMSample.MWQMSampleID);
               int val2 = 45;
               mWQMSample.MWQMSiteTVItemID = val2;
               Assert.Equal(val2, mWQMSample.MWQMSiteTVItemID);
               int val3 = 45;
               mWQMSample.MWQMRunTVItemID = val3;
               Assert.Equal(val3, mWQMSample.MWQMRunTVItemID);
               DateTime val4 = new DateTime(2010, 3, 4);
               mWQMSample.SampleDateTime_Local = val4;
               Assert.Equal(val4, mWQMSample.SampleDateTime_Local);
               string val5 = "Some text";
               mWQMSample.TimeText = val5;
               Assert.Equal(val5, mWQMSample.TimeText);
               double val6 = 87.9D;
               mWQMSample.Depth_m = val6;
               Assert.Equal(val6, mWQMSample.Depth_m);
               int val7 = 45;
               mWQMSample.FecCol_MPN_100ml = val7;
               Assert.Equal(val7, mWQMSample.FecCol_MPN_100ml);
               double val8 = 87.9D;
               mWQMSample.Salinity_PPT = val8;
               Assert.Equal(val8, mWQMSample.Salinity_PPT);
               double val9 = 87.9D;
               mWQMSample.WaterTemp_C = val9;
               Assert.Equal(val9, mWQMSample.WaterTemp_C);
               double val10 = 87.9D;
               mWQMSample.PH = val10;
               Assert.Equal(val10, mWQMSample.PH);
               string val11 = "Some text";
               mWQMSample.SampleTypesText = val11;
               Assert.Equal(val11, mWQMSample.SampleTypesText);
               SampleTypeEnum val12 = (SampleTypeEnum)3;
               mWQMSample.SampleType_old = val12;
               Assert.Equal(val12, mWQMSample.SampleType_old);
               int val13 = 45;
               mWQMSample.Tube_10 = val13;
               Assert.Equal(val13, mWQMSample.Tube_10);
               int val14 = 45;
               mWQMSample.Tube_1_0 = val14;
               Assert.Equal(val14, mWQMSample.Tube_1_0);
               int val15 = 45;
               mWQMSample.Tube_0_1 = val15;
               Assert.Equal(val15, mWQMSample.Tube_0_1);
               string val16 = "Some text";
               mWQMSample.ProcessedBy = val16;
               Assert.Equal(val16, mWQMSample.ProcessedBy);
               bool val17 = true;
               mWQMSample.UseForOpenData = val17;
               Assert.Equal(val17, mWQMSample.UseForOpenData);
               DateTime val18 = new DateTime(2010, 3, 4);
               mWQMSample.LastUpdateDate_UTC = val18;
               Assert.Equal(val18, mWQMSample.LastUpdateDate_UTC);
               int val19 = 45;
               mWQMSample.LastUpdateContactTVItemID = val19;
               Assert.Equal(val19, mWQMSample.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
