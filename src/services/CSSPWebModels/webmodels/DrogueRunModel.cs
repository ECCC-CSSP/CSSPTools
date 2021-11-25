namespace CSSPWebModels;

[NotMapped]
public partial class DrogueRunModel
{
    public DrogueRun DrogueRun { get; set; }
    public List<DrogueRunPosition> DrogueRunPositionList { get; set; }

    public DrogueRunModel()
    {
        DrogueRunPositionList = new List<DrogueRunPosition>();
    }
}

