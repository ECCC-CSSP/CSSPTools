namespace CSSPDBLocalServices.Tests;

public partial class CSSPDBLocalServiceTest
{
    protected void CheckDBLocal(List<TVItemModel> tvItemModelList)
    {

        foreach (TVItemModel tvItemModel in tvItemModelList)
        {
            TVItem tvItem = (from c in dbLocal.TVItems
                             where c.TVItemID == tvItemModel.TVItem.TVItemID
                             select c).FirstOrDefault();

            Assert.NotNull(tvItem);

            List<TVItemLanguage> tvItemLanguageList = (from c in dbLocal.TVItemLanguages
                                                       where c.TVItemID == tvItemModel.TVItem.TVItemID
                                                       orderby c.Language
                                                       select c).ToList();

            Assert.NotNull(tvItem);

            TVItemModel tvItemModelDB = new TVItemModel()
            {
                TVItem = tvItem,
                TVItemLanguageList = tvItemLanguageList,
                TVItemStatList = tvItemModel.TVItemStatList,
                MapInfoModelList = tvItemModel.MapInfoModelList,
            };

            Assert.Equal(JsonSerializer.Serialize(tvItemModel), JsonSerializer.Serialize(tvItemModelDB));
        }
    }
}

