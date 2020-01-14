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

    public partial class AppErrLogTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private AppErrLog appErrLog { get; set; }
        #endregion Properties

        #region Constructors
        public AppErrLogTest()
        {
            appErrLog = new AppErrLog();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void AppErrLog_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "AppErrLogID", "Tag", "LineNumber", "Source", "Message", "DateTime_UTC", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() { "HasErrors",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(AppErrLog).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(AppErrLog).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void AppErrLog_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(AppErrLog).GetProperties())
            {
                if (propertyInfo.GetGetMethod().IsVirtual && !propertyInfo.GetGetMethod().ReturnType.Name.StartsWith("ICollection"))
                {
                    Assert.True(foreignNameList.Contains(propertyInfo.Name));
                    index += 1;
                }
            }

            Assert.Equal(foreignNameList.Count, index);

            index = 0;
            foreach (PropertyInfo propertyInfo in typeof(AppErrLog).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                if (propertyInfo.GetGetMethod().ReturnType.Name.StartsWith("ICollection"))
                {
                    Assert.True(foreignNameCollectionList.Contains(propertyInfo.Name));
                    index += 1;
                }
            }

            Assert.Equal(foreignNameCollectionList.Count, index);

        }
        [Fact]
        public void AppErrLog_Has_ValidationResults_Test()
        {
             Assert.True(typeof(AppErrLog).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void AppErrLog_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               appErrLog.AppErrLogID = val1;
               Assert.Equal(val1, appErrLog.AppErrLogID);
               string val2 = "Some text";
               appErrLog.Tag = val2;
               Assert.Equal(val2, appErrLog.Tag);
               int val3 = 45;
               appErrLog.LineNumber = val3;
               Assert.Equal(val3, appErrLog.LineNumber);
               string val4 = "Some text";
               appErrLog.Source = val4;
               Assert.Equal(val4, appErrLog.Source);
               string val5 = "Some text";
               appErrLog.Message = val5;
               Assert.Equal(val5, appErrLog.Message);
               DateTime val6 = new DateTime(2010, 3, 4);
               appErrLog.DateTime_UTC = val6;
               Assert.Equal(val6, appErrLog.DateTime_UTC);
               DateTime val7 = new DateTime(2010, 3, 4);
               appErrLog.LastUpdateDate_UTC = val7;
               Assert.Equal(val7, appErrLog.LastUpdateDate_UTC);
               int val8 = 45;
               appErrLog.LastUpdateContactTVItemID = val8;
               Assert.Equal(val8, appErrLog.LastUpdateContactTVItemID);
               bool val9 = true;
               appErrLog.HasErrors = val9;
               Assert.Equal(val9, appErrLog.HasErrors);
               IEnumerable<ValidationResult> val30 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               appErrLog.ValidationResults = val30;
               Assert.Equal(val30, appErrLog.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
