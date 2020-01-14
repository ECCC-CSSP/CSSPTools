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

    public partial class PolSourceObsInfoEnumTextAndIDTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private PolSourceObsInfoEnumTextAndID polSourceObsInfoEnumTextAndID { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObsInfoEnumTextAndIDTest()
        {
            polSourceObsInfoEnumTextAndID = new PolSourceObsInfoEnumTextAndID();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void PolSourceObsInfoEnumTextAndID_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "Text", "ID", "HasErrors",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(PolSourceObsInfoEnumTextAndID).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void PolSourceObsInfoEnumTextAndID_Has_ValidationResults_Test()
        {
             Assert.True(typeof(PolSourceObsInfoEnumTextAndID).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void PolSourceObsInfoEnumTextAndID_Every_Property_Has_Get_Set_Test()
        {
               string val1 = "Some text";
               polSourceObsInfoEnumTextAndID.Text = val1;
               Assert.Equal(val1, polSourceObsInfoEnumTextAndID.Text);
               int val2 = 45;
               polSourceObsInfoEnumTextAndID.ID = val2;
               Assert.Equal(val2, polSourceObsInfoEnumTextAndID.ID);
               bool val3 = true;
               polSourceObsInfoEnumTextAndID.HasErrors = val3;
               Assert.Equal(val3, polSourceObsInfoEnumTextAndID.HasErrors);
               IEnumerable<ValidationResult> val12 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               polSourceObsInfoEnumTextAndID.ValidationResults = val12;
               Assert.Equal(val12, polSourceObsInfoEnumTextAndID.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
