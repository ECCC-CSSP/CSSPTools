namespace CSSPModels;

[NotMapped]
public partial class SearchResult
{
    public TVItem TVItem { get; set; }
    public TVItemLanguage TVItemLanguage { get; set; }

    public SearchResult() : base()
    {
    }
}

