namespace CSSPModels;

[NotMapped]
public partial class RunsToRemoveFromStat
{
    public bool RemoveFromStat { get; set; }
    [CSSPRange(1, -1)]
    public int MWQMRunTVItemID { get; set; }

    public RunsToRemoveFromStat()
    {
    }
}

