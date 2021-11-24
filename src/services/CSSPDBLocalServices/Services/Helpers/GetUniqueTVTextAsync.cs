namespace CSSPDBLocalServices;

public partial class HelperLocalService : ControllerBase, IHelperLocalService
{
    public async Task<string> GetUniqueTVTextAsync(List<TVItemModel> TVItemModelList, LanguageEnum language, string StartText)
    {
        int LangID = language == LanguageEnum.fr ? 1 : 0;

        string TVText = "";
        for (int i = 1; i < 1000; i++)
        {
            TVText = $"{ StartText} { i }";

            if (!(from c in TVItemModelList
                  where c.TVItemLanguageList[LangID].TVText == TVText
                  select c).Any())
            {
                break;
            }
        }

        return await Task.FromResult(TVText);
    }
}
