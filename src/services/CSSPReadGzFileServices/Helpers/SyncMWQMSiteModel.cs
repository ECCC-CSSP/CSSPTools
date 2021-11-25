namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncMWQMSiteModel(MWQMSiteModel mwqmSiteModelOriginal, MWQMSiteModel mwqmSiteModelLocal)
    {
        if (mwqmSiteModelLocal != null)
        {
            if (mwqmSiteModelLocal.TVItemModel != null)
            {
                SyncTVItemModel(mwqmSiteModelOriginal.TVItemModel, mwqmSiteModelLocal.TVItemModel);
            }

            if (mwqmSiteModelLocal.MWQMSite != null)
            {
                mwqmSiteModelOriginal.MWQMSite = mwqmSiteModelLocal.MWQMSite;
            }

            foreach (MWQMSiteStartEndDate mwqmSiteStartEndDate in mwqmSiteModelLocal.MWQMSiteStartEndDateList)
            {
                MWQMSiteStartEndDate mwqmSiteStartEndDateOriginal = mwqmSiteModelLocal.MWQMSiteStartEndDateList.Where(c => c.MWQMSiteStartEndDateID == mwqmSiteStartEndDate.MWQMSiteStartEndDateID).FirstOrDefault();
                if (mwqmSiteStartEndDateOriginal == null)
                {
                    mwqmSiteModelLocal.MWQMSiteStartEndDateList.Add(mwqmSiteStartEndDate);
                }
                else
                {
                    mwqmSiteStartEndDateOriginal = mwqmSiteStartEndDate;
                }
            }

            List<TVFileModel> TVFileModelList = (from c in mwqmSiteModelLocal.TVFileModelList
                                                 where c.TVFile.TVFileID != 0
                                                 && (c.TVFile.DBCommand != DBCommandEnum.Original
                                                 || c.TVFileLanguageList[0].DBCommand != DBCommandEnum.Original
                                                 || c.TVFileLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                 select c).ToList();

            foreach (TVFileModel tvFileModel in TVFileModelList)
            {
                TVFileModel tvFileModelOriginal = mwqmSiteModelLocal.TVFileModelList.Where(c => c.TVFile.TVFileID == tvFileModel.TVFile.TVFileID).FirstOrDefault();
                if (tvFileModelOriginal == null)
                {
                    mwqmSiteModelLocal.TVFileModelList.Add(tvFileModel);
                }
                else
                {
                    tvFileModelOriginal = tvFileModel;
                }
            }
        }
    }
}

