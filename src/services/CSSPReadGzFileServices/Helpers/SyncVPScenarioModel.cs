namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncVPScenarioModel(VPScenarioModel vpScenarioModelOriginal, VPScenarioModel vpScenarioModelLocal)
    {
        if (vpScenarioModelLocal != null)
        {
            if (vpScenarioModelLocal.VPScenario != null)
            {
                vpScenarioModelOriginal.VPScenario = vpScenarioModelLocal.VPScenario;
            }
            if (vpScenarioModelLocal.VPScenarioLanguageList != null)
            {
                vpScenarioModelOriginal.VPScenarioLanguageList = vpScenarioModelLocal.VPScenarioLanguageList;
            }
            foreach (VPAmbient vpAmbientLocal in vpScenarioModelLocal.VPAmbientList)
            {
                VPAmbient vpAmbientOriginal = vpScenarioModelOriginal.VPAmbientList.Where(c => c.VPAmbientID == vpAmbientLocal.VPAmbientID).FirstOrDefault();
                if (vpAmbientOriginal == null)
                {
                    vpScenarioModelOriginal.VPAmbientList.Add(vpAmbientLocal);
                }
                else
                {
                    vpAmbientOriginal = vpAmbientLocal;
                }
            }
            foreach (VPResult vpResultLocal in vpScenarioModelLocal.VPResultList)
            {
                VPResult vpResultOriginal = vpScenarioModelOriginal.VPResultList.Where(c => c.VPResultID == vpResultLocal.VPResultID).FirstOrDefault();
                if (vpResultOriginal == null)
                {
                    vpScenarioModelOriginal.VPResultList.Add(vpResultLocal);
                }
                else
                {
                    vpResultOriginal = vpResultLocal;
                }
            }
        }
    }
}

