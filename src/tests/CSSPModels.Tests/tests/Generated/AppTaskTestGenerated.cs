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
    public partial class AppTaskTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private AppTask appTask { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskTest()
        {
            appTask = new AppTask();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void AppTask_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "AppTaskID", "TVItemID", "TVItemID2", "AppTaskCommand", "AppTaskStatus", "PercentCompleted", "Parameters", "Language", "StartDateTime_UTC", "EndDateTime_UTC", "EstimatedLength_second", "RemainingTime_second", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(AppTask).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(AppTask).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void AppTask_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(AppTask).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(AppTask).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void AppTask_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               appTask.AppTaskID = val1;
               Assert.Equal(val1, appTask.AppTaskID);
               int val2 = 45;
               appTask.TVItemID = val2;
               Assert.Equal(val2, appTask.TVItemID);
               int val3 = 45;
               appTask.TVItemID2 = val3;
               Assert.Equal(val3, appTask.TVItemID2);
               AppTaskCommandEnum val4 = (AppTaskCommandEnum)3;
               appTask.AppTaskCommand = val4;
               Assert.Equal(val4, appTask.AppTaskCommand);
               AppTaskStatusEnum val5 = (AppTaskStatusEnum)3;
               appTask.AppTaskStatus = val5;
               Assert.Equal(val5, appTask.AppTaskStatus);
               int val6 = 45;
               appTask.PercentCompleted = val6;
               Assert.Equal(val6, appTask.PercentCompleted);
               string val7 = "Some text";
               appTask.Parameters = val7;
               Assert.Equal(val7, appTask.Parameters);
               LanguageEnum val8 = (LanguageEnum)3;
               appTask.Language = val8;
               Assert.Equal(val8, appTask.Language);
               DateTime val9 = new DateTime(2010, 3, 4);
               appTask.StartDateTime_UTC = val9;
               Assert.Equal(val9, appTask.StartDateTime_UTC);
               DateTime val10 = new DateTime(2010, 3, 4);
               appTask.EndDateTime_UTC = val10;
               Assert.Equal(val10, appTask.EndDateTime_UTC);
               int val11 = 45;
               appTask.EstimatedLength_second = val11;
               Assert.Equal(val11, appTask.EstimatedLength_second);
               int val12 = 45;
               appTask.RemainingTime_second = val12;
               Assert.Equal(val12, appTask.RemainingTime_second);
               DateTime val13 = new DateTime(2010, 3, 4);
               appTask.LastUpdateDate_UTC = val13;
               Assert.Equal(val13, appTask.LastUpdateDate_UTC);
               int val14 = 45;
               appTask.LastUpdateContactTVItemID = val14;
               Assert.Equal(val14, appTask.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
