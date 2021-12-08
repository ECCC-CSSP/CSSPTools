namespace CSSPModels;

[NotMapped]
public partial class VPFull
{
    public VPScenario VPScenario { get; set; }
    public List<VPAmbient> VPAmbientList { get; set; }
    public List<VPResult> VPResultList { get; set; }

    public VPFull() : base()
    {
        VPAmbientList = new List<VPAmbient>();
        VPResultList = new List<VPResult>();
    }
}

