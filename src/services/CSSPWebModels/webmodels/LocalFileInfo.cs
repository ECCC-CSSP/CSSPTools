namespace CSSPWebModels;

[NotMapped]
public partial class LocalFileInfo
{
    public int ParentTVItemID { get; set; }
    public string FileName { get; set; }
    public long Length { get; set; }

    public LocalFileInfo()
    {

    }
}

