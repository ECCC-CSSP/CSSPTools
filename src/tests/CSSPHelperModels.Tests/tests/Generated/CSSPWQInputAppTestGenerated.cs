/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPHelperModels_TestsGenerated.exe
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
    public partial class CSSPWQInputAppTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWQInputApp cSSPWQInputApp { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPWQInputAppTest()
        {
            cSSPWQInputApp = new CSSPWQInputApp();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void CSSPWQInputApp_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "AccessCode", "ActiveYear", "DailyDuplicatePrecisionCriteria", "IntertechDuplicatePrecisionCriteria", "IncludeLaboratoryQAQC", "ApprovalCode", "ApprovalDate",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(CSSPWQInputApp).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void CSSPWQInputApp_Every_Property_Has_Get_Set_Test()
        {
               string val1 = "Some text";
               cSSPWQInputApp.AccessCode = val1;
               Assert.Equal(val1, cSSPWQInputApp.AccessCode);
               string val2 = "Some text";
               cSSPWQInputApp.ActiveYear = val2;
               Assert.Equal(val2, cSSPWQInputApp.ActiveYear);
               double val3 = 87.9D;
               cSSPWQInputApp.DailyDuplicatePrecisionCriteria = val3;
               Assert.Equal(val3, cSSPWQInputApp.DailyDuplicatePrecisionCriteria);
               double val4 = 87.9D;
               cSSPWQInputApp.IntertechDuplicatePrecisionCriteria = val4;
               Assert.Equal(val4, cSSPWQInputApp.IntertechDuplicatePrecisionCriteria);
               bool val5 = true;
               cSSPWQInputApp.IncludeLaboratoryQAQC = val5;
               Assert.Equal(val5, cSSPWQInputApp.IncludeLaboratoryQAQC);
               string val6 = "Some text";
               cSSPWQInputApp.ApprovalCode = val6;
               Assert.Equal(val6, cSSPWQInputApp.ApprovalCode);
               DateTime val7 = new DateTime(2010, 3, 4);
               cSSPWQInputApp.ApprovalDate = val7;
               Assert.Equal(val7, cSSPWQInputApp.ApprovalDate);
        }
        #endregion Tests Functions public
    }
}
