namespace CSSPModels;

[NotMapped]
public partial class VPScenarioModel
{
    public VPScenario VPScenario { get; set; }
    public List<VPScenarioLanguage> VPScenarioLanguageList { get; set; }
    public List<VPAmbient> VPAmbientList { get; set; }
    public List<VPResult> VPResultList { get; set; }

    public VPScenarioModel()
    {
        VPScenario = new VPScenario();
        VPScenarioLanguageList = new List<VPScenarioLanguage>();
        VPAmbientList = new List<VPAmbient>();
        VPResultList = new List<VPResult>();
    }
}

