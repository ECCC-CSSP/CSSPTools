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
    public partial class FilePurposeAndTextTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private FilePurposeAndText filePurposeAndText { get; set; }
        #endregion Properties

        #region Constructors
        public FilePurposeAndTextTest()
        {
            filePurposeAndText = new FilePurposeAndText();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void FilePurposeAndText_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "FilePurpose", "FilePurposeText",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(FilePurposeAndText).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void FilePurposeAndText_Every_Property_Has_Get_Set_Test()
        {
               FilePurposeEnum val1 = (FilePurposeEnum)3;
               filePurposeAndText.FilePurpose = val1;
               Assert.Equal(val1, filePurposeAndText.FilePurpose);
               string val2 = "Some text";
               filePurposeAndText.FilePurposeText = val2;
               Assert.Equal(val2, filePurposeAndText.FilePurposeText);
        }
        #endregion Tests Functions public
    }
}
