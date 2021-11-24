namespace CSSPDBLocalServices.Tests;

public partial class CSSPDBLocalServiceTest
{
    protected void CheckTVItem(TVItemModel tvItemModel, DBCommandEnum dbCommand)
    {
        TVItem tvItemDB = (from c in dbLocal.TVItems
                           where c.TVItemID == tvItemModel.TVItem.TVItemID
                           select c).FirstOrDefault();
        Assert.NotNull(tvItemDB);

        Assert.Equal(dbCommand, tvItemModel.TVItem.DBCommand);
        Assert.Equal(tvItemDB.DBCommand, tvItemModel.TVItem.DBCommand);
        Assert.Equal(tvItemDB.IsActive, tvItemModel.TVItem.IsActive);
        Assert.Equal(tvItemDB.ParentID, tvItemModel.TVItem.ParentID);
        Assert.Equal(tvItemDB.TVItemID, tvItemModel.TVItem.TVItemID);
        Assert.Equal(tvItemDB.TVLevel, tvItemModel.TVItem.TVLevel);
        Assert.Equal(tvItemDB.TVPath, tvItemModel.TVItem.TVPath);
        Assert.Equal(tvItemDB.TVType, tvItemModel.TVItem.TVType);
        if (dbCommand != DBCommandEnum.Original)
        {
            Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, tvItemModel.TVItem.LastUpdateContactTVItemID);
            Assert.True(DateTime.UtcNow.AddMinutes(-1) < tvItemModel.TVItem.LastUpdateDate_UTC);
            Assert.True(DateTime.UtcNow.AddMinutes(1) > tvItemModel.TVItem.LastUpdateDate_UTC);
        }
        else
        {
            Assert.Equal(tvItemDB.LastUpdateContactTVItemID, tvItemModel.TVItem.LastUpdateContactTVItemID);
            Assert.Equal(tvItemDB.LastUpdateDate_UTC, tvItemModel.TVItem.LastUpdateDate_UTC);
        }
    }
}

