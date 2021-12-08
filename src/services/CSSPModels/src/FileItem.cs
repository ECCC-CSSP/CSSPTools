namespace CSSPModels;

[NotMapped]
public partial class FileItem
{
    [CSSPMaxLength(255)]
    [CSSPMinLength(1)]
    public string Name { get; set; }
    [CSSPRange(1, -1)]
    public int TVItemID { get; set; }

    public FileItem() : base()
    {
    }
}

