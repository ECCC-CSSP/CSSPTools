/*
 * Auto generated from C:\CSSPTools\src\codegen\GenerateCSSPDBModels_TestsGenerated\bin\Debug\net5.0\GenerateCSSPDBModels_TestsGenerated.exe
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

namespace CSSPDBModels.Tests
{
    public partial class TVFileTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TVFile tVFile { get; set; }
        #endregion Properties

        #region Constructors
        public TVFileTest()
        {
            tVFile = new TVFile();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void TVFile_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "TVFileID", "DBCommand", "TVFileTVItemID", "TemplateTVType", "ReportTypeID", "Parameters", "Year", "Language", "FilePurpose", "FileType", "FileSize_kb", "FileInfo", "FileCreatedDate_UTC", "FromWater", "ClientFilePath", "ServerFileName", "ServerFilePath", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(TVFile).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(TVFile).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void TVFile_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(TVFile).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(TVFile).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void TVFile_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               tVFile.TVFileID = val1;
               Assert.Equal(val1, tVFile.TVFileID);
               DBCommandEnum val2 = (DBCommandEnum)3;
               tVFile.DBCommand = val2;
               Assert.Equal(val2, tVFile.DBCommand);
               int val3 = 45;
               tVFile.TVFileTVItemID = val3;
               Assert.Equal(val3, tVFile.TVFileTVItemID);
               TVTypeEnum val4 = (TVTypeEnum)3;
               tVFile.TemplateTVType = val4;
               Assert.Equal(val4, tVFile.TemplateTVType);
               int val5 = 45;
               tVFile.ReportTypeID = val5;
               Assert.Equal(val5, tVFile.ReportTypeID);
               string val6 = "Some text";
               tVFile.Parameters = val6;
               Assert.Equal(val6, tVFile.Parameters);
               int val7 = 45;
               tVFile.Year = val7;
               Assert.Equal(val7, tVFile.Year);
               LanguageEnum val8 = (LanguageEnum)3;
               tVFile.Language = val8;
               Assert.Equal(val8, tVFile.Language);
               FilePurposeEnum val9 = (FilePurposeEnum)3;
               tVFile.FilePurpose = val9;
               Assert.Equal(val9, tVFile.FilePurpose);
               FileTypeEnum val10 = (FileTypeEnum)3;
               tVFile.FileType = val10;
               Assert.Equal(val10, tVFile.FileType);
               int val11 = 45;
               tVFile.FileSize_kb = val11;
               Assert.Equal(val11, tVFile.FileSize_kb);
               string val12 = "Some text";
               tVFile.FileInfo = val12;
               Assert.Equal(val12, tVFile.FileInfo);
               DateTime val13 = new DateTime(2010, 3, 4);
               tVFile.FileCreatedDate_UTC = val13;
               Assert.Equal(val13, tVFile.FileCreatedDate_UTC);
               bool val14 = true;
               tVFile.FromWater = val14;
               Assert.Equal(val14, tVFile.FromWater);
               string val15 = "Some text";
               tVFile.ClientFilePath = val15;
               Assert.Equal(val15, tVFile.ClientFilePath);
               string val16 = "Some text";
               tVFile.ServerFileName = val16;
               Assert.Equal(val16, tVFile.ServerFileName);
               string val17 = "Some text";
               tVFile.ServerFilePath = val17;
               Assert.Equal(val17, tVFile.ServerFilePath);
               DateTime val18 = new DateTime(2010, 3, 4);
               tVFile.LastUpdateDate_UTC = val18;
               Assert.Equal(val18, tVFile.LastUpdateDate_UTC);
               int val19 = 45;
               tVFile.LastUpdateContactTVItemID = val19;
               Assert.Equal(val19, tVFile.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}