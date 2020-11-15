/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPHelperModels_TestsGenerated.exe
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
using CSSPDBModels;

namespace CSSPHelperModels.Tests
{
    public partial class OtherFilesToUploadTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private OtherFilesToUpload otherFilesToUpload { get; set; }
        #endregion Properties

        #region Constructors
        public OtherFilesToUploadTest()
        {
            otherFilesToUpload = new OtherFilesToUpload();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void OtherFilesToUpload_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "MikeScenarioID", "TVFileList",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(OtherFilesToUpload).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void OtherFilesToUpload_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               otherFilesToUpload.MikeScenarioID = val1;
               Assert.Equal(val1, otherFilesToUpload.MikeScenarioID);
               List<TVFile> val2 = new List<TVFile>() { new TVFile(), new TVFile() };
               otherFilesToUpload.TVFileList = val2;
               Assert.Equal(val2, otherFilesToUpload.TVFileList);
        }
        #endregion Tests Functions public
    }
}