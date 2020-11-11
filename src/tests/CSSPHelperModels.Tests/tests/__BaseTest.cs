/*
 * Manually edited
 * 
 */
using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using CSSPHelperModels;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;

namespace CSSPHelperModels.Tests
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
            bool retBool = csspAfterAttribute.IsValid(new object());
            Assert.True(retBool);

            CSSPAllowNullAttribute csspAllowNullAttribute = new CSSPAllowNullAttribute();
            retBool = csspAllowNullAttribute.IsValid(new object());
            Assert.True(retBool);

            CSSPBiggerAttribute csspBiggerAttribute = new CSSPBiggerAttribute();
            csspBiggerAttribute.OtherField = "Something";
            Assert.Equal("Something", csspBiggerAttribute.OtherField);
            retBool = csspBiggerAttribute.IsValid(new object());
            Assert.True(retBool);

            CSSPCompareAttribute csspCompareAttribute = new CSSPCompareAttribute("something");
            retBool = csspCompareAttribute.IsValid(new object());
            Assert.True(retBool);

            CSSPEnumTypeAttribute csspEnumTypeAttribute = new CSSPEnumTypeAttribute();
            retBool = csspEnumTypeAttribute.IsValid(new object());
            Assert.True(retBool);

            CSSPEnumTypeTextAttribute csspEnumTypeTextAttribute = new CSSPEnumTypeTextAttribute();
            retBool = csspEnumTypeTextAttribute.IsValid(new object());
            Assert.True(retBool);

            CSSPExistAttribute csspExistAttribute = new CSSPExistAttribute();
            csspExistAttribute.ExistTypeName = "Something";
            Assert.Equal("Something", csspExistAttribute.ExistTypeName);
            csspExistAttribute.ExistPlurial = "s";
            Assert.Equal("s", csspExistAttribute.ExistPlurial);
            csspExistAttribute.ExistFieldID = "Something";
            Assert.Equal("Something", csspExistAttribute.ExistFieldID);
            csspExistAttribute.AllowableTVTypeList = "2,9";
            Assert.Equal("2,9", csspExistAttribute.AllowableTVTypeList);
            retBool = csspExistAttribute.IsValid(new object());
            Assert.True(retBool);

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
            Assert.True(retBool);

            CSSPMaxLengthAttribute csspMaxLengthAttribute = new CSSPMaxLengthAttribute(34);
            retBool = csspMaxLengthAttribute.IsValid(new object());
            Assert.True(retBool);

            CSSPMinLengthAttribute csspMinLengthAttribute = new CSSPMinLengthAttribute(34);
            retBool = csspMinLengthAttribute.IsValid(new object());
            Assert.True(retBool);

            CSSPRangeAttribute csspRangeAttribute = new CSSPRangeAttribute(34, 54);
            retBool = csspRangeAttribute.IsValid(new object());
            Assert.True(retBool);

            CSSPRegularExpressionAttribute csspRegularExpressionAttribute = new CSSPRegularExpressionAttribute("/testing/");
            retBool = csspRegularExpressionAttribute.IsValid(new object());
            Assert.True(retBool);

            CSSPRequiredAttribute csspRequiredAttribute = new CSSPRequiredAttribute();
            retBool = csspRequiredAttribute.IsValid(new object());
            Assert.True(retBool);

        }
        #endregion Tests
    }
}
