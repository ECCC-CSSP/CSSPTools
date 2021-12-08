namespace CSSPModels;

[NotMapped]
public partial class StatMWQMSiteSample
{
    public int RunIndex { get; set; }
    public int? MWQMSiteTVItemID { get; set; }
    public int? MWQMRunTVItemID { get; set; }
    public int? Samples { get; set; }
    public int? StartYear { get; set; }
    public int? EndYear { get; set; }
    public bool? UseInStat { get; set; }
    public ColorAndLetter ColorAndLetter { get; set; }
    public bool IsActive { get; set; }
    public DateTime SampleDate { get; set; }
    public int? FC { get; set; }
    public double? Sal { get; set; }
    public double? Temp { get; set; }
    public double? PH { get; set; }
    public double? DO { get; set; }
    public double? Depth { get; set; }
    public int? SampCount { get; set; }
    public int? MinFC { get; set; }
    public int? MaxFC { get; set; }
    public double? GeoMean { get; set; }
    public double? Median { get; set; }
    public double? P90 { get; set; }
    public double? PercOver43 { get; set; }
    public double? PercOver260 { get; set; }
    public string DataText { get; set; }
    public DateTime? LastSampleDate { get; set; }
    public int? StatStartYear { get; set; }
    public int? StatEndYear { get; set; }
    public int? SampleYear { get; set; }
    public int? SampleMonth { get; set; }
    public int? SampleDay { get; set; }

    public StatMWQMSiteSample() : base()
    {
    }
}

