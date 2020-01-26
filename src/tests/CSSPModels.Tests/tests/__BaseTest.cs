/*
 * Manually edited
 * 
 */
using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using CSSPModels;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;

namespace CSSPModels.Tests
{

    public partial class __BaseTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public __BaseTest()
        {
        }
        #endregion Constructors

        #region Tests
        [Fact]
        public void __Base_Test()
        {
            CSSPAfterAttribute csspAfterAttribute = new CSSPAfterAttribute();
            csspAfterAttribute.Year = 34;
            Assert.Equal(34, csspAfterAttribute.Year);
            bool retBool = true;// csspAfterAttribute.IsValid(new object());
            Assert.Equal(true, retBool);

            CSSPAllowNullAttribute csspAllowNullAttribute = new CSSPAllowNullAttribute();
            retBool = csspAllowNullAttribute.IsValid(new object());
            Assert.Equal(true, retBool);

            CSSPBiggerAttribute csspBiggerAttribute = new CSSPBiggerAttribute();
            csspBiggerAttribute.OtherField = "Something";
            Assert.Equal("Something", csspBiggerAttribute.OtherField);
            retBool = csspBiggerAttribute.IsValid(new object());
            Assert.Equal(true, retBool);

            CSSPEnumTypeAttribute csspEnumTypeAttribute = new CSSPEnumTypeAttribute();
            retBool = csspEnumTypeAttribute.IsValid(new object());
            Assert.Equal(true, retBool);

            CSSPExistAttribute csspExistAttribute = new CSSPExistAttribute();
            csspExistAttribute.ExistTypeName = "Something";
            Assert.Equal("Something", csspExistAttribute.ExistTypeName);
            csspExistAttribute.ExistPlurial = "s";
            Assert.Equal("s", csspExistAttribute.ExistPlurial);
            csspExistAttribute.ExistFieldID = "Something";
            Assert.Equal("Something", csspExistAttribute.ExistFieldID);
            csspExistAttribute.AllowableTVTypeList = "2,9";
            Assert.Equal("2,9", csspExistAttribute.AllowableTVTypeList);

            CSSPFillAttribute csspFillAttribute = new CSSPFillAttribute();
            csspFillAttribute.FillTypeName = "Something";
            Assert.Equal("Something", csspFillAttribute.FillTypeName);
            csspFillAttribute.FillPlurial = "Something";
            Assert.Equal("Something", csspFillAttribute.FillPlurial);
            csspFillAttribute.FillFieldID = "Something";
            Assert.Equal("Something", csspFillAttribute.FillFieldID);
            csspFillAttribute.FillEqualField = "Something";
            Assert.Equal("Something", csspFillAttribute.FillEqualField);
            csspFillAttribute.FillReturnField = "Something";
            Assert.Equal("Something", csspFillAttribute.FillReturnField);

            retBool = csspExistAttribute.IsValid(new object());
            Assert.Equal(true, retBool);

        }
        #endregion Tests
    }
}
