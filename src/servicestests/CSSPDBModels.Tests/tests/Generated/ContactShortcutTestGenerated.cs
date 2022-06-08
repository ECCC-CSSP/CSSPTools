/*
 * Auto generated from C:\CSSPTools\src\codegen\GenerateCSSPDBModels_TestsGenerated\bin\Debug\net6.0\GenerateCSSPDBModels_TestsGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

namespace CSSPDBModels.Tests;

public partial class ContactShortcutTest
{
    private ContactShortcut contactShortcut { get; set; }

    public ContactShortcutTest()
    {
        contactShortcut = new ContactShortcut();
    }
    [Fact]
    public void ContactShortcut_Properties_Test()
    {
        List<string> propNameList = new List<string>() { "ContactShortcutID", "DBCommand", "ContactID", "ShortCutText", "ShortCutAddress", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

        int index = 0;
        foreach (PropertyInfo propertyInfo in typeof(ContactShortcut).GetProperties().OrderBy(c => c.Name))
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
        foreach (PropertyInfo propertyInfo in typeof(ContactShortcut).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
    public void ContactShortcut_Navigation_Test()
    {
        List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
        List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

        int index = 0;
        foreach (PropertyInfo propertyInfo in typeof(ContactShortcut).GetProperties())
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
        foreach (PropertyInfo propertyInfo in typeof(ContactShortcut).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
    public void ContactShortcut_Every_Property_Has_Get_Set_Test()
    {
           int val1 = 45;
           contactShortcut.ContactShortcutID = val1;
           Assert.Equal(val1, contactShortcut.ContactShortcutID);
           DBCommandEnum val2 = (DBCommandEnum)3;
           contactShortcut.DBCommand = val2;
           Assert.Equal(val2, contactShortcut.DBCommand);
           int val3 = 45;
           contactShortcut.ContactID = val3;
           Assert.Equal(val3, contactShortcut.ContactID);
           string val4 = "Some text";
           contactShortcut.ShortCutText = val4;
           Assert.Equal(val4, contactShortcut.ShortCutText);
           string val5 = "Some text";
           contactShortcut.ShortCutAddress = val5;
           Assert.Equal(val5, contactShortcut.ShortCutAddress);
           DateTime val6 = new DateTime(2010, 3, 4);
           contactShortcut.LastUpdateDate_UTC = val6;
           Assert.Equal(val6, contactShortcut.LastUpdateDate_UTC);
           int val7 = 45;
           contactShortcut.LastUpdateContactTVItemID = val7;
           Assert.Equal(val7, contactShortcut.LastUpdateContactTVItemID);
    }
}
