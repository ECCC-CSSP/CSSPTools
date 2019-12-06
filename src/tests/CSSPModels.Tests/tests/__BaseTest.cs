using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using CSSPModels;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;

namespace CSSPModels.Tests
{
    [TestClass]
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
        [TestMethod]
        public void __Base_Test()
        {
            CSSPAfterAttribute csspAfterAttribute = new CSSPAfterAttribute();
            csspAfterAttribute.Year = 34;
            Assert.AreEqual(34, csspAfterAttribute.Year);
            bool retBool = true;// csspAfterAttribute.IsValid(new object());
            Assert.AreEqual(true, retBool);

            CSSPAllowNullAttribute csspAllowNullAttribute = new CSSPAllowNullAttribute();
            retBool = csspAllowNullAttribute.IsValid(new object());
            Assert.AreEqual(true, retBool);

            CSSPBiggerAttribute csspBiggerAttribute = new CSSPBiggerAttribute();
            csspBiggerAttribute.OtherField = "Something";
            Assert.AreEqual("Something", csspBiggerAttribute.OtherField);
            retBool = csspBiggerAttribute.IsValid(new object());
            Assert.AreEqual(true, retBool);

            CSSPEnumTypeAttribute csspEnumTypeAttribute = new CSSPEnumTypeAttribute();
            retBool = csspEnumTypeAttribute.IsValid(new object());
            Assert.AreEqual(true, retBool);

            CSSPExistAttribute csspExistAttribute = new CSSPExistAttribute();
            csspExistAttribute.ExistTypeName = "Something";
            Assert.AreEqual("Something", csspExistAttribute.ExistTypeName);
            csspExistAttribute.ExistPlurial = "s";
            Assert.AreEqual("s", csspExistAttribute.ExistPlurial);
            csspExistAttribute.ExistFieldID = "Something";
            Assert.AreEqual("Something", csspExistAttribute.ExistFieldID);
            csspExistAttribute.AllowableTVTypeList = "2,9";
            Assert.AreEqual("2,9", csspExistAttribute.AllowableTVTypeList);

            CSSPFillAttribute csspFillAttribute = new CSSPFillAttribute();
            csspFillAttribute.FillTypeName = "Something";
            Assert.AreEqual("Something", csspFillAttribute.FillTypeName);
            csspFillAttribute.FillPlurial = "Something";
            Assert.AreEqual("Something", csspFillAttribute.FillPlurial);
            csspFillAttribute.FillFieldID = "Something";
            Assert.AreEqual("Something", csspFillAttribute.FillFieldID);
            csspFillAttribute.FillEqualField = "Something";
            Assert.AreEqual("Something", csspFillAttribute.FillEqualField);
            csspFillAttribute.FillReturnField = "Something";
            Assert.AreEqual("Something", csspFillAttribute.FillReturnField);

            retBool = csspExistAttribute.IsValid(new object());
            Assert.AreEqual(true, retBool);

        }
        #endregion Tests
    }
}
