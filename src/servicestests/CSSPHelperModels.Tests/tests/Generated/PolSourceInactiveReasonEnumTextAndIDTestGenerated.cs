/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net6.0\GenerateCSSPHelperModels_TestsGenerated.exe
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
    public partial class PolSourceInactiveReasonEnumTextAndIDTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private PolSourceInactiveReasonEnumTextAndID polSourceInactiveReasonEnumTextAndID { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceInactiveReasonEnumTextAndIDTest()
        {
            polSourceInactiveReasonEnumTextAndID = new PolSourceInactiveReasonEnumTextAndID();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void PolSourceInactiveReasonEnumTextAndID_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "Text", "ID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(PolSourceInactiveReasonEnumTextAndID).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void PolSourceInactiveReasonEnumTextAndID_Every_Property_Has_Get_Set_Test()
        {
               string val1 = "Some text";
               polSourceInactiveReasonEnumTextAndID.Text = val1;
               Assert.Equal(val1, polSourceInactiveReasonEnumTextAndID.Text);
               int val2 = 45;
               polSourceInactiveReasonEnumTextAndID.ID = val2;
               Assert.Equal(val2, polSourceInactiveReasonEnumTextAndID.ID);
        }
        #endregion Tests Functions public
    }
}
