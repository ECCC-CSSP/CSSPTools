namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncInfrastructureModel(InfrastructureModel infrastructureModelOriginal, InfrastructureModel infrastructureModelLocal)
    {
        if (infrastructureModelLocal != null)
        {
            if (infrastructureModelLocal.TVItemModel != null)
            {
                SyncTVItemModel(infrastructureModelOriginal.TVItemModel, infrastructureModelLocal.TVItemModel);
            }
            if (infrastructureModelLocal.Infrastructure != null)
            {
                infrastructureModelOriginal.Infrastructure = infrastructureModelLocal.Infrastructure;
            }
            if (infrastructureModelLocal.InfrastructureLanguageList != null)
            {
                infrastructureModelOriginal.InfrastructureLanguageList = infrastructureModelLocal.InfrastructureLanguageList;
            }

            List<TVFileModel> TVFileModelInfrastructureLocalList = (from c in infrastructureModelLocal.TVFileModelList
                                                                    where c.TVFile.TVFileID != 0
                                                                    && (c.TVFile.DBCommand != DBCommandEnum.Original
                                                                    || c.TVFileLanguageList[0].DBCommand != DBCommandEnum.Original
                                                                    || c.TVFileLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                                    select c).ToList();

            foreach (TVFileModel tvFileModelInfrastructureLocal in TVFileModelInfrastructureLocalList)
            {
                TVFileModel tvFileModelInfrastructureOriginal = infrastructureModelOriginal.TVFileModelList.Where(c => c.TVFile.TVFileID == tvFileModelInfrastructureLocal.TVFile.TVFileID).FirstOrDefault();
                if (tvFileModelInfrastructureOriginal == null)
                {
                    infrastructureModelOriginal.TVFileModelList.Add(tvFileModelInfrastructureLocal);
                }
                else
                {
                    SyncTVFileModel(tvFileModelInfrastructureOriginal, tvFileModelInfrastructureLocal);
                }
            }
            if (infrastructureModelLocal.BoxModelModelList != null)
            {
                foreach (BoxModelModel boxModelModelLocal in infrastructureModelLocal.BoxModelModelList)
                {
                    BoxModelModel boxModelModelOriginal = infrastructureModelOriginal.BoxModelModelList.Where(c => c.BoxModel.BoxModelID == boxModelModelLocal.BoxModel.BoxModelID).FirstOrDefault();
                    if (boxModelModelOriginal == null)
                    {
                        infrastructureModelOriginal.BoxModelModelList.Add(boxModelModelLocal);
                    }
                    else
                    {
                        SyncBoxModelModel(boxModelModelOriginal, boxModelModelLocal);
                    }
                }
            }
            if (infrastructureModelLocal.VPScenarioModelList != null)
            {
                foreach (VPScenarioModel boxModelModelLocal in infrastructureModelLocal.VPScenarioModelList)
                {
                    VPScenarioModel boxModelModelOriginal = infrastructureModelOriginal.VPScenarioModelList.Where(c => c.VPScenario.VPScenarioID == boxModelModelLocal.VPScenario.VPScenarioID).FirstOrDefault();
                    if (boxModelModelOriginal == null)
                    {
                        infrastructureModelOriginal.VPScenarioModelList.Add(boxModelModelLocal);
                    }
                    else
                    {
                        SyncVPScenarioModel(boxModelModelOriginal, boxModelModelLocal);
                    }
                }
            }
        }
    }
}

