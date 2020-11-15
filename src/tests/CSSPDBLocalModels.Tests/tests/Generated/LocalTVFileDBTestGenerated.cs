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
    public partial class LocalTVFileTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LocalTVFile localTVFile { get; set; }
        #endregion Properties

        #region Constructors
        public LocalTVFileTest()
        {
            localTVFile = new LocalTVFile();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LocalTVFile_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LocalDBCommand", "TVFileID", "TVFileTVItemID", "TemplateTVType", "ReportTypeID", "Parameters", "Year", "Language", "FilePurpose", "FileType", "FileSize_kb", "FileInfo", "FileCreatedDate_UTC", "FromWater", "ClientFilePath", "ServerFileName", "ServerFilePath", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalTVFile).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(LocalTVFile).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalTVFile_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalTVFile).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(LocalTVFile).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalTVFile_Every_Property_Has_Get_Set_Test()
        {
               LocalDBCommandEnum val1 = (LocalDBCommandEnum)3;
               localTVFile.LocalDBCommand = val1;
               Assert.Equal(val1, localTVFile.LocalDBCommand);
               int val2 = 45;
               localTVFile.TVFileID = val2;
               Assert.Equal(val2, localTVFile.TVFileID);
               int val3 = 45;
               localTVFile.TVFileTVItemID = val3;
               Assert.Equal(val3, localTVFile.TVFileTVItemID);
               TVTypeEnum val4 = (TVTypeEnum)3;
               localTVFile.TemplateTVType = val4;
               Assert.Equal(val4, localTVFile.TemplateTVType);
               int val5 = 45;
               localTVFile.ReportTypeID = val5;
               Assert.Equal(val5, localTVFile.ReportTypeID);
               string val6 = "Some text";
               localTVFile.Parameters = val6;
               Assert.Equal(val6, localTVFile.Parameters);
               int val7 = 45;
               localTVFile.Year = val7;
               Assert.Equal(val7, localTVFile.Year);
               LanguageEnum val8 = (LanguageEnum)3;
               localTVFile.Language = val8;
               Assert.Equal(val8, localTVFile.Language);
               FilePurposeEnum val9 = (FilePurposeEnum)3;
               localTVFile.FilePurpose = val9;
               Assert.Equal(val9, localTVFile.FilePurpose);
               FileTypeEnum val10 = (FileTypeEnum)3;
               localTVFile.FileType = val10;
               Assert.Equal(val10, localTVFile.FileType);
               int val11 = 45;
               localTVFile.FileSize_kb = val11;
               Assert.Equal(val11, localTVFile.FileSize_kb);
               string val12 = "Some text";
               localTVFile.FileInfo = val12;
               Assert.Equal(val12, localTVFile.FileInfo);
               DateTime val13 = new DateTime(2010, 3, 4);
               localTVFile.FileCreatedDate_UTC = val13;
               Assert.Equal(val13, localTVFile.FileCreatedDate_UTC);
               bool val14 = true;
               localTVFile.FromWater = val14;
               Assert.Equal(val14, localTVFile.FromWater);
               string val15 = "Some text";
               localTVFile.ClientFilePath = val15;
               Assert.Equal(val15, localTVFile.ClientFilePath);
               string val16 = "Some text";
               localTVFile.ServerFileName = val16;
               Assert.Equal(val16, localTVFile.ServerFileName);
               string val17 = "Some text";
               localTVFile.ServerFilePath = val17;
               Assert.Equal(val17, localTVFile.ServerFilePath);
               DateTime val18 = new DateTime(2010, 3, 4);
               localTVFile.LastUpdateDate_UTC = val18;
               Assert.Equal(val18, localTVFile.LastUpdateDate_UTC);
               int val19 = 45;
               localTVFile.LastUpdateContactTVItemID = val19;
               Assert.Equal(val19, localTVFile.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}