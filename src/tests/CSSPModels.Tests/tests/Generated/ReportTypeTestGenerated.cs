/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ModelsModelClassNameTestGenerated_cs.exe
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
    public partial class ReportTypeTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ReportType reportType { get; set; }
        #endregion Properties

        #region Constructors
        public ReportTypeTest()
        {
            reportType = new ReportType();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void ReportType_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "ReportTypeID", "TVType", "FileType", "UniqueCode", "Language", "Name", "Description", "StartOfFileName", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(ReportType).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(ReportType).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void ReportType_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(ReportType).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(ReportType).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void ReportType_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               reportType.ReportTypeID = val1;
               Assert.Equal(val1, reportType.ReportTypeID);
               TVTypeEnum val2 = (TVTypeEnum)3;
               reportType.TVType = val2;
               Assert.Equal(val2, reportType.TVType);
               FileTypeEnum val3 = (FileTypeEnum)3;
               reportType.FileType = val3;
               Assert.Equal(val3, reportType.FileType);
               string val4 = "Some text";
               reportType.UniqueCode = val4;
               Assert.Equal(val4, reportType.UniqueCode);
               LanguageEnum val5 = (LanguageEnum)3;
               reportType.Language = val5;
               Assert.Equal(val5, reportType.Language);
               string val6 = "Some text";
               reportType.Name = val6;
               Assert.Equal(val6, reportType.Name);
               string val7 = "Some text";
               reportType.Description = val7;
               Assert.Equal(val7, reportType.Description);
               string val8 = "Some text";
               reportType.StartOfFileName = val8;
               Assert.Equal(val8, reportType.StartOfFileName);
               DateTime val9 = new DateTime(2010, 3, 4);
               reportType.LastUpdateDate_UTC = val9;
               Assert.Equal(val9, reportType.LastUpdateDate_UTC);
               int val10 = 45;
               reportType.LastUpdateContactTVItemID = val10;
               Assert.Equal(val10, reportType.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
