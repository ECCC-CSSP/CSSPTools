/*
 * Auto generated from C:\CSSPTools\src\codegen\GenerateCSSPDBModels_TestsGenerated\bin\Debug\net6.0\GenerateCSSPDBModels_TestsGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

namespace CSSPDBModels.Tests;

public partial class ReportTypeTest
{
    private ReportType reportType { get; set; }

    public ReportTypeTest()
    {
        reportType = new ReportType();
    }
    [Fact]
    public void ReportType_Properties_Test()
    {
        List<string> propNameList = new List<string>() { "ReportTypeID", "DBCommand", "TVType", "FileType", "UniqueCode", "Language", "Name", "Description", "StartOfFileName", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

        int index = 0;
        foreach (PropertyInfo propertyInfo in typeof(ReportType).GetProperties().OrderBy(c => c.Name))
        {
            if (!propertyInfo.GetGetMethod().IsVirtual
                && propertyInfo.Name != "ValidationResults"
                && !propertyInfo.CustomAttributes.Where(c => c.AttributeType.Name.Contains("NotMappedAttribute")).Any())
            {
                Assert.Equal(propNameList[index], propertyInfo.Name);
                index += 1;
            }
        }

        Assert.Equal(propNameList.Count, index);

        index = 0;
        foreach (PropertyInfo propertyInfo in typeof(ReportType).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
        {
            foreach (CustomAttributeData customAttributeData in propertyInfo.CustomAttributes)
            {
                if (customAttributeData.AttributeType.Name == "NotMappedAttribute")
                {
                }
            }
        }


    }
    [Fact]
    public void ReportType_Navigation_Test()
    {
        List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
        List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

        int index = 0;
        foreach (PropertyInfo propertyInfo in typeof(ReportType).GetProperties())
        {
            if (propertyInfo.GetGetMethod().IsVirtual && !propertyInfo.GetGetMethod().ReturnType.Name.StartsWith("ICollection"))
            {
                bool foreignNameExist = foreignNameList.Contains(propertyInfo.Name);
                Assert.True(foreignNameExist);
                index += 1;
            }
        }

        Assert.Equal(foreignNameList.Count, index);

        index = 0;
        foreach (PropertyInfo propertyInfo in typeof(ReportType).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
        {
            if (propertyInfo.GetGetMethod().ReturnType.Name.StartsWith("ICollection"))
            {
                bool foreignNameCollectionExist = foreignNameCollectionList.Contains(propertyInfo.Name);
                Assert.True(foreignNameCollectionExist);
                index += 1;
            }
        }

        Assert.Equal(foreignNameCollectionList.Count, index);

    }
    [Fact]
    public void ReportType_Every_Property_Has_Get_Set_Test()
    {
           int val1 = 45;
           reportType.ReportTypeID = val1;
           Assert.Equal(val1, reportType.ReportTypeID);
           DBCommandEnum val2 = (DBCommandEnum)3;
           reportType.DBCommand = val2;
           Assert.Equal(val2, reportType.DBCommand);
           TVTypeEnum val3 = (TVTypeEnum)3;
           reportType.TVType = val3;
           Assert.Equal(val3, reportType.TVType);
           FileTypeEnum val4 = (FileTypeEnum)3;
           reportType.FileType = val4;
           Assert.Equal(val4, reportType.FileType);
           string val5 = "Some text";
           reportType.UniqueCode = val5;
           Assert.Equal(val5, reportType.UniqueCode);
           LanguageEnum val6 = (LanguageEnum)3;
           reportType.Language = val6;
           Assert.Equal(val6, reportType.Language);
           string val7 = "Some text";
           reportType.Name = val7;
           Assert.Equal(val7, reportType.Name);
           string val8 = "Some text";
           reportType.Description = val8;
           Assert.Equal(val8, reportType.Description);
           string val9 = "Some text";
           reportType.StartOfFileName = val9;
           Assert.Equal(val9, reportType.StartOfFileName);
           DateTime val10 = new DateTime(2010, 3, 4);
           reportType.LastUpdateDate_UTC = val10;
           Assert.Equal(val10, reportType.LastUpdateDate_UTC);
           int val11 = 45;
           reportType.LastUpdateContactTVItemID = val11;
           Assert.Equal(val11, reportType.LastUpdateContactTVItemID);
    }
}
