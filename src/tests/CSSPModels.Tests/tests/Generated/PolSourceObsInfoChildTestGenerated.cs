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
    public partial class PolSourceObsInfoChildTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private PolSourceObsInfoChild polSourceObsInfoChild { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObsInfoChildTest()
        {
            polSourceObsInfoChild = new PolSourceObsInfoChild();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void PolSourceObsInfoChild_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "PolSourceObsInfo", "PolSourceObsInfoChildStart", "PolSourceObsInfoText", "PolSourceObsInfoChildStartText",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(PolSourceObsInfoChild).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void PolSourceObsInfoChild_Every_Property_Has_Get_Set_Test()
        {
               PolSourceObsInfoEnum val1 = (PolSourceObsInfoEnum)3;
               polSourceObsInfoChild.PolSourceObsInfo = val1;
               Assert.Equal(val1, polSourceObsInfoChild.PolSourceObsInfo);
               PolSourceObsInfoEnum val2 = (PolSourceObsInfoEnum)3;
               polSourceObsInfoChild.PolSourceObsInfoChildStart = val2;
               Assert.Equal(val2, polSourceObsInfoChild.PolSourceObsInfoChildStart);
               string val3 = "Some text";
               polSourceObsInfoChild.PolSourceObsInfoText = val3;
               Assert.Equal(val3, polSourceObsInfoChild.PolSourceObsInfoText);
               string val4 = "Some text";
               polSourceObsInfoChild.PolSourceObsInfoChildStartText = val4;
               Assert.Equal(val4, polSourceObsInfoChild.PolSourceObsInfoChildStartText);
        }
        #endregion Tests Functions public
    }
}
