/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
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
            List<string> propNameList = new List<string>() { "Text", "ID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(PolSourceObsInfoEnumTextAndID).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
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
        }
        #endregion Tests Functions public
    }
}
