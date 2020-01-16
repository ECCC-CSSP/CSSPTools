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
    public partial class CSSPMPNTableTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPMPNTable cSSPMPNTable { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPMPNTableTest()
        {
            cSSPMPNTable = new CSSPMPNTable();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void CSSPMPNTable_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "Tube10", "Tube1_0", "Tube0_1", "MPN", "HasErrors",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(CSSPMPNTable).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void CSSPMPNTable_Has_ValidationResults_Test()
        {
             Assert.True(typeof(CSSPMPNTable).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void CSSPMPNTable_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               cSSPMPNTable.Tube10 = val1;
               Assert.Equal(val1, cSSPMPNTable.Tube10);
               int val2 = 45;
               cSSPMPNTable.Tube1_0 = val2;
               Assert.Equal(val2, cSSPMPNTable.Tube1_0);
               int val3 = 45;
               cSSPMPNTable.Tube0_1 = val3;
               Assert.Equal(val3, cSSPMPNTable.Tube0_1);
               int val4 = 45;
               cSSPMPNTable.MPN = val4;
               Assert.Equal(val4, cSSPMPNTable.MPN);
               bool val5 = true;
               cSSPMPNTable.HasErrors = val5;
               Assert.Equal(val5, cSSPMPNTable.HasErrors);
               IEnumerable<ValidationResult> val18 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               cSSPMPNTable.ValidationResults = val18;
               Assert.Equal(val18, cSSPMPNTable.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
