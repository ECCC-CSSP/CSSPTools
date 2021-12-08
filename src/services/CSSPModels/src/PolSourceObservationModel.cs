namespace CSSPModels;

[NotMapped]
public partial class PolSourceObservationModel
{
    public PolSourceObservation PolSourceObservation { get; set; }
    public List<PolSourceObservationIssue> PolSourceObservationIssueList { get; set; }

    public PolSourceObservationModel()
    {
        PolSourceObservation = new PolSourceObservation();
        PolSourceObservationIssueList = new List<PolSourceObservationIssue>();
    }
}

