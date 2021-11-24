namespace CSSPCustomAttributes.Tests;

public partial class CSSPCustomAttributesTest
{
    // most of the tests are auto generated and are located under AddressTestGenerated.cs
    // use this section to add other manual test

    #region Tests
    [Fact]
    public void CSSPAfterAttribute_Good_Test()
    {
        CSSPAfterAttribute CSSPAfterAttribute = new CSSPAfterAttribute();
        Assert.NotNull(CSSPAfterAttribute);

        CSSPAfterAttribute.Year = 34;
        Assert.Equal(34, CSSPAfterAttribute.Year);

        Assert.True(CSSPAfterAttribute.IsValid(new object { }));
    }
    [Fact]
    public void CSSPAllowNullAttribute_Good_Test()
    {
        CSSPAllowNullAttribute CSSPAllowNullAttribute = new CSSPAllowNullAttribute();
        Assert.NotNull(CSSPAllowNullAttribute);

        Assert.True(CSSPAllowNullAttribute.IsValid(new object { }));
    }
    [Fact]
    public void CSSPBiggerAttribute_Good_Test()
    {
        CSSPBiggerAttribute CSSPBiggerAttribute = new CSSPBiggerAttribute();
        Assert.NotNull(CSSPBiggerAttribute);

        CSSPBiggerAttribute.OtherField = "The Other Field";
        Assert.Equal("The Other Field", CSSPBiggerAttribute.OtherField);

        Assert.True(CSSPBiggerAttribute.IsValid(new object { }));
    }
    [Fact]
    public void CSSPCompareAttribute_Good_Test()
    {
        CSSPCompareAttribute CSSPCompareAttribute = new CSSPCompareAttribute("Other Property");
        Assert.NotNull(CSSPCompareAttribute);

        Assert.True(CSSPCompareAttribute.IsValid(new object { }));
    }
    [Fact]
    public void CSSPEnumTypeAttribute_Good_Test()
    {
        CSSPEnumTypeAttribute CSSPEnumTypeAttribute = new CSSPEnumTypeAttribute();

        Assert.True(CSSPEnumTypeAttribute.IsValid(new object { }));
    }
    [Fact]
    public void CSSPEnumTypeTextAttribute_Good_Test()
    {
        CSSPEnumTypeTextAttribute CSSPEnumTypeTextAttribute = new CSSPEnumTypeTextAttribute();
        CSSPEnumTypeTextAttribute.EnumTypeName = "Enum type name";
        Assert.Equal("Enum type name", CSSPEnumTypeTextAttribute.EnumTypeName);

        CSSPEnumTypeTextAttribute.EnumType = "Enum type";
        Assert.Equal("Enum type", CSSPEnumTypeTextAttribute.EnumType);

        Assert.True(CSSPEnumTypeTextAttribute.IsValid(new object { }));
    }
    [Fact]
    public void CSSPExistAttribute_Good_Test()
    {
        CSSPExistAttribute CSSPExistAttribute = new CSSPExistAttribute();
        CSSPExistAttribute.ExistTypeName = "Exist type name";
        Assert.Equal("Exist type name", CSSPExistAttribute.ExistTypeName);

        CSSPExistAttribute.ExistPlurial = "Exist plurial";
        Assert.Equal("Exist plurial", CSSPExistAttribute.ExistPlurial);

        CSSPExistAttribute.ExistFieldID = "Exist Field ID";
        Assert.Equal("Exist Field ID", CSSPExistAttribute.ExistFieldID);

        CSSPExistAttribute.AllowableTVTypeList = "Allowable TVType List";
        Assert.Equal("Allowable TVType List", CSSPExistAttribute.AllowableTVTypeList);

        Assert.True(CSSPExistAttribute.IsValid(new object { }));
    }
    [Fact]
    public void CSSPFillAttribute_Good_Test()
    {
        CSSPFillAttribute CSSPFillAttribute = new CSSPFillAttribute();
        CSSPFillAttribute.FillTypeName = "Fill Type Name";
        Assert.Equal("Fill Type Name", CSSPFillAttribute.FillTypeName);

        CSSPFillAttribute.FillPlurial = "FillPlurial";
        Assert.Equal("FillPlurial", CSSPFillAttribute.FillPlurial);

        CSSPFillAttribute.FillFieldID = "Fill Field ID";
        Assert.Equal("Fill Field ID", CSSPFillAttribute.FillFieldID);

        CSSPFillAttribute.FillEqualField = "Fill Equal Field";
        Assert.Equal("Fill Equal Field", CSSPFillAttribute.FillEqualField);

        CSSPFillAttribute.FillReturnField = "Fill Return Field";
        Assert.Equal("Fill Return Field", CSSPFillAttribute.FillReturnField);

        CSSPFillAttribute.FillNeedLanguage = true;
        Assert.True(CSSPFillAttribute.FillNeedLanguage);

        CSSPFillAttribute.FillIsList = true;
        Assert.True(CSSPFillAttribute.FillIsList);

        Assert.True(CSSPFillAttribute.IsValid(new object { }));
    }
    [Fact]
    public void CSSPForeignKeyAttribute_Good_Test()
    {
        CSSPForeignKeyAttribute CSSPForeignKeyAttribute = new CSSPForeignKeyAttribute();
        CSSPForeignKeyAttribute.TableName = "Table Name";
        Assert.Equal("Table Name", CSSPForeignKeyAttribute.TableName);

        CSSPForeignKeyAttribute.FieldName = "Field Name";
        Assert.Equal("Field Name", CSSPForeignKeyAttribute.FieldName);

        Assert.True(CSSPForeignKeyAttribute.IsValid(new object { }));
    }
    [Fact]
    public void CSSPMaxLengthAttribute_Good_Test()
    {
        CSSPMaxLengthAttribute CSSPMaxLengthAttribute = new CSSPMaxLengthAttribute(34);
        Assert.NotNull(CSSPMaxLengthAttribute);

        Assert.True(CSSPMaxLengthAttribute.IsValid(new object { }));
    }
    [Fact]
    public void CSSPMinLengthAttribute_Good_Test()
    {
        CSSPMinLengthAttribute CSSPMinLengthAttribute = new CSSPMinLengthAttribute(34);
        Assert.NotNull(CSSPMinLengthAttribute);

        Assert.True(CSSPMinLengthAttribute.IsValid(new object { }));
    }
    [Fact]
    public void CSSPRangeAttribute_Good_Test()
    {
        CSSPRangeAttribute CSSPRangeAttribute = new CSSPRangeAttribute(34, 45);
        Assert.NotNull(CSSPRangeAttribute);

        Assert.True(CSSPRangeAttribute.IsValid(new object { }));

        CSSPRangeAttribute CSSPRangeAttribute2 = new CSSPRangeAttribute(34.4D, 45.5D);
        Assert.NotNull(CSSPRangeAttribute2);

        Assert.True(CSSPRangeAttribute2.IsValid(new object { }));

        CSSPRangeAttribute CSSPRangeAttribute3 = new CSSPRangeAttribute(typeof(float), "34.4", "45.5");
        Assert.NotNull(CSSPRangeAttribute3);

        Assert.True(CSSPRangeAttribute3.IsValid(new object { }));
    }
    [Fact]
    public void CSSPRegularExpressionAttribute_Good_Test()
    {
        CSSPRegularExpressionAttribute CSSPRegularExpressionAttribute = new CSSPRegularExpressionAttribute("/b-t");
        Assert.NotNull(CSSPRegularExpressionAttribute);

        Assert.True(CSSPRegularExpressionAttribute.IsValid(new object { }));
    }
    [Fact]
    public void CSSPRequiredAttribute_Good_Test()
    {
        CSSPRequiredAttribute CSSPRequiredAttribute = new CSSPRequiredAttribute();
        Assert.NotNull(CSSPRequiredAttribute);

        Assert.True(CSSPRequiredAttribute.IsValid(new object { }));
    }
    #endregion Tests
}

