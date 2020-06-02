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
    public partial class MWQMSiteSampleFCTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MWQMSiteSampleFC mWQMSiteSampleFC { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteSampleFCTest()
        {
            mWQMSiteSampleFC = new MWQMSiteSampleFC();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void MWQMSiteSampleFC_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "SampleDate", "FC", "Sal", "Temp", "PH", "DO", "Depth", "SampCount", "MinFC", "MaxFC", "GeoMean", "Median", "P90", "PercOver43", "PercOver260",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MWQMSiteSampleFC).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void MWQMSiteSampleFC_Every_Property_Has_Get_Set_Test()
        {
               DateTime val1 = new DateTime(2010, 3, 4);
               mWQMSiteSampleFC.SampleDate = val1;
               Assert.Equal(val1, mWQMSiteSampleFC.SampleDate);
               int val2 = 45;
               mWQMSiteSampleFC.FC = val2;
               Assert.Equal(val2, mWQMSiteSampleFC.FC);
               double val3 = 87.9D;
               mWQMSiteSampleFC.Sal = val3;
               Assert.Equal(val3, mWQMSiteSampleFC.Sal);
               double val4 = 87.9D;
               mWQMSiteSampleFC.Temp = val4;
               Assert.Equal(val4, mWQMSiteSampleFC.Temp);
               double val5 = 87.9D;
               mWQMSiteSampleFC.PH = val5;
               Assert.Equal(val5, mWQMSiteSampleFC.PH);
               double val6 = 87.9D;
               mWQMSiteSampleFC.DO = val6;
               Assert.Equal(val6, mWQMSiteSampleFC.DO);
               double val7 = 87.9D;
               mWQMSiteSampleFC.Depth = val7;
               Assert.Equal(val7, mWQMSiteSampleFC.Depth);
               int val8 = 45;
               mWQMSiteSampleFC.SampCount = val8;
               Assert.Equal(val8, mWQMSiteSampleFC.SampCount);
               int val9 = 45;
               mWQMSiteSampleFC.MinFC = val9;
               Assert.Equal(val9, mWQMSiteSampleFC.MinFC);
               int val10 = 45;
               mWQMSiteSampleFC.MaxFC = val10;
               Assert.Equal(val10, mWQMSiteSampleFC.MaxFC);
               double val11 = 87.9D;
               mWQMSiteSampleFC.GeoMean = val11;
               Assert.Equal(val11, mWQMSiteSampleFC.GeoMean);
               double val12 = 87.9D;
               mWQMSiteSampleFC.Median = val12;
               Assert.Equal(val12, mWQMSiteSampleFC.Median);
               double val13 = 87.9D;
               mWQMSiteSampleFC.P90 = val13;
               Assert.Equal(val13, mWQMSiteSampleFC.P90);
               double val14 = 87.9D;
               mWQMSiteSampleFC.PercOver43 = val14;
               Assert.Equal(val14, mWQMSiteSampleFC.PercOver43);
               double val15 = 87.9D;
               mWQMSiteSampleFC.PercOver260 = val15;
               Assert.Equal(val15, mWQMSiteSampleFC.PercOver260);
        }
        #endregion Tests Functions public
    }
}
