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
    public partial class LogTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private Log log { get; set; }
        #endregion Properties

        #region Constructors
        public LogTest()
        {
            log = new Log();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void Log_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LogID", "TableName", "ID", "LogCommand", "Information", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(Log).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(Log).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void Log_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(Log).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(Log).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void Log_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               log.LogID = val1;
               Assert.Equal(val1, log.LogID);
               string val2 = "Some text";
               log.TableName = val2;
               Assert.Equal(val2, log.TableName);
               int val3 = 45;
               log.ID = val3;
               Assert.Equal(val3, log.ID);
               LogCommandEnum val4 = (LogCommandEnum)3;
               log.LogCommand = val4;
               Assert.Equal(val4, log.LogCommand);
               string val5 = "Some text";
               log.Information = val5;
               Assert.Equal(val5, log.Information);
               DateTime val6 = new DateTime(2010, 3, 4);
               log.LastUpdateDate_UTC = val6;
               Assert.Equal(val6, log.LastUpdateDate_UTC);
               int val7 = 45;
               log.LastUpdateContactTVItemID = val7;
               Assert.Equal(val7, log.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
