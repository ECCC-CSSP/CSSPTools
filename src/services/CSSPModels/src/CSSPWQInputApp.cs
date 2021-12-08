namespace CSSPModels;

[NotMapped]
public partial class CSSPWQInputApp
{
    [CSSPMaxLength(100)]
    [CSSPMinLength(1)]
    public string AccessCode { get; set; }
    [CSSPMaxLength(4)]
    [CSSPMinLength(4)]
    public string ActiveYear { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double DailyDuplicatePrecisionCriteria { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double IntertechDuplicatePrecisionCriteria { get; set; }
    public bool IncludeLaboratoryQAQC { get; set; }
    [CSSPMaxLength(100)]
    [CSSPMinLength(1)]
    public string ApprovalCode { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime ApprovalDate { get; set; }

    public CSSPWQInputApp() : base()
    {
    }
}

