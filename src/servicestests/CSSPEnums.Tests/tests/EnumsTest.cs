/*
 * This document is manually edited.
 * 
 * All testing function are generated under documents
 * EnumsTestGenerated.cs and EnumsPolSourceObsInfoEnumTestGenerated.cs
 * 
 */

namespace CSSPEnums.Tests;

public partial class EnumsTest
{
    [Theory]
    [InlineData("en-CA")]
    [InlineData("fr-CA")]
    public async Task Enums_Constructor_Good_Test(string culture)
    {
        Assert.True(await EnumsSetup(culture));
        Assert.NotNull(CSSPCultureService);
        Assert.NotNull(enums);

    }
}

