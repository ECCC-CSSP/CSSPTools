namespace CSSPModels;

[NotMapped]
public partial class MWQMRunDataTableModel
{
    public string MWQMSiteName { get; set; }
    public DateTime SampleDate { get; set; }
    public int FC { get; set; }
    public double Sal { get; set; }
    public double Temp { get; set; }
    public string ProcessedBy { get; set; }
    public string SampleTypes { get; set; }
    public string SampleNote { get; set; }

    public MWQMRunDataTableModel()
    {
    }
}

