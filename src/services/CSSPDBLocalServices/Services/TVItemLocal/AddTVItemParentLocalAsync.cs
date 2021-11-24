namespace CSSPDBLocalServices;

public partial class TVItemLocalService : ControllerBase, ITVItemLocalService
{
    public async Task<bool> AddTVItemParentLocalAsync(List<TVItemModel> tvItemModelParent)
    {
        foreach (TVItemModel tvItemModel in tvItemModelParent)
        {
            if (!(from c in dbLocal.TVItems
                  where c.TVItemID == tvItemModel.TVItem.TVItemID
                  select c).Any())
            {
                try
                {
                    dbLocal.TVItems.Add(tvItemModel.TVItem);
                    dbLocal.SaveChanges();
                }
                catch (Exception ex)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem", ex.Message));
                }

                if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(false);

                foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                {
                    if (!(from c in dbLocal.TVItemLanguages
                          where c.TVItemID == tvItemModel.TVItem.TVItemID
                          && c.Language == lang
                          select c).Any())
                    {

                        try
                        {
                            dbLocal.TVItemLanguages.Add(tvItemModel.TVItemLanguageList[(int)lang - 1]);
                            dbLocal.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguage", ex.Message));
                        }

                        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(false);
                    }
                }
            }
        }

        return await Task.FromResult(true);
    }
}
